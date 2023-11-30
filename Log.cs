using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Лог
{

    /// <summary>
    /// Класс ведения журнала работы пользователя в ИС
    /// </summary>
    class logger
    {
        public logger()
        {

        }
        /// <summary>
        /// добавить новую запись в выбранный файл журнала
        /// </summary>
        /// <param name="LogsFolder"></param>
        /// <param name="extension"></param>
        /// <param name="messageType"></param>
        /// <param name="Message"></param>
        private static void WriteLine(string LogsFolder, string extension, string messageType, string Message)
        {

            if (!Directory.Exists(LogsFolder))
            {
                try
                {
                    Directory.CreateDirectory(LogsFolder);
                }
                catch (SystemException ex)
                {
                    throw ex;
                }
            }

            var cur_log_path = Path.Combine(LogsFolder, DateTime.Now.ToShortDateString() + extension);
            using (FileStream fs = new FileStream(cur_log_path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine($"{DateTime.Now.ToLongTimeString()}\t{messageType}\t{Message}");
                }
            }

        }

        /// <summary>
        /// добавить новую запись в журнал ошибок ИС
        /// </summary>
        /// <param name="message"></param>
        /// <param name="writeToConsole"></param>
        public static void WriteToErrorLog(string message, bool writeToConsole = true)
        {
            WriteLine("Logs", ".log", "ERROR", message);
            if (writeToConsole)
            {
                Console.WriteLine(message);
            }
        }


        /// <summary>
        /// добавить новую запись в журнал работы ИС
        /// </summary>
        /// <param name="message"></param>
        /// <param name="writeToConsole"></param>
        public static void WriteToStatLog(string message, bool writeToConsole = true)
        {
            WriteLine("Logs", ".log", "INFO", message);
            if (writeToConsole)
            {
                Console.WriteLine(message);
            }
        }
    }


}