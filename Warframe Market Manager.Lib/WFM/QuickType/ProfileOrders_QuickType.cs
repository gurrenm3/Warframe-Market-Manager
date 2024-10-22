﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Warframe_Market_Manager.Lib.WFM.QuickType;
//
//    var profileOrders = ProfileOrders.FromJson(jsonString);

namespace Warframe_Market_Manager.Lib.WFM.QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ProfileOrders_QuickType
    {
        [JsonProperty("payload", NullValueHandling = NullValueHandling.Ignore)]
        public Payload Payload { get; set; }

        /*[JsonProperty("sell_orders", NullValueHandling = NullValueHandling.Ignore)]
        public List<Order> SellOrders { get; set; }

        [JsonProperty("buy_orders", NullValueHandling = NullValueHandling.Ignore)]
        public List<Order> BuyOrders { get; set; }*/


        public static ProfileOrders_QuickType FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ProfileOrders_QuickType>(json, Warframe_Market_Manager.Lib.WFM.QuickType.ProfileOrders_QuickType.Settings);
        }

        internal static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    public static class ProfileOrders_QuickTypeExt
    {
        public static string ToJson(this ProfileOrders_QuickType self)
        {
            return JsonConvert.SerializeObject(self, Warframe_Market_Manager.Lib.WFM.QuickType.ProfileOrders_QuickType.Settings);
        }
    }

    public partial class Payload
    {
        [JsonProperty("sell_orders", NullValueHandling = NullValueHandling.Ignore)]
        public List<Order> SellOrders { get; set; }

        [JsonProperty("buy_orders", NullValueHandling = NullValueHandling.Ignore)]
        public List<Order> BuyOrders { get; set; }
    }

    /*public partial class Order
    {
        [JsonProperty("creation_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CreationDate { get; set; }

        [JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
        public long? Quantity { get; set; }

        [JsonProperty("visible", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Visible { get; set; }

        [JsonProperty("item", NullValueHandling = NullValueHandling.Ignore)]
        public Item Item { get; set; }

        [JsonProperty("last_update", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? LastUpdate { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("region", NullValueHandling = NullValueHandling.Ignore)]
        public string Region { get; set; }

        [JsonProperty("platinum", NullValueHandling = NullValueHandling.Ignore)]
        public long? Platinum { get; set; }

        [JsonProperty("platform", NullValueHandling = NullValueHandling.Ignore)]
        public string DevicePlatform { get; set; }

        [JsonProperty("order_type", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderType { get; set; }
    }*/

    /*public partial class ProfileItemOverview
    {
        [JsonProperty("thumb", NullValueHandling = NullValueHandling.Ignore)]
        public string Thumb { get; set; }

        [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Tags { get; set; }

        [JsonProperty("sub_icon")]
        public string SubIcon { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("url_name", NullValueHandling = NullValueHandling.Ignore)]
        public string UrlName { get; set; }

        [JsonProperty("en", NullValueHandling = NullValueHandling.Ignore)]
        public De En { get; set; }


        *//*[JsonProperty("zh-hant", NullValueHandling = NullValueHandling.Ignore)]
        public De ZhHant { get; set; }

        [JsonProperty("es", NullValueHandling = NullValueHandling.Ignore)]
        public De Es { get; set; }

        [JsonProperty("zh-hans", NullValueHandling = NullValueHandling.Ignore)]
        public De ZhHans { get; set; }

        [JsonProperty("ru", NullValueHandling = NullValueHandling.Ignore)]
        public De Ru { get; set; }

        [JsonProperty("sv", NullValueHandling = NullValueHandling.Ignore)]
        public De Sv { get; set; }

        [JsonProperty("pt", NullValueHandling = NullValueHandling.Ignore)]
        public De Pt { get; set; }

        [JsonProperty("de", NullValueHandling = NullValueHandling.Ignore)]
        public De De { get; set; }

        [JsonProperty("pl", NullValueHandling = NullValueHandling.Ignore)]
        public De Pl { get; set; }

        [JsonProperty("ko", NullValueHandling = NullValueHandling.Ignore)]
        public De Ko { get; set; }

        [JsonProperty("fr", NullValueHandling = NullValueHandling.Ignore)]
        public De Fr { get; set; }*//*
    }*/

    /*public partial class De
    {
        [JsonProperty("item_name", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemName { get; set; }
    }*/

    /*public partial class ProfileOrders_QuickType
    {
        public static ProfileOrders_QuickType FromJson(string json) => JsonConvert.DeserializeObject<ProfileOrders_QuickType>(json, Warframe_Market_Manager.Lib.WFM.QuickType.Converter.Settings);
    }*/

    /*public static class Serialize
    {
        public static string ToJson(this ProfileOrders_QuickType self) => JsonConvert.SerializeObject(self, Warframe_Market_Manager.Lib.WFM.QuickType.Converter.Settings);
    }*/

    /*internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }*/
}
