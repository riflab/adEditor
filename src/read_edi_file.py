def check_float(val):
    try:
        float(val)
        return True
    except ValueError:
        return False


def read_edi(file):
    list_variable = [
        '>FREQ', '>ZROT',
        '>ZXXR', '>ZXXI', '>ZXX.VAR',
        '>ZXYR', '>ZXYI', '>ZXY.VAR',
        '>ZYXR', '>ZYXI', '>ZYX.VAR',
        '>ZYYR', '>ZYYI', '>ZYY.VAR',
    ]
    f = open(file, 'r')
    temp = f.readline()
    count = 0

    while True:

        if temp == '':
            break

        a = (temp.split())

        if len(a) > 0:
            if a[0] == list_variable[count]:

                print(list_variable[count])
                while True:
                    try:
                        temp = f.readline().split()
                        b = float(temp[0])
                        print(b, count, temp[0])
                    except ValueError:
                        print("BREAK")
                        break
                count += 1
        temp = f.readline()

