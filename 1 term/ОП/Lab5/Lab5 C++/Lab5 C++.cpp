#include <iostream>
using namespace std;

int main()
{
	int lowerBound; // Lower bound of the interval, input
	int upperBound; // Upper bound of the interval, input
	int devisorsNumber; // Number of devisors of number, renews every iteration
	int devisorsSum; // Sum of devisors of number, renews every iteration

	cout << "Enter the lower bound: ";
	cin >> lowerBound;
	cout << "Enter the upper bound: ";
	cin >> upperBound;

	devisorsNumber = 0;
	devisorsSum = 0;

	for (int i = lowerBound; i <= upperBound; i++)
	{
		cout << "Devisors of " << i << " are: ";
		for (int j = 1; j <= i; j++)
		{
			if (i % j == 0)
			{
				cout << j << " ";
				devisorsNumber += 1;
				devisorsSum += j;
			}
		}
		cout << "\n" << "Number of devisors of " << i << " is " << devisorsNumber;
		cout << "\n" << "Sum of devisors of " << i << " is " << devisorsSum << "\n \n";
		devisorsNumber = 0;
		devisorsSum = 0;
	}
}
