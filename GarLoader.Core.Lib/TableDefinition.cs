using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarLoader.Core.Lib
{
    public class TableDefinition
    {
        string comment;
        public string schemaName;
        public string tableName;
        public List<ColumnDefinition> columns;

        public TableDefinition(string schemaName, string tableName, string comment = null)
        {
            this.tableName = tableName;
            this.comment = comment;
            this.schemaName = schemaName;
            this.columns = new List<ColumnDefinition>();
        }

        public string SQLtableComment => string.Format("COMMENT ON TABLE {0}.{1} IS '{2}';", schemaName, tableName, comment);

        public string SQLcolumns => string.Join(",", columns.Select(x => x.SQLcolumn).ToArray());

        public string SQLcolumnsComment => string.Join(Environment.NewLine, columns.Select(x => x.SQLcolumnComment(schemaName, tableName)).ToArray());

        public string SQLtable()
        {
            string template = "CREATE SCHEMA IF NOT EXISTS {2}; CREATE TABLE {2}.{1} ({0});";
            return string.Format(template, SQLcolumns, tableName, schemaName) + SQLcolumnsComment + SQLtableComment;
        }
    }

    public class ColumnDefinition
    {
        public string columnName;
        public string columnType;
        string comment;
        bool required = false;
        public ColumnDefinition(string columnName, 
            string columnType, 
            string comment = null, 
            bool required = false)
        {
            this.columnName = columnName;
            this.columnType = columnType;
            this.comment = comment;
            this.required = required;
        }

        public string SQLcolumn => DBcolumn + " " + columnType + (required ? " NOT NULL" : "") ;
     

        public string DBcolumn
        {
            get
            {
                if (columnName == "desc")
                {
                    return (char)34 + columnName + (char)34;
                }
                else
                {
                    return columnName;
                }
            }
        }


        public string SQLcolumnComment(string schemaName, string tableName)
        {
            return string.Format("COMMENT ON COLUMN {0}.{1}.{2} IS '{3}';", schemaName, tableName, columnName, comment);
        }
    }
}