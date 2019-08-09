// QueuesAndStacks.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include <fstream>
#include <string>
#include <stack>
#include <queue>
using namespace std;

class Solution {
	stack <char> st;
	queue <char> q;
public:	Solution()
	{
		
	}
public: void pushCharacter(char c) {
	st.push(c);
}
public: char popCharacter() {
	char r = st.top();;
	st.pop();
	return r;
}
public: void enqueueCharacter(char c) {
	q.push(c);
}
public: char dequeueCharacter() {
	char r = q.front();;
	q.pop();
	return r;
}

};

int main() {
	ifstream cin("Console.txt");
	string s;
	cin >> s;

	// create the Solution class object p.
	Solution obj;

	// push/enqueue all the characters of string s to stack.
	for (int i = 0; i < s.length(); i++) {
		obj.pushCharacter(s[i]);
		obj.enqueueCharacter(s[i]);
	}

	bool isPalindrome = true;

	// pop the top character from stack.
	// dequeue the first character from queue.
	// compare both the characters.
	for (int i = 0; i < s.length() / 2; i++) {
		if (obj.popCharacter() != obj.dequeueCharacter()) {
			isPalindrome = false;

			break;
		}
	}

	// finally print whether string s is palindrome or not.
	if (isPalindrome) {
		cout << "The word, " << s << ", is a palindrome.";
	}
	else {
		cout << "The word, " << s << ", is not a palindrome.";
	}

	return 0;
}