namespace org.parser.marpa
{
    public class ESLIFGrammarDefaults
    {
        public ESLIFAction defaultRuleAction { get; }
        public ESLIFAction defaultSymbolAction { get; }
        public ESLIFAction defaultEventAction { get; }
        public ESLIFAction defaultRegexAction { get; }
        public string defaultEncoding { get; }
        public string fallbackEncoding { get; }

        public ESLIFGrammarDefaults(ESLIFAction defaultRuleAction, ESLIFAction defaultSymbolAction, ESLIFAction defaultEventAction, ESLIFAction defaultRegexAction, string defaultEncoding, string fallbackEncoding)
        {
            this.defaultRuleAction = defaultRuleAction;
            this.defaultSymbolAction = defaultSymbolAction;
            this.defaultEventAction = defaultEventAction;
            this.defaultRegexAction = defaultRegexAction;
            this.defaultEncoding = defaultEncoding;
            this.fallbackEncoding = fallbackEncoding;
        }

        public override string ToString()
        {
            return
                $"ESLIFGrammarDefaults [defaultRuleAction={this.defaultRuleAction}" +
                $", defaultSymbolAction={this.defaultSymbolAction}" +
                $", defaultEventAction={this.defaultEventAction}" +
                $", defaultRegexAction={this.defaultRegexAction}" +
                $", defaultEncoding={this.defaultEncoding}" +
                $", fallbackEncoding={this.fallbackEncoding}]";
        }
    }
}
