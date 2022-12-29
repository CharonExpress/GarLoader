using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private  TableDefinition XSDToTableDefinition(string XsdPath, string TableName, string schemaName = "fias")
        {
            System.Xml.XmlDocument _doc = new System.Xml.XmlDocument();
            _doc.Load(XsdPath);
            System.Xml.XmlNamespaceManager _nsMan = new System.Xml.XmlNamespaceManager(_doc.NameTable);
            _nsMan.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");

            string tableComment;
            try
            {
                tableComment = _doc.
                    SelectSingleNode("xs:schema/xs:element/xs:complexType/xs:sequence/xs:element/xs:annotation/xs:documentation", _nsMan).
                    InnerText;
            }
            catch (Exception q)
            {
                tableComment = q.Message;
            }

            TableDefinition _table = new TableDefinition(schemaName.ToLower(), TableName.ToLower(),
                tableComment);

            System.Xml.XmlNodeList xsdColumns = _doc.SelectNodes(".//xs:attribute", _nsMan);

            List<XSD2PGTypes.XSD2PGType> typesConversion = (new XSD2PGTypes()).Types;

            // Список столбцов
            for (int i = 0; i <= xsdColumns.Count - 1; i++)
            {
                System.Xml.XmlNode _c = xsdColumns[i];
                string colName = _c.SelectSingleNode("@name", _nsMan).Value.ToLower();
                string colComment = _c.SelectSingleNode("xs:annotation/xs:documentation", _nsMan).
                    InnerText;
                string xsdcolType;
                XmlNode requiredNode = _c.SelectSingleNode("@use");
                bool required = requiredNode != null && requiredNode.Value == "required";
                XmlNode xsdcolTypeNode = _c.SelectSingleNode("@type|xs:simpleType/xs:restriction/@base",
                        _nsMan);
                xsdcolType = xsdcolTypeNode != null ? xsdcolTypeNode.Value : "xs:string";

#if DEBUG
                Console.WriteLine(xsdcolType);
#endif
                string colType = typesConversion.Where(x => x.xsdType == xsdcolType).Single().pgType;

                _table.columns.Add(new(colName, colType, colComment, required));
            }
            return _table;
        }
    }
}
