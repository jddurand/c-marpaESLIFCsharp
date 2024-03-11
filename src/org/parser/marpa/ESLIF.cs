using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using static org.parser.marpa.marpaESLIFShr;

namespace org.parser.marpa
{
    public sealed class ESLIF : IDisposable
    {
        private static readonly ConcurrentDictionary<ILogger, ESLIF> Multitons = new ConcurrentDictionary<ILogger, ESLIF>();
        private readonly genericLogger genericLogger;
        private readonly IntPtr marpaESLIFp;
        private bool disposedValue;

        public ESLIF(ILogger logger = null)
        {
            this.genericLogger = new genericLogger(logger);
            this.marpaESLIFp = marpaESLIF_newp(
                    new marpaESLIFOption_t
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

                marpaESLIF_freev(this.marpaESLIFp);
                disposedValue = true;
            }
        }

        public string Version()
        {
            IntPtr versionPtr = IntPtr.Zero;

            if (marpaESLIF_versionb(this.marpaESLIFp, ref versionPtr) == 0)
            {
                throw new Exception("marpaESLIF_versionb failure");
            }

            // It returns a pointer to a static string in the library
            return Marshal.PtrToStringAnsi(versionPtr);
        }

        public int Major()
        {
            int major = 0;

            if (marpaESLIF_versionMajorb(this.marpaESLIFp, ref major) == 0)
            {
                throw new Exception("marpaESLIF_versionMajorb failure");
            }

            return major;
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
