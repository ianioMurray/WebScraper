using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebScraper
{
    public partial class Form1 : Form
    {
        private Scrapper myWeb;
        private OutputType outputType;

        public Form1()
        {
            InitializeComponent();
            myWeb = new Scrapper();
            outputType = OutputType.Excel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myWeb.OpenSite(siteTextBox.Text);
        }

        private void scrapButton_Click(object sender, EventArgs e)
        {
            scrapButton.Enabled = false;
            scrapResultOutput.Text = "";
            scrapResultOutput.Text = myWeb.ScrapSite(siteTextBox.Text, outputType);
            scrapButton.Enabled = true;
        }

        private void excelRadio_Click(object sender, EventArgs e)
        {
            outputType = OutputType.Excel;
        }

        private void CsvRadio_CheckedChanged(object sender, EventArgs e)
        {
            outputType = OutputType.CSV;
        }
    }
}
