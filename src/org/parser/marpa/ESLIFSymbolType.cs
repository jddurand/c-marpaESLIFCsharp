namespace org.parser.marpa
{
    /// <summary>
    /// ESLIFSymbolType is an enumeration to disambiguate symbol types, that can be either a terminal, either a meta-symbol.
    /// </summary>
    public enum ESLIFSymbolType
    {

        /// <summary>Symbol is a terminal</summary>
        TERMINAL = 0,

        /// <summary>Symbol is a meta symbol</summary>
        META = 1,
    }
}
