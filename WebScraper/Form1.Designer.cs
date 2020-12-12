namespace WebScraper
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openSiteButton = new System.Windows.Forms.Button();
            this.scrapButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.siteTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.excelRadio = new System.Windows.Forms.RadioButton();
            this.CsvRadio = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.scrapResultOutput = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openSiteButton
            // 
            this.openSiteButton.Location = new System.Drawing.Point(450, 12);
            this.openSiteButton.Name = "openSiteButton";
            this.openSiteButton.Size = new System.Drawing.Size(203, 63);
            this.openSiteButton.TabIndex = 0;
            this.openSiteButton.Text = "Open Web Site";
            this.openSiteButton.UseVisualStyleBackColor = true;
            this.openSiteButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // scrapButton
            // 
            this.scrapButton.Location = new System.Drawing.Point(105, 144);
            this.scrapButton.Name = "scrapButton";
            this.scrapButton.Size = new System.Drawing.Size(206, 58);
            this.scrapButton.TabIndex = 1;
            this.scrapButton.Text = "Scrap the Site";
            this.scrapButton.UseVisualStyleBackColor = true;
            this.scrapButton.Click += new System.EventHandler(this.scrapButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Site to Scrap";
            // 
            // siteTextBox
            // 
            this.siteTextBox.Location = new System.Drawing.Point(105, 31);
            this.siteTextBox.Name = "siteTextBox";
            this.siteTextBox.Size = new System.Drawing.Size(298, 20);
            this.siteTextBox.TabIndex = 3;
            this.siteTextBox.Text = "https://www.sportinglife.com/racing/naps-table";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CsvRadio);
            this.groupBox1.Controls.Add(this.excelRadio);
            this.groupBox1.Location = new System.Drawing.Point(115, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 86);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output Type";
            // 
            // excelRadio
            // 
            this.excelRadio.AutoSize = true;
            this.excelRadio.Checked = true;
            this.excelRadio.Location = new System.Drawing.Point(19, 23);
            this.excelRadio.Name = "excelRadio";
            this.excelRadio.Size = new System.Drawing.Size(51, 17);
            this.excelRadio.TabIndex = 0;
            this.excelRadio.TabStop = true;
            this.excelRadio.Text = "Excel";
            this.excelRadio.UseVisualStyleBackColor = true;
            this.excelRadio.Click += new System.EventHandler(this.excelRadio_Click);
            // 
            // CsvRadio
            // 
            this.CsvRadio.AutoSize = true;
            this.CsvRadio.Location = new System.Drawing.Point(19, 46);
            this.CsvRadio.Name = "CsvRadio";
            this.CsvRadio.Size = new System.Drawing.Size(46, 17);
            this.CsvRadio.TabIndex = 5;
            this.CsvRadio.Text = "CSV";
            this.CsvRadio.UseVisualStyleBackColor = true;
            this.CsvRadio.CheckedChanged += new System.EventHandler(this.CsvRadio_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.scrapResultOutput);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.scrapButton);
            this.groupBox2.Location = new System.Drawing.Point(66, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(510, 348);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;

            // 
            // scrapResultOutput
            // 
            this.scrapResultOutput.Location = new System.Drawing.Point(6, 227);
            this.scrapResultOutput.Multiline = true;
            this.scrapResultOutput.Name = "scrapResultOutput";
            this.scrapResultOutput.ReadOnly = true;
            this.scrapResultOutput.Size = new System.Drawing.Size(498, 52);
            this.scrapResultOutput.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 483);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.siteTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.openSiteButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openSiteButton;
        private System.Windows.Forms.Button scrapButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox siteTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton CsvRadio;
        private System.Windows.Forms.RadioButton excelRadio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox scrapResultOutput;
    }
}

