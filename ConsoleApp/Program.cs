﻿using Microsoft.Extensions.Logging;
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
            ESLIF ESLIF = ESLIF.Instance(logger);
            ESLIFGrammar ESLIFGrammar = ESLIF.Grammar();
            logger.LogInformation($"Version: {ESLIF.Version()}");
            logger.LogInformation($"Version major: {ESLIF.VersionMajor()}");
            logger.LogInformation($"Version minor: {ESLIF.VersionMinor()}");
            logger.LogInformation($"Version patch: {ESLIF.VersionPatch()}");
            logger.LogInformation($"ESLIF Number of grammars: {ESLIFGrammar.ngrammar()}");
            ESLIFGrammarDefaults ESLIFGrammarDefaults = ESLIFGrammar.Defaults();
            logger.LogInformation($"ESLIF Grammar defaults: {ESLIFGrammarDefaults}");
            ESLIFGrammarProperties ESLIFGrammarProperties = ESLIFGrammar.Properties();
            logger.LogInformation($"ESLIF Grammar properties: {ESLIFGrammarProperties}");
            for (int level = 0; level < ESLIFGrammar.ngrammar() ; level++ )
            {
                logger.LogInformation($"ESLIF Grammar defaults at level {level}: {ESLIFGrammar.DefaultsByLevel(level)}");
                logger.LogInformation($"ESLIF Grammar properties at level {level}: {ESLIFGrammar.PropertiesByLevel(level)}");
            }

            try
            {
                ESLIFGrammar = ESLIFGrammar.Instance(ESLIF, "Something that will fail");
            }
            catch (Exception e)
            {
                logger.LogWarning($"ESLIFGrammar failure, {e.Message}");
            }

            try
            {
                ESLIFGrammar = ESLIFGrammar.Instance(ESLIF, ":default ::= event-action => ::luac->function() print('In event-action') return true end\ntext ::= 'text'");
                logger.LogInformation($"Number of grammars: {ESLIFGrammar.ngrammar()}");
                ESLIFGrammarDefaults = ESLIFGrammar.Defaults();
                logger.LogInformation($"Grammar defaults: {ESLIFGrammarDefaults}");
                ESLIFGrammarProperties = ESLIFGrammar.Properties();
                logger.LogInformation($"Grammar properties: {ESLIFGrammarProperties}");
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
