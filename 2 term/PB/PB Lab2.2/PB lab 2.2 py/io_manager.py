from Client import *
from file_manager import *


def input_clients(file_name, writing_option):
    old_clients = []
    new_clients = []
    if writing_option == 'ab':
        try:
            for client in read_all_clients(file_name):
                for i in range(len(client)):
                    old_clients.append(client[i])
        except FileNotFoundError:
            pass
    character = input("If you want to add client, press a, otherwise press Enter: ")
    while character == 'a':
        name = input("Enter client's name: ")
        coming_time = input("Enter coming time(hh:mm): ")
        leaving_time = input("Enter leaving time(hh:mm): ")
        client = Client(name, coming_time, leaving_time)
        if check_client(coming_time, leaving_time, old_clients) and check_client(coming_time, leaving_time, new_clients):
            new_clients.append(client)
            print("Added successfully")
        else:
            print("Wrong time entered, client wasn't added")
        character = input("If you want to add client, press a, otherwise press Enter: ")
    return new_clients


def output_clients(file_name):
    clients = []
    for client in read_all_clients(file_name):
        for i in range(len(client)):
            clients.append(client[i])
    clients.sort(key=lambda x: get_minutes_from_time(x.coming_time))
    for client in clients:
        print(f"{client.name}: {client.coming_time} - {client.leaving_time}")


def ask_writing_option():
    writing_option = input("If you want to append existing file, press a, otherwise press Enter: ")
    if writing_option == 'a':
        return 'ab'
    else:
        return 'wb'


def print_free_time(file_name):
    first_half, second_half = get_free_time(file_name)
    print(f"Number of free periods in the first half of the day: {first_half}")
    print(f"Number of free periods in the second half of the day: {second_half}")


def check_client(coming_time, leaving_time, clients):
    coming_minutes = get_minutes_from_time(coming_time)
    leaving_minutes = get_minutes_from_time(leaving_time)
    if (coming_minutes > leaving_minutes or
        coming_minutes < 9 * 60 or
        leaving_minutes > 17 * 60):
        return False
    for client in clients:
        current_coming_minutes = get_minutes_from_time(client.coming_time)
        current_leaving_minutes = get_minutes_from_time(client.leaving_time)
        if (coming_minutes < current_leaving_minutes < leaving_minutes or
            coming_minutes < current_coming_minutes < leaving_minutes or
            coming_minutes < current_coming_minutes and current_leaving_minutes < leaving_minutes
            ):
            return False
    return True


def get_minutes_from_time(time):
    return int(time.split(":")[0]) * 60 + int(time.split(":")[1])

