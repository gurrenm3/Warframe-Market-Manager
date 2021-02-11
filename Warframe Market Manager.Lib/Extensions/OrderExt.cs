using System.Collections.Generic;
using System.Linq;
using Warframe_Market_Manager.Lib.Web;
using Warframe_Market_Manager.Lib.WFM;

namespace Warframe_Market_Manager.Lib.Extensions
{
    public static class OrderExt
    {
        public static void ModifyOrder(this Order order, long cost) => order.ModifyOrder(cost, order.Quantity, order.Visible);
        public static void ModifyOrder(this Order order, long cost, long quantity, bool isVisible)
        {
            string jsonBody = $"{{\"order_id\":\"{order.Id}\",\"platinum\":{cost},\"quantity\":{quantity}}}";

            var response = RestHelper.Put($"profile/orders/{order.Id}", jsonBody: jsonBody, requireAuth:true);

            Logger.Log($"{response.StatusCode}");
        }

        public static List<Order> GetSellOrders(this Order[] orders, Status onlineStatus)
        {
            var sellOrders = orders.Where(order => order.OrderType == OrderType.Sell && order.User.Status == onlineStatus);
            return sellOrders.OrderBy(item => item.Platinum).ToList();
        }

        public static List<Order> GetBuyOrders(this Order[] orders, Status onlineStatus)
        {
            var sellOrders = orders.Where(order => order.OrderType == OrderType.Buy && order.User.Status == onlineStatus);
            return sellOrders.OrderByDescending(item => item.Platinum).ToList();
        }
    }
}