using RestSharp;
using System;
using System.IO;
using System.Linq;
using Warframe_Market_Manager.Lib.Web;

namespace Warframe_Market_Manager.Lib.WFM
{
    public class WfmAccount
    {
        public string email = "";
        public string password = "";
        [NonSerialized] public Profile profile;
        [NonSerialized] public string savePath = $"{Environment.CurrentDirectory}\\account data.json";

        public WfmAccount() {  }

        public WfmAccount(string email, string password)
        {
            LoadAccount(email, password, out string jwt);
        }

        public WfmAccount LoadFromFile()
        {
            if (!File.Exists(savePath))
            {
                SaveToFile();
                return this;
            }

            var account = Serializer.LoadFromFile<WfmAccount>(savePath);
            if (account is null)
                return this;

            email = account.email;
            password = account.password;
            return this;
        }

        public void SaveToFile()
        {
            Serializer.SaveToFile(this, savePath);
        }


        public bool LoadAccount() => LoadAccount(email, password, out string jwt);

        public bool LoadAccount(string email, string password, out string jwt)
        {
            bool success = Login(email, password, out jwt);

            if (success && profile is null)
                profile = LoadProfile();

            return success;
        }

        private bool Login() => Login(email, password, out string jwt);

        private bool Login(string email, string password, out string jwt)
        {
            jwt = "";

            var client = RestHandler.client;
            var request = RestHandler.InitializeRequest("auth/signin");
            var json = $"{{ \"email\":\"{email}\",\"password\":\"{password.Replace(@"\", @"\\")}\", \"auth_type\": \"header\"}}";
            request.AddJsonBody(json);
            var response = client.Post(request);

            if (response is null)
                return false;

            if (string.IsNullOrEmpty(MarketHandler.Instance.JWT))
            {
                bool success = SetJWT(response);
                jwt = (success) ? MarketHandler.Instance.JWT : "";
                if (!success)
                    return false;

                this.email = email;
                this.password = password;
                Logger.Log("Successfully logged into Warframe Market account.");
            }

            return true;
        }

        private Profile LoadProfile()
        {
            var profileResponse = RestHandler.Get("/profile");
            var profile = Profile_Config.FromJson(profileResponse).Profile;

            string msg = (profile is null) ? "Failed to get WFM profile. Try relaunching app." : "Successfully aquired WFM profile.";
            Logger.Log(msg);

            return profile;
        }

        private bool SetJWT(IRestResponse response)
        {
            var header = response.Headers.FirstOrDefault(h => h.Name == "Authorization");
            if (header is null)
            {
                Logger.Log("Authorization Failed. Failed to get JWT");
                return false;
            }

            var jwt = header.Value.ToString();
            MarketHandler.Instance.JWT = jwt.Replace("JWT", "").Trim();
            return true;
        }
    }
}