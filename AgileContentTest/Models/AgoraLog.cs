using System.Text;

namespace CandidateTesting.GustavoDosReisViana.Models
{
    public class AgoraLog
    {
        public string Provider { get; set; }
        public string HttpMethod { get; set; }
        public int StatusCode { get; set; }
        public string UriPath { get; set; }
        public int TimeTaken { get; set; }
        public int ResponseSize { get; set; }
        public string CacheStatus { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder
                .AppendFormat("\"{0}\" ", this.Provider)
                .AppendFormat("{0} ", this.HttpMethod)
                .AppendFormat("{0} ", this.StatusCode)
                .AppendFormat("{0} ", this.UriPath)
                .AppendFormat("{0} ", this.TimeTaken)
                .AppendFormat("{0} ", this.ResponseSize)
                .AppendFormat("{0}", this.CacheStatus);

            return builder.ToString();
        }
    }
}
