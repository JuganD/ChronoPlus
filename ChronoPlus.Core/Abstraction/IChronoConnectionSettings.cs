using System.Collections.Generic;
using System.Net.Http;
using ChronoPlus.Core.Enums;

namespace ChronoPlus.Core.Abstraction
{
    public interface IChronoConnectionSettings
    {
        string AuthenticationKey { get; set; }
        string Url { get; set; }
        HttpMethod Method { get; set; }
        IReadOnlyDictionary<string, string> Headers { get; }
        void DefineHeader(string key, string value);
        bool RemoveHeader(string key);
        void PrepareWithDefaultSettings(ChronoMethod method);
    }
}