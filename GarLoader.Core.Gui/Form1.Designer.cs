
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
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.Maroon;
            this.progressBar1.Location = new System.Drawing.Point(12, 97);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(776, 30);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 2;
            // 
            // FolderSelectButton
            // 
            this.FolderSelectButton.Enabled = false;
            this.FolderSelectButton.Location = new System.Drawing.Point(12, 12);
            this.FolderSelectButton.Name = "FolderSelectButton";
            this.FolderSelectButton.Size = new System.Drawing.Size(229, 30);
            this.FolderSelectButton.TabIndex = 3;
            this.FolderSelectButton.Text = "Выбрать папку с файлами схем и XML";
            this.FolderSelectButton.UseVisualStyleBackColor = true;
            this.FolderSelectButton.Click += new System.EventHandler(this.SelectFolder_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 48);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(776, 44);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // CreatTablesButt
            // 
            this.CreatTablesButt.Enabled = false;
            this.CreatTablesButt.Location = new System.Drawing.Point(247, 12);
            this.CreatTablesButt.Name = "CreatTablesButt";
            this.CreatTablesButt.Size = new System.Drawing.Size(153, 30);
            this.CreatTablesButt.TabIndex = 5;
            this.CreatTablesButt.Text = "Создать таблицы";
            this.CreatTablesButt.UseVisualStyleBackColor = true;
            this.CreatTablesButt.Click += new System.EventHandler(this.CreatTablesButt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(421, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Схема";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // targetSchemaBox
            // 
            this.targetSchemaBox.Location = new System.Drawing.Point(469, 12);
            this.targetSchemaBox.Name = "targetSchemaBox";
            this.targetSchemaBox.Size = new System.Drawing.Size(204, 23);
            this.targetSchemaBox.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 139);
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
    }
}

