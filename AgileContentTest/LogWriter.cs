using CandidateTesting.GustavoDosReisViana.Models;
using System;
using System.IO;
using System.Text;

namespace CandidateTesting.GustavoDosReisViana
{
    public class LogWriter : IDisposable
    {
        public const string Version = "1.0";
        private const string LogFields = "provider http-method status-code uri-path time-taken response-size cache-status";
        private readonly DateTime logTime;

        private bool disposed = false;
        private Stream baseStream;
        private StreamWriter writer;

        public LogWriter(string filePath, DateTime logTime) : this(new FileStream(filePath, FileMode.Create), logTime)
        {
        }

        public LogWriter(Stream stream, DateTime logTime)
        {
            this.baseStream = stream;
            this.writer = new StreamWriter(this.baseStream);
            this.logTime = logTime;
            this.WriteAllFileHeaders();
        }

        private void WriteAllFileHeaders()
        {
            this.WriteHeader("Version", Version);
            this.WriteHeader("Date", this.logTime.ToString("dd/MM/yyyy HH:mm:ss"));
            this.WriteHeader("Fields", LogFields);
        }

        private void WriteHeader(string name, string value)
        {
            this.writer.WriteLine("#{0}: {1}", name, value);
            this.writer.Flush();
        }

        public void WriteLog(AgoraLog log)
        {
            this.writer.WriteLine(log.ToString());
            this.writer.Flush();
        }

        #region IDisposable
        ~LogWriter()
        {
            this.Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
                return;

            this.disposed = true;

            if (disposing)
            {
                this.writer.Dispose();
                this.baseStream.Dispose();
            }

            this.writer = null;
            this.baseStream = null;
        }

        public void Dispose()
        {
            if (this.disposed)
                throw new ObjectDisposedException(nameof(LogWriter));

            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
