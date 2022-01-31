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
        self.data()
        # init class attributes:
        self.background = None
        self.draggable = None
        self.msize = 6
        # plot some data:
        x = np.random.rand(25)
        self.ax = self.figure.add_subplot(111)
        self.markers, = self.ax.plot(self.df['xyi'], marker='o', ms=self.msize)
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
            xydata = self.ax.transData.transform(self.markers.get_xydata())
            xdata, ydata = xydata.T
            # compute the linear distance between the markers and the cursor:
            r = ((xdata - x)**2 + (ydata - y)**2)**0.5
            if np.min(r) < self.msize:
                # save figure background:
                self.markers.set_visible(False)
                self.draw()
                self.background = self.copy_from_bbox(self.ax.bbox)
                self.markers.set_visible(True)
                self.ax.draw_artist(self.markers)
                self.update()
                # store index of draggable marker:
                self.draggable = np.argmin(r)
            else:
                self.draggable = None

    def on_motion(self, event):
        if self.draggable is not None:
            if event.xdata and event.ydata:
                # get markers coordinate in data units:
                xdata, ydata = self.markers.get_data()
                print('motion', event.xdata, event.ydata)
                # change the coordinate of the marker that is
                # being dragged to the ones of the mouse cursor:
                # xdata[self.draggable] = event.xdata
                ydata[self.draggable] = event.ydata
                # update the data of the artist:
                # self.markers.set_xdata(xdata)
                self.markers.set_ydata(ydata)
                # update the plot:
                self.restore_region(self.background)
                self.ax.draw_artist(self.markers)
                self.update()

    def on_release(self, event):
        self.draggable = None

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

    # ax_1 = fig.add_subplot(1, 4, (3, 4))
    # ax_2 = fig.add_subplot(3, 4, (1, 6))
    # ax_3 = fig.add_subplot(3, 4, (9, 10))