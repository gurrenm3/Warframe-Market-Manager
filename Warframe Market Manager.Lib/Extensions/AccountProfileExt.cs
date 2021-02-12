using System.Collections.Generic;
using Warframe_Market_Manager.Lib.Web;
using Warframe_Market_Manager.Lib.WFM;
using Warframe_Market_Manager.Lib.WFM.QuickType;

namespace Warframe_Market_Manager.Lib.Extensions
{
    public static class AccountProfileExt
    {
        public static List<Order> GetSellOrders(this AccountProfile profile)
        {
            //Logger.Log("2");
            string json = RestHelper.Get($"profile/{profile.IngameName}/orders", requireAuth:true).Content.Replace("\\","/");
            //Logger.Log(json);

            //return new List<Order>();
            //Logger.Log("3");
            var orderConfig = ProfileOrders_QuickType.FromJson(json);
            //Logger.Log("4");
            return orderConfig.Payload.SellOrders;
        }

        public static List<Order> GetBuyOrders(this AccountProfile profile)
        {
            string json = RestHelper.Get($"profile/{profile.IngameName}/orders", requireAuth: true).Content.Replace("\\", "/");
            var orderConfig = ProfileOrders_QuickType.FromJson(json);

            return orderConfig.Payload.BuyOrders;
        }
    }
}
