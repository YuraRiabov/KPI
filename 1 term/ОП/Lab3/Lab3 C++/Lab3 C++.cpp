#include <iostream>
#include <cmath>
using namespace std;

int main()
{
	double number; // input number
	double previous_value; // previos value of root, needed to calculate margin
	double current_value; // current value of root, output

	// Input of number
	cout << "Enter a number: ";
	cin >> number;

	// Asigning current value based on input
	if (number <= 1){
		current_value = min(2 * number, 0.95);
	}else if (number > 1 && number < 25){
		current_value = number / 5;
	}else{
		current_value = number / 25;
	}

	// Calculating the root
	do{
		previous_value = current_value;
		current_value = 0.8 * previous_value + number / (5 * pow(previous_value, 4));
	} while (abs(current_value - previous_value) > 1e-4);
	
	cout << "The 5th power root of the number is " << current_value;
}