﻿using System.Collections.Generic;
using System.Net.Http;
using ChronoPlus.Controller.Abstraction;
using ChronoPlus.Controller.Models;
using ChronoPlus.Core.Enums;
using Newtonsoft.Json;

namespace ChronoPlus.Controller
{
    public class ChronoDeserializer : IChronoDeserializer
    {
        public ChronoHttpContext DeserializeResponse(HttpResponseMessage response, ChronoMethod method)
        {
            var jsonResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            //string testString = "{\"quest\":{\"_id\":-1,\"name\":\"default\",\"earns\":\"coins\",\"kind\":\"daily\",\"value\":20,\"bonus\":6},\"chest\":{\"base\":125,\"bonus\":31,\"kind\":3}}";
            //string jsonResponse =
            //"{\"quest\":{\"_id\":-1,\"name\":\"default\",\"earns\":\"coins\",\"kind\":\"daily\",\"value\":20,\"bonus\":9},\"chest\":{}}";
            try
            {
                switch (method)
                {
                    // Rolled
                    case ChronoMethod.Spin:
                        var objSpin = JsonConvert.DeserializeObject<ChronoCoinInformationModel>(jsonResponse);
                        return new ChronoHttpContext(objSpin, response, jsonResponse);
                    case ChronoMethod.Check:
                        var objCheck = JsonConvert.DeserializeObject<ChronoCheckInformationModel>(jsonResponse);
                        return new ChronoHttpContext(objCheck, response, jsonResponse);
                    case ChronoMethod.Offers:
                        var objOffers = JsonConvert.DeserializeObject<List<ChronoOfferInformationModel>>(jsonResponse);
                        return new ChronoHttpContext(new ChronoOffersInformationModel() { Offers = objOffers }, response, jsonResponse);
                    default:
                        return new ChronoHttpContext(response, jsonResponse);
                }
            }
            catch (JsonException)
            {
                try
                {
                    var annonimusObject = JsonConvert.DeserializeObject(jsonResponse);
                    return new ChronoHttpContext(annonimusObject, response, jsonResponse);
                }
                catch
                {
                    return new ChronoHttpContext(response, jsonResponse);
                }
            }
        }
    }
}