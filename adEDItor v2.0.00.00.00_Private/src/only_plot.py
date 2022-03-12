import sys
from PyQt5 import QtWidgets
from matplotlib.figure import Figure
from matplotlib.backends.backend_qt5agg import FigureCanvasQTAgg
from matplotlib.backends.backend_qt5agg import FigureManagerQT
# from read_edi_file import read_edi
from configure import plot_setting
from calculation import *


class MyFigureCanvas(FigureCanvasQTAgg):
    def __init__(self, df, header):
        super(MyFigureCanvas, self).__init__(Figure(tight_layout=True))

        # init status
        # self.status_1i = False
        # self.status_1r = False
        # self.status_2 = False
        # self.status_3 = False
        # self.click_sta = False

        # init class attributes
        # self.background_1 = None
        # self.background_2 = None
        # self.background_3 = None
        # self.index_of_frequency = None
        # self.marker_size = 6

        # init data parameter
        self.df = df
        self.header = header
        # self.real = real
        # self.imaginary = imaginary
        # self.rho = rho
        # self.phs = phs

        # c = None
        # self.deg = None
        # marker = None
        # if label == 'XX':
        #     c = 'gold'
        #     marker = '.'
        #     self.deg = 0
        # elif label == 'XY':
        #     c = 'r'
        #     marker = '.'
        #     self.deg = 0
        # elif label == 'YX':
        #     c = 'b'
        #     marker = '.'
        #     self.deg = 180
        # elif label == 'YY':
        #     c = 'lime'
        #     marker = '.'
        #     self.deg = 0
        #
        # # self.df['>ZXXR'] = self.df['>ZXXR'].abs()
        # # self.df['>ZXXI'] = self.df['>ZXXI'].abs()
        # self.df['>ZXYR'] = self.df['>ZXYR'].abs()
        # self.df['>ZXYI'] = self.df['>ZXYI'].abs()
        # self.df['>ZYXR'] = self.df['>ZYXR'].abs()
        # self.df['>ZYXI'] = self.df['>ZYXI'].abs()
        # # self.df['>ZYYR'] = self.df['>ZYYR'].abs()
        # # self.df['>ZYYI'] = self.df['>ZYYI'].abs()

        ''' add figure '''
        # self.ax_1 = self.figure.add_subplot(1, 4, (3, 4))
        self.ax_2 = self.figure.add_subplot(3, 4, (1, 6))
        self.ax_3 = self.figure.add_subplot(3, 4, (9, 10))

        ''' calculation '''
        # self.app_rho = cal_app_rho(self.df['>FREQ'],
        #                            self.df[self.real],
        #                            self.df[self.imaginary])
        # self.pha = cal_pha(self.df[self.real],
        #                    self.df[self.imaginary],
        #                    self.deg)

        ''' plot '''
        # self.markers_1r, = self.ax_1.plot(self.df['>FREQ'],
        #                                   self.df[self.real],
        #                                   marker='.',
        #                                   c='m',
        #                                   ms=self.marker_size,
        #                                   label='Real')
        # self.markers_1i, = self.ax_1.plot(self.df['>FREQ'],
        #                                   self.df[self.imaginary],
        #                                   marker='.',
        #                                   c='c',
        #                                   ms=self.marker_size,
        #                                   label='Imaginary')
        '''
        --------------------------------------------------------------------------------------- XX
        '''
        self.markers_2, = self.ax_2.plot(self.df['>FREQ'], self.df['>RHOXX'],
                                         marker='.',
                                         c='gold',
                                         ms=6,
                                         label='XX')
        self.markers_3, = self.ax_3.plot(self.df['>FREQ'], self.df['>PHSXX'],
                                         marker='.',
                                         c='gold',
                                         ms=6,
                                         label='XX')
        '''
        --------------------------------------------------------------------------------------- 
        '''

        '''
        --------------------------------------------------------------------------------------- XY
        '''
        self.markers_2, = self.ax_2.plot(self.df['>FREQ'], self.df['>RHOXY'],
                                         marker='.',
                                         c='r',
                                         ms=6,
                                         label='XY')
        self.markers_3, = self.ax_3.plot(self.df['>FREQ'], self.df['>PHSXY'],
                                         marker='.',
                                         c='r',
                                         ms=6,
                                         label='XY')
        '''
        --------------------------------------------------------------------------------------- 
        '''

        '''
        --------------------------------------------------------------------------------------- YX
        '''
        self.markers_2, = self.ax_2.plot(self.df['>FREQ'], self.df['>RHOYX'],
                                         marker='.',
                                         c='b',
                                         ms=6,
                                         label='YX')
        self.markers_3, = self.ax_3.plot(self.df['>FREQ'], self.df['>PHSYX'],
                                         marker='.',
                                         c='b',
                                         ms=6,
                                         label='YX')
        '''
        --------------------------------------------------------------------------------------- 
        '''

        '''
        --------------------------------------------------------------------------------------- YY
        '''
        self.markers_2, = self.ax_2.plot(self.df['>FREQ'], self.df['>RHOYY'],
                                         marker='.',
                                         c='lime',
                                         ms=6,
                                         label='YY')
        self.markers_3, = self.ax_3.plot(self.df['>FREQ'], self.df['>PHSYY'],
                                         marker='.',
                                         c='lime',
                                         ms=6,
                                         label='YY')
        '''
        --------------------------------------------------------------------------------------- 
        '''

        plot_setting(None, self.ax_2, self.ax_3, None)
