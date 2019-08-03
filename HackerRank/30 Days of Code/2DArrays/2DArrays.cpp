// 2DArrays.cpp : This file contains the 'main' function. Program execution begins and ends there.
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
	vector<vector<int>> arr;

	int i;

	// skip the new line which is after N2 (i.e; 2 value in 1st line)

	for (i = 0; i < 6; i++)
	{
		vector<int> numbers;
		int j;
		for (j = 0; j < 6; j++)
		{
			int number;
			cin >> number;
			numbers.push_back(number);
		}

		arr.push_back(numbers);
	}

	int h = 0;
	int v = 0;
	int maxSum = -2147483647;
	for (h = 0; h < arr.size(); h++)
	{
		for (v = 0; v < arr[h].size(); v++)
		{
			int r = h;
			int c = v;
			int sum = 0;
			if (c + 3 <= arr[h].size() && r + 3 <= arr.size())
			{
				for (c = v; c < v + 3; c++)
				{
					sum += arr[r][c];
					sum += arr[r + 2][c];
				}
				c = v;
				sum += arr[r + 1][c + 1];
				if (sum > maxSum)
				{
					maxSum = sum;
				}
			}
		}
	}
}