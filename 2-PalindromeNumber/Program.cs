namespace _2_PalindromeNumber
{
    using System;
    using System.Collections.Generic;

    public class Solution
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;

            if (x < 10) return true;

            if (x % 10 == 0 && x != 0) return false;

            int reversed = 0;
            int original = x;

            while (x > 0)
            {
                int digit = x % 10;
                reversed = reversed * 10 + digit;
                x /= 10;
            }

            return original == reversed;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();

            Console.WriteLine("\n=== Palindrome Number Checker ===");
            while (true)
            {
                Console.Write("\nEnter a number to check: ");
                string input = Console.ReadLine();

                int number = int.Parse(input);
                bool result = solution.IsPalindrome(number);

                DisplayResult(number, result);

                Console.Write("\nCheck another number? (y/n): ");
                string continueChoice = Console.ReadLine();

                if (continueChoice.ToLower() != "y") break;
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        public static void DisplayResult(int number, bool isPalindrome)
        {
            Console.WriteLine($"\nNumber: {number}");
            Console.WriteLine($"Is Palindrome: {isPalindrome}");

            if (isPalindrome)
            {
                Console.WriteLine($"✓ {number} reads the same forwards and backwards!");
            }
            else
            {
                // Show why it's not a palindrome
                if (number < 0)
                {
                    Console.WriteLine("✗ Negative numbers cannot be palindromes");
                }
                else if (number % 10 == 0 && number != 0)
                {
                    Console.WriteLine("✗ Numbers ending with 0 (except 0) cannot be palindromes");
                }
                else
                {
                    int reversed = ReverseNumber(number);
                    Console.WriteLine($"✗ {number} reversed is {reversed}, which is different");
                }
            }
        }

        public static int ReverseNumber(int x)
        {
            int reversed = 0;
            int original = x;

            while (x > 0)
            {
                int digit = x % 10;
                reversed = reversed * 10 + digit;
                x /= 10;
            }

            return reversed;
        }
    }
}
