#include <iostream>
#include <ctime>
#include <iomanip>
#include <cmath>

double** GenerateMatrix();
void FillAverageNegative(double* array, double** matrix);
double FindAvergeNegative(double** matrix, int row);
void SortBubbleDescent(double* array);
void OutputMatrix(double** matrix);
void OutputArray(double* array);
void DeleteMatrix(double** matrix);

int main()
{
	double** matrix;
	double* array = new double[6];

	matrix = GenerateMatrix();
	std::cout << "Generated matrix:\n";
	OutputMatrix(matrix);

	FillAverageNegative(array, matrix);
	std::cout << "Array of averages of negative elements in each row of the matrix:\n";
	OutputArray(array);

	SortBubbleDescent(array);
	std::cout << "Sorted array:\n";
	OutputArray(array);

	DeleteMatrix(matrix);
	delete[] array;

	system("pause");
}

double** GenerateMatrix()
{
	double** matrix = new double* [6];
	for (int i = 0; i < 6; i++)
	{
		matrix[i] = new double [5];
	}

	srand(time(NULL));
	for (int i = 0; i < 6; i++)
	{
		for (int j = 0; j < 5; j++)
		{
			matrix[i][j] = round(100 * ((double)(rand() % 2001 - 1000) / (double)(rand() % 1000 + 1))) / 100.0;
		}
	}

	return matrix;
}

void FillAverageNegative(double* array, double** matrix)
{
	for (int i = 0; i < 6; i++)
	{
		array[i] = FindAvergeNegative(matrix, i);
	}
}

double FindAvergeNegative(double** matrix, int row)
{
	double sumOfNegative = 0;
	int numberOfNegative = 0;
	double averageNegative;

	for (int i = 0; i < 6; i++)
	{
		if (matrix[row][i] < 0)
		{
			sumOfNegative += matrix[row][i];
			numberOfNegative += 1;
		}
	}

	if (numberOfNegative == 0)
	{
		averageNegative = 0;
	}
	else
	{
		averageNegative = round(100 * sumOfNegative / numberOfNegative) / 100.0;
	}

	return averageNegative;
}

void SortBubbleDescent(double* array)
{
	double buffer;

	for (int i = 0; i < 6; i++)
	{
		for (int j = 0; j < 5 - i; j++)
		{
			if (array[j] < array[j + 1])
			{
				buffer = array[j];
				array[j] = array[j + 1];
				array[j + 1] = buffer;
			}
		}
	}
}

void OutputMatrix(double** matrix)
{
	for (int i = 0; i < 6; i++)
	{
		for (int j = 0; j < 5; j++)
		{
			std::cout << std::setw(7) << matrix[i][j];
		}
		std::cout << "\n";
	}
}

void OutputArray(double* array)
{
	for (int i = 0; i < 6; i++)
	{
		std::cout << array[i] << " ";
	}
	std::cout << "\n";
}

void DeleteMatrix(double** matrix)
{
	for (int i = 0; i < 6; i++)
	{
		delete(matrix[i]);
	}
	delete(matrix);
}