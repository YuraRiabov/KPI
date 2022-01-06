#include <iostream>
#include <ctime>
#include <iomanip>

double** GenerateMatrix(int size);
void FindLastPositive(double** matrix, int size, double& lastPositive, int& lastPositiveRow, int& lastPositiveColumn);
void MoveUp(double** matrix, int size, int column, double& lastPositive, int& lastPositiveRow, int& lastPositiveColumn);
void MoveDown(double** matrix, int size, int column, double& lastPositive, int& lastPositiveRow, int& lastPositiveColumn);
int FindNumberAboveMore(double** matrix, int size, double lastPositive);
void OutputMatrix(double** matrix, int size);
void DeleteMatrix(double** matrix, int size);


int main()
{
	double** matrix;
	int size;
	double lastPositive;
	int lastPositiveRow;
	int lastPositiveColumn;
	int numberAboveMore;

	std::cout << "Enter matrix size: ";
	std::cin >> size;
	
	matrix = GenerateMatrix(size);
	std::cout << "Generated matrix:\n";
	OutputMatrix(matrix, size);

	FindLastPositive(matrix, size, lastPositive, lastPositiveRow, lastPositiveColumn);
	std::cout << "\nLast positive element: " << lastPositive << "\nIt's row and column: " << lastPositiveRow << ", " << lastPositiveColumn;

	numberAboveMore = FindNumberAboveMore(matrix, size, lastPositive);
	std::cout << "\nNumber of elements above not main diagonal more than last positive element: " << numberAboveMore << "\n";

	DeleteMatrix(matrix, size);

	system("pause");
}

double** GenerateMatrix(int size)
{
	double** matrix = new double*[size];
	for (int i = 0; i < size; i++)
	{
		matrix[i] = new double[size];
	}

	srand(time(NULL));
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			matrix[i][j] = (double)(rand() % 20000 - 10000) / 100.0;
		}
	}

	return matrix;
}

void FindLastPositive(double** matrix, int size, double& lastPositive, int& lastPositiveRow, int& lastPositiveColumn)
{
	for (int j = 0; j < size; j++)
	{
		if (j % 2 == 0)
		{
			MoveDown(matrix, size, j, lastPositive, lastPositiveRow, lastPositiveColumn);
		}
		else
		{
			MoveUp(matrix, size, j, lastPositive, lastPositiveRow, lastPositiveColumn);
		}
	}
}

void MoveUp(double** matrix, int size, int column, double& lastPositive, int& lastPositiveRow, int& lastPositiveColumn)
{
	for (int i = size - 1; i >= 0; i--)
	{
		if (matrix[i][column] > 0)
		{
			lastPositive = matrix[i][column];
			lastPositiveRow = i;
			lastPositiveColumn = column;
		}
	}
}

void MoveDown(double** matrix, int size, int column, double& lastPositive, int& lastPositiveRow, int& lastPositiveColumn)
{
	for (int i = 0; i < size; i++)
	{
		if (matrix[i][column] > 0)
		{
			lastPositive = matrix[i][column];
			lastPositiveRow = i;
			lastPositiveColumn = column;
		}
	}
}

int FindNumberAboveMore(double** matrix, int size, double lastPositive)
{
	int numberAboveMore = 0;

	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			if (i + j < size - 1 && matrix[i][j] > lastPositive)
			{
				numberAboveMore++;
			}
		}
	}

	return numberAboveMore;
}

void OutputMatrix(double** matrix, int size)
{
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			std::cout << std::setw(7) << matrix[i][j];
		}
		std::cout << "\n";
	}
}

void DeleteMatrix(double** matrix, int size)
{
	for (int i = 0; i < size; i++)
	{
		delete[] matrix[i];
	}
	delete[] matrix;
}