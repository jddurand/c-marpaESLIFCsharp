using System;
using System.Collections.Generic;

namespace org.parser.marpa
{
    public interface ESLIFValueInterface
    {
        bool IsWithHighRankOnly();
        bool IsWithOrderByRank();
        bool IsWithAmbiguous();
        bool IsWithNull();
        int MaxParses();
        void SetResult(object result);
        object GetResult();
        void SetSymbolName(string symbolName);
        void SetSymbolNumber(int symbolNumber);
        void SetRuleName(string ruleName);
        void SetRuleNumber(int symbolNumber);
        void SetGrammar(ESLIFGrammar grammar);
        Dictionary<string, Func<object, List<object>>> Actions();
    }
}
