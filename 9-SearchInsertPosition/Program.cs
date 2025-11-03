namespace _9_SearchInsertPosition
{
    public class Solution
    {
        public int SearchInsert(int[] nums, int target)
        {
            int low = 0;
            int high = nums.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }

                if (nums[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return low;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n=== Search Insert Position ===");
            Console.WriteLine("This program finds the index where a target should be inserted in a sorted array.");

            Solution solution = new Solution();

            Console.WriteLine("\nEnter a sorted array of integers (separated by spaces):");
            string arrayInput = Console.ReadLine() ?? "";

            int[] nums;
            if (string.IsNullOrWhiteSpace(arrayInput))
            {
                nums = new int[0];
                Console.WriteLine("Using empty array.");
            }
            else
            {
                string[] parts = arrayInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                nums = new int[parts.Length];

                for (int i = 0; i < parts.Length; i++)
                {
                    if (!int.TryParse(parts[i], out nums[i]))
                    {
                        throw new ArgumentException($"Invalid number: {parts[i]}");
                    }
                }

                // Check if array is sorted
                if (!IsSorted(nums))
                {
                    Console.WriteLine("Warning: Array is not sorted! Sorting it for you...");
                    Array.Sort(nums);
                    Console.WriteLine($"Sorted array: [{string.Join(", ", nums)}]");
                }
            }

            // Get target
            Console.Write("Enter target value: ");
            if (!int.TryParse(Console.ReadLine(), out int target))
            {
                throw new ArgumentException("Invalid target value");
            }

            DisplaySearchInsertProcess(solution, nums, target, "Custom Search");

        }

        public static void DisplaySearchInsertProcess(Solution solution, int[] nums, int target, string description)
        {
            Console.WriteLine($"\n=== {description} ===");
            Console.WriteLine($"Array: [{string.Join(", ", nums)}]");
            Console.WriteLine($"Target: {target}");
            Console.WriteLine($"Array length: {nums.Length}");

            int result = solution.SearchInsert(nums, target);

            Console.WriteLine($"\n=== Result ===");
            Console.WriteLine($"Insert position: {result}");

            ValidateAndExplain(nums, target, result);

        }

        public static void ValidateAndExplain(int[] nums, int target, int result)
        {
            Console.WriteLine($"\nExplanation:");

            if (result < 0 || result > nums.Length)
            {
                Console.WriteLine($"✗ Invalid position: {result} (should be between 0 and {nums.Length})");
                return;
            }

            bool condition1 = result < nums.Length ? nums[result] >= target : true;
            bool condition2 = result > 0 ? nums[result - 1] <= target : true;

            if (result < nums.Length)
            {
                Console.WriteLine($"• nums[{result}] = {nums[result]} {(nums[result] >= target ? "≥" : "<")} {target}");
            }
            else
            {
                Console.WriteLine($"• Position {result} is beyond array end");
            }

            if (result > 0)
            {
                Console.WriteLine($"• nums[{result - 1}] = {nums[result - 1]} {(nums[result - 1] <= target ? "≤" : ">")} {target}");
            }
            else
            {
                Console.WriteLine($"• Position {result} is at array start");
            }

            if (condition1 && condition2)
            {
                Console.WriteLine($"✓ Valid insert position: maintains sorted order");

                if (result < nums.Length && nums[result] == target)
                {
                    Console.WriteLine($"✓ Target found at index {result}");
                }
                else if (result == 0)
                {
                    Console.WriteLine($"✓ Insert at beginning: {target} ≤ all elements");
                }
                else if (result == nums.Length)
                {
                    Console.WriteLine($"✓ Insert at end: {target} ≥ all elements");
                }
                else
                {
                    Console.WriteLine($"✓ Insert between {nums[result - 1]} and {nums[result]}");
                }
            }
            else
            {
                Console.WriteLine($"✗ Invalid position: does not maintain sorted order");
            }
        }

        public static bool IsSorted(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < nums[i - 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
