from Prism3 import Prism3
from Prism4 import Prism4
from Prism import Prism


def get_prisms():
    prism_count = int(input("Enter number of prisms you want to enter: "))
    i = 0
    prisms = []
    while i < prism_count:
        line = input("Enter a prism in format: side number(3 or 4) side length height: ")
        members = line.split(" ")
        if len(members) == 3:
            if int(members[0]) == 3:
                prisms.append(Prism3(float(members[1]), float(members[2])))
                i += 1
            elif int(members[0]) == 4:
                prisms.append(Prism4(float(members[1]), float(members[2])))
                i += 1
            else:
                print("Wrong number of sides, try again")
        else:
            print("Something went wrong, try again")
    return prisms

def get_volume_surface_data(prisms):
    volume_sum = 0
    surface_sum = 0
    for prism in prisms:
        if type(prism) is Prism3:
            volume_sum += prism.calculate_volume()
        elif type(prism) is Prism4:
            surface_sum += prism.calculate_surface()
    print(f"Sum of volumes of triangular prisms is {volume_sum}")
    print(f"Sum of surfaces of square prisms is {surface_sum}")

