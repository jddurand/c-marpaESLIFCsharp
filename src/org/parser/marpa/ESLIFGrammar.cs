using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace org.parser.marpa
{
    public class ESLIFGrammar
    {
        private static readonly object MutitonsLock = new object();
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
            lock (MutitonsLock)
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

        public ESLIFGrammarRuleProperties RuleProperties(int ruleId)
        {
            return this.marpaESLIFGrammar.RuleProperties(ruleId);
        }

        public ESLIFGrammarRuleProperties RulePropertiesByLevel(int ruleId, int level)
        {
            return this.marpaESLIFGrammar.RulePropertiesByLevel(ruleId, level);
        }

        public ESLIFGrammarSymbolProperties SymbolProperties(int ruleId)
        {
            return this.marpaESLIFGrammar.SymbolProperties(ruleId);
        }

        public ESLIFGrammarSymbolProperties SymbolPropertiesByLevel(int ruleId, int level)
        {
            return this.marpaESLIFGrammar.SymbolPropertiesByLevel(ruleId, level);
        }

        public string RuleDisplay(int ruleId)
        {
            return this.marpaESLIFGrammar.RuleDisplay(ruleId);
        }

        public string RuleDisplayByLevel(int ruleId, int level)
        {
            return this.marpaESLIFGrammar.RuleDisplayByLevel(ruleId, level);
        }

        public string RuleShow(int ruleId)
        {
            return this.marpaESLIFGrammar.RuleShow(ruleId);
        }

        public string RuleShowByLevel(int ruleId, int level)
        {
            return this.marpaESLIFGrammar.RuleShowByLevel(ruleId, level);
        }

        public string SymbolDisplay(int symbolId)
        {
            return this.marpaESLIFGrammar.SymbolDisplay(symbolId);
        }

        public string SymbolDisplayByLevel(int symbolId, int level)
        {
            return this.marpaESLIFGrammar.SymbolDisplayByLevel(symbolId, level);
        }

        public string Show()
        {
            return this.marpaESLIFGrammar.Show();
        }

        public string ShowByLevel(int level)
        {
            return this.marpaESLIFGrammar.ShowByLevel(level);
        }

        public bool Parse(ESLIFRecognizerInterface recognizerInterface, ESLIFValueInterface valueInterface, ref bool isExhausted)
        {
            bool _isExhausted = false;

            bool result = this.marpaESLIFGrammar.Parse(recognizerInterface, valueInterface, ref _isExhausted);
            isExhausted = _isExhausted;

            return result;
        }

        public bool ParseByLevel(ESLIFRecognizerInterface recognizerInterface, ESLIFValueInterface valueInterface, ref bool isExhausted, int level)
        {
            bool _isExhausted = false;

            bool result = this.marpaESLIFGrammar.ParseByLevel(recognizerInterface, valueInterface, ref _isExhausted, level);
            isExhausted = _isExhausted;

            return result;
        }
    }
}
