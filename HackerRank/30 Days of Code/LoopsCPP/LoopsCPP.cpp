// LoopsCPP.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>


using namespace std;
int main()
{
	// std::cout << "Hello World!\n"; 
	int n;
	cin >> n;
	for (size_t i = 0; i < 10; i++)
	{
	
		cout << n << " x " << (i + 1) << " = " << (n*(i + 1)) << endl;

	}

}
