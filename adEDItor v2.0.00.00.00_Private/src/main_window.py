from PyQt5 import QtWidgets, uic
from PyQt5.QtWidgets import QFileDialog
from matplotlib.backends.backend_qt5agg import FigureCanvasQTAgg as FigureCanvas
from matplotlib.backends.backend_qt5agg import NavigationToolbar2QT as NavigationToolbar
from matplotlib.figure import Figure
from module import *
import sys
from read_edi_file import read_edi


class Ui(QtWidgets.QMainWindow):
    def __init__(self):
        super(Ui, self).__init__()  # Call the inherited classes __init__ method
        uic.loadUi('main_window.ui', self)  # Load the .ui file

        self.msize = 6

        self.action_open_edi_file.triggered.connect(lambda: self.action_open_edi_file_clicked())
        self.df, self.header = read_edi('MT_001.edi')

        # print(self.header)
        # print(self.df)

        # self.commandLinkButtonRun.clicked.connect(lambda: self.button_click())

        # self.actionClose.triggered.connect(lambda: window_close(Ui))
        # self.actionAbout.triggered.connect(lambda: form_about())
        # self.actionTutorial.triggered.connect(lambda: open_web_browser())

        self.figure = Figure()
        self.widgetCanvas = FigureCanvas(self.figure)
        self.toolbar = NavigationToolbar(self.widgetCanvas, self)

        self.verticalLayout_xy.addWidget(self.toolbar, 1)
        self.verticalLayout_xy.addWidget(self.widgetCanvas, 100)

        # self.ax1 = self.figure.add_subplot(1, 5, (4, 5))
        # self.ax2 = self.figure.add_subplot(3, 5, (1, 8))
        # self.ax3 = self.figure.add_subplot(3, 5, (11, 13))

        self.ax1 = self.figure.add_subplot(1, 4, (3, 4))
        self.ax2 = self.figure.add_subplot(3, 4, (1, 6))
        self.ax3 = self.figure.add_subplot(3, 4, (9, 10))

        self.figure.tight_layout()

        plot_template(self.widgetCanvas, self.ax1, self.ax2, self.ax3, self.df, self.msize)

        plot_edi(self.df)

        self.showMaximized()

    def action_open_edi_file_clicked(self):
        options = QFileDialog.Options()
        options |= QFileDialog.DontUseNativeDialog
        file_name, _ = QFileDialog.getOpenFileName(self, "Open EDI File", "", "EDI File (*.edi)", options=options)
        if file_name:
            self.df = read_edi(file_name)

        # print(site_name, n_frequency)
        # print(self.df)

if __name__ == "__main__":
    app = QtWidgets.QApplication(sys.argv)
    window = Ui()
    app.exec_()
