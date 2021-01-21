
namespace Fasetto.Word.Core
{
    /// <summary>
    /// The serverity of the log message
    /// </summary>
    public enum LogOutputLevel
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

        Critical = 4,

        /// <summary>
        /// The logger will 
        /// </summary>
        Nothing = 7,
    }
}
