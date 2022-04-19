import pickle


def read_all_clients(file_name):
    with open(file_name, 'rb') as file:
        try:
            while True:
                yield pickle.load(file)
        except EOFError:
            pass


def write_to_file(file_name, clients, writing_option):
    with open(file_name, writing_option) as file:
        pickle.dump(clients, file)


def get_free_time(file_name):
    clients = []
    for client in read_all_clients(file_name):
        for i in range(len(client)):
            clients.append(client[i])
    clients.sort(key=lambda x: get_minutes_from_time(x.coming_time))
    first_half = 0
    second_half = 0
    for i in range(len(clients)):
        start_minutes = get_minutes_from_time(clients[i].coming_time)
        end_minutes = get_minutes_from_time(clients[i].leaving_time)
        if i == 0:
            if start_minutes > 9 * 60:
                first_half += 1
            if start_minutes > 13 * 60:
                second_half += 1
            if len(clients) == 1:
                if end_minutes < 17 * 60:
                    second_half += 1
                if end_minutes < 13 * 60:
                    first_half += 1
        else:
            previous_start_minutes = get_minutes_from_time(clients[i - 1].coming_time)
            previous_end_minutes = get_minutes_from_time(clients[i - 1].leaving_time)
            if start_minutes > previous_end_minutes:
                if start_minutes > 13 * 60:
                    second_half += 1
                    if previous_end_minutes < 13 * 60:
                        first_half += 1
                else:
                    first_half += 1
            if i == len(clients) - 1:
                if end_minutes < 17 * 60:
                    second_half += 1
                if end_minutes < 13 * 60:
                    first_half += 1
    return first_half, second_half


def get_minutes_from_time(time):
    return int(time.split(":")[0]) * 60 + int(time.split(":")[1])
