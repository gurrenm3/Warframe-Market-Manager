using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Warframe_Market_Manager.Lib;
using Warframe_Market_Manager.Lib.WFM;
using Warframe_Market_Manager.Extensions;

namespace Warframe_Market_Manager.Wpf.UserControls
{
    /// <summary>
    /// Interaction logic for OrdersAndMins.xaml
    /// </summary>
    public partial class OrdersAndMins : UserControl
    {
        public OrdersAndMins()
        {
            InitializeComponent();
            SetMinPrice_Grid.Visibility = Visibility.Hidden;
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ResizeOrderList();
            ResizeModifyPriceUC();
        }

        private void ResizeModifyPriceUC()
        {
            /*var uc = MinPriceUC;
            uc.Width = ModifyOrderGrid.ActualWidth;
            uc.Height = ModifyOrderGrid.ActualHeight;*/

        }

        private void ResizeOrderList()
        {
            if (MyOrderList.Items.Count == 0)
                return;

            for (int i = 0; i < MyOrderList.Items.Count; i++)
            {
                var listBoxItem = (ListBoxItem)MyOrderList.Items[i];

                int topMargin = (i == 0) ? 3 : 0;
                listBoxItem.Margin = new Thickness(3, topMargin, 5, 0);
                listBoxItem.Width = MyOrderList.ActualWidth;
            }

            var items = MyOrderList.Items;
            var lastItem = (ListBoxItem)items[items.Count - 1];
            var margin = lastItem.Margin;

            lastItem.Margin = new Thickness(margin.Left, margin.Top, margin.Right, 3);
        }


        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (Visibility != Visibility.Visible)
                return;

            MainWindow.instance.welcomeUC.Visibility = Visibility.Hidden;
            PopulateMyOrders();
        }

        public void PopulateMyOrders()
        {
            if (Visibility != Visibility.Visible)
                return;

            MyOrderList.Items.Clear();
            var orders = MarketManager.Instance.Account.profile.GetMyOrders(OrderType.Sell);
            foreach (var order in orders)
            {
                var itemName = order.ItemOverview.EnglishDescription.ItemName;
                if (HasOrderInList(itemName))
                    continue;

                AddOrderToList(itemName);
            }

            var items = MyOrderList.Items;
            if (items.Count == 0)
                return;

            var listBoxItem = (ListBoxItem)items[items.Count - 1];
            var margin = listBoxItem.Margin;

            listBoxItem.Margin = new Thickness(margin.Left, margin.Top, margin.Right, 3);
        }

        public void AddOrderToList(string itemName)
        {
            var listBoxItem = CreateOrderListboxItem(itemName);
            MyOrderList.Items.Add(listBoxItem);
        }

        private ListBoxItem CreateOrderListboxItem(string itemName)
        {
            ListBoxItem listBoxItem = new ListBoxItem();

            listBoxItem.Content = itemName;
            listBoxItem.HorizontalContentAlignment = HorizontalAlignment.Center;
            listBoxItem.FontSize = 24;
            listBoxItem.Foreground = Brushes.White;
            listBoxItem.Width = MyOrderList.ActualWidth;

            int topMargin = (MyOrderList.Items.Count == 0) ? 3 : 0;
            listBoxItem.Margin = new Thickness(3, topMargin, 5, 0);

            byte colorNum = 58;
            if (MyOrderList.Items.Count % 2 == 0)
                colorNum = 64;

            listBoxItem.Background = new SolidColorBrush(Color.FromRgb(colorNum, colorNum, colorNum));
            return listBoxItem;
        }

        private bool HasOrderInList(string itemName)
        {
            var hasItem = MyOrderList.Items.HasItem(item => ((ListBoxItem)item).Content.ToString() == itemName);
            return hasItem;
        }

        private void MyOrderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = MyOrderList.SelectedIndex;
            if (index < 0)
                return;

            SelectOrder(index);
        }

        public void SelectOrder(int index)
        {
            var previousText = ItemNameTB.Text;
            var selectedItemText = ((ListBoxItem)MyOrderList.SelectedItem).Content.ToString();
            if (previousText != selectedItemText)
                ItemNameTB.Text = selectedItemText;

            SetMinPriceTB.SetText("");

            var listboxItem = (ListBoxItem)MyOrderList.Items[index];
            DisplayOrderInfo(listboxItem.Content.ToString());
        }

        private void DisplayOrderInfo(string itemName)
        {
            SetMinPrice_Grid.Visibility = Visibility.Visible;

            var manager = MarketManager.Instance.GetMinPriceForItem(itemName);
            if (manager.MinPrice.HasValue)
                SetMinPriceTB.SetText(manager.MinPrice.ToString());
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            var newMinPrice = SetMinPriceTB.GetText();
            var success = Int32.TryParse(newMinPrice, out int result);
            if (!success)
            {
                string msg = "Error! You can only enter numbers for the minimum price!";
                MessageBox.Show(msg);
                Logger.Log(msg);
                return;
            }

            SetMinPriceForItem(ItemNameTB.Text, result);
            SetMinPrice_Grid.Visibility = Visibility.Hidden;
            MyOrderList.SelectedIndex = -1;
            ItemNameTB.Text = "Select Order to Modify";
            SetMinPriceTB.SetText("");
        }

        private void SetMinPriceForItem(string itemName, int minPrice)
        {
            var manager = MarketManager.Instance.GetMinPriceForItem(itemName);
            manager.MinPrice = minPrice;

            if (manager.ItemName != itemName)
                manager.ItemName = itemName;

            manager.SaveToFile();   
        }

        private void RefreshOrders_Button_Click(object sender, RoutedEventArgs e)
        {
            PopulateMyOrders();
        }
    }
}