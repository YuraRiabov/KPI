#define _USE_MATH_DEFINES

#include <iostream>
#include <functional>
#include <cmath>

void inputValues(double &a, double &b, int &n);
double integral(double a, double b, int n, std::function<double(double)> function);
double logarithm(double x);
double atanSquared(double x);
double solution(double a, double b, int n);

int main(void)
{
	double a; // Lower bound of second integral
	double b; // Upper bound of second integral
	int n; // Number of iterations in approximation
	double result; 

	inputValues(a,b,n);
	result = solution(a, b, n);
	std::cout << "The result is: " << result;
}

void inputValues(double &a, double &b, int &n)
{
	std::cout << "Enter a: ";
	std::cin >> a;
	std::cout << "Enter b: ";
	std::cin >> b;
	std::cout << "Enter n: ";
	std::cin >> n;
}

double integral(double a, double b, int n, std::function<double(double)> function) // Integral calculator
{
	double h = (b - a) / n;
	double integral = 0;
	for (int i = 1; i <= n; i++)
	{
		integral += h * function(a + i * h - h / 2);
	}
	return integral;
}

double logarithm(double x) // First function calculator
{
	double logarithm = log(2 + sin(x));
	return logarithm;
}

double atanSquared(double x) // Second function calculator
{
	double atanSquared = pow(atan(x), 2);
	return atanSquared;
}

double solution(double a, double b, int n)
{
	double result = integral(0.0, M_PI, n, logarithm) + integral(a, b, n, atanSquared);
	return result;
}