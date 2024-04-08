namespace org.parser.marpa
{
    public abstract class ESLIFRecognizerInterface
    {
        private ESLIFRecognizer ESLIFRecognizer;

        public abstract bool Read();
        public abstract bool IsEof();
        public abstract bool IsCharacterStream();
        public abstract string Encoding();
        public abstract byte[] Data();

        public virtual bool IsWithDisableThreshold() => true;

        public virtual bool IsWithExhaustion() => true;

        public virtual bool IsWithNewline() => true;

        public virtual bool IsWithTrack() => false;

        public virtual void SetESLIFRecognizer(ESLIFRecognizer recognizer) => this.ESLIFRecognizer = recognizer;

        public virtual ESLIFRecognizer GetESLIFRecognizer() => ESLIFRecognizer;
    }
}
