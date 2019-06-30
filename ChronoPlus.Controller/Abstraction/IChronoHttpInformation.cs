using System.Net.Http;

namespace ChronoPlus.Controller.Abstraction
{
    public interface IChronoHttpInformation
    {
        HttpResponseMessage Response { get; }
        string JsonResponse { get; }
        IChronoInformationSegment Model { get; }
    }
}