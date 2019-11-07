using System.Collections.Generic;
using System.Net.Http;
using ChronoPlus.Core.Abstraction;
using ChronoPlus.Core.Enums;

namespace ChronoPlus.Core
{
    public class ChronoConnectionSettings : IChronoConnectionSettings
    {
        private readonly Dictionary<string, string> _headers;

        public ChronoConnectionSettings()
        {
            this.Method = HttpMethod.Get;
            this._headers = new Dictionary<string, string>();
        }

        public ChronoConnectionSettings(string authenticationKey) : this()
        {
            this.AuthenticationKey = authenticationKey;
        }

        public string Url { get; set; }
        public HttpMethod Method { get; set; }
        public IReadOnlyDictionary<string, string> Headers => this._headers;
        public string AuthenticationKey { get; set; }

        public void PrepareWithDefaultSettings(ChronoMethod method)
        {
            this._headers.Clear();
            
            DefineHeader("Host", "api.chrono.gg");
            DefineHeader("User-Agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:67.0) Gecko/20100101 Firefox/67.0");
            DefineHeader("Accept-Language", "en-US,en;q=0.5");
            DefineHeader("Accept-Encoding", "gzip, deflate, br");

            switch (method)
            {
                case ChronoMethod.Spin:
                    this.Url = "https://api.chrono.gg/quest/spin";
                    break;
                case ChronoMethod.Check:
                    this.Url = "https://api.chrono.gg/account";
                    break;
                case ChronoMethod.Offers:
                    this.Url = "https://api.chrono.gg/shop";
                    break;
            }

            // Authorization and json requirement. Currently used by all ChronoMethods.
            DefineHeader("Accept", "application/json");
            DefineHeader("Authorization", "JWT " + this.AuthenticationKey);

            DefineHeader("Referer", "https://www.chrono.gg/");
            DefineHeader("Origin", "https://www.chrono.gg");
            DefineHeader("Connection", "keep-alive");
        }

        public void DefineHeader(string key, string value)
        {
            if (!this._headers.ContainsKey(key)) this._headers.Add(key, null);
            this._headers[key] = value;
        }

        public bool RemoveHeader(string key)
        {
            if (!this._headers.ContainsKey(key)) return false;
            this._headers.Remove(key);
            return true;
        }
    }
}