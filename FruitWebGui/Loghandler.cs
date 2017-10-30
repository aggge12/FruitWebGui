using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace FruitWebGui
{
    public class Loghandler
    {
            string _logFilePath = "";
            StreamWriter filetoWrite;
            public Loghandler()
            {
                this._logFilePath = ConfigurationManager.AppSettings["LoggingPath"].ToString();


            }

            public void logMessage(string message)
            {
                filetoWrite = new StreamWriter(_logFilePath, true);


                string time = DateTime.Now.ToString();
                filetoWrite.WriteLine(time + " " + message);

                filetoWrite.Close();
            }
    }
}