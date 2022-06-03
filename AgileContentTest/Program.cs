using CandidateTesting.GustavoDosReisViana.Connection;
using CandidateTesting.GustavoDosReisViana.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CandidateTesting.GustavoDosReisViana
{
    class Program
    {
        private readonly ArgumentInfo info;

        private Program(ArgumentInfo info)
        {
            this.info = info;
        }

        static void Main(string[] args)
        {
            try
            {
                new Program(LoadArgs(args)).SaveLogFile();
                Console.WriteLine("Successful downloading and converting logs.");
                SendContinueMessage();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SendContinueMessage();
            }
        }

        public static ArgumentInfo LoadArgs(string[] args)
        {
            if (args.Length != 3 || args[0].ToLower() != "convert")
                throw new NotSupportedException("Only \"convert\" command is supported");

            return new ArgumentInfo
            {
                SourceUrl = new Uri(args[1]),
                TargetPath = args[2].Trim()
            };
        }

        private void SaveLogFile()
        {
            Console.WriteLine("Downloading logs from server...");
            AgoraLog[] logs = this.GetAgoraLogsFromMinhaCdn().ToArray();
            Console.WriteLine("Saving log in file...");

            using (var fileStream = this.CreateLogFile())
            using (var writer = new LogWriter(fileStream, DateTime.Now))
                foreach (var log in logs)
                    writer.WriteLog(log);
        }

        private FileStream CreateLogFile()
        {
            this.CreateParentDirectory();
            return new FileStream(this.info.TargetPath, FileMode.Create);
        }

        private void CreateParentDirectory()
        {
            string DirName = Path.GetDirectoryName(this.info.TargetPath);

            if (!Directory.Exists(DirName))
                Directory.CreateDirectory(DirName);
        }

        public IEnumerable<AgoraLog> GetAgoraLogsFromMinhaCdn()
        {
            foreach (var log in this.DownloadMinhaCdnLogs())
                yield return LogLoader.LoadAgoraFromMinhaCdn(log);
        }

        public IEnumerable<MinhaCdnLog> DownloadMinhaCdnLogs()
        {
            return new MinhaCdnLogConnection().GetLogs(this.info.SourceUrl);
        }

        private static void SendContinueMessage()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
