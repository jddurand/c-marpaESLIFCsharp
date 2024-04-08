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
:default ::= event-action => MyEvent regex-action => MyRegexAction
:discard ::= /[\s]+/
:symbol ::= ""("" name => LPAREN pause => before event => ^LPAREN
:symbol ::= "")"" name => RPAREN pause => before event => ^RPAREN
:symbol ::= /(?C1)([\d]+(?C""some """"arbitrary"""" text""))/ name => DIGITS pause => before event => ^DIGITS if-action => GreaterThanZero
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
            MyRecognizer recognizerInterface = new MyRecognizer(logger, input);
            MyValue valueInterface = new MyValue();

            logger.LogWarning("===> Calling grammar.Parse()");
            if (grammar.Parse(recognizerInterface, valueInterface, ref isExhausted))
            {
                logger.LogInformation($"Parse of {input} gives: {valueInterface.result}, isExhausted={isExhausted}");
            }

            logger.LogWarning("===> Calling grammar.Parse() at level 0");
            if (grammar.ParseByLevel(recognizerInterface, valueInterface, ref isExhausted, 0))
            {
                logger.LogInformation($"Parse of {input} at level 0 gives: {valueInterface.result}, isExhausted={isExhausted}");
            }

            logger.LogInformation("Creating recognizer");
            ESLIFRecognizer eslifRecognizer = new ESLIFRecognizer(grammar, recognizerInterface);
            logger.LogInformation($"Expected: {string.Join(", ", eslifRecognizer.ExpectedNames())}");
            logger.LogInformation($"Last pause at symbol DIGITS: {new string(eslifRecognizer.LastPauseName("DIGITS").Select(b => (char)b).ToArray())}");
            logger.LogInformation($"Last try at symbol DIGITS: {new string(eslifRecognizer.LastTryName("DIGITS").Select(b => (char)b).ToArray())}");
            logger.LogInformation($"Last discard: {new string(eslifRecognizer.LastDiscard().Select(b => (char)b).ToArray())}");
            logger.LogInformation($"IsEof: {eslifRecognizer.IsEof()}");
            logger.LogInformation($"IsStartComplete: {eslifRecognizer.IsStartComplete()}");
            logger.LogInformation($"EventOnOff on exp: {eslifRecognizer.EventOnOff("exp", ESLIFEventType.NONE, true)}");

            logger.LogWarning("===> Calling eslifRecognizer.Scan()");
            eslifRecognizer.Scan();

            logger.LogWarning("===> Calling eslifRecognizer.Events()");
            foreach (ESLIFEvent e in eslifRecognizer.Events())
            {
                logger.LogInformation($"Event: {e}");
            }

            logger.LogWarning("===> Calling eslifRecognizer.ProgressLog()");
            eslifRecognizer.ProgressLog(0, -1, LogLevel.Information);
            foreach (ESLIFProgress eslifProgress in eslifRecognizer.Progress(0, -1))
            {
                logger.LogInformation($"{eslifProgress}");
            }

            logger.LogWarning("===> Calling eslifRecognizer.InputLength()");
            int inputLength = eslifRecognizer.InputLength();
            logger.LogInformation($"Input length: {inputLength}");

            for (int i = 0; i < inputLength; i++)
            {
                logger.LogWarning($"===> Calling eslifRecognizer.Input(0, {i})");
                byte[] recognizerInput = eslifRecognizer.Input(0, i);
                logger.LogInformation($"Input: {new string(recognizerInput.Select(b => (char)b).ToArray())}");
            }

            logger.LogWarning("===> Calling eslifRecognizer.Error()");
            eslifRecognizer.Error();

            logger.LogWarning("===> Calling eslifRecognizer.Location()");
            (int line, int column) = eslifRecognizer.Location();
            logger.LogInformation($"Line: {line}, Column: {column}");
            try
            {
                logger.LogWarning("===> Calling eslifRecognizer.Read()");
                byte[] recognizerRead = eslifRecognizer.Read();
                logger.LogInformation($"Read: {new string(recognizerRead.Select(b => (char)b).ToArray())}");
            }
            catch (Exception e)
            {
                logger.LogError($"Exception: {e.Message}");
            }

            logger.LogWarning("===> Calling eslifRecognizer.DiscardHook()");
            eslifRecognizer.DiscardHook(true);
            eslifRecognizer.DiscardHook(false);

            logger.LogWarning("===> Calling eslifRecognizer.SwitchDiscardHook()");
            eslifRecognizer.SwitchDiscardHook();

            ESLIFSymbol stringSymbol = new ESLIFSymbol(eslif, "\"3\"", null);
            ESLIFSymbol regexSymbol = new ESLIFSymbol(eslif, "\\d+", null, "\"JDD\"", null);
            ESLIFSymbol metaSymbol = new ESLIFSymbol(eslif, grammar, "ANYTHING UP TO NEWLINE");
            ESLIFSymbol stringSymbol2 = new ESLIFSymbol(eslif, "\"XXXX\"", null);

            logger.LogWarning("===> Calling eslifRecognizer.SymbolTry()");
            logger.LogInformation($"string symbol try: {eslifRecognizer.SymbolTry(stringSymbol)}");
            logger.LogInformation($"regex symbol try: {eslifRecognizer.SymbolTry(regexSymbol)}");
            logger.LogInformation($"meta symbol try: {eslifRecognizer.SymbolTry(metaSymbol)}");
            logger.LogInformation($"string symbol2 try: {eslifRecognizer.SymbolTry(stringSymbol2)}");

            grammar = ESLIFGrammar.Instance(eslif,
                    @"
/*
 * Example of parameterized rules
*/
:discard ::= /[\s]+/

top  ::= rhs1
rhs1 ::= . => parameterizedRhs->(1, nil, 'Input should be ""1""')
       | . => parameterizedRhs->(2, nil, 'Input should be ""2""')
       | . => parameterizedRhs->(3, nil, 'Input should be ""3""')
       | . => parameterizedRhs->(4, nil, 'Input should be ""4""')
"
            );

            string[] strings = new string[] { "5" };
            foreach (string _string in strings)
            {
                MyParameterizedRecognizer parameterizedRecognizerInterface = new MyParameterizedRecognizer(logger, _string);
                MyParameterizedValue parameterizedValueInterface = new MyParameterizedValue();
                eslifRecognizer = new ESLIFRecognizer(grammar, parameterizedRecognizerInterface);

                if (eslifRecognizer.Scan())
                {
                    bool ok = true;
                    while (eslifRecognizer.IsCanContinue())
                    {
                        if (!eslifRecognizer.Resume())
                        {
                            ok = false;
                            break;
                        }
                    }

                    if (ok)
                    {
                        ESLIFValue parameterizedValue = new ESLIFValue(eslifRecognizer, parameterizedValueInterface);
                        while (parameterizedValue.Value() != 0)
                        {
                            object result = parameterizedValueInterface.result;
                            logger.LogInformation($"Parameterized value: {result}");
                        }
                    }
                }

            }

            Console.ReadLine(); // Give some time to the logger ;)
        }
    }

    public class MyRecognizer : ESLIFRecognizerString
    {
        private readonly ILogger logger;

        public MyRecognizer(ILogger logger,  string input)
            : base(input)
        {
            this.logger = logger;
        }

        public bool GreaterThanZero(byte[] bytes)
        {
            bool output;

            string input = System.Text.Encoding.UTF8.GetString(bytes);
            if (int.TryParse(input, out int value))
            {
                output = value > 0;
            }
            else
            {
                output = false;
            }

            this.logger.LogInformation($"Symbol callback on \"{input}\": {output}");

            return output;
        }

        public void MyEvent(ESLIFEvent[] events)
        {
            for (int i = 0; i < events.Length; i++)
            {
                this.logger.LogInformation($"Event callback[{i}]: {events[i]}");
            }
        }

        public int MyRegexAction(ESLIFRegexCallout callout)
        {
            this.logger.LogInformation($"Regex callout: {callout.ToStringUTF8()}");

            return 0;
        }
    }

    public class MyValue : ESLIFValueInterface
    {
        public int Digits(string input) => int.Parse(input);

        public double Exp(byte[] leftParent, double input, byte[] rightParen) => input;

        public double Pow(double x, double y) => Math.Pow(x, y);

        public double Mul(double x, double y) => x * y;

        public double Div(double x, double y) => x / y;

        public double Plus(double x, double y) => x + y;

        public double Minus(double x, double y) => x - y;
    }

    public class MyParameterizedRecognizer : ESLIFRecognizerString
    {
        private readonly ILogger logger;
        private int nbParameterizedRhsCalls = 0;

        public MyParameterizedRecognizer(ILogger logger, string input)
            : base(input)
        {
            this.logger = logger;
        }

        public string parameterizedRhs(object[] args)
        {
            int parameter = Convert.ToInt32(args[0]);
            object anything = args[1];
            string explanation = args[2] as string;

            this.nbParameterizedRhsCalls++;
            string output;

            if (this.nbParameterizedRhsCalls == 5)
            {
                output = "start ::= '5'\n";
            }
            else if (this.nbParameterizedRhsCalls > 5)
            {
                output = "start ::= 'no match'\n";
            }
            else
            {
                ++parameter;
                output = $"start ::= . => parameterizedRhs->({parameter}, {new {x = "Value of x", y = "Value of y"}}, \"Input should be \"{parameter}\"')\n";
            }

            logger.LogInformation($"In rhs, parameters: [{parameter}, {anything}, {explanation}] => \"{output}\"");
            return output;
        }
    }


    public class MyParameterizedValue : ESLIFValueInterface
    {
    }
}
