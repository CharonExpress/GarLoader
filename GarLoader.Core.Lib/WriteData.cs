using System;
using System.Collections.Generic;
using NpgsqlTypes;
using System.Linq;
using System.Threading;

namespace GarLoader.Core.Lib
{
    public class WriteData
    {
        TableDefinition tableDefinition;
        private Npgsql.NpgsqlConnection _conn;
        Npgsql.NpgsqlBinaryImporter _wrt;
        int bulkSize;
        string _dbTableName, _dbColumns, xmlFile;
        public int percentage;
        string ConnectionString;
        private readonly Action<string> logger;
        public WriteData(TableDefinition TableDefinition,
            string InputXml,
            string connString,
            int BulkSize = 50000,
            Action<string> loggerAction = null)
        {
            tableDefinition = TableDefinition;
            ConnectionString = connString;
            logger = loggerAction;
            // Задаю соединение
            _conn = new Npgsql.NpgsqlConnection(ConnectionString);
            _conn.Open();

            // Открываем операцию копирования
            _dbTableName = tableDefinition.SchemaName + "." + tableDefinition.TableName;
            Console.WriteLine(tableDefinition.SchemaName);
            _dbColumns = string.Join(",", tableDefinition.Columns.Select(c => c.DBcolumn).ToArray());
            string copyCommand = string.Format("COPY {0} ({1}) FROM STDIN (FORMAT BINARY)", _dbTableName, _dbColumns);
            _wrt = _conn.BeginBinaryImport(copyCommand);
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
                BulkData _pair = new BulkData(tableDefinition);

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

                //Changed from NpgsqlBinaryImporter.WriteRow to Write
                if (_pair.HasData && _pair.IsValid)
                {
                    await _wrt.StartRowAsync(token);
                    var columns = _pair.GetColumns();
                    foreach (var column in columns)
                    {
                        if (column.Item2 == null)
                        {
                            await _wrt.WriteNullAsync(token);
                        }
                        else
                        {
                            await _wrt.WriteAsync(column.Item1, column.Item2.Value, token);
                        }
                    }
                }

                if (!_pair.IsValid && logger != null) logger.
                        Invoke($"В данных для таблицы {tableDefinition.TableName} " +
                        $"присутствует строка с обязательным, " +
                        $"но пустым значением. " +
                        $"Строка содержит {_pair.GetColumns().
                        Select(val => val.Item1.ToString())} ");


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
            TableDefinition tableDefinition;
            public List<BulkRecord> Data { get; }

            /// <summary>
            /// Проверка если колонка NOT NULL но при этом в XML отсутствует значение
            /// </summary>
            public bool IsValid { get; private set; } = true;

            public bool HasData => Data.Count > 0;
            public BulkData(TableDefinition TableDefinition)
            {
                Data = new List<BulkRecord>();
                tableDefinition = TableDefinition;
            }

            public void InsertCell(string ColumnName, object Value)
            {
                var columnDefinition = tableDefinition.Columns.
                    Where(y => y.ColumnName == ColumnName).FirstOrDefault();

                Type targetNetType = columnDefinition.NetType;

                object targetValue = null;

                if (Value != null && Value.ToString().Length > 0)
                {
                    targetValue = Commons.ChangeType(Value, targetNetType);
                }

                if (Value == null && columnDefinition.Required) IsValid = false;

                Data.Add(new BulkRecord(ColumnName, targetValue, columnDefinition.NpgsqlDbType));
            }

            public IEnumerable<Tuple<object, NpgsqlDbType?>> GetColumns()
            {
                List<Tuple<object, NpgsqlDbType?>> items = new();
                foreach (ColumnDefinition columnDefinition in tableDefinition.Columns)
                {
                    var column = Data.Where(data => data.ColumnName ==
                    columnDefinition.ColumnName);
                    if (column.Count() > 0)
                    {
                        object objectValue = column.FirstOrDefault().ObjectValue;

                        NpgsqlDbType npgsqlDbType = columnDefinition.NpgsqlDbType;
                        items.Add(new(objectValue, npgsqlDbType));
                    }
                    else
                    {
                        items.Add(new(null, null));
                    }
                }
                return items;
            }
        }

        class BulkRecord
        {
            public string ColumnName { get; set; }

            public object ObjectValue { get; set; }

            public NpgsqlDbType NpgsqlDbType { get; set; }

            public BulkRecord(string columnName, object value, NpgsqlDbType npgsqlDbType)
            {
                ColumnName = columnName;
                ObjectValue = value;
                NpgsqlDbType = npgsqlDbType;
            }
        }
    }
}