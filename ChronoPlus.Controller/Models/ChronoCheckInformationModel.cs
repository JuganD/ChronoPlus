using System;
using System.Collections.Generic;
using ChronoPlus.Controller.Abstraction;
using Newtonsoft.Json;

namespace ChronoPlus.Controller.Models
{
    public class ChronoCheckInformationModel : IChronoInformationSegment
    {
        public ChronoCheckCoinsInformationModel Coins { get; set; }

        [JsonProperty("status")] public int StatusCode { get; set; }

        [JsonProperty("email")] public string Email { get; set; }

        public ChronoCheckPropertiesInformationModel Properties { get; set; }
        public List<ChronoCheckSubscriptionsInformationModel> Subscriptions { get; set; }
    }

    public class ChronoCheckCoinsInformationModel
    {
        [JsonProperty("balance")] public int Balance { get; set; }

        [JsonProperty("legendaries")] public int Legendaries { get; set; }

        [JsonProperty("last")] public DateTime LastSpin { get; set; }

        [JsonProperty("new")] public bool New { get; set; }

        [JsonProperty("spins")] public int Spins { get; set; }
    }

    public class ChronoCheckPropertiesInformationModel
    {
        [JsonProperty("showCoinsIntro")] public bool ShowCoinsIntro { get; set; }

        [JsonProperty("visitedShop")] public bool VisitedShop { get; set; }

        [JsonProperty("coinsConverted")] public bool CoinsConverted { get; set; }
    }

    public class ChronoCheckSubscriptionsInformationModel
    {
        [JsonProperty("list_id")] public string ListId { get; set; }

        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("_id")] public string Id { get; set; }

        public List<string> Tags { get; set; }

        [JsonProperty("updated")] public DateTime Updated { get; set; }
    }
}