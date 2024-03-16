namespace org.parser.marpa
{
    public class ESLIFJSONDecoderOption
    {
        private bool _disallowDupkeys;
        private long _maxDepth;
        private bool _noReplacementCharacter;

        /// <returns>the disallowDupkeys option</returns>
        public bool isDisallowDupkeys() {
            return this._disallowDupkeys;
        }

        /// <param name="disallowDupkeys">the disallowDupkeys option to set</param>
        public void setDisallowDupkeys(bool disallowDupkeys) {
            this._disallowDupkeys = disallowDupkeys;
        }

        /// <returns>the maxDepth option</returns>
        public long getMaxDepth() {
            return this._maxDepth;
        }

        /// <param name="maxDepth">the maxDepth option to set</param>
        public void setMaxDepth(long maxDepth) {
            this._maxDepth = maxDepth;
        }

        /// <returns>the noReplacementCharacter option</returns>
        public bool isNoReplacementCharacter() {
            return this._noReplacementCharacter;
        }

        /// <param name="noReplacementCharacter">the noReplacementCharacter option to set</param>
        public void setNoReplacementCharacter(bool noReplacementCharacter) {
            this._noReplacementCharacter = noReplacementCharacter;
        }
    }
}