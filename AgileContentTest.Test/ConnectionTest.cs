using AgileContentTest.Test.Mocks;
using AgileContentTest.Test.Samples;
using CandidateTesting.GustavoDosReisViana.Connection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace AgileContentTest.Test
{
    [TestClass]
    public class ConnectionTest
    {
        private static readonly Uri SampleServer = new Uri("https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt");

        [TestMethod]
        public void ReadLogsTest()
        {
            var connection = new MinhaCdnLogConnection(new LogConnectionLoaderMock());
            string[] RawLogs = connection.GetRawLogs(SampleServer).ToArray();

            Assert.AreEqual(MinhaCdnRaw.Sample1, RawLogs[0]);
            Assert.AreEqual(MinhaCdnRaw.Sample2, RawLogs[1]);
            Assert.AreEqual(MinhaCdnRaw.Sample3, RawLogs[2]);
            Assert.AreEqual(MinhaCdnRaw.Sample4, RawLogs[3]);
            Assert.AreEqual(4, RawLogs.Length);
        }
    }
}
