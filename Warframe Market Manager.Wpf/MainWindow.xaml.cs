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
using Warframe_Market_Manager.Lib.Web;
using Warframe_Market_Manager.Lib.WFM;
using Warframe_Market_Manager.Wpf.UserControls;
using Warframe_Market_Manager.Extensions;
using System.Diagnostics;

namespace Warframe_Market_Manager.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow instance;
        private MarketManager market;
        public DebugLogUC debugUC = new DebugLogUC();
        public LoginUC loginUC = new LoginUC();
        public WelcomeUC welcomeUC = new WelcomeUC();
        public OrdersAndMins ordersAndMinsUC = new OrdersAndMins();

        public MainWindow()
        {
            InitializeComponent();
            instance = this;

            Logger.MessageLogged += Logger_MessageLogged;

            market = MarketManager.Instance;
            Main.FinishedLoading += Main_FinishedLoading;
        }

        private void Window_Closed(object sender, EventArgs e) => Application.Current.Shutdown();

        private void Logger_MessageLogged(object sender, Logger.LogEvents e)
        {
            Main.RunOnUIThread(() =>
            {
                debugUC.OutputConsole.AppendText($">> {e.Message}\n");
                debugUC.OutputConsole.CaretPosition = debugUC.OutputConsole.Document.ContentEnd;
            });
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            new Main().OnFinishedLoading(new Main.MainEventArgs());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void DiscordButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://discord.gg/M7BHnPS");
        }

        private void GithubButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/gurrenm3/Warframe-Market-Manager");
        }

        private void DonateButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.buymeacoffee.com/toms.tutorials");
        }

        private void DebugButton_Click(object sender, RoutedEventArgs e)
        {
            ShowHideDebugScreen();
        }

        private void ShowHideDebugScreen()
        {
            var debugVisibility = (debugUC.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            debugUC.Visibility = debugVisibility;
            loginUC.Visibility = Visibility.Hidden;
            welcomeUC.Visibility = Visibility.Hidden;

            ordersAndMinsUC.Visibility = (debugUC.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            ShowHideLoginScreen();
        }

        public void ShowHideLoginScreen()
        {
            var loginVisibility = (loginUC.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            welcomeUC.Visibility = loginVisibility;
            loginUC.Visibility = loginVisibility;
            debugUC.Visibility = Visibility.Hidden;

            if (market.Account.profile != null)
                ordersAndMinsUC.Visibility = (loginUC.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
        }

        private void Main_FinishedLoading(object sender, Main.MainEventArgs e)
        {
            Logger.Log("Warframe Market Manager has loaded");            

            debugUC.Visibility = Visibility.Collapsed;
            ContentGrid.Children.Add(debugUC);

            loginUC.Visibility = Visibility.Hidden;
            welcomeUC.LoginSection.Children.Add(loginUC);

            ordersAndMinsUC.Visibility = Visibility.Collapsed;
            ContentGrid.Children.Add(ordersAndMinsUC);

            welcomeUC.Visibility = Visibility.Visible;
            ContentGrid.Children.Add(welcomeUC);

            TryLoginFromFile();
        }

        private void TryLoginFromFile()
        {
            var account = MarketManager.Instance.Account;
            var success = account.TryLoginFromFile();
            LoadingTextBlock.Visibility = Visibility.Hidden;

            if (!success)
            {
                ShowHideLoginScreen();
                return;
            }

            if (account.isLoggedIn)
            {
                InGameName_TextBlock.Text = $"{account.InGameName}";
                ordersAndMinsUC.Visibility = Visibility.Visible;

                return;
            }
        }

        private async void UpdateOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            var lastTime = UserData.Instance.LastOrderUpdate;
            var tempTime = lastTime.Minute + Main.minutesBetweenOrderUpdates;
            

            

            /*if (DateTime.Compare(DateTime.Now, tempTime) < 0)
                return;*/

            var market = MarketManager.Instance;
            if (market.Account.isLoggedIn)
            {
                await market.UpdateAllListingsAsync();
                StartTimer();
            }
            else
            {
                string msg = "You need to be logged in in order to update your orders";
                Logger.Log(msg);
                MessageBox.Show(msg);
            }
        }

        private void StartTimer()
        {
            Thread t = new Thread(() =>
            {
                var timeToReset = Main.minutesBetweenOrderUpdates * 60;
                int counter = timeToReset;
                for (int i = 0; i < timeToReset; i++)
                {
                    Main.RunOnUIThread(() =>
                    {
                        (MainWindow.instance.UpdateOrdersButton.Content = timeToReset).ToString();
                    });

                    Thread.Sleep(1000);
                    counter--;
                    Main.RunOnUIThread(() =>
                    {
                        (MainWindow.instance.UpdateOrdersButton.Content = timeToReset).ToString();
                    });
                }
            });
            t.IsBackground = true;
        }
    }
}