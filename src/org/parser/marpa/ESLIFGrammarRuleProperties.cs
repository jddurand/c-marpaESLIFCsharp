namespace org.parser.marpa
{
    /// <summary>
    ///
    /// ESLIFGrammarRuleProperties is describing properties of a rule within a grammar.
    ///
    /// <code>
    ///   ESLIF eslif = new ESLIF(...)
    ///   ESLIFGrammar eslifGrammar = new ESLIFGrammar(...);
    ///   ESLIFGrammarRuleProperties eSLIFGrammarRuleProperties = eslifGrammar.currentRuleProperties(0);
    ///   or
    ///   ESLIFGrammarRuleProperties eSLIFGrammarRuleProperties = eslifGrammar.rulePropertiesByLevel(0, 0);
    ///   ...
    ///   eslifGrammar.free();
    ///   eslif.free()
    ///   </code>
    /// </summary>
    public class ESLIFGrammarRuleProperties
    {
        public int id { get; }
        public string description { get; }
        public string show { get; }
        public int lhsId { get; }
        public int separatorId { get; }
        public int[] rhsIds { get; }
        public bool[] skipIndices { get; }
        public int exceptionId { get; }
        public ESLIFAction action { get; }
        public string discardEvent { get; }
        public bool discardEventInitialState { get; }
        public int rank { get; }
        public bool nullRanksHigh { get; }
        public bool sequence { get; }
        public bool proper { get; }
        public int minimum { get; }
        public int propertyBitSet { get; }
        public bool hideseparator { get; }

        /// <summary>
        /// Creation of an ESLIFGrammarRuleProperties instance
        /// </summary>
        ///
        /// <param name="id">Rule id</param>
        /// <param name="description">Rule description</param>
        /// <param name="show">Rule show</param>
        /// <param name="lhsId">LHS id</param>
        /// <param name="separatorId">Separator Id</param>
        /// <param name="rhsIds">Array of RHS id</param>
        /// <param name="skipIndices">Array of skipped RHS indices</param>
        /// <param name="exceptionId">Exception id</param>
        /// <param name="action">Explicit action</param>
        /// <param name="discardEvent">Discard event name when this is a :discard rule</param>
        /// <param name="discardEventInitialState">Discard event initial state is on ?</param>
        /// <param name="rank">Rule rank</param>
        /// <param name="nullRanksHigh">Null ranks high ?</param>
        /// <param name="sequence">Is a sequence ?</param>
        /// <param name="proper">When it is a sequence, is separatation proper ?</param>
        /// <param name="minimum">When it is a sequence, mininum number of items</param>
        /// <param name="propertyBitSet">Low-level property bit set</param>
        /// <param name="hideseparator">When it is a sequence, hide separator for action arguments ?</param>
        /// 
        /// <returns>An ESLIFGrammarRuleProperties instance</returns>
        public ESLIFGrammarRuleProperties(int id, string description, string show, int lhsId, int separatorId, int[] rhsIds, bool[] skipIndices, int exceptionId, ESLIFAction action, string discardEvent, bool discardEventInitialState, int rank, bool nullRanksHigh, bool sequence, bool proper, int minimum, int propertyBitSet, bool hideseparator)
        {
            this.id = id;
            this.description = description;
            this.show = show;
            this.lhsId = lhsId;
            this.separatorId = separatorId;
            this.rhsIds = rhsIds;
            this.skipIndices = skipIndices;
            this.exceptionId = exceptionId;
            this.action = action;
            this.discardEvent = discardEvent;
            this.discardEventInitialState = discardEventInitialState;
            this.rank = rank;
            this.nullRanksHigh = nullRanksHigh;
            this.sequence = sequence;
            this.proper = proper;
            this.minimum = minimum;
            this.propertyBitSet = propertyBitSet;
            this.hideseparator = hideseparator;
        }

        public override string ToString() =>
            "ESLIFGrammarRuleProperties [id=" + this.id
            + ", description=" + (this.description ?? "(null)")
            + ", show=" + (this.show ?? "(null)")
            + ", lhsId=" + this.lhsId
            + ", separatorId=" + this.separatorId
            + ", rhsIds=" + (this.rhsIds != null ? "[" + string.Join(", ", rhsIds) + "]" : "null")
            + ", skipIndices=" + (this.skipIndices != null ? "[" + string.Join(", ", this.skipIndices) + "]" : "null")
            + ", exceptionId=" + this.exceptionId
            + ", action=" + this.action?.ToString()
            + ", discardEvent=" + (this.discardEvent ?? "(null)")
            + ", discardEventInitialState=" + this.discardEventInitialState
            + ", rank=" + this.rank
            + ", nullRanksHigh=" + this.nullRanksHigh
            + ", sequence=" + this.sequence
            + ", proper=" + this.proper
            + ", minimum=" + this.minimum
            + ", propertyBitSet=" + this.propertyBitSet
            + ", hideseparator=" + this.hideseparator + "]";
    }
}
