using System;

namespace org.parser.marpa.dev
{
    public interface ESLIFValueInterface
    {
		/// <summary>When the interface returns true, only the choices with the highest rank are kept.This method is used at valuation instance creation step only. This method is used at valuation instance creation step only.</summary>
		/// <returns>the high-rank only preference</returns>
	    bool isWithHighRankOnly();

        /// <summary>Orders the parse tree values by their rank value. This method is used at valuation instance creation step only.</summary>
        /// <returns>the rank order preference</returns>
	    bool isWithOrderByRank();

        /// <summary>Accept ambiguous parse tree. This method is used at valuation instance creation step only.</summary>
        /// <returns>the ambiguity acceptance</returns>
	    bool isWithAmbiguous();

        /// <summary>Accept a null parse tree value (e.g. when the start rule is not complete). This method is used at valuation instance creation step only.</summary>
        /// <returns>the null parse acceptance</returns>
	    bool isWithNull();

        /// <summary>A very ambiguous parsing can provide a lot of parse tree values, it is possible to reduce such number, at the cost of not having all the valuation possibilities. This method is used at valuation instance creation step only.</summary>
        /// <returns>the maximum number of wanted parses, 0 for all parse trees.</returns>
	    int maxParses();

        /// <summary>Store the final result.</summary>
        /// <param name="result">the final result</param>
	    void setResult(Object result);

        /// <summary>Returns the object stored using <see cref="setResult"/></summary>
	    object getResult();

        /// <summary>Sets current symbol name, when value interface is called on the context of a symbol.</summary>
        /// <param name="symbolName">Symbol name</param>
	    void  setSymbolName(String symbolName);

        /// <summary>Sets current symbol number, when value interface is called on the context of a symbol.</summary>
        /// <param name="symbolNumber">Symbol number</param>
        void  setSymbolNumber(int symbolNumber);

        /// <summary>Sets current rule name, when value interface is called on the context of a rule.</summary>
        /// <param name="ruleName">Rule name</param>
	    void  setRuleName(String ruleName);

        /// <summary>Sets current rule number, when value interface is called on the context of a rule.</summary>
        /// <param name="ruleNumber">Rule number</param>
	    void  setRuleNumber(int ruleNumber);

        /// <summary>Sets current rule grammar at every value interface call.</summary>
        /// <param name="grammar">ESLIF grammar instance</param>
	    void  setGrammar(ESLIFGrammar grammar);
    }
}
