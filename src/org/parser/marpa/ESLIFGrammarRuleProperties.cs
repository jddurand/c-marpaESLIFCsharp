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
        private readonly int id;
        private readonly string description;
        private readonly string show;
        private readonly int lhsId;
        private readonly int separatorId;
        private readonly int[] rhsIds;
        private readonly bool[] skipIndices;
        private readonly int exceptionId;
        private readonly string action;
        private readonly string discardEvent;
        private readonly bool discardEventInitialState;
        private readonly int rank;
        private readonly bool nullRanksHigh;
        private readonly bool sequence;
        private readonly bool proper;
        private readonly int minimum;
        private readonly int propertyBitSet;
        private readonly bool hideseparator;

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
        public ESLIFGrammarRuleProperties(int id, string description, string show, int lhsId, int separatorId, int[] rhsIds, bool[] skipIndices, int exceptionId, string action, string discardEvent, bool discardEventInitialState, int rank, bool nullRanksHigh, bool sequence, bool proper, int minimum, int propertyBitSet, bool hideseparator)
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
            + ", action=" + (this.action ?? "(null)")
            + ", discardEvent=" + (this.discardEvent ?? "(null)")
            + ", discardEventInitialState=" + this.discardEventInitialState
            + ", rank=" + this.rank
            + ", nullRanksHigh=" + this.nullRanksHigh
            + ", sequence=" + this.sequence
            + ", proper=" + this.proper
            + ", minimum=" + this.minimum
            + ", propertyBitSet=" + this.propertyBitSet
            + ", hideseparator=" + this.hideseparator + "]";

        /// <returns>Rule's id (always >= 0)</returns>
        public int getId() => this.id;

        /// <returns>Rule's description (auto-generated if there is not "name" keyword in the grammar)</returns>
        public string getDescription() => this.description;

        /// <returns>Rule's show</returns>
        public string getShow() => this.show;

        /// <returns>Rule's LHS symbol id (always >= 0)</returns>
        public int getLhsId() => this.lhsId;

        /// <returns>Rule's separator symbol id (< 0 if the rule is not a sequence)</returns>
        public int getSeparatorId() => this.separatorId;

        /// <returns>Rule's RHS ids (none for a null rule)</returns>
        public int[] getRhsIds() => this.rhsIds;

        /// <returns>Rule's RHS skip indices (none for a null rule or a sequence)</returns>
        public bool[] getSkipIndices() => this.skipIndices;

        /// <returns>Rule's exception id ({@code <} 0 if there is no exception)</returns>
        public int getExceptionId() => this.exceptionId;

        /// <returns>Rule's action (null if none)</returns>
        public string getAction() => this.action;

        /// <returns>Rule's discard event name (only when LHS is ":discard" and "event" keyword is present)</returns>
        public string getDiscardEvent() => this.discardEvent;

        /// <returns>Rule's discard initial state is on ?</returns>
        public bool isDiscardEventInitialState() => this.discardEventInitialState;

        /// <remarks>Alias to <see cref="isDiscardEventInitialState"/></remarks>
        /// <returns>Rule's discard initial state is on ?</returns>
        public bool getDiscardEventInitialState() => isDiscardEventInitialState();

        /// <returns>Rule's rank (defaults to 0)</returns>
        public int getRank() => this.rank;

        /// <returns>Rule rank high when it is a nullable ?</returns>
        public bool isNullRanksHigh() => this.nullRanksHigh;

        /// <remarks>Alias to <see cref="isNullRanksHigh"/></remarks>
        /// <returns>Rule rank high when it is a nullable ?</returns>
        public bool getNullRanksHigh() => isNullRanksHigh();

        /// <returns>Rule is a sequence ?</returns>
        public bool isSequence() => this.sequence;

        /// <remarks>Alias to <see cref="isSequence"/></remarks>
        /// <returns>Rule is a sequence ?</returns>
        public bool getSequence() => isSequence();

        /// <returns>Rule's separation is proper ? (meaningful only when it is sequence)</returns>
        public bool isProper() => this.proper;

        /// <remarks>Alias to <see cref="isProper"/></remarks>
        /// <returns>Rule's separation is proper ? (meaningful only when it is sequence)</returns>
        public bool getProper() => isProper();

        /// <returns>Rule's minimum number of RHS (meaningful only when rule is a sequence)</returns>
        public int getMinimum() => this.minimum;

        /// <returns>Rule's low-level property bits (combination of ESLIFRulePropertyBitSet values)</returns>
        public int getPropertyBitSet() => this.propertyBitSet;

        /// <returns>Hide separator in action callback ? (meaningful only when rule is a sequence)</returns>
        public bool isHideseparator() => this.hideseparator;

        /// <remarks>Alias to <see cref="isHideseparator"/></remarks>
        /// <returns>Hide separator in action callback ? (meaningful only when rule is a sequence)</returns>
        public bool getHideseparator() => isHideseparator();
    }
}
