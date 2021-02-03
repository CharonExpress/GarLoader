using System;
using System.Collections.Generic;
using System.Text;

namespace GarLoader.Core.Lib
{
    public class XSD2PGTypes
    {
        public List<XSD2PGType> Types = new List<XSD2PGType>();
        public XSD2PGTypes()
        {
            Types.Add(new XSD2PGType("xs:string", typeof(string), "text"));
            Types.Add(new XSD2PGType("xs:none", typeof(Guid), "uuid"));
            Types.Add(new XSD2PGType("xs:date", typeof(DateTime), "date"));
            Types.Add(new XSD2PGType("xs:integer", typeof(Int32), "integer"));
            Types.Add(new XSD2PGType("xs:byte", typeof(Int32), "integer"));
            Types.Add(new XSD2PGType("xs:int", typeof(Int32), "integer"));
            Types.Add(new XSD2PGType("xs:boolean", typeof(bool), "boolean"));
            Types.Add(new XSD2PGType("xs:long", typeof(Int64), "bigint"));
        }

        public class XSD2PGType
        {
            public string xsdType;
            public Type netType;
            public string pgType;
            public XSD2PGType(string _xsdType, Type _netType, string _pgType)
            {
                xsdType = _xsdType;
                netType = _netType;
                pgType = _pgType;
            }
        }
    }


}
