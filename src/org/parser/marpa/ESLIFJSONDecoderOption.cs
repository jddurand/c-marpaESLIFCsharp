namespace org.parser.marpa
{
    public class ESLIFJSONDecoderOption
    {
        public marpaESLIFJSONDecodeOption marpaESLIFJSONDecodeOption { get; protected set; }
        public bool DisallowDupkeys { get; set; }
        public long MaxDepth { get; set; }
        public bool NoReplacementCharacter { get; set; }

        public ESLIFJSONDecoderOption(bool disallowDupkeys, int maxDepth, bool noReplacementCharacter) {
            this.DisallowDupkeys = disallowDupkeys;
            this.MaxDepth = maxDepth;
            this.NoReplacementCharacter = noReplacementCharacter;
            this.marpaESLIFJSONDecodeOption = new marpaESLIFJSONDecodeOption(this.DisallowDupkeys, this.MaxDepth, this.NoReplacementCharacter);
        }

        public ESLIFJSONDecoderOption() : this(false, 0, false)
        {
        }
    }
}