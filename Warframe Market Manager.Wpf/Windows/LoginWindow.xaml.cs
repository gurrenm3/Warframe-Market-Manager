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
using System.Windows.Shapes;
using Warframe_Market_Manager.Lib;
using Warframe_Market_Manager.Lib.WFM;
using Warframe_Market_Manager.Wpf.Extensions;

namespace Warframe_Market_Manager.Wpf.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (!AreInputsValid())
                return;

            string email = EmailRTB.GetContent().Trim();
            string password = PasswordRTB.GetContent().Trim();
            
            var success = MarketManager.Instance.Account.LoginAsync(email, password);
            if (!success.Result)
            {
                string msg = "Email or Password was not correct. Please try again";
                Logger.Log(msg);
                MessageBox.Show(msg);
            }
            else
            {
                MarketManager.Instance.Account.SaveAccountToFile();
                this.Close();
            }
        }

        private bool AreInputsValid()
        {
            if (EmailRTB.IsEmpty() || PasswordRTB.IsEmpty())
            {
                string msg = "Email or Password was not entered";
                Logger.Log(msg);
                MessageBox.Show(msg);
                return false;
            }

            return true;
        }
    }
}
