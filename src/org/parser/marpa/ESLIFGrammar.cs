using System;
using System.Collections.Generic;
using System.Linq;

namespace org.parser.marpa
{
    public class ESLIFGrammar
    {
        private static readonly object Lock = new object();
        private static readonly Dictionary<IntPtr, ESLIFGrammar> Multitons = new Dictionary<IntPtr, ESLIFGrammar>();

        private readonly marpaESLIFGrammar marpaESLIFGrammar;
        private readonly ESLIF ESLIF;
        private readonly string grammar;

        private ESLIFGrammar(ESLIF ESLIF, string grammar)
        {
            this.ESLIF = ESLIF ?? throw new ArgumentNullException(nameof(ESLIF));
            this.grammar = grammar ?? throw new ArgumentNullException(nameof(grammar));
            this.marpaESLIFGrammar = new marpaESLIFGrammar(this.ESLIF.marpaESLIF, new marpaESLIFGrammarOption(grammar));
        }

        public ESLIFGrammar(IntPtr marpaESLIFGrammarp)
        {
            this.marpaESLIFGrammar = new marpaESLIFGrammar(marpaESLIFGrammarp);
        }

        public static ESLIFGrammar Instance(ESLIF ESLIF, string grammar)
        {
            lock (Lock)
            {
                ESLIFGrammar ESLIFGrammar;
                KeyValuePair<IntPtr, ESLIFGrammar> keyPair = Multitons.FirstOrDefault(p => ESLIF == p.Value.ESLIF && grammar == p.Value.grammar);
                if (keyPair.Key != IntPtr.Zero)
                {
                    ESLIFGrammar = keyPair.Value;
                }
                else
                {
                    ESLIFGrammar = new ESLIFGrammar(ESLIF, grammar);
                    Multitons.Add(ESLIFGrammar.marpaESLIFGrammar.marpaESLIFGrammarp, ESLIFGrammar);
                }

                return ESLIFGrammar;
            }
        }

        public int ngrammar()
        {
            return this.marpaESLIFGrammar.ngrammar();
        }

        public ESLIFGrammarDefaults Defaults()
        {
            return this.marpaESLIFGrammar.Defaults();
        }

        public ESLIFGrammarDefaults DefaultsByLevel(int level)
        {
            return this.marpaESLIFGrammar.DefaultsByLevel(level);
        }

        public ESLIFGrammarProperties Properties()
        {
            return this.marpaESLIFGrammar.Properties();
        }

        public ESLIFGrammarProperties PropertiesByLevel(int level)
        {
            return this.marpaESLIFGrammar.PropertiesByLevel(level);
        }
    }
}
