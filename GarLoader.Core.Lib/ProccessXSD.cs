using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace GarLoader.Core.Lib
{
    public class ProccessXSD
    {
        public  TableDefinition XSDToTableDefinition(string XsdPath, string schemaName = "fias")
        {
            string _tableName = GetTablesNames.GetTableName(XsdPath);
            return XSDToTableDefinition(XsdPath, _tableName, schemaName);
        }
        private  TableDefinition XSDToTableDefinition(string XsdPath, 
            string TableName, string schemaName = "fias")
        {
            XmlDocument doc = new();
            doc.Load(XsdPath);
            XmlNamespaceManager nsMan = new(doc.NameTable);
            nsMan.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");

            string tableComment;
            try
            {
                tableComment = doc.
                    SelectSingleNode("xs:schema/xs:element/xs:complexType/xs:sequence/xs:element/xs:annotation/xs:documentation", nsMan).
                    InnerText;
            }
            catch (Exception q)
            {
                tableComment = q.Message;
            }

            TableDefinition table = new(schemaName.ToLower(), TableName.ToLower(),
                tableComment);

            XmlNodeList xsdColumns = doc.SelectNodes(".//xs:attribute", nsMan);

            List<XSD2PGTypes.XSD2PGType> typesConversion = (new XSD2PGTypes()).Types;

            // Список столбцов
            for (int i = 0; i <= xsdColumns.Count - 1; i++)
            {
                XmlNode _c = xsdColumns[i];
                string colName = _c.SelectSingleNode("@name", nsMan).Value.ToLower();
                string colComment = _c.SelectSingleNode("xs:annotation/xs:documentation", nsMan).
                    InnerText;
                string xsdcolType;
                XmlNode requiredNode = _c.SelectSingleNode("@use");
                bool required = requiredNode != null && requiredNode.Value == "Required";
                XmlNode xsdcolTypeNode = _c.SelectSingleNode("@type|xs:simpleType/xs:restriction/@base",
                        nsMan);
                xsdcolType = xsdcolTypeNode != null ? xsdcolTypeNode.Value : "xs:string";

#if DEBUG
                Console.WriteLine(xsdcolType);
#endif
                XSD2PGTypes.XSD2PGType columnType;

                #region "GUID костыль"
                if (colComment.Contains("UUID") || colComment.Contains("GUID"))
                {
                    columnType = typesConversion.Where(x => x.netType == typeof(Guid)).Single();
                }
                else
                {
                    columnType = typesConversion.Where(x => x.xsdType == xsdcolType).Single();
                }
                #endregion

                NpgsqlTypes.NpgsqlDbType npgSqlType = columnType.NpgsqlDbType;

                table.Columns.Add(new(colName, columnType, colComment, required));
            }
            return table;
        }
    }
}
