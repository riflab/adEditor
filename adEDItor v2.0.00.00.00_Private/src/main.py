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
        self.status_1i = False
        self.status_1r = False
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

        self.markers_1i, = self.ax_1.plot(self.df['xyi'], marker='o', ms=self.msize)
        self.markers_1r, = self.ax_1.plot(self.df['xyr'], marker='+', ms=self.msize)

        self.markers_2, = self.ax_2.plot(self.df['xyr']*self.df['xyi'], marker='x', ms=self.msize)
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
            xydata_1i = self.ax_1.transData.transform(self.markers_1i.get_xydata())
            xydata_1r = self.ax_1.transData.transform(self.markers_1r.get_xydata())
            # xydata_2 = self.ax_2.transData.transform(self.markers_2.get_xydata())
            xdata_1i, ydata_1i = xydata_1i.T
            xdata_1r, ydata_1r = xydata_1r.T
            # xdata_2, ydata_2 = xydata_2.T
            # compute the linear distance between the markers and the cursor:
            r_1i = ((xdata_1i - x) ** 2 + (ydata_1i - y) ** 2) ** 0.5
            r_1r = ((xdata_1r - x) ** 2 + (ydata_1r - y) ** 2) ** 0.5
            # r_2 = ((xdata_2 - x) ** 2 + (ydata_2 - y) ** 2) ** 0.5
            if np.min(r_1i) < self.msize:
                # save figure background:
                self.markers_1i.set_visible(False)
                self.draw()
                self.background_1 = self.copy_from_bbox(self.ax_1.bbox)
                self.markers_1i.set_visible(True)
                self.ax_1.draw_artist(self.markers_1i)
                self.update()
                # store index of draggable marker:
                self.draggable = np.argmin(r_1i)
                self.status_1i = True
            # elif np.min(r_2) < self.msize:
            #     # save figure background:
            #     self.markers_2.set_visible(False)
            #     self.draw()
            #     self.background_2 = self.copy_from_bbox(self.ax_2.bbox)
            #     self.markers_2.set_visible(True)
            #     self.ax_2.draw_artist(self.markers_2)
            #     self.update()
            #     # store index of draggable marker:
            #     self.draggable = np.argmin(r_2)
            #     self.status_2 = True
            elif np.min(r_1r) < self.msize:
                # save figure background:
                self.markers_1r.set_visible(False)
                self.draw()
                self.background_1 = self.copy_from_bbox(self.ax_1.bbox)
                self.markers_1r.set_visible(True)
                self.ax_1.draw_artist(self.markers_1r)
                self.update()
                # store index of draggable marker:
                self.draggable = np.argmin(r_1r)
                self.status_1r = True
            # elif np.min(r_2) < self.msize:
            #     # save figure background:
            #     self.markers_2.set_visible(False)
            #     self.draw()
            #     self.background_2 = self.copy_from_bbox(self.ax_2.bbox)
            #     self.markers_2.set_visible(True)
            #     self.ax_2.draw_artist(self.markers_2)
            #     self.update()
            #     # store index of draggable marker:
            #     self.draggable = np.argmin(r_2)
            #     self.status_2 = True
            else:
                self.draggable = None
            self.markers_2.set_visible(False)
            self.draw()
            self.background_2 = self.copy_from_bbox(self.ax_2.bbox)
            self.markers_2.set_visible(True)
            self.ax_2.draw_artist(self.markers_2)
            self.update()

    def on_motion(self, event):
        if self.draggable is not None:
            if event.xdata and event.ydata:
                # get markers coordinate in data units:
                xdata_1i, ydata_1i = self.markers_1i.get_data()
                xdata_1r, ydata_1r = self.markers_1r.get_data()
                xdata_2, ydata_2 = self.markers_2.get_data()

                print('motion', event.xdata, event.ydata)
                if self.status_1i == True:
                    # change the coordinate of the marker that is
                    # being dragged to the ones of the mouse cursor:
                    # xdata[self.draggable] = event.xdata
                    ydata_1i[self.draggable] = event.ydata
                    # update the data of the artist:
                    # self.markers.set_xdata(xdata)
                    self.markers_1i.set_ydata(ydata_1i)
                    # update the plot:
                    self.restore_region(self.background_1)
                    self.ax_1.draw_artist(self.markers_1i)

                    ### rho curve
                    # change the coordinate of the marker that is
                    # being dragged to the ones of the mouse cursor:
                    # xdata[self.draggable] = event.xdata
                    ydata_2[self.draggable] = event.ydata * ydata_1r[self.draggable]
                    print(ydata_2)
                    # update the data of the artist:
                    # self.markers.set_xdata(xdata)
                    self.markers_2.set_ydata(ydata_2)
                    # update the plot:
                    self.restore_region(self.background_2)
                    self.ax_2.draw_artist(self.markers_2)

                elif self.status_1r == True:
                    # change the coordinate of the marker that is
                    # being dragged to the ones of the mouse cursor:
                    # xdata[self.draggable] = event.xdata
                    ydata_1r[self.draggable] = event.ydata
                    # update the data of the artist:
                    # self.markers.set_xdata(xdata)
                    self.markers_1r.set_ydata(ydata_1r)
                    # update the plot:
                    self.restore_region(self.background_1)
                    self.ax_1.draw_artist(self.markers_1r)

                    ### rho curve
                    # change the coordinate of the marker that is
                    # being dragged to the ones of the mouse cursor:
                    # xdata[self.draggable] = event.xdata
                    ydata_2[self.draggable] = event.ydata * ydata_1i[self.draggable]
                    print(ydata_2)
                    # update the data of the artist:
                    # self.markers.set_xdata(xdata)
                    self.markers_2.set_ydata(ydata_2)
                    # update the plot:
                    self.restore_region(self.background_2)
                    self.ax_2.draw_artist(self.markers_2)

                self.update()

    def on_release(self, event):
        self.draggable = None
        self.status_1i = False
        self.status_1r = False
        self.status_2 = False


    def data(self):
        dat = {'idx': [1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
                'frequency': [0.01, 0.02, 0.03, 0.04, 0.05, 0.06, 0.07, 0.08, 0.09, 0.10],
                'xyr': [12, 14, 5, 34, 2, 33, 22, 55, 1, 2],
                'xyi': [12, 23, 23, 5, 45, 2, 7, 8, 9, 22]
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

