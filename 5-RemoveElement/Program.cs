namespace _5_RemoveElement
{
    public class Solution
    {
        public int RemoveElement(int[] nums, int val)
        {
            int j = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
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
            Console.WriteLine("\n=== Remove Element from Array ===");
            Console.WriteLine("This program removes all occurrences of a value from an array in-place");

            Solution solution = new Solution();
            Console.WriteLine("\nEnter an array of integers (separated by spaces):");
            string arrayInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(arrayInput))
            {
                Console.WriteLine("Empty input received. Using empty array.");
                arrayInput = "";
            }

            string[] parts = arrayInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] nums = new int[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                if (!int.TryParse(parts[i], out nums[i]))
                {
                    throw new ArgumentException($"Invalid number: {parts[i]}");
                }
            }

            // Get value to remove
            Console.Write("Enter the value to remove: ");
            if (!int.TryParse(Console.ReadLine(), out int valToRemove))
            {
                throw new ArgumentException("Invalid value to remove");
            }

            DisplayRemovalProcess(solution, nums, valToRemove, "Custom Input");
        }

        public static void DisplayRemovalProcess(Solution solution, int[] nums, int valToRemove, string description)
        {
            Console.WriteLine($"\n=== Processing: {description} ===");
            Console.WriteLine($"Original array: [{string.Join(", ", nums)}]");
            Console.WriteLine($"Value to remove: {valToRemove}");
            Console.WriteLine($"Original length: {nums.Length}");

            int occurrences = nums.Count(x => x == valToRemove);
            Console.WriteLine($"Occurrences of {valToRemove}: {occurrences}");

            // Create a working copy
            int[] workingArray = new int[nums.Length];
            Array.Copy(nums, workingArray, nums.Length);

            // Perform the operation
            int newLength = solution.RemoveElement(workingArray, valToRemove);

            // Display results
            Console.WriteLine($"\n=== Results ===");
            Console.WriteLine($"New length: {newLength}");
            Console.WriteLine($"Elements kept: {newLength}");
            Console.WriteLine($"Elements removed: {nums.Length - newLength}");
            Console.WriteLine($"Array after removal: [{string.Join(", ", workingArray.Take(newLength))}]");
            Console.WriteLine($"Full array: [{string.Join(", ", workingArray)}]");

            // Validation
            bool isValid = ValidateResult(workingArray, newLength, valToRemove);
            Console.WriteLine($"Validation: {(isValid ? "✓ PASS - Value correctly removed" : "✗ FAIL - Value still present")}");

        }
        public static bool ValidateResult(int[] nums, int length, int valToRemove)
        {
            for (int i = 0; i < length; i++)
            {
                if (nums[i] == valToRemove)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
