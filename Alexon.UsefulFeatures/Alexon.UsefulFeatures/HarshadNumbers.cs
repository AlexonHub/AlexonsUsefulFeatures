namespace Alexon.UsefulFeatures
{
    using System;
    using System.Collections.Generic;

    public static class HarshadNumbers
    {
        /// <summary>
        /// Генерує список чисел Харшад у заданому діапазоні.
        /// </summary>
        /// <param name="start">Початкове число діапазону (включно).</param>
        /// <param name="end">Кінцеве число діапазону (включно).</param>
        /// <returns>Список цілих чисел, які є числами Харшад.</returns>
        public static List<int> GetHarshadNumbers(int start, int end)
        {
            if (start > end)
            {
                throw new ArgumentException("Початкове число не може бути більшим за кінцеве.");
            }

            var harshadNumbers = new List<int>();
            for (int i = start; i <= end; i++)
            {
                if (IsHarshad(i))
                {
                    harshadNumbers.Add(i);
                }
            }
            return harshadNumbers;
        }

        /// <summary>
        /// Перевіряє, чи є число числом Харшад.
        /// </summary>
        /// <param name="number">Ціле число для перевірки.</param>
        /// <returns>True, якщо число є числом Харшад; інакше False.</returns>
        private static bool IsHarshad(int number)
        {
            if (number <= 0)
            {
                return false;
            }

            int sumOfDigits = 0;
            int tempNumber = number;

            while (tempNumber > 0)
            {
                sumOfDigits += tempNumber % 10;
                tempNumber /= 10;
            }

            return number % sumOfDigits == 0;
        }
    }
}
