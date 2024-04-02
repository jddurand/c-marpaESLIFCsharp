using Microsoft.Extensions.Logging;
using org.parser.marpa;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace marpaESLIFShrTest
{
    public class Program
    {
        static void Main(string[] args)
        {

            ILoggerFactory loggerFactory = LoggerFactory.Create(
                builder =>
                {
                    builder.AddSimpleConsole(options =>
                    {
                        options.SingleLine = true;
                    });
                });

            ILogger logger = loggerFactory.CreateLogger("Program");
            ESLIF eslif = ESLIF.Instance(logger);
            ESLIFGrammar grammar = eslif.Grammar();
            logger.LogInformation($"Version: {eslif.Version()}");
            logger.LogInformation($"Version major: {eslif.VersionMajor()}");
            logger.LogInformation($"Version minor: {eslif.VersionMinor()}");
            logger.LogInformation($"Version patch: {eslif.VersionPatch()}");
            logger.LogInformation($"ESLIF Number of grammars: {grammar.ngrammar()}");
            ESLIFGrammarDefaults grammarDefaults = grammar.Defaults();
            logger.LogInformation($"ESLIF Grammar defaults: {grammarDefaults}");
            ESLIFGrammarProperties grammarProperties = grammar.Properties();
            logger.LogInformation($"ESLIF Grammar properties: {grammarProperties}");
            string grammarShow = grammar.Show();
            logger.LogInformation($"ESLIF Grammar show: {grammarShow}");
            for (int level = 0; level < grammar.ngrammar() ; level++ )
            {
                grammarDefaults = grammar.DefaultsByLevel(level);
                logger.LogInformation($"ESLIF Grammar defaults at level {level}: {grammarDefaults}");
                grammarProperties = grammar.PropertiesByLevel(level);
                logger.LogInformation($"ESLIF Grammar properties at level {level}: {grammarProperties}");
                grammarShow = grammar.ShowByLevel(level);
                logger.LogInformation($"ESLIF Grammar show at level {level}: {grammarShow}");
            }

            try
            {
                grammar = ESLIFGrammar.Instance(eslif, "Something that will fail");
            }
            catch (Exception e)
            {
                logger.LogWarning($"ESLIFGrammar failure, {e.Message}");
            }

            try
            {
                grammar = ESLIFGrammar.Instance(eslif, ":default ::= event-action => ::luac->function() print('In event-action') return true end\ntext ::= 'text'");
                int ngrammar = grammar.ngrammar();
                logger.LogInformation($"Number of grammars: {ngrammar}");
                grammarDefaults = grammar.Defaults();
                logger.LogInformation($"Grammar defaults: {grammarDefaults}");
                grammarProperties = grammar.Properties();
                logger.LogInformation($"Grammar properties: {grammarProperties}");
                grammarShow = grammar.Show();
                logger.LogInformation($"Grammar show: {grammarShow}");
                foreach (int ruleId in grammarProperties.ruleIds)
                {
                    ESLIFGrammarRuleProperties ruleProperties = grammar.RuleProperties(ruleId);
                    logger.LogInformation($"Current grammar rule No {ruleId} properties: {ruleProperties}");
                    string ruleDisplay = grammar.RuleDisplay(ruleId);
                    logger.LogInformation($"Current grammar rule No {ruleId} display: {ruleDisplay}");
                    string ruleShow = grammar.RuleShow(ruleId);
                    logger.LogInformation($"Current grammar rule No {ruleId} show: {ruleShow}");
                }
                foreach (int symbolId in grammarProperties.symbolIds)
                {
                    ESLIFGrammarSymbolProperties symbolProperties = grammar.SymbolProperties(symbolId);
                    logger.LogInformation($"Current grammar symbol No {symbolId} properties: {symbolProperties}");
                    string symbolDisplay = grammar.SymbolDisplay(symbolId);
                    logger.LogInformation($"Current grammar symbol No {symbolId} display: {symbolId}");
                }
                for (int level = 0; level < ngrammar; level++)
                {
                    grammarShow = grammar.ShowByLevel(level);
                    logger.LogInformation($"Grammar level No {level} show: {grammarShow}");
                    grammarProperties = grammar.PropertiesByLevel(level);
                    foreach (int ruleId in grammarProperties.ruleIds)
                    {
                        ESLIFGrammarRuleProperties ruleProperties = grammar.RulePropertiesByLevel(ruleId, level);
                        logger.LogInformation($"Grammar level No {level} rule No {ruleId} properties: {ruleProperties}");
                        string ruleDisplay = grammar.RuleDisplayByLevel(ruleId, level);
                        logger.LogInformation($"Grammar level No {level} rule No {ruleId} display: {ruleDisplay}");
                        string ruleShow = grammar.RuleShowByLevel(ruleId, level);
                        logger.LogInformation($"Grammar level No {level} rule No {ruleId} show: {ruleShow}");
                    }
                    foreach (int symbolId in grammarProperties.symbolIds)
                    {
                        ESLIFGrammarSymbolProperties symbolProperties = grammar.SymbolPropertiesByLevel(symbolId, level);
                        logger.LogInformation($"Grammar level No {level} symbol No {symbolId} properties: {symbolProperties}");
                        string symbolDisplay = grammar.SymbolDisplayByLevel(symbolId, level);
                        logger.LogInformation($"Grammar level No {level} symbol No {symbolId} display: {symbolDisplay}");
                    }
                }
            }
            catch (Exception e)
            {
                logger.LogWarning($"ESLIFGrammar failure, {e.Message}");
            }

            grammar = ESLIFGrammar.Instance(eslif,
                @"
:discard ::= /[\s]+/
exp ::=
    digits                                  action => digits # ::luac->function(input) return tonumber(input) end
    |    ""(""  exp "")""    assoc => group action => exp # ::luac->function(l,e,r) return e               end
   || exp (- '**' -) exp     assoc => right action => pow # ::luac->function(x,y)   return x^y             end
   || exp (-  '*' -) exp                    action => mul # ::luac->function(x,y)   return x*y             end
    | exp (-  '/' -) exp                    action => div # ::luac->function(x,y)   return x/y             end
   || exp (-  '+' -) exp                    action => plus # ::luac->function(x,y)   return x+y             end
    | exp (-  '-' -) exp                    action => minus # ::luac->function(x,y)   return x-y             end
digits ::= /[\d]+/                          action => ::ascii
"
            );
            bool isExhausted = false;
            string input = "3 * 4";
            RecognizerInterface recognizerInterface = new RecognizerInterface(input);
            ValueInterface valueInterface = new ValueInterface();
            if (grammar.Parse(recognizerInterface, valueInterface, ref isExhausted))
            {
                logger.LogInformation($"Parse of {input} gives: {valueInterface.result}, isExhausted={isExhausted}");
            }
            if (grammar.ParseByLevel(recognizerInterface, valueInterface, ref isExhausted, 0))
            {
                logger.LogInformation($"Parse of {input} at level 0 gives: {valueInterface.result}, isExhausted={isExhausted}");
            }

            ESLIFRecognizer eslifRecognizer = new ESLIFRecognizer(grammar, recognizerInterface);
            logger.LogInformation($"Expected: {string.Join(", ", eslifRecognizer.Expected())}");


            // Give some time to the logger ;)
            Console.ReadLine();
        }
    }

    public class RecognizerInterface : ESLIFRecognizerInterface
    {
        private readonly string input;
        public RecognizerInterface(string input)
        {
            this.input = input ?? throw new ArgumentNullException(nameof(input));
        }

        public Dictionary<string, Func<List<object>, object>> Actions()
        {
            return new Dictionary<string, Func<List<object>, object>>();
        }

        public byte[] Data()
        {
            return System.Text.Encoding.UTF8.GetBytes(this.input);
        }

        public string Encoding()
        {
            return "UTF-8";
        }

        public ESLIFRecognizer GetESLIFRecognizer()
        {
            throw new NotImplementedException();
        }

        public bool IsCharacterStream()
        {
            return true;
        }

        public bool IsEof()
        {
            return true;
        }

        public bool IsWithDisableThreshold()
        {
            return true;
        }

        public bool IsWithExhaustion()
        {
            return true;
        }

        public bool IsWithNewline()
        {
            return true;
        }

        public bool IsWithTrack()
        {
            return false;
        }

        public bool Read()
        {
            return true;
        }

        public void SetESLIFRecognizer(ESLIFRecognizer recognizer)
        {
            throw new NotImplementedException();
        }
    }

    public class ValueInterface : ESLIFValueInterface
    {
        public object result { get; protected set; }
        public string ruleName { get; protected set; }
        public int ruleNumber { get; protected set; }
        public string symbolName { get; protected set; }
        public int symbolNumber { get; protected set; }
        public ESLIFGrammar grammar { get; protected set; }

        public object GetResult()
        {
            return this.result;
        }

        public bool IsWithAmbiguous()
        {
            return false;
        }

        public bool IsWithHighRankOnly()
        {
            return true;
        }

        public bool IsWithNull()
        {
            return false;
        }

        public bool IsWithOrderByRank()
        {
            return true;
        }

        public int MaxParses()
        {
            return 0;
        }

        public void SetGrammar(ESLIFGrammar grammar)
        {
            this.grammar = grammar;
        }

        public void SetResult(object result)
        {
            this.result = result;
        }

        public void SetRuleName(string ruleName)
        {
            this.ruleName = ruleName;
        }

        public void SetRuleNumber(int ruleNumber)
        {
            this.ruleNumber = ruleNumber;
        }

        public void SetSymbolName(string symbolName)
        {
            this.symbolName = symbolName;
        }

        public void SetSymbolNumber(int symbolNumber)
        {
            this.symbolNumber = symbolNumber;
        }

        public Dictionary<string, Func<List<object>, object>> Actions()
        {
            return new Dictionary<string, Func<List<object>, object>>
            {
                { "digits", (args) =>
                    {
                        return int.Parse(args[0] as string);
                    }
                },
                { "exp", (args) =>
                    {
                        return args[1];
                    }
                },
                { "pow", (args) =>
                    {
                        return Math.Pow(ObjToDouble(args[0]), ObjToDouble(args[1]));
                    }
                },
                { "mul", (args) =>
                    {
                        return ObjToDouble(args[0]) * ObjToDouble(args[1]);
                    }
                },
                { "div", (args) =>
                    {
                        return ObjToDouble(args[0])/ ObjToDouble(args[1]);
                    }
                },
                { "plus", (args) =>
                    {
                        return ObjToDouble(args[0]) + ObjToDouble(args[1]);
                    }
                },
                { "minus", (args) =>
                    {
                        return ObjToDouble(args[0]) - ObjToDouble(args[1]);
                    }
                },
            };
        }

        private static double ObjToDouble(object obj)
        {
            return Convert.ToDouble(obj, CultureInfo.InvariantCulture);
        }
    }
}
