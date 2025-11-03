namespace _10_SingleNumber
{
    public class Solution
    {
        public int SingleNumber(int[] nums)
        {
            int result = 0;

            foreach (int num in nums)
            {
                result ^= num;
            }
            return result;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n=== Single Number Finder ===");
            Console.WriteLine("This program finds the number that appears exactly once using XOR operation.");
            Console.WriteLine("Note: All other numbers must appear exactly twice");

            Solution solution = new Solution();

            Console.WriteLine("\nFormat: numbers separated by spaces (like: '2 2 1 3 3')");
            Console.Write("Enter an array: ");
            string input = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Empty input received. Using default array [1, 1, 2].");
                input = "1 1 2";
            }

            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] nums = new int[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                if (!int.TryParse(parts[i], out nums[i]))
                {
                    throw new ArgumentException($"Invalid number: {parts[i]}");
                }
            }

            if (nums.Length == 0)
            {
                Console.WriteLine("Error: Array cannot be empty.");
                return;
            }

            DisplaySingleNumberAnalysis(solution, nums, "Custom Analysis");
        }

        public static void DisplaySingleNumberAnalysis(Solution solution, int[] nums, string description)
        {
            Console.WriteLine($"\n=== {description} ===");
            Console.WriteLine($"Array: [{string.Join(", ", nums)}]");
            Console.WriteLine($"Length: {nums.Length} ({(nums.Length % 2 == 1 ? "odd ✓" : "even ✗ - should be odd")})");

            // Show frequency analysis
            Console.WriteLine("\nFrequency Analysis:");
            ShowFrequencyAnalysis(nums);

            int result = solution.SingleNumber(nums);

            Console.WriteLine($"\n=== Result ===");
            Console.WriteLine($"Single number: {result}");

            ValidateResult(nums, result);

            // Mathematical properties
            Console.WriteLine($"\nMathematical Properties:");
        }

        public static void ShowFrequencyAnalysis(int[] nums)
        {
            var frequency = nums.GroupBy(x => x)
                               .Select(g => new { Number = g.Key, Count = g.Count() })
                               .OrderBy(x => x.Count)
                               .ThenBy(x => x.Number);

            foreach (var item in frequency)
            {
                string marker = item.Count == 1 ? "🎯 SINGLE" : "✓ pair";
                Console.WriteLine($"  {item.Number,4}: appears {item.Count,2} time(s) - {marker}");
            }

            // Check if exactly one number appears once
            int singlesCount = frequency.Count(x => x.Count == 1);
            if (singlesCount != 1)
            {
                Console.WriteLine($"⚠️  Warning: Found {singlesCount} numbers appearing once (should be exactly 1)");
            }
        }

        public static void ValidateResult(int[] nums, int result)
        {
            int count = nums.Count(x => x == result);

            if (count == 1)
            {
                Console.WriteLine($"✓ Validation: {result} appears exactly once");

                // Verify XOR property
                int xorAll = 0;
                foreach (int num in nums)
                {
                    xorAll ^= num;
                }

                if (xorAll == result)
                {
                    Console.WriteLine($"✓ XOR verification: XOR of all numbers = {result}");
                }
                else
                {
                    Console.WriteLine($"✗ XOR verification failed: XOR of all numbers = {xorAll}, expected {result}");
                }
            }
            else
            {
                Console.WriteLine($"✗ Validation: {result} appears {count} times, not once!");
            }
        }
    }
}
