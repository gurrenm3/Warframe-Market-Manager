using System;
using System.Linq;
using Warframe_Market_Manager.Lib.Web;

namespace Warframe_Market_Manager.Lib.WFM
{
    public class MarketHandler
    {
        public string JWT;
        public WfmAccount account = new WfmAccount();
        public MarketItems_Config itemData;

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

        public ItemInfo GetItemInfo(string itemName)
        {
            itemName = itemName.ToLower().Replace(" ", "_");
            ItemInfo item = new ItemInfo();

            item.ItemData = itemData.Payload.Items.FirstOrDefault(i => i.UrlName == itemName);
            if (item.ItemData == null)
            {
                Logger.Log($"Failed to get market info for {itemName}");
            }
            else
            {
                string json = RestHandler.Get($"items/{item.ItemData.UrlName}/orders");
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
