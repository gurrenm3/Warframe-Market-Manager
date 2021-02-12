using Newtonsoft.Json;
using System;

namespace Warframe_Market_Manager.Lib.WFM
{
    public class DropRelic
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("link")]
        public Uri Link { get; set; }
    }
}