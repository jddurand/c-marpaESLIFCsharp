namespace org.parser.marpa
{
    public interface ESLIFLoggerInterface
    {
        void Trace(string message);
        void Debug(string message);
        void Info(string message);
        void Notice(string message);
        void Warning(string message);
        void Error(string message);
        void Critical(string message);
        void Alert(string message);
        void Emergency(string message);
    }
}
