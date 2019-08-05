// DictionariesAndMaps.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <fstream>
#include <algorithm>
#include <string>
using namespace std;
class Book {
protected:
	string title;
	string author;
public:
	Book(string t, string a) {
		title = t;
		author = a;
	}
	virtual void display() = 0;

};

class MyBook :Book
{
	int Price;

public: MyBook(string t, string a, int price) :Book(t, a) {
	Price = price;
}
		void display() {
			cout << "Title: " << title << endl;
			cout << "Author: " << author << endl;
			cout << "Price: " << Price << endl;
		}
};



int main() {
	ifstream cin("Console.txt");
	string title, author;
	int price;
	getline(cin, title);
	getline(cin, author);
	cin >> price;
	MyBook novel(title, author, price);
	novel.display();
	return 0;
}
