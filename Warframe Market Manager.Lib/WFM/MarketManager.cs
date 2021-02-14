using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warframe_Market_Manager.Extensions;
using Warframe_Market_Manager.Lib.Web;
using Warframe_Market_Manager.Lib.WFM.QuickType;

namespace Warframe_Market_Manager.Lib.WFM
{
    public class MarketManager
    {
        public WfmAccount Account { get; set; } = new WfmAccount();
        public bool IsUpdatingOrders { get; set; }

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


        public async Task UpdateAllListingsAsync() => await Task.Run(() => { UpdateAllListings(); });

        public void UpdateAllListings()
        {
            if (IsUpdatingOrders)
            {
                Logger.Log("You are already updating orders. Please wait for it to finish");
                return;
            }

            var myOrders = Account.profile.GetMyOrders(OrderType.Sell);
            if (myOrders.Count == 0)
                return;

            IsUpdatingOrders = true;
            foreach (var myOrder in myOrders)
            {
                var manager = GetMinPriceForItem(myOrder.ItemOverview.EnglishDescription.ItemName);
                if (!manager.MinPrice.HasValue)
                {
                    Logger.Log($"Error! You didn't set a minimum price for {myOrder.ItemOverview.EnglishDescription.ItemName}. Will not " +
                        $"use MinPrice for this item");
                    //continue;
                }

                var allSellOrders = myOrder.ItemOverview.GetAllSellOrders(OnlineStatus.Ingame);
                if (!allSellOrders.Any())
                    break;

                long minPrice = (manager.MinPrice.HasValue) ? manager.MinPrice.Value : 0;
                var topListing = allSellOrders[0];

                if (myOrder.Id != topListing.Id)
                {
                    if (topListing.Platinum >= minPrice)
                        myOrder.ModifyOrder(cost: topListing.Platinum.Value);
                    else if (allSellOrders[1].Platinum >= minPrice)
                        myOrder.ModifyOrder(cost: allSellOrders[1].Platinum.Value);
                    else if (allSellOrders[2].Platinum >= minPrice)
                        myOrder.ModifyOrder(cost: allSellOrders[2].Platinum.Value);
                    else
                    {
                        Logger.Log($"Couldn't set price for {myOrder.ItemOverview.EnglishDescription.ItemName} because" +
                            $" first 3 cheapest orders were below minimum");
                        if (myOrder.Platinum != minPrice)
                            myOrder.ModifyOrder(minPrice);
                        continue;
                    }
                }
                else
                {
                    var secondListing = allSellOrders[1];
                    if (secondListing.Platinum >= minPrice)
                        myOrder.ModifyOrder(cost: secondListing.Platinum.Value);
                    else if (allSellOrders[2].Platinum >= minPrice)
                        myOrder.ModifyOrder(cost: allSellOrders[2].Platinum.Value);
                    else if (allSellOrders[3].Platinum >= minPrice)
                        myOrder.ModifyOrder(cost: allSellOrders[3].Platinum.Value);
                    else
                    {
                        Logger.Log($"Couldn't set price for {myOrder.ItemOverview.EnglishDescription.ItemName} because" +
                            $" first 3 cheapest orders were below minimum");
                        if (myOrder.Platinum != minPrice)
                            myOrder.ModifyOrder(minPrice);
                        continue;
                    }
                }
            }

            UserData.Instance.LastOrderUpdate = DateTime.Now;
            IsUpdatingOrders = false;
            Logger.Log("Finished updating orders.");
        }


        public MinPriceManager GetMinPriceForItem(string itemName)
        {
            var minPriceMgr = MinPriceManager.LoadFromFile(itemName);
            return minPriceMgr;
        }

        /*public void SetMinPriceForItem(string itemName, long minPrice)
        {
            var minPriceMgr = MinPriceManager.LoadFromFile(itemName);
            if (!minPriceMgr.MinPrice.HasValue)
                return null;

            return minPriceMgr.MinPrice.Value;
        }*/



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
