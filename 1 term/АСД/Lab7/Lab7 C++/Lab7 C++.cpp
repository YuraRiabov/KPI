#include <iostream>
#include <vector>

void FillVectors(std::vector<char>& vect1, std::vector<char>& vect2);
void OutputVector(const std::vector<char>& vect);
void FillWithCommon(const std::vector<char>& vect1, const std::vector<char>& vect2, std::vector<char>& vect3);
int FindMaxCode(const std::vector<char>& vect);
void OutputLessThan(const std::vector<char>& vect, int num);

int main()
{
	std::vector<char> firstVector(10), secondVector(10), thirdVector(10);
	int maxCode;

	FillVectors(firstVector, secondVector);

	std::cout << "First array: ";
	OutputVector(firstVector);
	std::cout << "Second array: ";
	OutputVector(secondVector);

	FillWithCommon(firstVector, secondVector, thirdVector);

	std::cout << "Third array: ";
	OutputVector(thirdVector);

	maxCode = FindMaxCode(thirdVector);

	std::cout << "Result: ";
	OutputLessThan(thirdVector, maxCode);

	system("pause");
}

void FillVectors(std::vector<char>& vect1, std::vector<char>& vect2)
{
	for (int i = 1; i < 11; i++)
	{
		vect1[i-1] = (char)(2 * i + 42);
		vect2[i-1] = (char)(54 - 2 * i);
	}
}

void OutputVector(const std::vector<char>& vect)
{
	int size = vect.size();
	for (int i = 0; i < size; i++)
	{
		std::cout << vect[i] << " ";
	}
	std::cout << "\n";
}

void FillWithCommon(const std::vector<char>& vect1, const std::vector<char>& vect2, std::vector<char>& vect3)
{
	char currentFirst, currentSecond;
	int k = 0;
	for (int i = 0; i < 10; i++)
	{
		currentFirst = vect1[i];
		for (int j = 0; j < 10; j++)
		{
			currentSecond = vect2[j];
			if (currentFirst == currentSecond)
			{
				vect3[k] = currentSecond;
				k++;
			}
		}
	}
}

int FindMaxCode(const std::vector<char>& vect)
{
	int maxCode = (int)vect[0];
	int size = vect.size();

	for (int i = 1; i < size; i++)
	{
		if ((int)vect[i] > maxCode)
		{
			maxCode = (int)vect[i];
		}
	}

	return maxCode;
}

void OutputLessThan(const std::vector<char>& vect, int num)
{
	int size = vect.size();
	for (int i = 0; i < size; i++)
	{
		if ((int)vect[i] < num)
		{
			std::cout << vect[i] << " ";
		}
	}
	std::cout << "\n";
}