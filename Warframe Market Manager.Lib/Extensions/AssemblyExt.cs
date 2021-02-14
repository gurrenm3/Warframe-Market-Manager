using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Warframe_Market_Manager.Extensions
{
    public static class AssemblyExt
    {
        public static string GetDirectory(this Assembly assembly)
        {
            return new FileInfo(assembly.Location).Directory.FullName;
        }
    }
}
