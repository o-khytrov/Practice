// DictionariesAndMaps.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include <cstdlib>
#include <fstream>
#include <string>
#include <vector>
#include <math.h>
#include <map>
using namespace std;

int main()
{
	ifstream cin("Console.txt");
	vector<vector<int>> v;
	int n; // number of arrays
	int q; // number of queries
	cin >> n >> q;
	int i;

	// skip the new line which is after N2 (i.e; 2 value in 1st line)

	for (i = 0; i < n; i++)
	{
		cin.ignore(numeric_limits<streamsize>::max(), '\n');

		vector<int> numbers;
		int number;

		while ((cin.peek() != '\n') && cin.peek() != EOF) {
			cin >> number;
			numbers.push_back(number);
		}

		v.push_back(numbers);
	}
	int j;
	for (j = 0; j < q; j++)
	{
		int q1;
		int q2;
		cin >> q1 >> q2;
		cout << v[q1][q2 + 1] << endl;
	}
}