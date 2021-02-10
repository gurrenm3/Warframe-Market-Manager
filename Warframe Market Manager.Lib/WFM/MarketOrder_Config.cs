﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Warframe_Market_Manager.Lib.WFM;
//
//    var marketOrderConfig = MarketOrderConfig.FromJson(jsonString);

namespace Warframe_Market_Manager.Lib.WFM
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MarketOrder_Config
    {
        [JsonProperty("payload")]
        public Payload Payload { get; set; }
    }

    public partial class Payload
    {
        [JsonProperty("orders")]
        public Order[] Orders { get; set; }
    }

    public partial class Order
    {
        [JsonProperty("region")]
        public Region Region { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("order_type")]
        public OrderType OrderType { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("platinum")]
        public long Platinum { get; set; }

        [JsonProperty("visible")]
        public bool Visible { get; set; }

        [JsonProperty("last_update")]
        public DateTimeOffset LastUpdate { get; set; }

        [JsonProperty("platform")]
        public Platform Platform { get; set; }

        [JsonProperty("creation_date")]
        public DateTimeOffset CreationDate { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class User
    {
        [JsonProperty("ingame_name")]
        public string IngameName { get; set; }

        [JsonProperty("last_seen")]
        public DateTimeOffset LastSeen { get; set; }

        [JsonProperty("reputation")]
        public long Reputation { get; set; }

        [JsonProperty("region")]
        public Region Region { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }
    }

    public enum OrderType { Buy, Sell };

    public enum Platform { Pc };

    public enum Region { En };

    public enum Status { Ingame, Offline };

    public partial class MarketOrder_Config
    {
        public static MarketOrder_Config FromJson(string json) => JsonConvert.DeserializeObject<MarketOrder_Config>(json, Warframe_Market_Manager.Lib.WFM.MarketOrder_Converter.Settings);
    }

    public static class MarketOrder_Serialize
    {
        public static string ToJson(this MarketOrder_Config self) => JsonConvert.SerializeObject(self, Warframe_Market_Manager.Lib.WFM.MarketOrder_Converter.Settings);
    }

    internal static class MarketOrder_Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                OrderTypeConverter.Singleton,
                PlatformConverter.Singleton,
                RegionConverter.Singleton,
                StatusConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class OrderTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(OrderType) || t == typeof(OrderType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "buy":
                    return OrderType.Buy;
                case "sell":
                    return OrderType.Sell;
            }
            throw new Exception("Cannot unmarshal type OrderType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (OrderType)untypedValue;
            switch (value)
            {
                case OrderType.Buy:
                    serializer.Serialize(writer, "buy");
                    return;
                case OrderType.Sell:
                    serializer.Serialize(writer, "sell");
                    return;
            }
            throw new Exception("Cannot marshal type OrderType");
        }

        public static readonly OrderTypeConverter Singleton = new OrderTypeConverter();
    }

    internal class PlatformConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Platform) || t == typeof(Platform?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "pc")
            {
                return Platform.Pc;
            }
            throw new Exception("Cannot unmarshal type Platform");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Platform)untypedValue;
            if (value == Platform.Pc)
            {
                serializer.Serialize(writer, "pc");
                return;
            }
            throw new Exception("Cannot marshal type Platform");
        }

        public static readonly PlatformConverter Singleton = new PlatformConverter();
    }

    internal class RegionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Region) || t == typeof(Region?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "en")
            {
                return Region.En;
            }
            throw new Exception("Cannot unmarshal type Region");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Region)untypedValue;
            if (value == Region.En)
            {
                serializer.Serialize(writer, "en");
                return;
            }
            throw new Exception("Cannot marshal type Region");
        }

        public static readonly RegionConverter Singleton = new RegionConverter();
    }

    internal class StatusConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Status) || t == typeof(Status?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "ingame":
                    return Status.Ingame;
                case "offline":
                    return Status.Offline;
                default:
                    return Status.Offline;
            }
            //throw new Exception("Cannot unmarshal type Status");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Status)untypedValue;
            switch (value)
            {
                case Status.Ingame:
                    serializer.Serialize(writer, "ingame");
                    return;
                case Status.Offline:
                    serializer.Serialize(writer, "offline");
                    return;
            }
            throw new Exception("Cannot marshal type Status");
        }

        public static readonly StatusConverter Singleton = new StatusConverter();
    }
}