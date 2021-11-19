#include <iostream>
#include <iomanip>
#include <cmath>
#include <vector>
using namespace std;

void moveDiagonallyUp(vector<vector<int>> &matrix, int &currentNumber, int &i, int &j, int& size);
void moveDiagonallyDown(vector<vector<int>> &matrix, int &currentNumber, int &i, int &j, int& size);
void outputArray(vector<vector<int>> matrix);

int main()
{
	int matrixSize; // Size of a matrix we wanna create
	int elementsNumber; // Total number of elements in the matrix
	int currentNumber; // Current number which is being put in the matrix
	int i; // Current line of the matrix
	int j; // Current column of the matrix

	cout << "Enter matrix size: ";
	cin >> matrixSize;

	vector<vector<int>>matrix(matrixSize, vector<int>(matrixSize)); // Emty matrix of needed size

	elementsNumber = (int)pow(matrixSize, 2);
	matrix[0][0] = elementsNumber;
	currentNumber = elementsNumber - 1;
	i = 0;
	j = 0;

	while (currentNumber > 0)
	{
		if (i == 0 && j != matrixSize - 1)
		{
			j += 1;
			moveDiagonallyDown(matrix, currentNumber, i, j, matrixSize);
		}
		else if (j == 0 && i != matrixSize - 1)
		{
			i += 1;
			moveDiagonallyUp(matrix, currentNumber, i, j, matrixSize);
		}
		else if (j == matrixSize - 1)
		{
			i += 1;
			moveDiagonallyDown(matrix, currentNumber, i, j, matrixSize);
		}
		else if (i == matrixSize - 1)
		{
			j += 1;
			if (currentNumber != 1)
			{
				moveDiagonallyUp(matrix, currentNumber, i, j, matrixSize);
			}
			else
			{
				matrix[i][j] = 1;
				currentNumber -= 1;
			}
		}
	}

	outputArray(matrix);
	cout << "Corner elements of the matrix: " << matrix[0][0] << " " << matrix[matrixSize - 1][0] << " " << matrix[0][matrixSize - 1] << " " << matrix[matrixSize - 1][matrixSize - 1];
	cout << "\nMaximum corner element of the matrix: " << matrix[0][0];
}

// Function which fills a diagonal with decreasing values from bottom to top moving to the right
void moveDiagonallyUp(vector<vector<int>> &matrix, int& currentNumber, int& i, int& j, int& size)
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
void moveDiagonallyDown(vector<vector<int>> &matrix, int& currentNumber, int& i, int& j, int& size)
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
void outputArray(vector<vector<int>> matrix)
{
	for (int i = 0; i < matrix.size(); i++)
	{
		for (int j = 0; j < matrix.size(); j++)
		{
			cout << setw(4) << matrix[i][j];
		}
		cout << "\n";
	}
}