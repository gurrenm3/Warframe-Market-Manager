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
using Warframe_Market_Manager.Wpf.UserControls;
using Warframe_Market_Manager.Wpf.Extensions;
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
        private bool hasLoaded = false;
        private DebugLogUC debugUC = new DebugLogUC();
        private LoginUC loginUC = new LoginUC();
        private WelcomeUC welcomeUC = new WelcomeUC();

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

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (hasLoaded)
                return;

            new Main().OnFinishedLoading(new Main.MainEventArgs());
            hasLoaded = true;
        }

        private void Main_FinishedLoading(object sender, Main.MainEventArgs e)
        {
            Logger.Log("Warframe Market Manager has loaded");

            welcomeUC.Visibility = Visibility.Visible;
            ContentGrid.Children.Add(welcomeUC);

            debugUC.Visibility = Visibility.Hidden;
            ContentGrid.Children.Add(debugUC);

            loginUC.Visibility = Visibility.Hidden;
            ContentGrid.Children.Add(loginUC);

            TryLoginFromFileAsync();
        }

        private async Task TryLoginFromFileAsync()
        {
            var account = MarketManager.Instance.Account;
            account.TryLoginFromFile();
            if (account.isLoggedIn)
            {
                InGameName_TextBlock.Text = $"{account.InGameName}";
                return;
            }

            welcomeUC.LoginSection.Children.Add(new LoginUC());
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
            debugUC.Visibility = (debugUC.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            
            loginUC.Visibility = Visibility.Hidden;
            welcomeUC.Visibility = (debugUC.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            //welcomeUC.WelcomeMsg_TextBlock.Visibility = (debugUC.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            welcomeUC.Visibility = Visibility.Visible;
            loginUC.Visibility = (loginUC.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;

            debugUC.Visibility = Visibility.Hidden;
            //welcomeUC.WelcomeMsg_TextBlock.Visibility = (loginUC.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
        }

        private void UpdateOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            if (market.Account.isLoggedIn)
            {
                market.UpdateAllListings();
            }
            else
            {
                string msg = "You need to be logged in in order to update your orders";
                Logger.Log(msg);
                MessageBox.Show(msg);
            }
        }
    }
}