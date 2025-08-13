using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Domain.Utilitis
{
    public static class TextHelper
    {
        //Slug Validation
        public static string ToSlug(this string Text)
        {
            return Text.Trim().ToLower()
                .Replace(" ", "-")
                .Replace("+", "")
                .Replace("_", "")
                .Replace(")", "")
                .Replace("(", "")
                .Replace("*", "")
                .Replace("&", "")
                .Replace("^", "")
                .Replace("%", "")
                .Replace("$", "")
                .Replace("#", "")
                .Replace("@", "");
        }
        //ConvertHtmlToText
        public static string ConvertHtmlToText(this string text)
        {
            return Regex.Replace(text, "<.*?>", " ")
                .Replace(":&nbsp;", " ");
        }
    }
}
