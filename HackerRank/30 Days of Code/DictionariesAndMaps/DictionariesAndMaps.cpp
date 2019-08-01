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

int main()
{
	if (const char* env_p = std::getenv("Console_Txt"))
	{
		int n;
		map<string, string> dict;
		if (std::string(env_p) == "True")
		{
			ifstream cin("Console.txt");
			cin >> n;

			int i;
			for ( i = 0; i < n; i++)
			{
				string name;
				string phoneNumber;
				cin >> name >> phoneNumber;
				dict.insert(make_pair(name, phoneNumber));
			}
			int j;
			for ( j = 0; j < n; j++)
			{
				string search;
				string phone;
				cin >> search;
				phone = dict[search];
				if (!phone.empty()) {
					cout << search << "=" << phone << endl;

				}
				else {
					cout << "Not found" << endl;
				}
			}

		}

	}
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
