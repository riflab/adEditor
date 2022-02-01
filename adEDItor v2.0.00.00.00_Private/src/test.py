from read_edi_file import read_edi
import matplotlib.pyplot as plt
import pandas as pd
from matplotlib.figure import Figure

df, header = read_edi('MT_001.edi')

figure = Figure()

ax1 = figure.add_subplot(1, 5, (4, 5))
ax2 = figure.add_subplot(3, 5, (1, 8))
ax3 = figure.add_subplot(3, 5, (11, 13))

# df.semilogx('>ZXYI', style='o')
# ax1 = df.semilogx(x='>FREQ', y='>ZXYI', c='DarkBlue')

df.plot(x='>FREQ', y='>ZXYI', loglog=True, legend=False)

plt.show()

