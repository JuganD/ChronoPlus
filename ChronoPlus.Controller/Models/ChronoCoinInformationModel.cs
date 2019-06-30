using ChronoPlus.Controller.Abstraction;
using Newtonsoft.Json;

namespace ChronoPlus.Controller.Models
{
    public class ChronoCoinInformationModel : IChronoInformationSegment
    {
        public ChronoCoinQuestInformationModel Quest { get; set; }
        public ChronoCoinChestInformationModel Chest { get; set; }
    }

    public class ChronoCoinQuestInformationModel
    {
        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("kind")] public string Kind { get; set; }

        [JsonProperty("earns")] public string RewardType { get; set; }

        [JsonProperty("value")] public int RewardValue { get; set; }

        [JsonProperty("bonus")] public int RewardBonus { get; set; }
    }

    public class ChronoCoinChestInformationModel
    {
        [JsonProperty("base")] public int RewardValue { get; set; }

        [JsonProperty("bonus")] public int RewardBonus { get; set; }

        [JsonProperty("kind")] public int RewardKind { get; set; }
    }
}