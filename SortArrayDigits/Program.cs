//Written by Ricardo Ferrancullo

using System;

namespace SortArrayDigits
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[,] arrayToSortDigits = new int[,] { { 125, 893, 7821, 8091, 3385, 219, 732, 8907 }, { 26, 180, 92, 58, 21, 698, 275, 532 } };
            for (int i = 0; i < arrayToSortDigits.GetLength(0); i++)
            {
                string newArray = "";
                string oldArray = "";

                for (int j = 0; j < arrayToSortDigits.GetLength(1); j++)
                {
                    string leadingZeros = "";
                    int originalDigits = arrayToSortDigits[i, j];

                    int zeros = originalDigits.ToString().Split("0").Length - 1;

                    oldArray += originalDigits + (j < arrayToSortDigits.GetLength(1) - 1 ? ", " : "");
                    arrayToSortDigits[i, j] = SortDigits(arrayToSortDigits[i, j]);

                    //For purpose of displaying, we add leading zeros if applicable. Note that the real array can't have leading zeros because it's an array of int
                    for (int ctr = 0; ctr < zeros; ctr++)
                    {
                        leadingZeros += "0";
                    }

                    newArray += leadingZeros + arrayToSortDigits[i, j] + (j < arrayToSortDigits.GetLength(1) - 1 ? ", " : "");
                }
                Console.WriteLine($"[{oldArray}] => [{newArray}]");
            }
        }

        private static int SortDigits(int number)
        {
            int[] digits = new int[(int)Math.Floor(Math.Log10(Math.Abs(number)) + 1)];

            for (int i = 0; i < digits.Length; i++)
            {
                digits[i] = number % 10;
                number /= 10;
            }

            for (int i = 0; i < digits.Length; i++)
            {
                for (int j = i + 1; j < digits.Length; j++)
                {
                    if (digits[j] < digits[i])
                    {
                        int temp = digits[i];
                        digits[i] = digits[j];
                        digits[j] = temp;
                    }
                }
            }

            int newNumber = 0;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                newNumber += digits[i] * (int)Math.Pow(10, digits.Length - 1 - i);
            }

            return newNumber;
        }
    }
}