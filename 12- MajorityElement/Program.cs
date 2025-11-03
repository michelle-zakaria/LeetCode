namespace _12__MajorityElement
{
    public class Solution
    {
        public int MajorityElement(int[] nums)
        {
            int majority = 0;
            int n = nums.Length;
            for (int i = 0; i < 32; i++)
            {
                int bitCount = 0;
                foreach (int num in nums)
                {
                    if ((num & (1 << i)) != 0)
                    {
                        bitCount++;
                    }
                }

                if (bitCount > n / 2)
                {
                    majority |= (1 << i);
                }
            }

            return majority;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n=== Majority Element Finder ===");
            Console.WriteLine("This program finds the element that appears more than n/2 times using bit manipulation.");

            Console.WriteLine("\nEnter an array where one element appears more than n/2 times:");
            Console.WriteLine("Format: numbers separated by spaces (Like: '3 2 3')");
            string input = Console.ReadLine() ?? "";

            Solution solution = new Solution();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Empty input received. Using default array [3, 2, 3].");
                input = "3 2 3";
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

            DisplayMajorityElementAnalysis(solution, nums, "Custom Analysis");
        }

        public static void DisplayMajorityElementAnalysis(Solution solution, int[] nums, string description)
        {
            Console.WriteLine($"\n=== {description} ===");
            Console.WriteLine($"Array: [{string.Join(", ", nums)}]");
            Console.WriteLine($"Length: {nums.Length}, Majority threshold: {nums.Length / 2 + 1}");

            int result = solution.MajorityElement(nums);

            Console.WriteLine($"\n=== Result ===");
            Console.WriteLine($"Majority element: {result}");

            ValidateMajorityElement(nums, result);
        }

        public static void ValidateMajorityElement(int[] nums, int result)
        {
            int count = nums.Count(x => x == result);
            int threshold = nums.Length / 2 + 1;

            if (count >= threshold)
            {
                Console.WriteLine($"✓ Validation: {result} appears {count} times (≥ {threshold})");

                // Verify using alternative method
                int alternative = FindMajorityWithSorting(nums);
                if (alternative == result)
                {
                    Console.WriteLine($"✓ Alternative verification (sorting): {result}");
                }
                else
                {
                    Console.WriteLine($"✗ Alternative verification failed: sorting gives {alternative}");
                }
            }
            else
            {
                Console.WriteLine($"✗ Validation: {result} appears only {count} times (< {threshold})");
                Console.WriteLine($"  This shouldn't happen with a correct majority element!");
            }
        }

        public static int FindMajorityWithSorting(int[] nums)
        {
            Array.Sort(nums);
            return nums[nums.Length / 2];
        }
    }
}
