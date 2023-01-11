
namespace GarLoader.Core.Gui
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.FolderSelectButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CreatTablesButt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.targetSchemaBox = new System.Windows.Forms.TextBox();
            this.SelectXsdButton = new System.Windows.Forms.Button();
            this.SearchSubFoldersBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.Maroon;
            this.progressBar1.Location = new System.Drawing.Point(12, 97);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(668, 30);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 2;
            // 
            // FolderSelectButton
            // 
            this.FolderSelectButton.Enabled = false;
            this.FolderSelectButton.Location = new System.Drawing.Point(166, 7);
            this.FolderSelectButton.Name = "FolderSelectButton";
            this.FolderSelectButton.Size = new System.Drawing.Size(128, 43);
            this.FolderSelectButton.TabIndex = 3;
            this.FolderSelectButton.Text = "Выбрать папку с XML";
            this.FolderSelectButton.UseVisualStyleBackColor = true;
            this.FolderSelectButton.Click += new System.EventHandler(this.SelectFolder_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 56);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(668, 36);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // CreatTablesButt
            // 
            this.CreatTablesButt.Enabled = false;
            this.CreatTablesButt.Location = new System.Drawing.Point(300, 7);
            this.CreatTablesButt.Name = "CreatTablesButt";
            this.CreatTablesButt.Size = new System.Drawing.Size(125, 43);
            this.CreatTablesButt.TabIndex = 5;
            this.CreatTablesButt.Text = "Создать таблицы";
            this.CreatTablesButt.UseVisualStyleBackColor = true;
            this.CreatTablesButt.Click += new System.EventHandler(this.CreatTablesButt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(428, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Схема";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // targetSchemaBox
            // 
            this.targetSchemaBox.Location = new System.Drawing.Point(476, 5);
            this.targetSchemaBox.Name = "targetSchemaBox";
            this.targetSchemaBox.PlaceholderText = "fias";
            this.targetSchemaBox.Size = new System.Drawing.Size(204, 23);
            this.targetSchemaBox.TabIndex = 7;
            // 
            // SelectXsdButton
            // 
            this.SelectXsdButton.Enabled = false;
            this.SelectXsdButton.Location = new System.Drawing.Point(12, 7);
            this.SelectXsdButton.Name = "SelectXsdButton";
            this.SelectXsdButton.Size = new System.Drawing.Size(148, 43);
            this.SelectXsdButton.TabIndex = 8;
            this.SelectXsdButton.Text = "Выбрать папку со схемами";
            this.SelectXsdButton.UseVisualStyleBackColor = true;
            this.SelectXsdButton.Click += new System.EventHandler(this.SelectXsdButton_Click);
            // 
            // SearchSubFoldersBox
            // 
            this.SearchSubFoldersBox.AutoSize = true;
            this.SearchSubFoldersBox.Location = new System.Drawing.Point(459, 33);
            this.SearchSubFoldersBox.Name = "SearchSubFoldersBox";
            this.SearchSubFoldersBox.Size = new System.Drawing.Size(188, 19);
            this.SearchSubFoldersBox.TabIndex = 9;
            this.SearchSubFoldersBox.Text = "Искать во вложенных папках";
            this.SearchSubFoldersBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 139);
            this.Controls.Add(this.SearchSubFoldersBox);
            this.Controls.Add(this.SelectXsdButton);
            this.Controls.Add(this.targetSchemaBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CreatTablesButt);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.FolderSelectButton);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Загрузка ГАР";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button FolderSelectButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button CreatTablesButt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox targetSchemaBox;
        private System.Windows.Forms.Button SelectXsdButton;
        private System.Windows.Forms.CheckBox SearchSubFoldersBox;
    }
}

