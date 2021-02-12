using RestSharp;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warframe_Market_Manager.Lib.Web;
using Warframe_Market_Manager.Lib.Extensions;
using Warframe_Market_Manager.Lib.WFM.QuickType;

namespace Warframe_Market_Manager.Lib.WFM
{
    public class WfmAccount
    {
        [NonSerialized] public AccountProfile profile;
        [NonSerialized] public string savePath = $"{Environment.CurrentDirectory}\\account data.json";
        public string Email { get; set; }
        public string Password { get; set; }
        public string Jwt { get; set; }
        public bool IsLoggedIn { get; set; }

        public WfmAccount() {  }

        public WfmAccount(string email, string password)
        {
            Login(email, password);
        }


        public void SaveAccountToFile() => Serializer.SaveToFile(this, savePath);
        public WfmAccount GetAccountFromFile()
        {
            if (!File.Exists(savePath))
            {
                SaveAccountToFile();
                return this;
            }

            var account = Serializer.LoadFromFile<WfmAccount>(savePath);
            if (account is null)
                return this;

            Email = account.Email;
            Password = account.Password;
            return this;
        }


        public async Task<bool> LoginAsync()
        {
            bool loadedAccount = false;
            await Task.Run(() => { loadedAccount = Login(Email, Password); });
            return loadedAccount;
        }
        public async Task<bool> LoginAsync(string email, string password)
        {
            bool loadedAccount = false;
            await Task.Run(() => { loadedAccount = Login(email, password); });
            return loadedAccount;
        }


        public bool Login() => Login(Email, Password);
        public bool Login(string email, string password)
        {
            var json = $"{{ \"email\":\"{email}\",\"password\":\"{password.Replace(@"\", @"\\")}\", \"auth_type\": \"header\"}}";
            var response = RestHelper.Post("auth/signin", jsonBody: json);

            if (IsLoggedIn)
                return true;

            bool success = SetJWT(response);
            if (!success)
                return false;

            Email = email;
            Password = password;

            if (profile is null)
                profile = LoadProfile();

            if (string.IsNullOrEmpty(profile?.IngameName))
            {
                Logger.Log($"Failed to login to user profile.");
                return false;
            }

            Logger.Log($"Welcome {profile?.IngameName}");
            IsLoggedIn = true;
            
            return true;
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
            Jwt = jwt.Replace("JWT", "").Trim();
            return true;
        }
        private AccountProfile LoadProfile()
        {
            var profileResponse = RestHelper.Get("/profile", requireAuth:true).Content;
            var profile = AccountProfile_QuickType.FromJson(profileResponse).AccountProfile;

            string msg = (profile is null) ? "Failed to get WFM profile. Try relaunching app." : "Successfully aquired WFM profile.";
            Logger.Log(msg);

            return profile;
        }


        public bool HasEmailAndPass() => !Email.IsNullOrEmpty() && !Password.IsNullOrEmpty();
        public bool HasJwt() => !string.IsNullOrEmpty(Jwt);
    }
}