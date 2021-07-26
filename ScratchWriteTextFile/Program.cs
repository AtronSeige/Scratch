using System;
using System.IO;
using System.Text;

namespace ScratchWriteTextFile
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            writeToText("Hello World!");

            for (int i = 0; i < 100; i++)
            {
                writeToText(i.ToString());
            }

            Console.WriteLine("Done. Press Any key to close the app.");
            Console.ReadLine();
        }

        private static void writeToText(string value)
        {
            string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string filename = "log_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";

            string logPath = Environment.CurrentDirectory + "\\Logs\\";

            string filepath = logPath + filename;

            StringBuilder sb = new StringBuilder($"[{dateTime}] Value: [{value}]");

            if (!Directory.Exists(logPath)) Directory.CreateDirectory(logPath);

            //If you just want one file, with the current data, overwriting other files/data, then use this:
            //File.WriteAllText(filepath, value);

            //If you want to append if the file exists, use this: 
            using (StreamWriter outputFile = new StreamWriter(filepath, true))
            {
                outputFile.WriteLine(value);
            }
        }
    }
}
