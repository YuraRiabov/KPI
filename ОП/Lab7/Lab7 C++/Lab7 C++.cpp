#include <iostream>
#include <cmath>
using namespace std;

const int N = 7; // Size of an array
int arr[N]; // Array

void generateArray(int* arr);
int findMax(int* array);
void outputArray(int* arr);

int main()
{
	int max; // Max element of an array
	int d; // Value every element has to be reduced by

	generateArray(arr);
	cout << "Generated array: ";
	outputArray(arr);
	cout << "\n";

	max = findMax(arr);

	d = 0;
	for (int i = 0; i < N; i++)
	{
		d += (int)pow(arr[i] - max, 2);
	}

	for (int i = 0; i < N; i += 2)
	{
		arr[i] -= d;
	}

	cout << "New array: ";
	outputArray(arr);
}

void generateArray(int* array) // Function which generates values for initialized array
{
	srand(time(NULL));
	for (int i = 0; i < N; i++)
	{
		array[i] = rand() % 30 - 15;
	}
	
}

int findMax(int* array) // Function which returns the maximum value of an array
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

void outputArray(int* arr) // Function which outputs array elements
{
	for (int i = 0; i < N; i++)
	{
		cout << arr[i] << " ";
	}
}