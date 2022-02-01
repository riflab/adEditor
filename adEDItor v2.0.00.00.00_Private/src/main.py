import sys
from PyQt5 import QtWidgets
from matplotlib.figure import Figure
from matplotlib.backends.backend_qt5agg import FigureCanvasQTAgg
from matplotlib.backends.backend_qt5agg import FigureManagerQT
import numpy as np
import pandas as pd


class MyFigureCanvas(FigureCanvasQTAgg):
    def __init__(self):
        super(MyFigureCanvas, self).__init__(Figure())
        self.status_1 = False
        self.status_2 = False

        # ax_1 = fig.add_subplot(1, 4, (3, 4))
        # ax_2 = fig.add_subplot(3, 4, (1, 6))
        # ax_3 = fig.add_subplot(3, 4, (9, 10))

        # init class attributes:
        self.background = None
        self.draggable = None
        self.msize = 6

        # plot some data:
        self.data()
        # self.ax = self.figure.add_subplot(111)

        self.ax_1 = self.figure.add_subplot(1, 4, (3, 4))
        self.ax_2 = self.figure.add_subplot(3, 4, (1, 6))
        self.ax_3 = self.figure.add_subplot(3, 4, (9, 10))

        self.markers_1, = self.ax_1.plot(self.df['xyi'], marker='o', ms=self.msize)
        self.markers_2, = self.ax_1.plot(self.df['xyr'], marker='+', ms=self.msize)

        self.markers_3, = self.ax_2.plot(self.df['xyr']*self.df['xyi'], marker='+', ms=self.msize)
        # self.point_3, = self.ax.plot(df['xyi'], 'o-', linewidth=0.9, picker=True, pickradius=5)

        # define event connections:
        self.mpl_connect('motion_notify_event', self.on_motion)
        self.mpl_connect('button_press_event', self.on_click)
        self.mpl_connect('button_release_event', self.on_release)

    def on_click(self, event):
        if event.button == 1:  # 2 is for middle mouse button
            # get mouse cursor coordinates in pixels:
            x = event.x
            y = event.y
            # get markers xy coordinate in pixels:
            xydata_1 = self.ax_1.transData.transform(self.markers_1.get_xydata())
            xydata_2 = self.ax_1.transData.transform(self.markers_2.get_xydata())
            xdata_1, ydata_1 = xydata_1.T
            xdata_2, ydata_2 = xydata_2.T
            # compute the linear distance between the markers and the cursor:
            r_1 = ((xdata_1 - x) ** 2 + (ydata_1 - y) ** 2) ** 0.5
            r_2 = ((xdata_2 - x) ** 2 + (ydata_2 - y) ** 2) ** 0.5
            if np.min(r_1) < self.msize:
                # save figure background:
                self.markers_1.set_visible(False)
                self.markers_3.set_visible(False)
                self.draw()
                self.background_12 = self.copy_from_bbox(self.ax_1.bbox)
                self.background_3 = self.copy_from_bbox(self.ax_3.bbox)
                self.markers_1.set_visible(True)
                self.markers_3.set_visible(True)
                self.ax_1.draw_artist(self.markers_1)
                self.ax_3.draw_artist(self.markers_3)
                self.update()
                # store index of draggable marker:
                self.draggable = np.argmin(r_1)
                print('xyr')
                self.status_1 = True
            elif np.min(r_2) < self.msize:
                # save figure background:
                self.markers_2.set_visible(False)
                self.draw()
                self.background_12 = self.copy_from_bbox(self.ax_1.bbox)
                self.background_3 = self.copy_from_bbox(self.ax_3.bbox)
                self.markers_2.set_visible(True)
                self.ax_1.draw_artist(self.markers_2)
                self.update()
                # store index of draggable marker:
                self.draggable = np.argmin(r_2)
                print('xyi')
                self.status_2 = True
            else:
                self.draggable = None

    def on_motion(self, event):
        if self.draggable is not None:
            if event.xdata and event.ydata:
                # get markers coordinate in data units:
                xdata_1, ydata_1 = self.markers_1.get_data()
                xdata_2, ydata_2 = self.markers_2.get_data()
                xdata_3, ydata_3 = self.markers_3.get_data()
                print('motion', event.xdata, event.ydata)
                if self.status_1 == True:
                    # change the coordinate of the marker that is
                    # being dragged to the ones of the mouse cursor:
                    # xdata[self.draggable] = event.xdata
                    ydata_1[self.draggable] = event.ydata
                    ydata_3[self.draggable] = event.ydata * 5
                    # update the data of the artist:
                    # self.markers.set_xdata(xdata)
                    self.markers_1.set_ydata(ydata_1)
                    self.markers_3.set_ydata(ydata_3)
                    # update the plot:
                    self.restore_region(self.background_12)
                    self.ax_1.draw_artist(self.markers_1)
                    self.restore_region(self.background_3)
                    self.ax_3.draw_artist(self.markers_3)
                    #
                    # ydata_3[self.draggable] = event.ydata * 5
                    # self.markers_3.set_ydata(ydata_3)
                    # self.restore_region(self.background)
                    # self.ax_3.draw_artist(self.markers_3)
                else:
                    # change the coordinate of the marker that is
                    # being dragged to the ones of the mouse cursor:
                    # xdata[self.draggable] = event.xdata
                    ydata_2[self.draggable] = event.ydata
                    ydata_3[self.draggable] = event.ydata * 5
                    # update the data of the artist:
                    # self.markers.set_xdata(xdata)
                    self.markers_2.set_ydata(ydata_2)
                    self.markers_3.set_ydata(ydata_3)
                    # update the plot:
                    self.restore_region(self.background_12)
                    self.ax_2.draw_artist(self.markers_2)
                    self.restore_region(self.background_3)
                    self.ax_3.draw_artist(self.markers_3)

                self.update()

    def on_release(self, event):
        self.draggable = None
        self.status_1 = False
        self.status_2 = False

    def data(self):
        dat = {'idx': [1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
                'frequency': [0.01, 0.02, 0.03, 0.04, 0.05, 0.06, 0.07, 0.08, 0.09, 0.10],
                'xyr': [1200, 150, 300, 450, 200, 1200, 150, 300, 450, 200],
                'xyi': [12, 23, 23, 5, 45, 65, 7, 8, 9, 22]
                }

        self.df = pd.DataFrame(dat)
        # df = df.set_index(['idx', 'frequency'], inplace=False)
        self.df = self.df.set_index('frequency')

if __name__ == '__main__':

    app = QtWidgets.QApplication(sys.argv)

    canvas = MyFigureCanvas()
    manager = FigureManagerQT(canvas, 1)
    manager.show()

    sys.exit(app.exec_())

