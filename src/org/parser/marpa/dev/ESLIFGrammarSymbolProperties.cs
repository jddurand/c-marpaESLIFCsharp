using System;

namespace org.parser.marpa.dev
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
        private readonly ESLIFSymbolType type;
        private readonly bool start;
        private readonly bool discard;
        private readonly bool discardRhs;
        private readonly bool lhs;
        private readonly bool top;
        private readonly int id;
        private readonly string description;
        private readonly string eventBefore;
        private readonly bool eventBeforeInitialState;
        private readonly string eventAfter;
        private readonly bool eventAfterInitialState;
        private readonly string eventPredicted;
        private readonly bool eventPredictedInitialState;
        private readonly string eventNulled;
        private readonly bool eventNulledInitialState;
        private readonly string eventCompleted;
        private readonly bool eventCompletedInitialState;
        private readonly string discardEvent;
        private readonly bool discardEventInitialState;
        private readonly int lookupResolvedLeveli;
        private readonly int priority;
        private readonly string nullableAction;
        private readonly int propertyBitSet;
        private readonly int eventBitSet;
        private readonly string symbolAction;
        private readonly string ifAction;
        private readonly string generatorAction;
        private readonly bool verbose;

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
        public ESLIFGrammarSymbolProperties(ESLIFSymbolType type, bool start, bool discard, bool discardRhs, bool lhs, bool top, int id, string description, string eventBefore, bool eventBeforeInitialState, string eventAfter, bool eventAfterInitialState, string eventPredicted, bool eventPredictedInitialState, string eventNulled, bool eventNulledInitialState, string eventCompleted, bool eventCompletedInitialState, string discardEvent, bool discardEventInitialState, int lookupResolvedLeveli, int priority, string nullableAction, int propertyBitSet, int eventBitSet, string symbolAction, string ifAction, string generatorAction, bool verbose)
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
            + ", nullableAction=" + (this.nullableAction ?? "(null)")
            + ", propertyBitSet=" + this.propertyBitSet
            + ", eventBitSet=" + this.eventBitSet
            + ", symbolAction=" + (this.symbolAction ?? "(null)")
            + ", ifAction=" + (this.ifAction ?? "(null)")
            + ", generatorAction=" + (this.generatorAction ?? "(null)")
            + ", verbose=" + this.verbose
            + "]";

        /// <returns>the type</returns>
        public ESLIFSymbolType getType() => type;

        /// <returns>if this the start symbol</returns>
        public bool isStart() => this.start;

        /// <remarks>Alias to <see cref="isStart"/></remarks>
        /// <returns>if this is the start symbol</returns>
        public bool getStart() => isStart();

        /// <returns>if this is the discard symbol</returns>
        public bool isDiscard() => this.discard;

        /// <remarks>Alias to <see cref="isDiscard"/></remarks>
        /// <returns>if this is the discard symbol</returns>
        public bool getDiscard() => isDiscard();

        /// <returns>if this is a RHS of a discard rule</returns>
        public bool isDiscardRhs() => this.discardRhs;

        /// <remarks>Alias to <see cref="isDiscardRhs"/></remarks>
        /// <returns>if this is a RHS of a discard rule</returns>
        public bool getDiscardRhs() => isDiscardRhs();

        /// <returns>if this is an LHS</returns>
        public bool isLhs() => this.lhs;

        /// <remarks>Alias to <see cref="isLhs"/></remarks>
        /// <returns>if this is an LHS</returns>
        public bool getLhs() => isLhs();

        /// <returns>if this is the first symbol of the grammar</returns>
        public bool isTop() => this.top;

        /// <remarks>Alias to <see cref="isTop"/></remarks>
        /// <returns>if this is the first symbol of the grammar</returns>
        public bool getTop() => isTop();

        /// <returns>the id</returns>
        public int getId() => this.id;

        /// <returns>the description</returns>
        public string getDescription() => this.description;

        /// <returns>the event before name, null if there is none</returns>
        public string getEventBefore() => this.eventBefore;

        /// <returns>if the event before initial state is on, meaningless if there is no event before</returns>
        public bool isEventBeforeInitialState() => this.eventBeforeInitialState;

        /// <remarks>Alias to <see cref="isEventBeforeInitialState"/></remarks>
        /// <returns>if the eventBefore initial state is on, meaningless if there is no event before</returns>
        public bool getEventBeforeInitialState() => isEventBeforeInitialState();

        /// <returns>the event after name, null if there is none</returns>
        public string getEventAfter() => this.eventAfter;

        /// <returns>if the event after initial state is on, meaningless if there is no event after</returns>
        public bool isEventAfterInitialState() => this.eventAfterInitialState;

        /// <remarks>Alias to <see cref="isEventAfterInitialState"/></remarks>
        /// <returns>if the event after initial state is on, meaningless if there is no event after</returns>
        public bool getEventAfterInitialState() => isEventAfterInitialState();

        /// <returns>the event predicted name, null if there is none</returns>
        public string getEventPredicted() => this.eventPredicted;

        /// <returns>A boolean indicating if the event predicted initial state is on, meaningless if there is no prediction event</returns>
        public bool isEventPredictedInitialState() => this.eventPredictedInitialState;

        /// <remarks>Alias to <see cref="isEventPredictedInitialState"/></remarks>
        /// <returns>if the event predicted initial state is on, meaningless if there is no prediction event</returns>
        public bool getEventPredictedInitialState() => isEventPredictedInitialState();

        /// <returns>the null event name, null if there is none - used internally for ":discard[on]" and ":discard[off]" in particular</returns>
        public string getEventNulled() => this.eventNulled;

        /// <returns>the nulled event initial state, meaningless if there is nulled event</returns>
        public bool isEventNulledInitialState() => this.eventNulledInitialState;

        /// <remarks>Alias to <see cref="isEventNulledInitialState"/></remarks>
        /// <returns>the nulled event initial state, meaningless if there is nulled event</returns>
        public bool getEventNulledInitialState() => isEventNulledInitialState();

        /// <returns>the completion event name, null if there is none</returns>
        public string getEventCompleted() => this.eventCompleted;

        /// <returns>the completion event initial state, meaningless if there is no completion event</returns>
        public bool isEventCompletedInitialState() => this.eventCompletedInitialState;

        /// <remarks>Alias to <see cref="isEventCompletedInitialState"/></remarks>
        /// <returns>the completion event initial state, meaningless if there is no completion event</returns>
        public bool getEventCompletedInitialState() => isEventCompletedInitialState();

        /// <returns>the discard event, null if there is none</returns>
        public string getDiscardEvent() => this.discardEvent;

        /// <returns>the discard event initial state, meaningless if there is no discard event</returns>
        public bool isDiscardEventInitialState() => this.discardEventInitialState;

        /// <remarks>Alias to <see cref="isDiscardEventInitialState"/></remarks>
        /// <returns>the discard event initial state, meaningless if there is no discard event</returns>
        public bool getDiscardEventInitialState() => isDiscardEventInitialState();

        /// <returns>the grammar level to which it is resolved, can be different to the grammar used when this is a lexeme</returns>
        public int getLookupResolvedLeveli() => this.lookupResolvedLeveli;

        /// <returns>the symbol priority</returns>
        public int getPriority() => this.priority;

        /// <returns>the nullable action, null if there is none</returns>
        public string getNullableAction() => this.nullableAction;

        /// <returns>the low-level properties (combination of ESLIFSymbolPropertyBitSet values)</returns>
        public int getPropertyBitSet() => this.propertyBitSet;

        /// <returns>the low-level events (combination of ESLIFSymbolEventBitSet values)</returns>
        public int getEventBitSet() => this.eventBitSet;

        /// <returns>the symbol action</returns>
        public string getSymbolAction() => this.symbolAction;

        /// <returns>the if action</returns>
        public string getIfAction() => this.ifAction;

        /// <returns>the generator action</returns>
        public string getGeneratorAction() => this.generatorAction;

        /// <returns>the symbol verbose</returns>
        public bool isVerbose() => this.verbose;

        /// <remarks>Alias to <see cref="isVerbose"/></remarks>
        /// <returns>the symbol verbose</returns>
        public bool getVerbose() => isVerbose();
    }
}

