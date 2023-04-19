using System;

namespace algorithm.FloydCycle
{

    class Program
    {
        public static void Main()
        {
            // input keys
            int[] keys = { 1, 2, 3, 4, 5 };

            Node? head = null;
            for (int i = keys.Length - 1; i >= 0; i--)
            {
                head = new Node(keys[i], head);
            }

            head.next.next.next.next.next = head.next.next;

            if (detectCycle(head))
            {
                Console.WriteLine("Cycle Found");
            }
            else
            {
                Console.WriteLine("No Cycle Found");
            }
        }

        public static bool detectCycle(Node head)
        {
            Node slow = head, fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast)
                {
                    return true;
                }
            }

            return false;
        }


    }
    public class Node
    {
        int data;
        public Node next;

        public Node(int data, Node next)
        {
            this.data = data;
            this.next = next;
        }
    }

}


