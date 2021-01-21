
namespace Fasetto.Word.Core
{
    /// <summary>
    /// The serverity of the log message
    /// </summary>
    public enum LogLevel
    {
        Debug = 1,

        /// <summary>
        /// Log all information except debug information
        /// </summary>
        Verbose = 2,

        /// <summary>
        /// Log all informative message , ignoring any debug and verbose messages
        /// </summary>
        Informative = 3,

        /// <summary>
        /// Log only warnings, errors and standard message
        /// </summary>
        Waring = 4,

        Error = 5,

        Success = 6,
    }
}
