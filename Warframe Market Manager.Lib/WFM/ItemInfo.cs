using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warframe_Market_Manager.Lib.WFM
{
    public class ItemInfo
    {
        public MarketItem ItemData { get; set; }

        public List<Order> SellOrders { get; set; } = new List<Order>();
        public List<Order> BuyOrders { get; set; } = new List<Order>();

        public void SetOrderData(Order[] allOrders)
        {
            foreach (var order in allOrders)
            {
                if (order.OrderType == OrderType.Sell)
                    SellOrders.Add(order);
                else
                    BuyOrders.Add(order);
            }

            SellOrders = SellOrders.OrderBy(item => item.Platinum).ToList();
            BuyOrders = BuyOrders.OrderByDescending(item => item.Platinum).ToList();
        }
    }
}
