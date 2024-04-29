using System;

namespace org.parser.marpa
{
    public class ESLIFJSONDecoder
    {
        public static object Decode(ESLIF ESLIF, string jsonString, bool jsonStrict = false, ESLIFJSONDecoderOption decodeOption = null)
        {
            ESLIFGrammar jsonGrammar = ESLIFGrammar.JSONDecoderInstance(ESLIF, jsonStrict);
            object rc;

            using (marpaESLIFJSONDecodeOption marpaESLIFJSONDecodeOption = decodeOption?.marpaESLIFJSONDecodeOption ?? new marpaESLIFJSONDecodeOption(false, 0, false))
            {
                using (marpaESLIFRecognizerOption marpaESLIFRecognizerOption = new marpaESLIFRecognizerOption(new ESLIFJSONDecoderRecognizer(jsonString)))
                {
                    ESLIFJSONDecoderValue value = new ESLIFJSONDecoderValue();
                    marpaESLIFValueOption valueOption = new marpaESLIFValueOption(value);
                    if (marpaESLIFShr.marpaESLIFJSON_decodeb(jsonGrammar.marpaESLIFGrammar.marpaESLIFGrammarp, marpaESLIFJSONDecodeOption.marpaESLIFJSONDecodeOptionp, marpaESLIFRecognizerOption.marpaESLIFRecognizerOptionp, valueOption.marpaESLIFValueOptionp) == 0)
                    {
                        throw new ESLIFException("marpaESLIFJSON_decodeb failure");
                    }
                    rc = value.GetResult();
                }
            }

            return rc;
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
    }
}

