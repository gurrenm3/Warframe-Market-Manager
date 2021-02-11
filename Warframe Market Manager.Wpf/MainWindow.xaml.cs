using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Warframe_Market_Manager.Lib;
using Warframe_Market_Manager.Lib.Extensions;
using Warframe_Market_Manager.Lib.Web;
using Warframe_Market_Manager.Lib.WFM;

namespace Warframe_Market_Manager.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow instance;
        private MarketHandler market;

        public MainWindow()
        {
            InitializeComponent();
            instance = this;

            Logger.MessageLogged += Logger_MessageLogged;
            
            market = MarketHandler.Instance;
            MarketHandler.MarketItemData_Aquired += MarketItemData_Aquired;
            Main.FinishedLoading += Main_FinishedLoading;
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Logger.Log("Warframe Market Manager has loaded");
            Main.GetAccountData();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void Logger_MessageLogged(object sender, Logger.LogEvents e)
        {
            Main.RunOnUIThread(() =>
            {
                ConsoleRTB.AppendText($"{e.Message}\n");
                ConsoleRTB.CaretPosition = ConsoleRTB.Document.ContentEnd;
            });
        }

        private void Main_FinishedLoading(object sender, Main.MainEventArgs e)
        {
            //GetMarketItems();
        }

        /*private void GetMarketItems()
        {
            Thread t = new Thread(() => 
            {
                var json = RestHandler.Get("items");
                market.ItemData = MarketItems_Config.FromJson(json);
                market.OnMarketItemData_Aquired(new MarketHandler.MarketHandlerEvents());
            });

            t.IsBackground = true;
            t.Start();
        }*/

        private void MarketItemData_Aquired(object sender, MarketHandler.MarketHandlerEvents e)
        {
            
        }

        private void ModifyOrders_Button_Click(object sender, RoutedEventArgs e)
        {
            market.UpdateAllListings();
        }
    }
}