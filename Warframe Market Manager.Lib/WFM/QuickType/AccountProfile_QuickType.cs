﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Warframe_Market_Manager.Lib.WFM.QuickType;
//
//    var accountProfile = AccountProfile.FromJson(jsonString);

namespace Warframe_Market_Manager.Lib.WFM.QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class AccountProfile_QuickType
    {
        [JsonProperty("profile", NullValueHandling = NullValueHandling.Ignore)]
        public AccountProfile AccountProfile { get; set; }



        public static AccountProfile_QuickType FromJson(string json)
        {
            return JsonConvert.DeserializeObject<AccountProfile_QuickType>(json, Warframe_Market_Manager.Lib.WFM.QuickType.AccountProfile_QuickType.Settings);
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

    public static class AccountProfile_QuickTypeExt
    {
        public static string ToJson(this AccountProfile_QuickType self)
        {
            return JsonConvert.SerializeObject(self, Warframe_Market_Manager.Lib.WFM.QuickType.AccountProfile_QuickType.Settings);
        }
    }

    /*public class AccountProfile
    {
        [JsonProperty("platform", NullValueHandling = NullValueHandling.Ignore)]
        public string Platform { get; set; }

        [JsonProperty("check_code", NullValueHandling = NullValueHandling.Ignore)]
        public string CheckCode { get; set; }

        [JsonProperty("verification", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Verification { get; set; }

        [JsonProperty("linked_accounts", NullValueHandling = NullValueHandling.Ignore)]
        public LinkedAccounts LinkedAccounts { get; set; }

        [JsonProperty("unread_messages", NullValueHandling = NullValueHandling.Ignore)]
        public long? UnreadMessages { get; set; }

        [JsonProperty("ingame_name", NullValueHandling = NullValueHandling.Ignore)]
        public string IngameName { get; set; }

        [JsonProperty("reputation", NullValueHandling = NullValueHandling.Ignore)]
        public long? Reputation { get; set; }

        [JsonProperty("region", NullValueHandling = NullValueHandling.Ignore)]
        public string Region { get; set; }

        [JsonProperty("banned", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Banned { get; set; }

        [JsonProperty("written_reviews", NullValueHandling = NullValueHandling.Ignore)]
        public long? WrittenReviews { get; set; }

        [JsonProperty("role", NullValueHandling = NullValueHandling.Ignore)]
        public string Role { get; set; }

        [JsonProperty("anonymous", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Anonymous { get; set; }

        [JsonProperty("avatar", NullValueHandling = NullValueHandling.Ignore)]
        public string Avatar { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("has_mail", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasMail { get; set; }
    }*/

    /*public partial class LinkedAccounts
    {
        [JsonProperty("steam_profile", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SteamProfile { get; set; }

        [JsonProperty("patreon_profile", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PatreonProfile { get; set; }

        [JsonProperty("xbox_profile", NullValueHandling = NullValueHandling.Ignore)]
        public bool? XboxProfile { get; set; }
    }*/

    /*public partial class AccountProfile
    {
        public static AccountProfile FromJson(string json) => JsonConvert.DeserializeObject<AccountProfile>(json, Warframe_Market_Manager.Lib.WFM.QuickType.Converter.Settings);
    }*/

    /*public static class Serialize
    {
        public static string ToJson(this AccountProfile self) => JsonConvert.SerializeObject(self, Warframe_Market_Manager.Lib.WFM.QuickType.Converter.Settings);
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