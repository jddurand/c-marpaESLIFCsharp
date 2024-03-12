namespace org.parser.marpa.dev
{
    public interface ESLIFRecognizerInterface
    {
		/// <summary>Callback executed whenever the recognizer need more data.
		///
		/// It is the end-user responsibility to provide coherent chunks of data in case there is a mix of character and binary streams. Every execution of this method should impact the other methods:
		/// <see cref="isEof">isEof</see>, <see cref="isCharacterStream">isCharacterStream</see>, <see cref="encoding">encoding</see>, <see cref="data">data</see>
		/// </summary>
		/// <returns>a boolean value indicating read success or failure</returns>
	    bool read();

        /// <summary>End of data flag.</summary>
        /// <returns>a boolean value indicating the end of the stream</returns>
	    bool isEof();

        /// <summary>Character stream flag.</summary>
        /// <returns>a boolean value indicating if current chunk is a character stream or not</returns>
	    bool isCharacterStream();

        /// <summary>Encoding of latest chunk of data, when the later is a character chunk.
        /// <remarks>
        /// If current chunk of data is a character stream, and this method returns null, then marpaESLIF will guess the encoding if there previous chunk of data was not a character stream, or continue with previous encoding if previous chunk of data was a character stream
        /// </remarks>
        /// </summary>
        /// <returns>a string giving current character encoding, may be null if unknown</returns>
	    bool encoding();

        /// <summary>Chunk content.</summary>
        /// <returns>byte content of current chunk, may be of zero size</returns>
        byte[] data();

        /// <summary>Disable threshold warning.</summary>
        /// <returns>a boolean indicating if threshold warnings should be turned off</returns>
	    bool isWithDisableThreshold();

        /// <summary>Enable exhaustion event.</summary>
        /// <returns>a boolean indicating if exhaustion should trigger an exhaustion event, see <see cref="ESLIFEventType">ESLIFEventType</see></returns>
        bool isWithExhaustion();

        /// <summary>User-friendly error reporting.</summary>
        /// <remarks>
        /// Error reporting can be accurate up to line and column numbers when this is happening on a character stream enabled chunk of data.
        /// This is handy, but has an extra cost on parsing performance.
        /// This method is used at recognizer creation step only.
        /// </remarks>
        /// <returns>a boolean indicating if line/number accounting is on</returns>
        bool isWithNewline();

        /// <summary>Absolute position tracking.</summary>
        /// <remarks>
        /// Absolute position tracking is telling the recognizer to keep track of absolute position at every new alternative.
        /// This function not only has a cost, but is not fully reliable because there is no tentative to check for internal turnaround of the associated implied internal variables.
        /// You should turn this option to true only if you plan to use <see cref="lastCompletedOffset">lastCompletedOffset</see> or <see cref="lastCompletedLEngth">lastCompletedLEngth</see> methods.
        /// </remarks>
        /// <returns>a boolean indicating if absolute position tracking is on</returns>
        bool isWithTrack();


        /// <summary>Set current recognizer</summary>
        /// <remarks>
        /// All recognizer callbacks are executed using an instance of ESLIFRecognizerInterface. Whenever ESLIF executes them, it will call this method with a shallow copy of current ESLIFRecognizer.
        /// </remarks>
        /// <param name="eslifRecognizer">the ESLIFRecognizer instance</param>
        void setEslifRecognizer(ESLIFRecognizer eslifRecognizer);

        /// <summary>Get current recognizer</summary>
        /// <returns>the ESLIFRecognizer injected at every recognizer callback</returns>
        bool getEslifRecognizer();
    }
}
