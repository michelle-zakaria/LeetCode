namespace _7_Sqrtx
{
    public class Solution
    {
        public int MySqrt(int x)
        {
            if (x == 0) return 0;

            for (long i = 1; i <= x; i++)
            {
                if (i * i > x)
                {
                    return (int)(i - 1);
                }
            }

            return 1;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n=== Integer Square Root Calculator ===");
            Console.WriteLine("This program calculates the integer square root using linear search");

            Solution solution = new Solution();

            Console.Write("\nEnter a non-negative integer: ");
            if (!int.TryParse(Console.ReadLine(), out int x) || x < 0)
            {
                Console.WriteLine("Error: Please enter a valid non-negative integer.");
                return;
            }

            DisplaySquareRootCalculation(solution, x, "Custom Calculation");
        }

        public static void DisplaySquareRootCalculation(Solution solution, int x, string description)
        {
            Console.WriteLine($"\n=== {description} ===");
            Console.WriteLine($"Input: {x}");
            Console.WriteLine($"Actual square root: {Math.Sqrt(x):F6}");

            if (x <= 1000)
            {
                Console.WriteLine("\nCalculation steps:");
                ShowCalculationSteps(x);
            }

            // Performance measurement
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int result = solution.MySqrt(x);
            watch.Stop();

            Console.WriteLine($"\n=== Result ===");
            Console.WriteLine($"Integer square root: {result}");
            Console.WriteLine($"Calculation time: {watch.ElapsedTicks} ticks");

            // Show the mathematical relationship
            long square = (long)result * result;
            long nextSquare = (long)(result + 1) * (result + 1);

            Console.WriteLine($"\nMathematical verification:");
            Console.WriteLine($"{result}² = {square}");
            Console.WriteLine($"{result + 1}² = {nextSquare}");
            Console.WriteLine($"Condition: {square} ≤ {x} < {nextSquare}");

            bool isValid = IsValidSquareRoot(result, x);
            Console.WriteLine($"Validation: {(isValid ? "✓ PASS - Result is correct" : "✗ FAIL - Result is incorrect")}");

            // Additional information
            if (square == x)
            {
                Console.WriteLine($"✓ {x} is a perfect square!");
            }
            else
            {
                double remainder = x - square;
                double percentage = (remainder / (nextSquare - square)) * 100;
                Console.WriteLine($"Remainder: {remainder} ({percentage:F2}% towards next square)");
            }
        }

        public static void ShowCalculationSteps(int x)
        {
            if (x == 0)
            {
                Console.WriteLine("√0 = 0");
                return;
            }

            Console.WriteLine("Iterating from 1 to find where i² > x:");
            Console.WriteLine("i | i² | Comparison with x");
            Console.WriteLine("--|----|------------------");

            for (long i = 1; i <= x; i++)
            {
                long square = i * i;
                string comparison = square > x ? $"{square} > {x} ✓" : $"{square} ≤ {x}";
                string action = square > x ? $"STOP: return {i - 1}" : "continue";

                Console.WriteLine($"{i} | {square} | {comparison} ({action})");

                if (square > x)
                {
                    break;
                }

                // Limit output for large numbers
                if (i > 50 && x > 100)
                {
                    Console.WriteLine($"... (skipping to near the solution)");
                    // Jump to near the solution
                    i = (long)Math.Sqrt(x) - 2;
                    if (i < 51) i = 51;
                }
            }
        }

        public static bool IsValidSquareRoot(int sqrt, int x)
        {
            long square = (long)sqrt * sqrt;
            long nextSquare = (long)(sqrt + 1) * (sqrt + 1);

            return square <= x && x < nextSquare;
        }
    }
}
