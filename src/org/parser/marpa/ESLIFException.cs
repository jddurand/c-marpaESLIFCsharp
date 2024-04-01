using System;

namespace org.parser.marpa
{
    public class ESLIFException : Exception
    {
        public ESLIFException()
        {
        }

        public ESLIFException(string message)
            : base(message)
        {
        }

        public ESLIFException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
