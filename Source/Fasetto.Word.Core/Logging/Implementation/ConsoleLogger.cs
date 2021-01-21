
using System;

namespace Fasetto.Word.Core
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message, LogLevel level)
        {
            var color = ConsoleColor.White;
            var oldColor = Console.ForegroundColor;

            switch (level)
            {
                case LogLevel.Debug:
                    color = ConsoleColor.Blue;
                    break;
                case LogLevel.Verbose:
                    color = ConsoleColor.Gray;
                    break;
                case LogLevel.Informative:
                    color = ConsoleColor.Red;
                    break;
                case LogLevel.Waring:
                    color = ConsoleColor.DarkYellow;
                    break;
                case LogLevel.Error:
                    color = ConsoleColor.Red;
                    break;
                case LogLevel.Success:
                    color = ConsoleColor.Green;
                    break;
                default:
                    break;
            }

            Console.ForegroundColor = color;
            Console.WriteLine($"[{level}]".PadRight(13, ' ') + message);
            Console.ForegroundColor = oldColor;
        }
    }
}
