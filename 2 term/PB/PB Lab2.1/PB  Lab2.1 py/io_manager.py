def get_text():
    text = []
    print("Enter text, to stop inputting press Enter twice")
    exit_character = ""
    keep_inputting = True
    while keep_inputting:
        line = str(input())
        if line == exit_character:
            keep_inputting = False
        else:
            text.append(line)
    return text


def ask_appending():
    writing_option = input("If yoy want to append to existing file press 'a', otherwise press Enter: ")
    if writing_option == "a":
        return True
    else:
        return False

