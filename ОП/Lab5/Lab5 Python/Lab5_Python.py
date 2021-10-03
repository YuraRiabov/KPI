lowerBound = int(input("Enter the lower bound: ")) #Lower bound of the interval
upperBound = int(input("Enter the upper bound: ")) #Upper bound of the interval

devisorsNumber = 0 #Number of devisors of number, renews every iteration
devisorsSum = 0 #Sum of devisors of number, renews every iteration

for i in range(lowerBound, upperBound + 1) :
   print(f"Devisors of {i} are: ", end = "")
   for j in range(1, i+1) :
      if i % j == 0:
         print(f"{j} ", end = "")
         devisorsNumber += 1
         devisorsSum += j
   print(f"\nNumber of devisors of {i} is {devisorsNumber}")
   print(f"Sum of devisors of {i} is {devisorsSum}\n")
   devisorsNumber = 0
   devisorsSum = 0