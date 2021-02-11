using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warframe_Market_Manager.Lib.Web;
using Warframe_Market_Manager.Lib.WFM;

namespace Warframe_Market_Manager.Lib.Extensions
{
    public static class ProfileExt
    {
        public static List<Order> GetSellOrders(this Profile profile)
        {
            string json = RestHelper.Get($"profile/{profile.IngameName}/orders", requireAuth:true).Content.Replace("\\","/");
            var orderConfig = ProfileOrdersConfig.FromJson(json);

            return orderConfig.Payload.SellOrders.ToList();
        }

        public static List<Order> GetBuyOrders(this Profile profile)
        {
            string json = RestHelper.Get($"profile/{profile.IngameName}/orders", requireAuth: true).Content.Replace("\\", "/");
            var orderConfig = ProfileOrdersConfig.FromJson(json);

            return orderConfig.Payload.BuyOrders.ToList();
        }
    }
}
