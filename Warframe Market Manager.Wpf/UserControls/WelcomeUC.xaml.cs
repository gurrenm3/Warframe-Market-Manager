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
using Warframe_Market_Manager.Lib.WFM;

namespace Warframe_Market_Manager.Wpf.UserControls
{
    /// <summary>
    /// Interaction logic for WelcomeUC.xaml
    /// </summary>
    public partial class WelcomeUC : UserControl
    {
        public WelcomeUC()
        {
            InitializeComponent();
            Main.FinishedLoading += Main_FinishedLoading;
        }

        private void Main_FinishedLoading(object sender, Main.MainEventArgs e)
        {
            //TryLoginFromFile();
        }

        /*private async Task TryLoginFromFile()
        {
            var account = MarketManager.Instance.Account;
            await account.TryLoginFromFile();
            if (account.isLoggedIn)
            {
                WelcomeMsg_TextBlock.Text = $"Hello {account.InGameName}";
                return;
            }

            LoginSection.Children.Add(new LoginUC());
        }*/
    }
}
