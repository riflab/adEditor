'''

module      : read_edi_file
version     : 1.0
release     : 29 September 2021

author      : arif.darmawan@riflab.com
website     : www.riflab.com

input       : EDI file
output      : Pandas dataframe containing MT components

description : EDI file is the SEG Standard for Magnetotelluric Data

'''


import pandas as pd


def read_edi(file):
    # list_header = [
    #     'site_name', 'n_frequency'
    # ]

    list_variable = [
        '>FREQ',
        '>ZROT',
        '>ZXXR', '>ZXXI', '>ZXX.VAR',
        '>ZXYR', '>ZXYI', '>ZXY.VAR',
        '>ZYXR', '>ZYXI', '>ZYX.VAR',
        '>ZYYR', '>ZYYI', '>ZYY.VAR',
        '>RHOROT',
        '>RHOXY', '>RHOXY.ERR', '>RHOXY.FIT',
        '>RHOYX', '>RHOYX.ERR', '>RHOYX.FIT',
        '>RHOXX', '>RHOXX.ERR',
        '>RHOYY', '>RHOYY.ERR',
        '>PHSXY', '>PHSXY.ERR', '>PHSXY.FIT',
        '>PHSYX', '>PHSYX.ERR', '>PHSYX.FIT',
        '>PHSXX', '>PHSXX.ERR',
        '>PHSYY', '>PHSYY.ERR',
        '>TROT.EXP',
        '>TXR.EXP', '>TXI.EXP', '>TXVAR.EXP',
        '>TYR.EXP', '>TYI.EXP', '>TYVAR.EXP',
        '>TIPMAG', '>TIPMAG.VAR', '>TIPPHS',
        '>ZSTRIKE', '>ZSKEW', '>ZELLIP',
        '>TSTRIKE', '>TSKEW', '>TELLIP',
        '>INDMAGR.EXP', '>INDMAGI.EXP',
        '>INDANGR.EXP', '>INDANGI.EXP',
        '>END'
    ]
    df = pd.DataFrame()

    site_name = None
    n_frequency = None

    list_data = []

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
                # print(list_variable[ind])
                break

            if a[0] == list_variable[ind]:
                while len(list_data) < n_frequency:
                    temp = f.readline()
                    b = temp.split()
                    list_data += b

                # print(list_variable[ind], list_data)
                df[list_variable[ind]] = list_data
                ind += 1
                list_data = []

        temp = f.readline()

    print(site_name, n_frequency)
    print(df)

    return df
