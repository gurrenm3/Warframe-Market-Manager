using System.Collections.Generic;
using System.Linq;
using Warframe_Market_Manager.Lib.Web;
using Warframe_Market_Manager.Lib.WFM;

namespace Warframe_Market_Manager.Lib.Extensions
{
    public static class OrderExt
    {
        public static void ModifyOrder(this Order order, long cost) => order.ModifyOrder(cost, order.Quantity.Value, order.Visible.Value);
        public static void ModifyOrder(this Order order, long cost, long quantity, bool isVisible)
        {
            //Logger.Log("7");
            string jsonBody = $"{{\"order_id\":\"{order.Id}\",\"platinum\":{cost},\"quantity\":{quantity}}}";
            var response = RestHelper.Put($"profile/orders/{order.Id}", jsonBody: jsonBody, requireAuth:true);

            //Logger.Log("8");
            Logger.Log($"{response.StatusCode}");
        }

        public static List<Order> GetOrdersOfType(this List<Order> orders, OrderType orderType, OnlineStatus onlineStatus = OnlineStatus.Ingame)
        {
            var goodOrders = orders.Where(order => order.OrderType == orderType && order.User.OnlineStatus == onlineStatus && order.Region == "en");
            //goodOrders = goodOrders.Where(order => order.User.OnlineStatus == OnlineStatus.Ingame);

            if (orderType == OrderType.Sell)
                return goodOrders.OrderBy(item => item.Platinum).ToList();
            else
                return goodOrders.OrderByDescending(item => item.Platinum).ToList();
        }
    }
}