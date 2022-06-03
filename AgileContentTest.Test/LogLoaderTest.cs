using AgileContentTest.Test.Samples;
using CandidateTesting.GustavoDosReisViana;
using CandidateTesting.GustavoDosReisViana.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgileContentTest.Test
{
    [TestClass]
    public class LogLoaderTest
    {
        [TestMethod]
        public void TestToString()
        {
            AgoraLog log = new AgoraLog
            {
                Provider = "MINHA CDN",
                HttpMethod = "GET",
                StatusCode = 200,
                UriPath = "/robots.txt",
                TimeTaken = 100,
                ResponseSize = 312,
                CacheStatus = "HIT"
            };

            Assert.AreEqual(AgoraRaw.Sample1, log.ToString());
        }

        [TestMethod]
        public void TestMinhaCdnToAgoraLog()
        {
            MinhaCdnLog minhaCdnLog = new MinhaCdnLog
            {
                ResponseSize = 199,
                StatusCode = 404,
                CacheStatus = "MISS",
                HttpMethod = "GET",
                UriPath = "/not-found",
                TimeTaken = 142.9,
            };

            Assert.AreEqual(AgoraRaw.Sample3, LogLoader.LoadAgoraFromMinhaCdn(minhaCdnLog).ToString());
        }

        [TestMethod]
        public void TestParseMinhaCdnLog()
        {
            string origin = MinhaCdnRaw.Sample2;
            MinhaCdnLog parsed = LogLoader.LoadMinhaCdnFrom(origin);

            Assert.AreEqual(101, parsed.ResponseSize);
            Assert.AreEqual(200, parsed.StatusCode);
            Assert.AreEqual("MISS", parsed.CacheStatus);
            Assert.AreEqual("POST", parsed.HttpMethod);
            Assert.AreEqual("/myImages", parsed.UriPath);
            Assert.AreEqual(319.4, parsed.TimeTaken);
        }
    }
}
