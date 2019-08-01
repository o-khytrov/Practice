// DictionariesAndMaps.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include <cstdlib>
#include <fstream>
#include <string>
#include <math.h>
#include <map>
using namespace std;

int factorial(int n) {
	if (n == 1)
	{
		return n;
	}

	else
	{
		return  n * factorial(n - 1);
	}

}

int main()
{
	ifstream cin("Console.txt");

	int n;
	cin >> n;

	int f = factorial(n);
	cout << f;

}
