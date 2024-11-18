using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ms = Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Diagnostics;

namespace NewDimension_APP
{
    public static class Logger
    {
        private static bool debug = true;
        private static Stopwatch stopwatch = Stopwatch.StartNew();
        public enum LogLevel
        {
            DEBUG = 0,
            INFO = 1,
            SYS = 2,
            WARN = 3,
            ERROR = 4
        }

        private static string[] Level = new string[] {
            "0.DEBUG",
            "1.INFO-",
            "2.SYS--",
            "3.WARN-",
            "4.ERROR" };

        public static bool Debug
        {
            set { debug = value; }
            get { return debug; }
        }

        private static TraceEventType[] EventType = new TraceEventType[] {
            TraceEventType.Information,
            TraceEventType.Information,
            TraceEventType.Information,
            TraceEventType.Warning,
            TraceEventType.Error };


        
        static Logger()
        {
            try
            {
                //IConfigurationSource configurationSource = ConfigurationSourceFactory.Create();
                //ms.LogWriterFactory logWriterFactory = new ms.LogWriterFactory(configurationSource);
                //ms.Logger.SetLogWriter(new ms.LogWriterFactory().Create());
                ms.Logger.SetLogWriter(new ms.LogWriterFactory().Create());
                ms.LogEntry entry = new ms.LogEntry();

            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// Writes exception details to the log using Enterprise Library
        /// </summary>
        /// <param name="ex"></param>
        public static void Log(Exception ex)
        {
            // can be changed as per your requirement for the event/priority and the category
            ms.Logger.Write(ex, "ErrorsWarnings", 1, 1, System.Diagnostics.TraceEventType.Error);
        }
        /// <summary>
        /// Writes Information message to the log using Enterprise Library
        /// </summary>
        /// <param name="infoMsg"></param>
        public static void Log(LogLevel level, string message)
        {
            if (debug)
            {
                //System.Console.WriteLine(string.Format("{0} : {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), message));
                System.Console.WriteLine(string.Format("{0} {3,19}: [{4}] {2} {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), message, System.Threading.Thread.CurrentThread.ManagedThreadId, stopwatch.Elapsed.ToString(), Level[(int)level]));
            }
            ms.Logger.Write(string.Format("{1,19} {0}", message, stopwatch.Elapsed.ToString()), Level[(int)level], 5, 0, EventType[(int)level]);
            
            //ms.Logger.Write(infoMsg, "INFO-");
        }
    }
}