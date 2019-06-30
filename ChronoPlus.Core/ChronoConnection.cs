using System;
using System.Net.Http;
using System.Threading.Tasks;
using ChronoPlus.Core.Abstraction;
using ChronoPlus.Core.Enums;

namespace ChronoPlus.Core
{
    public class ChronoConnection : IChronoConnection
    {
        private readonly HttpClient _client;

        public ChronoConnection(HttpClient client)
        {
            this._client = client;
        }

        public HttpResponseMessage SendHttpRequest(IChronoConnectionSettings settings)
        {
            var request = PrepareHttpRequest(settings);

            return this._client.SendAsync(request).GetAwaiter().GetResult();
        }

        public async Task<HttpResponseMessage> SendHttpRequestAsync(IChronoConnectionSettings settings)
        {
            var request = PrepareHttpRequest(settings);

            return await this._client.SendAsync(request);
        }

        public HttpResponseMessage SendInformRequest(IChronoConnectionSettings settings)
        {
            return SendHttpRequest(PrepareInformSettings(settings));
        }

        public async Task<HttpResponseMessage> SendInformRequestAsync(IChronoConnectionSettings settings)
        {
            return await SendHttpRequestAsync(PrepareInformSettings(settings));
        }

        private static HttpRequestMessage PrepareHttpRequest(IChronoConnectionSettings settings)
        {
            var request = new HttpRequestMessage
            {
                Method = settings.Method, RequestUri = new Uri(settings.Url)
            };

            foreach (var header in settings.Headers) request.Headers.Add(header.Key, header.Value);
            return request;
        }

        private static IChronoConnectionSettings PrepareInformSettings(IChronoConnectionSettings settings)
        {
            IChronoConnectionSettings informSettings = new ChronoConnectionSettings();
            informSettings.PrepareWithDefaultSettings(ChronoMethod.None);

            informSettings.DefineHeader("Accept", "*/*");
            informSettings.DefineHeader("Access-Control-Request-Method", "GET");
            informSettings.DefineHeader("Access-Control-Request-Headers", "authorization");
            informSettings.Url = settings.Url;
            informSettings.Method = HttpMethod.Options;

            return informSettings;
        }
    }
}