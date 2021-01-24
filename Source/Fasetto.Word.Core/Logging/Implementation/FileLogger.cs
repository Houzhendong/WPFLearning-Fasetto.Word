
using System;

namespace Fasetto.Word.Core
{
    public class FileLogger : ILogger
    {
        public string FilePath { get; set; }

        /// <summary>
        /// If true 
        /// </summary>
        public bool LogTime { get; set; } = true;

        public FileLogger(string filePath)
        {
            FilePath = filePath;
        }

        public void Log(string message, LogLevel level)
        {
            var currentTime = DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss");

            var timeLogString = LogTime ? $"[{currentTime}]" : "";

            IoC.File.WriteAllTextToFileAsync($"{timeLogString} {message}{Environment.NewLine}", FilePath, append: true);
        }
    }
}
