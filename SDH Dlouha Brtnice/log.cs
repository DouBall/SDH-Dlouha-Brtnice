using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDH_Dlouha_Brtnice
{
    public class log
    {
        static DateTime time = DateTime.Now;
        static string logname = String.Format("{0}.{1}.{2}_{3}-{4}-{5}_log.txt", time.Day, time.Month, time.Year, time.Hour, time.Minute, time.Second);
        static string con;
        public static void logme(int erno)
        {
            using (StreamWriter sw = new StreamWriter(String.Format(@"log\{0}", logname)))
            {
                
                    string content = null;
                    switch (erno)
                    {
                    case 0:
                        content = "OK";
                        break;
                    case 1:
                        content = String.Format("Error, zvoleny port {0} nelze otevrit!", Main.port);
                        break;
                    case 2:
                        content = "Error reading from Serial Port!";
                        break;
                    default:
                        break;
                }
                DateTime timenow = DateTime.Now;
                sw.WriteLine(String.Format("{4}[{0}:{1}:{2}]  {3}", timenow.Hour, timenow.Minute, timenow.Second, content, con));
                sw.Flush();
                sw.Close();
            }
            using (StreamReader sr = new StreamReader(String.Format(@"log\{0}", logname)))
            {
                con = sr.ReadToEnd();
                sr.Close();
            }
        }
    }
}
