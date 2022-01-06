def split_string(string):
    array = []
    buffer = ""
    for i in range(len(line)):
        if string[i] == " ":
            array.append(buffer)
            buffer = ""
        else:
            buffer += string[i]
    array.append(buffer)
    return array


def delete_element(array, index):
    for i in range(index + 1, len(array)):
        array[i - 1] = array[i]
    array.pop()


def delete_even(array):
    for i in range(len(array) - 1, -1, -1):
        if i % 2 == 1:
            delete_element(array, i)


def find_longest(array):
    longest_word = array[0]
    for i in array:
        if len(i) > len(longest_word):
            longest_word = i
    return longest_word


def join_to_string(array):
    string = ""
    for i in range(len(array) - 1):
        string += array[i] + " "
    string += array[len(array) - 1]
    return string


if '__name__ = __main__':
    line = input("Enter line: ")
    list_of_words = split_string(line)
    delete_even(list_of_words)
    longest = find_longest(list_of_words)
    new_string = join_to_string(list_of_words)
    print(f"New line: {new_string}")
    print(f"Longest word in odd position: {longest}")
