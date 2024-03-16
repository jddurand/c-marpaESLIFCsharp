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
        private readonly int level;
        private readonly int maxLevel;
        private readonly string description;
        private readonly bool latm;
        private readonly bool discardIsFallback;
        private readonly string defaultSymbolAction;
        private readonly string defaultRuleAction;
        private readonly string defaultEventAction;
        private readonly string defaultRegexAction;
        private readonly int startId;
        private readonly int discardId;
        private readonly int[] symbolIds;
        private readonly int[] ruleIds;
        private readonly string defaultEncoding;
        private readonly string fallbackEncoding;

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
        public ESLIFGrammarProperties(int level, int maxLevel, string description, bool latm, bool discardIsFallback, string defaultSymbolAction, string defaultRuleAction, string defaultEventAction, string defaultRegexAction, int startId, int discardId, int[] symbolIds, int[] ruleIds, string defaultEncoding, string fallbackEncoding)
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
            + ", defaultSymbolAction=" + (this.defaultSymbolAction ?? "(null)")
            + ", defaultRuleAction=" + (this.defaultRuleAction ?? "(null)")
            + ", defaultEventAction=" + (this.defaultEventAction ?? "(null)")
            + ", defaultRegexAction=" + (this.defaultRegexAction ?? "(null)")
            + ", startId=" + this.startId
            + ", discardId=" + this.discardId
            + ", symbolIds=" + (this.symbolIds != null ? "[" + string.Join(", ", this.symbolIds)  + "]": "(null)")
            + ", ruleIds=" + (this.ruleIds != null ? "[" + string.Join(", ", this.ruleIds) + "]" : "(null)")
            + ", defaultEncoding=" + (this.defaultEncoding ?? "(null)")
            + ", fallbackEncoding=" + (this.fallbackEncoding ?? "(null)")
            + "]";

        ///
        /// <returns>Grammar's level</returns>
        ///
        public int getLevel() => this.level;

        ///
        /// <returns>Maximum grammar level</returns>
        ///
        public int getMaxLevel() => this.maxLevel;

        ///
        /// <returns>Grammar's description</returns>
        ///
        public String getDescription() => this.description;

        ///
        /// <returns>A boolean that indicates if this grammar is in the LATM (Longest Acceptable Token Mode) or not</returns>
        ///
        public bool isLatm() => this.latm;

        /// <remarks>Alias to <see cref="isLatm"/></remarks>
        /// <returns>A boolean that indicates if this grammar is in the LATM (Longest Acceptable Token Mode) or not</returns>
        ///
        public bool getLatm() => isLatm();

        ///
        /// <returns>A boolean that returns the grammar's discard-is-fallback setting</returns>
        ///
        public bool isDiscardIsFallback() => this.discardIsFallback;

        /// <remarks>Alias to <see cref="isDiscardIsFallback"/></remarks>
        /// <returns>A boolean that returns the grammar's discard-is-fallback setting</returns>
        ///
        public bool getDiscardIsFallback() => isDiscardIsFallback();

        ///
        /// <returns>Grammar's default symbol action, never null</returns>
        ///
        public string getDefaultSymbolAction() => this.defaultSymbolAction;

        ///
        /// <returns>Grammar's default rule action, can be null</returns>
        ///
        public string getDefaultRuleAction() => this.defaultRuleAction;

        ///
        /// <returns>Grammar's default event action, can be null</returns>
        ///
        public string getDefaultEventAction() => this.defaultEventAction;

        ///
        /// <returns>Grammar's default regex action, can be null</returns>
        ///
        public string getDefaultRegexAction() => this.defaultRegexAction;

        ///
        /// <returns>Grammar's start symbol id, always >= 0</returns>
        ///
        public int getStartId() => this.startId;

        ///
        /// <returns>Grammar's discard symbol id, < 0 if none.</returns>
        ///
        public int getDiscardId() => this.discardId;

        ///
        /// <returns>List of symbol identifiers</returns>
        ///
        public int[] getSymbolIds() => this.symbolIds;

        ///
        /// <returns>List of rule identifiers</returns>
        ///
        public int[] getRuleIds() => this.ruleIds;

        ///
        /// <returns>the default encoding, can be null</returns>
        ///
        public string getDefaultEncoding() => this.defaultEncoding;

        ///
        /// <returns>the fallback encoding, can be null</returns>
        ///
        public string getFallbackEncoding() => this.fallbackEncoding;
    }
}
