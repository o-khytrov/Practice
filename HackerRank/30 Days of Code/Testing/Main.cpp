#include <algorithm>
#include <iostream>
#include <stdexcept>
#include <vector>
#include <cassert>
#include <set>
#include <fstream>


using namespace std;

int minimum_index(vector<int> seq) {
	if (seq.empty()) {
		throw invalid_argument("Cannot get the minimum value index from an empty sequence");
	}
	int min_idx = 0;
	for (int i = 1; i < seq.size(); ++i) {
		if (seq[i] < seq[min_idx]) {
			min_idx = i;
		}
	}
	return min_idx;
}

class TestDataEmptyArray {
public:
	static vector<int> get_array() {
		vector<int> e;
		return e;
	}

};

class TestDataUniqueValues {
public:
	static vector<int> get_array() {
		vector<int> v;
		v.push_back(1);
		v.push_back(2);
		v.push_back(3);
		v.push_back(4);
		v.push_back(5);
	}

	static int get_expected_result() {
		return 0;
	}

};

class TestDataExactlyTwoDifferentMinimums {
public:
	static vector<int> get_array() {
		vector<int> v;
		v.push_back(1);
		v.push_back(2);
		v.push_back(3);
		v.push_back(1);
		v.push_back(5);
	
	}
public:
	static int get_expected_result() {
		return 0;
	}

};


void TestWithEmptyArray() {
	try {
		auto seq = TestDataEmptyArray::get_array();
		auto result = minimum_index(seq);
	}
	catch (invalid_argument& e) {
		return;
	}
	assert(false);
}

void TestWithUniqueValues() {
	auto seq = TestDataUniqueValues::get_array();
	assert(seq.size() >= 2);

	assert(set<int>(seq.begin(), seq.end()).size() == seq.size());

	auto expected_result = TestDataUniqueValues::get_expected_result();
	auto result = minimum_index(seq);
	assert(result == expected_result);
}

void TestWithExactlyTwoDifferentMinimums() {
	auto seq = TestDataExactlyTwoDifferentMinimums::get_array();
	assert(seq.size() >= 2);

	auto tmp = seq;
	sort(tmp.begin(), tmp.end());
	assert(tmp[0] == tmp[1] and (tmp.size() == 2 or tmp[1] < tmp[2]));

	auto expected_result = TestDataExactlyTwoDifferentMinimums::get_expected_result();
	auto result = minimum_index(seq);
	assert(result == expected_result);
}

int main() {
	ifstream cin("Console.txt");
	TestWithEmptyArray();
	TestWithUniqueValues();
	TestWithExactlyTwoDifferentMinimums();
	cout << "OK" << endl;
	return 0;
}
