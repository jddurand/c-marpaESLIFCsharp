using System;

namespace org.parser.marpa
{
    public class ESLIFRecognizer
    {
        private ESLIF eslif;
        private ESLIFRecognizerInterface recognizerInterface;
        private readonly marpaESLIFRecognizer marpaESLIFRecognizer;

        public ESLIFRecognizer(ESLIF eslif, ESLIFRecognizerInterface recognizerInterface)
        {
            this.eslif = eslif ?? throw new ArgumentNullException(nameof(eslif));
            this.recognizerInterface = recognizerInterface; // Can be null
            this.marpaESLIFRecognizer = new marpaESLIFRecognizer(eslif.marpaESLIF, recognizerInterface TO FINISH);
        }
    }
}
