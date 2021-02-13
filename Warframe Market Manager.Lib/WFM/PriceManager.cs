using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warframe_Market_Manager.Lib.WFM
{
    public class PriceManager
    {
        string priceDataLocation = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\Warframe Market Manager\\MinPrice Data";

        public string item_url_name { get; set; } = "";
        public long MinPrice { get; set; }


        public PriceManager LoadFromFile()
        {
            string path = $"{priceDataLocation}\\{item_url_name}";

            if (File.Exists(path))
                return Serializer.LoadFromFile<PriceManager>(path);

            SaveToFile();
            return this;
        }

        public void SaveToFile()
        {
            string path = $"{priceDataLocation}\\{item_url_name}";
            Serializer.SaveToFile(this, path);
        }
    }
}
