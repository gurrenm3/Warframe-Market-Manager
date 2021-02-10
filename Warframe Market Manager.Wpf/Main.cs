using System;
using Warframe_Market_Manager.Lib;
using Warframe_Market_Manager.Lib.WFM;
using Warframe_Market_Manager.Wpf.Windows;

namespace Warframe_Market_Manager.Wpf
{
    class Main
    {
        public static void RunOnUIThread(Action act)
        {
            MainWindow.instance.Dispatcher.Invoke(act);
        }

        public static void GetAccountData()
        {
            var account = MarketHandler.Instance.GetAccountData();

            if (account != null)
            {
                bool isAccountValid = account.LoadAccount(account.email, account.password, out string jwt);
                if (!isAccountValid)
                {
                    string msg = "The saved account data does not match an existing account. Please login again";
                    Logger.Log(msg);
                }

                new Main().OnFinishedLoading(new MainEventArgs());
            }
            else
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
            }
        }


        #region Events
        public static event EventHandler<MainEventArgs> FinishedLoading;

        public class MainEventArgs : EventArgs { }

        public void OnFinishedLoading(MainEventArgs e)
        {
            EventHandler<MainEventArgs> handler = FinishedLoading;
            if (handler != null)
                handler(this, e);
        }
        #endregion
    }
}
