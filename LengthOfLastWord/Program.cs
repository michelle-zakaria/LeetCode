namespace LengthOfLastWord
{
    public class Solution
    {
        public int LengthOfLastWord(string s)
        {
            int length = 0;
            int i = s.Length - 1;

            while (i >= 0 && s[i] == ' ')
            {
                i--;
            }

            while (i >= 0 && s[i] != ' ')
            {
                length++;
                i--;
            }

            return length;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n=== Length of Last Word ===");
            Console.WriteLine("\nThis program finds the length of the last word in a string");

            Solution solution = new Solution();
            Console.WriteLine("\nEnter a string:");
            string input = Console.ReadLine();

            if (input == null)
            {
                input = "";
            }

            DisplayStringAnalysis(solution, input, "Custom Input");
        }

        public static void DisplayStringAnalysis(Solution solution, string input, string description)
        {
            Console.WriteLine($"Input string: \"{input}\"");
            Console.WriteLine($"Input length: {input.Length}");

            int result = solution.LengthOfLastWord(input);

            // Display results
            Console.WriteLine($"\n=== Results ===");
            Console.WriteLine($"Length of last word: {result}");

            string lastWord = GetLastWord(input);
            Console.WriteLine($"Last word: \"{lastWord}\"");
            Console.WriteLine($"Last word length: {lastWord.Length}");

            // Additional statistics
            int wordCount = CountWords(input);
            Console.WriteLine($"Total words in string: {wordCount}");

            // Validation
            bool isValid = result == lastWord.Length;
            Console.WriteLine($"Validation: {(isValid ? "✓ PASS - Correct length" : "✗ FAIL - Incorrect length")}");

            Console.WriteLine($"\nAlgorithm: Reverse traversal with space skipping (O(n) time, O(1) space)");
        }

        public static void VisualizeStringDetailed(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                Console.WriteLine("String is empty.");
                return;
            }

            // Show characters with indices
            Console.Write("Chars:  ");
            for (int i = 0; i < s.Length; i++)
            {
                Console.Write($"{s[i],3}");
            }
            Console.WriteLine();

            // Show indices
            Console.Write("Index: ");
            for (int i = 0; i < s.Length; i++)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();

            // Show pointer positions for algorithm
            Console.Write("Spaces: ");
            for (int i = 0; i < s.Length; i++)
            {
                Console.Write($"{(s[i] == ' ' ? " ␣ " : "   ")}");
            }
            Console.WriteLine();
        }

        public static string GetLastWord(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return "";

            // Trim trailing spaces
            s = s.TrimEnd();

            // Find last space
            int lastSpaceIndex = s.LastIndexOf(' ');

            if (lastSpaceIndex == -1)
            {
                // No spaces found, entire string is the word
                return s;
            }
            else
            {
                // Return substring after last space
                return s.Substring(lastSpaceIndex + 1);
            }
        }

        public static int CountWords(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return 0;

            return s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static int CountTrailingSpaces(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            int count = 0;
            for (int i = s.Length - 1; i >= 0 && s[i] == ' '; i--)
            {
                count++;
            }
            return count;
        }

    }
}
