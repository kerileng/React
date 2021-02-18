using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerTester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Logger logger = new Logger(@"C:\Dev\Dev\C#\Employement Test\React\NewLogs.log", Logger.LogLevel.INF);
            logger.Debug("Debug message test");
            logger.Info("Info message test");
            logger.Error("Error message test");
            logger.Info("Demo of log started");

            for(int i = 0; i < 5; i++)
                logger.Info($"i = {i}");

            logger.Info("Demo of log finished");
         
        }
    }
}
