#include <iostream>
#include <cmath>

long double recursiveRoot(int a);
long double factorial(int num);


int main()
{
	int m; // Lower bound of the sum, input
	int n; // Upper bound of the sum, input
	long double sum = 0; // Sum, result

	do {
		std::cout << "Enter the first number: ";
		std::cin >> m;
		std::cout << "Enter a larger number: ";
		std::cin >> n;
	} while (n < m || n < 1 || m < 0);

	for (int k = m; k <= n; k++) {
		sum += pow(-1, k) * pow((recursiveRoot(k) + 2) / 3, k) / factorial(k);
	}

	std::cout << "The sum is: " << sum;
}

// Function which calculates a root which diverges to 2 + sqrt(6) using recursion
long double recursiveRoot(int a)
{
	long double result;
	if (a == 0) {
		result = 1;
	}
	else {
		result = sqrt(4 * recursiveRoot(a - 1) + 2);
	}
	return result;
}

// Function which calculates factorial via recursion
long double factorial(int num)
{
	long double result;
	if (num == 1 || num == 0) {
		result = 1.0;
	}
	else {
		result = (long double)(num * factorial(num - 1));
	}
	return result;
}