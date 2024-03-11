using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;

namespace org.parser.marpa
{
    public sealed class genericLogger : IDisposable, ESLIFLoggerInterface
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
                    this.Trace(msgs);
                    break;
                case genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_DEBUG:
                    this.Debug(msgs);
                    break;
                case genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_INFO:
                    this.Info(msgs);
                    break;
                case genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_NOTICE:
                    this.Notice(msgs);
                    break;
                case genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_WARNING:
                    this.Warning(msgs);
                    break;
                case genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_ALERT:
                    this.Alert(msgs);
                    break;
                case genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_EMERGENCY:
                    this.Emergency(msgs);
                    break;
                case genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_ERROR:
                    this.Error(msgs);
                    break;
                case genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_CRITICAL:
                    this.Critical(msgs);
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

        public void Trace(string message)
        {
            this.logger.LogTrace(message);
        }

        public void Debug(string message)
        {
            this.logger.LogDebug(message);
        }

        public void Info(string message)
        {
            this.logger.LogInformation(message);
        }

        public void Notice(string message)
        {
            this.logger.LogInformation(message);
        }

        public void Warning(string message)
        {
            this.logger.LogWarning(message);
        }

        public void Error(string message)
        {
            this.logger.LogError(message);
        }

        public void Critical(string message)
        {
            this.logger.LogCritical(message);
        }

        public void Alert(string message)
        {
            this.logger.LogWarning(message);
        }

        public void Emergency(string message)
        {
            this.logger.LogWarning(message);
        }
    }
}
