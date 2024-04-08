using System;

namespace org.parser.marpa
{
    public class ESLIFValue
    {
        public ESLIFRecognizer eslifRecognizer { get; protected set; }
        public ESLIFValueInterface eslifValueInterface { get; protected set; }
        private readonly marpaESLIFValueOption marpaESLIFValueOption;
        private readonly marpaESLIFValue marpaESLIFValue;

        public ESLIFValue(ESLIFRecognizer eslifRecognizer, ESLIFValueInterface eslifValueInterface)
        {
            this.eslifRecognizer = eslifRecognizer ?? throw new ArgumentNullException(nameof(eslifRecognizer));
            this.eslifValueInterface = eslifValueInterface ?? throw new ArgumentNullException(nameof(eslifValueInterface));
            this.marpaESLIFValueOption = new marpaESLIFValueOption(eslifValueInterface);
            this.marpaESLIFValue = new marpaESLIFValue(eslifRecognizer.marpaESLIFRecognizer, this.marpaESLIFValueOption);
        }

        public short Value()
        {
            return this.marpaESLIFValue.Value();
        }
    }
}
