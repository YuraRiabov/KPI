string = input("Enter a string: ") # Initial line of words

stringList = string.split(" ") # List of words in the line
i = len(stringList) - 1 # Index of last word in the line

while i >= 0:
    if i % 2 == 1:
        stringList.pop(i)
    i -= 1
longest = "" # Longest word in odd position

for i in stringList:
    if len(i) > len(longest):
        longest = i

newString = " ".join(stringList) # Line after removal of even elements

print("New string is: ", newString)
print("The longest word in odd position is ", longest)