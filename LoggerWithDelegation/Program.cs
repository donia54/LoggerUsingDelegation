using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LoggerWithDelegation
{

    public class Logger
    {
        public delegate void LoggerAction(string message);
        private LoggerAction _Action;

        public Logger(LoggerAction action)
        {
            _Action = action;
        }

        public void Log(string message)
        {
            _Action(message);
        }
    }

    public class Program
    {
       public static void LogToScreen(string message)
       {
            Console.WriteLine(message);
       }

        public static void LogToFile(string message)
        {
            string fileName = "log.txt";
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                Console.WriteLine(message);
            }
        }

        static void Main(string[] args)
        {
            Logger ScreenLogger = new Logger(LogToScreen);
            Logger FileLogger = new Logger(LogToScreen);

            ScreenLogger.Log("Screen ");
            FileLogger.Log("Logged to file");

            Console.ReadKey();
        }
    }
}
