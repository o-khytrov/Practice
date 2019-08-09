// LinkedList.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include <fstream>
#include <cstddef>
using namespace std;
class Node
{
public:
	int data;
	Node *next;
	Node(int d) {
		data = d;
		next = NULL;
	}
};
class Solution {
public:

	Node* insert(Node *head, int data)
	{
		if (head == NULL)
		{
			return new Node(data);
		}
	
		
		Node* nextNode = head;
		while (true)
		{
			if (nextNode->next == NULL)
			{
				nextNode->next = new Node(data);
				break;
			}
			nextNode = nextNode->next;
		}

		return head;
	}

	void display(Node *head)
	{
		Node *start = head;
		while (start)
		{
			cout << start->data << " ";
			start = start->next;
		}
	}
};

unsigned gcd(unsigned a, unsigned b)
{
	unsigned rest = 0;
	if (a>b)
	{
		rest = a % b;
		if (rest == 0)
			return b;
		return gcd(rest, b);

	}
	else
	{
		rest = b % a;
		if (rest == 0)
			return a;
		return gcd(rest, a);
	
	}

}


int main()
{
	ifstream cin("Console.txt");
	Node* head = NULL;
	Solution mylist;
	int T, data;
	cin >> T;
	while (T-- > 0) {
		cin >> data;
		head = mylist.insert(head, data);
	}
	mylist.display(head);

}