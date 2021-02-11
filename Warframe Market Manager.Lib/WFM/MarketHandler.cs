using System;
using System.Collections.Generic;
using System.Linq;
using Warframe_Market_Manager.Lib.Extensions;
using Warframe_Market_Manager.Lib.Web;

namespace Warframe_Market_Manager.Lib.WFM
{
    public class MarketHandler
    {
        public string JWT;
        public WfmAccount account = new WfmAccount();

        public List<MarketItem> Items
        {
            get 
            {
                if (items is null)
                    items = MarketItems_Config.FromJson(RestHelper.Get("items").Content).Payload.MarketItems.ToList();
                return items;
            }
            set { items = value; }
        }
        private List<MarketItem> items;


        public static MarketHandler Instance
        {
            get 
            {
                if (instance is null)
                    instance = new MarketHandler();
                return instance;
            }
            set { instance = value; }
        }
        private static MarketHandler instance;
        
        public void UpdateAllListings()
        {
            var myOrders = account.profile.GetSellOrders();
            foreach (var myOrder in myOrders)
            {
                var allSellOrders = myOrder.MarketItem.GetAllSellOrders(Status.Ingame);
                var topListing = allSellOrders[1];

                if (myOrder.Id != topListing.Id)
                    myOrder.ModifyOrder(cost: topListing.Platinum);
            }
        }


        public WfmAccount GetAccountData()
        {
            account.LoadFromFile();
            return (IsAccountDataValid()) ? account : null;
        }

        private bool IsAccountDataValid()
        {
            var isAnyDataEmpty = string.IsNullOrEmpty(account.email) || string.IsNullOrEmpty(account.password);
            return !isAnyDataEmpty;
        }

        public bool IsJWTValid() => !string.IsNullOrEmpty(JWT);

        public ItemInfo GetItemInfoFromName(string itemName)
        {
            itemName = itemName.ToLower().Replace(" ", "_");
            ItemInfo item = new ItemInfo();

            item.ItemData = Items.FirstOrDefault(i => i.UrlName == itemName);
            return ProcessItemData(item, itemName);
        }
        
        public ItemInfo GetItemInfoFromID(string id)
        {
            ItemInfo item = new ItemInfo();

            item.ItemData = Items.FirstOrDefault(i => i.Id == id);
            Logger.Log(item.ItemData is null);
            return ProcessItemData(item, id);
        }

        private ItemInfo ProcessItemData(ItemInfo item, string itemName)
        {
            if (item.ItemData == null)
            {
                Logger.Log($"Failed to get market info for {itemName}");
            }
            else
            {
                string json = RestHelper.Get($"items/{item.ItemData.UrlName}/orders").Content;
                var orderData = MarketOrder_Config.FromJson(json);
                item.SetOrderData(orderData.Payload.Orders);
            }

            return item;
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
