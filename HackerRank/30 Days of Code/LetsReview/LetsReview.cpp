// LetsReview.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include <string>

using namespace std;

int main()
{
	int T; //���������� �������� ����
	string S; // ������
	
	cin >> T; // ������� ���� �� ������� � ���������� �
	int i;
	for ( i = 0; i < T; i++)
	{
		cin >> S; // 
		string left;
		string right;

		int length = S.length();
		int j;
		for (j = 0; j < length; j++) {

			int num = j + 1;
			if (num % 2 == 0)//������ �����
			{
				right = right + S[j];
			}
			else {
				left = left + S[j];
			}
		}
		cout << left << " " << right << endl;
	}
	
}
