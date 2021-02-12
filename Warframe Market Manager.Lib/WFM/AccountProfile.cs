using Newtonsoft.Json;

namespace Warframe_Market_Manager.Lib.WFM
{
    public class AccountProfile
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
    }
}
