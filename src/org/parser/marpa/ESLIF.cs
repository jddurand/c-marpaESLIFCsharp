using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace org.parser.marpa
{
    public sealed class ESLIF : IDisposable
    {
        private readonly ILogger<ESLIF> _logger;
        private static readonly ConcurrentDictionary<ILogger, ESLIF> Multitons = new ConcurrentDictionary<ILogger, ESLIF>();
        private readonly genericLogger genericLogger;
        private readonly IntPtr marpaESLIFp;
        private bool disposedValue;

        public ESLIF(ILogger logger = null)
        {
            this.genericLogger = new genericLogger(logger ?? _logger);
            this.marpaESLIFp = marpaESLIFShr.marpaESLIF_newp(
                    new marpaESLIFShr.marpaESLIFOption_t
                    {
                        genericLoggerp = genericLogger.genericLoggerp
                    });
        }

        public static ESLIF GetESLIFInstance(ILogger logger)
        {
            return Multitons.GetOrAdd(logger, key => new ESLIF(key));
        }

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    genericLogger.Dispose();
                }

                marpaESLIFShr.marpaESLIF_freev(this.marpaESLIFp);
                disposedValue = true;
            }
        }

        public string Version()
        {
            IntPtr versions = IntPtr.Zero;
            if (marpaESLIFShr.marpaESLIF_versionb(this.marpaESLIFp, ref versions) == 0)
            {
                throw new Exception("marpaESLIF_versionb failure");
            }
            // It returns a pointer to a static string in the library

            string version = Marshal.PtrToStringAnsi(versions);
            genericLoggerShr.genericLogger_logv(this.genericLogger.genericLoggerp, genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_TRACE, "%s", $"Version: {version}");
            genericLoggerShr.genericLogger_logv(this.genericLogger.genericLoggerp, genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_DEBUG, "%s", $"Version: {version}");
            genericLoggerShr.genericLogger_logv(this.genericLogger.genericLoggerp, genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_INFO, "%s", $"Version: {version}");
            genericLoggerShr.genericLogger_logv(this.genericLogger.genericLoggerp, genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_NOTICE, "%s", $"Version: {version}");
            genericLoggerShr.genericLogger_logv(this.genericLogger.genericLoggerp, genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_WARNING, "%s", $"Version: {version}");
            genericLoggerShr.genericLogger_logv(this.genericLogger.genericLoggerp, genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_ERROR, "%s", $"Version: {version}");
            genericLoggerShr.genericLogger_logv(this.genericLogger.genericLoggerp, genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_CRITICAL, "%s", $"Version: {version}");
            genericLoggerShr.genericLogger_logv(this.genericLogger.genericLoggerp, genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_ALERT, "%s", $"Version: {version}");
            genericLoggerShr.genericLogger_logv(this.genericLogger.genericLoggerp, genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_EMERGENCY, "%s", $"Version: {version}");

            return Marshal.PtrToStringAnsi(versions);
        }

        ~ESLIF()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
