#include <iostream>
#include <cmath>
using namespace std;

int main()
{
	// Declaring all needed variables
	double x;
	double y;


	// Getting all needed inputs
	cout << "Enter x coordinate: ";
	cin >> x;
	cout << "Enter y coordinate: ";
	cin >> y;

	// Cheking if point is in area
	if (pow(x, 2) + pow(y, 2) > 1)
	{
		cout << "Point doesn't belong to the area";
	}
	else
	{
		if (x > 0 && y > 0 && y >= -x + 1.0)
		{
			cout << "Point belongs to the area";
		}
		else if (x <= 0 && y >= 0 && y <= x + 1.0)
		{
			cout << "Point belongs to the area";
		}
		else if (x < 0 && y < 0 && y <= -x - 1.0)
		{
			cout << "Point belongs to the area";
		}
		else if (x >= 0 && y <= 0 && y >= x - 1.0)
		{
			cout << "Point belongs to the area";
		}
		else
		{
			cout << "Point doesn't belong to the area";
		}
	}
}

