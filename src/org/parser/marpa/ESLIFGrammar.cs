using System;
using System.Collections.Generic;
using System.Linq;

namespace org.parser.marpa
{
    public class ESLIFGrammar
    {
        private static readonly object MutitonsLock = new object();
        private static readonly Dictionary<IntPtr, ESLIFGrammar> Multitons = new Dictionary<IntPtr, ESLIFGrammar>();
        public marpaESLIFGrammar marpaESLIFGrammar { get; protected set; }
        private readonly ESLIF ESLIF;
        private readonly string grammar;
        private readonly bool? jsonDecoder;
        private readonly bool jsonStrict;

        private ESLIFGrammar(ESLIF ESLIF, string grammar)
        {
            this.ESLIF = ESLIF ?? throw new ArgumentNullException(nameof(ESLIF));
            this.grammar = grammar ?? throw new ArgumentNullException(nameof(grammar));
            this.marpaESLIFGrammar = new marpaESLIFGrammar(this.ESLIF.marpaESLIF, new marpaESLIFGrammarOption(grammar));
        }

        private ESLIFGrammar(ESLIF ESLIF, bool jsonDecoder, bool jsonStrict)
        {
            this.ESLIF = ESLIF ?? throw new ArgumentNullException(nameof(ESLIF));
            this.jsonDecoder = jsonDecoder;
            this.jsonStrict = jsonStrict;
            this.marpaESLIFGrammar = new marpaESLIFGrammar(this.ESLIF.marpaESLIF, this.jsonDecoder.Value, this.jsonStrict);
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

        private static ESLIFGrammar JSONInstance(ESLIF ESLIF, bool jsonDecoder, bool jsonStrict)
        {
            lock (MutitonsLock)
            {
                ESLIFGrammar ESLIFGrammar;
                KeyValuePair<IntPtr, ESLIFGrammar> keyPair = Multitons.FirstOrDefault(p => ESLIF == p.Value.ESLIF && p.Value.jsonDecoder.HasValue && p.Value.jsonDecoder.Value == jsonDecoder && p.Value.jsonStrict == jsonStrict);
                if (keyPair.Key != IntPtr.Zero)
                {
                    ESLIFGrammar = keyPair.Value;
                }
                else
                {
                    ESLIFGrammar = new ESLIFGrammar(ESLIF, jsonDecoder, jsonStrict);
                    Multitons.Add(ESLIFGrammar.marpaESLIFGrammar.marpaESLIFGrammarp, ESLIFGrammar);
                }

                return ESLIFGrammar;
            }
        }

        public static ESLIFGrammar JSONDecoderInstance(ESLIF ESLIF, bool jsonStrict)
        {
            return JSONInstance(ESLIF, true, jsonStrict);
        }

        public static ESLIFGrammar JSONEncoderInstance(ESLIF ESLIF, bool jsonStrict)
        {
            return JSONInstance(ESLIF, false, jsonStrict);
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
