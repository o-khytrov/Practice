// Arrays.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include <string>

using namespace std;
string trim(const string& str)
{
	size_t first = str.find_first_not_of(' ');
	if (string::npos == first)
	{
		return str;
	}
	size_t last = str.find_last_not_of(' ');
	return str.substr(first, (last - first + 1));
}
int main()
{
	int N;
	//N = 4;
	cin >> N;
	string S;
    cin >> S;
	//S = "1 4 3 2";
	int l = S.length();
	for (int i = l - 1; i >= 0; i--)
		cout << S[i];
	

}

