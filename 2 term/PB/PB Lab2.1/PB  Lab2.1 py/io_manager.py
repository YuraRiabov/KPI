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