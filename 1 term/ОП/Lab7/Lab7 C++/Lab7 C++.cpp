﻿#include <iostream>
#include <cmath>
using namespace std;

int* GenerateArray(int size);
int FindMax(int* array, int size);
int FindD(int* array, int max, int size);
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
	cout << "Maximum element of the array: " << max << "\n";

	d = FindD(array, max, size);
	cout << "The value every odd element has to be reduced by: " << d << "\n";

	SubtractFromOdd(d, array, size);

	cout << "New array: ";
	OutputArray(array, size);
	delete(array);

	system("pause");
}

int* GenerateArray(int size) 
{
	int* array = new int[size];
	srand(time(NULL));
	for (int i = 0; i < size; i++)
	{
		array[i] = rand() % 30 - 15;
	}
	return array;
}

int FindMax(int* array, int size)
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

// D is a value every odd element has to be reduced by
int FindD(int* array, int max, int size)
{
	int d = 0;
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

void OutputArray(int* array, int size)
{
	for (int i = 0; i < size; i++)
	{
		cout << array[i] << " ";
	}
	cout << "\n";
}