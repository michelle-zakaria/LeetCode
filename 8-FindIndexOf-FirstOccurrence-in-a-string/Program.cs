namespace _8_FindIndexOf_FirstOccurrence_in_a_string
{
    public class Solution
    {
        public int StrStr(string haystack, string needle)
        {
            if (needle.Length == 0) return 0;
            if (haystack.Length < needle.Length) return -1;
            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                if (haystack[i] == needle[0])
                {
                    bool found = true;
                    for (int j = 1; j < needle.Length; j++)
                    {
                        if (haystack[i + j] != needle[j])
                        {
                            found = false;
                            break;
                        }
                    }
                    if (found) return i;
                }
            }
            return -1;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n=== String Search (strStr) Implementation ===");
            Console.WriteLine("This program finds the first occurrence of a needle in a haystack.");

            Solution solution = new Solution();

            Console.Write("\nEnter the haystack string: ");
            string haystack = Console.ReadLine() ?? "";

            Console.Write("Enter the needle string: ");
            string needle = Console.ReadLine() ?? "";

            DisplaySearchResult(solution, haystack, needle, "Custom Search");
        }

        public static void DisplaySearchResult(Solution solution, string haystack, string needle, string description)
        {
            Console.WriteLine($"\n=== {description} ===");
            Console.WriteLine($"Haystack: \"{haystack}\"");
            Console.WriteLine($"Needle: \"{needle}\"");
            Console.WriteLine($"Haystack length: {haystack.Length}");
            Console.WriteLine($"Needle length: {needle.Length}");

            if (needle.Length == 0)
            {
                Console.WriteLine("Needle is empty - returning 0");
                Console.WriteLine("Result: 0");
                return;
            }

            if (haystack.Length < needle.Length)
            {
                Console.WriteLine("Needle is longer than haystack - returning -1");
                Console.WriteLine("Result: -1");
                return;
            }

            Console.WriteLine($"\nSearch bounds: i from 0 to {haystack.Length - needle.Length}");

            int result = solution.StrStr(haystack, needle);
            DisplayFinalResult(haystack, needle, result);
        }

        public static void DisplayFinalResult(string haystack, string needle, int result)
        {
            Console.WriteLine($"\n=== Final Result ===");
            Console.WriteLine($"Index: {result}");

            if (result != -1)
            {
                Console.WriteLine($"\nVisual confirmation:");
                Console.WriteLine($"Haystack: {haystack}");
                Console.WriteLine($"Match:    {new string(' ', result)}{needle}");
                Console.WriteLine($"Position: {new string(' ', result)}↑ (index {result})");

                // Show context around match
                int start = Math.Max(0, result - 5);
                int end = Math.Min(haystack.Length, result + needle.Length + 5);
                string context = haystack.Substring(start, end - start);
                string contextPointer = new string(' ', result - start) + new string('↑', needle.Length);

                Console.WriteLine($"Context:  {context}");
                Console.WriteLine($"          {contextPointer}");
            }

            // Validation
            int expected = haystack.IndexOf(needle);
            Console.WriteLine($"Validation: {(result == expected ? "✓ PASS - Matches .IndexOf()" : "✗ FAIL - Different from .IndexOf()")}");
        }
    }
}
