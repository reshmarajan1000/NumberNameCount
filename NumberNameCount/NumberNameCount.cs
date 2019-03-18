using System;

namespace NumberNameCount
{
    class NumberNameCount
    {
        static void Main(string[] args)
        {
            // Letter Count: 1 to 19.
            int[] belowTwenty = { 3, 3, 5, 4, 4, 3, 5, 5, 4, 3, 6, 6, 8, 8, 7, 7, 9, 8, 8 };

            // Letter Count: Tens from 20 to 90.
            int[] tens = { 6, 6, 5, 5, 5, 7, 6, 6 };

            // Letter Count: 100.
            int hundred = 7;

            // Letter Count: 1000.
            int oneThousand = 11;

            // Letter Count: And.
            int and = 3;

            int minNumber = 1;
            int maxNumber = 1000;
            int totalLetterCount = 0;
            int number = 0;

            try
            {
                for (var n = minNumber; n <= maxNumber; n++)
            {
                totalLetterCount += GetLetterCount(n, belowTwenty, tens);

                if (n == 100)
                {
                    totalLetterCount += belowTwenty[0] + hundred;
                }

                if (n == 1000)
                {
                    totalLetterCount += oneThousand;
                }

                if ((n > 100) && (n < 1000))
                {
                    number = n % 100;

                    if (number == 0)
                    {
                        totalLetterCount += belowTwenty[n / 100 - 1] + hundred;
                    }
                    else
                    {
                        totalLetterCount += belowTwenty[n / 100 - 1] + hundred + and;
                        totalLetterCount += GetLetterCount(number, belowTwenty, tens);
                    }
                }

            }

            Console.WriteLine($"Number Name Count[{minNumber}-{maxNumber}]: " + totalLetterCount);
            Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e} Exception caught.");
            }
        }
        public static int GetLetterCount(int number, int[] belowTwenty, int[] tens)
        {
            int totalLetterCount = 0;

            // 1 to 19.
            if (number < 20)
                totalLetterCount += belowTwenty[number - 1];

            // 20  to 90 : tens only.
            if ((number >= 20) && (number < 100) && (number % 10 == 0))
                totalLetterCount += tens[number / 10 - 2];

            // 21 to 99 : excluding tens.
            if ((number > 20) && (number < 100) && (number % 10 != 0))
            {
                totalLetterCount += (tens[number / 10 - 2] + belowTwenty[number % 10 - 1]);
            }

            return totalLetterCount;
        }
    }
}