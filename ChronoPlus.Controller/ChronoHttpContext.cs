using System;
using System.ComponentModel;
using System.Net.Http;
using ChronoPlus.Controller.Abstraction;

namespace ChronoPlus.Controller
{
    public class ChronoHttpContext : IChronoHttpInformation, IDisposable
    {
        internal ChronoHttpContext(object annonimusObject, HttpResponseMessage response, string jsonResponse)
        {
            this.Model = (IChronoInformationSegment)annonimusObject;
        }
        internal ChronoHttpContext(IChronoInformationSegment model, HttpResponseMessage response, string jsonResponse)
            : this(response, jsonResponse)
        {
            this.Model = model;
        }

        internal ChronoHttpContext(HttpResponseMessage response, string jsonResponse)
        {
            this.Response = response;
            this.JsonResponse = jsonResponse;
        }

        /// <summary>
        ///     Http response from the last request.
        /// </summary>
        public HttpResponseMessage Response { get; }

        /// <summary>
        ///     Json decoded response.
        /// </summary>
        public string JsonResponse { get; }

        public IChronoInformationSegment Model { get; }

        public void Dispose()
        {
            this.Response?.Dispose();
        }
    }
}