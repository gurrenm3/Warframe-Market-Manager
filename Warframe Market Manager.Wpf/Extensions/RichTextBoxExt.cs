using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Warframe_Market_Manager.Extensions
{
    public static class RichTextBoxExt
    {
        public static string GetText(this RichTextBox rtb)
        {
            TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            return textRange.Text;
        }

        public static void SetText(this RichTextBox rtb, string text)
        {
            TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            textRange.Text = text;
        }

        public static bool IsEmpty(this RichTextBox rtb) => string.IsNullOrEmpty(rtb.GetText().Trim());
    }
}
