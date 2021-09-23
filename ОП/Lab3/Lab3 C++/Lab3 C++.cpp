#include <iostream>
#include <cmath>
using namespace std;

int main()
{
	double number;
	double previous_value;
	double current_value;

	cout << "Enter a number: ";
	cin >> number;

	if (number <= 1)
	{
		current_value = min(2 * number, 0.95);
	}
	else if (number > 1 && number < 25)
	{
		current_value = number / 5;
	}
	else
	{
		current_value = number / 25;
	}

	do
	{
		previous_value = current_value;
		current_value = 0.8 * previous_value + number / (5 * pow(previous_value, 4));
	} while (abs(current_value - previous_value) > 1e-4);
	
	cout << "The 5th power root of the number is " << current_value;
}