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
            ESLIF ESLIF = ESLIF.Instance(logger);

            logger.LogInformation($"Version: {ESLIF.Version()}");
            logger.LogInformation($"Version major: {ESLIF.VersionMajor()}");
            logger.LogInformation($"Version minor: {ESLIF.VersionMinor()}");
            logger.LogInformation($"Version patch: {ESLIF.VersionPatch()}");

            try
            {
                ESLIFGrammar ESLIFGrammar = ESLIFGrammar.Instance(ESLIF, "Something that will fail");
            }
            catch (Exception e)
            {
                logger.LogWarning($"ESLIFGrammar failure, {e.Message}");
            }

            try
            {
                ESLIFGrammar ESLIFGrammar = ESLIFGrammar.Instance(ESLIF, ":default ::= event-action => ::luac->function() print('In event-action') return true end\ntext ::= 'text'");
                logger.LogInformation($"Number of grammars: {ESLIFGrammar.ngrammar()}");
                ESLIFGrammarDefaults ESLIFGrammarDefaults = ESLIFGrammar.Defaults();
                logger.LogInformation($"Grammar defaults: {ESLIFGrammar.Defaults()}");
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
