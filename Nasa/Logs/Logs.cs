using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nasa
{
    public class Logs
    {
        public string fileLocation { get; private set; }


        public Logs()
        {
            fileLocation = ConfigurationSettings.AppSettings["logPath"].Trim().Replace("{user}", Environment.UserName);

            if (!Directory.Exists(fileLocation)) Directory.CreateDirectory(fileLocation);
            fileLocation += "\\logs.txt";

            if (!File.Exists(fileLocation))
                using (FileStream fs = File.Create(fileLocation))
                {
                    fs.Close();
                }


        }
        public void writeException(Exception ex)
        {
            using (StreamWriter sw = File.AppendText(fileLocation))
            {
                sw.WriteLine(DateTime.UtcNow.ToString("F"));
                sw.WriteLine(ex.Message);
                //sw.WriteLine(ex.HResult);
                sw.WriteLine(ex.InnerException);
                sw.WriteLine(ex.StackTrace);
                sw.WriteLine("++++++++++++++++++++++++++++++++++++++++++++");
                sw.Close();
            }
        }
    }
}
