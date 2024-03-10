using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;

namespace org.parser.marpa
{
    public sealed class genericLogger : IDisposable
    {
        private bool disposedValue;
        public IntPtr genericLoggerp;
        private readonly ILogger logger;

        public genericLogger(ILogger logger)
        {
            this.disposedValue = false;
            this.logger = logger ?? NullLogger.Instance;
            this.genericLoggerp = genericLoggerShr.genericLogger_newp(genericLoggerCallback, IntPtr.Zero, genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_INFO);
        }

        private void genericLoggerCallback(IntPtr userDatavp, genericLoggerShr.genericLoggerLevel_t logLeveli, string msgs)
        {
            switch (logLeveli)
            {
                case genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_TRACE:
                    this.logger.LogTrace(msgs);
                    break;
                case genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_DEBUG:
                    this.logger.LogDebug(msgs);
                    break;
                case genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_INFO:
                case genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_NOTICE:
                    this.logger.LogInformation(msgs);
                    break;
                case genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_WARNING:
                case genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_ALERT:
                case genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_EMERGENCY:
                    this.logger.LogWarning(msgs);
                    break;
                case genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_ERROR:
                    this.logger.LogError(msgs);
                    break;
                case genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_CRITICAL:
                    this.logger.LogCritical(msgs);
                    break;
            }
        }

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (this.genericLoggerp != null)
                {
                    genericLoggerShr.genericLogger_freev(ref this.genericLoggerp);
                }
                this.disposedValue = true;
            }
        }

        ~genericLogger()
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
