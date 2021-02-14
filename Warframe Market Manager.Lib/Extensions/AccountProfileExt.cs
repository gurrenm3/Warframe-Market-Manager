using System.Collections.Generic;
using Warframe_Market_Manager.Lib.Web;
using Warframe_Market_Manager.Lib.WFM;
using Warframe_Market_Manager.Lib.WFM.QuickType;

namespace Warframe_Market_Manager.Extensions
{
    public static class AccountProfileExt
    {
        public static List<Order> GetMyOrders(this AccountProfile profile, OrderType orderType)
        {
            string json = RestHelper.Get($"profile/{MarketManager.Instance.Account.InGameName}/orders", requireAuth: true).Content.Replace("\\", "/");
            var orderConfig = ProfileOrders_QuickType.FromJson(json);
            return (orderType == OrderType.Buy) ? orderConfig.Payload.BuyOrders : orderConfig.Payload.SellOrders;
        }

        /*public static List<Order> GetSellOrders(this AccountProfile profile)
        {
            string json = RestHelper.Get($"profile/{MarketManager.Instance.Account.InGameName}/orders", requireAuth:true).Content.Replace("\\","/");
            var orderConfig = ProfileOrders_QuickType.FromJson(json);
            return orderConfig.Payload.SellOrders;
        }

        public static List<Order> GetBuyOrders(this AccountProfile profile)
        {
            string json = RestHelper.Get($"profile/{profile.IngameName}/orders", requireAuth: true).Content.Replace("\\", "/");
            var orderConfig = ProfileOrders_QuickType.FromJson(json);

            return orderConfig.Payload.BuyOrders;
        }*/
    }
}
