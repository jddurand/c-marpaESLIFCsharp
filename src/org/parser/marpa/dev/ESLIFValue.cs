using System;
using static org.parser.marpa.marpaESLIFShr;

namespace org.parser.marpa.dev
{
    /// <summary>
    /// ESLIFValue is the step after getting an ESLIF recognizer. Caller must dispose resources in reverse of object creation:
    ///
    /// <code>
    /// ESLIF eslif = new ESLIF(...)
    /// ESLIFGrammar eslifGrammar = new ESLIFGrammar(...);
    /// ESLIFRecognizer eslifRecognizer = new ESLIFRecognizer(...);
    /// ESLIFValue eslifValue = new ESLIFValue(...);
    /// ...
    /// eslifValue.free();
    /// eslifRecognizer.free();
    /// eslifGrammar.free();
    /// eslif.free()
    /// </code>
    ///
    /// A typical recognizer usage is:
    /// <code>
    /// while (eslifValue.value() > 0) {
    ///   object result = eslifValueInterface.getResult();
    /// }
    /// </code>
    /// </summary>
    public class ESLIFValue
    {
        private readonly ESLIFRecognizer eslifRecognizer;
        private ESLIFValueInterface  eslifValueInterface;
        private IntPtr marpaESLIFValuep;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recognizer">recognizer the recognizer instance</param>
        /// <param name="eslifValueInterface">eslifValueInterface the value interface</param>
        /// <exception cref="ESLIFException">ESLIF Exception</exception>
        public ESLIFValue(ESLIFRecognizer recognizer, ESLIFValueInterface eslifValueInterface) {
            this.eslifRecognizer = recognizer ?? throw new ArgumentNullException(nameof(recognizer));
            this.eslifValueInterface = eslifValueInterface ?? throw new ArgumentNullException(nameof(eslifValueInterface));
            this.marpaESLIFValuep = marpaESLIFShr.marpaESLIFValue_newp(eslifRecognizer.marpaESLIFRecognizer)
        }
    }
}
