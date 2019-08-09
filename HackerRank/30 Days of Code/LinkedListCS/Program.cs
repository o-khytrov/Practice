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
    public static Node insert(Node head, int data)
    {
        if (head == null)
        {
            return new Node(data);
        }
        var nextNode = head;

        while (true)
        {
            if (nextNode.next == null)
            {
                nextNode.next = new Node(data);
                break;
            }
            nextNode = nextNode.next;
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
        display(head);
        Console.ReadKey();
    }
}