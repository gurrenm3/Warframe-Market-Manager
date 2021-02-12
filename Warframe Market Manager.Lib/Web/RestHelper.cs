using RestSharp;
using System.Threading.Tasks;
using Warframe_Market_Manager.Lib.WFM;

namespace Warframe_Market_Manager.Lib.Web
{
    public class RestHelper
    {
        public const string rootApi = "https://api.warframe.market/v1/";
        public static RestClient client = new RestClient(rootApi);
        private static RestRequest request;

        public static RestRequest InitializeRequest(string requestPath)
        {
            var request = new RestRequest(requestPath);

            request.AddHeader("Authorization", $"JWT {MarketManager.Instance.Account.Jwt}");
            request.AddHeader("language", "en");
            request.AddHeader("accept", "application/json");
            request.AddHeader("platform", "pc");
            request.AddHeader("auth_type", "header");
            
            return request;
        }

        private static bool IsAuthValid(bool requireAuth)
        {
            if (requireAuth && !MarketManager.Instance.Account.HasJwt())
            {
                string email = MarketManager.Instance.Account.Email;
                string password = MarketManager.Instance.Account.Password;
                var accounnt = MarketManager.Instance.Account;
                
                accounnt.Login(email, password);
                
                if (string.IsNullOrEmpty(accounnt.Jwt))
                {
                    Logger.Log("Authorization Failed. Failed to get JWT");
                    return false;
                }
            }

            return true;
        }

        public static IRestResponse Get(string requestPath, string jsonBody = "", bool requireAuth = false)
        {
            return GenericRequest(RequestType.Get, requestPath, jsonBody, requireAuth);
        }
        public static async Task<IRestResponse> GetAsync(string requestPath, string jsonBody = "", bool requireAuth = false)
        {
            IRestResponse response = null;
            await Task.Run(() => { response = Get(requestPath, jsonBody, requireAuth); });

            return response;
        }

        public static IRestResponse Post(string requestPath, string jsonBody = "", bool requireAuth = false)
        {
            return GenericRequest(RequestType.Post, requestPath, jsonBody, requireAuth);
        }
        public static async Task<IRestResponse> PostAsync(string requestPath, string jsonBody = "", bool requireAuth = false)
        {
            IRestResponse response = null;
            await Task.Run(() => { response = Post(requestPath, jsonBody, requireAuth); });

            return response;
        }

        public static IRestResponse Put(string requestPath, string jsonBody = "", bool requireAuth = false)
        {
            return GenericRequest(RequestType.Put, requestPath, jsonBody, requireAuth);
        }
        public static async Task<IRestResponse> PutAsync(string requestPath, string jsonBody = "", bool requireAuth = false)
        {
            IRestResponse response = null;
            await Task.Run(() => { response = Put(requestPath, jsonBody, requireAuth); });

            return response;
        }



        enum RequestType
        {
            Get,
            Post,
            Put
        }

        private static IRestResponse GenericRequest(RequestType requestType, string requestPath, string jsonBody = "", bool requireAuth = false)
        {
            if (!IsAuthValid(requireAuth))
                return null;

            request = InitializeRequest($"{rootApi}/{requestPath}");

            if (!string.IsNullOrEmpty(jsonBody))
                request.AddJsonBody(jsonBody);

            IRestResponse response = null;

            switch (requestType)
            {
                case RequestType.Get:
                    response = client.Get(request);
                    break;
                case RequestType.Post:
                    response = client.Post(request);
                    break;
                case RequestType.Put:
                    client.Execute(request);
                    response = client.Put(request);
                    break;
                default:
                    break;
            }

            return response;
        }
    }
}
