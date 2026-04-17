namespace Alexon.UsefulFeatures
{
    public static class StringHelper
    {
        extension(string input)
        {
            public bool IsPalindrome => input == Reverse(input);
            public string Reverse() 
            {
                var charArray = input.ToCharArray();
                Array.Reverse(charArray);
                return new string(charArray);
            }
            public string GetNumbersFromString() 
            {
                var numbers = input.Where(char.IsDigit).Select(c => c);
                return new string([.. numbers]);
            }

        }

        public static int CombineNumber(int n, int m)
        {
            var nStr = n.ToString();
            var mStr = m.ToString();
            var maxLength = Math.Max(nStr.Length, mStr.Length);

            nStr = nStr.PadLeft(maxLength, '0');
            mStr = mStr.PadLeft(maxLength, '0');

            var resultStr = new char[maxLength];
            for (int i = 0; i < maxLength; i++)
            {
                resultStr[i] = nStr[i] >= mStr[i] ? nStr[i] : mStr[i];
            }

            return int.Parse(new string(resultStr));
        }
    }
}