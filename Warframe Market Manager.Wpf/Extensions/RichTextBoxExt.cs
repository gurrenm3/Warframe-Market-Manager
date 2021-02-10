using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Warframe_Market_Manager.Wpf.Extensions
{
    public static class RichTextBoxExt
    {
        public static string GetContent(this RichTextBox rtb)
        {
            TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            return textRange.Text;
        }

        public static bool IsEmpty(this RichTextBox rtb) => string.IsNullOrEmpty(rtb.GetContent().Trim());
    }
}
