using Microsoft.Extensions.Logging;
using org.parser.marpa;
using System;
using System.Collections.Generic;
using System.Linq;

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
:symbol ::= ""("" name => LPAREN pause => before event => ^LPAREN
:symbol ::= "")"" name => RPAREN pause => before event => ^RPAREN
:symbol ::= /[\d]+/ name => DIGITS pause => before event => ^DIGITS if-action => GreaterThanZero
exp ::=
    digits                                  action => Digits # ::luac->function(input) return tonumber(input) end
    | $LPAREN  exp $RPAREN   assoc => group action => Exp # ::luac->function(l,e,r) return e               end
   || exp (- '**' -) exp     assoc => right action => Pow # ::luac->function(x,y)   return x^y             end
   || exp (-  '*' -) exp                    action => Mul # ::luac->function(x,y)   return x*y             end
    | exp (-  '/' -) exp                    action => Div # ::luac->function(x,y)   return x/y             end
   || exp (-  '+' -) exp                    action => Plus # ::luac->function(x,y)   return x+y             end
    | exp (-  '-' -) exp                    action => Minus # ::luac->function(x,y)   return x-y             end
digits ::= $DIGITS                          action => ::ascii
<anything up to newline> ::= <ANYTHING UP TO NEWLINE>
<ANYTHING UP TO NEWLINE> ~ /[^\\n]*/
"
            );
            bool isExhausted = false;
            string input = "(3 * 4 / 2) ** 2 + 15";
            MyRecognizer myRecognizer = new MyRecognizer(input);
            MyValue myValue = new MyValue();
            if (grammar.Parse(myRecognizer, myValue, ref isExhausted))
            {
                logger.LogInformation($"Parse of {input} gives: {myValue.result}, isExhausted={isExhausted}");
            }
            if (grammar.ParseByLevel(myRecognizer, myValue, ref isExhausted, 0))
            {
                logger.LogInformation($"Parse of {input} at level 0 gives: {myValue.result}, isExhausted={isExhausted}");
            }

            ESLIFRecognizer eslifRecognizer = new ESLIFRecognizer(grammar, myRecognizer);
            logger.LogInformation($"Expected: {string.Join(", ", eslifRecognizer.ExpectedNames())}");
            logger.LogInformation($"Last pause at symbol DIGITS: {eslifRecognizer.LastPauseName("DIGITS")}");
            logger.LogInformation($"Last try at symbol DIGITS: {eslifRecognizer.LastTryName("DIGITS")}");
            logger.LogInformation($"Last discard: {eslifRecognizer.LastDiscard()}");
            logger.LogInformation($"IsEof: {eslifRecognizer.IsEof()}");
            logger.LogInformation($"IsStartComplete: {eslifRecognizer.IsStartComplete()}");
            logger.LogInformation($"EventOnOff on exp: {eslifRecognizer.EventOnOff("exp", ESLIFEventType.NONE, true)}");
            eslifRecognizer.Scan();
            foreach (ESLIFEvent e in eslifRecognizer.Events())
            {
                logger.LogInformation($"Event: {e}");
            }
            eslifRecognizer.ProgressLog(0, -1, LogLevel.Information);
            foreach (ESLIFProgress eslifProgress in eslifRecognizer.Progress(0, -1))
            {
                logger.LogInformation($"{eslifProgress}");
            }
            byte[] recognizerInput = eslifRecognizer.Input();
            logger.LogInformation($"Input: {new string(recognizerInput.Select(b => (char)b).ToArray())}");
            eslifRecognizer.Error();
            (int line, int column) = eslifRecognizer.Location();
            logger.LogInformation($"Line: {line}, Column: {column}");
            try
            {
                byte[] recognizerRead = eslifRecognizer.Read();
                logger.LogInformation($"Read: {new string(recognizerRead.Select(b => (char)b).ToArray())}");
            }
            catch (Exception e)
            {
                logger.LogError($"Exception: {e.Message}");
            }
            eslifRecognizer.DiscardHook(true);
            eslifRecognizer.DiscardHook(false);
            eslifRecognizer.SwitchDiscardHook();

            ESLIFSymbol stringSymbol = new ESLIFSymbol(eslif, "\"3\"", null);
            ESLIFSymbol regexSymbol = new ESLIFSymbol(eslif, "\\d+", null, "\"JDD\"", null);
            ESLIFSymbol metaSymbol = new ESLIFSymbol(eslif, grammar, "ANYTHING UP TO NEWLINE");
            ESLIFSymbol stringSymbol2 = new ESLIFSymbol(eslif, "\"XXXX\"", null);

            logger.LogInformation($"string symbol try: {eslifRecognizer.SymbolTry(stringSymbol)}");
            logger.LogInformation($"regex symbol try: {eslifRecognizer.SymbolTry(regexSymbol)}");
            logger.LogInformation($"meta symbol try: {eslifRecognizer.SymbolTry(metaSymbol)}");
            logger.LogInformation($"string symbol2 try: {eslifRecognizer.SymbolTry(stringSymbol2)}");

            // Give some time to the logger ;)
            Console.ReadLine();
        }
    }

    public class MyRecognizer : ESLIFRecognizerString
    {
        public MyRecognizer(string input)
            : base(input)
        {
        }

        public bool GreaterThanZero(byte[] bytes)
        {
            string input = System.Text.Encoding.UTF8.GetString(bytes);
            if (int.TryParse(input, out int value))
            {
                return value > 0;
            }

            return false;
        }
    }

    public class MyValue : ESLIFValue
    {
        public int Digits(string input) => int.Parse(input);

        public double Exp(byte[] leftParent, double input, byte[] rightParen) => input;

        public double Pow(double x, double y) => Math.Pow(x, y);

        public double Mul(double x, double y) => x * y;

        public double Div(double x, double y) => x / y;

        public double Plus(double x, double y) => x + y;

        public double Minus(double x, double y) => x - y;
    }
}
