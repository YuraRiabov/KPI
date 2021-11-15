#include <iostream>
#include <cmath>
using namespace std;

const int N = 7; // Size of an array
int arr[N]; // Array

void GenerateArray(int* arr);
int FindMax(int* array);
double FindD(int* array, int max);
void SubtractFromOdd(double d, int* array);
void OutputArray(int* arr);

int main()
{
	int max; // Max element of an array
	int d; // Value every element has to be reduced by

	GenerateArray(arr);
	cout << "Generated array: ";
	OutputArray(arr);
	cout << "\n";

	max = FindMax(arr);
	d = FindD(arr, max);
	SubtractFromOdd(d, arr);

	cout << "New array: ";
	OutputArray(arr);

	system("pause");
}

void GenerateArray(int* array) // Function which generates values for initialized array
{
	srand(time(NULL));
	for (int i = 0; i < N; i++)
	{
		array[i] = rand() % 30 - 15;
	}
	
}

int FindMax(int* array) // Function which returns the maximum value of an array
{
	int max = array[1];
	for (int i = 0; i < N; i++)
	{
		if (array[i] > max)
		{
			max = array[i];
		}
	}
	return max;
}

double FindD(int* array, int max)
{
	double d = 0;
	for (int i = 0; i < N; i++)
	{
		d += (int)pow(array[i] - max, 2);
	}
	return d;
}

void SubtractFromOdd(double d, int* array)
{
	for (int i = 0; i < N; i += 2)
	{
		arr[i] -= d;
	}
}

void OutputArray(int* arr) // Function which outputs array elements
{
	for (int i = 0; i < N; i++)
	{
		cout << arr[i] << " ";
	}
}