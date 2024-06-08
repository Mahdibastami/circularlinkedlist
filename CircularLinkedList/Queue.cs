using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CircularLinkedList
{
    public class Queue
    {
        private Node front;
        private Node rear;

        public Queue()
        {
            front = rear = null;
        }

        public void Add(int data)
        {
            Node newNode = new Node(data);
            if (rear == null)
            {
                front = rear = newNode;
                return;
            }
            rear.Next = newNode;
            rear = newNode;
        }

        public int Delete()
        {
            if (front == null) throw new InvalidOperationException("Queue is empty");
            int value = front.Data;
            front = front.Next;
            if (front == null) rear = null;
            return value;
        }

        public void PrintQueue()
        {
            Node current = front;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
}