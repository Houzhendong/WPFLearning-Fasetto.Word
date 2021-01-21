using System;
using System.Runtime.CompilerServices;

namespace Fasetto.Word.Core
{
    public interface ILogFactory
    {
        #region Events

        event Action<(string Message, LogLevel Level)> NewLog;

        #endregion

        #region Properties

        /// <summary>
        /// The level of logging to output 
        /// </summary>
        LogOutputLevel LogOutputLevel { get; set; }

        /// <summary>
        /// If true, includs the orgin of where the log message was logged from 
        /// </summary>
        bool IncludeLogOriginDetails { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Adds the specific logger to this factory
        /// </summary>
        /// <param name="logger"></param>
        void AddLogger(ILogger logger);

        /// <summary>
        /// Remove the specified logger from this factory
        /// </summary>
        /// <param name="logger"></param>
        void RemoveLogger(ILogger logger);

        /// <summary>
        /// Logger the specific message to all loggers in this factory
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="level">The level of the message was logged in</param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line of code in the filename this message was logged</param>
        void Log(string message, LogLevel level = LogLevel.Informative, [CallerMemberName]string origin = "", [CallerFilePath]string filePath = "", [CallerLineNumber]int lineNumber = 0);

        #endregion
    }
}
