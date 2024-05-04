namespace org.parser.marpa
{
    public class ESLIFJSONDecoder
    {
        public static object Decode(ESLIF ESLIF, string jsonString, bool jsonStrict = false, ESLIFJSONDecoderOption decodeOption = null)
        {
            ESLIFGrammar jsonGrammar = ESLIFGrammar.JSONDecoderInstance(ESLIF, jsonStrict);

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

                    if (valueOption.context.stack.Count != 1)
                    {
                        throw new ESLIFException($"Internal value stack is {valueOption.context.stack.Count} instead of {1}");
                    }

                    return valueOption.context.stack.Pop();
                }
            }
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

