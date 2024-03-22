namespace org.parser.marpa
{
    /// <summary>
    ///
    /// ESLIFGrammarSymbolProperties is describing properties of a symbol within a grammar.
    ///
    /// <code>
    ///   ESLIF eslif = new ESLIF(...)
    ///   ESLIFGrammar eslifGrammar = new ESLIFGrammar(...);
    ///   ESLIFGrammarSymbolProperties eSLIFGrammarSymbolProperties = eslifGrammar.currentSymbolProperties(0);
    ///   or
    ///   ESLIFGrammarSymbolProperties eSLIFGrammarSymbolProperties = eslifGrammar.symbolPropertiesByLevel(0, 0);
    ///   ...
    ///   eslifGrammar.free();
    ///   eslif.free()
    ///   </code>
    /// </summary>
    public class ESLIFGrammarSymbolProperties
    {
        public ESLIFSymbolType type { get; }
        public bool start { get; }
        public bool discard { get; }
        public bool discardRhs { get; }
        public bool lhs { get; }
        public bool top { get; }
        public int id { get; }
        public string description { get; }
        public string eventBefore { get; }
        public bool eventBeforeInitialState { get; }
        public string eventAfter { get; }
        public bool eventAfterInitialState { get; }
        public string eventPredicted { get; }
        public bool eventPredictedInitialState { get; }
        public string eventNulled { get; }
        public bool eventNulledInitialState { get; }
        public string eventCompleted { get; }
        public bool eventCompletedInitialState { get; }
        public string discardEvent { get; }
        public bool discardEventInitialState { get; }
        public int lookupResolvedLeveli { get; }
        public int priority { get; }
        public ESLIFAction nullableAction { get; }
        public int propertyBitSet { get; }
        public int eventBitSet { get; }
        public ESLIFAction symbolAction { get; }
        public ESLIFAction ifAction { get; }
        public ESLIFAction generatorAction { get; }
        public bool verbose { get; }

        /// <summary>
        /// Creation of an ESLIFGrammarSymbolProperties instance
        /// </summary>
        /// 
        /// <param name="type">symbol type</param>
        /// <param name="start">true if this is the start symbol</param>
        /// <param name="discard">true if this is a discard symbol</param>
        /// <param name="discardRhs">true if this is on the right-hand side of a discard rule</param>
        /// <param name="lhs">true if this is on the left-hand side of a rule</param>
        /// <param name="top">true if this is the first symbol of the grammar</param>
        /// <param name="id">internal identifier</param>
        /// <param name="description">description</param>
        /// <param name="eventBefore">name of the "before" event, null if none</param>
        /// <param name="eventBeforeInitialState">initial state of the "before" event, meaningless if there is no "before" event</param>
        /// <param name="eventAfter">name of the "after" event, null if none</param>
        /// <param name="eventAfterInitialState">initial state of the "after" event, meaningless if there is no "after" event</param>
        /// <param name="eventPredicted">name of the "predicted" event, null if none</param>
        /// <param name="eventPredictedInitialState">initial state of "predicted" event, meaningless if there is no "predicted" event</param>
        /// <param name="eventNulled">name of the "nulled event, null if none</param>
        /// <param name="eventNulledInitialState">initial state of the "nulled" event, meaningless if there is no "nulled" event</param>
        /// <param name="eventCompleted">name of the "completed" event, null if none</param>
        /// <param name="eventCompletedInitialState">initial state of the "completed" event, meaningless if there is no "completed" event</param>
        /// <param name="discardEvent">name of the "discard" event, null if none</param>
        /// <param name="discardEventInitialState">initial state of the discard event, meaningless if there is no "discard" event</param>
        /// <param name="lookupResolvedLeveli">grammar level to which it is resolved, can be different to the grammar used when this is a lexeme</param>
        /// <param name="priority">symbol priority</param>
        /// <param name="nullableAction">nullable action, null if there is none</param>
        /// <param name="propertyBitSet">low-level grammar properties</param>
        /// <param name="eventBitSet">low-level grammar events</param>
        /// <param name="symbolAction">specific action, null if there is none</param>
        /// <param name="ifAction">if action, null if there is none</param>
        /// <param name="generatorAction">generator action, null if there is none</param>
        /// <param name="verbose">verbose priority</param>
        /// 
        /// <returns>An ESLIFGrammarSymbolProperties instance</returns>
        public ESLIFGrammarSymbolProperties(ESLIFSymbolType type, bool start, bool discard, bool discardRhs, bool lhs, bool top, int id, string description, string eventBefore, bool eventBeforeInitialState, string eventAfter, bool eventAfterInitialState, string eventPredicted, bool eventPredictedInitialState, string eventNulled, bool eventNulledInitialState, string eventCompleted, bool eventCompletedInitialState, string discardEvent, bool discardEventInitialState, int lookupResolvedLeveli, int priority, ESLIFAction nullableAction, int propertyBitSet, int eventBitSet, ESLIFAction symbolAction, ESLIFAction ifAction, ESLIFAction generatorAction, bool verbose)
        {
            this.type = type;
            this.start = start;
            this.discard = discard;
            this.discardRhs = discardRhs;
            this.lhs = lhs;
            this.top = top;
            this.id = id;
            this.description = description;
            this.eventBefore = eventBefore;
            this.eventBeforeInitialState = eventBeforeInitialState;
            this.eventAfter = eventAfter;
            this.eventAfterInitialState = eventAfterInitialState;
            this.eventPredicted = eventPredicted;
            this.eventPredictedInitialState = eventPredictedInitialState;
            this.eventNulled = eventNulled;
            this.eventNulledInitialState = eventNulledInitialState;
            this.eventCompleted = eventCompleted;
            this.eventCompletedInitialState = eventCompletedInitialState;
            this.discardEvent = discardEvent;
            this.discardEventInitialState = discardEventInitialState;
            this.lookupResolvedLeveli = lookupResolvedLeveli;
            this.priority = priority;
            this.nullableAction = nullableAction;
            this.propertyBitSet = propertyBitSet;
            this.eventBitSet = eventBitSet;
            this.symbolAction = symbolAction;
            this.ifAction = ifAction;
            this.generatorAction = generatorAction;
            this.verbose = verbose;
        }

        public override string ToString() =>
            "ESLIFGrammarSymbolProperties [type=" + this.type
            + ", start=" + this.start
            + ", discard=" + this.discard
            + ", discardRhs=" + this.discardRhs
            + ", lhs=" + this.lhs
            + ", top=" + this.top
            + ", id=" + this.id
            + ", description=" + (this.description ?? "(null)")
            + ", eventBefore=" + (this.eventBefore ?? "(null)")
            + ", eventBeforeInitialState=" + this.eventBeforeInitialState
            + ", eventAfter=" + (this.eventAfter ?? "(null)")
            + ", eventAfterInitialState=" + this.eventAfterInitialState
            + ", eventPredicted=" + (this.eventPredicted ?? "(null)")
            + ", eventPredictedInitialState=" + this.eventPredictedInitialState
            + ", eventNulled=" + (this.eventNulled ?? "(null)")
            + ", eventNulledInitialState=" + this.eventNulledInitialState
            + ", eventCompleted=" + (this.eventCompleted ?? "(null)")
            + ", eventCompletedInitialState=" + this.eventCompletedInitialState
            + ", discardEvent=" + (this.discardEvent ?? "(null)")
            + ", discardEventInitialState=" + this.discardEventInitialState
            + ", lookupResolvedLeveli=" + this.lookupResolvedLeveli
            + ", priority=" + this.priority
            + ", nullableAction=" + (this.nullableAction?.ToString())
            + ", propertyBitSet=" + this.propertyBitSet
            + ", eventBitSet=" + this.eventBitSet
            + ", symbolAction=" + (this.symbolAction?.ToString())
            + ", ifAction=" + (this.ifAction?.ToString())
            + ", generatorAction=" + (this.generatorAction?.ToString())
            + ", verbose=" + this.verbose
            + "]";
    }
}

