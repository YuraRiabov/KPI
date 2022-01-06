import math

number = float(input("Enter a number: "))

if number <= 1 :
   current_value = min(number, 0.95)
elif number > 1 and number < 25 :
   current_value = number / 5
else :
   current_value = number / 25

previous_value = 0 # Initializing previous value to be 0 in order for the first iteration to occur

while abs(current_value - previous_value) > 1e-4 :
   previous_value = current_value
   current_value = 0.8 * previous_value + number / (5 * pow(previous_value, 4))

print("The 5th power root of the number is ", current_value)
