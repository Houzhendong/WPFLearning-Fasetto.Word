
namespace Fasetto.Word.Core
{
    /// <summary>
    /// A logger that will handle log message from a <see cref="ILogFactory"/>
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Handles the logged message b
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        void Log(string message, LogLevel level);    
    }
}
