namespace org.parser.marpa
{
    public class ESLIFJSON
    {
        public static object Decode(ESLIF eslif, string jsonString, bool jsonStrict = false, ESLIFJSONDecoderOption decodeOption = null)
        {
            return ESLIFJSONDecoder.Decode(eslif, jsonString, jsonStrict, decodeOption);
        }

        public static string Encode(ESLIF eslif, object input, bool jsonStrict = false)
        {
            return ESLIFJSONEncoder.Encode(eslif, input, jsonStrict);
        }
    }
}
