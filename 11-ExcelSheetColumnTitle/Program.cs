namespace _11_ExcelSheetColumnTitle
{
    public class Solution
    {
        public string ConvertToTitle(int columnNumber)
        {
            string result = "";
            while (columnNumber > 0)
            {
                columnNumber--;
                int remainder = columnNumber % 26;
                char currentChar = (char)('A' + remainder);
                result = currentChar + result;
                columnNumber /= 26;
            }

            return result;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n=== Excel Column Title Converter ===");
            Console.WriteLine("This program converts column numbers to Excel-style column titles.");
            Console.WriteLine("Examples: 1 -> A, 26 -> Z, 27 -> AA, 28 -> AB, 701 -> ZY");
            Solution solution = new Solution();

            Console.Write("\nEnter column number (1 or greater): ");
            if (!int.TryParse(Console.ReadLine(), out int columnNumber) || columnNumber < 1)
            {
                Console.WriteLine("Error: Please enter a valid positive integer.");
                return;
            }

            DisplayConversionProcess(solution, columnNumber, "Custom Conversion");
        }

        public static void DisplayConversionProcess(Solution solution, int columnNumber, string description)
        {
            Console.WriteLine($"\n=== {description} ===");
            Console.WriteLine($"Input: {columnNumber}");

            string result = solution.ConvertToTitle(columnNumber);

            Console.WriteLine($"\n=== Result ===");
            Console.WriteLine($"Column {columnNumber} -> \"{result}\"");

            ValidateConversion(columnNumber, result);

            Console.WriteLine($"Title length: {result.Length} character(s)");

            if (result.Length > 1)
            {
                Console.WriteLine($"Position in {result.Length}-letter sequence: {CalculatePositionInGroup(columnNumber, result.Length)}");
            }
        }
        public static int TitleToNumber(string columnTitle)
        {
            int result = 0;
            foreach (char c in columnTitle)
            {
                result = result * 26 + (c - 'A' + 1);
            }
            return result;
        }
        public static void ValidateConversion(int columnNumber, string result)
        {
            // Manual validation by converting back
            int calculatedNumber = TitleToNumber(result);

            if (calculatedNumber == columnNumber)
            {
                Console.WriteLine($"✓ Validation: \"{result}\" -> {calculatedNumber} (matches input)");
            }
            else
            {
                Console.WriteLine($"✗ Validation failed: \"{result}\" -> {calculatedNumber} (expected {columnNumber})");
            }

            // Check if result contains only valid characters
            if (result.All(char.IsLetter) && result.All(c => c >= 'A' && c <= 'Z'))
            {
                Console.WriteLine($"✓ Valid characters: A-Z only");
            }
            else
            {
                Console.WriteLine($"✗ Invalid characters in result");
            }
        }

        public static int CalculatePositionInGroup(int columnNumber, int length)
        {
            int minInGroup = CalculateMinColumns(length);
            return columnNumber - minInGroup + 1;
        }
        public static int CalculateMinColumns(int length)
        {
            // For n letters, minimum column is 26^(n-1) + 1, but actually it's:
            if (length == 1) return 1;
            return (int)Math.Pow(26, length - 1) + 1;
        }
    }
}
