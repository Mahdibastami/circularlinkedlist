namespace CircularLinkedList;

class Program
{
    static void Main(string[] args)
    {
        CircularLinkedList list1 = new CircularLinkedList();
        CircularLinkedList list2 = new CircularLinkedList();

        Console.WriteLine("Enter values for list 1 (comma-separated):");
        string[] input1 = Console.ReadLine().Split(',');
        foreach (string s in input1)
        {
            list1.Add(int.Parse(s.Trim()));
        }

        Console.WriteLine("Enter values for list 2 (comma-separated):");
        string[] input2 = Console.ReadLine().Split(',');
        foreach (string s in input2)
        {
            list2.Add(int.Parse(s.Trim()));
        }

        Console.WriteLine("list 1:");
        list1.PrintList();

        Console.WriteLine("list 2:");
        list2.PrintList();

        CircularLinkedList mergedList = CircularLinkedList.Merge(list1, list2);

        Console.WriteLine("Merged list:");
        mergedList.PrintList();

        mergedList.RemovePrimes();
        Console.WriteLine("List after removing prime numbers:");
        mergedList.PrintList();

        Stack stack = new Stack();

        Console.WriteLine("Enter values for the stack (comma-separated):");
        string[] stackInput = Console.ReadLine().Split(',');
        foreach (string s in stackInput)
        {
            stack.Push(int.Parse(s.Trim()));
        }

        Console.WriteLine("Stack:");
        stack.PrintStack();
        Console.WriteLine("Pop this from stack: " + stack.Pop());
        Console.WriteLine("Stack after pop:");
        stack.PrintStack();

        Queue queue = new Queue();

        Console.WriteLine("Enter values for the queue (comma-separated):");
        string[] queueInput = Console.ReadLine().Split(',');
        foreach (string s in queueInput)
        {
            queue.Add(int.Parse(s.Trim()));
        }

        Console.WriteLine("Queue:");
        queue.PrintQueue();
        Console.WriteLine("Delete this from queue: " + queue.Delete());
        Console.WriteLine("Queue after delete:");
        queue.PrintQueue();
    }
}
