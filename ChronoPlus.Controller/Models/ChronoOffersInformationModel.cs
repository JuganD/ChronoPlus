using System;
using System.Collections.Generic;
using ChronoPlus.Controller.Abstraction;
using Newtonsoft.Json;

namespace ChronoPlus.Controller.Models
{
    public class ChronoOffersInformationModel : IChronoInformationSegment
    {
        public List<ChronoOfferInformationModel> Offers { get; set; }
    }
    public class ChronoOfferInformationModel
    {
        [JsonProperty("active")] public bool Active { get; set; }

        [JsonProperty("created")] public DateTime CreatedOn { get; set; }
        [JsonProperty("sold_out")] public bool SoldOut { get; set; }
        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("_id")] public string Id { get; set; }
    }
}