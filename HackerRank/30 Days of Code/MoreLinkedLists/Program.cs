using System;
using System.IO;

internal class Node
{
    public int data;
    public Node next;

    public Node(int d)
    {
        data = d;
        next = null;
    }
}

internal class Solution
{
    public static Node removeDuplicates(Node head)
    {
        var root = insert(null, head.data);
        var retVal = root;

        var list = new System.Collections.Generic.List<int>();
        list.Add(head.data);
        while (head.next != null)
        {
            head = head.next;
            var isDuplicate = false;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == head.data)
                {
                    isDuplicate = true;
                    break;
                }
            }
            if (!isDuplicate)
            {
                list.Add(head.data);
                root = insert(root, head.data);
            }

        }

        return retVal;
    }

    public static Node insert(Node head, int data)
    {
        Node p = new Node(data);

        if (head == null)
            head = p;
        else if (head.next == null)
            head.next = p;
        else
        {
            Node start = head;
            while (start.next != null)
                start = start.next;
            start.next = p;
        }
        return head;
    }

    public static void display(Node head)
    {
        Node start = head;
        while (start != null)
        {
            Console.Write(start.data + " ");
            start = start.next;
        }
    }

    private static void Main(String[] args)
    {
        var value = Environment.GetEnvironmentVariable("Console_Txt", EnvironmentVariableTarget.User);
        if (value == "True")
            Console.SetIn(new StreamReader("Console.txt"));

        Node head = null;
        int T = Int32.Parse(Console.ReadLine());
        while (T-- > 0)
        {
            int data = Int32.Parse(Console.ReadLine());
            head = insert(head, data);
        }
        head = removeDuplicates(head);
        display(head);
        Console.ReadKey();
    }
}