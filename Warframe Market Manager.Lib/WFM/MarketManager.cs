using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warframe_Market_Manager.Lib.Extensions;
using Warframe_Market_Manager.Lib.Web;
using Warframe_Market_Manager.Lib.WFM.QuickType;

namespace Warframe_Market_Manager.Lib.WFM
{
    public class MarketManager
    {
        public WfmAccount Account { get; set; } = new WfmAccount();

        public List<ItemOverview> ItemOverviews
        {
            get 
            {
                if (itemOverviews is null)
                    itemOverviews = AllItems_QuickType.FromJson(RestHelper.Get("items").Content).Payload.Items;
                return itemOverviews;
            }
            set { itemOverviews = value; }
        }
        private List<ItemOverview> itemOverviews;


        public static MarketManager Instance
        {
            get 
            {
                if (instance is null)
                    instance = new MarketManager();
                return instance;
            }
            set { instance = value; }
        }
        private static MarketManager instance;
        
        public void UpdateAllListings()
        {
            //Logger.Log("1");
            var myOrders = Account.profile.GetSellOrders();
            //return;
            //Logger.Log("5");
            foreach (var myOrder in myOrders)
            {
                var allSellOrders = myOrder.ItemOverview.GetAllSellOrders(OnlineStatus.Ingame);
                if (!allSellOrders.Any())
                    break;

                //Logger.Log("6");
                var topListing = allSellOrders[0];

                if (myOrder.Id != topListing.Id)
                    myOrder.ModifyOrder(cost: topListing.Platinum.Value);
            }
        }



        #region Events
        public static event EventHandler<MarketHandlerEvents> MarketItemData_Aquired;

        public class MarketHandlerEvents : EventArgs {  }

        public void OnMarketItemData_Aquired(MarketHandlerEvents e)
        {
            EventHandler<MarketHandlerEvents> handler = MarketItemData_Aquired;
            if (handler != null)
                handler(this, e);
        }
        #endregion
    }
}
