using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Logic.Helpers
{
    public class StringFormattingHelpers
    {
        
        public static string FormatBibleChapter(string text) 
        {
            text = text.Trim();
            text = text.Replace("\n", "<br />");
            text = System.Text.RegularExpressions.Regex.Replace(text, @"(<br\s*\/?>\s*){2,}", "<br>");
            text = System.Text.RegularExpressions.Regex.Replace(text, @"(\d+)<br\s*\/?>", "$1");
			text = System.Text.RegularExpressions.Regex.Replace(text, @"(\d+)", "<i><b>$1</b></i>");
			//text = System.Text.RegularExpressions.Regex.Replace(text, @"(\d+)", " $1 ");

			return text;
        }
    }
}
