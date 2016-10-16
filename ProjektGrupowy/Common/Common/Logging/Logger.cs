using System;
using System.IO;

namespace Common.Logging
{
    public class Logger
    {
        private string _fileName;

        private string _directory = "C:\\logs\\";

        public Logger(string fileName)
        {
            _fileName = fileName;
        }

        public void Debug(string log)
        {
            Log(string.Format("{0}-Debug.txt", _fileName), log);
        }

        public void Info(string log)
        {
            Log(string.Format("{0}-Info.txt", _fileName), log);
        }

        public void Error(string log)
        {
            Log(string.Format("{0}-Error.txt", _fileName), log);
        }

        public void Error(Exception ex)
        {
            Error(string.Format("Exception message: {1}", ex));
        }

        public void Error(string log, Exception ex)
        {
            Error(string.Format("{0}. Exception message: {1}", log, ex));
        }


        public void Log(string filename, string log)
        {
            var path = _directory + filename;
            StreamWriter writer;

            if (!File.Exists(path))
            {
                writer = new StreamWriter(path);
            }
            else
            {
                writer = File.AppendText(path);
            }

            writer.WriteLine(string.Format("{0}: {1}", DateTime.Now, log));

            writer.Close();
        }
    }
}
