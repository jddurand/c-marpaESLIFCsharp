using log4net;
using System;
using static marpaESLIFCsharp.genericLoggershr;

namespace marpaESLIFCsharp
{
    public class genericLoggerIface : IDisposable
    {
        private static readonly ILog log = LogManager.GetLogger("marpaESLIFCsharp");
        private IntPtr genericLoggerp = IntPtr.Zero;
        private bool disposed = false;

        private static void callback(IntPtr userDatavp, genericLoggerLevel_t logLeveli, string msgs)
        {
            switch (logLeveli)
            {
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_TRACE:
                    log.Debug(msgs);
                    break;
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_DEBUG:
                    log.Debug(msgs);
                    break;
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_INFO:
                    log.Info(msgs);
                    break;
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_NOTICE:
                    log.Info(msgs);
                    break;
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_WARNING:
                    log.Warn(msgs);
                    break;
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_ERROR:
                    log.Error(msgs);
                    break;
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_CRITICAL:
                    log.Warn(msgs);
                    break;
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_ALERT:
                    log.Warn(msgs);
                    break;
                case genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_EMERGENCY:
                    log.Warn(msgs);
                    break;
            }
        }

        public genericLoggerIface()
        {
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
                genericLoggershr.genericLogger_freev(this.genericLoggerp);
                this.genericLoggerp = IntPtr.Zero;

                // Note disposing has been done.
                disposed = true;
            }
        }
    }
}
