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



Public Class Form1
    Public intFreq As Integer = 100
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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim openFileDialog1 As New OpenFileDialog()
        Dim i As Integer
        Dim ReadEdi As String
        Dim rNfreq() As String
        Dim nFreq As Integer

        openFileDialog1.InitialDirectory = "C:\data\"
        openFileDialog1.Filter = "EDI files (*.edi)|*.edi"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Using EdiFile As StreamReader = My.Computer.FileSystem.OpenTextFileReader(openFileDialog1.FileName)
                Dim strReadEdi() As String

                'read number of frequency---------------------------------------------------------
                ReadEdi = EdiFile.ReadLine()
                Do Until ReadEdi = ">=MTSECT"
                    ReadEdi = EdiFile.ReadLine()
                Loop

                ReadEdi = EdiFile.ReadLine()
                ReadEdi = EdiFile.ReadLine()
                rNfreq = ReadEdi.Split("=")
                nFreq = rNfreq(1)
                '--------------------------------------------------------------------------------
                i = 0
                'read frequency------------------------------------------------------------------
                Do Until ReadEdi = ">FREQ //" & nFreq
                    ReadEdi = EdiFile.ReadLine()
                Loop
                For k = 1 To ((nFreq / 6) + 1)
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 1 To UBound(strReadEdi)
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
                For k = 1 To ((nFreq / 6) + 1)
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 1 To UBound(strReadEdi)
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
                For k = 1 To ((nFreq / 6) + 1)
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 1 To UBound(strReadEdi)
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
                For k = 1 To ((nFreq / 6) + 1)
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 1 To UBound(strReadEdi)
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
                For k = 1 To ((nFreq / 6) + 1)
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 1 To UBound(strReadEdi)
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
                For k = 1 To ((nFreq / 6) + 1)
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 1 To UBound(strReadEdi)
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
                For k = 1 To ((nFreq / 6) + 1)
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 1 To UBound(strReadEdi)
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
                For k = 1 To ((nFreq / 6) + 1)
                    ReadEdi = EdiFile.ReadLine()
                    strReadEdi = ReadEdi.Split(" ")
                    For j = 1 To UBound(strReadEdi)
                        If strReadEdi(j) <> "" Then
                            i += 1
                            Zxyv(i) = strReadEdi(j)
                        End If
                    Next j
                Next k
                '-----------------------------------------------------------------------------

                ListBox1.Items.Add(Freq(i) & vbTab & Zrot(i) & vbTab & ZxxR(i) & vbTab & ZxxI(i) & vbTab & ZxxV(i) & vbTab & ZxyR(i) & vbTab & ZxyI(i) & vbTab & Zxyv(i))
            End Using
        End If
    End Sub
End Class
