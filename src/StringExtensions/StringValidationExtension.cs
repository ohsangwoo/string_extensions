namespace StringExtensions
{
    public static class StringValidationExtension
    {
        public static bool IsUsZipCode(this string value)
        {
            var tokens = value.Split('-');
            if (tokens.Length == 1)
            {
                return IsFiveDigitUsZipCode(value);
            } else if (tokens.Length == 2)
            {
                return value.Length == 10 && IsFiveDigitUsZipCode(tokens[0]) && tokens[1].Length == 4 && int.TryParse(tokens[1], out _);
            }

            return false;
        }

        public static bool IsFiveDigitUsZipCode(this string value)
        {
            return value.Length == 5 && int.TryParse(value, out _);
        }
    }
}
