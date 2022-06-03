using AgileContentTest.Test.Samples;
using CandidateTesting.GustavoDosReisViana;
using CandidateTesting.GustavoDosReisViana.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;

namespace AgileContentTest.Test
{
    [TestClass]
    public class LogWriterTest
    {
        private static readonly DateTime ExpectedTime = new DateTime(2017, 12, 15, 23, 01, 06);

        [TestMethod]
        public void WriteHeaderTest()
        {
            string headerResult = this.WriteLogInString();
            Assert.AreEqual(AgoraRaw.Header, headerResult);
        }

        [TestMethod]
        public void WriteOneLogTest()
        {
            AgoraLog log = LogLoader.LoadAgoraFromMinhaCdn(MinhaCdnRaw.Sample1);
            string streamResult = this.WriteLogInString(log).Substring(AgoraRaw.Header.Length);

            Assert.AreEqual(AgoraRaw.Sample1 + "\r\n", streamResult);
        }

        [TestMethod]
        public void WriteThreeLogsTest()
        {
            StringBuilder expected = new StringBuilder();
            expected
                .Append(AgoraRaw.Header)
                .AppendLine(AgoraRaw.Sample1)
                .AppendLine(AgoraRaw.Sample2)
                .AppendLine(AgoraRaw.Sample3);

            string streamResult = WriteLogInString(
                LogLoader.LoadAgoraFromMinhaCdn(MinhaCdnRaw.Sample1),
                LogLoader.LoadAgoraFromMinhaCdn(MinhaCdnRaw.Sample2),
                LogLoader.LoadAgoraFromMinhaCdn(MinhaCdnRaw.Sample3)
            );

            Assert.AreEqual(expected.ToString(), streamResult);
        }

        private string WriteLogInString(params AgoraLog[] logs)
        {
            using (MemoryStream stream = new MemoryStream())
            using (LogWriter writer = new LogWriter(stream, ExpectedTime))
            {
                foreach (var log in logs)
                    writer.WriteLog(log);

                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }
    }
}
