namespace org.parser.marpa
{
    public class ESLIFValue : ESLIFValueInterface
    {
        public object result { get; protected set; }
        public string ruleName { get; protected set; }
        public int ruleNumber { get; protected set; }
        public string symbolName { get; protected set; }
        public int symbolNumber { get; protected set; }
        public ESLIFGrammar grammar { get; protected set; }

        public object GetResult()
        {
            return this.result;
        }

        public bool IsWithAmbiguous()
        {
            return false;
        }

        public bool IsWithHighRankOnly()
        {
            return true;
        }

        public bool IsWithNull()
        {
            return false;
        }

        public bool IsWithOrderByRank()
        {
            return true;
        }

        public int MaxParses()
        {
            return 0;
        }

        public void SetGrammar(ESLIFGrammar grammar)
        {
            this.grammar = grammar;
        }

        public void SetResult(object result)
        {
            this.result = result;
        }

        public void SetRuleName(string ruleName)
        {
            this.ruleName = ruleName;
        }

        public void SetRuleNumber(int ruleNumber)
        {
            this.ruleNumber = ruleNumber;
        }

        public void SetSymbolName(string symbolName)
        {
            this.symbolName = symbolName;
        }

        public void SetSymbolNumber(int symbolNumber)
        {
            this.symbolNumber = symbolNumber;
        }
    }
}
