namespace org.parser.marpa
{
    public interface ESLIFValueInterface
    {
        bool IsWithHighRankOnly();
        bool IsWithOrderByRank();
        bool IsWithAmbiguous();
        bool isWithNull();
        int MaxParses();
        void SetResult(object result);
        object GetResult();
        void SetSymbolName();
        void SetSymbolNumber();
        void SetRuleName();
        void SetRuleNumber();
        void SetGrammar(ESLIFGrammar grammar);
    }
}
