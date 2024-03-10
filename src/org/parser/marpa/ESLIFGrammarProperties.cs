namespace org.parser.marpa
{
    public class ESLIFGrammarProperties
    {
        public int Level { get; }
        public int MaxLevel { get; }
        public string Description { get; }
        public bool Latm { get; }
        public bool DiscardIsFallback { get; }
        public string DefaultSymbolAction { get; }
        public string DefaultRuleAction { get; }
        public string DefaultEventAction { get; }
        public string DefaultRegexAction { get; }
        public int StartId { get; }
        public int DiscardId { get; }
        public int[] SymbolIds { get; }
        public int[] RuleIds { get; }
        public string DefaultEncoding { get; }
        public string FallbackEncoding { get; }

        public ESLIFGrammarProperties(int level, int maxLevel, string description, bool latm, bool discardIsFallback, string defaultSymbolAction, string defaultRuleAction, string defaultEventAction, string defaultRegexAction, int startId, int discardId, int[] symbolIds, int[] ruleIds, string defaultEncoding, string fallbackEncoding)
        {
            this.Level = level;
            this.MaxLevel = maxLevel;
            this.Description = description;
            this.Latm = latm;
            this.DiscardIsFallback = discardIsFallback;
            this.DefaultSymbolAction = defaultSymbolAction;
            this.DefaultRuleAction = defaultRuleAction;
            this.DefaultEventAction = defaultEventAction;
            this.DefaultRegexAction = defaultRegexAction;
            this.StartId = startId;
            this.DiscardId = discardId;
            this.SymbolIds = symbolIds;
            this.RuleIds = ruleIds;
            this.DefaultEncoding = defaultEncoding;
            this.FallbackEncoding = fallbackEncoding;
        }
    }
}
