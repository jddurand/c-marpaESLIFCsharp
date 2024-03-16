namespace org.parser.marpa
{
    /// <summary>
    /// ESLIFSymbolType is an enumeration to disambiguate symbol types, that can be either a terminal, either a meta-symbol.
    /// </summary>
    public enum ESLIFSymbolType
    {

        /// <summary>Symbol is a terminal</summary>
        MARPAESLIF_SYMBOLTYPE_TERMINAL = 0,

        /// <summary>Symbol is a meta symbol</summary>
        MARPAESLIF_SYMBOLTYPE_META = 1,
    }
}
