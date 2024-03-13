namespace org.parser.marpa.dev
{
    /// <summary>
    /// ESLIFEvent is describing an event coming out from the grammar. See <see cref="ESLIFEventType"/> and <see cref="ESLIFRecognizer.events()"/>
    /// </summary>
    public class ESLIFEvent
    {
        private readonly ESLIFEventType type;
        private readonly string symbol;
        private readonly string @event;

        /// <summary>
        /// Creation of an ESLIFEvent instance
        /// </summary>
        ///
        /// <param name="type">Event type</param>
        /// <param name="symbol">Symbol name</param>
        /// <param name="event">Event name</param>
        /// 
        /// <returns>An ESLIFEvent instance</returns>
        public ESLIFEvent(ESLIFEventType type, string symbol, string @event) {
            this.type = type;
            this.symbol = symbol;
            this.@event = @event;
        }

        public override string ToString()
        {
            return $"ESLIFEvent [type={this.type}, symbol={this.symbol}, event={this.@event}]";
        }

        ///
        /// <returns>the event type</returns>
        ///
        public ESLIFEventType getType()
        {
            return this.type;
        }

        ///
        /// <returns>the symbol name, null only when this the exhaustion event</returns>
        ///
        public string getSymbol()
        {
            return this.symbol;
        }

        ///
        /// <returns>the event name, null only when this the exhaustion event</returns>
        ///
        public string getEvent()
        {
            return this.@event;
        }
    }
}
