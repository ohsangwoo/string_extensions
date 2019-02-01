using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringExtensions
{
    public static class StringPatternExtension
    {
        private static readonly Regex TokensRegex = new Regex(@"\\\{(\w+)\}", RegexOptions.Compiled);

        public static bool IsMatchedWith(this string value, string pattern, bool isCaseSensitive = false)
        {
            var patternTokens = pattern.Split('{', '}');
            var cursor = 0;
            for (var i = 0; i < patternTokens.Length; i += 2)
            {
                if (string.IsNullOrEmpty(patternTokens[i])) continue;

                cursor = value.IndexOf(patternTokens[i], cursor, isCaseSensitive ? StringComparison.InvariantCulture : StringComparison.CurrentCultureIgnoreCase);
                if (cursor < 0) return false;
                cursor += patternTokens[i].Length;
            }

            return true;
        }

        //public static Dictionary<string, string> GetTokensWith(this string value, string pattern, bool isCaseSensitive = false)
        //{
        //    var matches = new Regex(TokensRegex.Replace(Regex.Escape(pattern), match => $"(?<{match.Groups[1].Value}>\\w+)")).Match(value);

        //    return matches.Groups
        //        .Select(g => new { name = g.Name, value = g.Value })
        //        .ToDictionary(o => o.name, o => o.value);
        //}

        //public static string FormatWith(this string pattern, params object[] values)
        //{
        //    var replaced = TokensRegex.Replace(Regex.Escape(pattern), match => $"{{{match.Value}}}");
        //    return Regex.Unescape(string.Format(replaced, values));
        //}
    }
}
