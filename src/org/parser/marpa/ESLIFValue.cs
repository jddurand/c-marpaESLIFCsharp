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
            short value = this.marpaESLIFValue.Value();
            if (value < 0)
            {
                throw new ESLIFException("Valuation failure");
            }

            if (value > 0)
            {
                if (this.marpaESLIFValueOption.context.stack.Count != 1)
                {
                    throw new ESLIFException($"Internal value stack is {this.marpaESLIFValueOption.context.stack.Count} instead of 1");
                }

                object result = this.marpaESLIFValueOption.context.stack.Pop();
                this.eslifValueInterface.SetResult(result);
            }

            return value;
        }
    }
}
