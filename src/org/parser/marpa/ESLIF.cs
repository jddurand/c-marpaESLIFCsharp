using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace org.parser.marpa
{
    public class ESLIF : IDisposable
    {
        private static readonly object Lock = new object();
        private static readonly Dictionary<IntPtr,ESLIF> Multitons =new Dictionary<IntPtr, ESLIF>();

        private readonly IntPtr marpaESLIFp;
        private readonly ILogger logger;
        protected IntPtr genericLoggerp;
        private readonly GCHandle loggerHandle;
        private IntPtr loggerHandlePtr;
        private bool disposedValue;

        private ESLIF(ILogger logger)
        {
            this.logger = logger; // Can be null

            // Callback context is a handle to the logger
            if (this.logger != null)
            {
                this.loggerHandle = GCHandle.Alloc(logger, GCHandleType.Normal);
                this.loggerHandlePtr = GCHandle.ToIntPtr(this.loggerHandle);
                // Log level is driven by logger, so we put GENERICLOGGER_LOGLEVEL_TRACE to filter nothing
                this.genericLoggerp = genericLoggerShr.genericLogger_newp(logCallback, this.loggerHandlePtr, genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_TRACE);
                if (this.genericLoggerp == IntPtr.Zero)
                {
                    DisposeUnmanagedResources();
                    throw new Exception("genericLogger_newp failure");
                }

                marpaESLIFShr.marpaESLIFOption_t marpaESLIFOption = new marpaESLIFShr.marpaESLIFOption_t
                {
                    genericLoggerp = genericLoggerp,
                };

                IntPtr marpaESLIFOptionp = Marshal.AllocHGlobal(Marshal.SizeOf(marpaESLIFOption));
                Marshal.StructureToPtr(marpaESLIFOption, marpaESLIFOptionp, false);
                this.marpaESLIFp = marpaESLIFShr.marpaESLIF_newp(marpaESLIFOptionp);
                Marshal.FreeHGlobal(marpaESLIFOptionp);
            }
            else
            {
                this.marpaESLIFp = marpaESLIFShr.marpaESLIF_newp(IntPtr.Zero);
            }

            if (this.marpaESLIFp == IntPtr.Zero)
            {
                DisposeUnmanagedResources();
                throw new Exception("marpaESLIF_newp failure");
            }
        }

        public static ESLIF GetESLIFInstance(ILogger logger = null)
        {
            lock (Lock)
            {
                // Multiton key is marpaESLIFp (always != IntPtr.Zero), value is the instance, test is on instance's logger
                ESLIF ESLIF;
                KeyValuePair<IntPtr, ESLIF> keyPair = Multitons.FirstOrDefault(p => logger == p.Value.logger);
                if (keyPair.Key != IntPtr.Zero)
                {
                    ESLIF = keyPair.Value;
                }
                else
                {
                    ESLIF = new ESLIF(logger);
                    Multitons.Add(ESLIF.marpaESLIFp, ESLIF);
                }

                return ESLIF;
            }
        }

        private static void logCallback(IntPtr userDatavp, genericLoggerShr.genericLoggerLevel_t logLeveli, IntPtr msgs)
        {
            if (userDatavp == IntPtr.Zero || msgs == IntPtr.Zero)
            {
                return;
            }

            GCHandle loggerHandlePtr = GCHandle.FromIntPtr(userDatavp);
            ILogger logger = (ILogger) loggerHandlePtr.Target;
            if (logger == null)
            {
                return;
            }

            string message = Marshal.PtrToStringAnsi(msgs);
            switch (logLeveli)
            {
                case genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_TRACE:
                    logger.LogTrace(message);
                    break;
                case genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_DEBUG:
                    logger.LogDebug(message);
                    break;
                case genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_INFO:
                    logger.LogInformation(message);
                    break;
                case genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_NOTICE:
                    logger.LogInformation(message);
                    break;
                case genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_WARNING:
                    logger.LogWarning(message);
                    break;
                case genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_ALERT:
                    logger.LogWarning(message);
                    break;
                case genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_EMERGENCY:
                    logger.LogWarning(message);
                    break;
                case genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_ERROR:
                    logger.LogError(message);
                    break;
                case genericLoggerShr.genericLoggerLevel_t.GENERICLOGGER_LOGLEVEL_CRITICAL:
                    logger.LogCritical(message);
                    break;
            }
        }

        private void DisposeUnmanagedResources()
        {
            if (this.loggerHandlePtr != IntPtr.Zero)
            {
                this.loggerHandle.Free();
                this.loggerHandlePtr = IntPtr.Zero;
            }

            if (this.genericLoggerp != IntPtr.Zero)
            {
                genericLoggerShr.genericLogger_freev(ref this.genericLoggerp);
                this.loggerHandle.Free();
                this.loggerHandlePtr = IntPtr.Zero;
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // DONE: dispose managed state (managed objects)
                }

                // DONE: free unmanaged resources (unmanaged objects) and override finalizer
                DisposeUnmanagedResources();

                // DONE: set large fields to null
                disposedValue = true;
            }
        }

        // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~ESLIF()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public string Version()
        {
            IntPtr versionsp = IntPtr.Zero;
            if (marpaESLIFShr.marpaESLIF_versionb(this.marpaESLIFp, ref versionsp) == 0)
            {
                throw new Exception("marpaESLIF_versionb failure");
            }

            string version;
            if (versionsp != IntPtr.Zero)
            {
                version = Marshal.PtrToStringAnsi(versionsp);
                // No free : this is a pointer to a string owned by marpaESLIF
            }
            else
            {
                version = null;
            }

            return version;
        }

        public int VersionMajor()
        {
            int versionMajor = 0;
            if (marpaESLIFShr.marpaESLIF_versionMajorb(this.marpaESLIFp, ref versionMajor) == 0)
            {
                throw new Exception("marpaESLIF_versionMajorb failure");
            }

            return versionMajor;
        }
    
        public int VersionMinor()
        {
            int versionMinor = 0;
            if (marpaESLIFShr.marpaESLIF_versionMinorb(this.marpaESLIFp, ref versionMinor) == 0)
            {
                throw new Exception("marpaESLIF_versionMinorb failure");
            }

            return versionMinor;
        }
    
        public int VersionPatch()
        {
            int versionPatch = 0;
            if (marpaESLIFShr.marpaESLIF_versionPatchb(this.marpaESLIFp, ref versionPatch) == 0)
            {
                throw new Exception("marpaESLIF_versionPatchb failure");
            }

            return versionPatch;
        }
    }
}
