using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WebScraper
{
    class Outputer
    {
       protected virtual string GenerateSavePathAndFileName()
       {
            string path = Directory.GetCurrentDirectory();
            bool exists = Directory.Exists(path);

            DateTime date1 = DateTime.Now;
            string now = date1.ToString("yyyyMMdd HHmm");
            return path + @"\output " + now;
        }
    }
}
