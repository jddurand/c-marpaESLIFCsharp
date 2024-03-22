using Microsoft.Extensions.Logging;
using org.parser.marpa;
using System;

namespace marpaESLIFShrTest
{
    internal class Program
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

            // Give some time to the logger ;)
            Console.ReadLine();
        }
    }
}
