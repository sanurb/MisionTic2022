def print_board(field: str):
    print('---------')
    for i in range(3):
        print('| ' + ' '.join(field[3 * i:3 * i + 3]) + ' |')
    print('---------')


def state(field):
    """check the game status
    :type field: str
    :return: status: str [Draw, O wins, X wins]
    """
    for i in range(3):
        if field[3 * i] == field[3 * i + 1] == field[3 * i + 2]:
            return field[3 * i] + ' wins'
        if field[i] == field[i + 3] == field[i + 6]:
            return field[i] + ' wins'
    if field[0] == field[4] == field[8] or field[2] == field[4] == field[6]:
        return field[4] + ' wins'
    if ' ' in field:
        return ' '
    else:
        return 'Draw'


def get_input(field):
    """
    Receives user input and validates that it is a number in the range of 1 to 3, and if the field to occupy is empty
    :param field:str
    :return: index: int
    :raises ValueError: Raises an exception
    """
    x, y = [int(i) for i in input().split()]
    try:
        x = int(x) - 1
        y = int(y) - 1
    except ValueError:
        print('You should enter numbers!')
        return get_input(field)
    if x not in [0, 1, 2] or y not in [0, 1, 2]:
        print('Coordinates should be from 1 to 3!')
        return get_input(field)
    if field[3 * x + y] != ' ':
        print('This cell is occupied! Choose another one!')
        return get_input(field)
    return 3 * x + y


def main():
    field = '         '
    print(type(field))
    turn = 'X'
    print_board(field)
    while state(field).startswith(' '):
        pos = get_input(field)
        field = field[:pos] + turn + field[pos + 1:]
        turn = 'O' if turn == 'X' else 'X'
        print_board(field)
    print(state(field))


if __name__ == '__main__':
    main()
