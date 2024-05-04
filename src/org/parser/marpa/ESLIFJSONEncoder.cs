using static org.parser.marpa.marpaESLIFShr;
using System.Runtime.InteropServices;
using System;
using System.Globalization;

namespace org.parser.marpa
{
    public static class ESLIFJSONEncoder
    {
        public static string Encode(ESLIF eslif, object input, bool jsonStrict = false)
        {
            ESLIFGrammar jsonGrammar = ESLIFGrammar.JSONEncoderInstance(eslif, jsonStrict);

            ESLIFJSONEncoderValue value = new ESLIFJSONEncoderValue();
            marpaESLIFValueOption valueOption = new marpaESLIFValueOption(value, CultureInfo.InvariantCulture);
            IntPtr marpaESLIFValueResultp = ImportExport.Instance.Exporter(input);

            if (marpaESLIFShr.marpaESLIFJSON_encodeb(jsonGrammar.marpaESLIFGrammar.marpaESLIFGrammarp, marpaESLIFValueResultp, valueOption.marpaESLIFValueOptionp) == 0)
            {
                Marshal.FreeHGlobal(marpaESLIFValueResultp);
                throw new ESLIFException("marpaESLIFJSON_encodeb failure");
            }
            Marshal.FreeHGlobal(marpaESLIFValueResultp);

            if (valueOption.context.stack.Count != 1)
            {
                throw new ESLIFException($"Internal value stack is {valueOption.context.stack.Count} instead of {1}");
            }

            return valueOption.context.stack.Pop() as string;
        }

        private class ESLIFJSONDecoderRecognizer : ESLIFRecognizerString
        {
            public ESLIFJSONDecoderRecognizer(string input) : base(input)
            {
            }
        }

        private class ESLIFJSONDecoderValue : ESLIFValueInterface
        {
        }

        private class ESLIFJSONEncoderValue : ESLIFValueInterface
        {
        }
    }
}

