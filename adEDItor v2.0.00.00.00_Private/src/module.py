import math


def plot_template(widget_canvas, ax1, ax2, ax3, df, msize):

    ax1.loglog()
    # ax1.set_xlim(0.001, 1000)
    # ax1.set_ylim(1, 100000)
    ax1.set_xlabel('Frequency (Hz)', fontsize=8)
    ax1.set_ylabel('Zxy', rotation=90, fontsize=8)
    # ax1.yaxis.tick_right()
    # ax1.yaxis.set_label_position("right")
    ax1.invert_xaxis()
    ax1.grid(which='both', alpha=0.2)
    # ax1.legend(['Real', 'Imag'])
    ax1.autoscale(axis='x')
    ax1.autoscale(axis='y')
    markers_1r, = ax1.plot(df['>FREQ'], df['>ZXYR'].abs(), marker='+', c='r', ms=msize, label='Real')
    markers_1i, = ax1.plot(df['>FREQ'], df['>ZXYI'].abs(), marker='x', c='b', ms=msize, label='Imag')
    ax1.legend()

    ax2.loglog()
    ax2.set_xlim(0.001, 1000)
    ax2.set_ylim(1, 1000)
    ax2.set_ylabel('Ohm meter', fontsize=8)
    ax2.invert_xaxis()
    ax2.grid(which='both', alpha=0.2)
    ax2.legend(['Apparent Resistivity'])
    ax2.autoscale(axis='x')

    ax3.semilogx()
    ax3.set_xlim(0.001, 1000)
    ax3.set_ylim(0, 90)
    ax3.set_xlabel('Frequency (Hz)', fontsize=8)
    ax3.set_ylabel('Degree', fontsize=8)
    ax3.invert_xaxis()
    ax3.grid(which='both', alpha=0.2)
    ax3.legend(['Phase'])
    ax3.autoscale(axis='x')

    widget_canvas.draw()


def plot_edi(df):
    print(df['>ZXYI'])
