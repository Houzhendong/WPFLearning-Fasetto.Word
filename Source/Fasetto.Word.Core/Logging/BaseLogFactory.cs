using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace Fasetto.Word.Core
{
    public class BaseLogFactory : ILogFactory
    {
        #region Protected Methods

        protected List<ILogger> loggers = new List<ILogger>();

        protected object loggersLock = new object();

        #endregion

        public LogOutputLevel LogOutputLevel { get; set; }

        public event Action<(string Message, LogLevel Level)> NewLog = (details) => { };

        /// <summary>
        /// If true, includs the orgin of where the log message was logged from 
        /// </summary>
        public bool IncludeLogOriginDetails { get; set; } = true;

        public BaseLogFactory()
        {
            AddLogger(new ConsoleLogger());
        }

        public void AddLogger(ILogger logger)
        {
            lock (loggersLock)
            {
                if (!loggers.Contains(logger))
                {
                    loggers.Add(logger);
                }
            }
        }

        public void Log(string message,
            LogLevel level = LogLevel.Informative,
            [CallerMemberName] string origin = "", 
            [CallerFilePath]string filePath = "",
            [CallerLineNumber]int lineNumber = 0)
        {
            if ((int)level < (int)LogOutputLevel)
            {
                return;
            }

            if(IncludeLogOriginDetails)
            {
                message = $"[{Path.GetFileName(filePath)} > {origin}() : Line {lineNumber}]{message}";
            }

            loggers.ForEach(logger => logger.Log(message, level));

            NewLog.Invoke((message, level));
        }

        public void RemoveLogger(ILogger logger)
        {
            lock (loggersLock)
            {
                if (loggers.Contains(logger))
                {
                    loggers.Remove(logger);
                }
            }
        }
    }
}
