

using Newtonsoft.Json;

namespace Warframe_Market_Manager.Lib.WFM
{
    public partial class LinkedAccounts
    {
        [JsonProperty("steam_profile", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SteamProfile { get; set; }

        [JsonProperty("patreon_profile", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PatreonProfile { get; set; }

        [JsonProperty("xbox_profile", NullValueHandling = NullValueHandling.Ignore)]
        public bool? XboxProfile { get; set; }
    }
}
