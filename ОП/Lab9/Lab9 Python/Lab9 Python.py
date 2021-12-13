def delete_even(array):
    for i in range(len(array) - 1, -1, -1):
        if i % 2 == 1:
            array.pop(i)


def find_longest(array):
    longest_word = array[0]
    for i in array:
        if len(i) > len(longest_word):
            longest_word = i
    return longest_word


line = input("Enter line: ")
list_of_words = line.split(" ")
delete_even(list_of_words)
longest = find_longest(list_of_words)
new_string = " ".join(list_of_words)
print(f"New line: {new_string}")
print(f"Longest word in odd position: {longest}")
