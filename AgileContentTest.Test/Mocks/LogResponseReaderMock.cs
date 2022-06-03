using AgileContentTest.Test.Samples;
using CandidateTesting.GustavoDosReisViana.Connection;
using System;
using System.IO;
using System.Text;

namespace AgileContentTest.Test.Mocks
{
    /// <summary>
    /// Mock used to simulate server response.
    /// </summary>
    public class LogResponseReaderMock : ILogReader
    {
        private StringReader reader;
        private bool disposed = false;

        public LogResponseReaderMock()
        {
            reader = new StringReader(BuildResponse());
        }

        private static string BuildResponse()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(MinhaCdnRaw.Sample1);
            builder.AppendLine(MinhaCdnRaw.Sample2);
            builder.AppendLine(MinhaCdnRaw.Sample3);
            builder.Append(MinhaCdnRaw.Sample4);
            return builder.ToString();
        }

        public string ReadLogLine()
        {
            return this.reader.ReadLine();
        }

        #region IDisposable
        ~LogResponseReaderMock()
        {
            this.Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
                return;

            this.disposed = true;

            if (disposing)
                this.reader.Dispose();

            this.reader = null;
        }

        public void Dispose()
        {
            if (this.disposed)
                throw new ObjectDisposedException(nameof(LogResponseReaderMock));

            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
