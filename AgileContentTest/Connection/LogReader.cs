using System;
using System.IO;
using System.Net;

namespace CandidateTesting.GustavoDosReisViana.Connection
{
    public class LogReader : ILogReader
    {
        private bool disposed = false;
        private Stream baseStream;
        private StreamReader reader;

        public LogReader(HttpWebResponse response)
        {
            this.baseStream = response.GetResponseStream();
            this.reader = new StreamReader(this.baseStream);
        }

        public string ReadLogLine()
        {
            return this.reader.ReadLine();
        }

        #region IDisposable
        protected void Dispose(bool disposing)
        {
            if (this.disposed)
                return;

            this.disposed = true;

            if (disposing)
            {
                this.reader.Dispose();
                this.baseStream.Dispose();
            }

            this.reader = null;
            this.baseStream = null;
        }

        public void Dispose()
        {
            if (this.disposed)
                throw new ObjectDisposedException(nameof(LogReader));

            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~LogReader()
        {
            this.Dispose(false);
        }
        #endregion
    }
}
