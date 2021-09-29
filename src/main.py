import numpy as np
import matplotlib.pyplot as plt


class DraggableRectangle:
    def __init__(self):
        self.press_event = None
        self.connect()

    def connect(self):
        fig.canvas.mpl_connect('button_press_event', self.on_press)
        fig.canvas.mpl_connect('button_release_event', self.on_release)
        fig.canvas.mpl_connect('motion_notify_event', self.on_motion)

    def on_pick(self, event):

        if event.artist != self.point:  # check that you clicked on the object you wanted
            return True
        if not len(event.ind):  # check the index is valid
            return True

        self.press_event = True
        return True

    def on_press(self, event):
        fig.canvas.mpl_connect('pick_event', self.on_pick)

    def on_release(self, event):
        self.press_event = False

    def on_motion(self, event):
        if self.press_event is None or self.press_event == False:
            return
        print('motion', event.ydata)

    def plot_graph(self, ax, x, y):
        self.point, = ax.plot(x, y, 'o', picker=True, pickradius=5)


if __name__ == "__main__":
    fig, ax = plt.subplots()

    x = np.arange(0, 4 * np.pi, 1)  # start,stop,step
    y = np.sin(x)

    drag = DraggableRectangle()
    drag.plot_graph(ax, x, y)
    # fig.canvas.mpl_connect('pick_event', drag.on_pick)

    plt.show()
