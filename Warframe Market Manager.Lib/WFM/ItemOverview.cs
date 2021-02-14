using Newtonsoft.Json;
using System.Collections.Generic;

namespace Warframe_Market_Manager.Lib.WFM
{
    public class ItemOverview
    {
        public MinPriceManager PriceManager { get; set; } = new MinPriceManager();


        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("tradable", NullValueHandling = NullValueHandling.Ignore)]
        public bool Tradable { get; set; }

        [JsonProperty("trading_tax", NullValueHandling = NullValueHandling.Ignore)]
        public long? TradingTax { get; set; }

        [JsonProperty("en", NullValueHandling = NullValueHandling.Ignore)]
        public ItemDescription EnglishDescription { get; set; }

        [JsonProperty("set_root", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SetRoot { get; set; }

        [JsonProperty("mastery_level", NullValueHandling = NullValueHandling.Ignore)]
        public long? MasteryLevel { get; set; }

        [JsonProperty("sub_icon", NullValueHandling = NullValueHandling.Ignore)]
        public string SubIcon { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Tags { get; set; }

        [JsonProperty("url_name", NullValueHandling = NullValueHandling.Ignore)]
        public string UrlName { get; set; }

        [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

        [JsonProperty("icon_format", NullValueHandling = NullValueHandling.Ignore)]
        public string IconFormat { get; set; }

        [JsonProperty("thumb", NullValueHandling = NullValueHandling.Ignore)]
        public string Thumb { get; set; }

        [JsonProperty("ducats", NullValueHandling = NullValueHandling.Ignore)]
        public long? Ducats { get; set; }


        // Extra info for different languages. Not using because I don't plan to support it now
        /*[JsonProperty("zh-hans", NullValueHandling = NullValueHandling.Ignore)]
        public ItemOverview ZhHans { get; set; }

        [JsonProperty("fr", NullValueHandling = NullValueHandling.Ignore)]
        public ItemOverview Fr { get; set; }

        [JsonProperty("ko", NullValueHandling = NullValueHandling.Ignore)]
        public ItemOverview Ko { get; set; }

        [JsonProperty("de", NullValueHandling = NullValueHandling.Ignore)]
        public ItemOverview De { get; set; }

        [JsonProperty("es", NullValueHandling = NullValueHandling.Ignore)]
        public ItemOverview Es { get; set; }

        [JsonProperty("pl", NullValueHandling = NullValueHandling.Ignore)]
        public ItemOverview Pl { get; set; }

        [JsonProperty("pt", NullValueHandling = NullValueHandling.Ignore)]
        public ItemOverview Pt { get; set; }

        [JsonProperty("ru", NullValueHandling = NullValueHandling.Ignore)]
        public ItemOverview Ru { get; set; }

        [JsonProperty("zh-hant", NullValueHandling = NullValueHandling.Ignore)]
        public ItemOverview ZhHant { get; set; }

        [JsonProperty("sv", NullValueHandling = NullValueHandling.Ignore)]
        public ItemOverview Sv { get; set; }*/


        public ItemOverview()
        {
            
        }
    }
}
