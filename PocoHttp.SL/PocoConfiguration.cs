using System.Net;

namespace PocoHttp.SL
{
    public class PocoConfiguration
    {
        public PocoConfiguration()
        {
            WebClient = new WebClient();
        }

        public WebClient WebClient { get; set; }
    }
}