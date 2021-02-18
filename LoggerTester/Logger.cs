using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerTester
{
    public class Logger
    {
 
        private int logLevelNum = default;

        public enum LogLevel
        {
            DEB,
            INF,
            ERR

        }

        public Logger(string filename, LogLevel level)
        {
            try
            {            
                
                logLevelNum = (int)Enum.Parse(typeof(LoggerTester.Logger.LogLevel), level.ToString());

                TextWriterTraceListener listener = new TextWriterTraceListener(filename);
                Trace.Listeners.Add(listener);

                Trace.WriteLine($" {DateTime.Now} {level.ToString()} Logger initialized");
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                Trace.Close();
               
            }
        }
        public void Debug(string message)
        {
           
            int currentLevel = (int)Enum.Parse(typeof(LoggerTester.Logger.LogLevel), LogLevel.DEB.ToString());
            try
            {
             
                TextWriterTraceListener listerner = new TextWriterTraceListener();
                Trace.Listeners.Add(listerner);

                Trace.WriteLineIf(currentLevel >= logLevelNum, $" {DateTime.Now} {LogLevel.DEB} {message}");
               
            }
            catch(Exception ex)
            {
               ex.ToString();
            }
            finally
            {
                Trace.Close();
            }
        }

        public void Error(string message)
        {
          
            int currentLevel = (int)Enum.Parse(typeof(LoggerTester.Logger.LogLevel), LogLevel.ERR.ToString());
            try
            {
              
                TextWriterTraceListener listener = new TextWriterTraceListener();
                Trace.Listeners.Add(listener);

                Trace.WriteLineIf(currentLevel >= logLevelNum, $" {DateTime.Now} {LogLevel.ERR} {message}");
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                Trace.Close();
            }

        }

        public void Info(string message)
        {
            int currentLevel = (int)Enum.Parse(typeof(LoggerTester.Logger.LogLevel), LogLevel.INF.ToString());
            try
            {
               TextWriterTraceListener listener = new TextWriterTraceListener();
               
                Trace.Listeners.Add(listener);

                Trace.WriteLineIf(currentLevel >= logLevelNum, $" {DateTime.Now} {LogLevel.INF} {message}");
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                
                Trace.Close();
            }

        }

        ~Logger()
        {
            try
            {
                TextWriterTraceListener listener = new TextWriterTraceListener();

                Trace.Listeners.Add(listener);

                Trace.WriteLine($" {DateTime.Now} {LogLevel.INF.ToString()} Logger destroyed");
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {

                Trace.Close();
            }

        }
    }
}
