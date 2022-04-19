from io_manager import *
from file_manager import *

if __name__ == '__main__':
    file_name = "clients.txt"

    writing_option = ask_writing_option()
    clients = input_clients(file_name)
    write_to_file(file_name, clients, writing_option)
    print("Schedule:")
    output_clients(file_name)
    print_free_time(file_name)

