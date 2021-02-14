using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Warframe_Market_Manager.Extensions
{
    public static class ItemCollectionExt
    {
        public static object FirstOrDefault(this ItemCollection source, Func<object, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                    return item;
            }
            return default;
        }

        public static bool HasItem(this ItemCollection source, Func<object, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                    return true;
            }
            return false;
        }
    }
}
