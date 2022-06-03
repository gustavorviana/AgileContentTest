using CandidateTesting.GustavoDosReisViana.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace CandidateTesting.GustavoDosReisViana.Connection
{
    public class MinhaCdnLogConnection
    {
        private readonly ILogResponseLoader loader;

        public MinhaCdnLogConnection() : this(new LogConnectionLoader())
        {

        }

        public MinhaCdnLogConnection(ILogResponseLoader loader)
        {
            this.loader = loader;
        }

        public IEnumerable<MinhaCdnLog> GetLogs(Uri logUri)
        {
            foreach (var rawLog in this.GetRawLogs(logUri))
                yield return LogLoader.LoadMinhaCdnFrom(rawLog);
        }

        public IEnumerable<string> GetRawLogs(Uri logUri)
        {
            string logLine;
            using (ILogReader reader = this.loader.GetConnectionResponse(logUri))
                while ((logLine = reader.ReadLogLine()) != null)
                    yield return logLine;
        }

        private class LogConnectionLoader : ILogResponseLoader
        {
            public ILogReader GetConnectionResponse(Uri uri)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = "GET";

                return new LogReader((HttpWebResponse)request.GetResponse());
            }
        }
    }
}
