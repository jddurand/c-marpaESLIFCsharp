namespace org.parser.marpa
{
    public abstract class ESLIFRecognizerString : ESLIFRecognizerInterface
    {
        private readonly string input;
        public ESLIFRecognizer ESLIFRecognizer { get; private set; }

        public ESLIFRecognizerString(string input)
        {
            this.input = input;
        }

        public override byte[] Data() => System.Text.Encoding.UTF8.GetBytes(this.input);
        public override string Encoding() => "UTF-8";
        public override bool IsCharacterStream() => true;
        public override bool IsEof() => true;
        public override bool Read() => true;
    }
}

