from file_manager import *
from io_manager import *

if __name__ == "__main__":
    first_file_name = "first_file.txt"
    second_file_name = "second_file_txt"

    text = get_text()
    appending = ask_appending()
    write_to_file(first_file_name, text, appending)
    last_lines_number = int(input("Enter number of last lines to transfer: "))
    new_text = read_last_lines(first_file_name, last_lines_number)
    write_to_file(second_file_name, new_text, appending)
    print("Second file before removal:")
    output_text(read_all_lines(second_file_name))
    removed = remove_repeating_lines(second_file_name)
    print(f"Lines removed: {removed}")
    print("Second file after removal:")
    output_text(read_all_lines(second_file_name))

