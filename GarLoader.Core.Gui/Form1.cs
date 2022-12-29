using GarLoader.Core.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GarLoader.Core.Gui
{
    public partial class Form1 : Form
    {
        string _cs;
        public Form1()
        {
            InitializeComponent();
        }

        public string TargetSchema
        {
            get
            {
                if (string.IsNullOrWhiteSpace(targetSchemaBox.Text))
                {
                    return "fias";
                }
                else
                {
                    return targetSchemaBox.Text;
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ResetProgressBar();
            textBox1.Enabled = true;
        }

        /// <summary>
        /// Програссбар
        /// </summary>
        void ResetProgressBar()
        {
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            progressBar1.Step = 1;
        }

        private async void SelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string folder = dlg.SelectedPath;
                await BurnDaHausAsync(folder);
            }
        }

        /// <summary>
        /// TODO: переименовать во что-то более осмысленное
        /// </summary>
        /// <param name="Folder"></param>
        /// <returns></returns>
        private async System.Threading.Tasks.Task BurnDaHausAsync(string Folder)
        {
            string _folder = Folder;
            string xmlPath = _folder;
            string xsdPath = _folder;
            string originalText = Text;
            Dictionary<string, string> tables = GetTablesNames.GetTables(xsdPath);

            foreach (KeyValuePair<string, string> table in tables.AsEnumerable())
            {
                ResetProgressBar();
                Text = table.Value;
                Action<int> progress = new Action<int>(ProgressChanged);
                string[] files = GetXMLSBySchema(table.Value, xmlPath, true);



                ProccessXSD proc = new ProccessXSD();
                TableDefinition def = proc.XSDToTableDefinition(table.Key, TargetSchema);
                if (def.tableName == "as_param")
                {
                    ResetProgressBar();
                    Action<int> localProgress = new Action<int>(ProgressChanged);
                    string[] paramXmls = System.IO.Directory.GetFiles(xmlPath, "AS_*_PARAMS_*.xml", System.IO.SearchOption.AllDirectories);
                    foreach (string paramXml in paramXmls)
                    {
                        textBox1.Text = paramXml;
                        WriteData paramWrt = new WriteData(def, paramXml, _cs, 100);
                        await paramWrt.ReadXmlAsync(localProgress);
                    }
                    continue;
                }

                if (files.Count() < 1)
                {
                    continue;
                }

                foreach (string xmlfile in files)
                {
                    textBox1.Text = xmlfile;
                    WriteData wrt = new WriteData(def, xmlfile, _cs);
                    await wrt.ReadXmlAsync(progress);
                }
            }
            Text = originalText;
            ResetProgressBar();
        }

        private string[] GetXMLSBySchema(string SchemaName, string Folder, bool SearchSubs = true)
        {
            string[] xmls;
            if (SearchSubs)
            {
                xmls = System.IO.Directory.GetFiles(Folder, SchemaName + "_2*.xml", System.IO.SearchOption.AllDirectories);
            }
            else
            {
                xmls = System.IO.Directory.GetFiles(Folder, SchemaName + "_2*.xml", System.IO.SearchOption.TopDirectoryOnly);
            }
            return xmls;
        }

        private void ProgressChanged(int smth)
        {
            reportProgressInt(smth, progressBar1);
        }

        private delegate void reportProgressInvoker(int smth, ProgressBar bar);

        private void reportProgressInt(int smth, ProgressBar bar)
        {
            if (bar.InvokeRequired)
                bar.Invoke(new reportProgressInvoker(reportProgressInt), smth, bar);
            else
            {
                bar.Value = smth;
            }
        }

        private void CreatTablesButt_Click(object sender, EventArgs e)
        {
            string ConnectionString = _cs;
            Npgsql.NpgsqlConnection _conn = new Npgsql.NpgsqlConnection(ConnectionString);
            _conn.Open();
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            Dictionary<string, string> xsdFiles = GetTablesNames.GetTables(dlg.SelectedPath);
            foreach (KeyValuePair<string, string> _filePath in xsdFiles)
            {
                ProccessXSD proc = new ProccessXSD();
                TableDefinition def = proc.XSDToTableDefinition(_filePath.Key, TargetSchema);
                Console.WriteLine(def.SQLtable());
                Npgsql.NpgsqlCommand _cmd = new Npgsql.NpgsqlCommand(def.SQLtable(), _conn);
                _cmd.ExecuteNonQuery();

                ///Запись sql в файл для каждой таблицы
#if Debug
string file = System.IO.Path.Combine(System.IO.Directory.GetParent(_filePath.Key).FullName, _filePath.Value + ".sql");
                System.IO.StreamWriter wrt = new System.IO.StreamWriter(file);
                wrt.WriteLine(def.SQLtable());
                wrt.Flush();
                wrt.Close();
#endif

            }
            _conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string[] mustHaves = { "Server", "MinPoolSize", "MaxPoolSize", "Port", "Database", "Userid" };
            try
            {
                if (textBox1.Text.Length < 90)
                {
                    return;
                }

                foreach (string musthave in mustHaves)
                {
                    bool checkPoint = textBox1.Text.Contains(musthave);
                    if (!checkPoint)
                    {
                        return;
                    }
                }

                Npgsql.NpgsqlConnection conn = new(textBox1.Text);

                conn.Open();
                _cs = textBox1.Text;
                conn.Close();
                textBox1.Text = default;
                textBox1.Enabled = false;
                CreatTablesButt.Enabled = true;
                FolderSelectButton.Enabled = true;

                string[] specialValues = { "192.168.2.145", "192.168.1.42", "avalon.geo-volodarsk.com" };
                foreach (string specialV in specialValues)
                {
                    if (_cs.Contains(specialV))
                    {
                        string newName = System
                            .Text.Encoding
                            .UTF8.GetString(Convert
                            .FromBase64String("0KHQvtC30LTQsNGC0Ywg0YHRgNCw0L3Ri9C1INGC0LDQsdC70LjRhtGL"));
                        CreatTablesButt.Text = newName;
                    }
                }
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            
        }
    }
}
