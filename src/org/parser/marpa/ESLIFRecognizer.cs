using System;

namespace org.parser.marpa
{
    public class ESLIFRecognizer
    {
        private ESLIFGrammar eslifGrammar;
        private ESLIFRecognizerInterface recognizerInterface;
        private readonly marpaESLIFRecognizer marpaESLIFRecognizer;
        private readonly marpaESLIFRecognizerOption marpaESLIFRecognizerOption;
        private readonly ESLIFRecognizer eslifRecognizerShared;

        public ESLIFRecognizer(ESLIFGrammar eslifGrammar, ESLIFRecognizerInterface recognizerInterface)
        {
            this.eslifGrammar = eslifGrammar ?? throw new ArgumentNullException(nameof(eslifGrammar));
            this.recognizerInterface = recognizerInterface; // Can be null
            this.marpaESLIFRecognizerOption = recognizerInterface == null ? null : new marpaESLIFRecognizerOption(recognizerInterface);
            this.marpaESLIFRecognizer = new marpaESLIFRecognizer(eslifGrammar.marpaESLIFGrammar, this.marpaESLIFRecognizerOption);
        }

        public ESLIFRecognizer(ESLIFGrammar eslifGrammar, ESLIFRecognizer eslifRecognizerShared)
        {
            this.eslifGrammar = eslifGrammar ?? throw new ArgumentNullException(nameof(eslifGrammar));
            this.eslifRecognizerShared = eslifRecognizerShared ?? throw new ArgumentNullException(nameof(eslifRecognizerShared));
            this.marpaESLIFRecognizer = new marpaESLIFRecognizer(eslifGrammar.marpaESLIFGrammar, this.eslifRecognizerShared.marpaESLIFRecognizer);
        }

        public void SetExhaustedFlag(bool onOff)
        {
            this.marpaESLIFRecognizer.SetExhaustedFlag(onOff);
        }

        public bool IsCanContinue()
        {
            return this.marpaESLIFRecognizer.IsCanContinue();
        }

        public void Share(ESLIFRecognizer eslifRecognizer)
        {
            this.marpaESLIFRecognizer.Share(eslifRecognizer.marpaESLIFRecognizer);
        }

        public void Unshare()
        {
            this.marpaESLIFRecognizer.Unshare();
        }
    }
}
