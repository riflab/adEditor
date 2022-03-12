import numpy as np


def plot_setting(ax1, ax2, ax3, label):
    if label == 'XY' or label == 'YX':
        ax1.loglog()
    elif label == 'XX' or label == 'YY':
        ax1.semilogx()
    # ax1.set_xlim(0.0001, 10000)
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
    ax1.legend()
    ax1.axis('equal')
    ax1.set_aspect(1)

    ax2.loglog()
    # ax2.set_xlim(0.001, 1000)
    # ax2.set_ylim(1, 1000)
    ax2.set_xlabel('Frequency (Hz)', fontsize=8)
    ax2.set_ylabel('App. Resistivity (ohm-meter)', fontsize=8)
    # ax2.yaxis.tick_right()
    # ax2.yaxis.set_label_position("right")
    ax2.invert_xaxis()
    ax2.grid(which='both', alpha=0.2)
    # ax2.legend(['Apparent Resistivity'])
    # ax2.autoscale(axis='x')
    # ax2.autoscale(axis='y')
    ax2.legend()
    ax2.axis('equal')
    ax2.set_aspect(1)

    ax3.semilogx()
    # ax3.set_xlim(0.001, 1000)
    ax3.set_ylim(-200, 200)
    ax3.set_yticks(np.arange(-180, 180.1, 45))
    ax3.set_xlabel('Frequency (Hz)', fontsize=8)
    ax3.set_ylabel('Phase (Degree)', fontsize=8)
    # ax1.yaxis.tick_right()
    # ax1.yaxis.set_label_position("right")
    ax3.invert_xaxis()
    ax3.grid(which='both', alpha=0.2)
    # ax3.legend(['Apparent Resistivity'])
    # ax3.autoscale(axis='x')
    # ax3.autoscale(axis='y')
    ax3.legend()

    '''
    to share and connect axis-x
    '''
    ax1.sharex(ax2)
    ax2.sharex(ax3)
