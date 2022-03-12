import sys
from PyQt5 import QtWidgets
from matplotlib.figure import Figure
from matplotlib.backends.backend_qt5agg import FigureCanvasQTAgg
from matplotlib.backends.backend_qt5agg import FigureManagerQT
# from read_edi_file import read_edi
from configure import plot_setting
from calculation import *


class MyFigureCanvas(FigureCanvasQTAgg):
    def __init__(self, df, label):
        super(MyFigureCanvas, self).__init__(Figure(tight_layout=True))

        # init status
        self.status_1i = False
        self.status_1r = False
        self.status_2 = False
        self.status_3 = False
        self.click_sta = False

        # init class attributes
        self.background_1 = None
        self.background_2 = None
        self.background_3 = None
        self.index_of_frequency = None
        self.marker_size = 6

        # init data parameter
        self.df = df
        other_rho = None
        other_phs = None
        other_label = None
        other_marker = None
        # self.header = header
        # self.real = real
        # self.imaginary = imaginary
        # self.rho = rho
        # self.phs = phs

        c = None
        marker = None
        if label == 'XX':
            c = 'gold'
            marker = '+'
            self.real = '>ZXXR'
            self.imaginary = '>ZXXI'
            self.rho = '>RHOXX'
            self.phs = '>PHSXX'
            other_rho = ['>RHOXY', '>RHOYX', '>RHOYY']
            other_phs = ['>PHSXY', '>PHSYX', '>PHSYY']
            other_label = ['XY', 'YX', 'YY']
            other_marker = ['o', 's', 'x']
        elif label == 'XY':
            c = 'r'
            marker = 'o'
        elif label == 'YX':
            c = 'b'
            marker = 's'
        elif label == 'YY':
            c = 'lime'
            marker = 'x'

        ''' add figure '''
        self.ax_1 = self.figure.add_subplot(1, 4, (3, 4))
        self.ax_2 = self.figure.add_subplot(3, 4, (1, 6))
        self.ax_3 = self.figure.add_subplot(3, 4, (9, 10))

        ''' plot '''
        x = self.df['>FREQ']
        y = self.df[self.real]
        self.markers_1r, = self.ax_1.plot(x, y, marker='.', c='m', ms=self.marker_size, label='Real')
        y = self.df[self.imaginary]
        self.markers_1i, = self.ax_1.plot(x, y, marker='.', c='c', ms=self.marker_size, label='Imaginary')
        y = self.df[self.rho]
        self.markers_2, = self.ax_2.plot(x, y, marker=marker, c=c, ms=self.marker_size, label=label)
        y = self.df[self.phs]
        self.markers_3, = self.ax_3.plot(x, y, marker=marker, c=c, ms=self.marker_size, label=label)

        for i in range(3):
            y = self.df[other_rho[i]]
            self.ax_2.plot(x, y, marker=other_marker[i], c='grey', alpha=0.2, ms=4, label=other_label[i])
            y = self.df[other_phs[i]]
            self.ax_3.plot(x, y, marker=other_marker[i], c='grey', alpha=0.2, ms=4, label=other_label[i])

        plot_setting(self.ax_1, self.ax_2, self.ax_3, label)

        ''' define event connections '''
        self.mpl_connect('button_press_event', self.on_click)
        self.mpl_connect('motion_notify_event', self.on_motion)
        # self.mpl_connect('button_release_event', self.on_release)

    def on_click(self, event):

        """ this section is only implemented on the control chart """
        if event.button == 1 and self.click_sta == False:  # 2 is for middle mouse button

            ''' get mouse cursor coordinates in pixels: '''
            x = event.x
            y = event.y

            ''' get markers xy coordinate in pixels: '''
            xy_data_1i = self.ax_1.transData.transform(self.markers_1i.get_xydata())
            xy_data_1r = self.ax_1.transData.transform(self.markers_1r.get_xydata())

            xdata_1i, ydata_1i = xy_data_1i.T
            xdata_1r, ydata_1r = xy_data_1r.T

            ''' compute the linear distance between the markers and the cursor: '''
            r_1i = ((xdata_1i - x) ** 2 + (ydata_1i - y) ** 2) ** 0.5
            r_1r = ((xdata_1r - x) ** 2 + (ydata_1r - y) ** 2) ** 0.5

            if np.min(r_1i) < self.marker_size:
                # save figure background:
                self.markers_1i.set_visible(False)
                self.markers_2.set_visible(False)
                self.markers_3.set_visible(False)
                self.draw()
                self.background_1 = self.copy_from_bbox(self.ax_1.bbox)
                self.background_2 = self.copy_from_bbox(self.ax_2.bbox)
                self.background_3 = self.copy_from_bbox(self.ax_3.bbox)
                self.markers_1i.set_visible(True)
                self.markers_2.set_visible(True)
                self.markers_3.set_visible(True)
                self.ax_1.draw_artist(self.markers_1i)
                self.ax_2.draw_artist(self.markers_2)
                self.ax_3.draw_artist(self.markers_3)
                self.update()
                # store index of draggable marker:
                self.index_of_frequency = np.argmin(r_1i)
                self.status_1i = True
                self.click_sta = True

            elif np.min(r_1r) < self.marker_size:
                # save figure background:
                self.markers_1r.set_visible(False)
                self.markers_2.set_visible(False)
                self.markers_3.set_visible(False)
                self.draw()
                self.background_1 = self.copy_from_bbox(self.ax_1.bbox)
                self.background_2 = self.copy_from_bbox(self.ax_2.bbox)
                self.background_3 = self.copy_from_bbox(self.ax_3.bbox)
                self.markers_1r.set_visible(True)
                self.markers_2.set_visible(True)
                self.markers_3.set_visible(True)
                self.ax_1.draw_artist(self.markers_1r)
                self.ax_2.draw_artist(self.markers_2)
                self.ax_3.draw_artist(self.markers_3)
                self.update()
                # store index of draggable marker:
                self.index_of_frequency = np.argmin(r_1r)
                self.status_1r = True
                self.click_sta = True
            else:
                self.index_of_frequency = None

        elif event.button == 1 and self.click_sta == True:

            if self.status_1i == True and self.status_1r == False:
                self.df.at[self.index_of_frequency, self.imaginary] = event.ydata
            if self.status_1r == True and self.status_1i == False:
                self.df.at[self.index_of_frequency, self.real] = event.ydata

            if self.status_1i == True or self.status_1r == True:
                self.df.at[self.index_of_frequency, self.rho] = self.app_rho
                self.df.at[self.index_of_frequency, self.phs] = self.pha

            self.index_of_frequency = None
            self.status_1i = False
            self.status_1r = False
            self.status_2 = False
            self.click_sta = False

    def on_motion(self, event):
        if self.index_of_frequency is not None and event.xdata and event.ydata and event.xdata and event.ydata:
            if event.xdata and event.ydata:
                '''  get markers coordinate in data units: '''
                xdata_1i, ydata_1i = self.markers_1i.get_data()
                xdata_1r, ydata_1r = self.markers_1r.get_data()
                xdata_2, ydata_2 = self.markers_2.get_data()  # app resistivity curve
                xdata_3, ydata_3 = self.markers_3.get_data()  # phase

                if self.status_1i == True and self.status_1r == False:

                    ''' change the coordinate of the marker that is being dragged to the ones of the mouse cursor: '''
                    # xdata[self.draggable] = event.xdata
                    ydata_1i[self.index_of_frequency] = event.ydata

                    ''' update the data of the artist: '''
                    # self.markers.set_xdata(xdata)
                    self.markers_1i.set_ydata(ydata_1i)

                    ''' update the plot: '''
                    self.restore_region(self.background_1)
                    self.ax_1.draw_artist(self.markers_1i)

                    ''' rho curve '''
                    ''' change the coordinate of the marker that is being dragged to the ones of the mouse cursor: '''
                    # xdata[self.draggable] = event.xdata

                    ''' calculation '''

                    self.app_rho = cal_app_rho(self.df['>FREQ'][self.index_of_frequency],
                                               self.df[self.real][self.index_of_frequency],
                                               event.ydata)
                    self.pha = cal_pha(self.df[self.real][self.index_of_frequency],
                                       event.ydata)

                    ydata_2[self.index_of_frequency] = self.app_rho
                    ydata_3[self.index_of_frequency] = self.pha

                    ''' update the data of the artist: '''
                    # self.markers.set_xdata(xdata)
                    self.markers_2.set_ydata(ydata_2)
                    self.markers_3.set_ydata(ydata_3)

                    ''' update the plot: '''
                    self.restore_region(self.background_2)
                    self.ax_2.draw_artist(self.markers_2)

                    self.restore_region(self.background_3)
                    self.ax_3.draw_artist(self.markers_3)

                elif self.status_1r == True and self.status_1i == False:
                    ''' change the coordinate of the marker that is being dragged to the ones of the mouse cursor: '''
                    # xdata[self.draggable] = event.xdata
                    ydata_1r[self.index_of_frequency] = event.ydata

                    ''' update the data of the artist: '''
                    # self.markers.set_xdata(xdata)
                    self.markers_1r.set_ydata(ydata_1r)

                    ''' update the plot: '''
                    self.restore_region(self.background_1)
                    self.ax_1.draw_artist(self.markers_1r)

                    ''' rho curve '''
                    ''' change the coordinate of the marker that is being dragged to the ones of the mouse cursor: '''
                    # xdata[self.draggable] = event.xdata

                    ''' calculation '''

                    self.app_rho = cal_app_rho(self.df['>FREQ'][self.index_of_frequency],
                                               event.ydata,
                                               self.df[self.imaginary][self.index_of_frequency])
                    self.pha = cal_pha(event.ydata,
                                       self.df[self.imaginary][self.index_of_frequency])

                    ydata_2[self.index_of_frequency] = self.app_rho
                    ydata_3[self.index_of_frequency] = self.pha

                    ''' update the data of the artist: '''
                    # self.markers.set_xdata(xdata)
                    self.markers_2.set_ydata(ydata_2)
                    self.markers_3.set_ydata(ydata_3)

                    ''' update the plot: '''
                    self.restore_region(self.background_2)
                    self.ax_2.draw_artist(self.markers_2)
                    self.restore_region(self.background_3)
                    self.ax_3.draw_artist(self.markers_3)

                self.update()

    # def on_release(self, event):
    #     if self.status_1i == True and self.status_1r == False:
    #         self.df.at[self.index_of_frequency, self.imaginary] = event.ydata
    #     if self.status_1r == True and self.status_1i == False:
    #         self.df.at[self.index_of_frequency, self.real] = event.ydata
    #
    #     if self.status_1i == True or self.status_1r == True:
    #         self.df.at[self.index_of_frequency, self.rho] = self.app_rho
    #         self.df.at[self.index_of_frequency, self.phs] = self.pha
    #
    #     self.index_of_frequency = None
    #     self.status_1i = False
    #     self.status_1r = False
    #     self.status_2 = False

    # def data(self):
    #     self.df, self.header = read_edi('MT_001.edi')


if __name__ == '__main__':
    app = QtWidgets.QApplication(sys.argv)

    canvas = MyFigureCanvas('df', 'label')
    manager = FigureManagerQT(canvas, 1)
    manager.show()

    sys.exit(app.exec_())
