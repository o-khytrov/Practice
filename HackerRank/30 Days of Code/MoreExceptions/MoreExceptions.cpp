// MoreExceptions.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include <fstream>
#include <cmath>
#include <cstddef>
using namespace std;

class Calculator
{

public: int power(int a, int b)
{
	if (a < 0 || b < 0) {
		throw std::invalid_argument("received negative value");
	}
	else
	{
		return pow(a, b);
	}
	

}
};


int main()
{
	ifstream cin("Console.txt");
	Calculator myCalculator = Calculator();
	int T, n, p;
	cin >> T;
	while (T-- > 0) {
		cin >> n >> p;
		try {
			int ans = myCalculator.power(n, p);
			cout << ans << endl;
		}
		catch (exception& e) {
			cout << e.what() << endl;
		}

	}
}
