using System;
using System.Threading.Tasks;
using Warframe_Market_Manager.Lib;
using Warframe_Market_Manager.Lib.WFM;

namespace Warframe_Market_Manager.Wpf
{
    class Main
    {
        public const int minutesBetweenOrderUpdates = 1;

        public static void RunOnUIThread(Action act)
        {
            MainWindow.instance.Dispatcher.Invoke(act);
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
