using System;

namespace CandidateTesting.GustavoDosReisViana.Connection
{
    /// <summary>
    /// Contract for classes responsible for making requests to the log server.
    /// </summary>
    public interface ILogResponseLoader
    {
        /// <summary>
        /// Returns an object with the server's response.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        ILogReader GetConnectionResponse(Uri uri);
    }
}
