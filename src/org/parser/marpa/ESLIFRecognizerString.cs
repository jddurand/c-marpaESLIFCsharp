using System;
using System.Collections.Generic;

namespace org.parser.marpa
{
    public abstract class ESLIFRecognizerString : IESLIFRecognizer
    {
        private readonly string input;
        public ESLIFRecognizer ESLIFRecognizer { get; private set; }

        public ESLIFRecognizerString(string input)
        {
            this.input = input;
        }

        public virtual byte[] Data() => System.Text.Encoding.UTF8.GetBytes(this.input);
        public virtual string Encoding() => "UTF-8";
        public virtual ESLIFRecognizer GetESLIFRecognizer() => this.ESLIFRecognizer;
        public virtual bool IsCharacterStream() => true;
        public virtual bool IsEof() => true;
        public virtual bool IsWithDisableThreshold() => true;
        public virtual bool IsWithExhaustion() => true;
        public virtual bool IsWithNewline() => true;
        public virtual bool IsWithTrack() => false;
        public virtual bool Read() => true;
        public virtual void SetESLIFRecognizer(ESLIFRecognizer recognizer) => this.ESLIFRecognizer = recognizer;
    }
}

