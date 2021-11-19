#include <iostream>
#include <iomanip>
#include <cmath>
#include <vector>
using namespace std;

int** CreateMatrix(int rowNumber, int columnNumber);
void MoveDiagonallyUp(int** matrix, int& currentNumber, int& i, int& j, int size);
void MoveDiagonallyDown(int** matrix, int& currentNumber, int& i, int& j, int size);
void OutputMatrix(int** matrix, int rowNumber, int columnNumber);

int main()
{
	int matrixSize; // Size of a matrix we wanna create
	int** matrix;
	int currentNumber; // Current number which is being put in the matrix
	int i; // Current line of the matrix
	int j; // Current column of the matrix

	cout << "Enter matrix size: ";
	cin >> matrixSize;

	matrix = CreateMatrix(matrixSize, matrixSize);

	matrix[0][0] = (int)pow(matrixSize, 2);
	currentNumber = matrix[0][0] - 1;
	i = 0;
	j = 0;

	while (currentNumber > 0)
	{
		if (i == 0 && j != matrixSize - 1)
		{
			j += 1;
			MoveDiagonallyDown(matrix, currentNumber, i, j, matrixSize);
		}
		else if (j == 0 && i != matrixSize - 1)
		{
			i += 1;
			MoveDiagonallyUp(matrix, currentNumber, i, j, matrixSize);
		}
		else if (j == matrixSize - 1)
		{
			i += 1;
			MoveDiagonallyDown(matrix, currentNumber, i, j, matrixSize);
		}
		else if (i == matrixSize - 1)
		{
			j += 1;
			if (currentNumber != 1)
			{
				MoveDiagonallyUp(matrix, currentNumber, i, j, matrixSize);
			}
			else
			{
				matrix[i][j] = 1;
				currentNumber -= 1;
			}
		}
	}

	OutputMatrix(matrix, matrixSize, matrixSize);
	cout << "Corner elements of the matrix: " << matrix[0][0] << " " << matrix[matrixSize - 1][0] << " " << matrix[0][matrixSize - 1] << " " << matrix[matrixSize - 1][matrixSize - 1];
	cout << "\nMaximum corner element of the matrix: " << matrix[0][0];

	system("pause");
}

int** CreateMatrix(int rowNumber, int columnNumber)
{
	int** matrix = new int* [rowNumber];
	for (int i = 0; i < rowNumber; i++)
	{
		matrix[i] = new int[columnNumber];
	}
	return matrix;
}

// Function which fills a diagonal with decreasing values from bottom to top moving to the right
void MoveDiagonallyUp(int** matrix, int& currentNumber, int& i, int& j, int size)
{
	for (i, j; i >= 0 && j <= size - 1; i--, j++)
	{
		matrix[i][j] = currentNumber;
		currentNumber -= 1;
	}
	i++;
	j--;
}

// Function which fills a diagonal with decreasing values from top to bottom moving to the left
void MoveDiagonallyDown(int** matrix, int& currentNumber, int& i, int& j, int size)
{
	for (i, j; i <= size - 1 && j >= 0; i++, j--)
	{
		matrix[i][j] = currentNumber;
		currentNumber -= 1;
	}
	i--;
	j++;
}

// Function which outputs a matrix
void OutputMatrix(int** matrix, int rowNumber, int columnNumber)
{
	for (int i = 0; i < rowNumber; i++)
	{
		for (int j = 0; j < columnNumber; j++)
		{
			cout << setw(4) << matrix[i][j];
		}
		cout << "\n";
	}
}