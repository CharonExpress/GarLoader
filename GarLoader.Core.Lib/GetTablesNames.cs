using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace GarLoader.Core.Lib
{
    public class GetTablesNames
    {
        public static Dictionary<string, string> GetTables(string XsdPath)
        {
            Dictionary<string, string> FilesTables = new Dictionary<string, string>();
            List<string> xsdFiles = Directory.
                GetFiles(XsdPath, "*.xsd",
                SearchOption.TopDirectoryOnly).ToList();

            foreach (string _filePath in xsdFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(_filePath);
                string fileNameWOnumbers = Regex.Replace(fileName, @"[\d-]", string.Empty);
                string tableName = Regex.Replace(fileNameWOnumbers, @"([_])\1+", string.Empty).ToLower();
                FilesTables.Add(_filePath, tableName);
            }
            return FilesTables;
        }

        public static string GetTableName(string XsdPath)
        {
            string fileName = Path.GetFileNameWithoutExtension(XsdPath);
            string fileNameWOnumbers = Regex.Replace(fileName, @"[\d-]", string.Empty);
            string tableName = Regex.Replace(fileNameWOnumbers, @"([_])\1+", string.Empty).ToLower();
            return tableName;
        }
    }
}
