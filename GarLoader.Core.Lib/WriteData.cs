using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using static GarLoader.Core.Lib.XSD2PGTypes;

namespace GarLoader.Core.Lib
{
    public class WriteData
    {
        public List<XSD2PGType> typesList;
        TableDefinition tableDefinition;
        private Npgsql.NpgsqlConnection _conn;
        Npgsql.NpgsqlBinaryImporter _wrt;
        int bulkSize;
        string _dbTableName, _dbColumns, xmlFile;
        public int percentage;
        string ConnectionString;
        public WriteData(TableDefinition TableDefinition, string InputXml, string connString, int BulkSize = 50000)
        {
            typesList = (new XSD2PGTypes()).Types;
            tableDefinition = TableDefinition;
            ConnectionString = connString;
            // Задаю соединение
            _conn = new Npgsql.NpgsqlConnection(ConnectionString);
            _conn.Open();

            // Открываем операцию копирования
            _dbTableName = tableDefinition.schemaName + "." + tableDefinition.tableName;
            Console.WriteLine(tableDefinition.schemaName);
            _dbColumns = string.Join(",", tableDefinition.columns.Select(c => c.DBcolumn).ToArray());
            _wrt = _conn.BeginBinaryImport(string.Format("COPY {0} ({1}) FROM STDIN (FORMAT BINARY)", _dbTableName, _dbColumns));
            xmlFile = InputXml;

            bulkSize = BulkSize;
        }

        public async System.Threading.Tasks.Task ReadXmlAsync(Action<int> percentProgress)
        {
            string xmlPath = xmlFile;

            // Счетчик элементов
            int i = 0;

            // Инициализация XMLReader
            System.IO.FileStream sr = new System.IO.FileStream(xmlPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.Xml.XmlReaderSettings _settings = new System.Xml.XmlReaderSettings() { Async = true };
            System.Xml.XmlReader rdr = System.Xml.XmlReader.Create(sr, _settings);
            long lastPosition = 0;
            while (await rdr.ReadAsync())
            {
                rdr.MoveToContent();

                // Новая строка
                BulkData _pair = new BulkData(tableDefinition, typesList);

                // Чтение элемента
                while (rdr.MoveToNextAttribute())
                {
                    if (rdr.NodeType == System.Xml.XmlNodeType.Attribute)
                        _pair.InsertCell(rdr.Name.ToLower(), rdr.Value);
                }
                i += 1;

                percentage = (int)Math.Round((double)(sr.Position / sr.Length), 2) * 100;

                if (lastPosition != sr.Position)
                {
                    lastPosition = sr.Position;

                    percentage = (int)(100.0 * lastPosition / sr.Length);
                    percentProgress(percentage);
                }

                // Вставка
                CancellationTokenSource source = new CancellationTokenSource();
                CancellationToken token = source.Token;
                await _wrt.WriteRowAsync(token, _pair.GetRow());



                
                //Проверяем достигнут ли максимальный размер списка
                if (i == bulkSize)
                {
                    await _wrt.CompleteAsync();
                    await _wrt.CloseAsync();
                    i = 0;
                    _wrt = _conn.BeginBinaryImport(string.Format("COPY {0} ({1}) FROM STDIN (FORMAT BINARY)", _dbTableName, _dbColumns));
                    if (percentProgress != null)
                    {
                        percentProgress(percentage);
                    }
                    
                    
                }
            }

            await _wrt.CompleteAsync();
            if (percentProgress != null)
            {
                percentProgress(percentage);
            }
            await _wrt.CloseAsync();
            await _conn.CloseAsync();
            }

        class BulkData
        {
            List<XSD2PGType> typesList { get; set; }
            TableDefinition tableDefinition;
            public List<BulkRecord> Data { get; }
            public BulkData(TableDefinition TableDefinition, List<XSD2PGType> TypesList)
            {
                Data = new List<BulkRecord>();
                typesList = TypesList;
                tableDefinition = TableDefinition;
            }

            public void InsertCell(string ColumnName, object Value)
            {
                string _pgType = tableDefinition.columns.Where(y => y.columnName == ColumnName).FirstOrDefault().columnType;
                Type _targetType = typesList.Where(x => x.pgType == _pgType).FirstOrDefault().netType;
                object _targetValue = null;

                if (Value != null)
                {
                    if (Value.ToString().Length > 0)
                    {
                        if (_targetType.Equals((new DateTime()).GetType()))
                            _targetValue = new NpgsqlTypes.NpgsqlDate(Convert.ToDateTime(Value));
                        else
                            _targetValue = Commons.ChangeType(Value, _targetType);
                    }
                }
                Data.Add(new BulkRecord(ColumnName, _targetValue));
            }

            public object[] GetRow()
            {
                List<object> values = new List<object>();
                foreach (ColumnDefinition c in tableDefinition.columns)
                {
                    if (Data.Where(d => d.ColumnName == c.columnName).Count() > 0)
                    {
                        values.Add(Data.Where(d => d.ColumnName == c.columnName).FirstOrDefault().ObjectValue);
                    }
                    else
                    {
                        values.Add(null);
                    }
                }
                return values.ToArray();
            }
        }

        class BulkRecord
        {
            public string ColumnName { get; set; }
            public object ObjectValue { get; set; }
            public BulkRecord(string columnName, object value)
            {
                ColumnName = columnName;
                ObjectValue = value;
            }
        }
    }
}