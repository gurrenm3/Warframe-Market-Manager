using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warframe_Market_Manager.Lib.Web;
using Warframe_Market_Manager.Lib.WFM;
using Warframe_Market_Manager.Lib.Extensions;

namespace Warframe_Market_Manager.Lib.Extensions
{
    public static class MarketItemExt
    {

        public static List<Order> GetAllSellOrders(this MarketItem marketItem, Status onlineStatus)
        {
            var response = RestHelper.Get($"items/{marketItem.UrlName}/orders");
            var config = MarketOrder_Config.FromJson(response.Content);

            var orders = config.Payload.Orders.GetSellOrders(onlineStatus);
            return orders;
        }
    }
}
