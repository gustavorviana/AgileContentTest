using CandidateTesting.GustavoDosReisViana.Models;
using System;
using System.Globalization;

namespace CandidateTesting.GustavoDosReisViana
{
    public static class LogLoader
    {
        public static MinhaCdnLog LoadMinhaCdnFrom(string value)
        {
            string[] sections = value.Split('|');
            string[] httpInfo = GetMinhaCdnHttpInfo(sections[3]);

            return new MinhaCdnLog
            {
                ResponseSize = int.Parse(sections[0]),
                StatusCode = int.Parse(sections[1]),
                CacheStatus = sections[2],
                HttpMethod = httpInfo[0],
                UriPath = httpInfo[1],
                TimeTaken = double.Parse(sections[4], CultureInfo.InvariantCulture)
            };
        }

        private static string[] GetMinhaCdnHttpInfo(string info)
        {
            info = info.Substring(1, info.LastIndexOf("\"") - 2);
            return info.Split(' ');
        }

        public static AgoraLog LoadAgoraFromMinhaCdn(MinhaCdnLog log)
        {
            return new AgoraLog
            {
                Provider = "MINHA CDN",
                HttpMethod = log.HttpMethod,
                CacheStatus = log.CacheStatus,
                ResponseSize = log.ResponseSize,
                StatusCode = log.StatusCode,
                TimeTaken = (int)Math.Round(log.TimeTaken),
                UriPath = log.UriPath
            };
        }

        public static AgoraLog LoadAgoraFromMinhaCdn(string minhaCdn)
        {
            return LoadAgoraFromMinhaCdn(LoadMinhaCdnFrom(minhaCdn));
        }
    }
}
