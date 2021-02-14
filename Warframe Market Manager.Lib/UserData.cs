using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warframe_Market_Manager.Lib
{
    public class UserData
    {
        public static string location = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\Warframe Market Manager\\user data.json";

        public DateTime LastOrderUpdate { get; set; } = new DateTime();

        private static UserData instance;

        public static UserData Instance
        {
            get
            {
                if (instance is null)
                    instance = LoadFromFile();
                return instance;
            }
            set { instance = value; }
        }



        public void SaveToFile() => SaveToFile(this);
        public static void SaveToFile(UserData userData)=> Serializer.SaveToFile(userData, location);
        public static UserData LoadFromFile()
        {
            if (!File.Exists(location))
            {
                var userData = new UserData();
                userData.SaveToFile();
                return userData;
            }
            
            return Serializer.LoadFromFile<UserData>(location);
        }
    }
}
