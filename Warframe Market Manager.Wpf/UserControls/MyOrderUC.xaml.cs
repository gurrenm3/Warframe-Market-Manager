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

namespace Warframe_Market_Manager.Wpf.UserControls
{
    /// <summary>
    /// Interaction logic for MyOrderUC.xaml
    /// </summary>
    public partial class MyOrderUC : UserControl
    {
        public string ItemName { get; set; }

        public MyOrderUC()
        {
            InitializeComponent();
        }

        public MyOrderUC(string itemName)
        {
            ItemName = itemName;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ItemNameTB.Text = ItemName;
        }
    }
}