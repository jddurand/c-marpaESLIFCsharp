using System;

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

        /**
	     * 
	     * @param type the event type
	     * @param symbol the symbol name
	     * @param event the event name
	     */
        public ESLIFEvent(ESLIFEventType type, string symbol, string @event) {
            this.type = type;
            this.symbol = symbol;
            this.@event = @event;
        }

        public override string ToString()
        {
            return $"ESLIFEvent [type={this.type}, symbol={this.symbol}, event={this.@event}]";
        }

        /**
         * 
         * @return the event type
         */
        public ESLIFEventType getType()
        {
            return this.type;
        }

        /**
         * 
         * @return the symbol name, null only when this the exhaustion event
         */
        public String getSymbol()
        {
            return this.symbol;
        }

        /**
         * 
         * @return the event name, null only when this the exhaustion event
         */
        public String getEvent()
        {
            return this.@event;
        }
    }
}
