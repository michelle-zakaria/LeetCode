namespace _1_TwoSum
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[] { -1, -1 };
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            Console.WriteLine("\n=== Two Sum Problem Solver ===");
            Console.Write("\nEnter the number of elements in the array: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] nums = new int[n];
            Console.WriteLine("Enter the array elements:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Element {i + 1}: ");
                nums[i] = Convert.ToInt32(Console.ReadLine());
            }

            // Get target input
            Console.Write("Enter the target sum: ");
            int target = Convert.ToInt32(Console.ReadLine());

            // Solve the problem
            int[] result = solution.TwoSum(nums, target);

            // Display results
            Console.WriteLine("\n=== Results ===");
            Console.WriteLine($"Array: [{string.Join(", ", nums)}]");
            Console.WriteLine($"Target: {target}");

            if (result[0] != -1 && result[1] != -1)
            {
                Console.WriteLine($"Solution found at indices: [{string.Join(", ", result)}]");
                Console.WriteLine($"Values: {nums[result[0]]} + {nums[result[1]]} = {target}");
            }
            else
            {
                Console.WriteLine("No solution found!");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

    }
}
