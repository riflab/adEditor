from PyQt5 import QtWidgets, uic
from PyQt5.QtWidgets import QFileDialog
# from matplotlib.backends.backend_qt5agg import FigureCanvasQTAgg as FigureCanvas
from matplotlib.backends.backend_qt5agg import NavigationToolbar2QT as NavigationToolbar
# from matplotlib.figure import Figure
# from matplotlib.backends.backend_qt5agg import FigureCanvasQTAgg
# from matplotlib.backends.backend_qt5agg import FigureManagerQT
import sys
from read_edi_file import read_edi
import draggable


class Ui(QtWidgets.QMainWindow):
    def __init__(self):
        super(Ui, self).__init__()  # Call the inherited classes __init__ method
        uic.loadUi('main_window.ui', self)  # Load the .ui file

        self.marker_size = 6

        self.action_open_edi_file.triggered.connect(lambda: self.action_open_edi_file_clicked())
        # self.df, self.header = read_edi('MTCU001A.edi')
        self.df, self.header = read_edi('../data/MT-001.edi')

        # self.commandLinkButtonRun.clicked.connect(lambda: self.button_click())

        # self.actionClose.triggered.connect(lambda: window_close(Ui))
        # self.actionAbout.triggered.connect(lambda: form_about())
        # self.actionTutorial.triggered.connect(lambda: open_web_browser())

        # XX --------------------------------------------------------------------------------------------
        self.canvas_xx = draggable.MyFigureCanvas(self.df, self.header,
                                                  '>ZXXR',
                                                  '>ZXXI',
                                                  '>RHOXX',
                                                  '>PHSXX',
                                                  'XX')
        self.toolbar_xx = NavigationToolbar(self.canvas_xx, self)

        self.verticalLayout_xx.addWidget(self.toolbar_xx, 1)
        self.verticalLayout_xx.addWidget(self.canvas_xx, 100)

        # -----------------------------------------------------------------------------------------------

        # XY --------------------------------------------------------------------------------------------
        self.canvas_xy = draggable.MyFigureCanvas(self.df, self.header,
                                                  '>ZXYR',
                                                  '>ZXYI',
                                                  '>RHOXY',
                                                  '>PHSXY',
                                                  'XY')
        self.toolbar_xy = NavigationToolbar(self.canvas_xy, self)

        self.verticalLayout_xy.addWidget(self.toolbar_xy, 1)
        self.verticalLayout_xy.addWidget(self.canvas_xy, 100)

        # -----------------------------------------------------------------------------------------------

        # yx --------------------------------------------------------------------------------------------
        self.canvas_yx = draggable.MyFigureCanvas(self.df, self.header,
                                                  '>ZYXR',
                                                  '>ZYXI',
                                                  '>RHOYX',
                                                  '>PHSYX',
                                                  'YX')
        self.toolbar_yx = NavigationToolbar(self.canvas_yx, self)

        self.verticalLayout_yx.addWidget(self.toolbar_yx, 1)
        self.verticalLayout_yx.addWidget(self.canvas_yx, 100)
        # -----------------------------------------------------------------------------------------------

        # yy --------------------------------------------------------------------------------------------
        self.canvas_yy = draggable.MyFigureCanvas(self.df, self.header,
                                                  '>ZYYR',
                                                  '>ZYYI',
                                                  '>RHOYY',
                                                  '>PHSYY',
                                                  'YY')
        self.toolbar_yy = NavigationToolbar(self.canvas_yy, self)

        self.verticalLayout_yy.addWidget(self.toolbar_yy, 1)
        self.verticalLayout_yy.addWidget(self.canvas_yy, 100)
        # -----------------------------------------------------------------------------------------------

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
