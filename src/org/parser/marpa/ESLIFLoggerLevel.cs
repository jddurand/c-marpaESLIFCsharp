namespace org.parser.marpa
{
    /// <summary>ESLIFLoggerLevel is an enumeration of all ESLIF logging levels. </summary>
    /// <remarks>This class is explicitly reproducing the formalism of the <a href="http://github.com/jddurand/c-genericLogger" target="_top">genericLogger</a> C library.</remarks>
    public enum ESLIFLoggerLevel
    {
        /// <summary>TRACE log level</summary>
        TRACE = 0,

        /// <summary>DEBUG log level</summary>
        DEBUG = 1,

        /// <summary>INFO log level</summary>
        INFO = 2,

        /// <summary>NOTICE log level</summary>
        NOTICE = 3,

        /// <summary>WARNING log level</summary>
        WARNING = 4,

        /// <summary>ERROR log level</summary>
        ERROR = 5,

        /// <summary>CRITICAL log level</summary>
        CRITICAL = 6,

        /// <summary>ALERT log level</summary>
        ALERT = 7,

        /// <summary>EMERGENCY log level</summary>
        EMERGENCY = 8,
    }
}
