using System;

namespace StringExtensions
{
    public static class StringPatternExtension
    {
        public static bool IsMatchedWith(this string value, string pattern)
        {
            var patternTokens = pattern.Split(new[] { '{', '}' });
            var cursor = 0;
            for(var i = 0; i < patternTokens.Length; i+=2)
            {
                if (string.IsNullOrEmpty(patternTokens[i])) continue;

                cursor = value.IndexOf(patternTokens[i], cursor);
                if (cursor < 0) return false;
                cursor += patternTokens[i].Length;
            }

            return true;
        }
    }
}
