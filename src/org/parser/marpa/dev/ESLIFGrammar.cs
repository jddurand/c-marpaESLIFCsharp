using System;

namespace org.parser.marpa.dev
{
    /// <summary>ESLIFGrammar is the second step after getting an ESLIF instance. As many grammars as wanted</summary>
    /// <code>
    /// ESLIF eslif = new ESLIF(...)
    /// ESLIFGrammar eslifGrammar = new ESLIFGrammar(...);
    /// ...
    /// eslifGrammar.free();
    /// eslif.free()
    /// </code>

    public class ESLIFGrammar
    {
        private readonly object grammarLock = new object();
        private readonly IntPtr marpaESLIFGrammarp;
        private readonly ESLIF eslif;
        private readonly string grammar;

        // Note that it is not safe to access grammar object from multiple thread, thus the internal lock.

        /// <summary>Creation of an ESLIFGrammar instance</summary>
        /// <param name="eslif">an instance of ESLIF</param>
        /// <param name="grammar">the grammar to compile</param>
        public ESLIFGrammar(ESLIF eslif, string grammar)
        {
            this.eslif = eslif ?? throw new ArgumentNullException(nameof(eslif));
            this.grammar = grammar ?? throw new ArgumentNullException(nameof(grammar));
            this.marpaESLIFGrammarp = marpaESLIFShr.marpaESLIFGrammar_newp(eslif.marpaESLIFp, IntPtr.Zero) ?? throw new ESLIFException("marpaESLIFGrammar_newp failre"):
        }

        public int ngrammar()
        {
            lock (grammarLock)
            {
                int ngrammar = 0;
                if (marpaESLIFShr.marpaESLIFGrammar_ngrammarib(this, ref ngrammar) == 0)
                {
                    throw new ESLIFException("marpaESLIFGrammar_ngrammarib failure");
                }
                return ngrammar;
            }
        }
    }
}