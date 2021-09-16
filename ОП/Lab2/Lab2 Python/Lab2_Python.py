
x = float(input("Enter x coordinate: "))
y = float(input("Enter y coordinate: "))

if pow(x, 2) + pow(y, 2) > 1 :
    print("Point doesn't belong to the area")
else :
    if x > 0 and y > 0 and y >= - x + 1.0 :
        print("Point belongs to the area")
    elif x <= 0 and y >= 0 and y <= x + 1.0 :
        print("Point belongs to the area")
    elif x < 0 and y < 0 and y <= - x - 1.0 :
        print("Point belongs to the area")
    elif x >= 0 and y <= 0 and y > x - 1.0 :
        print("Point belongs to the area")
    else :
        print("Point doesn't belong to the area")