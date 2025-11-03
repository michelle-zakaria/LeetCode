namespace _3_MergeTwoSortedists
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class LinkedListHelper
    {
        // Convert array to linked list
        public static ListNode ArrayToList(int[] arr)
        {
            if (arr == null || arr.Length == 0) return null;

            ListNode head = new ListNode(arr[0]);
            ListNode current = head;

            for (int i = 1; i < arr.Length; i++)
            {
                current.next = new ListNode(arr[i]);
                current = current.next;
            }

            return head;
        }

        // Convert linked list to array
        public static int[] ListToArray(ListNode head)
        {
            List<int> result = new List<int>();
            ListNode current = head;

            while (current != null)
            {
                result.Add(current.val);
                current = current.next;
            }

            return result.ToArray();
        }

        // Print linked list
        public static void PrintList(ListNode head)
        {
            ListNode current = head;
            while (current != null)
            {
                Console.Write(current.val);
                if (current.next != null) Console.Write(" -> ");
                current = current.next;
            }
            Console.WriteLine();
        }

        // Create a deep copy of a linked list
        public static ListNode CopyList(ListNode head)
        {
            if (head == null) return null;

            ListNode newHead = new ListNode(head.val);
            ListNode currentOriginal = head.next;
            ListNode currentNew = newHead;

            while (currentOriginal != null)
            {
                currentNew.next = new ListNode(currentOriginal.val);
                currentNew = currentNew.next;
                currentOriginal = currentOriginal.next;
            }

            return newHead;
        }
    }
    public class Solution
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null) return list2;
            if (list2 == null) return list1;

            if (list1.val <= list2.val)
            {
                list1.next = MergeTwoLists(list1.next, list2);
                return list1;
            }
            else
            {
                list2.next = MergeTwoLists(list1, list2.next);
                return list2;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n=== Linked List Merger ===");
            Console.WriteLine("\nThis program merges two sorted linked lists into one sorted linked list.");

            Solution solution = new Solution();

            Console.WriteLine("\nEnter the first sorted linked list");
            ListNode list1 = GetLinkedListFromUser("List 1");

            // Get second linked list
            Console.WriteLine("\nEnter the second sorted linked list:");
            ListNode list2 = GetLinkedListFromUser("List 2");

            // Display input lists
            Console.WriteLine("\n=== Input Lists ===");
            Console.Write("List 1: ");
            LinkedListHelper.PrintList(list1);
            Console.Write("List 2: ");
            LinkedListHelper.PrintList(list2);

            // Validate that lists are sorted
            if (!IsSorted(list1) || !IsSorted(list2))
            {
                Console.WriteLine("Warning: One or both input lists are not sorted! The result may be incorrect.");
            }

            // Merge the lists
            Console.WriteLine("\n=== Merging Lists ===");
            ListNode merged = solution.MergeTwoLists(
                LinkedListHelper.CopyList(list1),
                LinkedListHelper.CopyList(list2)
            );

            Console.Write("Merged Result: ");
            LinkedListHelper.PrintList(merged);

        }

        public static ListNode GetLinkedListFromUser(string listName)
        {
            Console.WriteLine($"Enter values for {listName} (separated by spaces, or press Enter for empty list):");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine($"{listName} will be empty.");
                return null;
            }

            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] values = new int[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                if (!int.TryParse(parts[i], out values[i]))
                {
                    throw new ArgumentException($"Invalid number: {parts[i]}");
                }
            }

            return LinkedListHelper.ArrayToList(values);
        }

        public static bool IsSorted(ListNode head)
        {
            if (head == null || head.next == null) return true;

            ListNode current = head;
            while (current.next != null)
            {
                if (current.val > current.next.val)
                {
                    return false;
                }
                current = current.next;
            }

            return true;
        }
    }
}
