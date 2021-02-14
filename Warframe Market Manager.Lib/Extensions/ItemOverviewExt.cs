using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warframe_Market_Manager.Lib.Web;
using Warframe_Market_Manager.Lib.WFM;
using Warframe_Market_Manager.Extensions;
using Warframe_Market_Manager.Lib.WFM.QuickType;

namespace Warframe_Market_Manager.Extensions
{
    public static class ItemOverviewExt
    {
        public static List<Order> GetAllSellOrders(this ItemOverview marketItem, OnlineStatus onlineStatus)
        {
            var response = RestHelper.Get($"items/{marketItem.UrlName}/orders");
            var config = ItemOrders_QuickType.FromJson(response.Content);

            var orders = config.Payload.Orders.GetOrdersOfType(OrderType.Sell, onlineStatus);
            return orders;
        }
    }
}