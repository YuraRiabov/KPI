#include <stdio.h>
#include <math.h>
#include <iostream>
using namespace std;

int main()
{
	// Initializing all needed variables
	int radius;
	double angle_A, angle_B, angle_C;
	double side_AB, side_AC, side_BC;

	// Getting all needed inputs
	cout << "Enter the radius: ";
	cin >> radius;
	cout << "Enter angle A: ";
	cin >> angle_A;
	cout << "Enter angle B: ";
	cin >> angle_B;
	cout << "Enter angle C: ";
	cin >> angle_C;

	// Calculating values of the sides
	side_AB = 2 * radius * sin(angle_C);
	side_AC = 2 * radius * sin(angle_B);
	side_BC = 2 * radius * sin(angle_A);

	// Outputting the answers
	cout << "Value of side AB is: " << side_AB << "\n";
	cout << "Value of side AC is: " << side_AC << "\n";
	cout << "Value of side BC is: " << side_BC << "\n";
}