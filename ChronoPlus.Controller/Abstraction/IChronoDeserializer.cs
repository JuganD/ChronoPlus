using System.Net.Http;
using ChronoPlus.Core.Enums;

namespace ChronoPlus.Controller.Abstraction
{
    public interface IChronoDeserializer
    {
        /// <summary>
        ///     Returns ChronoHttpContext object with the data from the response depending on the method type.
        ///     Returns null if errors occured
        /// </summary>
        /// <param name="response">Current HttpResponseMessage</param>
        /// <param name="method">Used ChronoMethod</param>
        /// <returns>Returns new ChronoHttpContext object, containing the response, according to the method</returns>
        ChronoHttpContext DeserializeResponse(HttpResponseMessage response, ChronoMethod method);
    }
}