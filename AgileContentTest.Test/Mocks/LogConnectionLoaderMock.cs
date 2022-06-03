using CandidateTesting.GustavoDosReisViana.Connection;
using System;

namespace AgileContentTest.Test.Mocks
{
    /// <summary>
    /// Mock used to retrieve an object with the log reader.
    /// </summary>
    public class LogConnectionLoaderMock : ILogResponseLoader
    {
        public ILogReader GetConnectionResponse(Uri uri)
        {
            return new LogResponseReaderMock();
        }
    }
}
