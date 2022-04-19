def write_to_file(file_name, text, appending):
    if appending:
        file = open(file_name, 'a')
        file.write("\n" + text[0])
    else:
        file = open(file_name, 'w')
        file.write(text[0])
    for i in range(1, len(text)):
        file.write("\n" + text[i])
    file.close()


def read_last_lines(file_name, number):
    text = read_all_lines(file_name)
    if len(text) - number > 0:
        starting_index = len(text) - number
    else:
        starting_index = 0
    new_text = []
    for i in range(starting_index, len(text)):
        new_text.append(text[i])
    return new_text


def read_all_lines(file_name):
    with open(file_name) as file:
        text = []
        for line in file:
            text.append(line)
    return text

