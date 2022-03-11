"""

This module contains functions for calculate

    Apparent Resistivity
    Phase

arif.darmawan@riflab.com

"""

import numpy as np


def cal_app_rho(freq, real, imaginary):
    app_rho = (1 / (2 * np.pi * np.pi * 0.25 * freq)) * (imaginary ** 2 + real ** 2)

    return app_rho


def cal_pha(real, imaginary):
    pha = (np.arctan(imaginary / real)) / np.pi * 180

    return pha
