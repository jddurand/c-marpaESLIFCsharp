using System;

namespace org.parser.marpa
{
    /// <summary>
    ///
    /// ESLIFGrammarProperties is describing properties of a grammar.
    ///
    /// <code>
    ///   ESLIF eslif = new ESLIF(...)
    ///   ESLIFGrammar eslifGrammar = new ESLIFGrammar(...);
    ///   ESLIFGrammarProperties eslifGrammarProperties = eslifGrammar.currentProperties();
    ///   ESLIFGrammarProperties eslifGrammarProperties = eslifGrammar.propertiesByLevel(0);
    ///   ...
    ///   eslifGrammar.free();
    ///   eslif.free()
    ///   </code>
    /// </summary>
    public class ESLIFGrammarProperties
    {
        public int level { get; }
        public int maxLevel { get; }
        public string description { get; }
        public bool latm { get; }
        public bool discardIsFallback { get; }
        public ESLIFAction defaultSymbolAction { get; }
        public ESLIFAction defaultRuleAction { get; }
        public ESLIFAction defaultEventAction { get; }
        public ESLIFAction defaultRegexAction { get; }
        public int startId { get; }
        public int discardId { get; }
        public int[] symbolIds { get; }
        public int[] ruleIds { get; }
        public string defaultEncoding { get; }
        public string fallbackEncoding { get; }

        /// <summary>
        /// Creation of an ESLIFGrammarProperties instance
        /// </summary>
        ///
        /// <param name="level">Grammar level</param>
        /// <param name="maxLevel">Maximum grammar level</param>
        /// <param name="description">Grammar description</param>
        /// <param name="latm">Grammar is in LATM (Longest Accepted Token Mode) ?</param>
        /// <param name="discardIsFallback">Grammar's discard-is-fallback setting</param>
        /// <param name="defaultSymbolAction">Grammar default symbol action</param>
        /// <param name="defaultRuleAction">Grammar default rule action</param>
        /// <param name="defaultEventAction">Grammar default event action</param>
        /// <param name="defaultRegexAction">Grammar default regex action</param>
        /// <param name="startId">Start symbol Id</param>
        /// <param name="discardId">Discard symbol Id</param>
        /// <param name="symbolIds">Symbol Ids</param>
        /// <param name="ruleIds">Rule Ids</param>
        /// <param name="defaultEncoding">Grammar default encoding</param>
        /// <param name="fallbackEncoding">Grammar fallback encoding</param>
        /// 
        /// <returns>An ESLIFGrammarProperties instance</returns>
        public ESLIFGrammarProperties(int level, int maxLevel, string description, bool latm, bool discardIsFallback, ESLIFAction defaultSymbolAction, ESLIFAction defaultRuleAction, ESLIFAction defaultEventAction, ESLIFAction defaultRegexAction, int startId, int discardId, int[] symbolIds, int[] ruleIds, string defaultEncoding, string fallbackEncoding)
        {
            this.level = level;
            this.maxLevel = maxLevel;
            this.description = description;
            this.latm = latm;
            this.discardIsFallback = discardIsFallback;
            this.defaultSymbolAction = defaultSymbolAction;
            this.defaultRuleAction = defaultRuleAction;
            this.defaultEventAction = defaultEventAction;
            this.defaultRegexAction = defaultRegexAction;
            this.startId = startId;
            this.discardId = discardId;
            this.symbolIds = symbolIds;
            this.ruleIds = ruleIds;
            this.defaultEncoding = defaultEncoding;
            this.fallbackEncoding = fallbackEncoding;
        }

        public override string ToString() =>
		    "ESLIFGrammarProperties [level=" + this.level
            + ", maxLevel=" + this.maxLevel
            + ", description=" + (this.description ?? "(null)")
            + ", latm=" + this.latm
            + ", discardIsFallback=" + this.discardIsFallback
            + ", defaultSymbolAction=" + (this.defaultSymbolAction?.ToString())
            + ", defaultRuleAction=" + (this.defaultRuleAction?.ToString())
            + ", defaultEventAction=" + (this.defaultEventAction?.ToString())
            + ", defaultRegexAction=" + (this.defaultRegexAction?.ToString())
            + ", startId=" + this.startId
            + ", discardId=" + this.discardId
            + ", symbolIds=" + (this.symbolIds != null ? "[" + string.Join(", ", this.symbolIds)  + "]": "(null)")
            + ", ruleIds=" + (this.ruleIds != null ? "[" + string.Join(", ", this.ruleIds) + "]" : "(null)")
            + ", defaultEncoding=" + (this.defaultEncoding ?? "(null)")
            + ", fallbackEncoding=" + (this.fallbackEncoding ?? "(null)")
            + "]";
    }
}
