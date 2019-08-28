#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <algorithm>
using namespace std;




int main()
{
#if _DEBUG
	

#endif // DEBUG
	FILE* fp;

	if ((fp = fopen("Conso.txt", "r+")) == NULL)
	{
		printf("No such file\n");
		exit(1);
	}
	int numbers[10];
	int count = 10;
	long sum = 0L;
	float average = 0.0f;

	printf("\nEnter the 10 numbers:\n");
	int i;

	for (i = 0; i < count; i++)
	{
		fscanf(fp,"%d", &numbers[i]);
		sum += numbers[i];
	}

	average = (float)sum / count;

	printf("\nAverage of the ten numbers entered is: %f\n", average);
	return 0;
}
