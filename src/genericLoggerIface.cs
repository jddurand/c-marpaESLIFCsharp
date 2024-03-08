using log4net;
using System;
using static marpaESLIFCsharp.genericLoggershr;

namespace marpaESLIFCsharp
{
    public class genericLoggerIface : IDisposable
    {
        private readonly ILog logger;
        private IntPtr genericLoggerp = IntPtr.Zero;
        private bool disposed = false;

        private void callback(IntPtr userDatavp, genericLoggerLevel_t logLeveli, string msgs)
        {
            switch (logLeveli)
            {
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_TRACE:
                    this.logger.Debug(msgs);
                    break;
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_DEBUG:
                    this.logger.Debug(msgs);
                    break;
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_INFO:
                    this.logger.Info(msgs);
                    break;
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_NOTICE:
                    this.logger.Info(msgs);
                    break;
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_WARNING:
                    this.logger.Warn(msgs);
                    break;
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_ERROR:
                    this.logger.Error(msgs);
                    break;
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_CRITICAL:
                    this.logger.Warn(msgs);
                    break;
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_ALERT:
                    this.logger.Warn(msgs);
                    break;
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_EMERGENCY:
                    this.logger.Warn(msgs);
                    break;
            }
        }

        public genericLoggerIface(ILog logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.genericLoggerp = genericLoggershr.genericLogger_newp(callback, IntPtr.Zero, genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_INFO);
        }

        ~genericLoggerIface()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                genericLoggershr.genericLogger_freev(ref this.genericLoggerp);

                // Note disposing has been done.
                disposed = true;
            }
        }

        public void Info(string msgs)
        {
            genericLoggershr.genericLogger_logv(this.genericLoggerp, genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_INFO, "%s", msgs);
        }
    }
}
