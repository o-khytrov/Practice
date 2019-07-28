#include <bits/stdc++.h>
using namespace std;
#define int long long int
#define mp make_pair
#define pb push_back
#define F first
#define S second
const int N = 1000005;
#define M 1000000007
#define double long double
#define BINF 1000000000000001
#define init(arr,val) memset(arr,val,sizeof(arr))
#define MAXN 15000001
#define deb(x) cout << #x << " " << x << endl;
const int LG = 22;

vector<pair<pair<int, int>, pair<int, int>>>ver, v;
vector<pair<int, int>>point;
vector<int>val;

#undef int 
int main() {
#define int long long int
	ios_base::sync_with_stdio(false);
	cin.tie(0);
	cout.tie(0);


	int n, d;
	cin >> n >> d;
	int p, q, r, s, c;
	cin >> p >> q >> r >> s >> c;
	for (int i = 0; i < n; i++) {
		int aa, bb, cc, dd, ee;
		cin >> aa >> bb >> cc >> dd >> ee;
		ver.push_back({ {aa,bb} , {cc,dd} });
		val.push_back(ee);

	}

	//point.push_back(make_pair(p,q));

	int px = p, py = q;

	for (int i = 0; i < 600; i++) {
		int x = rand() % 2013;
		int y = rand() % 7047;
		point.push_back(make_pair(x, y));
	}

	point.push_back(make_pair(r, s));

	cout << point.size() << endl;

	for (int i = 0; i < point.size(); i += 1) {
		int x = px, y = py, xx = point[i].F, yy = point[i].S;

		int lol = BINF;
		int ind = 0;

		for (int j = 0; j < n; j++) {
			int aa = ver[j].F.F, bb = ver[j].F.S, cc = ver[j].S.F, dd = ver[j].S.S;
			if (aa <= xx and bb <= yy and xx <= cc and yy <= dd and lol > val[j])
				ind = j + 1, lol = val[j];
		}

		cout << x << ' ' << y << ' ' << xx << ' ' << yy << ' ' << ind << endl;
		px = xx, py = yy;

	}



}