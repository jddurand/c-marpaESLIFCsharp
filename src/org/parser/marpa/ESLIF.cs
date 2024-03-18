using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace org.parser.marpa
{
    public class ESLIF
    {
        private static readonly object Lock = new object();
        private static readonly Dictionary<IntPtr,ESLIF> Multitons =new Dictionary<IntPtr, ESLIF>();

        public marpaESLIF marpaESLIF { get; }
        private readonly ILogger logger;

        private ESLIF(ILogger logger)
        {
            this.logger = logger; // Can be null
            this.marpaESLIF = new marpaESLIF(new marpaESLIFOption(new genericLogger(logger)));
        }

        public static ESLIF Instance(ILogger logger = null)
        {
            lock (Lock)
            {
                ESLIF ESLIF;
                KeyValuePair<IntPtr, ESLIF> keyPair = Multitons.FirstOrDefault(p => logger == p.Value.logger);
                if (keyPair.Key != IntPtr.Zero)
                {
                    ESLIF = keyPair.Value;
                }
                else
                {
                    ESLIF = new ESLIF(logger);
                    Multitons.Add(ESLIF.marpaESLIF.marpaESLIFp, ESLIF);
                }

                return ESLIF;
            }
        }

        public string Version()
        {
            return this.marpaESLIF.Version();
        }

        public int VersionMajor()
        {
            return this.marpaESLIF.VersionMajor();
        }

        public int VersionMinor()
        {
            return this.marpaESLIF.VersionMinor();
        }

        public int VersionPatch()
        {
            return this.marpaESLIF.VersionPatch();
        }

        public ESLIFGrammar Grammar()
        {
            return this.marpaESLIF.Grammar();
        }
    }
}
