using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CircularLinkedList
{
    public class CircularLinkedList
    {
        public Node Head { get; set; }

        public CircularLinkedList()
        {
            Head = new Node(0);
            Head.Next = Head;
        }

        public void PrintList()
        {
            if (Head.Next == Head)
            {
                Console.WriteLine("List is empty.");
                return;
            }

            Node current = Head.Next;
            do
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            } while (current != Head);
            Console.WriteLine();
        }

        public void RemovePrimes()
        {
            Node current = Head;
            while (current.Next != Head)
            {
                if (IsPrime(current.Next.Data))
                {
                    current.Next = current.Next.Next;
                }
                else
                {
                    current = current.Next;
                }
            }
        }

        private bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        public void Add(int data)
        {
            Node newNode = new Node(data);
            if (Head.Next == Head)
            {
                Head.Next = newNode;
                newNode.Next = Head;
            }
            else
            {
                Node current = Head;
                while (current.Next != Head)
                {
                    current = current.Next;
                }
                current.Next = newNode;
                newNode.Next = Head;
            }
        }

        public static CircularLinkedList Merge(CircularLinkedList list1, CircularLinkedList list2)
        {
            CircularLinkedList result = new CircularLinkedList();
            Node current1 = list1.Head.Next;
            Node current2 = list2.Head.Next;

            while (current1 != list1.Head && current2 != list2.Head)
            {
                if (current1.Data <= current2.Data)
                {
                    result.Add(current1.Data);
                    current1 = current1.Next;
                }
                else
                {
                    result.Add(current2.Data);
                    current2 = current2.Next;
                }
            }

            while (current1 != list1.Head)
            {
                result.Add(current1.Data);
                current1 = current1.Next;
            }

            while (current2 != list2.Head)
            {
                result.Add(current2.Data);
                current2 = current2.Next;
            }

            return result;
        }
    }
}