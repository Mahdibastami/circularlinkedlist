using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CircularLinkedList
{
    public class Stack
    {
        private Node top;

        public Stack()
        {
            top = null;
        }

        public void Push(int data)
        {
            Node newNode = new Node(data);
            newNode.Next = top;
            top = newNode;
        }

        public int Pop()
        {
            if (top == null) throw new InvalidOperationException("Stack is empty");
            int value = top.Data;
            top = top.Next;
            return value;
        }

        public void PrintStack()
        {
            Node current = top;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
}