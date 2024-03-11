using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using static org.parser.marpa.genericLoggerShr;

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
            // Logging level is left to logger, so we say to genericLogger to open everything
            this.genericLoggerp = genericLogger_newp(genericLoggerCallback, IntPtr.Zero, genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_TRACE);
        }

        private void genericLoggerCallback(IntPtr userDatavp, genericLoggerLevel_t logLeveli, string msgs)
        {
            switch (logLeveli)
            {
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_TRACE:
                    this.Trace(msgs);
                    break;
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_DEBUG:
                    this.Debug(msgs);
                    break;
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_INFO:
                    this.Info(msgs);
                    break;
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_NOTICE:
                    this.Notice(msgs);
                    break;
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_WARNING:
                    this.Warning(msgs);
                    break;
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_ALERT:
                    this.Alert(msgs);
                    break;
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_EMERGENCY:
                    this.Emergency(msgs);
                    break;
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_ERROR:
                    this.Error(msgs);
                    break;
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_CRITICAL:
                    this.Critical(msgs);
                    break;
            }
        }

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (this.genericLoggerp != IntPtr.Zero)
                {
                    genericLogger_freev(ref this.genericLoggerp);
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
            if (this.logger.IsEnabled(LogLevel.Trace))
            {
                this.logger.LogTrace(message);
            }
        }

        public void Debug(string message)
        {
            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug(message);
            }
        }

        public void Info(string message)
        {
            if (this.logger.IsEnabled(LogLevel.Information))
            {
                this.logger.LogInformation(message);
            }
        }

        public void Notice(string message)
        {
            // No explicit Notice level, we map it to Information
            this.Info(message);
        }

        public void Warning(string message)
        {
            if (this.logger.IsEnabled(LogLevel.Warning))
            {
                this.logger.LogWarning(message);
            }
        }

        public void Error(string message)
        {
            if (this.logger.IsEnabled(LogLevel.Error))
            {
                this.logger.LogError(message);
            }
        }

        public void Critical(string message)
        {
            if (this.logger.IsEnabled(LogLevel.Critical))
            {
                this.logger.LogCritical(message);
            }
        }

        public void Alert(string message)
        {
            // No explicit Alert level, we map it to Warning
            this.Warning(message);
        }

        public void Emergency(string message)
        {
            // No explicit Emergency level, we map it to Warning
            this.Warning(message);
        }
    }
}
