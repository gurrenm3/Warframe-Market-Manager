using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Warframe_Market_Manager.Lib.WFM
{
    public class ItemDescription
    {
        [JsonProperty("item_name", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemName { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("wiki_link", NullValueHandling = NullValueHandling.Ignore)]
        public Uri WikiLink { get; set; }

        [JsonProperty("drop", NullValueHandling = NullValueHandling.Ignore)]
        public List<DropRelic> RelicsThatDropItem { get; set; }
    }
}