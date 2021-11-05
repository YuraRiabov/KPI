import math

def inputValues():
    a = float(input("Enter a: "))
    b = float(input("Enter b: "))
    n = int(input("Enter n: "))
    return a, b, n

def integral(a, b, n, function):
    integral = 0
    h = (b - a) / n
    for i in range(1, n + 1):
        integral += h * function(a + h * i - h / 2)
    return integral

def logarithm(x):
    logarithm = math.log(2 + math.sin(x))
    return logarithm

def atanSquared(x):
    atanSquared = pow(math.atan(x), 2)
    return atanSquared

def solution(a, b, n):
    result = integral(0, math.pi, n, logarithm) + integral(a, b, n, atanSquared)
    return result

a, b, n = inputValues()
result = solution(a, b, n)
print("The result is ", result)