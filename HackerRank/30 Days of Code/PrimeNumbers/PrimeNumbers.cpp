#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
#include <math.h>
#include <fstream>
using namespace std;

bool IsPrime(int n)
{
	if (n == 1) {
		return false;
	}

	int i = 2;
	// This will loop from 2 to int(sqrt(x))
	while (i*i <= n) {
		// Check if i divides x without leaving a remainder
		if (n % i == 0) {
			// This means that n has a factor in between 2 and sqrt(n)
			// So it is not a prime number
			return false;
		}
		i += 1;
	}
	// If we did not find any factor in the above loop,
	// then n is a prime number
	return true;
}

int main() {
	ifstream cin("Console.txt");
	int t;
	cin >> t;
	int i = 0;
	for (i = 0; i < t; i++) {
		int n;
		cin >> n;
		bool isPrime = IsPrime(n);
		if (isPrime) {
			cout << "Prime" << endl;;
		}
		else {
			cout << "Not prime" << endl;
		}
	}
	return 0;
}