// ColorTheBriksCPP.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include <fstream>
#include <algorithm>    // std::sort
#include <vector>       // std::vector

using namespace std;
typedef long long ll;
const int maxn = 1014, mod = 1e9 + 7;
int n, c[maxn][maxn], a[maxn], k, pw[maxn];
int main() {
	ifstream cin("Console.txt");
	ios::sync_with_stdio(0), cin.tie(0);
	cin >> n >> k;
	for (int i = 0; i <= n; i++) {
		c[i][0] = 1;
		for (int j = 1; j <= i; j++)
			c[i][j] = (c[i - 1][j] + c[i - 1][j - 1]) % mod;
	}
	pw[0] = pw[1] = 1;
	for (int i = 2; i <= n; i++)
		pw[i] = pw[i - 1] * 2 % mod;
	int all = n - k;
	a[0] = 0;
	k++;
	for (int i = 1; i < k; i++)
		cin >> a[i];
	a[k++] = n + 1;
	sort(a, a + k);
	int ans = 1;
	for (int i = 1; i < k; i++) {
		int x = a[i] - a[i - 1] - 1;
		ans = (ll)ans * c[all][x] % mod * (i != 1 && i != k - 1 ? pw[x] : 1) % mod;
		all -= x;
	}
	cout << ans << '\n';
}