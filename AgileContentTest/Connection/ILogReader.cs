using System;

namespace CandidateTesting.GustavoDosReisViana.Connection
{
    /// <summary>
    /// Contract for classes responsible for reading server logs.
    /// </summary>
    public interface ILogReader : IDisposable
    {
        string ReadLogLine();
    }
}
