namespace CandidateTesting.GustavoDosReisViana.Models
{
    public class MinhaCdnLog
    {
        public int ResponseSize { get; set; }
        public int StatusCode { get; set; }
        public string CacheStatus { get; set; }
        public string HttpMethod { get; set; }
        public string UriPath { get; set; }
        public double TimeTaken { get; set; }
    }
}