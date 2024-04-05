namespace org.parser.marpa
{
    public class ESLIFSymbol
    {
        public marpaESLIFSymbol marpaESLIFSymbol { get; protected set; }

        public ESLIFSymbol(ESLIF ESLIF, string @string, string modifiers)
        {
            this.marpaESLIFSymbol = new marpaESLIFSymbol(ESLIF.marpaESLIF, @string, modifiers);
        }

        public ESLIFSymbol(ESLIF ESLIF, string @string, string modifiers, string substitutionString, string substitutionModifiers)
        {
            this.marpaESLIFSymbol = new marpaESLIFSymbol(ESLIF.marpaESLIF, @string, modifiers, substitutionString, substitutionModifiers);
        }

        public ESLIFSymbol(ESLIF ESLIF, ESLIFGrammar ESLIFGrammar, string symbol)
        {
            this.marpaESLIFSymbol = new marpaESLIFSymbol(ESLIF.marpaESLIF, ESLIFGrammar.marpaESLIFGrammar, symbol);
        }

        public bool Try(byte[] input)
        {
            return this.marpaESLIFSymbol.Try(input);
        }
    }
}
