using Microsoft.Extensions.Logging;
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

        public bool Scan(bool initialEventsb = true)
        {
            return this.marpaESLIFRecognizer.Scan(initialEventsb);
        }

        public bool Scan(bool initialEventsb, ref bool isCanContinue, ref bool isExhausted)
        {
            return this.marpaESLIFRecognizer.Scan(initialEventsb, ref isCanContinue, ref isExhausted);
        }

        public bool Resume(int deltaLengthl)
        {
            return this.marpaESLIFRecognizer.Resume(deltaLengthl);
        }

        public bool Resume(int deltaLengthl, ref bool isCanContinue, ref bool isExhausted)
        {
            return this.marpaESLIFRecognizer.Resume(deltaLengthl, ref isCanContinue, ref isExhausted);
        }

        public bool Alternative(string name, object value, int grammarLength = 1)
        {
            return this.marpaESLIFRecognizer.Alternative(name, value, grammarLength);
        }

        public bool AlternativeComplete(int length)
        {
            return this.marpaESLIFRecognizer.AlternativeComplete(length);
        }

        public bool AlternativeRead(string name, object value, int length, int grammarLength = 1)
        {
            return this.marpaESLIFRecognizer.AlternativeRead(name, value, length, grammarLength);
        }

        public bool TryName(string name)
        {
            return this.marpaESLIFRecognizer.TryName(name);
        }

        public int Discard()
        {
            return this.marpaESLIFRecognizer.Discard();
        }

        public bool TryDiscard(string name)
        {
            return this.marpaESLIFRecognizer.TryDiscard();
        }

        public string[] ExpectedNames()
        {
            return this.marpaESLIFRecognizer.ExpectedNames();
        }

        public byte[] LastPauseName(string name)
        {
            return this.marpaESLIFRecognizer.LastPauseName(name);
        }

        public byte[] LastTryName(string name)
        {
            return this.marpaESLIFRecognizer.LastTryName(name);
        }

        public byte[] LastDiscard()
        {
            return this.marpaESLIFRecognizer.LastDiscard();
        }

        public bool IsEof()
        {
            return this.marpaESLIFRecognizer.IsEof();
        }

        public bool IsStartComplete()
        {
            return this.marpaESLIFRecognizer.IsStartComplete();
        }

        public bool EventOnOff(string symbol, ESLIFEventType eventType, bool onOff)
        {
            return this.marpaESLIFRecognizer.EventOnOff(symbol, eventType, onOff);
        }

        public ESLIFEvent[] Events()
        {
            return this.marpaESLIFRecognizer.Events();
        }

        public void ProgressLog(int start, int end, LogLevel logLevel)
        {
            this.marpaESLIFRecognizer.ProgressLog(start, end, logLevel);
        }
    }
}
