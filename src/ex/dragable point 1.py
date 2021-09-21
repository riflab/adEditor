#!/usr/bin/python
# -*-coding:Utf-8 -*

import sys
import matplotlib
matplotlib.use("Qt5Agg")
from PyQt5 import QtWidgets, QtGui

from matplotlib.backends.backend_qt5agg import FigureCanvasQTAgg as FigureCanvas
from matplotlib.figure import Figure

# Personnal modules
from drag import DraggablePoint


class MyGraph(FigureCanvas):

    """A canvas that updates itself every second with a new plot."""

    def __init__(self, parent=None, width=5, height=4, dpi=100):

        self.fig = Figure(figsize=(width, height), dpi=dpi)
        self.axes = self.fig.add_subplot(111)

        self.axes.grid(True)

        FigureCanvas.__init__(self, self.fig)
        self.setParent(parent)

        FigureCanvas.setSizePolicy(self,
                                   QtWidgets.QSizePolicy.Expanding,
                                   QtWidgets.QSizePolicy.Expanding)
        FigureCanvas.updateGeometry(self)

        # To store the 2 draggable points
        self.list_points = []


        self.show()
        self.plotDraggablePoints([0.1, 0.1], [0.2, 0.2], [0.1, 0.1])

    def plotDraggablePoints(self, xy1, xy2, size=None):

        """Plot and define the 2 draggable points of the baseline"""

        # del(self.list_points[:])
        self.list_points.append(DraggablePoint(self, xy1[0], xy1[1], size))
        self.list_points.append(DraggablePoint(self, xy2[0], xy2[1], size))
        self.updateFigure()


    def clearFigure(self):

        """Clear the graph"""

        self.axes.clear()
        self.axes.grid(True)
        del(self.list_points[:])
        self.updateFigure()


    def updateFigure(self):

        """Update the graph. Necessary, to call after each plot"""

        self.draw()

if __name__ == '__main__':

    app = QtWidgets.QApplication(sys.argv)
    ex = MyGraph()
    sys.exit(app.exec_())