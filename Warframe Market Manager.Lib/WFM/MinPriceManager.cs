using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warframe_Market_Manager.Lib.WFM
{
    public class MinPriceManager
    {
        public static string priceDataLocation = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\Warframe Market Manager\\MinPrice Data";

        public string ItemName { get; set; } = "";
        public string item_url_name { get; set; } = "";
        public long? MinPrice { get; set; }



        public static MinPriceManager LoadFromFile(string itemName)
        {
            string path = $"{priceDataLocation}\\{itemName}.json";

            if (File.Exists(path))
                return Serializer.LoadFromFile<MinPriceManager>(path);

            var newManager = new MinPriceManager();
            newManager.ItemName = itemName;
            SaveToFile(newManager);
            return newManager;
        }

        public void SaveToFile() => SaveToFile(this);
        public static void SaveToFile(MinPriceManager minPriceManager)
        {
            string path = $"{priceDataLocation}\\{minPriceManager.ItemName}.json";
            Serializer.SaveToFile(minPriceManager, path);
        }
    }
}
