using System;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace PocoHttp.SL
{
    public class PocoClient
    {
        private readonly WebClient webClient;

        public PocoClient(PocoConfiguration configuration)
        {
            webClient = configuration.WebClient;
        }

        public IQueryable Context(Type entityType, Uri uri)
        {
            if (BaseAddess == null && (uri == null || !uri.IsAbsoluteUri))
            {
                throw new InvalidOperationException("BaseAddress is null and uri is null or relative. Set base address or provide absolute uri.");
            }

            IQueryable result = null;

            webClient.DownloadStringAsync(uri);

            webClient.DownloadStringCompleted += (sender, args) => { result = JsonConvert.DeserializeObject<IQueryable>(args.Result); };

            return result;
        }

        public Uri BaseAddess
        {
            get { return new Uri(webClient.BaseAddress); }
            set { webClient.BaseAddress = value.ToString(); }
        }
    }
}
