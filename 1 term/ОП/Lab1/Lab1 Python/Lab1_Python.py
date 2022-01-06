import math

# Getting all needed values
radius = float(input("Enter the radius: "))
angle_A = float(input("Enter angle A: "))
angle_B = float(input("Enter angle B: "))
angle_C = float(input("Enter angle C: "))

# Calculating the sides
side_AB = 2 * radius * math.sin(angle_C)
side_AC = 2 * radius * math.sin(angle_B)
side_BC = 2 * radius * math.sin(angle_A)

# Outputing the results
print("Side AB is", side_AB)
print("Side AC is", side_AC)
print("Side BC is", side_BC)
