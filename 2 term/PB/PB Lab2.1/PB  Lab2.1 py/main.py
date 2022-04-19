from file_manager import *
from io_manager import *

if __name__ == "__main__":
    first_file_name = "first_file.txt"
    second_file_name = "second_file_txt"

    text = get_text()
    write_to_file(first_file_name, text)
    last_lines_number = int(input("Enter number of last lines to transfer: "))