#include <iostream>
#include <cmath>
using namespace std;

int* GenerateArray(int size);
int FindMax(int* array, int size);
double FindD(int* array, int max, int size);
void SubtractFromOdd(double d, int* array, int size);
void OutputArray(int* array, int size);

int main()
{
	int* array;
	int size;
	int max; // Max element of an array
	int d; // Value every element has to be reduced by

	cout << "Enter array size: ";
	cin >> size;

	array = GenerateArray(size);
	cout << "Generated array: ";
	OutputArray(array, size);

	max = FindMax(array, size);
	d = FindD(array, max, size);
	SubtractFromOdd(d, array, size);

	cout << "New array: ";
	OutputArray(array, size);

	system("pause");
}

int* GenerateArray(int size) // Function which generates values for initialized array
{
	int* array = new int[size];
	srand(time(NULL));
	for (int i = 0; i < size; i++)
	{
		array[i] = rand() % 30 - 15;
	}
	return array;
}

int FindMax(int* array, int size) // Function which returns the maximum value of an array
{
	int max = array[0];
	for (int i = 1; i < size; i++)
	{
		if (array[i] > max)
		{
			max = array[i];
		}
	}
	return max;
}

double FindD(int* array, int max, int size)
{
	double d = 0;
	for (int i = 0; i < size; i++)
	{
		d += (int)pow(array[i] - max, 2);
	}
	return d;
}

void SubtractFromOdd(double d, int* array, int size)
{
	for (int i = 0; i < size; i += 2)
	{
		array[i] -= d;
	}
}

void OutputArray(int* array, int size) // Function which outputs array elements
{
	for (int i = 0; i < size; i++)
	{
		cout << array[i] << " ";
	}
	cout << "\n";
}