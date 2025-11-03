namespace _4_RemoveDuplicatesFromSortedArray
{
    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;

            int j = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[j - 1])
                {
                    nums[j] = nums[i];
                    j++;
                }
            }

            return j;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Remove Duplicates from Sorted Array ===");
            Console.WriteLine("This program removes duplicates from a sorted array in-place");

            Solution solution = new Solution();

            Console.WriteLine("\nEnter a sorted array of integers (separated by spaces):");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Empty input received. Using empty array.");
                input = "";
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

            // Check if array is sorted
            if (!IsSorted(nums))
            {
                Console.WriteLine("Warning: The input array is not sorted! Sorting it for you...");
                Array.Sort(nums);
                Console.WriteLine($"Sorted array: [{string.Join(", ", nums)}]");
            }

            DisplayArrayProcessing(solution, nums, "Custom Input");
        }

        public static void DisplayArrayProcessing(Solution solution, int[] nums, string description)
        {
            Console.WriteLine($"\n=== Processing: {description} ===");
            Console.WriteLine($"Original array: [{string.Join(", ", nums)}]");
            Console.WriteLine($"Original length: {nums.Length}");

            // Create a working copy
            int[] workingArray = new int[nums.Length];
            Array.Copy(nums, workingArray, nums.Length);

            // Perform the operation
            int newLength = solution.RemoveDuplicates(workingArray);

            // Display results
            Console.WriteLine($"\n=== Results ===");
            Console.WriteLine($"New length: {newLength}");
            Console.WriteLine($"Unique elements: [{string.Join(", ", workingArray.Take(newLength))}]");

            // Performance metrics
            int duplicatesRemoved = nums.Length - newLength;
            Console.WriteLine($"Duplicates removed: {duplicatesRemoved}");

            // Validation
            bool isValid = ValidateResult(workingArray, newLength);
            Console.WriteLine($"Validation: {(isValid ? "✓ PASS - No duplicates in result" : "✗ FAIL - Duplicates found")}");
        }
        public static bool ValidateResult(int[] nums, int length)
        {
            // Check that the first 'length' elements have no duplicates
            for (int i = 1; i < length; i++)
            {
                if (nums[i] == nums[i - 1])
                {
                    return false;
                }
            }
            return true;
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
