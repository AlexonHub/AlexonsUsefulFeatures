namespace Alexon.UsefulFeatures
{
    public static class StringHelper
    {
        public static bool IsPalindrome(this string input)
        {
            return input == Reverse(input);
        }

        public static string Reverse(this string input)
        {
            var charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}