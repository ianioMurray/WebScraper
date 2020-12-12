using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WebScraper
{
    enum OutputType
    {
        Excel,
        CSV
    }


    class Scrapper
    {
        private List<List<string>> tableRows;
        private List<string> headings;
        private IOutputer outputer;
        private HtmlDocument doc;
        private HtmlWeb web;
        private HtmlNodeCollection tables;
        private List<int> noOfFieldsPerColumn;

        public List<List<string>> TableRows
        {
            get
            {
                return tableRows;
            }
        }

        public List<string> Headings
        {
            get
            {
                return headings;
            }
        }

        public Scrapper()
        {


            tableRows = new List<List<string>>();
            noOfFieldsPerColumn = new List<int>();
        }


        public void OpenSite(string siteURL)
        {
            //open the site
            System.Diagnostics.Process.Start(siteURL);
        }

        public string ScrapSite(string siteURL, OutputType outputType)
        {
            switch(outputType)
            {
                case OutputType.Excel:
                    outputer = new ExcelOutputer();
                    break;
                case OutputType.CSV:
                    outputer = new CSVOutputer();
                    break;
                default:
                    throw new Exception("Unknown OutputType");
            }

            string scrapResult = ScrapInfo(siteURL);
            outputer.GenerateOutput(this);
            return scrapResult;
        }

        private bool IsATablePresent(string siteURL)
        {
            web = new HtmlWeb();
            doc = web.Load(siteURL);
            tables = doc.DocumentNode.SelectNodes("//table");

            if (tables != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string ScrapInfo(string siteURL)
        {
            string returnString = "";
            if (IsATablePresent(siteURL))
            {
                returnString = ScrapTableBody();
                returnString += Environment.NewLine + ScrapTableHeadings();
            }
            else
            {
                returnString = "Scrap Unsuccessful: No table found on the selected Page";
            }
            return returnString;
        }

        private string ScrapTableBody()
        {
            List<string> temprow;

            foreach (HtmlNode table in tables)
            {
                HtmlNodeCollection rows = table.SelectNodes("//tbody/tr");
                if (rows == null)
                {
                    return "Scrap Unsuccessful: Table structure is not in the expected format. No tr in the tbody";
                }
                else
                {
                    foreach (HtmlNode row in rows)
                    {
                        temprow = new List<string>();
                        int columnCount = 0;

                        HtmlNodeCollection cells = row.SelectNodes("td");
                        if (cells == null)
                        {
                            return "Scrap Unsuccessful: Table structure is not in the expected format. No td in the tr"; ;
                        }
                        else
                        {

                            foreach (HtmlNode cell in cells)
                            {
                                int noOfDataFields = 0;
                                HtmlNodeCollection subCells = cell.SelectNodes("div");

                                if (subCells != null)
                                {
                                    foreach (HtmlNode subCell in subCells)
                                    {
                                        temprow.Add(subCell.InnerText);
                                        noOfDataFields++;
                                    }
                                }
                                else
                                {
                                    temprow.Add(cell.InnerText);
                                    noOfDataFields++;
                                }
                                UpdateNoOfFieldsPerColumn(columnCount, noOfDataFields);
                                columnCount++;
                            }
                        }
                        tableRows.Add(temprow);
                    }
                }
            }
            return "Scrap Successful: Body";
        }

        //identifies the number of fields in a column so where a column has more than 1 piece of data we can add blank spaces 
        //for extra columns in the output
        private void UpdateNoOfFieldsPerColumn(int column, int dataFieldsInRow)
        {
            if (noOfFieldsPerColumn.Count == column)
            {
                noOfFieldsPerColumn.Add(dataFieldsInRow);
            }
            else
            {
                if (noOfFieldsPerColumn[column] < dataFieldsInRow)
                {
                    noOfFieldsPerColumn[column] = dataFieldsInRow;
                }
            }
        }

        public string ScrapTableHeadings()
        {
            headings = new List<string>();
            foreach (HtmlNode table in tables)
            {
                int rowCount = 0;
                HtmlNodeCollection rowHeadings = table.SelectNodes("//thead/tr/th");
                if (rowHeadings == null)
                {
                    return "Scrap Unsuccessful: Table structure is not in the expected format. No th within the thead/tr";
                }
                else
                {
                    foreach (HtmlNode rowHeading in rowHeadings)
                    {
                        headings.Add(rowHeading.InnerText);
                        if (noOfFieldsPerColumn[rowCount] > 1)
                        {
                            for (int i = 1; i < noOfFieldsPerColumn[rowCount]; i++)
                            {
                                headings.Add("");
                            }
                        }
                        rowCount++;
                    }
                }
            }
            return "Scrap Successful: Headings";
        }
    }
}

  











