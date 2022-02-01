from PyQt5 import QtWidgets, uic
from PyQt5.QtWidgets import QFileDialog
import sys
from read_edi_file import read_edi


class Ui(QtWidgets.QMainWindow):
    def __init__(self):
        super(Ui, self).__init__()  # Call the inherited classes __init__ method
        uic.loadUi('main_window.ui', self)  # Load the .ui file

        self.action_open_edi_file.triggered.connect(lambda: self.action_open_edi_file_clicked())
        # read_edi('MT_001.edi')
        self.showMaximized()

    def action_open_edi_file_clicked(self):
        options = QFileDialog.Options()
        options |= QFileDialog.DontUseNativeDialog
        file_name, _ = QFileDialog.getOpenFileName(self, "Open EDI File", "", "EDI File (*.edi)", options=options)
        if file_name:
            read_edi(file_name)


if __name__ == "__main__":
    app = QtWidgets.QApplication(sys.argv)
    window = Ui()
    app.exec_()
