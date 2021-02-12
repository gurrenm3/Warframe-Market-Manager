using Newtonsoft.Json;
using System;
using Warframe_Market_Manager.Lib.WFM.QuickType;

namespace Warframe_Market_Manager.Lib.WFM
{
    public class User
    {
        [JsonProperty("ingame_name", NullValueHandling = NullValueHandling.Ignore)]
        public string IngameName { get; set; }

        [JsonProperty("last_seen", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? LastSeen { get; set; }

        [JsonProperty("reputation", NullValueHandling = NullValueHandling.Ignore)]
        public long? Reputation { get; set; }

        [JsonProperty("region", NullValueHandling = NullValueHandling.Ignore)]
        public string Region { get; set; }
        //public Region? Region { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public OnlineStatus? OnlineStatus { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }
    }
}
