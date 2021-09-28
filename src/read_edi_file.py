def check_float(val):
    try:
        float(val)
        return True
    except ValueError:
        return False


def read_edi(file):
    # list_header = [
    #     'site_name', 'n_frequency'
    # ]

    list_variable = [
        '>FREQ', '>ZROT',
        '>ZXXR', '>ZXXI', '>ZXX.VAR',
        '>ZXYR', '>ZXYI', '>ZXY.VAR',
        '>ZYXR', '>ZYXI', '>ZYX.VAR',
        '>ZYYR', '>ZYYI', '>ZYY.VAR',
        '>END'
    ]

    site_name = None
    n_frequency = None

    frequency = []

    f = open(file, 'r')
    temp = f.readline()
    ind = 0

    while True:
        a = temp.split()
        if len(a) > 0:

            if a[0][:6] == 'DATAID':
                site_name = a[0].split('"')[1]

            if a[0][:5] == 'NFREQ':
                n_frequency = int(a[0].split('=')[1])

            if a[0] == list_variable[-1]:
                print('break', list_variable[ind])
                break

            if a[0] == list_variable[ind]:
                print(list_variable[ind])

                while len(frequency) < n_frequency:
                    temp = f.readline()
                    b = temp.split()
                    frequency += b
                    print(list_variable[ind], len(frequency), b)
                ind += 1
                frequency = []

        temp = f.readline()

    print(site_name, n_frequency, frequency)
