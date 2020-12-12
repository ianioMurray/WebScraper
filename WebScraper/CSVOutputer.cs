using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WebScraper
{
    class CSVOutputer : Outputer, IOutputer
    {
        protected override string GenerateSavePathAndFileName()
        {
            return base.GenerateSavePathAndFileName() + ".csv";
        }

        private string RemoveCommasFromText(string text)
        {
            return text.Replace(",", "");
        }

        private string AddCommaAndSpaceAfterEachField(int index, string text)
        {
            if (index != 0)
            {
                text += ", ";
            }
            return text;
        }


        public void GenerateOutput(Scrapper scrapper)
        {
            FileStream fs = File.Create(GenerateSavePathAndFileName());
            using (StreamWriter sw = new StreamWriter(fs))
            {
                string headingTextToAdd = "";
                for (int i = 0; i < scrapper.Headings.Count; i++)
                {
                    //add a comma and space after the last entry if the current entry is not the first one
                    headingTextToAdd = AddCommaAndSpaceAfterEachField(i, headingTextToAdd);

                    string heading = scrapper.Headings[i];
                    headingTextToAdd += RemoveCommasFromText(heading);
                }

                sw.Write(headingTextToAdd + Environment.NewLine);

                string bodyTextToAdd = "";
                for (int i = 0; i < scrapper.TableRows.Count; i++)
                {
                    List<string> row = scrapper.TableRows[i];

                    for (int j = 0; j < row.Count; j++)
                    {
                        bodyTextToAdd = AddCommaAndSpaceAfterEachField(j, bodyTextToAdd);

                        string cellText = row[j];
                        bodyTextToAdd += RemoveCommasFromText(cellText);
                    }
                    bodyTextToAdd += Environment.NewLine;
                }

                sw.Write(bodyTextToAdd);
            }
        }
    }
}
