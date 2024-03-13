namespace org.parser.marpa.dev
{
    /// <summary>Null Logger implementation used in multiton</summary>
    public class ESLIFMultitonNullLogger : ESLIFLoggerInterface
    {
        public void Trace(string message)
        {
        }

        public void Debug(string message)
        {
        }

        public void Info(string message)
        {
        }

        public void Notice(string message)
        {
        }

        public void Warning(string message)
        {
        }

        public void Error(string message)
        {
        }

        public void Critical(string message)
        {
        }

        public void Alert(string message)
        {
        }

        public void Emergency(string message)
        {
        }
    }
}