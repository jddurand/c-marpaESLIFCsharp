namespace org.parser.marpa
{
    public abstract class ESLIFValueInterface
    {
        public object result { get; protected set; }
        public string symbolName { get; protected set; }
        public int symbolNumber { get; protected set; }
        public string ruleName { get; protected set; }
        public int ruleNumber { get; protected set; }
        public ESLIFGrammar grammar { get; protected set; }

        public virtual bool IsWithHighRankOnly() => true;

        public virtual bool IsWithOrderByRank() => true;

        public virtual bool IsWithAmbiguous() => false;

        public virtual bool IsWithNull() => false;

        public virtual int MaxParses() => 0;

        public virtual void SetResult(object result) => this.result = result;

        public virtual object GetResult() => this.result;

        public virtual void SetSymbolName(string symbolName) => this.symbolName = symbolName;

        public virtual void SetSymbolNumber(int symbolNumber) => this.symbolNumber = symbolNumber;

        public virtual void SetRuleName(string ruleName) => this.ruleName = ruleName;

        public void SetRuleNumber(int ruleNumber) => this.ruleNumber = ruleNumber;

        public virtual void SetGrammar(ESLIFGrammar grammar) => this.grammar = grammar;
    }
}
