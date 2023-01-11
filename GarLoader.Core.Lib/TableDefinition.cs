using System;
using System.Collections.Generic;
using System.Linq;
using static GarLoader.Core.Lib.XSD2PGTypes;

namespace GarLoader.Core.Lib
{
    public class TableDefinition
    {
        /// <summary>
        /// Комментарий таблицы
        /// </summary>
        string Comment { get; }

        /// <summary>
        /// Имя схемы
        /// </summary>
        public string SchemaName { get; }

        /// <summary>
        /// Имя таблицы
        /// </summary>
        public string TableName { get; }

        /// <summary>
        /// Колонки
        /// </summary>
        public List<ColumnDefinition> Columns;

        public TableDefinition(string schemaName, string tableName, string comment = null)
        {
            TableName = tableName;
            Comment = comment;
            SchemaName = schemaName;
            Columns = new List<ColumnDefinition>();
        }

        /// <summary>
        /// SQL скрипт комментария таблицы
        /// </summary>
        public string SQLtableComment => string.Format("COMMENT ON TABLE {0}.{1} IS '{2}';", SchemaName, TableName, Comment);

        /// <summary>
        /// SQL создания колонок
        /// </summary>
        public string SQLcolumns => string.Join(",", Columns.Select(x => x.SQLcolumn).ToArray());

        /// <summary>
        /// SQL комментариев колонок
        /// </summary>
        public string SQLcolumnsComment => string.Join(Environment.NewLine, Columns.Select(x => x.SQLcolumnComment(SchemaName, TableName)).ToArray());

        /// <summary>
        /// Полный SQL скрипт таблицы
        /// </summary>
        /// <returns></returns>
        public string SQLtable()
        {
            string template = "CREATE SCHEMA IF NOT EXISTS {2}; CREATE TABLE {2}.{1} ({0});";
            return string.Format(template, SQLcolumns, TableName, SchemaName) + SQLcolumnsComment + SQLtableComment;
        }
    }

    public class ColumnDefinition
    {
        /// <summary>
        /// Имя колонки
        /// </summary>
        public string ColumnName { get; }

        /// <summary>
        /// PostgreSQL тип колонки
        /// </summary>
        public string ColumnType { get; }

        /// <summary>
        /// Комментарий
        /// </summary>
        string Comment { get; }

        /// <summary>
        /// NOT NULL
        /// </summary>
        public bool Required { get; } = false;

        /// <summary>
        /// Npgsql тип
        /// </summary>
        public NpgsqlTypes.NpgsqlDbType NpgsqlDbType { get; }

        public Type NetType { get; }

        public ColumnDefinition(string columnName, XSD2PGType xSD2PGType,
            string comment = null, bool required = false)
        {
            ColumnName = columnName;
            Comment = comment;
            Required = required;
            NetType = xSD2PGType.netType;
            ColumnType = xSD2PGType.pgType;
            NpgsqlDbType = xSD2PGType.NpgsqlDbType;
        }

        public string SQLcolumn => DBcolumn + " " + ColumnType + (Required ? " NOT NULL" : "") ;
     
        /// <summary>
        /// Имя колонки в БД
        /// </summary>
        public string DBcolumn
        {
            get
            {
                if (ColumnName == "desc")
                {
                    return (char)34 + ColumnName + (char)34;
                }
                else
                {
                    return ColumnName;
                }
            }
        }

        /// <summary>
        /// SQL скрип комментария для колонки
        /// </summary>
        /// <param name="schemaName">Имя схемы</param>
        /// <param name="tableName">Имя таблицы</param>
        /// <returns></returns>
        public string SQLcolumnComment(string schemaName, string tableName)
        {
            return string.Format("COMMENT ON COLUMN {0}.{1}.{2} IS '{3}';", schemaName, tableName, ColumnName, Comment);
        }
    }
}