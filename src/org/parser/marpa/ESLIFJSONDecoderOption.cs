namespace org.parser.marpa
{
    public class ESLIFJSONDecoderOption
    {
        public bool DisallowDupkeys { get; }
        public long MaxDepth { get; }
        public bool NoReplacementCharacter { get; }

        public ESLIFJSONDecoderOption(bool disallowDupkeys, long maxDepth, bool noReplacementCharacter)
        {
            this.DisallowDupkeys = disallowDupkeys;
            this.MaxDepth = maxDepth;
            this.NoReplacementCharacter = noReplacementCharacter;
        }
    }
}
