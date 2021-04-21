using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ReportGeneratorService
{
    class InnerService
    {
        Timer timer = new Timer();
        public void Start()
        {
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 60000;
            timer.Enabled = true;
        }
        public void Stop()
        {
            Console.WriteLine("Service Durduruldu " + DateTime.Now);
        }

        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            try
            {
                var res = new ReportGenerator.ReportService().RunService();
            }
            catch (Exception ex)
            {
                WriteToFile($"---{DateTime.Now:HH:mm}");
                WriteToFile(ex.Message);
                WriteToFile(ex.StackTrace);
                WriteToFile(ex.InnerException.ToString());
                WriteToFile("---");
            }
        }
    }
}
