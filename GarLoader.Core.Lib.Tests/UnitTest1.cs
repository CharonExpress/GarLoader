using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace GarLoader.Core.Lib.Tests
{
    [TestClass]
    public class UnitTest1
    {
        string ConnectionString = "Server=192.168.2.145;Port=5432;Database=fias;Userid=postgres;Password=admin;Pooling=true;MinPoolSize=1;MaxPoolSize=20;";
        [TestMethod]
        public void TestRenaming()
        {
            List<string> xsdFiles = Directory.
                GetFiles(@"C:\Users\Shadow\Downloads\gar_schemas", "*.xsd",
                SearchOption.TopDirectoryOnly).ToList();

            foreach (var _filePath in xsdFiles)
            {
                var fileName = Path.GetFileName(_filePath);
                var clearFilename = Regex.Replace(fileName, @"[\d-]", string.Empty);
                Console.WriteLine(Regex.Replace(clearFilename, @"([_])\1+", string.Empty));
            }
        }

        [TestMethod]
        public void TestCreatingSQLs()
        {
            string ConnectionString = "Server=192.168.2.145;Port=5432;Database=fias_x;Userid=postgres;Password=admin;Pooling=true;MinPoolSize=1;MaxPoolSize=20;";
            Npgsql.NpgsqlConnection _conn = new Npgsql.NpgsqlConnection(ConnectionString);
            _conn.Open();
            var xsdFiles = GetTablesNames.GetTables(@"C:\Users\Shadow\Downloads\gar_schemas");
            foreach (var _filePath in xsdFiles)
            {
                ProccessXSD proc = new ProccessXSD();
                var def = proc.XSDToTableDefinition(_filePath.Key);
                Console.WriteLine(def.SQLtable());
                var _cmd = new Npgsql.NpgsqlCommand(def.SQLtable(), _conn);
                _cmd.ExecuteNonQuery();

                var file = Path.Combine(Directory.GetParent(_filePath.Key).FullName, _filePath.Value + ".sql");
                var wrt = new System.IO.StreamWriter(file);
                wrt.WriteLine(def.SQLtable());
                wrt.Flush();
                wrt.Close();
            }
            _conn.Close();
        }

        [TestMethod]
        public async System.Threading.Tasks.Task TestLoadingFileAsync()
        {
            //string ConnectionString = "Server=192.168.2.145;Port=5432;Database=fias;Userid=postgres;Password=admin;Pooling=true;MinPoolSize=1;MaxPoolSize=20;";

            var xsdFile = GetTablesNames.GetTables(@"C:\Users\Shadow\Downloads\gar_schemas\Новая папка");
            var _filePath = xsdFile.First();
            ProccessXSD proc = new ProccessXSD();
            var def = proc.XSDToTableDefinition(_filePath.Key);
            var wrt = new WriteData(def, @"C:\Users\Shadow\Downloads\gar_schemas\Новая папка\AS_PARAM_TYPES_20201210_1fe12d2c-ddfa-438c-9d03-98f936a61ef6.XML", ConnectionString);
            await wrt.ReadXmlAsync(null);
        }

        [TestMethod]
        public void TestXsdAndXml()
        {
            string xmlPath = @"\\192.168.2.145\LargeStorage\Software\gar_xml";
            string xsdPath = @"C:\Users\Shadow\Downloads\gar_schemas";
            Dictionary<string, string> tables = GetTablesNames.GetTables(xsdPath);

            foreach (KeyValuePair<string, string> table in tables.AsEnumerable())
            {
                Console.WriteLine(table.Value);
                if (table.Value == "as_param")
                {
                    var paramXmls = Directory.GetFiles(xmlPath, "AS_*_PARAMS_2*.xml", SearchOption.AllDirectories);
                    foreach (string paramXml in paramXmls)
                    {
                        Console.WriteLine($"Ебучий параметры {table.Key} {paramXml}");
                    }
                    continue;
                }

                var files = Directory.GetFiles(xmlPath, table.Value + "_2*.xml", SearchOption.AllDirectories);
                foreach (string filename in files)
                {
Console.WriteLine($"{filename}");
                }
                
            }

        }

        [TestMethod]
        public async System.Threading.Tasks.Task TestLiadingFilesAsync()
        {
            string xmlPath = @"C:\Users\Shadow\Downloads\gar_schemas\Новая папка";
            string xsdPath = @"C:\Users\Shadow\Downloads\gar_schemas";
            Dictionary<string, string> tables = GetTablesNames.GetTables(xsdPath);

            foreach (KeyValuePair<string, string> table in tables.AsEnumerable())
            {
                var files = Directory.GetFiles(xmlPath, table.Value + "*.xml");
                if (files.Count() < 1)
                {
                    continue;
                }
                Console.WriteLine($"{table.Key} {table.Value} {files.First()}");
                ProccessXSD proc = new ProccessXSD();
                var def = proc.XSDToTableDefinition(table.Key);
                if (def.tableName == "as_param")
                {
                    var paramXmls = Directory.GetFiles(xmlPath, "AS_*_PARAMS_*.xml");
                    foreach (string paramXml in paramXmls)
                    {
                        var paramWrt = new WriteData(def, paramXml, ConnectionString);
                        await paramWrt.ReadXmlAsync(null);
                    }
                    continue;
                }
                var wrt = new WriteData(def, files.First(), ConnectionString);
                await wrt.ReadXmlAsync(null);
            }
        }

        [TestMethod]
        public void TestBooleanConverter()
        {
            string t = "1";
            Console.WriteLine(Commons.ChangeType(t, typeof(bool)));
        }
    }
}