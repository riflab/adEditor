Imports System.Windows.Forms.DataVisualization
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Math

Module Plot

    Public tableALL As New DataTable
    Public tableORI As New DataTable
    Public tableZXX As New DataTable
    Public tableRhoPhaXX As New DataTable
    Public tableZXY As New DataTable
    Public tableRhoPhaXY As New DataTable
    Public tableZYX As New DataTable
    Public tableRhoPhaYX As New DataTable
    Public tableZYY As New DataTable
    Public tableRhoPhaYY As New DataTable
    Public tableTxZ As New DataTable
    Public tableTyZ As New DataTable

    Function tableColumns()
        tableALL.Columns.Add(">NO", GetType(Integer))
        tableALL.Columns.Add(">PERIODE", GetType(Double))
        tableALL.Columns.Add(">ZROT", GetType(Double))
        tableALL.Columns.Add(">ZXXR ROT=ZROT", GetType(Double))
        tableALL.Columns.Add(">ZXXI ROT=ZROT", GetType(Double))
        tableALL.Columns.Add(">ZXX.VAR ROT=ZROT", GetType(Double))
        tableALL.Columns.Add(">ZXYR ROT=ZROT", GetType(Double))
        tableALL.Columns.Add(">ZXYI ROT=ZROT", GetType(Double))
        tableALL.Columns.Add(">ZXY.VAR ROT=ZROT", GetType(Double))
        tableALL.Columns.Add(">ZYXR ROT=ZROT", GetType(Double))
        tableALL.Columns.Add(">ZYXI ROT=ZROT", GetType(Double))
        tableALL.Columns.Add(">ZYX.VAR ROT=ZROT", GetType(Double))
        tableALL.Columns.Add(">ZYYR ROT=ZROT", GetType(Double))
        tableALL.Columns.Add(">ZYYI ROT=ZROT", GetType(Double))
        tableALL.Columns.Add(">ZYY.VAR ROT=ZROT", GetType(Double))
        tableALL.Columns.Add(">RHOROT", GetType(Double))
        tableALL.Columns.Add(">RHOXY ROT=RHOROT", GetType(Double))
        tableALL.Columns.Add(">RHOXY.ERR ROT=RHOROT", GetType(Double))
        tableALL.Columns.Add(">RHOXY.FIT ROT=RHOROT", GetType(Double))
        tableALL.Columns.Add(">RHOYX ROT=RHOROT", GetType(Double))
        tableALL.Columns.Add(">RHOYX.ERR ROT=RHOROT", GetType(Double))
        tableALL.Columns.Add(">RHOYX.FIT ROT=RHOROT", GetType(Double))
        tableALL.Columns.Add(">RHOXX ROT=RHOROT", GetType(Double))
        tableALL.Columns.Add(">RHOXX.ERR ROT=RHOROT", GetType(Double))
        tableALL.Columns.Add(">RHOYY ROT=RHOROT", GetType(Double))
        tableALL.Columns.Add(">RHOYY.ERR ROT=RHOROT", GetType(Double))
        tableALL.Columns.Add(">PHSXY ROT=RHOROT", GetType(Double))
        tableALL.Columns.Add(">PHSXY.ERR ROT=RHOROT", GetType(Double))
        tableALL.Columns.Add(">PHSXY.FIT ROT=RHOROT", GetType(Double))
        tableALL.Columns.Add(">PHSYX ROT=RHOROT", GetType(Double))
        tableALL.Columns.Add(">PHSYX.ERR ROT=RHOROT", GetType(Double))
        tableALL.Columns.Add(">PHSYX.FIT ROT=RHOROT", GetType(Double))
        tableALL.Columns.Add(">PHSXX ROT=RHOROT", GetType(Double))
        tableALL.Columns.Add(">PHSXX.ERR ROT=RHOROT", GetType(Double))
        tableALL.Columns.Add(">PHSYY ROT=RHOROT", GetType(Double))
        tableALL.Columns.Add(">PHSYY.ERR ROT=RHOROT", GetType(Double))
        tableALL.Columns.Add(">TROT.EXP", GetType(Double))
        tableALL.Columns.Add(">TXR.EXP", GetType(Double))
        tableALL.Columns.Add(">TXI.EXP", GetType(Double))
        tableALL.Columns.Add(">TXVAR.EXP", GetType(Double))
        tableALL.Columns.Add(">TYR.EXP", GetType(Double))
        tableALL.Columns.Add(">TYI.EXP", GetType(Double))
        tableALL.Columns.Add(">TYVAR.EXP", GetType(Double))
        tableALL.Columns.Add(">TIPMAG", GetType(Double))
        tableALL.Columns.Add(">TIPMAG.VAR", GetType(Double))
        tableALL.Columns.Add(">TIPPHS", GetType(Double))
        tableALL.Columns.Add(">ZSTRIKE", GetType(Double))
        tableALL.Columns.Add(">ZSKEW", GetType(Double))
        tableALL.Columns.Add(">ZELLIP", GetType(Double))
        tableALL.Columns.Add(">TSTRIKE", GetType(Double))
        tableALL.Columns.Add(">TSKEW", GetType(Double))
        tableALL.Columns.Add(">TELLIP", GetType(Double))
        tableALL.Columns.Add(">INDMAGR.EXP", GetType(Double))
        tableALL.Columns.Add(">INDMAGI.EXP", GetType(Double))
        tableALL.Columns.Add(">INDANGR.EXP", GetType(Double))
        tableALL.Columns.Add(">INDANGI.EXP", GetType(Double))

        tableORI.Columns.Add(">NO", GetType(Integer))
        tableORI.Columns.Add(">PERIODE", GetType(Double))
        tableORI.Columns.Add(">ZROT", GetType(Double))
        tableORI.Columns.Add(">ZXXR ROT=ZROT", GetType(Double))
        tableORI.Columns.Add(">ZXXI ROT=ZROT", GetType(Double))
        tableORI.Columns.Add(">ZXX.VAR ROT=ZROT", GetType(Double))
        tableORI.Columns.Add(">ZXYR ROT=ZROT", GetType(Double))
        tableORI.Columns.Add(">ZXYI ROT=ZROT", GetType(Double))
        tableORI.Columns.Add(">ZXY.VAR ROT=ZROT", GetType(Double))
        tableORI.Columns.Add(">ZYXR ROT=ZROT", GetType(Double))
        tableORI.Columns.Add(">ZYXI ROT=ZROT", GetType(Double))
        tableORI.Columns.Add(">ZYX.VAR ROT=ZROT", GetType(Double))
        tableORI.Columns.Add(">ZYYR ROT=ZROT", GetType(Double))
        tableORI.Columns.Add(">ZYYI ROT=ZROT", GetType(Double))
        tableORI.Columns.Add(">ZYY.VAR ROT=ZROT", GetType(Double))
        tableORI.Columns.Add(">RHOROT", GetType(Double))
        tableORI.Columns.Add(">RHOXY ROT=RHOROT", GetType(Double))
        tableORI.Columns.Add(">RHOXY.ERR ROT=RHOROT", GetType(Double))
        tableORI.Columns.Add(">RHOXY.FIT ROT=RHOROT", GetType(Double))
        tableORI.Columns.Add(">RHOYX ROT=RHOROT", GetType(Double))
        tableORI.Columns.Add(">RHOYX.ERR ROT=RHOROT", GetType(Double))
        tableORI.Columns.Add(">RHOYX.FIT ROT=RHOROT", GetType(Double))
        tableORI.Columns.Add(">RHOXX ROT=RHOROT", GetType(Double))
        tableORI.Columns.Add(">RHOXX.ERR ROT=RHOROT", GetType(Double))
        tableORI.Columns.Add(">RHOYY ROT=RHOROT", GetType(Double))
        tableORI.Columns.Add(">RHOYY.ERR ROT=RHOROT", GetType(Double))
        tableORI.Columns.Add(">PHSXY ROT=RHOROT", GetType(Double))
        tableORI.Columns.Add(">PHSXY.ERR ROT=RHOROT", GetType(Double))
        tableORI.Columns.Add(">PHSXY.FIT ROT=RHOROT", GetType(Double))
        tableORI.Columns.Add(">PHSYX ROT=RHOROT", GetType(Double))
        tableORI.Columns.Add(">PHSYX.ERR ROT=RHOROT", GetType(Double))
        tableORI.Columns.Add(">PHSYX.FIT ROT=RHOROT", GetType(Double))
        tableORI.Columns.Add(">PHSXX ROT=RHOROT", GetType(Double))
        tableORI.Columns.Add(">PHSXX.ERR ROT=RHOROT", GetType(Double))
        tableORI.Columns.Add(">PHSYY ROT=RHOROT", GetType(Double))
        tableORI.Columns.Add(">PHSYY.ERR ROT=RHOROT", GetType(Double))
        tableORI.Columns.Add(">TROT.EXP", GetType(Double))
        tableORI.Columns.Add(">TXR.EXP", GetType(Double))
        tableORI.Columns.Add(">TXI.EXP", GetType(Double))
        tableORI.Columns.Add(">TXVAR.EXP", GetType(Double))
        tableORI.Columns.Add(">TYR.EXP", GetType(Double))
        tableORI.Columns.Add(">TYI.EXP", GetType(Double))
        tableORI.Columns.Add(">TYVAR.EXP", GetType(Double))
        tableORI.Columns.Add(">TIPMAG", GetType(Double))
        tableORI.Columns.Add(">TIPMAG.VAR", GetType(Double))
        tableORI.Columns.Add(">TIPPHS", GetType(Double))
        tableORI.Columns.Add(">ZSTRIKE", GetType(Double))
        tableORI.Columns.Add(">ZSKEW", GetType(Double))
        tableORI.Columns.Add(">ZELLIP", GetType(Double))
        tableORI.Columns.Add(">TSTRIKE", GetType(Double))
        tableORI.Columns.Add(">TSKEW", GetType(Double))
        tableORI.Columns.Add(">TELLIP", GetType(Double))
        tableORI.Columns.Add(">INDMAGR.EXP", GetType(Double))
        tableORI.Columns.Add(">INDMAGI.EXP", GetType(Double))
        tableORI.Columns.Add(">INDANGR.EXP", GetType(Double))
        tableORI.Columns.Add(">INDANGI.EXP", GetType(Double))

        tableZXX.Columns.Add(">NO", GetType(Integer))
        tableZXX.Columns.Add(">PERIODE", GetType(Double))
        tableZXX.Columns.Add(">ZXXI ROT=ZROT", GetType(Double))
        tableZXX.Columns.Add(">ZXXR ROT=ZROT", GetType(Double))
        tableRhoPhaXX.Columns.Add(">NO", GetType(Integer))
        tableRhoPhaXX.Columns.Add(">PERIODE", GetType(Double))
        tableRhoPhaXX.Columns.Add("RhoXX", GetType(Double))
        tableRhoPhaXX.Columns.Add("PhaXX", GetType(Double))

        tableZXY.Columns.Add(">NO", GetType(Integer))
        tableZXY.Columns.Add(">PERIODE", GetType(Double))
        tableZXY.Columns.Add("log(>ZXYI ROT=ZROT)", GetType(Double))
        tableZXY.Columns.Add("log(>ZXYR ROT=ZROT)", GetType(Double))
        tableZXY.Columns.Add(">RHOXY.FIT ROT=RHOROT", GetType(Double))
        tableZXY.Columns.Add(">PHSXY.FIT ROT=RHOROT", GetType(Double))
        tableRhoPhaXY.Columns.Add(">NO", GetType(Integer))
        tableRhoPhaXY.Columns.Add(">PERIODE", GetType(Double))
        tableRhoPhaXY.Columns.Add("RhoXY", GetType(Double))
        tableRhoPhaXY.Columns.Add("PhaXY", GetType(Double))
        tableRhoPhaXY.Columns.Add(">RHOXY.FIT ROT=RHOROT", GetType(Double))
        tableRhoPhaXY.Columns.Add(">PHSXY.FIT ROT=RHOROT", GetType(Double))

        tableZYX.Columns.Add(">NO", GetType(Integer))
        tableZYX.Columns.Add(">PERIODE", GetType(Double))
        tableZYX.Columns.Add("log(>ZYXI ROT=ZROT)", GetType(Double))
        tableZYX.Columns.Add("log(>ZYXR ROT=ZROT)", GetType(Double))
        tableZYX.Columns.Add(">RHOYX.FIT ROT=RHOROT", GetType(Double))
        tableZYX.Columns.Add(">PHSYX.FIT ROT=RHOROT", GetType(Double))
        tableRhoPhaYX.Columns.Add(">NO", GetType(Integer))
        tableRhoPhaYX.Columns.Add(">PERIODE", GetType(Double))
        tableRhoPhaYX.Columns.Add("RhoYX", GetType(Double))
        tableRhoPhaYX.Columns.Add("PhaYX", GetType(Double))
        tableRhoPhaYX.Columns.Add(">RHOYX.FIT ROT=RHOROT", GetType(Double))
        tableRhoPhaYX.Columns.Add(">PHSYX.FIT ROT=RHOROT", GetType(Double))

        tableZYY.Columns.Add(">NO", GetType(Integer))
        tableZYY.Columns.Add(">PERIODE", GetType(Double))
        tableZYY.Columns.Add(">ZYYI ROT=ZROT", GetType(Double))
        tableZYY.Columns.Add(">ZYYR ROT=ZROT", GetType(Double))
        tableRhoPhaYY.Columns.Add(">NO", GetType(Integer))
        tableRhoPhaYY.Columns.Add(">PERIODE", GetType(Double))
        tableRhoPhaYY.Columns.Add("RhoYY", GetType(Double))
        tableRhoPhaYY.Columns.Add("PhaYY", GetType(Double))

        tableTxZ.Columns.Add(">NO", GetType(Integer))
        tableTxZ.Columns.Add(">PERIODE", GetType(Double))
        tableTxZ.Columns.Add(">TXR.EXP", GetType(Double))
        tableTxZ.Columns.Add(">TXI.EXP", GetType(Double))
        tableTyZ.Columns.Add(">NO", GetType(Integer))
        tableTyZ.Columns.Add(">PERIODE", GetType(Double))
        tableTyZ.Columns.Add(">TYR.EXP", GetType(Double))
        tableTyZ.Columns.Add(">TYI.EXP", GetType(Double))
        Return 0
    End Function

    Function loadDash(ByVal minX As Double, ByVal maxX As Double,
                    ByVal minRh As Double, ByVal maxRh As Double,
                       ByVal minPh As Double, ByVal maxPh As Double) As Double

        MainWindow.ChartRhoDash.Series(0).MarkerStyle = MarkerStyle.Square
        MainWindow.ChartPhaDash.Series(0).MarkerStyle = MarkerStyle.Square
        MainWindow.ChartRhoDash.Series(1).MarkerStyle = MarkerStyle.Square
        MainWindow.ChartPhaDash.Series(1).MarkerStyle = MarkerStyle.Square
        MainWindow.ChartRhoDash.Series(2).MarkerStyle = MarkerStyle.Square
        MainWindow.ChartPhaDash.Series(2).MarkerStyle = MarkerStyle.Square
        MainWindow.ChartRhoDash.Series(3).MarkerStyle = MarkerStyle.Square
        MainWindow.ChartPhaDash.Series(3).MarkerStyle = MarkerStyle.Square

        MainWindow.ChartRhoDash.Series(0).MarkerSize = 5
        MainWindow.ChartPhaDash.Series(0).MarkerSize = 5
        MainWindow.ChartRhoDash.Series(1).MarkerSize = 5
        MainWindow.ChartPhaDash.Series(1).MarkerSize = 5
        MainWindow.ChartRhoDash.Series(2).MarkerSize = 5
        MainWindow.ChartPhaDash.Series(2).MarkerSize = 5
        MainWindow.ChartRhoDash.Series(3).MarkerSize = 5
        MainWindow.ChartPhaDash.Series(3).MarkerSize = 5

        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ rho
        MainWindow.ChartRhoDash.Series(0).Points.AddXY(100000, 100000)

        MainWindow.ChartRhoDash.Series(0).ChartType = SeriesChartType.Point
        MainWindow.ChartRhoDash.Series(0).IsVisibleInLegend = True
        MainWindow.ChartRhoDash.Series(0).Color = Color.DarkGreen

        MainWindow.ChartRhoDash.Series(1).ChartType = SeriesChartType.Point
        MainWindow.ChartRhoDash.Series(1).IsVisibleInLegend = True
        MainWindow.ChartRhoDash.Series(1).Color = Color.Red

        MainWindow.ChartRhoDash.Series(2).ChartType = SeriesChartType.Point
        MainWindow.ChartRhoDash.Series(2).IsVisibleInLegend = True
        MainWindow.ChartRhoDash.Series(2).Color = Color.Blue

        MainWindow.ChartRhoDash.Series(3).ChartType = SeriesChartType.Point
        MainWindow.ChartRhoDash.Series(3).IsVisibleInLegend = True
        MainWindow.ChartRhoDash.Series(3).Color = Color.Brown

        MainWindow.ChartRhoDash.Legends(0).Position.Auto = True
        MainWindow.ChartRhoDash.Legends(0).Docking = Docking.Top

        MainWindow.ChartRhoDash.ChartAreas(0).AxisX.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ x
        MainWindow.ChartRhoDash.ChartAreas(0).AxisX.IsLogarithmic = True
        MainWindow.ChartRhoDash.ChartAreas(0).AxisX.IsReversed = False
        MainWindow.ChartRhoDash.ChartAreas(0).AxisX.Minimum = minX
        MainWindow.ChartRhoDash.ChartAreas(0).AxisX.Maximum = maxX
        MainWindow.ChartRhoDash.ChartAreas(0).AxisX.Title = "Periode (second)"
        MainWindow.ChartRhoDash.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartRhoDash.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartRhoDash.ChartAreas(0).AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartRhoDash.ChartAreas(0).AxisX.MajorTickMark.Enabled = True
        MainWindow.ChartRhoDash.ChartAreas(0).AxisX.MajorTickMark.Interval = 1
        MainWindow.ChartRhoDash.ChartAreas(0).AxisX.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartRhoDash.ChartAreas(0).AxisX.MinorTickMark.Enabled = True
        MainWindow.ChartRhoDash.ChartAreas(0).AxisX.MinorTickMark.Interval = 1
        MainWindow.ChartRhoDash.ChartAreas(0).AxisX.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartRhoDash.ChartAreas(0).AxisY.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ y
        MainWindow.ChartRhoDash.ChartAreas(0).AxisY.IsLogarithmic = True
        MainWindow.ChartRhoDash.ChartAreas(0).AxisY.Minimum = minRh
        MainWindow.ChartRhoDash.ChartAreas(0).AxisY.Maximum = maxRh
        MainWindow.ChartRhoDash.ChartAreas(0).AxisY.Title = "App. Rho (ohm.m)"
        MainWindow.ChartRhoDash.ChartAreas(0).AxisY.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartRhoDash.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartRhoDash.ChartAreas(0).AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartRhoDash.ChartAreas(0).AxisY.MajorTickMark.Enabled = True
        MainWindow.ChartRhoDash.ChartAreas(0).AxisY.MajorTickMark.Interval = 1
        MainWindow.ChartRhoDash.ChartAreas(0).AxisY.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartRhoDash.ChartAreas(0).AxisY.MinorTickMark.Enabled = True
        MainWindow.ChartRhoDash.ChartAreas(0).AxisY.MinorTickMark.Interval = 1
        MainWindow.ChartRhoDash.ChartAreas(0).AxisY.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartRhoDash.ChartAreas(0).AxisY.LabelStyle.Angle = -90

        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ pha
        MainWindow.ChartPhaDash.Series(0).Points.AddXY(100000, 100000)

        MainWindow.ChartPhaDash.Series(0).ChartType = SeriesChartType.Point
        MainWindow.ChartPhaDash.Series(0).IsVisibleInLegend = False
        MainWindow.ChartPhaDash.Series(0).Color = Color.DarkGreen

        MainWindow.ChartPhaDash.Series(1).ChartType = SeriesChartType.Point
        MainWindow.ChartPhaDash.Series(1).IsVisibleInLegend = False
        MainWindow.ChartPhaDash.Series(1).Color = Color.Red

        MainWindow.ChartPhaDash.Series(2).ChartType = SeriesChartType.Point
        MainWindow.ChartPhaDash.Series(2).IsVisibleInLegend = False
        MainWindow.ChartPhaDash.Series(2).Color = Color.Blue

        MainWindow.ChartPhaDash.Series(3).ChartType = SeriesChartType.Point
        MainWindow.ChartPhaDash.Series(3).IsVisibleInLegend = False
        MainWindow.ChartPhaDash.Series(3).Color = Color.Brown

        MainWindow.ChartPhaDash.Legends(0).Position.Auto = True
        MainWindow.ChartPhaDash.Legends(0).Docking = Docking.Top

        MainWindow.ChartPhaDash.ChartAreas(0).AxisX.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ x
        MainWindow.ChartPhaDash.ChartAreas(0).AxisX.IsLogarithmic = True
        MainWindow.ChartPhaDash.ChartAreas(0).AxisX.IsReversed = False
        MainWindow.ChartPhaDash.ChartAreas(0).AxisX.Minimum = minX
        MainWindow.ChartPhaDash.ChartAreas(0).AxisX.Maximum = maxX
        MainWindow.ChartPhaDash.ChartAreas(0).AxisX.Title = "Periode (second)"
        MainWindow.ChartPhaDash.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartPhaDash.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartPhaDash.ChartAreas(0).AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartPhaDash.ChartAreas(0).AxisX.MajorTickMark.Enabled = True
        MainWindow.ChartPhaDash.ChartAreas(0).AxisX.MajorTickMark.Interval = 1
        MainWindow.ChartPhaDash.ChartAreas(0).AxisX.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartPhaDash.ChartAreas(0).AxisX.MinorTickMark.Enabled = True
        MainWindow.ChartPhaDash.ChartAreas(0).AxisX.MinorTickMark.Interval = 1
        MainWindow.ChartPhaDash.ChartAreas(0).AxisX.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartPhaDash.ChartAreas(0).AxisY.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ y
        MainWindow.ChartPhaDash.ChartAreas(0).AxisY.IsLogarithmic = False
        MainWindow.ChartPhaDash.ChartAreas(0).AxisY.Minimum = minPh
        MainWindow.ChartPhaDash.ChartAreas(0).AxisY.Maximum = maxPh
        MainWindow.ChartPhaDash.ChartAreas(0).AxisY.Interval = (maxPh - minPh) / 4
        MainWindow.ChartPhaDash.ChartAreas(0).AxisY.Title = "Phase (degree)"
        MainWindow.ChartPhaDash.ChartAreas(0).AxisY.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartPhaDash.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartPhaDash.ChartAreas(0).AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartPhaDash.ChartAreas(0).AxisY.MajorTickMark.Enabled = True
        'MainWindow.ChartPhaDash.ChartAreas(0).AxisY.MajorTickMark.Interval = 1
        MainWindow.ChartPhaDash.ChartAreas(0).AxisY.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartPhaDash.ChartAreas(0).AxisY.MinorTickMark.Enabled = False
        MainWindow.ChartPhaDash.ChartAreas(0).AxisY.MinorTickMark.Interval = 1
        MainWindow.ChartPhaDash.ChartAreas(0).AxisY.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartPhaDash.ChartAreas(0).AxisY.LabelStyle.Angle = -90

        ''~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Z
        'MainWindow.ChartZDash.Series(0).Points.AddXY(100000, 100000)
        'MainWindow.ChartZDash.Series(0).ChartType = SeriesChartType.Point
        'MainWindow.ChartZDash.Series(0).IsVisibleInLegend = True
        'MainWindow.ChartZDash.Series(0).Color = Color.Red

        'MainWindow.ChartZDash.Series(1).ChartType = SeriesChartType.Point
        'MainWindow.ChartZDash.Series(1).Color = Color.Blue

        'MainWindow.ChartZDash.Legends(0).Position.Auto = True
        'MainWindow.ChartZDash.Legends(0).Docking = Docking.Top

        'MainWindow.ChartZDash.ChartAreas(0).AxisX.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ x
        'MainWindow.ChartZDash.ChartAreas(0).AxisX.IsLogarithmic = True
        'MainWindow.ChartZDash.ChartAreas(0).AxisX.IsReversed = False
        'MainWindow.ChartZDash.ChartAreas(0).AxisX.Minimum = minX
        'MainWindow.ChartZDash.ChartAreas(0).AxisX.Maximum = maxX
        'MainWindow.ChartZDash.ChartAreas(0).AxisX.Title = "Periode (second)"
        'MainWindow.ChartZDash.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Arial", 8)
        'MainWindow.ChartZDash.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.Silver
        'MainWindow.ChartZDash.ChartAreas(0).AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        'MainWindow.ChartZDash.ChartAreas(0).AxisX.MajorTickMark.Enabled = True
        'MainWindow.ChartZDash.ChartAreas(0).AxisX.MajorTickMark.Interval = 1
        'MainWindow.ChartZDash.ChartAreas(0).AxisX.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        'MainWindow.ChartZDash.ChartAreas(0).AxisX.MinorTickMark.Enabled = True
        'MainWindow.ChartZDash.ChartAreas(0).AxisX.MinorTickMark.Interval = 1
        'MainWindow.ChartZDash.ChartAreas(0).AxisX.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        'MainWindow.ChartZDash.ChartAreas(0).AxisY.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ y
        'MainWindow.ChartZDash.ChartAreas(0).AxisY.IsLogarithmic = False
        'MainWindow.ChartZDash.ChartAreas(0).AxisY.Minimum = minZ
        'MainWindow.ChartZDash.ChartAreas(0).AxisY.Maximum = maxZ
        ''MainWindow.ChartZDash.ChartAreas(0).AxisY.Interval = (maxPh - minPh) / 4
        'MainWindow.ChartZDash.ChartAreas(0).AxisY.Title = "ZDash"
        'MainWindow.ChartZDash.ChartAreas(0).AxisY.LabelStyle.Font = New Font("Arial", 8)
        'MainWindow.ChartZDash.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.Silver
        'MainWindow.ChartZDash.ChartAreas(0).AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        'MainWindow.ChartZDash.ChartAreas(0).AxisY.MajorTickMark.Enabled = True
        ''MainWindow.chartZDash.ChartAreas(0).AxisY.MajorTickMark.Interval = 1
        'MainWindow.ChartZDash.ChartAreas(0).AxisY.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        'MainWindow.ChartZDash.ChartAreas(0).AxisY.MinorTickMark.Enabled = False
        'MainWindow.ChartZDash.ChartAreas(0).AxisY.MinorTickMark.Interval = 1
        'MainWindow.ChartZDash.ChartAreas(0).AxisY.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        'MainWindow.ChartZDash.ChartAreas(0).AxisY.LabelStyle.Angle = -90

        Return 0
    End Function

    Function loadZxx(ByVal minX As Double, ByVal maxX As Double,
                     ByVal minRh As Double, ByVal maxRh As Double,
                        ByVal minPh As Double, ByVal maxPh As Double,
                        ByVal minZ As Double, ByVal maxZ As Double) As Double

        MainWindow.ChartRhoXX.Series(0).MarkerStyle = MarkerStyle.Square
        MainWindow.ChartPhaXX.Series(0).MarkerStyle = MarkerStyle.Square
        MainWindow.ChartZXX.Series(0).MarkerStyle = MarkerStyle.Square
        MainWindow.ChartZXX.Series(1).MarkerStyle = MarkerStyle.Square

        MainWindow.ChartRhoXX.Series(0).MarkerSize = 5
        MainWindow.ChartPhaXX.Series(0).MarkerSize = 5
        MainWindow.ChartZXX.Series(0).MarkerSize = 5
        MainWindow.ChartZXX.Series(1).MarkerSize = 5
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ rho
        MainWindow.ChartRhoXX.Series(0).Points.AddXY(100000, 100000)
        MainWindow.ChartRhoXX.Series(0).ChartType = SeriesChartType.Point
        MainWindow.ChartRhoXX.Series(0).IsVisibleInLegend = True
        MainWindow.ChartRhoXX.Series(0).Color = Color.DarkGreen

        MainWindow.ChartRhoXX.Legends(0).Position.Auto = True
        MainWindow.ChartRhoXX.Legends(0).Docking = Docking.Top

        MainWindow.ChartRhoXX.ChartAreas(0).AxisX.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ x
        MainWindow.ChartRhoXX.ChartAreas(0).AxisX.IsLogarithmic = True
        MainWindow.ChartRhoXX.ChartAreas(0).AxisX.IsReversed = False
        MainWindow.ChartRhoXX.ChartAreas(0).AxisX.Minimum = minX
        MainWindow.ChartRhoXX.ChartAreas(0).AxisX.Maximum = maxX
        MainWindow.ChartRhoXX.ChartAreas(0).AxisX.Title = "Periode (second)"
        MainWindow.ChartRhoXX.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartRhoXX.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartRhoXX.ChartAreas(0).AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartRhoXX.ChartAreas(0).AxisX.MajorTickMark.Enabled = True
        MainWindow.ChartRhoXX.ChartAreas(0).AxisX.MajorTickMark.Interval = 1
        MainWindow.ChartRhoXX.ChartAreas(0).AxisX.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartRhoXX.ChartAreas(0).AxisX.MinorTickMark.Enabled = True
        MainWindow.ChartRhoXX.ChartAreas(0).AxisX.MinorTickMark.Interval = 1
        MainWindow.ChartRhoXX.ChartAreas(0).AxisX.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartRhoXX.ChartAreas(0).AxisY.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ y
        MainWindow.ChartRhoXX.ChartAreas(0).AxisY.IsLogarithmic = True
        MainWindow.ChartRhoXX.ChartAreas(0).AxisY.Minimum = minRh
        MainWindow.ChartRhoXX.ChartAreas(0).AxisY.Maximum = maxRh
        MainWindow.ChartRhoXX.ChartAreas(0).AxisY.Title = "App. Rho (ohm.m)"
        MainWindow.ChartRhoXX.ChartAreas(0).AxisY.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartRhoXX.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartRhoXX.ChartAreas(0).AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartRhoXX.ChartAreas(0).AxisY.MajorTickMark.Enabled = True
        MainWindow.ChartRhoXX.ChartAreas(0).AxisY.MajorTickMark.Interval = 1
        MainWindow.ChartRhoXX.ChartAreas(0).AxisY.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartRhoXX.ChartAreas(0).AxisY.MinorTickMark.Enabled = True
        MainWindow.ChartRhoXX.ChartAreas(0).AxisY.MinorTickMark.Interval = 1
        MainWindow.ChartRhoXX.ChartAreas(0).AxisY.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartRhoXX.ChartAreas(0).AxisY.LabelStyle.Angle = -90

        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ pha
        MainWindow.ChartPhaXX.Series(0).Points.AddXY(100000, 100000)
        MainWindow.ChartPhaXX.Series(0).ChartType = SeriesChartType.Point
        MainWindow.ChartPhaXX.Series(0).IsVisibleInLegend = False
        MainWindow.ChartPhaXX.Series(0).Color = Color.DarkGreen

        MainWindow.ChartPhaXX.Legends(0).Position.Auto = True
        MainWindow.ChartPhaXX.Legends(0).Docking = Docking.Top

        MainWindow.ChartPhaXX.ChartAreas(0).AxisX.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ x
        MainWindow.ChartPhaXX.ChartAreas(0).AxisX.IsLogarithmic = True
        MainWindow.ChartPhaXX.ChartAreas(0).AxisX.IsReversed = False
        MainWindow.ChartPhaXX.ChartAreas(0).AxisX.Minimum = minX
        MainWindow.ChartPhaXX.ChartAreas(0).AxisX.Maximum = maxX
        MainWindow.ChartPhaXX.ChartAreas(0).AxisX.Title = "Periode (second)"
        MainWindow.ChartPhaXX.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartPhaXX.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartPhaXX.ChartAreas(0).AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartPhaXX.ChartAreas(0).AxisX.MajorTickMark.Enabled = True
        MainWindow.ChartPhaXX.ChartAreas(0).AxisX.MajorTickMark.Interval = 1
        MainWindow.ChartPhaXX.ChartAreas(0).AxisX.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartPhaXX.ChartAreas(0).AxisX.MinorTickMark.Enabled = True
        MainWindow.ChartPhaXX.ChartAreas(0).AxisX.MinorTickMark.Interval = 1
        MainWindow.ChartPhaXX.ChartAreas(0).AxisX.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartPhaXX.ChartAreas(0).AxisY.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ y
        MainWindow.ChartPhaXX.ChartAreas(0).AxisY.IsLogarithmic = False
        MainWindow.ChartPhaXX.ChartAreas(0).AxisY.Minimum = minPh
        MainWindow.ChartPhaXX.ChartAreas(0).AxisY.Maximum = maxPh
        MainWindow.ChartPhaXX.ChartAreas(0).AxisY.Interval = (maxPh - minPh) / 4
        MainWindow.ChartPhaXX.ChartAreas(0).AxisY.Title = "Phase (degree)"
        MainWindow.ChartPhaXX.ChartAreas(0).AxisY.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartPhaXX.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartPhaXX.ChartAreas(0).AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartPhaXX.ChartAreas(0).AxisY.MajorTickMark.Enabled = True
        'MainWindow.ChartPhaXX.ChartAreas(0).AxisY.MajorTickMark.Interval = 1
        MainWindow.ChartPhaXX.ChartAreas(0).AxisY.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartPhaXX.ChartAreas(0).AxisY.MinorTickMark.Enabled = False
        MainWindow.ChartPhaXX.ChartAreas(0).AxisY.MinorTickMark.Interval = 1
        MainWindow.ChartPhaXX.ChartAreas(0).AxisY.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartPhaXX.ChartAreas(0).AxisY.LabelStyle.Angle = -90

        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Z
        MainWindow.ChartZXX.Series(0).Points.AddXY(100000, 100000)
        MainWindow.ChartZXX.Series(0).ChartType = SeriesChartType.Point
        MainWindow.ChartZXX.Series(0).IsVisibleInLegend = True
        MainWindow.ChartZXX.Series(0).Color = Color.Red

        MainWindow.ChartZXX.Series(1).ChartType = SeriesChartType.Point
        MainWindow.ChartZXX.Series(1).Color = Color.Blue

        MainWindow.ChartZXX.Legends(0).Position.Auto = True
        MainWindow.ChartZXX.Legends(0).Docking = Docking.Top

        MainWindow.ChartZXX.ChartAreas(0).AxisX.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ x
        MainWindow.ChartZXX.ChartAreas(0).AxisX.IsLogarithmic = True
        MainWindow.ChartZXX.ChartAreas(0).AxisX.IsReversed = False
        MainWindow.ChartZXX.ChartAreas(0).AxisX.Minimum = minX
        MainWindow.ChartZXX.ChartAreas(0).AxisX.Maximum = maxX
        MainWindow.ChartZXX.ChartAreas(0).AxisX.Title = "Periode (second)"
        MainWindow.ChartZXX.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartZXX.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartZXX.ChartAreas(0).AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartZXX.ChartAreas(0).AxisX.MajorTickMark.Enabled = False
        MainWindow.ChartZXX.ChartAreas(0).AxisX.MajorTickMark.Interval = 1
        MainWindow.ChartZXX.ChartAreas(0).AxisX.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartZXX.ChartAreas(0).AxisX.MinorTickMark.Enabled = True
        MainWindow.ChartZXX.ChartAreas(0).AxisX.MinorTickMark.Interval = 1
        MainWindow.ChartZXX.ChartAreas(0).AxisX.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartZXX.ChartAreas(0).AxisY.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ y
        MainWindow.ChartZXX.ChartAreas(0).AxisY.IsLogarithmic = False
        MainWindow.ChartZXX.ChartAreas(0).AxisY.Minimum = minZ
        MainWindow.ChartZXX.ChartAreas(0).AxisY.Maximum = maxZ
        MainWindow.ChartZXX.ChartAreas(0).AxisY.Interval = 1
        MainWindow.ChartZXX.ChartAreas(0).AxisY.Title = "Zxx"
        MainWindow.ChartZXX.ChartAreas(0).AxisY.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartZXX.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartZXX.ChartAreas(0).AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartZXX.ChartAreas(0).AxisY.MajorTickMark.Enabled = True
        'MainWindow.chartZxx.ChartAreas(0).AxisY.MajorTickMark.Interval = 1
        MainWindow.ChartZXX.ChartAreas(0).AxisY.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartZXX.ChartAreas(0).AxisY.MinorTickMark.Enabled = False
        MainWindow.ChartZXX.ChartAreas(0).AxisY.MinorTickMark.Interval = 1
        MainWindow.ChartZXX.ChartAreas(0).AxisY.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartZXX.ChartAreas(0).AxisY.LabelStyle.Angle = -90

        Return 0
    End Function

    Function loadZxy(ByVal minX As Double, ByVal maxX As Double,
                     ByVal minRh As Double, ByVal maxRh As Double,
                        ByVal minPh As Double, ByVal maxPh As Double,
                        ByVal minZ As Double, ByVal maxZ As Double) As Double

        MainWindow.ChartRhoXY.Series(0).MarkerStyle = MarkerStyle.Square
        MainWindow.ChartPhaXY.Series(0).MarkerStyle = MarkerStyle.Square
        MainWindow.ChartZXY.Series(0).MarkerStyle = MarkerStyle.Square
        MainWindow.ChartZXY.Series(1).MarkerStyle = MarkerStyle.Square

        MainWindow.ChartRhoXY.Series(0).MarkerSize = 5
        MainWindow.ChartPhaXY.Series(0).MarkerSize = 5
        MainWindow.ChartZXY.Series(0).MarkerSize = 5
        MainWindow.ChartZXY.Series(1).MarkerSize = 5
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ rho
        MainWindow.ChartRhoXY.Series(0).Points.AddXY(100000, 100000)
        MainWindow.ChartRhoXY.Series(0).ChartType = SeriesChartType.Point
        MainWindow.ChartRhoXY.Series(0).IsVisibleInLegend = True
        MainWindow.ChartRhoXY.Series(0).Color = Color.Red

        MainWindow.ChartRhoXY.Series(1).ChartType = SeriesChartType.Spline
        MainWindow.ChartRhoXY.Series(1).Color = Color.Red

        MainWindow.ChartRhoXY.Legends(0).Position.Auto = True
        MainWindow.ChartRhoXY.Legends(0).Docking = Docking.Top

        MainWindow.ChartRhoXY.ChartAreas(0).AxisX.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ x
        MainWindow.ChartRhoXY.ChartAreas(0).AxisX.IsLogarithmic = True
        MainWindow.ChartRhoXY.ChartAreas(0).AxisX.IsReversed = False
        MainWindow.ChartRhoXY.ChartAreas(0).AxisX.Minimum = minX
        MainWindow.ChartRhoXY.ChartAreas(0).AxisX.Maximum = maxX
        MainWindow.ChartRhoXY.ChartAreas(0).AxisX.Title = "Periode (second)"
        MainWindow.ChartRhoXY.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartRhoXY.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartRhoXY.ChartAreas(0).AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartRhoXY.ChartAreas(0).AxisX.MajorTickMark.Enabled = True
        MainWindow.ChartRhoXY.ChartAreas(0).AxisX.MajorTickMark.Interval = 1
        MainWindow.ChartRhoXY.ChartAreas(0).AxisX.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartRhoXY.ChartAreas(0).AxisX.MinorTickMark.Enabled = True
        MainWindow.ChartRhoXY.ChartAreas(0).AxisX.MinorTickMark.Interval = 1
        MainWindow.ChartRhoXY.ChartAreas(0).AxisX.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartRhoXY.ChartAreas(0).AxisY.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ y
        MainWindow.ChartRhoXY.ChartAreas(0).AxisY.IsLogarithmic = True
        MainWindow.ChartRhoXY.ChartAreas(0).AxisY.Minimum = minRh
        MainWindow.ChartRhoXY.ChartAreas(0).AxisY.Maximum = maxRh
        MainWindow.ChartRhoXY.ChartAreas(0).AxisY.Title = "App. Rho (ohm.m)"
        MainWindow.ChartRhoXY.ChartAreas(0).AxisY.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartRhoXY.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartRhoXY.ChartAreas(0).AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartRhoXY.ChartAreas(0).AxisY.MajorTickMark.Enabled = True
        MainWindow.ChartRhoXY.ChartAreas(0).AxisY.MajorTickMark.Interval = 1
        MainWindow.ChartRhoXY.ChartAreas(0).AxisY.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartRhoXY.ChartAreas(0).AxisY.MinorTickMark.Enabled = True
        MainWindow.ChartRhoXY.ChartAreas(0).AxisY.MinorTickMark.Interval = 1
        MainWindow.ChartRhoXY.ChartAreas(0).AxisY.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartRhoXY.ChartAreas(0).AxisY.LabelStyle.Angle = -90

        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ pha
        MainWindow.ChartPhaXY.Series(0).Points.AddXY(100000, 100000)
        MainWindow.ChartPhaXY.Series(0).ChartType = SeriesChartType.Point
        MainWindow.ChartPhaXY.Series(0).IsVisibleInLegend = False
        MainWindow.ChartPhaXY.Series(0).Color = Color.Red

        MainWindow.ChartPhaXY.Series(1).ChartType = SeriesChartType.Spline
        MainWindow.ChartPhaXY.Series(1).IsVisibleInLegend = False
        MainWindow.ChartPhaXY.Series(1).Color = Color.Red

        MainWindow.ChartPhaXY.Legends(0).Position.Auto = True
        MainWindow.ChartPhaXY.Legends(0).Docking = Docking.Top

        MainWindow.ChartPhaXY.ChartAreas(0).AxisX.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ x
        MainWindow.ChartPhaXY.ChartAreas(0).AxisX.IsLogarithmic = True
        MainWindow.ChartPhaXY.ChartAreas(0).AxisX.IsReversed = False
        MainWindow.ChartPhaXY.ChartAreas(0).AxisX.Minimum = minX
        MainWindow.ChartPhaXY.ChartAreas(0).AxisX.Maximum = maxX
        MainWindow.ChartPhaXY.ChartAreas(0).AxisX.Title = "Periode (second)"
        MainWindow.ChartPhaXY.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartPhaXY.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartPhaXY.ChartAreas(0).AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartPhaXY.ChartAreas(0).AxisX.MajorTickMark.Enabled = True
        MainWindow.ChartPhaXY.ChartAreas(0).AxisX.MajorTickMark.Interval = 1
        MainWindow.ChartPhaXY.ChartAreas(0).AxisX.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartPhaXY.ChartAreas(0).AxisX.MinorTickMark.Enabled = True
        MainWindow.ChartPhaXY.ChartAreas(0).AxisX.MinorTickMark.Interval = 1
        MainWindow.ChartPhaXY.ChartAreas(0).AxisX.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartPhaXY.ChartAreas(0).AxisY.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ y
        MainWindow.ChartPhaXY.ChartAreas(0).AxisY.IsLogarithmic = False
        MainWindow.ChartPhaXY.ChartAreas(0).AxisY.Minimum = minPh
        MainWindow.ChartPhaXY.ChartAreas(0).AxisY.Maximum = maxPh
        MainWindow.ChartPhaXY.ChartAreas(0).AxisY.Interval = (maxPh - minPh) / 4
        MainWindow.ChartPhaXY.ChartAreas(0).AxisY.Title = "Phase (degree)"
        MainWindow.ChartPhaXY.ChartAreas(0).AxisY.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartPhaXY.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartPhaXY.ChartAreas(0).AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartPhaXY.ChartAreas(0).AxisY.MajorTickMark.Enabled = True
        'MainWindow.ChartPhaxy.ChartAreas(0).AxisY.MajorTickMark.Interval = 1
        MainWindow.ChartPhaXY.ChartAreas(0).AxisY.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartPhaXY.ChartAreas(0).AxisY.MinorTickMark.Enabled = False
        MainWindow.ChartPhaXY.ChartAreas(0).AxisY.MinorTickMark.Interval = 1
        MainWindow.ChartPhaXY.ChartAreas(0).AxisY.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartPhaXY.ChartAreas(0).AxisY.LabelStyle.Angle = -90

        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Z
        MainWindow.ChartZXY.Series(0).Points.AddXY(100000, 100000)
        MainWindow.ChartZXY.Series(0).ChartType = SeriesChartType.Point
        MainWindow.ChartZXY.Series(0).IsVisibleInLegend = True
        MainWindow.ChartZXY.Series(0).Color = Color.Red

        MainWindow.ChartZXY.Series(1).ChartType = SeriesChartType.Point
        MainWindow.ChartZXY.Series(1).Color = Color.Blue

        MainWindow.ChartZXY.Legends(0).Position.Auto = True
        MainWindow.ChartZXY.Legends(0).Docking = Docking.Top

        MainWindow.ChartZXY.ChartAreas(0).AxisX.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ x
        MainWindow.ChartZXY.ChartAreas(0).AxisX.IsLogarithmic = True
        MainWindow.ChartZXY.ChartAreas(0).AxisX.IsReversed = False
        MainWindow.ChartZXY.ChartAreas(0).AxisX.Minimum = minX
        MainWindow.ChartZXY.ChartAreas(0).AxisX.Maximum = maxX
        MainWindow.ChartZXY.ChartAreas(0).AxisX.Title = "Periode (second)"
        MainWindow.ChartZXY.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartZXY.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartZXY.ChartAreas(0).AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartZXY.ChartAreas(0).AxisX.MajorTickMark.Enabled = True
        MainWindow.ChartZXY.ChartAreas(0).AxisX.MajorTickMark.Interval = 1
        MainWindow.ChartZXY.ChartAreas(0).AxisX.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartZXY.ChartAreas(0).AxisX.MinorTickMark.Enabled = True
        MainWindow.ChartZXY.ChartAreas(0).AxisX.MinorTickMark.Interval = 1
        MainWindow.ChartZXY.ChartAreas(0).AxisX.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartZXY.ChartAreas(0).AxisY.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ y
        MainWindow.ChartZXY.ChartAreas(0).AxisY.IsLogarithmic = False
        MainWindow.ChartZXY.ChartAreas(0).AxisY.Minimum = minZ
        MainWindow.ChartZXY.ChartAreas(0).AxisY.Maximum = maxZ
        MainWindow.ChartZXY.ChartAreas(0).AxisY.Interval = 1
        MainWindow.ChartZXY.ChartAreas(0).AxisY.Title = "Zxy"
        MainWindow.ChartZXY.ChartAreas(0).AxisY.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartZXY.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartZXY.ChartAreas(0).AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartZXY.ChartAreas(0).AxisY.MajorTickMark.Enabled = True
        'MainWindow.chartZxy.ChartAreas(0).AxisY.MajorTickMark.Interval = 1
        MainWindow.ChartZXY.ChartAreas(0).AxisY.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartZXY.ChartAreas(0).AxisY.MinorTickMark.Enabled = False
        MainWindow.ChartZXY.ChartAreas(0).AxisY.MinorTickMark.Interval = 1
        MainWindow.ChartZXY.ChartAreas(0).AxisY.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartZXY.ChartAreas(0).AxisY.LabelStyle.Angle = -90

        Return 0
    End Function

    Function loadZyx(ByVal minX As Double, ByVal maxX As Double,
                     ByVal minRh As Double, ByVal maxRh As Double,
                        ByVal minPh As Double, ByVal maxPh As Double,
                        ByVal minZ As Double, ByVal maxZ As Double) As Double

        MainWindow.ChartRhoYX.Series(0).MarkerStyle = MarkerStyle.Square
        MainWindow.ChartPhaYX.Series(0).MarkerStyle = MarkerStyle.Square
        MainWindow.ChartZYX.Series(0).MarkerStyle = MarkerStyle.Square
        MainWindow.ChartZYX.Series(1).MarkerStyle = MarkerStyle.Square

        MainWindow.ChartRhoYX.Series(0).MarkerSize = 5
        MainWindow.ChartPhaYX.Series(0).MarkerSize = 5
        MainWindow.ChartZYX.Series(0).MarkerSize = 5
        MainWindow.ChartZYX.Series(1).MarkerSize = 5
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ rho
        MainWindow.ChartRhoYX.Series(0).Points.AddXY(100000, 100000)
        MainWindow.ChartRhoYX.Series(0).ChartType = SeriesChartType.Point
        MainWindow.ChartRhoYX.Series(0).IsVisibleInLegend = True
        MainWindow.ChartRhoYX.Series(0).Color = Color.Blue

        MainWindow.ChartRhoYX.Series(1).ChartType = SeriesChartType.Spline
        MainWindow.ChartRhoYX.Series(1).Color = Color.Blue

        MainWindow.ChartRhoYX.Legends(0).Position.Auto = True
        MainWindow.ChartRhoYX.Legends(0).Docking = Docking.Top

        MainWindow.ChartRhoYX.ChartAreas(0).AxisX.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ x
        MainWindow.ChartRhoYX.ChartAreas(0).AxisX.IsLogarithmic = True
        MainWindow.ChartRhoYX.ChartAreas(0).AxisX.IsReversed = False
        MainWindow.ChartRhoYX.ChartAreas(0).AxisX.Minimum = minX
        MainWindow.ChartRhoYX.ChartAreas(0).AxisX.Maximum = maxX
        MainWindow.ChartRhoYX.ChartAreas(0).AxisX.Title = "Periode (second)"
        MainWindow.ChartRhoYX.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartRhoYX.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartRhoYX.ChartAreas(0).AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartRhoYX.ChartAreas(0).AxisX.MajorTickMark.Enabled = True
        MainWindow.ChartRhoYX.ChartAreas(0).AxisX.MajorTickMark.Interval = 1
        MainWindow.ChartRhoYX.ChartAreas(0).AxisX.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartRhoYX.ChartAreas(0).AxisX.MinorTickMark.Enabled = True
        MainWindow.ChartRhoYX.ChartAreas(0).AxisX.MinorTickMark.Interval = 1
        MainWindow.ChartRhoYX.ChartAreas(0).AxisX.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartRhoYX.ChartAreas(0).AxisY.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ y
        MainWindow.ChartRhoYX.ChartAreas(0).AxisY.IsLogarithmic = True
        MainWindow.ChartRhoYX.ChartAreas(0).AxisY.Minimum = minRh
        MainWindow.ChartRhoYX.ChartAreas(0).AxisY.Maximum = maxRh
        MainWindow.ChartRhoYX.ChartAreas(0).AxisY.Title = "App. Rho (ohm.m)"
        MainWindow.ChartRhoYX.ChartAreas(0).AxisY.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartRhoYX.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartRhoYX.ChartAreas(0).AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartRhoYX.ChartAreas(0).AxisY.MajorTickMark.Enabled = True
        MainWindow.ChartRhoYX.ChartAreas(0).AxisY.MajorTickMark.Interval = 1
        MainWindow.ChartRhoYX.ChartAreas(0).AxisY.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartRhoYX.ChartAreas(0).AxisY.MinorTickMark.Enabled = True
        MainWindow.ChartRhoYX.ChartAreas(0).AxisY.MinorTickMark.Interval = 1
        MainWindow.ChartRhoYX.ChartAreas(0).AxisY.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartRhoYX.ChartAreas(0).AxisY.LabelStyle.Angle = -90

        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ pha
        MainWindow.ChartPhaYX.Series(0).Points.AddXY(100000, 100000)
        MainWindow.ChartPhaYX.Series(0).ChartType = SeriesChartType.Point
        MainWindow.ChartPhaYX.Series(0).IsVisibleInLegend = False
        MainWindow.ChartPhaYX.Series(0).Color = Color.Blue

        MainWindow.ChartPhaYX.Series(1).ChartType = SeriesChartType.Spline
        MainWindow.ChartPhaYX.Series(1).IsVisibleInLegend = False
        MainWindow.ChartPhaYX.Series(1).Color = Color.Blue

        MainWindow.ChartPhaYX.Legends(0).Position.Auto = True
        MainWindow.ChartPhaYX.Legends(0).Docking = Docking.Top

        MainWindow.ChartPhaYX.ChartAreas(0).AxisX.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ x
        MainWindow.ChartPhaYX.ChartAreas(0).AxisX.IsLogarithmic = True
        MainWindow.ChartPhaYX.ChartAreas(0).AxisX.IsReversed = False
        MainWindow.ChartPhaYX.ChartAreas(0).AxisX.Minimum = minX
        MainWindow.ChartPhaYX.ChartAreas(0).AxisX.Maximum = maxX
        MainWindow.ChartPhaYX.ChartAreas(0).AxisX.Title = "Periode (second)"
        MainWindow.ChartPhaYX.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartPhaYX.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartPhaYX.ChartAreas(0).AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartPhaYX.ChartAreas(0).AxisX.MajorTickMark.Enabled = True
        MainWindow.ChartPhaYX.ChartAreas(0).AxisX.MajorTickMark.Interval = 1
        MainWindow.ChartPhaYX.ChartAreas(0).AxisX.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartPhaYX.ChartAreas(0).AxisX.MinorTickMark.Enabled = True
        MainWindow.ChartPhaYX.ChartAreas(0).AxisX.MinorTickMark.Interval = 1
        MainWindow.ChartPhaYX.ChartAreas(0).AxisX.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartPhaYX.ChartAreas(0).AxisY.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ y
        MainWindow.ChartPhaYX.ChartAreas(0).AxisY.IsLogarithmic = False
        MainWindow.ChartPhaYX.ChartAreas(0).AxisY.Minimum = minPh
        MainWindow.ChartPhaYX.ChartAreas(0).AxisY.Maximum = maxPh
        MainWindow.ChartPhaYX.ChartAreas(0).AxisY.Interval = (maxPh - minPh) / 4
        MainWindow.ChartPhaYX.ChartAreas(0).AxisY.Title = "Phase (degree)"
        MainWindow.ChartPhaYX.ChartAreas(0).AxisY.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartPhaYX.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartPhaYX.ChartAreas(0).AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartPhaYX.ChartAreas(0).AxisY.MajorTickMark.Enabled = True
        'MainWindow.ChartPhayx.ChartAreas(0).AxisY.MajorTickMark.Interval = 1
        MainWindow.ChartPhaYX.ChartAreas(0).AxisY.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartPhaYX.ChartAreas(0).AxisY.MinorTickMark.Enabled = False
        MainWindow.ChartPhaYX.ChartAreas(0).AxisY.MinorTickMark.Interval = 1
        MainWindow.ChartPhaYX.ChartAreas(0).AxisY.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartPhaYX.ChartAreas(0).AxisY.LabelStyle.Angle = -90

        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Z
        MainWindow.ChartZYX.Series(0).Points.AddXY(100000, 100000)
        MainWindow.ChartZYX.Series(0).ChartType = SeriesChartType.Point
        MainWindow.ChartZYX.Series(0).IsVisibleInLegend = True
        MainWindow.ChartZYX.Series(0).Color = Color.Red

        MainWindow.ChartZYX.Series(1).ChartType = SeriesChartType.Point
        MainWindow.ChartZYX.Series(1).Color = Color.Blue

        MainWindow.ChartZYX.Legends(0).Position.Auto = True
        MainWindow.ChartZYX.Legends(0).Docking = Docking.Top

        MainWindow.ChartZYX.ChartAreas(0).AxisX.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ x
        MainWindow.ChartZYX.ChartAreas(0).AxisX.IsLogarithmic = True
        MainWindow.ChartZYX.ChartAreas(0).AxisX.IsReversed = False
        MainWindow.ChartZYX.ChartAreas(0).AxisX.Minimum = minX
        MainWindow.ChartZYX.ChartAreas(0).AxisX.Maximum = maxX
        MainWindow.ChartZYX.ChartAreas(0).AxisX.Title = "Periode (second)"
        MainWindow.ChartZYX.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartZYX.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartZYX.ChartAreas(0).AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartZYX.ChartAreas(0).AxisX.MajorTickMark.Enabled = True
        MainWindow.ChartZYX.ChartAreas(0).AxisX.MajorTickMark.Interval = 1
        MainWindow.ChartZYX.ChartAreas(0).AxisX.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartZYX.ChartAreas(0).AxisX.MinorTickMark.Enabled = True
        MainWindow.ChartZYX.ChartAreas(0).AxisX.MinorTickMark.Interval = 1
        MainWindow.ChartZYX.ChartAreas(0).AxisX.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartZYX.ChartAreas(0).AxisY.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ y
        MainWindow.ChartZYX.ChartAreas(0).AxisY.IsLogarithmic = False
        MainWindow.ChartZYX.ChartAreas(0).AxisY.Minimum = minZ
        MainWindow.ChartZYX.ChartAreas(0).AxisY.Maximum = maxZ
        MainWindow.ChartZYX.ChartAreas(0).AxisY.Interval = 1
        MainWindow.ChartZYX.ChartAreas(0).AxisY.Title = "Zyx"
        MainWindow.ChartZYX.ChartAreas(0).AxisY.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartZYX.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartZYX.ChartAreas(0).AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartZYX.ChartAreas(0).AxisY.MajorTickMark.Enabled = True
        'MainWindow.chartZyx.ChartAreas(0).AxisY.MajorTickMark.Interval = 1
        MainWindow.ChartZYX.ChartAreas(0).AxisY.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartZYX.ChartAreas(0).AxisY.MinorTickMark.Enabled = False
        MainWindow.ChartZYX.ChartAreas(0).AxisY.MinorTickMark.Interval = 1
        MainWindow.ChartZYX.ChartAreas(0).AxisY.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartZYX.ChartAreas(0).AxisY.LabelStyle.Angle = -90

        'MainWindow.ChartRhoYX.Series(0).Points.AddXY(100000, 100000)
        'MainWindow.ChartRhoYX.Series(0).ChartType = SeriesChartType.Point
        'MainWindow.ChartRhoYX.Series(0).IsVisibleInLegend = True
        'MainWindow.ChartRhoYX.Legends(0).Position.Auto = True
        'MainWindow.ChartRhoYX.Legends(0).Docking = Docking.Top
        'MainWindow.ChartRhoYX.Series(0).Color = Color.DarkBlue
        'MainWindow.ChartRhoYX.Series(1).Color = Color.Blue

        'MainWindow.ChartRhoYX.Series(1).ChartType = SeriesChartType.Spline
        'MainWindow.ChartRhoYX.Series(1).IsVisibleInLegend = True

        'MainWindow.ChartRhoYX.ChartAreas(0).AxisX.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ x
        'MainWindow.ChartRhoYX.ChartAreas(0).AxisX.IsLogarithmic = True
        'MainWindow.ChartRhoYX.ChartAreas(0).AxisX.IsReversed = False
        'MainWindow.ChartRhoYX.ChartAreas(0).AxisX.Minimum = minX
        'MainWindow.ChartRhoYX.ChartAreas(0).AxisX.Maximum = maxX
        'MainWindow.ChartRhoYX.ChartAreas(0).AxisX.Title = "Periode (second)"
        'MainWindow.ChartRhoYX.ChartAreas(0).AxisX.MinorTickMark.Enabled = True
        'MainWindow.ChartRhoYX.ChartAreas(0).AxisX.MinorTickMark.Interval = 1
        'MainWindow.ChartRhoYX.ChartAreas(0).AxisX.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        'MainWindow.ChartRhoYX.ChartAreas(0).AxisY.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ y
        'MainWindow.ChartRhoYX.ChartAreas(0).AxisY.IsLogarithmic = True
        'MainWindow.ChartRhoYX.ChartAreas(0).AxisY.Minimum = minRh
        'MainWindow.ChartRhoYX.ChartAreas(0).AxisY.Maximum = maxRh
        'MainWindow.ChartRhoYX.ChartAreas(0).AxisY.Title = "App. Rho (ohm.m)"
        'MainWindow.ChartRhoYX.ChartAreas(0).AxisY.MinorTickMark.Enabled = True
        'MainWindow.ChartRhoYX.ChartAreas(0).AxisY.MinorTickMark.Interval = 1
        'MainWindow.ChartRhoYX.ChartAreas(0).AxisY.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis

        'MainWindow.ChartPhaYX.Series(0).Points.AddXY(100000, 100000)
        'MainWindow.ChartPhaYX.Series(0).ChartType = SeriesChartType.Point
        'MainWindow.ChartPhaYX.Series(0).IsVisibleInLegend = False
        'MainWindow.ChartPhaYX.Series(0).Color = Color.DarkBlue
        'MainWindow.ChartPhaYX.Series(1).Color = Color.Blue

        'MainWindow.ChartPhaYX.Series(1).ChartType = SeriesChartType.Spline
        'MainWindow.ChartPhaYX.Series(1).IsVisibleInLegend = False

        'MainWindow.ChartPhaYX.ChartAreas(0).AxisX.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ x
        'MainWindow.ChartPhaYX.ChartAreas(0).AxisX.IsLogarithmic = True
        'MainWindow.ChartPhaYX.ChartAreas(0).AxisX.IsReversed = False
        'MainWindow.ChartPhaYX.ChartAreas(0).AxisX.Minimum = minX
        'MainWindow.ChartPhaYX.ChartAreas(0).AxisX.Maximum = maxX
        'MainWindow.ChartPhaYX.ChartAreas(0).AxisX.Title = "Periode (second)"
        'MainWindow.ChartPhaYX.ChartAreas(0).AxisX.MinorTickMark.Enabled = True
        'MainWindow.ChartPhaYX.ChartAreas(0).AxisX.MinorTickMark.Interval = 1
        'MainWindow.ChartPhaYX.ChartAreas(0).AxisX.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        'MainWindow.ChartPhaYX.ChartAreas(0).AxisY.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ y
        'MainWindow.ChartPhaYX.ChartAreas(0).AxisY.IsLogarithmic = False
        'MainWindow.ChartPhaYX.ChartAreas(0).AxisY.Minimum = minPh
        'MainWindow.ChartPhaYX.ChartAreas(0).AxisY.Maximum = maxPh
        'MainWindow.ChartPhaYX.ChartAreas(0).AxisY.Interval = (maxPh - minPh) / 4
        'MainWindow.ChartPhaYX.ChartAreas(0).AxisY.Title = "Phase (degree)"
        'MainWindow.ChartPhaYX.ChartAreas(0).AxisY.MinorTickMark.Enabled = False
        'MainWindow.ChartPhaYX.ChartAreas(0).AxisY.MinorTickMark.Interval = 1
        'MainWindow.ChartPhaYX.ChartAreas(0).AxisY.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis

        'MainWindow.ChartZYX.Series(0).Points.AddXY(100000, 100000)
        'MainWindow.ChartZYX.Series(0).ChartType = SeriesChartType.Point
        'MainWindow.ChartZYX.Series(0).IsVisibleInLegend = True
        'MainWindow.ChartZYX.Series(1).ChartType = SeriesChartType.Point
        'MainWindow.ChartZYX.Series(1).IsVisibleInLegend = True
        'MainWindow.ChartZYX.Series(0).Color = Color.Red
        'MainWindow.ChartZYX.Series(1).Color = Color.Blue
        'MainWindow.ChartZYX.Legends(0).Position.Auto = True
        'MainWindow.ChartZYX.Legends(0).Docking = Docking.Top

        'MainWindow.ChartZYX.ChartAreas(0).AxisX.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ x
        'MainWindow.ChartZYX.ChartAreas(0).AxisX.IsLogarithmic = True
        'MainWindow.ChartZYX.ChartAreas(0).AxisX.IsReversed = False
        'MainWindow.ChartZYX.ChartAreas(0).AxisX.Minimum = minX
        'MainWindow.ChartZYX.ChartAreas(0).AxisX.Maximum = maxX
        'MainWindow.ChartZYX.ChartAreas(0).AxisX.Title = "Periode (second)"
        'MainWindow.ChartZYX.ChartAreas(0).AxisX.MinorTickMark.Enabled = True
        'MainWindow.ChartZYX.ChartAreas(0).AxisX.MinorTickMark.Interval = 1
        'MainWindow.ChartZYX.ChartAreas(0).AxisX.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        'MainWindow.ChartZYX.ChartAreas(0).AxisY.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ y
        'MainWindow.ChartZYX.ChartAreas(0).AxisY.IsLogarithmic = False
        'MainWindow.ChartZYX.ChartAreas(0).AxisY.Minimum = minZ
        'MainWindow.ChartZYX.ChartAreas(0).AxisY.Maximum = maxZ
        'MainWindow.ChartZYX.ChartAreas(0).AxisY.Title = "Zyx"
        'MainWindow.ChartZYX.ChartAreas(0).AxisY.MinorTickMark.Enabled = False
        'MainWindow.ChartZYX.ChartAreas(0).AxisY.MinorTickMark.Interval = 1
        'MainWindow.ChartZYX.ChartAreas(0).AxisY.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis

        Return 0
    End Function

    Function loadZyy(ByVal minX As Double, ByVal maxX As Double,
                     ByVal minRh As Double, ByVal maxRh As Double,
                     ByVal minPh As Double, ByVal maxPh As Double,
                     ByVal minZ As Double, ByVal maxZ As Double) As Double

        MainWindow.ChartRhoYY.Series(0).MarkerStyle = MarkerStyle.Square
        MainWindow.ChartPhaYY.Series(0).MarkerStyle = MarkerStyle.Square
        MainWindow.ChartZYY.Series(0).MarkerStyle = MarkerStyle.Square
        MainWindow.ChartZYY.Series(1).MarkerStyle = MarkerStyle.Square

        MainWindow.ChartRhoYY.Series(0).MarkerSize = 5
        MainWindow.ChartPhaYY.Series(0).MarkerSize = 5
        MainWindow.ChartZYY.Series(0).MarkerSize = 5
        MainWindow.ChartZYY.Series(1).MarkerSize = 5
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ rho
        MainWindow.ChartRhoYY.Series(0).Points.AddXY(100000, 100000)
        MainWindow.ChartRhoYY.Series(0).ChartType = SeriesChartType.Point
        MainWindow.ChartRhoYY.Series(0).IsVisibleInLegend = True
        MainWindow.ChartRhoYY.Series(0).Color = Color.Brown

        MainWindow.ChartRhoYY.Legends(0).Position.Auto = True
        MainWindow.ChartRhoYY.Legends(0).Docking = Docking.Top

        MainWindow.ChartRhoYY.ChartAreas(0).AxisX.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ x
        MainWindow.ChartRhoYY.ChartAreas(0).AxisX.IsLogarithmic = True
        MainWindow.ChartRhoYY.ChartAreas(0).AxisX.IsReversed = False
        MainWindow.ChartRhoYY.ChartAreas(0).AxisX.Minimum = minX
        MainWindow.ChartRhoYY.ChartAreas(0).AxisX.Maximum = maxX
        MainWindow.ChartRhoYY.ChartAreas(0).AxisX.Title = "Periode (second)"
        MainWindow.ChartRhoYY.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartRhoYY.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartRhoYY.ChartAreas(0).AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartRhoYY.ChartAreas(0).AxisX.MajorTickMark.Enabled = True
        MainWindow.ChartRhoYY.ChartAreas(0).AxisX.MajorTickMark.Interval = 1
        MainWindow.ChartRhoYY.ChartAreas(0).AxisX.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartRhoYY.ChartAreas(0).AxisX.MinorTickMark.Enabled = True
        MainWindow.ChartRhoYY.ChartAreas(0).AxisX.MinorTickMark.Interval = 1
        MainWindow.ChartRhoYY.ChartAreas(0).AxisX.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartRhoYY.ChartAreas(0).AxisY.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ y
        MainWindow.ChartRhoYY.ChartAreas(0).AxisY.IsLogarithmic = True
        MainWindow.ChartRhoYY.ChartAreas(0).AxisY.Minimum = minRh
        MainWindow.ChartRhoYY.ChartAreas(0).AxisY.Maximum = maxRh
        MainWindow.ChartRhoYY.ChartAreas(0).AxisY.Title = "App. Rho (ohm.m)"
        MainWindow.ChartRhoYY.ChartAreas(0).AxisY.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartRhoYY.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartRhoYY.ChartAreas(0).AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartRhoYY.ChartAreas(0).AxisY.MajorTickMark.Enabled = True
        MainWindow.ChartRhoYY.ChartAreas(0).AxisY.MajorTickMark.Interval = 1
        MainWindow.ChartRhoYY.ChartAreas(0).AxisY.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartRhoYY.ChartAreas(0).AxisY.MinorTickMark.Enabled = True
        MainWindow.ChartRhoYY.ChartAreas(0).AxisY.MinorTickMark.Interval = 1
        MainWindow.ChartRhoYY.ChartAreas(0).AxisY.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartRhoYY.ChartAreas(0).AxisY.LabelStyle.Angle = -90

        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ pha
        MainWindow.ChartPhaYY.Series(0).Points.AddXY(100000, 100000)
        MainWindow.ChartPhaYY.Series(0).ChartType = SeriesChartType.Point
        MainWindow.ChartPhaYY.Series(0).IsVisibleInLegend = False
        MainWindow.ChartPhaYY.Series(0).Color = Color.Brown

        MainWindow.ChartPhaYY.Legends(0).Position.Auto = True
        MainWindow.ChartPhaYY.Legends(0).Docking = Docking.Top

        MainWindow.ChartPhaYY.ChartAreas(0).AxisX.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ x
        MainWindow.ChartPhaYY.ChartAreas(0).AxisX.IsLogarithmic = True
        MainWindow.ChartPhaYY.ChartAreas(0).AxisX.IsReversed = False
        MainWindow.ChartPhaYY.ChartAreas(0).AxisX.Minimum = minX
        MainWindow.ChartPhaYY.ChartAreas(0).AxisX.Maximum = maxX
        MainWindow.ChartPhaYY.ChartAreas(0).AxisX.Title = "Periode (second)"
        MainWindow.ChartPhaYY.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartPhaYY.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartPhaYY.ChartAreas(0).AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartPhaYY.ChartAreas(0).AxisX.MajorTickMark.Enabled = True
        MainWindow.ChartPhaYY.ChartAreas(0).AxisX.MajorTickMark.Interval = 1
        MainWindow.ChartPhaYY.ChartAreas(0).AxisX.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartPhaYY.ChartAreas(0).AxisX.MinorTickMark.Enabled = True
        MainWindow.ChartPhaYY.ChartAreas(0).AxisX.MinorTickMark.Interval = 1
        MainWindow.ChartPhaYY.ChartAreas(0).AxisX.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartPhaYY.ChartAreas(0).AxisY.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ y
        MainWindow.ChartPhaYY.ChartAreas(0).AxisY.IsLogarithmic = False
        MainWindow.ChartPhaYY.ChartAreas(0).AxisY.Minimum = minPh
        MainWindow.ChartPhaYY.ChartAreas(0).AxisY.Maximum = maxPh
        MainWindow.ChartPhaYY.ChartAreas(0).AxisY.Interval = (maxPh - minPh) / 4
        MainWindow.ChartPhaYY.ChartAreas(0).AxisY.Title = "Phase (degree)"
        MainWindow.ChartPhaYY.ChartAreas(0).AxisY.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartPhaYY.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartPhaYY.ChartAreas(0).AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartPhaYY.ChartAreas(0).AxisY.MajorTickMark.Enabled = True
        'MainWindow.ChartPhayy.ChartAreas(0).AxisY.MajorTickMark.Interval = 1
        MainWindow.ChartPhaYY.ChartAreas(0).AxisY.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartPhaYY.ChartAreas(0).AxisY.MinorTickMark.Enabled = False
        MainWindow.ChartPhaYY.ChartAreas(0).AxisY.MinorTickMark.Interval = 1
        MainWindow.ChartPhaYY.ChartAreas(0).AxisY.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartPhaYY.ChartAreas(0).AxisY.LabelStyle.Angle = -90

        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Z
        MainWindow.ChartZYY.Series(0).Points.AddXY(100000, 100000)
        MainWindow.ChartZYY.Series(0).ChartType = SeriesChartType.Point
        MainWindow.ChartZYY.Series(0).IsVisibleInLegend = True
        MainWindow.ChartZYY.Series(0).Color = Color.Red

        MainWindow.ChartZYY.Series(1).ChartType = SeriesChartType.Point
        MainWindow.ChartZYY.Series(1).Color = Color.Blue

        MainWindow.ChartZYY.Legends(0).Position.Auto = True
        MainWindow.ChartZYY.Legends(0).Docking = Docking.Top

        MainWindow.ChartZYY.ChartAreas(0).AxisX.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ x
        MainWindow.ChartZYY.ChartAreas(0).AxisX.IsLogarithmic = True
        MainWindow.ChartZYY.ChartAreas(0).AxisX.IsReversed = False
        MainWindow.ChartZYY.ChartAreas(0).AxisX.Minimum = minX
        MainWindow.ChartZYY.ChartAreas(0).AxisX.Maximum = maxX
        MainWindow.ChartZYY.ChartAreas(0).AxisX.Title = "Periode (second)"
        MainWindow.ChartZYY.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartZYY.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartZYY.ChartAreas(0).AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartZYY.ChartAreas(0).AxisX.MajorTickMark.Enabled = True
        MainWindow.ChartZYY.ChartAreas(0).AxisX.MajorTickMark.Interval = 1
        MainWindow.ChartZYY.ChartAreas(0).AxisX.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartZYY.ChartAreas(0).AxisX.MinorTickMark.Enabled = True
        MainWindow.ChartZYY.ChartAreas(0).AxisX.MinorTickMark.Interval = 1
        MainWindow.ChartZYY.ChartAreas(0).AxisX.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartZYY.ChartAreas(0).AxisY.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ y
        MainWindow.ChartZYY.ChartAreas(0).AxisY.IsLogarithmic = False
        MainWindow.ChartZYY.ChartAreas(0).AxisY.Minimum = minZ
        MainWindow.ChartZYY.ChartAreas(0).AxisY.Maximum = maxZ
        MainWindow.ChartZYY.ChartAreas(0).AxisY.Interval = 1
        MainWindow.ChartZYY.ChartAreas(0).AxisY.Title = "Zyy"
        MainWindow.ChartZYY.ChartAreas(0).AxisY.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartZYY.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartZYY.ChartAreas(0).AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartZYY.ChartAreas(0).AxisY.MajorTickMark.Enabled = True
        'MainWindow.chartZyy.ChartAreas(0).AxisY.MajorTickMark.Interval = 1
        MainWindow.ChartZYY.ChartAreas(0).AxisY.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartZYY.ChartAreas(0).AxisY.MinorTickMark.Enabled = False
        MainWindow.ChartZYY.ChartAreas(0).AxisY.MinorTickMark.Interval = 1
        MainWindow.ChartZYY.ChartAreas(0).AxisY.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartZYY.ChartAreas(0).AxisY.LabelStyle.Angle = -90

        Return 0
    End Function

    Function loadTxZ(ByVal minX As Double, ByVal maxX As Double,
                     ByVal minRh As Double, ByVal maxRh As Double) As Double

        MainWindow.ChartTXZ.Series(0).MarkerStyle = MarkerStyle.Square
        MainWindow.ChartTXZ.Series(1).MarkerStyle = MarkerStyle.Diamond

        MainWindow.ChartTXZ.Series(0).MarkerSize = 5
        MainWindow.ChartTXZ.Series(1).MarkerSize = 5
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Z
        MainWindow.ChartTXZ.Series(0).Points.AddXY(100000, 100000)
        MainWindow.ChartTXZ.Series(0).ChartType = SeriesChartType.Point
        MainWindow.ChartTXZ.Series(0).IsVisibleInLegend = True
        MainWindow.ChartTXZ.Series(0).Color = Color.Red

        MainWindow.ChartTXZ.Series(1).ChartType = SeriesChartType.Point
        MainWindow.ChartTXZ.Series(1).Color = Color.Blue

        MainWindow.ChartTXZ.Legends(0).Position.Auto = True
        MainWindow.ChartTXZ.Legends(0).Docking = Docking.Top

        MainWindow.ChartTXZ.ChartAreas(0).AxisX.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ x
        MainWindow.ChartTXZ.ChartAreas(0).AxisX.IsLogarithmic = True
        MainWindow.ChartTXZ.ChartAreas(0).AxisX.IsReversed = False
        MainWindow.ChartTXZ.ChartAreas(0).AxisX.Minimum = minX
        MainWindow.ChartTXZ.ChartAreas(0).AxisX.Maximum = maxX
        MainWindow.ChartTXZ.ChartAreas(0).AxisX.Title = "Periode (second)"
        MainWindow.ChartTXZ.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartTXZ.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartTXZ.ChartAreas(0).AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartTXZ.ChartAreas(0).AxisX.MajorTickMark.Enabled = True
        MainWindow.ChartTXZ.ChartAreas(0).AxisX.MajorTickMark.Interval = 1
        MainWindow.ChartTXZ.ChartAreas(0).AxisX.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartTXZ.ChartAreas(0).AxisX.MinorTickMark.Enabled = True
        MainWindow.ChartTXZ.ChartAreas(0).AxisX.MinorTickMark.Interval = 1
        MainWindow.ChartTXZ.ChartAreas(0).AxisX.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartTXZ.ChartAreas(0).AxisY.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ y
        MainWindow.ChartTXZ.ChartAreas(0).AxisY.IsLogarithmic = False
        MainWindow.ChartTXZ.ChartAreas(0).AxisY.Minimum = minRh
        MainWindow.ChartTXZ.ChartAreas(0).AxisY.Maximum = maxRh
        MainWindow.ChartTXZ.ChartAreas(0).AxisY.Interval = (maxRh - minRh) / 4
        MainWindow.ChartTXZ.ChartAreas(0).AxisY.Title = "Txz"
        MainWindow.ChartTXZ.ChartAreas(0).AxisY.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartTXZ.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartTXZ.ChartAreas(0).AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartTXZ.ChartAreas(0).AxisY.MajorTickMark.Enabled = True
        'MainWindow.charttxz.ChartAreas(0).AxisY.MajorTickMark.Interval = 1
        MainWindow.ChartTXZ.ChartAreas(0).AxisY.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartTXZ.ChartAreas(0).AxisY.MinorTickMark.Enabled = False
        MainWindow.ChartTXZ.ChartAreas(0).AxisY.MinorTickMark.Interval = 1
        MainWindow.ChartTXZ.ChartAreas(0).AxisY.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartTXZ.ChartAreas(0).AxisY.LabelStyle.Angle = -90

        Return 0
    End Function

    Function loadTyZ(ByVal minX As Double, ByVal maxX As Double,
                     ByVal minRh As Double, ByVal maxRh As Double) As Double

        MainWindow.ChartTYZ.Series(0).MarkerStyle = MarkerStyle.Square
        MainWindow.ChartTYZ.Series(1).MarkerStyle = MarkerStyle.Diamond

        MainWindow.ChartTYZ.Series(0).MarkerSize = 5
        MainWindow.ChartTYZ.Series(1).MarkerSize = 5
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Z
        MainWindow.ChartTYZ.Series(0).Points.AddXY(100000, 100000)
        MainWindow.ChartTYZ.Series(0).ChartType = SeriesChartType.Point
        MainWindow.ChartTYZ.Series(0).IsVisibleInLegend = True
        MainWindow.ChartTYZ.Series(0).Color = Color.Red

        MainWindow.ChartTYZ.Series(1).ChartType = SeriesChartType.Point
        MainWindow.ChartTYZ.Series(1).Color = Color.Blue

        MainWindow.ChartTYZ.Legends(0).Position.Auto = True
        MainWindow.ChartTYZ.Legends(0).Docking = Docking.Top

        MainWindow.ChartTYZ.ChartAreas(0).AxisX.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ x
        MainWindow.ChartTYZ.ChartAreas(0).AxisX.IsLogarithmic = True
        MainWindow.ChartTYZ.ChartAreas(0).AxisX.IsReversed = False
        MainWindow.ChartTYZ.ChartAreas(0).AxisX.Minimum = minX
        MainWindow.ChartTYZ.ChartAreas(0).AxisX.Maximum = maxX
        MainWindow.ChartTYZ.ChartAreas(0).AxisX.Title = "Periode (second)"
        MainWindow.ChartTYZ.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartTYZ.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartTYZ.ChartAreas(0).AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartTYZ.ChartAreas(0).AxisX.MajorTickMark.Enabled = True
        MainWindow.ChartTYZ.ChartAreas(0).AxisX.MajorTickMark.Interval = 1
        MainWindow.ChartTYZ.ChartAreas(0).AxisX.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartTYZ.ChartAreas(0).AxisX.MinorTickMark.Enabled = True
        MainWindow.ChartTYZ.ChartAreas(0).AxisX.MinorTickMark.Interval = 1
        MainWindow.ChartTYZ.ChartAreas(0).AxisX.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartTYZ.ChartAreas(0).AxisY.IsStartedFromZero = False '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ y
        MainWindow.ChartTYZ.ChartAreas(0).AxisY.IsLogarithmic = False
        MainWindow.ChartTYZ.ChartAreas(0).AxisY.Minimum = minRh
        MainWindow.ChartTYZ.ChartAreas(0).AxisY.Maximum = maxRh
        MainWindow.ChartTYZ.ChartAreas(0).AxisY.Interval = (maxRh - minRh) / 4
        MainWindow.ChartTYZ.ChartAreas(0).AxisY.Title = "Tyz"
        MainWindow.ChartTYZ.ChartAreas(0).AxisY.LabelStyle.Font = New Font("Arial", 8)
        MainWindow.ChartTYZ.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.Silver
        MainWindow.ChartTYZ.ChartAreas(0).AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash
        MainWindow.ChartTYZ.ChartAreas(0).AxisY.MajorTickMark.Enabled = True
        'MainWindow.chartTyz.ChartAreas(0).AxisY.MajorTickMark.Interval = 1
        MainWindow.ChartTYZ.ChartAreas(0).AxisY.MajorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartTYZ.ChartAreas(0).AxisY.MinorTickMark.Enabled = False
        MainWindow.ChartTYZ.ChartAreas(0).AxisY.MinorTickMark.Interval = 1
        MainWindow.ChartTYZ.ChartAreas(0).AxisY.MinorTickMark.TickMarkStyle = Charting.TickMarkStyle.AcrossAxis
        MainWindow.ChartTYZ.ChartAreas(0).AxisY.LabelStyle.Angle = -90

        Return 0
    End Function

    Function dBindDash()
        MainWindow.ChartRhoDash.DataSource = tableALL
        MainWindow.ChartRhoDash.Series(0).XValueMember = ">PERIODE"
        MainWindow.ChartRhoDash.Series(0).YValueMembers = ">RHOXX ROT=RHOROT"
        MainWindow.ChartRhoDash.Series(1).XValueMember = ">PERIODE"
        MainWindow.ChartRhoDash.Series(1).YValueMembers = ">RHOXY ROT=RHOROT"
        MainWindow.ChartRhoDash.Series(2).XValueMember = ">PERIODE"
        MainWindow.ChartRhoDash.Series(2).YValueMembers = ">RHOYX ROT=RHOROT"
        MainWindow.ChartRhoDash.Series(3).XValueMember = ">PERIODE"
        MainWindow.ChartRhoDash.Series(3).YValueMembers = ">RHOYY ROT=RHOROT"
        MainWindow.ChartRhoDash.DataBind()

        MainWindow.ChartPhaDash.DataSource = tableALL
        MainWindow.ChartPhaDash.Series(0).XValueMember = ">PERIODE"
        MainWindow.ChartPhaDash.Series(0).YValueMembers = ">PHSXX ROT=RHOROT"
        MainWindow.ChartPhaDash.Series(1).XValueMember = ">PERIODE"
        MainWindow.ChartPhaDash.Series(1).YValueMembers = ">PHSXY ROT=RHOROT"
        MainWindow.ChartPhaDash.Series(2).XValueMember = ">PERIODE"
        MainWindow.ChartPhaDash.Series(2).YValueMembers = ">PHSYX ROT=RHOROT"
        MainWindow.ChartPhaDash.Series(3).XValueMember = ">PERIODE"
        MainWindow.ChartPhaDash.Series(3).YValueMembers = ">PHSYY ROT=RHOROT"
        MainWindow.ChartPhaDash.DataBind()

        Return 0
    End Function

    Function dBindZXX()

        MainWindow.ChartRhoXX.DataSource = tableRhoPhaXX
        MainWindow.ChartRhoXX.Series(0).XValueMember = ">PERIODE"
        MainWindow.ChartRhoXX.Series(0).YValueMembers = "RhoXX"
        MainWindow.ChartRhoXX.DataBind()

        MainWindow.ChartPhaXX.DataSource = tableRhoPhaXX
        MainWindow.ChartPhaXX.Series(0).XValueMember = ">PERIODE"
        MainWindow.ChartPhaXX.Series(0).YValueMembers = "PhaXX"
        MainWindow.ChartPhaXX.DataBind()

        MainWindow.ChartZXX.DataSource = tableZXX
        MainWindow.ChartZXX.Series(0).XValueMember = ">PERIODE"
        MainWindow.ChartZXX.Series(0).YValueMembers = ">ZXXI ROT=ZROT"
        MainWindow.ChartZXX.Series(1).XValueMember = ">PERIODE"
        MainWindow.ChartZXX.Series(1).YValueMembers = ">ZXXR ROT=ZROT"
        MainWindow.ChartZXX.DataBind()
        Return 0
    End Function

    Function dBindZXY()

        MainWindow.ChartRhoXY.DataSource = tableRhoPhaXY
        MainWindow.ChartRhoXY.Series(0).XValueMember = ">PERIODE"
        MainWindow.ChartRhoXY.Series(0).YValueMembers = "RhoXY"
        MainWindow.ChartRhoXY.Series(1).XValueMember = ">PERIODE"
        MainWindow.ChartRhoXY.Series(1).YValueMembers = ">RHOXY.FIT ROT=RHOROT"
        MainWindow.ChartRhoXY.DataBind()

        MainWindow.ChartPhaXY.DataSource = tableRhoPhaXY
        MainWindow.ChartPhaXY.Series(0).XValueMember = ">PERIODE"
        MainWindow.ChartPhaXY.Series(0).YValueMembers = "PhaXY"
        MainWindow.ChartPhaXY.Series(1).XValueMember = ">PERIODE"
        MainWindow.ChartPhaXY.Series(1).YValueMembers = ">PHSXY.FIT ROT=RHOROT"
        MainWindow.ChartPhaXY.DataBind()

        MainWindow.ChartZXY.DataSource = tableZXY
        MainWindow.ChartZXY.Series(0).XValueMember = ">PERIODE"
        MainWindow.ChartZXY.Series(0).YValueMembers = "log(>ZXYI ROT=ZROT)"
        MainWindow.ChartZXY.Series(1).XValueMember = ">PERIODE"
        MainWindow.ChartZXY.Series(1).YValueMembers = "log(>ZXYR ROT=ZROT)"
        MainWindow.ChartZXY.DataBind()
        Return 0
    End Function

    Function dBindZYX()
        MainWindow.ChartRhoYX.DataSource = tableRhoPhaYX
        MainWindow.ChartRhoYX.Series(0).XValueMember = ">PERIODE"
        MainWindow.ChartRhoYX.Series(0).YValueMembers = "RhoYX"
        MainWindow.ChartRhoYX.Series(1).XValueMember = ">PERIODE"
        MainWindow.ChartRhoYX.Series(1).YValueMembers = ">RHOYX.FIT ROT=RHOROT"
        MainWindow.ChartRhoYX.DataBind()

        MainWindow.ChartPhaYX.DataSource = tableRhoPhaYX
        MainWindow.ChartPhaYX.Series(0).XValueMember = ">PERIODE"
        MainWindow.ChartPhaYX.Series(0).YValueMembers = "PhaYX"
        MainWindow.ChartPhaYX.Series(1).XValueMember = ">PERIODE"
        MainWindow.ChartPhaYX.Series(1).YValueMembers = ">PHSYX.FIT ROT=RHOROT"
        MainWindow.ChartPhaYX.DataBind()

        MainWindow.ChartZYX.DataSource = tableZYX
        MainWindow.ChartZYX.Series(0).XValueMember = ">PERIODE"
        MainWindow.ChartZYX.Series(0).YValueMembers = "log(>ZYXI ROT=ZROT)"
        MainWindow.ChartZYX.Series(1).XValueMember = ">PERIODE"
        MainWindow.ChartZYX.Series(1).YValueMembers = "log(>ZYXR ROT=ZROT)"
        MainWindow.ChartZYX.DataBind()
        Return 0
    End Function

    Function dBindZYY()
        MainWindow.ChartRhoYY.DataSource = tableRhoPhaYY
        MainWindow.ChartRhoYY.Series(0).XValueMember = ">PERIODE"
        MainWindow.ChartRhoYY.Series(0).YValueMembers = "RhoYY"
        MainWindow.ChartRhoYY.DataBind()

        MainWindow.ChartPhaYY.DataSource = tableRhoPhaYY
        MainWindow.ChartPhaYY.Series(0).XValueMember = ">PERIODE"
        MainWindow.ChartPhaYY.Series(0).YValueMembers = "PhaYY"
        MainWindow.ChartPhaYY.DataBind()

        MainWindow.ChartZYY.DataSource = tableZYY
        MainWindow.ChartZYY.Series(0).XValueMember = ">PERIODE"
        MainWindow.ChartZYY.Series(0).YValueMembers = ">ZYYI ROT=ZROT"
        MainWindow.ChartZYY.Series(1).XValueMember = ">PERIODE"
        MainWindow.ChartZYY.Series(1).YValueMembers = ">ZYYR ROT=ZROT"
        MainWindow.ChartZYY.DataBind()
        Return 0
    End Function

    Function dBindTXZ()
        MainWindow.ChartTXZ.DataSource = tableTxZ
        MainWindow.ChartTXZ.Series(0).XValueMember = ">PERIODE"
        MainWindow.ChartTXZ.Series(0).YValueMembers = ">TXI.EXP"
        MainWindow.ChartTXZ.Series(1).XValueMember = ">PERIODE"
        MainWindow.ChartTXZ.Series(1).YValueMembers = ">TXR.EXP"
        MainWindow.ChartTXZ.DataBind()
        Return 0
    End Function

    Function dBindTYZ()
        MainWindow.ChartTYZ.DataSource = tableTyZ
        MainWindow.ChartTYZ.Series(0).XValueMember = ">PERIODE"
        MainWindow.ChartTYZ.Series(0).YValueMembers = ">TYI.EXP"
        MainWindow.ChartTYZ.Series(1).XValueMember = ">PERIODE"
        MainWindow.ChartTYZ.Series(1).YValueMembers = ">TYR.EXP"
        MainWindow.ChartTYZ.DataBind()
        Return 0
    End Function

    Function markerXX(ByVal i As Integer)
        If i >= 0 Then
            MainWindow.ChartRhoXX.Series(0).Points(i).Color = Color.Lime
            MainWindow.ChartPhaXX.Series(0).Points(i).Color = Color.Lime
            MainWindow.ChartZXX.Series(0).Points(i).Color = Color.Lime
            MainWindow.ChartZXX.Series(1).Points(i).Color = Color.Lime

            MainWindow.ChartRhoXX.Series(0).Points(i).MarkerStyle = MarkerStyle.Cross
            MainWindow.ChartPhaXX.Series(0).Points(i).MarkerStyle = MarkerStyle.Cross
            MainWindow.ChartZXX.Series(0).Points(i).MarkerStyle = MarkerStyle.Cross
            MainWindow.ChartZXX.Series(1).Points(i).MarkerStyle = MarkerStyle.Cross

            MainWindow.ChartRhoXX.Series(0).Points(i).MarkerSize = 10
            MainWindow.ChartPhaXX.Series(0).Points(i).MarkerSize = 10
            MainWindow.ChartZXX.Series(0).Points(i).MarkerSize = 10
            MainWindow.ChartZXX.Series(1).Points(i).MarkerSize = 10
        End If

        Return 0
    End Function

    Function remarkerXX(ByVal nFreq As Integer)
        Dim i As Integer
        For i = 0 To nFreq - 1
            MainWindow.ChartRhoXX.Series(0).Points(i).Color = Color.DarkGreen
            MainWindow.ChartPhaXX.Series(0).Points(i).Color = Color.DarkGreen
            MainWindow.ChartZXX.Series(0).Points(i).Color = Color.Red
            MainWindow.ChartZXX.Series(1).Points(i).Color = Color.Blue

            MainWindow.ChartRhoXX.Series(0).Points(i).MarkerStyle = MarkerStyle.Square
            MainWindow.ChartPhaXX.Series(0).Points(i).MarkerStyle = MarkerStyle.Square
            MainWindow.ChartZXX.Series(0).Points(i).MarkerStyle = MarkerStyle.Square
            MainWindow.ChartZXX.Series(1).Points(i).MarkerStyle = MarkerStyle.Square

            MainWindow.ChartRhoXX.Series(0).Points(i).MarkerSize = 5
            MainWindow.ChartPhaXX.Series(0).Points(i).MarkerSize = 5
            MainWindow.ChartZXX.Series(0).Points(i).MarkerSize = 5
            MainWindow.ChartZXX.Series(1).Points(i).MarkerSize = 5
        Next
        Return 0
    End Function

    Function markerxy(ByVal i As Integer)
        If i >= 0 Then
            MainWindow.ChartRhoxy.Series(0).Points(i).Color = Color.Lime
            MainWindow.ChartPhaxy.Series(0).Points(i).Color = Color.Lime
            MainWindow.ChartZxy.Series(0).Points(i).Color = Color.Lime
            MainWindow.ChartZxy.Series(1).Points(i).Color = Color.Lime

            MainWindow.ChartRhoxy.Series(0).Points(i).MarkerStyle = MarkerStyle.Cross
            MainWindow.ChartPhaxy.Series(0).Points(i).MarkerStyle = MarkerStyle.Cross
            MainWindow.ChartZxy.Series(0).Points(i).MarkerStyle = MarkerStyle.Cross
            MainWindow.ChartZxy.Series(1).Points(i).MarkerStyle = MarkerStyle.Cross

            MainWindow.ChartRhoxy.Series(0).Points(i).MarkerSize = 10
            MainWindow.ChartPhaxy.Series(0).Points(i).MarkerSize = 10
            MainWindow.ChartZxy.Series(0).Points(i).MarkerSize = 10
            MainWindow.ChartZxy.Series(1).Points(i).MarkerSize = 10
        End If

        Return 0
    End Function

    Function remarkerxy(ByVal nFreq As Integer)
        Dim i As Integer
        For i = 0 To nFreq - 1
            MainWindow.ChartRhoXY.Series(0).Points(i).Color = Color.Red
            MainWindow.ChartPhaXY.Series(0).Points(i).Color = Color.Red
            MainWindow.ChartZxy.Series(0).Points(i).Color = Color.Red
            MainWindow.ChartZxy.Series(1).Points(i).Color = Color.Blue

            MainWindow.ChartRhoxy.Series(0).Points(i).MarkerStyle = MarkerStyle.Square
            MainWindow.ChartPhaxy.Series(0).Points(i).MarkerStyle = MarkerStyle.Square
            MainWindow.ChartZxy.Series(0).Points(i).MarkerStyle = MarkerStyle.Square
            MainWindow.ChartZXY.Series(1).Points(i).MarkerStyle = MarkerStyle.Square

            MainWindow.ChartRhoxy.Series(0).Points(i).MarkerSize = 5
            MainWindow.ChartPhaxy.Series(0).Points(i).MarkerSize = 5
            MainWindow.ChartZxy.Series(0).Points(i).MarkerSize = 5
            MainWindow.ChartZxy.Series(1).Points(i).MarkerSize = 5
        Next
        Return 0
    End Function

    Function markeryx(ByVal i As Integer)
        If i >= 0 Then
            MainWindow.ChartRhoyx.Series(0).Points(i).Color = Color.Lime
            MainWindow.ChartPhayx.Series(0).Points(i).Color = Color.Lime
            MainWindow.ChartZyx.Series(0).Points(i).Color = Color.Lime
            MainWindow.ChartZyx.Series(1).Points(i).Color = Color.Lime

            MainWindow.ChartRhoyx.Series(0).Points(i).MarkerStyle = MarkerStyle.Cross
            MainWindow.ChartPhayx.Series(0).Points(i).MarkerStyle = MarkerStyle.Cross
            MainWindow.ChartZyx.Series(0).Points(i).MarkerStyle = MarkerStyle.Cross
            MainWindow.ChartZyx.Series(1).Points(i).MarkerStyle = MarkerStyle.Cross

            MainWindow.ChartRhoyx.Series(0).Points(i).MarkerSize = 10
            MainWindow.ChartPhayx.Series(0).Points(i).MarkerSize = 10
            MainWindow.ChartZyx.Series(0).Points(i).MarkerSize = 10
            MainWindow.ChartZyx.Series(1).Points(i).MarkerSize = 10
        End If

        Return 0
    End Function

    Function remarkeryx(ByVal nFreq As Integer)
        Dim i As Integer
        For i = 0 To nFreq - 1
            MainWindow.ChartRhoYX.Series(0).Points(i).Color = Color.Blue
            MainWindow.ChartPhaYX.Series(0).Points(i).Color = Color.Blue
            MainWindow.ChartZyx.Series(0).Points(i).Color = Color.Red
            MainWindow.ChartZyx.Series(1).Points(i).Color = Color.Blue

            MainWindow.ChartRhoyx.Series(0).Points(i).MarkerStyle = MarkerStyle.Square
            MainWindow.ChartPhayx.Series(0).Points(i).MarkerStyle = MarkerStyle.Square
            MainWindow.ChartZyx.Series(0).Points(i).MarkerStyle = MarkerStyle.Square
            MainWindow.ChartZYX.Series(1).Points(i).MarkerStyle = MarkerStyle.Square

            MainWindow.ChartRhoyx.Series(0).Points(i).MarkerSize = 5
            MainWindow.ChartPhayx.Series(0).Points(i).MarkerSize = 5
            MainWindow.ChartZyx.Series(0).Points(i).MarkerSize = 5
            MainWindow.ChartZyx.Series(1).Points(i).MarkerSize = 5
        Next
        Return 0
    End Function

    Function markeryy(ByVal i As Integer)
        If i >= 0 Then
            MainWindow.ChartRhoyy.Series(0).Points(i).Color = Color.Lime
            MainWindow.ChartPhayy.Series(0).Points(i).Color = Color.Lime
            MainWindow.ChartZyy.Series(0).Points(i).Color = Color.Lime
            MainWindow.ChartZyy.Series(1).Points(i).Color = Color.Lime

            MainWindow.ChartRhoyy.Series(0).Points(i).MarkerStyle = MarkerStyle.Cross
            MainWindow.ChartPhayy.Series(0).Points(i).MarkerStyle = MarkerStyle.Cross
            MainWindow.ChartZyy.Series(0).Points(i).MarkerStyle = MarkerStyle.Cross
            MainWindow.ChartZyy.Series(1).Points(i).MarkerStyle = MarkerStyle.Cross

            MainWindow.ChartRhoyy.Series(0).Points(i).MarkerSize = 10
            MainWindow.ChartPhayy.Series(0).Points(i).MarkerSize = 10
            MainWindow.ChartZyy.Series(0).Points(i).MarkerSize = 10
            MainWindow.ChartZyy.Series(1).Points(i).MarkerSize = 10
        End If

        Return 0
    End Function

    Function remarkeryy(ByVal nFreq As Integer)
        Dim i As Integer
        For i = 0 To nFreq - 1
            MainWindow.ChartRhoYY.Series(0).Points(i).Color = Color.Brown
            MainWindow.ChartPhaYY.Series(0).Points(i).Color = Color.Brown
            MainWindow.ChartZyy.Series(0).Points(i).Color = Color.Red
            MainWindow.ChartZyy.Series(1).Points(i).Color = Color.Blue

            MainWindow.ChartRhoyy.Series(0).Points(i).MarkerStyle = MarkerStyle.Square
            MainWindow.ChartPhayy.Series(0).Points(i).MarkerStyle = MarkerStyle.Square
            MainWindow.ChartZyy.Series(0).Points(i).MarkerStyle = MarkerStyle.Square
            MainWindow.ChartZYY.Series(1).Points(i).MarkerStyle = MarkerStyle.Square

            MainWindow.ChartRhoyy.Series(0).Points(i).MarkerSize = 5
            MainWindow.ChartPhayy.Series(0).Points(i).MarkerSize = 5
            MainWindow.ChartZyy.Series(0).Points(i).MarkerSize = 5
            MainWindow.ChartZyy.Series(1).Points(i).MarkerSize = 5
        Next
        Return 0
    End Function

    Function markerxz(ByVal i As Integer)
        If i >= 0 Then
            MainWindow.ChartTXZ.Series(0).Points(i).Color = Color.Lime
            MainWindow.ChartTXZ.Series(1).Points(i).Color = Color.Lime

            MainWindow.ChartTXZ.Series(0).Points(i).MarkerStyle = MarkerStyle.Cross
            MainWindow.ChartTXZ.Series(1).Points(i).MarkerStyle = MarkerStyle.Cross

            MainWindow.ChartTXZ.Series(0).Points(i).MarkerSize = 10
            MainWindow.ChartTXZ.Series(1).Points(i).MarkerSize = 10
        End If

        Return 0
    End Function

    Function remarkerxz(ByVal nFreq As Integer)
        Dim i As Integer
        For i = 0 To nFreq - 1
            MainWindow.ChartTXZ.Series(0).Points(i).Color = Color.Red
            MainWindow.ChartTXZ.Series(1).Points(i).Color = Color.Blue

            MainWindow.ChartTXZ.Series(0).Points(i).MarkerStyle = MarkerStyle.Square
            MainWindow.ChartTXZ.Series(1).Points(i).MarkerStyle = MarkerStyle.Diamond

            MainWindow.ChartTXZ.Series(0).Points(i).MarkerSize = 5
            MainWindow.ChartTXZ.Series(1).Points(i).MarkerSize = 5
        Next
        Return 0
    End Function

    Function markeryz(ByVal i As Integer)
        If i >= 0 Then
            MainWindow.ChartTyz.Series(0).Points(i).Color = Color.Lime
            MainWindow.ChartTyz.Series(1).Points(i).Color = Color.Lime

            MainWindow.ChartTyz.Series(0).Points(i).MarkerStyle = MarkerStyle.Cross
            MainWindow.ChartTyz.Series(1).Points(i).MarkerStyle = MarkerStyle.Cross

            MainWindow.ChartTyz.Series(0).Points(i).MarkerSize = 10
            MainWindow.ChartTyz.Series(1).Points(i).MarkerSize = 10
        End If

        Return 0
    End Function

    Function remarkeryz(ByVal nFreq As Integer)
        Dim i As Integer
        For i = 0 To nFreq - 1
            MainWindow.ChartTyz.Series(0).Points(i).Color = Color.Red
            MainWindow.ChartTyz.Series(1).Points(i).Color = Color.Blue

            MainWindow.ChartTyz.Series(0).Points(i).MarkerStyle = MarkerStyle.Square
            MainWindow.ChartTyz.Series(1).Points(i).MarkerStyle = MarkerStyle.Diamond

            MainWindow.ChartTyz.Series(0).Points(i).MarkerSize = 5
            MainWindow.ChartTyz.Series(1).Points(i).MarkerSize = 5
        Next
        Return 0
    End Function

End Module
