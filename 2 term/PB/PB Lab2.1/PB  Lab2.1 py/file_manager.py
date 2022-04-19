def write_to_file(file_name, text):
    writing_option = input("If yoy want to append to existing file press 'a', otherwise press Enter: ")
    if writing_option == 'a':
        file = open(file_name, 'a')
        file.write("\n" + text[0])
    else:
        file = open(file_name, 'w')
        file.write(text[0])
    for i in range(1, len(text)):
        file.write("\n" + text[i])
    file.close()