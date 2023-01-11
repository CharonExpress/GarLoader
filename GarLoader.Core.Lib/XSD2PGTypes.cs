using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace GarLoader.Core.Lib
{
    public class XSD2PGTypes
    {
        public List<XSD2PGType> Types = new List<XSD2PGType>();
        public XSD2PGTypes()
        {
            Types.Add(new XSD2PGType("xs:string", typeof(string), "text", NpgsqlDbType.Text));
            Types.Add(new XSD2PGType("xs:none", typeof(Guid), "uuid", NpgsqlDbType.Uuid));
            Types.Add(new XSD2PGType("xs:date", typeof(DateTime), "date", NpgsqlDbType.Date));
            Types.Add(new XSD2PGType("xs:integer", typeof(Int32), "integer", NpgsqlDbType.Integer));
            Types.Add(new XSD2PGType("xs:byte", typeof(short), "smallint", NpgsqlDbType.Smallint));
            Types.Add(new XSD2PGType("xs:int", typeof(Int32), "integer", NpgsqlDbType.Integer));
            Types.Add(new XSD2PGType("xs:boolean", typeof(bool), "boolean", NpgsqlDbType.Boolean));
            Types.Add(new XSD2PGType("xs:long", typeof(Int64), "bigint", NpgsqlDbType.Bigint));
        }

        public class XSD2PGType
        {
            public string xsdType;
            
            public Type netType;

            public string pgType;

            public NpgsqlDbType NpgsqlDbType;
            public XSD2PGType(string _xsdType, 
                Type _netType, 
                string _pgType, 
                NpgsqlDbType npgsqlDbType)
            {
                xsdType = _xsdType;
                netType = _netType;
                pgType = _pgType;
                NpgsqlDbType = npgsqlDbType;
            }
        }
    }


}
