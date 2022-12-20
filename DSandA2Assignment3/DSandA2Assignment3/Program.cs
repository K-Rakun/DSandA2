using System;
using System.Linq;

namespace DSandA2Assignment3
{
    class Program
    {
        static void Main()
        {
            decimal userInput;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("choose an action\n" +
                "1-Show all combination\n" +
                "2-Show combination with the least amount of coins\n" +
                "0-Exit");
                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Console.WriteLine("Enter the amount of money");
                        userInput = decimal.Parse(Console.ReadLine());
                        AllCombinations(userInput, 0, "");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Enter the amount of money");
                        userInput = decimal.Parse(Console.ReadLine());
                        SmallestCoinCount(userInput);
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;        
                }

                if (input == 0)
                {
                    break;
                }
            }


        }


        public static decimal[] coins = new decimal[] { 2.00m, 1.00m, 0.50m, 0.20m, 0.10m, 0.05m, 0.02m, 0.01m };

        static void AllCombinations(decimal input, int startPoint, string resultSoFar)
        {
            for (int i = startPoint; i < coins.Length; i++)
            {
                string result = resultSoFar;
                decimal input2 = input;

                if(result.Count(n => n == '-') <= 10)
                {
                    while (input2 > 0)
                    {
                        result += coins[i] + "- ";
                        input2 -= coins[i];
                        if (input2 > 0)
                        {
                            AllCombinations(input2, i + 1, result);
                        }
                    }
                    if (input2 == 0)
                    {
                        if (result.Count(n => n == '-') <= 10)
                        {
                            Console.WriteLine(result);

                        }
                    }
                }
            }
        }


        static void SmallestCoinCount(decimal input)
        {

            int i = 0;
            string result = null;

            while (input > 0)
            {
                if(coins[i] <= input)
                {
                    result += coins[i] + "- ";
                    input -= coins[i];
                }
                else
                {
                    i += 1;
                }
                if (input == 0)
                {
                    break;
                }
            }
            Console.WriteLine(result);
        }


    }
}
