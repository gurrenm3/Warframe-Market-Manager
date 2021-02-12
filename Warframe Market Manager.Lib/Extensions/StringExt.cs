using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warframe_Market_Manager.Lib.Extensions
{
    public static class StringExt
    {
        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);
    }
}
