namespace org.parser.marpa.dev
{
    /// <summary>ESLIFLoggerInterface is listing all required logging methods.</summary>
    /// <remarks>A logger interface may be associated to an <see cref="ESLIF">ESLIF</see> instance. This interface is explicitly reproducing the formalism of the <a href="http://github.com/jddurand/c-genericLogger" target="_top">genericLogger</a> C library. See also <see cref="ESLIFLoggerLevel">ESLIFLoggerLevel</see>.</remarks>
    public interface ESLIFLoggerInterface
    {
        /// <summary>Log messages with level TRACE</summary>
        /// <param name="message">the message to be logged</param>
        void Trace(string message);

        /// <summary>Log messages with level DEBUG</summary>
        /// <param name="message">the message to be logged</param>
        void Debug(string message);

        /// <summary>Log messages with level INFO</summary>
        /// <param name="message">the message to be logged</param>
        void Info(string message);

        /// <summary>Log messages with level NOTICE</summary>
        /// <param name="message">the message to be logged</param>
        void Notice(string message);

        /// <summary>Log messages with level WARNING</summary>
        /// <param name="message">the message to be logged</param>
        void Warning(string message);

        /// <summary>Log messages with level ERROR</summary>
        /// <param name="message">the message to be logged</param>
        void Error(string message);

        /// <summary>Log messages with level CRITICAL</summary>
        /// <param name="message">the message to be logged</param>
        void Critical(string message);

        /// <summary>Log messages with level ALERT</summary>
        /// <param name="message">the message to be logged</param>
        void Alert(string message);

        /// <summary>Log messages with level EMERGENCY</summary>
        /// <param name="message">the message to be logged</param>
        void Emergency(string message);
    }
}