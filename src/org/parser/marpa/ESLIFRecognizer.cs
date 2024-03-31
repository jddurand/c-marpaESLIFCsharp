using System;

namespace org.parser.marpa
{
    public class ESLIFRecognizer
    {
        public ESLIFGrammar eslifGrammar { get; protected set; }
        public ESLIFRecognizerInterface recognizerInterface { get; protected set; }
        private readonly marpaESLIFRecognizer marpaESLIFRecognizer;
        private readonly marpaESLIFRecognizerOption marpaESLIFRecognizerOption;
        private ESLIFRecognizer eslifRecognizerShared;
        private ESLIFRecognizer eslifRecognizerPeeked;

        public ESLIFRecognizer(ESLIFGrammar eslifGrammar, ESLIFRecognizerInterface recognizerInterface)
        {
            this.eslifGrammar = eslifGrammar ?? throw new ArgumentNullException(nameof(eslifGrammar));
            this.recognizerInterface = recognizerInterface; // Can be null
            this.marpaESLIFRecognizerOption = recognizerInterface == null ? null : new marpaESLIFRecognizerOption(recognizerInterface);
            this.marpaESLIFRecognizer = new marpaESLIFRecognizer(eslifGrammar.marpaESLIFGrammar, this.marpaESLIFRecognizerOption);
        }

        public ESLIFRecognizer(ESLIFGrammar eslifGrammar, ESLIFRecognizer eslifRecognizerFrom)
        {
            this.eslifGrammar = eslifGrammar ?? throw new ArgumentNullException(nameof(eslifGrammar));
            this.marpaESLIFRecognizer = new marpaESLIFRecognizer(eslifGrammar.marpaESLIFGrammar, eslifRecognizerFrom.marpaESLIFRecognizer);
        }

        public void SetExhaustedFlag(bool onOff)
        {
            this.marpaESLIFRecognizer.SetExhaustedFlag(onOff);
        }

        public bool IsCanContinue()
        {
            return this.marpaESLIFRecognizer.IsCanContinue();
        }

        public void Share(ESLIFRecognizer eslifRecognizerShared)
        {
            this.eslifRecognizerShared = eslifRecognizerShared ?? throw new ArgumentNullException(nameof(eslifRecognizerShared));
            this.marpaESLIFRecognizer.Share(this.eslifRecognizerShared.marpaESLIFRecognizer);
        }

        public void Unshare()
        {
            this.marpaESLIFRecognizer.Unshare();
            this.eslifRecognizerShared = null;
        }

        public void Peek(ESLIFRecognizer eslifRecognizerPeeked)
        {
            this.eslifRecognizerPeeked = eslifRecognizerPeeked ?? throw new ArgumentNullException(nameof(eslifRecognizerPeeked));
            this.marpaESLIFRecognizer.Peek(this.eslifRecognizerPeeked.marpaESLIFRecognizer);
        }

        public void Unpeek()
        {
            this.marpaESLIFRecognizer.Unpeek();
            this.eslifRecognizerPeeked = null;
        }
    }
}
