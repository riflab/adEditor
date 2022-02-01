import ../read_edi_file


if __name__ == '__main__':

    app = QtWidgets.QApplication(sys.argv)

    canvas = MyFigureCanvas()
    manager = FigureManagerQT(canvas, 1)
    manager.show()

    sys.exit(app.exec_())

    # ax_1 = fig.add_subplot(1, 4, (3, 4))
    # ax_2 = fig.add_subplot(3, 4, (1, 6))
    # ax_3 = fig.add_subplot(3, 4, (9, 10))