using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Warframe_Market_Manager.Extensions
{
    public static class TabControlExt
    {
        public static TabItem GetTabItem(this TabControl tabControl, int index) => (TabItem)tabControl.Items[index];
    }
}
