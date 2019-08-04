// Inhritance.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include <string>
#include <vector>
#include <fstream>
using namespace std;


class Person {
protected:
	string firstName;
	string lastName;
	int id;
public:
	Person(string firstName, string lastName, int identification) {
		this->firstName = firstName;
		this->lastName = lastName;
		this->id = identification;
	}
	void printPerson() {
		cout << "Name: " << lastName << ", " << firstName << "\nID: " << id << "\n";
	}

};

class Student : public Person {
private:
	vector<int> testScores;
public:
	Student(string firstName, string lastName, int identification, vector<int> scores) :Person(firstName, lastName, identification)
	{
		testScores = scores;
	}


public: char calculate() {
	int i;
	int sum = 0;
	for (i = 0; i < testScores.size(); i++)
	{
		sum += testScores[i];
	}
	int res = sum / testScores.size();
	char l;

	if (res < 40)
		l = 'T';
	else if (40 <= res && res < 55)
		l = 'D';
	else if (55 <= res && res < 70)
		l = 'P';
	else if (70 <= res && res < 80)
		l = 'A';
	else if (80 <= res && res < 90)
		l = 'E';
	else if (90 <= res)
		l = 'O';

	return l;
}

};

int main() {
	ifstream cin("Console.txt");
	string firstName;
	string lastName;
	int id;
	int numScores;
	
	cin >> firstName >> lastName >> id >> numScores;
	vector<int> scores;
	for (int i = 0; i < numScores; i++) {
		int tmpScore;
		cin >> tmpScore;
		scores.push_back(tmpScore);
	}
	Student* s = new Student(firstName, lastName, id, scores);
	s->printPerson();
	cout << "Grade: " << s->calculate() << "\n";
	return 0;
}