using Newtonsoft.Json;
using System;

namespace Warframe_Market_Manager.Lib.WFM
{
    public class Order
    {
        [JsonProperty("item", NullValueHandling = NullValueHandling.Ignore)]
        public ItemOverview ItemOverview { get; set; }

        [JsonProperty("visible", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Visible { get; set; }

        [JsonProperty("region", NullValueHandling = NullValueHandling.Ignore)]
        public Region? Region { get; set; }

        [JsonProperty("platform", NullValueHandling = NullValueHandling.Ignore)]
        public Platform? DevicePlatform { get; set; }

        [JsonProperty("creation_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CreationDate { get; set; }

        [JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
        public long? Quantity { get; set; }

        [JsonProperty("last_update", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? LastUpdate { get; set; }

        [JsonProperty("order_type", NullValueHandling = NullValueHandling.Ignore)]
        public OrderType? OrderType { get; set; }

        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public User User { get; set; }

        [JsonProperty("platinum", NullValueHandling = NullValueHandling.Ignore)]
        public long? Platinum { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
    }
}
