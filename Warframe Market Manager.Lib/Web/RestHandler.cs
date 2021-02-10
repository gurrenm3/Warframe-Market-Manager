using RestSharp;
using Warframe_Market_Manager.Lib.WFM;

namespace Warframe_Market_Manager.Lib.Web
{
    public class RestHandler
    {
        public const string rootApi = "https://api.warframe.market/v1/";
        public static RestClient client = new RestClient(rootApi);
        private static RestRequest request;

        public static RestRequest InitializeRequest(string requestPath)
        {
            var request = new RestRequest(requestPath);

            request.AddHeader("Authorization", $"JWT {MarketHandler.Instance.JWT}");
            request.AddHeader("language", "en");
            request.AddHeader("accept", "application/json");
            request.AddHeader("platform", "pc");
            request.AddHeader("auth_type", "header");

            return request;
        }


        private static bool IsAuthValid(bool requireAuth)
        {
            if (requireAuth && !MarketHandler.Instance.IsJWTValid())
            {
                string email = MarketHandler.Instance.account.email;
                string password = MarketHandler.Instance.account.password;
                MarketHandler.Instance.account.LoadAccount(email, password, out string jwt);
                
                if (string.IsNullOrEmpty(jwt))
                {
                    Logger.Log("Authorization Failed. Failed to get JWT");
                    return false;
                }
            }

            return true;
        }

        public static string Post(string requestPath, bool requireAuth = false)
        {
            if (!IsAuthValid(requireAuth))
                return null;

            request = InitializeRequest($"{rootApi}/{requestPath}");
            var response = client.Post(request);
            return response.Content;
        }

        public static string Get(string requestPath, bool requireAuth = false)
        {
            if (!IsAuthValid(requireAuth))
                return null;

            request = InitializeRequest($"{rootApi}/{requestPath}");
            var response = client.Get(request);
            return response.Content;
        }
    }
}
