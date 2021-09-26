import numpy as np
import matplotlib.pyplot as plt

class Click():
    def __init__(self, ax, func, button=1):
        self.ax=ax
        self.func=func
        self.button=button
        self.press=False
        self.move = False
        self.c1=self.ax.figure.canvas.mpl_connect('button_press_event', self.onpress)
        self.c2=self.ax.figure.canvas.mpl_connect('button_release_event', self.onrelease)
        self.c3=self.ax.figure.canvas.mpl_connect('motion_notify_event', self.onmove)

    def onclick(self,event):
        if event.inaxes == self.ax:
            if event.button == self.button:
                self.func(event, self.ax)
    def onpress(self,event):
        self.press=True
    def onmove(self,event):
        if self.press:
            self.move=True
    def onrelease(self,event):
        if self.press and not self.move:
            self.onclick(event)
        self.press=False; self.move=False


def func(event, ax):
    print(event.xdata, event.ydata)
    ax.scatter(event.xdata, event.ydata)
    ax.figure.canvas.draw()

fig, (ax1, ax2) = plt.subplots(1, 2)
# Plot some random scatter data
ax2.scatter(np.random.uniform(0., 10., 10), np.random.uniform(0., 10., 10))
click = Click(ax2, func, button=1)
plt.show()