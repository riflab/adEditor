"""

This module contains functions for calculate

    Apparent Resistivity
    Phase

arif.darmawan@riflab.com

"""

import numpy as np


def data_preparation(df):

    df['>ZXYR'] = df['>ZXYR'].abs()
    df['>ZXYI'] = df['>ZXYI'].abs()
    # self.df['>ZYXR'] = self.df['>ZYXR'].abs()
    # self.df['>ZYXI'] = self.df['>ZYXI'].abs()

    df['>RHOROT'] = 0.0

    ''' calculate apparent resistivity '''
    df['>RHOXX'] = cal_app_rho(df['>FREQ'], df['>ZXXR'], df['>ZXXI'])
    df['>RHOXX.ERR'] = 0.0
    df['>RHOXY'] = cal_app_rho(df['>FREQ'], df['>ZXYR'], df['>ZXYI'])
    df['>RHOXY.ERR'] = 0.0
    df['>RHOYX'] = cal_app_rho(df['>FREQ'], df['>ZYXR'], df['>ZYXI'])
    df['>RHOYX.ERR'] = 0.0
    df['>RHOYY'] = cal_app_rho(df['>FREQ'], df['>ZYYR'], df['>ZYYI'])
    df['>RHOYY.ERR'] = 0.0

    ''' calculate phase '''
    df['>PHSXX'] = cal_pha(df['>ZXXR'], df['>ZXXI'])
    df['>PHSXX.ERR'] = 0.0
    df['>PHSXY'] = cal_pha(df['>ZXYR'], df['>ZXYI'])
    df['>PHSXY.ERR'] = 0.0
    df['>PHSYX'] = cal_pha(df['>ZYXR'], df['>ZYXI'])
    df['>PHSYX.ERR'] = 0.0
    df['>PHSYY'] = cal_pha(df['>ZYYR'], df['>ZYYI'])
    df['>PHSYY.ERR'] = 0.0

    return df


def cal_app_rho(freq, real, imaginary):
    app_rho = (1 / (2 * np.pi * np.pi * 0.25 * freq)) * (imaginary ** 2 + real ** 2)

    return app_rho


def cal_pha(real, imaginary, deg=0):
    pha = ((np.arctan2(imaginary, real)) / np.pi * 180) - deg

    return pha
