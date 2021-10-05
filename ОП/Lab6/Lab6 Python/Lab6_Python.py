import math

def integral(a, b, n, function):
    integral = 0
    h = (b - a) / n
    for i in range(1, n + 1):
        integral += h * function(a + h * i - h / 2)
    return integral

def logarithm(x):
    return math.log(2 + math.sin(x))

def atanSquared(x):
    return pow(math.atan(x), 2)

a = float(input("Enter a: "))
b = float(input("Enter b: "))
n = int(input("Enter n: "))

result = integral(0, math.pi, n, logarithm) + integral(a, b, n, atanSquared)

print("The result is ", result)