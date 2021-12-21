Imports System
Imports System.IO
Imports System.Text
Imports System.Math
Imports System.Windows.Forms.DataVisualization
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient


Public Class MainWindow
    Dim nFreq As Integer
    Public Shared intFreq As Integer = 100
    Public Freq(intFreq) As Double
    Public Zrot(intFreq) As Double
    Public ZxxR(intFreq) As Double
    Public ZxxI(intFreq) As Double
    Public ZxxV(intFreq) As Double
    Public ZxyR(intFreq) As Double
    Public ZxyI(intFreq) As Double
    Public Zxyv(intFreq) As Double
    Public ZyxR(intFreq) As Double
    Public ZyxI(intFreq) As Double
    Public Zyxv(intFreq) As Double
    Public ZyyR(intFreq) As Double
    Public ZyyI(intFreq) As Double
    Public Zyyv(intFreq) As Double

    Public RHOR(intFreq) As Double
    Public RHOxyR(intFreq) As Double
    Public RHOxyE(intFreq) As Double
    Public RHOxyF(intFreq) As Double
    Public RHOyxR(intFreq) As Double
    Public RHOyxE(intFreq) As Double
    Public RHOyxF(intFreq) As Double
    Public RHOxxR(intFreq) As Double
    Public RHOxxE(intFreq) As Double
    Public RHOyyR(intFreq) As Double
    Public RHOyyE(intFreq) As Double

    Public PHAxyR(intFreq) As Double
    Public PHAxyE(intFreq) As Double
    Public PHAxyF(intFreq) As Double
    Public PHAyxR(intFreq) As Double
    Public PHAyxE(intFreq) As Double
    Public PHAyxF(intFreq) As Double
    Public PHAxxR(intFreq) As Double
    Public PHAxxE(intFreq) As Double
    Public PHAyyR(intFreq) As Double
    Public PHAyyE(intFreq) As Double

    Public Trot(intFreq) As Double
    Public TxR(intFreq) As Double
    Public TxI(intFreq) As Double
    Public TxV(intFreq) As Double
    Public TyR(intFreq) As Double
    Public TyI(intFreq) As Double
    Public TyV(intFreq) As Double
    Public TipM(intFreq) As Double
    Public TipMV(intFreq) As Double
    Public TipP(intFreq) As Double

    Public Zstrike(intFreq) As Double
    Public Zskew(intFreq) As Double
    Public Zellip(intFreq) As Double
    Public Tstrike(intFreq) As Double
    Public Tskew(intFreq) As Double
    Public Tellip(intFreq) As Double

    Public IndMagR(intFreq) As Double
    Public IndMagI(intFreq) As Double
    Public IndAngR(intFreq) As Double
    Public IndAngI(intFreq) As Double

    Public tableHeader As New DataTable

    Dim isDraggingPointIMAG As Boolean = False
    Dim isDraggingPointREAL As Boolean = False
    Dim draggedPointIndex As Integer = -1

    Dim staPERIODE As Boolean = False
    Dim staZROT As Boolean = False
    Dim staZXXR As Boolean = False
    Dim staZXXI As Boolean = False
    Dim staZXXVAR As Boolean = False
    Dim staZXYR As Boolean = False
    Dim staZXYI As Boolean = False
    Dim staZXYVAR As Boolean = False
    Dim staZYXR As Boolean = False
    Dim staZYXI As Boolean = False
    Dim staZYXVAR As Boolean = False
    Dim staZYYR As Boolean = False
    Dim staZYYI As Boolean = False
    Dim staZYYVAR As Boolean = False
    Dim staRHOROT As Boolean = False
    Dim staRHOXY As Boolean = False
    Dim staRHOXYERR As Boolean = False
    Dim staRHOXYFIT As Boolean = False
    Dim staRHOYX As Boolean = False
    Dim staRHOYXERR As Boolean = False
    Dim staRHOYXFIT As Boolean = False
    Dim staRHOXX As Boolean = False
    Dim staRHOXXERR As Boolean = False
    Dim staRHOYY As Boolean = False
    Dim staRHOYYERR As Boolean = False
    Dim staPHSXY As Boolean = False
    Dim staPHSXYERR As Boolean = False
    Dim staPHSXYFIT As Boolean = False
    Dim staPHSYX As Boolean = False
    Dim staPHSYXERR As Boolean = False
    Dim staPHSYXFIT As Boolean = False
    Dim staPHSXX As Boolean = False
    Dim staPHSXXERR As Boolean = False
    Dim staPHSYY As Boolean = False
    Dim staPHSYYERR As Boolean = False
    Dim staTROTEXP As Boolean = False
    Dim staTXREXP As Boolean = False
    Dim staTXIEXP As Boolean = False
    Dim staTXVAREXP As Boolean = False
    Dim staTYREXP As Boolean = False
    Dim staTYIEXP As Boolean = False
    Dim staTYVAREXP As Boolean = False
    Dim staTIPMAG As Boolean = False
    Dim staTIPMAGVAR As Boolean = False
    Dim staTIPPHS As Boolean = False
    Dim staZSTRIKE As Boolean = False
    Dim staZSKEW As Boolean = False
    Dim staZELLIP As Boolean = False
    Dim staTSTRIKE As Boolean = False
    Dim staTSKEW As Boolean = False
    Dim staTELLIP As Boolean = False
    Dim staINDMAGREXP As Boolean = False
    Dim staINDMAGIEXP As Boolean = False
    Dim staINDANGREXP As Boolean = False
    Dim staINDANGIEXP As Boolean = False

    Public Shared dataExist As Boolean
    Dim staClose As Boolean = False

    Public minX As Double
    Public maxX As Double
    Public minRh As Double
    Public maxRh As Double
    Public minPh As Integer
    Public maxPh As Integer
    Public intPh As Integer

    Public Shared minPerDash As Double
    Public Shared maxPerDash As Double
    Public Shared minRhoDash As Double
    Public Shared maxRhoDash As Double
    Public Shared minPhaDash As Double
    Public Shared maxPhaDash As Double

    Public Shared minPerZxx As Double
    Public Shared maxPerZxx As Double
    Public Shared minRhoZxx As Double
    Public Shared maxRhoZxx As Double
    Public Shared minPhaZxx As Double
    Public Shared maxPhaZxx As Double
    Public Shared minZZxx As Double
    Public Shared maxZZxx As Double

    Public Shared minPerZxy As Double
    Public Shared maxPerZxy As Double
    Public Shared minRhoZxy As Double
    Public Shared maxRhoZxy As Double
    Public Shared minPhaZxy As Double
    Public Shared maxPhaZxy As Double
    Public Shared minZZxy As Double
    Public Shared maxZZxy As Double

    Public Shared minPerZyx As Double
    Public Shared maxPerZyx As Double
    Public Shared minRhoZyx As Double
    Public Shared maxRhoZyx As Double
    Public Shared minPhaZyx As Double
    Public Shared maxPhaZyx As Double
    Public Shared minZZyx As Double
    Public Shared maxZZyx As Double

    Public Shared minPerZyy As Double
    Public Shared maxPerZyy As Double
    Public Shared minRhoZyy As Double
    Public Shared maxRhoZyy As Double
    Public Shared minPhaZyy As Double
    Public Shared maxPhaZyy As Double
    Public Shared minZZyy As Double
    Public Shared maxZZyy As Double

    Public Shared minPerTxz As Double
    Public Shared maxPerTxz As Double
    Public Shared minTxz As Double
    Public Shared maxTxz As Double

    Public Shared minPerTyz As Double
    Public Shared maxPerTyz As Double
    Public Shared minTyz As Double
    Public Shared maxTyz As Double

    Public Shared SSxx As Double
    Public Shared SSxy As Double
    Public Shared SSyx As Double
    Public Shared SSyy As Double

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SSxx = 1.0
        SSxy = 1.0
        SSyx = 1.0
        SSyy = 1.0

        OpenToolStripMenuItem.Enabled = True
        CloseToolStripMenuItem.Enabled = False
        SaveToolStripMenuItem.Enabled = False
        ExitToolStripMenuItem.Enabled = True

        DataToolStripMenuItem.Enabled = False
        StaticShiftToolStripMenuItem.Enabled = False
        ScaleSettingToolStripMenuItem.Enabled = False

        dataExist = False

        minX = 0.001
        maxX = 1000
        minRh = 0.01
        maxRh = 1000
        minPh = -360
        maxPh = 360

        minPerDash = minX
        maxPerDash = maxX
        minRhoDash = minRh
        maxRhoDash = maxRh
        minPhaDash = minPh
        maxPhaDash = maxPh

        minPerZxx = minX
        maxPerZxx = maxX
        minRhoZxx = minRh
        maxRhoZxx = maxRh
        minPhaZxx = minPh
        maxPhaZxx = maxPh
        minZZxx = -20
        maxZZxx = 20

        ScaleSettingWindow.TextBoxMinPerXX.Text = minPerZxx
        ScaleSettingWindow.TextBoxMaxPerXX.Text = maxPerZxx
        ScaleSettingWindow.TextBoxMinRhoXX.Text = minRhoZxx
        ScaleSettingWindow.TextBoxMaxRhoXX.Text = maxRhoZxx
        ScaleSettingWindow.TextBoxMinPhaXX.Text = minPhaZxx
        ScaleSettingWindow.TextBoxMaxPhaXX.Text = maxPhaZxx
        ScaleSettingWindow.TextBoxMinZxx.Text = minZZxx
        ScaleSettingWindow.TextBoxMaxZxx.Text = maxZZxx

        minPerZxy = minX
        maxPerZxy = maxX
        minRhoZxy = minRh
        maxRhoZxy = maxRh
        minPhaZxy = minPh
        maxPhaZxy = maxPh
        minZZxy = -1
        maxZZxy = 3

        ScaleSettingWindow.TextBoxMinPerXY.Text = minPerZxy
        ScaleSettingWindow.TextBoxMaxPerXY.Text = maxPerZxy
        ScaleSettingWindow.TextBoxMinRhoXY.Text = minRhoZxy
        ScaleSettingWindow.TextBoxMaxRhoXY.Text = maxRhoZxy
        ScaleSettingWindow.TextBoxMinPhaXY.Text = minPhaZxy
        ScaleSettingWindow.TextBoxMaxPhaXY.Text = maxPhaZxy
        ScaleSettingWindow.TextBoxMinZxy.Text = minZZxy
        ScaleSettingWindow.TextBoxMaxZxy.Text = maxZZxy

        minPerZyx = minX
        maxPerZyx = maxX
        minRhoZyx = minRh
        maxRhoZyx = maxRh
        minPhaZyx = minPh
        maxPhaZyx = maxPh
        minZZyx = -1
        maxZZyx = 3

        ScaleSettingWindow.TextBoxMinPerYX.Text = minPerZyx
        ScaleSettingWindow.TextBoxMaxPerYX.Text = maxPerZyx
        ScaleSettingWindow.TextBoxMinRhoYX.Text = minRhoZyx
        ScaleSettingWindow.TextBoxMaxRhoYX.Text = maxRhoZyx
        ScaleSettingWindow.TextBoxMinPhaYX.Text = minPhaZyx
        ScaleSettingWindow.TextBoxMaxPhaYX.Text = maxPhaZyx
        ScaleSettingWindow.TextBoxMinZyx.Text = minZZyx
        ScaleSettingWindow.TextBoxMaxZyx.Text = maxZZyx

        minPerZyy = minX
        maxPerZyy = maxX
        minRhoZyy = minRh
        maxRhoZyy = maxRh
        minPhaZyy = minPh
        maxPhaZyy = maxPh
        minZZyy = -20
        maxZZyy = 20

        ScaleSettingWindow.TextBoxMinPerYY.Text = minPerZyy
        ScaleSettingWindow.TextBoxMaxPerYY.Text = maxPerZyy
        ScaleSettingWindow.TextBoxMinRhoYY.Text = minRhoZyy
        ScaleSettingWindow.TextBoxMaxRhoYY.Text = maxRhoZyy
        ScaleSettingWindow.TextBoxMinPhaYY.Text = minPhaZyy
        ScaleSettingWindow.TextBoxMaxPhaYY.Text = maxPhaZyy
        ScaleSettingWindow.TextBoxMinZyy.Text = minZZyy
        ScaleSettingWindow.TextBoxMaxZyy.Text = maxZZyy

        minPerTxz = minX
        maxPerTxz = maxX
        minTxz = -0.5
        maxTxz = 0.5

        ScaleSettingWindow.TextBoxMinPerXZ.Text = minPerTxz
        ScaleSettingWindow.TextBoxMaxPerXZ.Text = maxPerTxz
        ScaleSettingWindow.TextBoxMinTxz.Text = minTxz
        ScaleSettingWindow.TextBoxMaxTxz.Text = maxTxz

        minPerTyz = minX
        maxPerTyz = maxX
        minTyz = -0.5
        maxTyz = 0.5

        ScaleSettingWindow.TextBoxMinPerYZ.Text = minPerTyz
        ScaleSettingWindow.TextBoxMaxPerYZ.Text = maxPerTyz
        ScaleSettingWindow.TextBoxMinTyz.Text = minTyz
        ScaleSettingWindow.TextBoxMaxTyz.Text = maxTyz

        Call loadDash(minPerDash, maxPerDash, minRhoDash, maxRhoDash, minPhaDash, maxPhaDash)
        Call loadZxx(minPerZxx, maxPerZxx, minRhoZxx, maxRhoZxx, minPhaZxx, maxPhaZxx, minZZxx, maxZZxx)
        Call loadZxy(minPerZxy, maxPerZxy, minRhoZxy, maxRhoZxy, minPhaZxy, maxPhaZxy, minZZxy, maxZZxy)
        Call loadZyx(minPerZyx, maxPerZyx, minRhoZyx, maxRhoZyx, minPhaZyx, maxPhaZyx, minZZyx, maxZZyx)
        Call loadZyy(minPerZyy, maxPerZyy, minRhoZyy, maxRhoZyy, minPhaZyy, maxPhaZyy, minZZyy, maxZZyy)
        Call loadTxZ(minPerTxz, maxPerTxz, minTxz, maxTxz)
        Call loadTyZ(minPerTyz, maxPerTyz, minTyz, maxTyz)
        Call tableColumns()

        tableHeader.Columns.Add(">HEADER", GetType(String))
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If staClose = False Then
            If dataExist = True Then
                Dim result As Integer = MessageBox.Show("What to save your EDI file?", "adEDItor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If result = DialogResult.Cancel Then
                    e.Cancel = True
                ElseIf result = DialogResult.Yes Then
                    Call saveData()
                End If
            End If
        End If 
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim openFileDialog1 As New OpenFileDialog()
        Dim OpenFileName As String

        openFileDialog1.InitialDirectory = "D:\EDI3Dngebel"
        openFileDialog1.Filter = "EDI files (*.edi)|*.edi"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            OpenFileName = openFileDialog1.FileName
            Call openData(OpenFileName)
            Me.Text = "adEDItor " + OpenFileName
        End If

    End Sub

    Private Sub DataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataToolStripMenuItem.Click
        DataWindow.Show()
    End Sub

    Private Sub ChartZXX_MouseDown(sender As Object, e As MouseEventArgs) Handles ChartZXX.MouseDown
        Dim h As Windows.Forms.DataVisualization.Charting.HitTestResult = ChartZXX.HitTest(e.X, e.Y)
        Dim XVal As Double
        Dim YVal As Double

        If h.ChartElementType = DataVisualization.Charting.ChartElementType.DataPoint Then
            Call markerXX(h.PointIndex)
        Else
            Call remarkerXX(nFreq)
        End If

        If h.ChartElementType = DataVisualization.Charting.ChartElementType.DataPoint Then
            XVal = h.Series.Points(h.PointIndex).XValue
            YVal = h.Series.Points(h.PointIndex).YValues(0)

            If (h.Series.Points(h.PointIndex).YValues(0) = ChartZXX.Series(0).Points(h.PointIndex).YValues(0)) Then
                draggedPointIndex = h.PointIndex
                isDraggingPointIMAG = True
            ElseIf (h.Series.Points(h.PointIndex).YValues(0) = ChartZXX.Series(1).Points(h.PointIndex).YValues(0)) Then
                draggedPointIndex = h.PointIndex
                isDraggingPointREAL = True
            End If
        End If
    End Sub

    Private Sub ChartZXX_MouseMove(sender As Object, e As MouseEventArgs) Handles ChartZXX.MouseMove
        Dim h As Windows.Forms.DataVisualization.Charting.HitTestResult = ChartZXX.HitTest(e.X, e.Y)
        Dim YVal As Double
        Dim a As Double
        Dim b As Double

        If h.ChartElementType = DataVisualization.Charting.ChartElementType.DataPoint Then
            Call markerXX(h.PointIndex)
        Else
            Call remarkerXX(nFreq)
        End If
      

        YVal = ChartZXX.ChartAreas(0).AxisY.PixelPositionToValue(e.Y)

        If isDraggingPointIMAG = True Then
            tableZXX.Rows(draggedPointIndex)(">ZXXI ROT=ZROT") = YVal
            tableALL.Rows(draggedPointIndex)(">ZXXI ROT=ZROT") = YVal

            Dim fr As Double = 1 / tableZXX.Rows(draggedPointIndex).Item(">PERIODE")
            Dim im As Double = YVal
            Dim re As Double = tableZXX.Rows(draggedPointIndex).Item(">ZXXR ROT=ZROT")

            a = CalcPHA(im, re)
            If a > 0 Then
                b = CalcPHA(im, re) - 180
            Else
                b = CalcPHA(im, re) + 180
            End If

            tableRhoPhaXX.Rows(draggedPointIndex)("RhoXX") = CalcRHO(fr, im, re)
            tableRhoPhaXX.Rows(draggedPointIndex)("PhaXX") = b
            tableALL.Rows(draggedPointIndex)(">RHOXX ROT=RHOROT") = CalcRHO(fr, im, re)
            tableALL.Rows(draggedPointIndex)(">PHSXX ROT=RHOROT") = b

            Call dBindZXX()
            Call dBindDash()
        ElseIf isDraggingPointREAL = True Then
            tableZXX.Rows(draggedPointIndex)(">ZXXR ROT=ZROT") = YVal
            tableALL.Rows(draggedPointIndex)(">ZXXR ROT=ZROT") = YVal

            Dim fr As Double = 1 / tableZXX.Rows(draggedPointIndex).Item(">PERIODE")
            Dim im As Double = tableZXX.Rows(draggedPointIndex).Item(">ZXXI ROT=ZROT")
            Dim re As Double = YVal

            a = CalcPHA(im, re)
            If a > 0 Then
                b = CalcPHA(im, re) - 180
            Else
                b = CalcPHA(im, re) + 180
            End If

            tableRhoPhaXX.Rows(draggedPointIndex)("RhoXX") = CalcRHO(fr, im, re)
            tableRhoPhaXX.Rows(draggedPointIndex)("PhaXX") = b
            tableALL.Rows(draggedPointIndex)(">RHOXX ROT=RHOROT") = CalcRHO(fr, im, re)
            tableALL.Rows(draggedPointIndex)(">PHSXX ROT=RHOROT") = b

            Call dBindZXX()
            Call dBindDash()
        End If
    End Sub

    Private Sub ChartZXX_MouseUp(sender As Object, e As MouseEventArgs) Handles ChartZXX.MouseUp
        draggedPointIndex = -1
        isDraggingPointIMAG = False
        isDraggingPointREAL = False
    End Sub

    Private Sub ChartZXY_MouseDown(sender As Object, e As MouseEventArgs) Handles ChartZXY.MouseDown

        Dim h As Windows.Forms.DataVisualization.Charting.HitTestResult = ChartZXY.HitTest(e.X, e.Y)
        Dim XVal As Double
        Dim YVal As Double

        If h.ChartElementType = DataVisualization.Charting.ChartElementType.DataPoint Then
            XVal = h.Series.Points(h.PointIndex).XValue
            YVal = h.Series.Points(h.PointIndex).YValues(0)
            If (h.Series.Points(h.PointIndex).YValues(0) = ChartZXY.Series(0).Points(h.PointIndex).YValues(0)) Then
                draggedPointIndex = h.PointIndex
                isDraggingPointIMAG = True
            ElseIf (h.Series.Points(h.PointIndex).YValues(0) = ChartZXY.Series(1).Points(h.PointIndex).YValues(0)) Then
                draggedPointIndex = h.PointIndex
                isDraggingPointREAL = True
            End If
        End If
    End Sub

    Private Sub ChartZXY_MouseMove(sender As Object, e As MouseEventArgs) Handles ChartZXY.MouseMove
        Dim h As Windows.Forms.DataVisualization.Charting.HitTestResult = ChartZXY.HitTest(e.X, e.Y)
        Dim YVal As Double

        If h.ChartElementType = DataVisualization.Charting.ChartElementType.DataPoint Then
            Call markerxy(h.PointIndex)
        Else
            Call remarkerxy(nFreq)
        End If

        YVal = ChartZXY.ChartAreas(0).AxisY.PixelPositionToValue(e.Y)

        If isDraggingPointIMAG = True Then
            tableZXY.Rows(draggedPointIndex)("log(>ZXYI ROT=ZROT)") = YVal
            tableALL.Rows(draggedPointIndex)(">ZXYI ROT=ZROT") = 10 ^ YVal

            Dim fr As Double = 1 / tableZXY.Rows(draggedPointIndex).Item(">PERIODE")
            Dim im As Double = 10 ^ YVal
            Dim re As Double = 10 ^ tableZXY.Rows(draggedPointIndex).Item("log(>ZXYR ROT=ZROT)")

            tableRhoPhaXY.Rows(draggedPointIndex)("RhoXY") = CalcRHO(fr, im, re)
            tableRhoPhaXY.Rows(draggedPointIndex)("PhaXY") = CalcPHA(im, re)

            tableALL.Rows(draggedPointIndex)(">RHOXY ROT=RHOROT") = CalcRHO(fr, im, re)
            tableALL.Rows(draggedPointIndex)(">PHSXY ROT=RHOROT") = CalcPHA(im, re)

            Call dBindZXY()
            Call dBindDash()
        ElseIf isDraggingPointREAL = True Then
            tableZXY.Rows(draggedPointIndex)("log(>ZXYR ROT=ZROT)") = YVal
            tableALL.Rows(draggedPointIndex)(">ZXYR ROT=ZROT") = 10 ^ YVal

            Dim fr As Double = 1 / tableZXY.Rows(draggedPointIndex).Item(">PERIODE")
            Dim im As Double = 10 ^ tableZXY.Rows(draggedPointIndex).Item("log(>ZXYI ROT=ZROT)")
            Dim re As Double = 10 ^ YVal

            tableRhoPhaXY.Rows(draggedPointIndex)("RhoXY") = CalcRHO(fr, im, re)
            tableRhoPhaXY.Rows(draggedPointIndex)("PhaXY") = CalcPHA(im, re)

            tableALL.Rows(draggedPointIndex)(">RHOXY ROT=RHOROT") = CalcRHO(fr, im, re)
            tableALL.Rows(draggedPointIndex)(">PHSXY ROT=RHOROT") = CalcPHA(im, re)
            Call dBindZXY()
            Call dBindDash()
        End If
    End Sub

    Private Sub ChartZXY_MouseUp(sender As Object, e As MouseEventArgs) Handles ChartZXY.MouseUp
        draggedPointIndex = -1
        isDraggingPointIMAG = False
        isDraggingPointREAL = False
    End Sub

    Private Sub ChartZYX_MouseDown(sender As Object, e As MouseEventArgs) Handles ChartZYX.MouseDown

        Dim h As Windows.Forms.DataVisualization.Charting.HitTestResult = ChartZYX.HitTest(e.X, e.Y)
        Dim XVal As Double
        Dim YVal As Double

        If h.ChartElementType = DataVisualization.Charting.ChartElementType.DataPoint Then
            XVal = h.Series.Points(h.PointIndex).XValue
            YVal = h.Series.Points(h.PointIndex).YValues(0)
            If (h.Series.Points(h.PointIndex).YValues(0) = ChartZYX.Series(0).Points(h.PointIndex).YValues(0)) Then
                draggedPointIndex = h.PointIndex
                isDraggingPointIMAG = True
            ElseIf (h.Series.Points(h.PointIndex).YValues(0) = ChartZYX.Series(1).Points(h.PointIndex).YValues(0)) Then
                draggedPointIndex = h.PointIndex
                isDraggingPointREAL = True
            End If
        End If
    End Sub

    Private Sub ChartZYX_MouseMove(sender As Object, e As MouseEventArgs) Handles ChartZYX.MouseMove
        Dim h As Windows.Forms.DataVisualization.Charting.HitTestResult = ChartZYX.HitTest(e.X, e.Y)
        Dim YVal As Double

        If h.ChartElementType = DataVisualization.Charting.ChartElementType.DataPoint Then
            Call markeryx(h.PointIndex)
        Else
            Call remarkeryx(nFreq)
        End If

        YVal = ChartZYX.ChartAreas(0).AxisY.PixelPositionToValue(e.Y)

        If isDraggingPointIMAG = True Then
            tableZYX.Rows(draggedPointIndex)("log(>ZYXI ROT=ZROT)") = YVal
            tableALL.Rows(draggedPointIndex)(">ZYXI ROT=ZROT") = -(10 ^ YVal)

            Dim fr As Double = 1 / tableZYX.Rows(draggedPointIndex).Item(">PERIODE")
            Dim im As Double = (10 ^ YVal)
            Dim re As Double = (10 ^ tableZYX.Rows(draggedPointIndex).Item("log(>ZYXR ROT=ZROT)"))

            tableRhoPhaYX.Rows(draggedPointIndex)("RhoYX") = CalcRHO(fr, im, re)
            tableRhoPhaYX.Rows(draggedPointIndex)("PhaYX") = CalcPHA(im, re) - 180

            tableALL.Rows(draggedPointIndex)(">RHOYX ROT=RHOROT") = CalcRHO(fr, im, re)
            tableALL.Rows(draggedPointIndex)(">PHSYX ROT=RHOROT") = CalcPHA(im, re) - 180

            Call dBindZYX()
            Call dBindDash()
        ElseIf isDraggingPointREAL = True Then
            tableZYX.Rows(draggedPointIndex)("log(>ZYXR ROT=ZROT)") = YVal
            tableALL.Rows(draggedPointIndex)(">ZYXR ROT=ZROT") = -(10 ^ YVal)

            Dim fr As Double = 1 / tableZYX.Rows(draggedPointIndex).Item(">PERIODE")
            Dim im As Double = (10 ^ tableZYX.Rows(draggedPointIndex).Item("log(>ZYXI ROT=ZROT)"))
            Dim re As Double = (10 ^ YVal)

            tableRhoPhaYX.Rows(draggedPointIndex)("RhoYX") = CalcRHO(fr, im, re)
            tableRhoPhaYX.Rows(draggedPointIndex)("PhaYX") = CalcPHA(im, re) - 180

            tableALL.Rows(draggedPointIndex)(">RHOYX ROT=RHOROT") = CalcRHO(fr, im, re)
            tableALL.Rows(draggedPointIndex)(">PHSYX ROT=RHOROT") = CalcPHA(im, re) - 180

            Call dBindZYX()
            Call dBindDash()
        End If
    End Sub

    Private Sub ChartZYX_MouseUp(sender As Object, e As MouseEventArgs) Handles ChartZYX.MouseUp
        draggedPointIndex = -1
        isDraggingPointIMAG = False
        isDraggingPointREAL = False
    End Sub

    Private Sub ChartZYY_MouseDown(sender As Object, e As MouseEventArgs) Handles ChartZYY.MouseDown

        Dim h As Windows.Forms.DataVisualization.Charting.HitTestResult = ChartZYY.HitTest(e.X, e.Y)
        Dim XVal As Double
        Dim YVal As Double

        If h.ChartElementType = DataVisualization.Charting.ChartElementType.DataPoint Then
            XVal = h.Series.Points(h.PointIndex).XValue
            YVal = h.Series.Points(h.PointIndex).YValues(0)
            If (h.Series.Points(h.PointIndex).YValues(0) = ChartZYY.Series(0).Points(h.PointIndex).YValues(0)) Then
                draggedPointIndex = h.PointIndex
                isDraggingPointIMAG = True
            ElseIf (h.Series.Points(h.PointIndex).YValues(0) = ChartZYY.Series(1).Points(h.PointIndex).YValues(0)) Then
                draggedPointIndex = h.PointIndex
                isDraggingPointREAL = True
            End If
        End If
    End Sub

    Private Sub ChartZYY_MouseMove(sender As Object, e As MouseEventArgs) Handles ChartZYY.MouseMove
        Dim h As Windows.Forms.DataVisualization.Charting.HitTestResult = ChartZYY.HitTest(e.X, e.Y)
        Dim YVal As Double
        Dim a As Double
        Dim b As Double
        If h.ChartElementType = DataVisualization.Charting.ChartElementType.DataPoint Then
            Call markeryy(h.PointIndex)
        Else
            Call remarkeryy(nFreq)
        End If

        YVal = ChartZYY.ChartAreas(0).AxisY.PixelPositionToValue(e.Y)

        If isDraggingPointIMAG = True Then
            tableZYY.Rows(draggedPointIndex)(">ZYYI ROT=ZROT") = YVal
            tableALL.Rows(draggedPointIndex)(">ZYYI ROT=ZROT") = YVal

            Dim fr As Double = 1 / tableZYY.Rows(draggedPointIndex).Item(">PERIODE")
            Dim im As Double = YVal
            Dim re As Double = tableZYY.Rows(draggedPointIndex).Item(">ZYYR ROT=ZROT")

            a = CalcPHA(im, re)
            If a > 0 Then
                b = CalcPHA(im, re) - 180
            Else
                b = CalcPHA(im, re) + 180
            End If

            tableRhoPhaYY.Rows(draggedPointIndex)("RhoYY") = CalcRHO(fr, im, re)
            tableRhoPhaYY.Rows(draggedPointIndex)("PhaYY") = b

            tableALL.Rows(draggedPointIndex)(">RHOYY ROT=RHOROT") = CalcRHO(fr, im, re)
            tableALL.Rows(draggedPointIndex)(">PHSYY ROT=RHOROT") = b

            Call dBindZYY()
            Call dBindDash()
        ElseIf isDraggingPointREAL = True Then
            tableZYY.Rows(draggedPointIndex)(">ZYYR ROT=ZROT") = YVal
            tableALL.Rows(draggedPointIndex)(">ZYYR ROT=ZROT") = YVal

            Dim fr As Double = 1 / tableZYY.Rows(draggedPointIndex).Item(">PERIODE")
            Dim im As Double = tableZYY.Rows(draggedPointIndex).Item(">ZYYI ROT=ZROT")
            Dim re As Double = YVal

            a = CalcPHA(im, re)
            If a > 0 Then
                b = CalcPHA(im, re) - 180
            Else
                b = CalcPHA(im, re) + 180
            End If

            tableRhoPhaYY.Rows(draggedPointIndex)("RhoYY") = CalcRHO(fr, im, re)
            tableRhoPhaYY.Rows(draggedPointIndex)("PhaYY") = b

            tableALL.Rows(draggedPointIndex)(">RHOYY ROT=RHOROT") = CalcRHO(fr, im, re)
            tableALL.Rows(draggedPointIndex)(">PHSYY ROT=RHOROT") = b

            Call dBindZYY()
            Call dBindDash()
        End If
    End Sub

    Private Sub ChartZYY_MouseUp(sender As Object, e As MouseEventArgs) Handles ChartZYY.MouseUp
        draggedPointIndex = -1
        isDraggingPointIMAG = False
        isDraggingPointREAL = False
    End Sub

    Private Sub ChartTXZ_MouseDown(sender As Object, e As MouseEventArgs) Handles ChartTXZ.MouseDown

        Dim h As Windows.Forms.DataVisualization.Charting.HitTestResult = ChartTXZ.HitTest(e.X, e.Y)
        Dim XVal As Double
        Dim YVal As Double

        If h.ChartElementType = DataVisualization.Charting.ChartElementType.DataPoint Then
            XVal = h.Series.Points(h.PointIndex).XValue
            YVal = h.Series.Points(h.PointIndex).YValues(0)
            If (h.Series.Points(h.PointIndex).YValues(0) = ChartTXZ.Series(0).Points(h.PointIndex).YValues(0)) Then
                draggedPointIndex = h.PointIndex
                isDraggingPointIMAG = True
            ElseIf (h.Series.Points(h.PointIndex).YValues(0) = ChartTXZ.Series(1).Points(h.PointIndex).YValues(0)) Then
                draggedPointIndex = h.PointIndex
                isDraggingPointREAL = True
            End If
        End If
    End Sub

    Private Sub ChartTXZ_MouseMove(sender As Object, e As MouseEventArgs) Handles ChartTXZ.MouseMove
        Dim h As Windows.Forms.DataVisualization.Charting.HitTestResult = ChartTXZ.HitTest(e.X, e.Y)
        Dim YVal As Double

        If h.ChartElementType = DataVisualization.Charting.ChartElementType.DataPoint Then
            Call markerxz(h.PointIndex)
        Else
            Call remarkerxz(nFreq)
        End If

        YVal = ChartTXZ.ChartAreas(0).AxisY.PixelPositionToValue(e.Y)

        If isDraggingPointIMAG = True Then
            tableTxZ.Rows(draggedPointIndex)(">TXI.EXP") = YVal
            tableALL.Rows(draggedPointIndex)(">TXI.EXP") = YVal

            Call dBindTXZ()
        ElseIf isDraggingPointREAL = True Then
            tableTxZ.Rows(draggedPointIndex)(">TXR.EXP") = YVal
            tableALL.Rows(draggedPointIndex)(">TXR.EXP") = YVal

            Call dBindTXZ()
        End If
    End Sub

    Private Sub ChartTXZ_MouseUp(sender As Object, e As MouseEventArgs) Handles ChartTXZ.MouseUp
        draggedPointIndex = -1
        isDraggingPointIMAG = False
        isDraggingPointREAL = False
    End Sub

    Private Sub ChartTyZ_MouseDown(sender As Object, e As MouseEventArgs) Handles ChartTYZ.MouseDown

        Dim h As Windows.Forms.DataVisualization.Charting.HitTestResult = ChartTYZ.HitTest(e.X, e.Y)
        Dim XVal As Double
        Dim YVal As Double

        If h.ChartElementType = DataVisualization.Charting.ChartElementType.DataPoint Then
            XVal = h.Series.Points(h.PointIndex).XValue
            YVal = h.Series.Points(h.PointIndex).YValues(0)
            If (h.Series.Points(h.PointIndex).YValues(0) = ChartTYZ.Series(0).Points(h.PointIndex).YValues(0)) Then
                draggedPointIndex = h.PointIndex
                isDraggingPointIMAG = True
            ElseIf (h.Series.Points(h.PointIndex).YValues(0) = ChartTYZ.Series(1).Points(h.PointIndex).YValues(0)) Then
                draggedPointIndex = h.PointIndex
                isDraggingPointREAL = True
            End If
        End If
    End Sub

    Private Sub ChartTyZ_MouseMove(sender As Object, e As MouseEventArgs) Handles ChartTYZ.MouseMove
        Dim h As Windows.Forms.DataVisualization.Charting.HitTestResult = ChartTYZ.HitTest(e.X, e.Y)
        Dim YVal As Double

        If h.ChartElementType = DataVisualization.Charting.ChartElementType.DataPoint Then
            Call markeryz(h.PointIndex)
        Else
            Call remarkeryz(nFreq)
        End If

        YVal = ChartTYZ.ChartAreas(0).AxisY.PixelPositionToValue(e.Y)

        If isDraggingPointIMAG = True Then
            tableTyZ.Rows(draggedPointIndex)(">TYI.EXP") = YVal
            tableALL.Rows(draggedPointIndex)(">TYI.EXP") = YVal

            Call dBindTYZ()
        ElseIf isDraggingPointREAL = True Then
            tableTyZ.Rows(draggedPointIndex)(">TYR.EXP") = YVal
            tableALL.Rows(draggedPointIndex)(">TYR.EXP") = YVal

            Call dBindTYZ()
        End If
    End Sub

    Private Sub ChartTyZ_MouseUp(sender As Object, e As MouseEventArgs) Handles ChartTYZ.MouseUp
        draggedPointIndex = -1
        isDraggingPointIMAG = False
        isDraggingPointREAL = False
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Call closeAll()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Call saveData()
    End Sub

    Private Sub ScaleSettingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScaleSettingToolStripMenuItem.Click
        ScaleSettingWindow.Show()
    End Sub

    Private Sub StaticShiftToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StaticShiftToolStripMenuItem.Click
        StaticShiftWindow.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        If dataExist = True Then
            Dim result As Integer = MessageBox.Show("What to save your EDI file?", "adEDItor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                staClose = True
                Me.Close()
            ElseIf result = DialogResult.Yes Then
                Call saveData()
            ElseIf result = DialogResult.Cancel Then
            End If
        Else
            staClose = True
            Me.Close()
        End If
    End Sub

    Function closeAll()
        DataWindow.Close()
        ScaleSettingWindow.Close()
        StaticShiftWindow.Close()

        Me.Text = "adEDItor"

        OpenToolStripMenuItem.Enabled = True
        CloseToolStripMenuItem.Enabled = False
        SaveToolStripMenuItem.Enabled = False
        ExitToolStripMenuItem.Enabled = True

        DataToolStripMenuItem.Enabled = False
        StaticShiftToolStripMenuItem.Enabled = False
        ScaleSettingToolStripMenuItem.Enabled = False

        DataWindow.DataGridViewAllData.Rows.Clear()
        DataWindow.DataGridViewAllData.Columns.Clear()

        DataWindow.DataGridViewRhoPhaXX.Rows.Clear()
        DataWindow.DataGridViewRhoPhaXX.Columns.Clear()
        DataWindow.DataGridViewRhoPhaXY.Rows.Clear()
        DataWindow.DataGridViewRhoPhaXY.Columns.Clear()
        DataWindow.DataGridViewRhoPhaYX.Rows.Clear()
        DataWindow.DataGridViewRhoPhaYX.Columns.Clear()
        DataWindow.DataGridViewRhoPhaYY.Rows.Clear()
        DataWindow.DataGridViewRhoPhaYY.Columns.Clear()

        DataWindow.DataGridViewTxZ.Rows.Clear()
        DataWindow.DataGridViewTxZ.Columns.Clear()
        DataWindow.DataGridViewTyZ.Rows.Clear()
        DataWindow.DataGridViewTyZ.Columns.Clear()

        DataWindow.DataGridViewZxx.Rows.Clear()
        DataWindow.DataGridViewZxx.Columns.Clear()
        DataWindow.DataGridViewZxy.Rows.Clear()
        DataWindow.DataGridViewZxy.Columns.Clear()
        DataWindow.DataGridViewZyx.Rows.Clear()
        DataWindow.DataGridViewZyx.Columns.Clear()
        DataWindow.DataGridViewZyy.Rows.Clear()
        DataWindow.DataGridViewZyy.Columns.Clear()

        dataExist = False

        tableHeader.Clear()
        tableALL.Clear()
        tableZXX.Clear()
        tableRhoPhaXX.Clear()
        tableZXY.Clear()
        tableRhoPhaXY.Clear()
        tableZYX.Clear()
        tableRhoPhaYX.Clear()
        tableZYY.Clear()
        tableRhoPhaYY.Clear()
        tableTxZ.Clear()
        tableTyZ.Clear()

        ChartRhoXX.Series(0).Points.Clear()
        ChartPhaXX.Series(0).Points.Clear()
        ChartZXX.Series(0).Points.Clear()
        ChartZXX.Series(1).Points.Clear()

        ChartRhoXY.Series(0).Points.Clear()
        ChartPhaXY.Series(0).Points.Clear()
        ChartRhoXY.Series(1).Points.Clear()
        ChartPhaXY.Series(1).Points.Clear()
        ChartZXY.Series(0).Points.Clear()
        ChartZXY.Series(1).Points.Clear()

        ChartRhoYX.Series(0).Points.Clear()
        ChartPhaYX.Series(0).Points.Clear()
        ChartRhoYX.Series(1).Points.Clear()
        ChartPhaYX.Series(1).Points.Clear()
        ChartZYX.Series(0).Points.Clear()
        ChartZYX.Series(1).Points.Clear()

        ChartRhoYY.Series(0).Points.Clear()
        ChartPhaYY.Series(0).Points.Clear()
        ChartZYY.Series(0).Points.Clear()
        ChartZYY.Series(1).Points.Clear()

        ChartTXZ.Series(0).Points.Clear()
        ChartTYZ.Series(0).Points.Clear()
        ChartTXZ.Series(1).Points.Clear()
        ChartTYZ.Series(1).Points.Clear()

        ChartRhoXX.Series(0).Points.AddXY(100000, 100000)
        ChartPhaXX.Series(0).Points.AddXY(100000, 100000)
        ChartZXX.Series(0).Points.AddXY(100000, 100000)

        ChartRhoXY.Series(0).Points.AddXY(100000, 100000)
        ChartPhaXY.Series(0).Points.AddXY(100000, 100000)
        ChartZXY.Series(0).Points.AddXY(100000, 100000)

        ChartRhoYX.Series(0).Points.AddXY(100000, 100000)
        ChartPhaYX.Series(0).Points.AddXY(100000, 100000)
        ChartZYX.Series(0).Points.AddXY(100000, 100000)

        ChartRhoYY.Series(0).Points.AddXY(100000, 100000)
        ChartPhaYY.Series(0).Points.AddXY(100000, 100000)
        ChartZYY.Series(0).Points.AddXY(100000, 100000)

        ChartTXZ.Series(0).Points.AddXY(100000, 100000)
        ChartTYZ.Series(0).Points.AddXY(100000, 100000)

        nFreq = Nothing
        Freq(intFreq) = Nothing
        Zrot(intFreq) = Nothing
        ZxxR(intFreq) = Nothing
        ZxxI(intFreq) = Nothing
        ZxxV(intFreq) = Nothing
        ZxyR(intFreq) = Nothing
        ZxyI(intFreq) = Nothing
        Zxyv(intFreq) = Nothing
        ZyxR(intFreq) = Nothing
        ZyxI(intFreq) = Nothing
        Zyxv(intFreq) = Nothing
        ZyyR(intFreq) = Nothing
        ZyyI(intFreq) = Nothing
        Zyyv(intFreq) = Nothing

        RHOR(intFreq) = Nothing
        RHOxyR(intFreq) = Nothing
        RHOxyE(intFreq) = Nothing
        RHOxyF(intFreq) = Nothing
        RHOyxR(intFreq) = Nothing
        RHOyxE(intFreq) = Nothing
        RHOyxF(intFreq) = Nothing
        RHOxxR(intFreq) = Nothing
        RHOxxE(intFreq) = Nothing
        RHOyyR(intFreq) = Nothing
        RHOyyE(intFreq) = Nothing

        PHAxyR(intFreq) = Nothing
        PHAxyE(intFreq) = Nothing
        PHAxyF(intFreq) = Nothing
        PHAyxR(intFreq) = Nothing
        PHAyxE(intFreq) = Nothing
        PHAyxF(intFreq) = Nothing
        PHAxxR(intFreq) = Nothing
        PHAxxE(intFreq) = Nothing
        PHAyyR(intFreq) = Nothing
        PHAyyE(intFreq) = Nothing

        Trot(intFreq) = Nothing
        TxR(intFreq) = Nothing
        TxI(intFreq) = Nothing
        TxV(intFreq) = Nothing
        TyR(intFreq) = Nothing
        TyI(intFreq) = Nothing
        TyV(intFreq) = Nothing
        TipM(intFreq) = Nothing
        TipMV(intFreq) = Nothing
        TipP(intFreq) = Nothing

        Zstrike(intFreq) = Nothing
        Zskew(intFreq) = Nothing
        Zellip(intFreq) = Nothing
        Tstrike(intFreq) = Nothing
        Tskew(intFreq) = Nothing
        Tellip(intFreq) = Nothing

        IndMagR(intFreq) = Nothing
        IndMagI(intFreq) = Nothing
        IndAngR(intFreq) = Nothing
        IndAngI(intFreq) = Nothing

        staPERIODE = False
        staZROT = False
        staZXXR = False
        staZXXI = False
        staZXXVAR = False
        staZXYR = False
        staZXYI = False
        staZXYVAR = False
        staZYXR = False
        staZYXI = False
        staZYXVAR = False
        staZYYR = False
        staZYYI = False
        staZYYVAR = False
        staRHOROT = False
        staRHOXY = False
        staRHOXYERR = False
        staRHOXYFIT = False
        staRHOYX = False
        staRHOYXERR = False
        staRHOYXFIT = False
        staRHOXX = False
        staRHOXXERR = False
        staRHOYY = False
        staRHOYYERR = False
        staPHSXY = False
        staPHSXYERR = False
        staPHSXYFIT = False
        staPHSYX = False
        staPHSYXERR = False
        staPHSYXFIT = False
        staPHSXX = False
        staPHSXXERR = False
        staPHSYY = False
        staPHSYYERR = False
        staTROTEXP = False
        staTXREXP = False
        staTXIEXP = False
        staTXVAREXP = False
        staTYREXP = False
        staTYIEXP = False
        staTYVAREXP = False
        staTIPMAG = False
        staTIPMAGVAR = False
        staTIPPHS = False
        staZSTRIKE = False
        staZSKEW = False
        staZELLIP = False
        staTSTRIKE = False
        staTSKEW = False
        staTELLIP = False
        staINDMAGREXP = False
        staINDMAGIEXP = False
        staINDANGREXP = False
        staINDANGIEXP = False

        Return 0
    End Function

    Function saveData()
        Dim objStreamWriter As StreamWriter
        Dim saveFileDialog1 As New SaveFileDialog()
        Dim i As Integer
        saveFileDialog1.InitialDirectory = "D:\EDI3D"
        saveFileDialog1.Filter = "EDI files (*.edi)|*.edi"
        saveFileDialog1.FilterIndex = 1
        saveFileDialog1.RestoreDirectory = True

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            objStreamWriter = New StreamWriter(saveFileDialog1.FileName)

            For Each row As DataRow In tableHeader.Rows
                objStreamWriter.WriteLine(row(">HEADER"))
            Next

            If (staPERIODE = True) Then
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">PERIODE") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", 1 / row(">PERIODE")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", 1 / row(">PERIODE")) & " ")
                        End If
                    Else
                        If (row(">PERIODE") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", 1 / row(">PERIODE")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", 1 / row(">PERIODE")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            objStreamWriter.Write(vbCrLf & ">!****IMPEDANCE ROTATION ANGLES****!")
            If staZROT = True Then
                objStreamWriter.Write(vbCrLf & ">ZROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">ZROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZROT")) & " ")
                        End If
                    Else
                        If (row(">ZROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            objStreamWriter.Write(vbCrLf & ">!****IMPEDANCES****!")
            If staZXXR = True Then
                objStreamWriter.Write(vbCrLf & ">ZXXR ROT=ZROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">ZXXR ROT=ZROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZXXR ROT=ZROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZXXR ROT=ZROT")) & " ")
                        End If
                    Else
                        If (row(">ZXXR ROT=ZROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZXXR ROT=ZROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZXXR ROT=ZROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staZXXI = True Then
                objStreamWriter.Write(vbCrLf & ">ZXXI ROT=ZROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">ZXXI ROT=ZROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZXXI ROT=ZROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZXXI ROT=ZROT")) & " ")
                        End If
                    Else
                        If (row(">ZXXI ROT=ZROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZXXI ROT=ZROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZXXI ROT=ZROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staZXXVAR = True Then
                objStreamWriter.Write(vbCrLf & ">ZXX.VAR ROT=ZROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">ZXX.VAR ROT=ZROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZXX.VAR ROT=ZROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZXX.VAR ROT=ZROT")) & " ")
                        End If

                    Else
                        If (row(">ZXX.VAR ROT=ZROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZXX.VAR ROT=ZROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZXX.VAR ROT=ZROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staZXYR = True Then
                objStreamWriter.Write(vbCrLf & ">ZXYR ROT=ZROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">ZXYR ROT=ZROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZXYR ROT=ZROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZXYR ROT=ZROT")) & " ")
                        End If

                    Else
                        If (row(">ZXYR ROT=ZROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZXYR ROT=ZROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZXYR ROT=ZROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staZXYI = True Then
                objStreamWriter.Write(vbCrLf & ">ZXYI ROT=ZROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">ZXYI ROT=ZROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZXYI ROT=ZROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZXYI ROT=ZROT")) & " ")
                        End If

                    Else
                        If (row(">ZXYI ROT=ZROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZXYI ROT=ZROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZXYI ROT=ZROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staZXYVAR = True Then
                objStreamWriter.Write(vbCrLf & ">ZXY.VAR ROT=ZROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">ZXY.VAR ROT=ZROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZXY.VAR ROT=ZROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZXY.VAR ROT=ZROT")) & " ")
                        End If

                    Else
                        If (row(">ZXY.VAR ROT=ZROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZXY.VAR ROT=ZROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZXY.VAR ROT=ZROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staZYXR = True Then
                objStreamWriter.Write(vbCrLf & ">ZYXR ROT=ZROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">ZYXR ROT=ZROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZYXR ROT=ZROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZYXR ROT=ZROT")) & " ")
                        End If

                    Else
                        If (row(">ZYXR ROT=ZROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZYXR ROT=ZROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZYXR ROT=ZROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staZYXI = True Then
                objStreamWriter.Write(vbCrLf & ">ZYXI ROT=ZROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">ZYXI ROT=ZROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZYXI ROT=ZROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZYXI ROT=ZROT")) & " ")
                        End If

                    Else
                        If (row(">ZYXI ROT=ZROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZYXI ROT=ZROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZYXI ROT=ZROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staZYXVAR = True Then
                objStreamWriter.Write(vbCrLf & ">ZYX.VAR ROT=ZROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">ZYX.VAR ROT=ZROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZYX.VAR ROT=ZROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZYX.VAR ROT=ZROT")) & " ")
                        End If

                    Else
                        If (row(">ZYX.VAR ROT=ZROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZYX.VAR ROT=ZROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZYX.VAR ROT=ZROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staZYYR = True Then
                objStreamWriter.Write(vbCrLf & ">ZYYR ROT=ZROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">ZYYR ROT=ZROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZYYR ROT=ZROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZYYR ROT=ZROT")) & " ")
                        End If

                    Else
                        If (row(">ZYYR ROT=ZROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZYYR ROT=ZROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZYYR ROT=ZROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staZYYI = True Then
                objStreamWriter.Write(vbCrLf & ">ZYYI ROT=ZROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">ZYYI ROT=ZROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZYYI ROT=ZROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZYYI ROT=ZROT")) & " ")
                        End If

                    Else
                        If (row(">ZYYI ROT=ZROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZYYI ROT=ZROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZYYI ROT=ZROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staZYYVAR = True Then
                objStreamWriter.Write(vbCrLf & ">ZYY.VAR ROT=ZROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">ZYY.VAR ROT=ZROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZYY.VAR ROT=ZROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZYY.VAR ROT=ZROT")) & " ")
                        End If

                    Else
                        If (row(">ZYY.VAR ROT=ZROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZYY.VAR ROT=ZROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZYY.VAR ROT=ZROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staRHOROT = True Then
                objStreamWriter.Write(vbCrLf & ">RHOROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">RHOROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">RHOROT")) & " ")
                        End If

                    Else
                        If (row(">RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">RHOROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">RHOROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            objStreamWriter.Write(vbCrLf & ">!****APPARENT RESISTIVITIES AND PHASES****!")
            If staRHOXY = True Then
                objStreamWriter.Write(vbCrLf & ">RHOXY ROT=RHOROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">RHOXY ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">RHOXY ROT=RHOROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">RHOXY ROT=RHOROT")) & " ")
                        End If

                    Else
                        If (row(">RHOXY ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">RHOXY ROT=RHOROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">RHOXY ROT=RHOROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staRHOXYERR = True Then
                objStreamWriter.Write(vbCrLf & ">RHOXY.ERR ROT=RHOROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">RHOXY.ERR ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">RHOXY.ERR ROT=RHOROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">RHOXY.ERR ROT=RHOROT")) & " ")
                        End If

                    Else
                        If (row(">RHOXY.ERR ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">RHOXY.ERR ROT=RHOROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">RHOXY.ERR ROT=RHOROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staRHOXYFIT = True Then
                objStreamWriter.Write(vbCrLf & ">RHOXY.FIT ROT=RHOROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">RHOXY.FIT ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">RHOXY.FIT ROT=RHOROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">RHOXY.FIT ROT=RHOROT")) & " ")
                        End If

                    Else
                        If (row(">RHOXY.FIT ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">RHOXY.FIT ROT=RHOROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">RHOXY.FIT ROT=RHOROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staRHOYX = True Then
                objStreamWriter.Write(vbCrLf & ">RHOYX ROT=RHOROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">RHOYX ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">RHOYX ROT=RHOROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">RHOYX ROT=RHOROT")) & " ")
                        End If

                    Else
                        If (row(">RHOYX ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">RHOYX ROT=RHOROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">RHOYX ROT=RHOROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staRHOYXERR = True Then
                objStreamWriter.Write(vbCrLf & ">RHOYX.ERR ROT=RHOROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">RHOYX.ERR ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">RHOYX.ERR ROT=RHOROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">RHOYX.ERR ROT=RHOROT")) & " ")
                        End If

                    Else
                        If (row(">RHOYX.ERR ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">RHOYX.ERR ROT=RHOROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">RHOYX.ERR ROT=RHOROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staRHOYXFIT = True Then
                objStreamWriter.Write(vbCrLf & ">RHOYX.FIT ROT=RHOROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">RHOYX.FIT ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">RHOYX.FIT ROT=RHOROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">RHOYX.FIT ROT=RHOROT")) & " ")
                        End If

                    Else
                        If (row(">RHOYX.FIT ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">RHOYX.FIT ROT=RHOROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">RHOYX.FIT ROT=RHOROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staRHOXX = True Then
                objStreamWriter.Write(vbCrLf & ">RHOXX ROT=RHOROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">RHOXX ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">RHOXX ROT=RHOROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">RHOXX ROT=RHOROT")) & " ")
                        End If

                    Else
                        If (row(">RHOXX ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">RHOXX ROT=RHOROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">RHOXX ROT=RHOROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staRHOXXERR = True Then
                objStreamWriter.Write(vbCrLf & ">RHOXX.ERR ROT=RHOROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">RHOXX.ERR ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">RHOXX.ERR ROT=RHOROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">RHOXX.ERR ROT=RHOROT")) & " ")
                        End If

                    Else
                        If (row(">RHOXX.ERR ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">RHOXX.ERR ROT=RHOROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">RHOXX.ERR ROT=RHOROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If


            If staRHOYY = True Then
                objStreamWriter.Write(vbCrLf & ">RHOYY ROT=RHOROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">RHOYY ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">RHOYY ROT=RHOROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">RHOYY ROT=RHOROT")) & " ")
                        End If

                    Else
                        If (row(">RHOYY ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">RHOYY ROT=RHOROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">RHOYY ROT=RHOROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staRHOYYERR = True Then
                objStreamWriter.Write(vbCrLf & ">RHOYY.ERR ROT=RHOROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">RHOYY.ERR ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">RHOYY.ERR ROT=RHOROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">RHOYY.ERR ROT=RHOROT")) & " ")
                        End If

                    Else
                        If (row(">RHOYY.ERR ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">RHOYY.ERR ROT=RHOROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">RHOYY.ERR ROT=RHOROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staPHSXY = True Then
                objStreamWriter.Write(vbCrLf & ">PHSXY ROT=RHOROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">PHSXY ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">PHSXY ROT=RHOROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">PHSXY ROT=RHOROT")) & " ")
                        End If

                    Else
                        If (row(">PHSXY ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">PHSXY ROT=RHOROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">PHSXY ROT=RHOROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staPHSXYERR = True Then
                objStreamWriter.Write(vbCrLf & ">PHSXY.ERR ROT=RHOROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">PHSXY.ERR ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">PHSXY.ERR ROT=RHOROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">PHSXY.ERR ROT=RHOROT")) & " ")
                        End If

                    Else
                        If (row(">PHSXY.ERR ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">PHSXY.ERR ROT=RHOROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">PHSXY.ERR ROT=RHOROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staPHSXYFIT = True Then
                objStreamWriter.Write(vbCrLf & ">PHSXY.FIT ROT=RHOROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">PHSXY.FIT ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">PHSXY.FIT ROT=RHOROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">PHSXY.FIT ROT=RHOROT")) & " ")
                        End If

                    Else
                        If (row(">PHSXY.FIT ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">PHSXY.FIT ROT=RHOROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">PHSXY.FIT ROT=RHOROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staPHSYX = True Then
                objStreamWriter.Write(vbCrLf & ">PHSYX ROT=RHOROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">PHSYX ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">PHSYX ROT=RHOROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">PHSYX ROT=RHOROT")) & " ")
                        End If

                    Else
                        If (row(">PHSYX ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">PHSYX ROT=RHOROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">PHSYX ROT=RHOROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staPHSYXERR = True Then
                objStreamWriter.Write(vbCrLf & ">PHSYX.ERR ROT=RHOROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">PHSYX.ERR ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">PHSYX.ERR ROT=RHOROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">PHSYX.ERR ROT=RHOROT")) & " ")
                        End If

                    Else
                        If (row(">PHSYX.ERR ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">PHSYX.ERR ROT=RHOROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">PHSYX.ERR ROT=RHOROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staPHSYXFIT = True Then
                objStreamWriter.Write(vbCrLf & ">PHSYX.FIT ROT=RHOROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">PHSYX.FIT ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">PHSYX.FIT ROT=RHOROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">PHSYX.FIT ROT=RHOROT")) & " ")
                        End If
                    Else
                        If (row(">PHSYX.FIT ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">PHSYX.FIT ROT=RHOROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">PHSYX.FIT ROT=RHOROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staPHSXX = True Then
                objStreamWriter.Write(vbCrLf & ">PHSXX ROT=RHOROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">PHSXX ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">PHSXX ROT=RHOROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">PHSXX ROT=RHOROT")) & " ")
                        End If
                    Else
                        If (row(">PHSXX ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">PHSXX ROT=RHOROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">PHSXX ROT=RHOROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staPHSXXERR = True Then
                objStreamWriter.Write(vbCrLf & ">PHSXX.ERR ROT=RHOROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">PHSXX.ERR ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">PHSXX.ERR ROT=RHOROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">PHSXX.ERR ROT=RHOROT")) & " ")
                        End If
                    Else
                        If (row(">PHSXX.ERR ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">PHSXX.ERR ROT=RHOROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">PHSXX.ERR ROT=RHOROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staPHSYY = True Then
                objStreamWriter.Write(vbCrLf & ">PHSYY ROT=RHOROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">PHSYY ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">PHSYY ROT=RHOROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">PHSYY ROT=RHOROT")) & " ")
                        End If
                    Else
                        If (row(">PHSYY ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">PHSYY ROT=RHOROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">PHSYY ROT=RHOROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staPHSYYERR = True Then
                objStreamWriter.Write(vbCrLf & ">PHSYY.ERR ROT=RHOROT //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">PHSYY.ERR ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">PHSYY.ERR ROT=RHOROT")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">PHSYY.ERR ROT=RHOROT")) & " ")
                        End If
                    Else
                        If (row(">PHSYY.ERR ROT=RHOROT") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">PHSYY.ERR ROT=RHOROT")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">PHSYY.ERR ROT=RHOROT")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            objStreamWriter.Write(vbCrLf & ">!****TIPPER PARAMETERS****!")
            If staTROTEXP = True Then
                objStreamWriter.Write(vbCrLf & ">TROT.EXP //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">TROT.EXP") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">TROT.EXP")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">TROT.EXP")) & " ")
                        End If
                    Else
                        If (row(">TROT.EXP") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">TROT.EXP")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">TROT.EXP")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staTXREXP = True Then
                objStreamWriter.Write(vbCrLf & ">TXR.EXP //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">TXR.EXP") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">TXR.EXP")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">TXR.EXP")) & " ")
                        End If
                    Else
                        If (row(">TXR.EXP") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">TXR.EXP")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">TXR.EXP")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staTXIEXP = True Then
                objStreamWriter.Write(vbCrLf & ">TXI.EXP //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">TXI.EXP") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">TXI.EXP")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">TXI.EXP")) & " ")
                        End If
                    Else
                        If (row(">TXI.EXP") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">TXI.EXP")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">TXI.EXP")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staTXVAREXP = True Then
                objStreamWriter.Write(vbCrLf & ">TXVAR.EXP //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">TXVAR.EXP") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">TXVAR.EXP")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">TXVAR.EXP")) & " ")
                        End If
                    Else
                        If (row(">TXVAR.EXP") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">TXVAR.EXP")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">TXVAR.EXP")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staTYREXP = True Then
                objStreamWriter.Write(vbCrLf & ">TYR.EXP //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">TYR.EXP") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">TYR.EXP")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">TYR.EXP")) & " ")
                        End If
                    Else
                        If (row(">TYR.EXP") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">TYR.EXP")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">TYR.EXP")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staTYIEXP = True Then
                objStreamWriter.Write(vbCrLf & ">TYI.EXP //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">TYI.EXP") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">TYI.EXP")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">TYI.EXP")) & " ")
                        End If
                    Else
                        If (row(">TYI.EXP") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">TYI.EXP")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">TYI.EXP")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staTYVAREXP = True Then
                objStreamWriter.Write(vbCrLf & ">TYVAR.EXP //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">TYVAR.EXP") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">TYVAR.EXP")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">TYVAR.EXP")) & " ")
                        End If
                    Else
                        If (row(">TYVAR.EXP") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">TYVAR.EXP")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">TYVAR.EXP")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staTIPMAG = True Then
                objStreamWriter.Write(vbCrLf & ">TIPMAG //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">TIPMAG") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">TIPMAG")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">TIPMAG")) & " ")
                        End If
                    Else
                        If (row(">TIPMAG") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">TIPMAG")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">TIPMAG")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staTIPMAGVAR = True Then
                objStreamWriter.Write(vbCrLf & ">TIPMAG.VAR //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">TIPMAG.VAR") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">TIPMAG.VAR")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">TIPMAG.VAR")) & " ")
                        End If
                    Else
                        If (row(">TIPMAG.VAR") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">TIPMAG.VAR")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">TIPMAG.VAR")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staTIPPHS = True Then
                objStreamWriter.Write(vbCrLf & ">TIPPHS //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">TIPPHS") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">TIPPHS")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">TIPPHS")) & " ")
                        End If
                    Else
                        If (row(">TIPPHS") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">TIPPHS")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">TIPPHS")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staZSTRIKE = True Then
                objStreamWriter.Write(vbCrLf & ">ZSTRIKE //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">ZSTRIKE") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZSTRIKE")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZSTRIKE")) & " ")
                        End If
                    Else
                        If (row(">ZSTRIKE") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZSTRIKE")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZSTRIKE")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staZSKEW = True Then
                objStreamWriter.Write(vbCrLf & ">ZSKEW //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">ZSKEW") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZSKEW")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZSKEW")) & " ")
                        End If
                    Else
                        If (row(">ZSKEW") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZSKEW")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZSKEW")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staZELLIP = True Then
                objStreamWriter.Write(vbCrLf & ">ZELLIP //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">ZELLIP") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZELLIP")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZELLIP")) & " ")
                        End If
                    Else
                        If (row(">ZELLIP") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">ZELLIP")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">ZELLIP")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staTSTRIKE = True Then
                objStreamWriter.Write(vbCrLf & ">TSTRIKE //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">TSTRIKE") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">TSTRIKE")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">TSTRIKE")) & " ")
                        End If
                    Else
                        If (row(">TSTRIKE") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">TSTRIKE")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">TSTRIKE")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staTSKEW = True Then
                objStreamWriter.Write(vbCrLf & ">TSKEW //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">TSKEW") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">TSKEW")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">TSKEW")) & " ")
                        End If
                    Else
                        If (row(">TSKEW") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">TSKEW")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">TSKEW")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staTELLIP = True Then
                objStreamWriter.Write(vbCrLf & ">TELLIP //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">TELLIP") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">TELLIP")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">TELLIP")) & " ")
                        End If
                    Else
                        If (row(">TELLIP") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">TELLIP")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">TELLIP")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staINDMAGREXP = True Then
                objStreamWriter.Write(vbCrLf & ">INDMAGR.EXP NFREQ=" & nFreq & " //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">INDMAGR.EXP") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">INDMAGR.EXP")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">INDMAGR.EXP")) & " ")
                        End If
                    Else
                        If (row(">INDMAGR.EXP") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">INDMAGR.EXP")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">INDMAGR.EXP")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staINDMAGIEXP = True Then
                objStreamWriter.Write(vbCrLf & ">INDMAGI.EXP NFREQ=" & nFreq & " //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">INDMAGI.EXP") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">INDMAGI.EXP")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">INDMAGI.EXP")) & " ")
                        End If
                    Else
                        If (row(">INDMAGI.EXP") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">INDMAGI.EXP")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">INDMAGI.EXP")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staINDANGREXP = True Then
                objStreamWriter.Write(vbCrLf & ">INDANGR.EXP NFREQ=" & nFreq & " //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">INDANGR.EXP") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">INDANGR.EXP")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">INDANGR.EXP")) & " ")
                        End If
                    Else
                        If (row(">INDANGR.EXP") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">INDANGR.EXP")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">INDANGR.EXP")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            If staINDANGIEXP = True Then
                objStreamWriter.Write(vbCrLf & ">INDANGI.EXP NFREQ=" & nFreq & " //" & nFreq & vbCrLf)
                i = 0
                For Each row As DataRow In tableALL.Rows
                    i += 1
                    If (i Mod 6 <> 0) Then
                        If (row(">INDANGI.EXP") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">INDANGI.EXP")) & " ")
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">INDANGI.EXP")) & " ")
                        End If
                    Else
                        If (row(">INDANGI.EXP") >= 0) Then
                            objStreamWriter.Write(" " & String.Format("{0:0.000000#e+00}", row(">INDANGI.EXP")) & " " & vbCrLf)
                        Else
                            objStreamWriter.Write(String.Format("{0:0.000000#e+00}", row(">INDANGI.EXP")) & " " & vbCrLf)
                        End If
                    End If
                Next
            End If

            'objStreamWriter.Write(vbCrLf)
            objStreamWriter.Write(vbCrLf & ">END")
            objStreamWriter.Close()

        End If
        Return 0
    End Function

    Function openData(ByVal OpenFileName As String)
        Dim i As Integer
        Dim ReadEdi As String
        Dim rNfreq() As String
        Dim nloop As Integer
        Using EdiFile As StreamReader = My.Computer.FileSystem.OpenTextFileReader(OpenFileName)
            Dim strReadEdi() As String
            Try
                'read number of frequency---------------------------------------------------------
                ReadEdi = EdiFile.ReadLine()
                tableHeader.Rows.Add(ReadEdi)
                Do Until ReadEdi = ">=MTSECT"
                    ReadEdi = EdiFile.ReadLine()
                    tableHeader.Rows.Add(ReadEdi)
                Loop
                ReadEdi = EdiFile.ReadLine()
                tableHeader.Rows.Add(ReadEdi)
                ReadEdi = EdiFile.ReadLine()
                tableHeader.Rows.Add(ReadEdi)
                rNfreq = ReadEdi.Split("=")
                nFreq = rNfreq(1)
                '-------------------------------------------------------------------------------
                nloop = (nFreq - (nFreq Mod 6)) / 6
                If (nFreq Mod 6) <> 0 Then
                    nloop = nloop + 1
                End If
                '------------------------------------------------------------------------------
                i = 0
                'read frequency------------------------------------------------------------------
                Do Until ReadEdi = ">FREQ //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                    tableHeader.Rows.Add(ReadEdi)
                Loop
                staPERIODE = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            Freq(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '------------------------------------------------------------------------------
                i = 0
                'read Zrot---------------------------------------------------------------------
                Do Until ReadEdi = ">ZROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staZROT = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            Zrot(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '------------------------------------------------------------------------------
                i = 0
                'read ZxxR---------------------------------------------------------------------
                Do Until ReadEdi = ">ZXXR ROT=ZROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staZXXR = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            ZxxR(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '------------------------------------------------------------------------------
                i = 0
                'read ZxxI---------------------------------------------------------------------
                Do Until ReadEdi = ">ZXXI ROT=ZROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staZXXI = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            ZxxI(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '-----------------------------------------------------------------------------
                i = 0
                'read ZxxV---------------------------------------------------------------------
                Do Until ReadEdi = ">ZXX.VAR ROT=ZROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staZXXVAR = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            ZxxV(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '-----------------------------------------------------------------------------
                i = 0
                'read ZxyR---------------------------------------------------------------------
                Do Until ReadEdi = ">ZXYR ROT=ZROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staZXYR = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            ZxyR(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '------------------------------------------------------------------------------
                i = 0
                'read ZxyI---------------------------------------------------------------------
                Do Until ReadEdi = ">ZXYI ROT=ZROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staZXYI = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            ZxyI(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '-----------------------------------------------------------------------------
                i = 0
                'read ZxyV---------------------------------------------------------------------
                Do Until ReadEdi = ">ZXY.VAR ROT=ZROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staZXYVAR = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            Zxyv(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '-----------------------------------------------------------------------------
                i = 0
                'read ZyxR---------------------------------------------------------------------
                Do Until ReadEdi = ">ZYXR ROT=ZROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staZYXR = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            ZyxR(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '------------------------------------------------------------------------------
                i = 0
                'read ZyxI---------------------------------------------------------------------
                Do Until ReadEdi = ">ZYXI ROT=ZROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staZYXI = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            ZyxI(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '-----------------------------------------------------------------------------
                i = 0
                'read ZyxV---------------------------------------------------------------------
                Do Until ReadEdi = ">ZYX.VAR ROT=ZROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staZYXVAR = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            Zyxv(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '-----------------------------------------------------------------------------
                i = 0
                'read ZyyR---------------------------------------------------------------------
                Do Until ReadEdi = ">ZYYR ROT=ZROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staZYYR = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            ZyyR(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '------------------------------------------------------------------------------
                i = 0
                'read ZyyI---------------------------------------------------------------------
                Do Until ReadEdi = ">ZYYI ROT=ZROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staZYYI = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            ZyyI(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '-----------------------------------------------------------------------------
                i = 0
                'read ZyyV---------------------------------------------------------------------
                Do Until ReadEdi = ">ZYY.VAR ROT=ZROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staZYYVAR = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            Zyyv(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '-----------------------------------------------------------------------------
                i = 0
                'read RhoR---------------------------------------------------------------------
                Do Until ReadEdi = ">RHOROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staRHOROT = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            RHOR(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '-----------------------------------------------------------------------------
                i = 0
                'read RhoxyR---------------------------------------------------------------------
                Do Until ReadEdi = ">RHOXY ROT=RHOROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staRHOXY = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            RHOxyR(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '----------------------------------------------------------------------------
                i = 0
                'read RhoxyE---------------------------------------------------------------------
                Do Until ReadEdi = ">RHOXY.ERR ROT=RHOROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staRHOXYERR = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            RHOxyE(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '----------------------------------------------------------------------------
                i = 0
                'read RHOxyF------------------------------------------------------------------
                Do Until ReadEdi = ">RHOXY.FIT ROT=RHOROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                    If ReadEdi = (">RHOYX ROT=RHOROT //" & nFreq) Then
                        GoTo LineRHOYXROTRHOROT
                    End If
                Loop
                staRHOXYFIT = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            RHOxyF(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '-----------------------------------------------------------------------------
                i = 0
                'read RhoyxR---------------------------------------------------------------------
                Do Until ReadEdi = ">RHOYX ROT=RHOROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
LineRHOYXROTRHOROT:
                staRHOYX = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            RHOyxR(i) = strReadEdi(j)
                        End If
                    Next j
                Next k

                '----------------------------------------------------------------------------
                i = 0
                'read RhoyxE---------------------------------------------------------------------
                Do Until ReadEdi = ">RHOYX.ERR ROT=RHOROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staRHOYXERR = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            RHOyxE(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '----------------------------------------------------------------------------
                i = 0
                'read RHOyxF-----------------------------------------------------------------
                Do Until ReadEdi = ">RHOYX.FIT ROT=RHOROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                    If ReadEdi = (">RHOXX ROT=RHOROT //" & nFreq) Then
                        GoTo LineRHOXXROTRHOROT
                    End If
                Loop
                staRHOYXFIT = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            RHOyxF(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '-----------------------------------------------------------------------------
                i = 0
                'read RhoxxR---------------------------------------------------------------------
                Do Until ReadEdi = ">RHOXX ROT=RHOROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
LineRHOXXROTRHOROT:
                staRHOXX = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            RHOxxR(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '----------------------------------------------------------------------------
                i = 0
                'read RhoxxE---------------------------------------------------------------------
                Do Until ReadEdi = ">RHOXX.ERR ROT=RHOROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staRHOXXERR = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            RHOxxE(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '----------------------------------------------------------------------------
                i = 0
                'read RhoyyR---------------------------------------------------------------------
                Do Until ReadEdi = ">RHOYY ROT=RHOROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staRHOYY = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            RHOyyR(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '----------------------------------------------------------------------------
                i = 0
                'read RhoyyE--------------------------------------------------------------------
                Do Until ReadEdi = ">RHOYY.ERR ROT=RHOROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staRHOYYERR = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            RHOyyE(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '----------------------------------------------------------------------------
                i = 0
                'read PhaxyR---------------------------------------------------------------------
                Do Until ReadEdi = ">PHSXY ROT=RHOROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staPHSXY = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            PHAxyR(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '----------------------------------------------------------------------------
                i = 0
                'read PhaxyE---------------------------------------------------------------------
                Do Until ReadEdi = ">PHSXY.ERR ROT=RHOROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staPHSXYERR = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            PHAxyE(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '----------------------------------------------------------------------------
                i = 0
                'read PHAxyF------------------------------------------------------------------
                Do Until ReadEdi = ">PHSXY.FIT ROT=RHOROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                    If ReadEdi = (">PHSYX ROT=RHOROT //" & nFreq) Then
                        GoTo LinePHSYXROTRHOROT
                    End If
                Loop
                staPHSXYFIT = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            PHAxyF(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '----------------------------------------------------------------------------
                i = 0
                'read PhayxR---------------------------------------------------------------------
                Do Until ReadEdi = ">PHSYX ROT=RHOROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
LinePHSYXROTRHOROT:
                staPHSYX = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            PHAyxR(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '----------------------------------------------------------------------------
                i = 0
                'read PhayxE---------------------------------------------------------------------
                Do Until ReadEdi = ">PHSYX.ERR ROT=RHOROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staPHSYXERR = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            PHAyxE(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '--------------------------------------------------------------------------
                i = 0
                'read PHAyxF------------------------------------------------------------------
                Do Until ReadEdi = ">PHSYX.FIT ROT=RHOROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                    If ReadEdi = (">PHSXX ROT=RHOROT //" & nFreq) Then
                        GoTo LinePHSXXROTRHOROT
                    End If
                Loop
                staPHSYXFIT = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            PHAyxF(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '---------------------------------------------------------------------------
                i = 0
                'read PhaxxR---------------------------------------------------------------------
                Do Until ReadEdi = ">PHSXX ROT=RHOROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
LinePHSXXROTRHOROT:
                staPHSXX = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            PHAxxR(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '----------------------------------------------------------------------------
                i = 0
                'read PhaxxE---------------------------------------------------------------------
                Do Until ReadEdi = ">PHSXX.ERR ROT=RHOROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staPHSXXERR = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            PHAxxE(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '--------------------------------------------------------------------------
                i = 0
                'read PhayyR---------------------------------------------------------------------
                Do Until ReadEdi = ">PHSYY ROT=RHOROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staPHSYY = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            PHAyyR(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '----------------------------------------------------------------------------
                i = 0
                'read PhayyE---------------------------------------------------------------------
                Do Until ReadEdi = ">PHSYY.ERR ROT=RHOROT //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staPHSYYERR = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            PHAyyE(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '--------------------------------------------------------------------------
                i = 0
                'read Trot---------------------------------------------------------------------
                Do Until ReadEdi = ">TROT.EXP //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staTROTEXP = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            Trot(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '--------------------------------------------------------------------------
                i = 0
                'read TxR---------------------------------------------------------------------
                Do Until ReadEdi = ">TXR.EXP //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staTXREXP = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            TxR(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '--------------------------------------------------------------------------
                i = 0
                'read TxI---------------------------------------------------------------------
                Do Until ReadEdi = ">TXI.EXP //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staTXIEXP = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            TxI(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '--------------------------------------------------------------------------
                i = 0
                'read TxV---------------------------------------------------------------------
                Do Until ReadEdi = ">TXVAR.EXP //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staTXVAREXP = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            TxV(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '--------------------------------------------------------------------------
                i = 0
                'read TyR---------------------------------------------------------------------
                Do Until ReadEdi = ">TYR.EXP //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staTYREXP = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            TyR(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '--------------------------------------------------------------------------
                i = 0
                'read TyI---------------------------------------------------------------------
                Do Until ReadEdi = ">TYI.EXP //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staTYIEXP = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            TyI(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '--------------------------------------------------------------------------
                i = 0
                'read TyV---------------------------------------------------------------------
                Do Until ReadEdi = ">TYVAR.EXP //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staTYVAREXP = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            TyV(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '------------------------------------------------------------------------
                i = 0
                'read TipM---------------------------------------------------------------------
                Do Until ReadEdi = ">TIPMAG //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staTIPMAG = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            TipM(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '------------------------------------------------------------------------
                i = 0
                'read TipMV---------------------------------------------------------------------
                Do Until ReadEdi = ">TIPMAG.VAR //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staTIPMAGVAR = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            TipMV(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '------------------------------------------------------------------------
                i = 0
                'read TipP---------------------------------------------------------------------
                Do Until ReadEdi = ">TIPPHS //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staTIPPHS = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            TipP(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '------------------------------------------------------------------------
                i = 0
                'read Zstrike---------------------------------------------------------------------
                Do Until ReadEdi = ">ZSTRIKE //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staZSTRIKE = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            Zstrike(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '------------------------------------------------------------------------
                i = 0
                'read Zskew---------------------------------------------------------------------
                Do Until ReadEdi = ">ZSKEW //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staZSKEW = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            Zskew(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '------------------------------------------------------------------------
                i = 0
                'read Zellip---------------------------------------------------------------------
                Do Until ReadEdi = ">ZELLIP //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staZELLIP = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            Zellip(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '------------------------------------------------------------------------
                i = 0
                'read Tstrike---------------------------------------------------------------------
                Do Until ReadEdi = ">TSTRIKE //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staTSTRIKE = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            Tstrike(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '------------------------------------------------------------------------
                i = 0
                'read Tskew---------------------------------------------------------------------
                Do Until ReadEdi = ">TSKEW //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staTSKEW = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            Tskew(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '------------------------------------------------------------------------
                i = 0
                'read Tellip---------------------------------------------------------------------
                Do Until ReadEdi = ">TELLIP //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staTELLIP = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            Tellip(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '-----------------------------------------------------------------------
                i = 0
                'read IndMagR---------------------------------------------------------------------
                Do Until ReadEdi = ">INDMAGR.EXP NFREQ=" & nFreq & " //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staINDMAGREXP = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            IndMagR(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '-----------------------------------------------------------------------
                i = 0
                'read IndMagI---------------------------------------------------------------------
                Do Until ReadEdi = ">INDMAGI.EXP NFREQ=" & nFreq & " //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staINDMAGIEXP = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            IndMagI(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '-----------------------------------------------------------------------
                i = 0
                'read IndAngR---------------------------------------------------------------------
                Do Until ReadEdi = ">INDANGR.EXP NFREQ=" & nFreq & " //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staINDANGREXP = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            IndAngR(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '-----------------------------------------------------------------------
                i = 0
                'read IndAngI---------------------------------------------------------------------
                Do Until ReadEdi = ">INDANGI.EXP NFREQ=" & nFreq & " //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                staINDANGIEXP = True
                For k = 1 To nloop
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 0 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            IndAngI(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '----------------------------------------------------------------------
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            '---------------------------------------------------------------------

            strReadEdi = Nothing
        End Using

        OpenFileName = Nothing
        i = Nothing
        ReadEdi = Nothing
        rNfreq = Nothing
        nloop = Nothing

        For i = 1 To nFreq
            tableALL.Rows.Add(i, 1 / Freq(i), Zrot(i), _
                              ZxxR(i), ZxxI(i), ZxxV(i), _
                              ZxyR(i), ZxyI(i), Zxyv(i), _
                              ZyxR(i), ZyxI(i), Zyxv(i), _
                              ZyyR(i), ZyyI(i), Zyyv(i), _
                              RHOR(i), _
                              RHOxyR(i), RHOxyE(i), RHOxyF(i), _
                              RHOyxR(i), RHOyxE(i), RHOyxF(i), _
                              RHOxxR(i), RHOxxE(i), _
                              RHOyyR(i), RHOyyE(i), _
                              PHAxyR(i), PHAxyE(i), PHAxyF(i), _
                              PHAyxR(i), PHAyxE(i), PHAyxF(i), _
                              PHAxxR(i), PHAxxE(i), _
                              PHAyyR(i), PHAyyE(i), _
                              Trot(i), _
                              TxR(i), TxI(i), TxV(i), _
                              TyR(i), TyI(i), TyV(i), _
                              TipM(i), TipMV(i), TipP(i), _
                              Zstrike(i), Zskew(i), Zellip(i), _
                              Tstrike(i), Tskew(i), Tellip(i), _
                              IndMagR(i), IndMagI(i), _
                              IndAngR(i), IndAngI(i))

            tableORI.Rows.Add(i, 1 / Freq(i), Zrot(i), _
                              ZxxR(i), ZxxI(i), ZxxV(i), _
                              ZxyR(i), ZxyI(i), Zxyv(i), _
                              ZyxR(i), ZyxI(i), Zyxv(i), _
                              ZyyR(i), ZyyI(i), Zyyv(i), _
                              RHOR(i), _
                              RHOxyR(i), RHOxyE(i), RHOxyF(i), _
                              RHOyxR(i), RHOyxE(i), RHOyxF(i), _
                              RHOxxR(i), RHOxxE(i), _
                              RHOyyR(i), RHOyyE(i), _
                              PHAxyR(i), PHAxyE(i), PHAxyF(i), _
                              PHAyxR(i), PHAyxE(i), PHAyxF(i), _
                              PHAxxR(i), PHAxxE(i), _
                              PHAyyR(i), PHAyyE(i), _
                              Trot(i), _
                              TxR(i), TxI(i), TxV(i), _
                              TyR(i), TyI(i), TyV(i), _
                              TipM(i), TipMV(i), TipP(i), _
                              Zstrike(i), Zskew(i), Zellip(i), _
                              Tstrike(i), Tskew(i), Tellip(i), _
                              IndMagR(i), IndMagI(i), _
                              IndAngR(i), IndAngI(i))
        Next
        DataWindow.DataGridViewAllData.DataSource = tableALL
        '---------------------------------------------------------------------------
        dataExist = True
        Call CalcXX(ZxxR, ZxxI, Freq, nFreq)
        Call CalcXY(ZxyR, ZxyI, Freq, nFreq, RHOxyF, PHAxyF)
        Call CalcYX(ZyxR, ZyxI, Freq, nFreq, RHOyxF, PHAyxF)
        Call CalcYY(ZyyR, ZyyI, Freq, nFreq)
        Call CalcTxZ(TxR, TxI, Freq, nFreq)
        Call CalcTyZ(TyR, TyI, Freq, nFreq)

        OpenToolStripMenuItem.Enabled = False
        CloseToolStripMenuItem.Enabled = True
        SaveToolStripMenuItem.Enabled = True
        ExitToolStripMenuItem.Enabled = True

        DataToolStripMenuItem.Enabled = True
        StaticShiftToolStripMenuItem.Enabled = True
        ScaleSettingToolStripMenuItem.Enabled = True

        Return 0
    End Function

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutForm.Show()
    End Sub

End Class
