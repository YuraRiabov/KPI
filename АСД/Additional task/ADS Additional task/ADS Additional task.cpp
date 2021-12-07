#include <iostream>

double FindSum(int n);
double FindA(int index);
double FindB(int index);
double FindFactorial(int index);

int main()
{
	int n;
	double sum = 0;

	std::cout << "Enter n(positive whole number): ";
	std::cin >> n;

	sum = FindSum(n);

	std::cout << "\nThe sum is: " << sum;
}

double FindSum(int n)
{
	double sum = 0;
	for (int k = 0; k < n; k++)
	{
		sum += (FindA(k) - FindB(k)) / FindFactorial(k + 1);
	}
	return sum;
}

double FindA(int index)
{
	double result;
	if (index == 0)
	{
		result = 1;
	}
	else
	{
		result = 0.5 * (sqrt(FindB(index - 1)) + 5 * sqrt(FindA(index - 1)));
	}
	return result;
}

double FindB(int index)
{
	double result;
	if (index == 0)
	{
		result = 1;
	}
	else
	{
		result = 2 * FindA(index - 1) * FindA(index - 1) + FindB(index - 1);
	}
	return result;
}

double FindFactorial(int index)
{
	double result;
	if (index == 0 || index == 1)
	{
		result = 1;
	}
	else
	{
		result = index * FindFactorial(index - 1);
	}
	return result;
}