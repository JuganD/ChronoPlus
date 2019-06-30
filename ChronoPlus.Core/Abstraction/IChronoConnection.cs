using System.Net.Http;
using System.Threading.Tasks;

namespace ChronoPlus.Core.Abstraction
{
    public interface IChronoConnection
    {
        HttpResponseMessage SendHttpRequest(IChronoConnectionSettings settings);
        Task<HttpResponseMessage> SendHttpRequestAsync(IChronoConnectionSettings settings);
        HttpResponseMessage SendInformRequest(IChronoConnectionSettings settings);
        Task<HttpResponseMessage> SendInformRequestAsync(IChronoConnectionSettings settings);
    }
}