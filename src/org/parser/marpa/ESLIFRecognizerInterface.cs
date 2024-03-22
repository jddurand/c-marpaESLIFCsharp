namespace org.parser.marpa
{
    public interface ESLIFRecognizerInterface
    {
        bool Read();
        bool IsEof();
        bool IsCharacterStream();
        string Encoding();
        byte[] Data();
        bool IsWithDisableThreshold();
        bool IsWithExhaustion();
        bool IsWithNewline();
        bool IsWithTrack();
        void SetESLIFRecognizer(ESLIFRecognizer recognizer);
        ESLIFRecognizer getESLIFRecognizer();

    }
}
