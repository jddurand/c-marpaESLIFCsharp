namespace org.parser.marpa
{
    /// <summary>
    /// ESLIFEventType is an enumeration of all ESLIF possible events. See <see cref="ESLIFEvent"/>.
    /// </summary>
    public enum ESLIFEventType
    {

        /// <summary>Should never happen ;)</summary>
        NONE = 0x00,

        /// <summary>Symbol completion event</summary>
        COMPLETED = 0x01, /* Grammar event */

        /// <summary>Symbol nulling event</summary>
        NULLED = 0x02, /* Grammar event */

        /// <summary>Symbol prediction event</summary>
        PREDICTED = 0x04, /* Grammar event */

        /// <summary>Lexeme prediction event</summary>
        BEFORE = 0x08, /* Just before lexeme is commited */

        /// <summary>Lexeme consumption event</summary>
        AFTER = 0x10, /* Just after lexeme is commited */

        /// <summary>Exhaustion event</summary>
        EXHAUSTED = 0x20, /* Exhaustion */

        /// <summary>Discard event</summary>
        DISCARD = 0x40, /* Discard */
    }
}
