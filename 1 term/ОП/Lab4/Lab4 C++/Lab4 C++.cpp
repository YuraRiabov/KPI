#include <iostream>
#include <cmath>
using namespace std;

int main()
{
	int n; // Number of iterations, input
	int currentFirstNumber; // First number in formula, defined every iteration
	int currentSecondNumber; // Second number in formula, defined every iteration
	int sum; // Sum, output

	cout << "Enter a number: ";
	cin >> n;

	sum = 0; // At the beginning of cycle sum is 0


	for (int i = 1; i <= n; i++)
	{
		if (i % 2 == 1)
		{
			currentFirstNumber = i;
			currentSecondNumber = pow(i, 2);
		}
		else
		{
			currentFirstNumber = i / 2;
			currentSecondNumber = i + 7;
		}
		sum += pow(currentFirstNumber - currentSecondNumber, 2);
	}

	cout << "The sum is " << sum;
}
