def write_to_file(file_name, text, appending):
    if appending:
        file = open(file_name, 'a')
        text = "\n" + text
    else:
        file = open(file_name, 'w')
    file.writelines(text)
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
    return "\n".join(new_text)


def read_all_lines(file_name):
    with open(file_name) as file:
        text = file.readlines()
    text_string = ''.join(text)
    text = text_string.split("\n")
    return text


def remove_repeating_lines(file_name):
    text = read_all_lines(file_name)
    removed = 0
    i = 0
    while i < len(text):
        count = 0
        current_line = text[i]
        for line in text:
            if line == text[i]:
                count += 1
        if count > 1:
            removed += count
            for j in range(count):
                text.remove(current_line)
            i = 0
        else:
            i += 1
    write_to_file(file_name, "\n".join(text), False)
    return removed

