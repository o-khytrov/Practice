// LetUsUnderstandComputerCPP.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include <cstdlib>
#include <fstream>
#include <string>
#include <math.h>

using namespace std;

int main()
{
	
	if (const char* env_p = std::getenv("Console_Txt"))
	{
		if (std::string(env_p) == "True")
		{
			ifstream cin("Console.txt");

			uint64_t T, X;
			cin >> T;	// Reading input from STDIN
			for (uint64_t i = 0; i < T; i++) {
				cin >> X;
				if (X == 0) {
					cout << "0\n";
					continue;
				}
				if (X == 1) {
					cout << "1\n";
					continue;
				}
				uint64_t b = log2(X);
				if (b % 2 == 0) {
					cout << (X - (int)pow(2, (b / 2)) + 1) << endl;
				}
				else {
					uint64_t c = ceil(b / 2.0);
					uint64_t n = X / pow(2, c);
					cout << X - n << endl;
				}
			}

		}

	}

}
