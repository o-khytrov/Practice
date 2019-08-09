// Scope.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include <vector>
#include <iostream>
#include <algorithm>
#include <fstream>
using namespace std;

class Difference {
private:
	vector<int> elements;

public:
	int maximumDifference;

public:Difference(vector<int> a) {
	elements = a;
}
public:void computeDifference() {
	int i;
	for (i = 0; i < elements.size(); i++) {
		int j;
		for (j = 0; j < elements.size(); j++) {

			int diff = elements[i] - elements[j];
			diff = abs(diff);
			if (maximumDifference < diff) {
				maximumDifference = diff;
			}
		}

	}
}

}; 
int main()
{
	int N;
	cin >> N;

	vector<int> a;

	for (int i = 0; i < N; i++) {
		int e;
		cin >> e;

		a.push_back(e);
	}

	Difference d(a);

	d.computeDifference();

	cout << d.maximumDifference;

	return 0;
}