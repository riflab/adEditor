Imports adEDItor.MainWindow
Imports System.Math


Module Calculate
    Dim RhoXX(intFreq) As Double
    Dim RhoXY(intFreq) As Double
    Dim RhoYX(intFreq) As Double
    Dim RhoYY(intFreq) As Double

    Dim PhaXX(intFreq) As Double
    Dim PhaXY(intFreq) As Double
    Dim PhaYX(intFreq) As Double
    Dim PhaYY(intFreq) As Double

    Dim linZxxI(intFreq) As Double
    Dim linZxxR(intFreq) As Double
    Dim linZxyI(intFreq) As Double
    Dim linZxyR(intFreq) As Double
    Dim linZyxI(intFreq) As Double
    Dim linZyxR(intFreq) As Double
    Dim linZyyI(intFreq) As Double
    Dim linZyyR(intFreq) As Double
    Dim RHO As Double
    Dim PHA As Double

    Function CalcXX(ByVal ZxxR() As Double, ByVal ZxxI() As Double, ByVal Freq() As Double, ByVal nFreq As Integer) As Double
        Dim i As Integer
        For i = 1 To nFreq
            tableZXX.Rows.Add(i, 1 / Freq(i), ZxxI(i), ZxxR(i))
        Next
        DataWindow.DataGridViewZxx.DataSource = tableZXX
        Return 0
    End Function

    Function CalcXY(ByVal ZxyR() As Double, ByVal ZxyI() As Double, ByVal Freq() As Double, ByVal nFreq As Integer, ByVal RHOxyF() As Double, ByVal PHAxyF() As Double) As Double
        Dim i As Integer
        For i = 1 To nFreq
            linZxyI(i) = Log10(Abs(ZxyI(i)))
            linZxyR(i) = Log10(Abs(ZxyR(i)))
            tableZXY.Rows.Add(i, 1 / Freq(i), linZxyI(i), linZxyR(i), RHOxyF(i), PHAxyF(i))
        Next
        DataWindow.DataGridViewZxy.DataSource = tableZXY
        Return 0
    End Function

    Function CalcYX(ByVal ZyxR() As Double, ByVal ZyxI() As Double, ByVal Freq() As Double, ByVal nFreq As Integer, ByVal RHOyxF() As Double, ByVal PHAyxF() As Double) As Double
        Dim i As Integer
        For i = 1 To nFreq
            linZyxI(i) = Log10(Abs(ZyxI(i)))
            linZyxR(i) = Log10(Abs(ZyxR(i)))
            tableZYX.Rows.Add(i, 1 / Freq(i), linZyxI(i), linZyxR(i), RHOyxF(i), PHAyxF(i))
        Next
        DataWindow.DataGridViewZyx.DataSource = tableZYX
        Return 0
    End Function

    Function CalcYY(ByVal ZyyR() As Double, ByVal ZyyI() As Double, ByVal Freq() As Double, ByVal nFreq As Integer) As Double
        Dim i As Integer
        For i = 1 To nFreq
            tableZYY.Rows.Add(i, 1 / Freq(i), ZyyI(i), ZyyR(i))
        Next
        DataWindow.DataGridViewZyy.DataSource = tableZYY
        Return 0
    End Function

    Function CalcTxZ(ByVal TxR() As Double, ByVal TxI() As Double, ByVal Freq() As Double, ByVal nFreq As Integer) As Double
        For i = 1 To nFreq
            tableTxZ.Rows.Add(i, 1 / Freq(i), TxR(i), TxI(i))
        Next
        DataWindow.DataGridViewTxZ.DataSource = tableTxZ
        Return 0
    End Function

    Function CalcTyZ(ByVal TyR() As Double, ByVal TyI() As Double, ByVal Freq() As Double, ByVal nFreq As Integer) As Double
        For i = 1 To nFreq
            tableTyZ.Rows.Add(i, 1 / Freq(i), TyR(i), TyI(i))
        Next
        DataWindow.DataGridViewTyZ.DataSource = tableTyZ
        Return 0
    End Function

    Function CalcRHO(ByVal Freq As Double, ByVal Zimag As Double, ByVal Zreal As Double) As Double
        RHO = (1 / (2 * PI * PI * 0.25 * Freq)) * (Zimag ^ 2 + Zreal ^ 2)
        Return RHO
    End Function

    Function CalcPHA(ByVal Zimag As Double, ByVal Zreal As Double) As Double
        PHA = (Atan(Zimag / Zreal)) / PI * 180
        Return PHA
    End Function

    Function reCalcXX()
        tableRhoPhaXX.Clear()

        Dim a(intFreq) As Double
        Dim b(intFreq) As Double
        Dim c(intFreq) As Double
        Dim f As Double

        Dim i As Integer

        For Each row As DataRow In tableZXX.Rows
            i += 1
            a(i) = (row(">ZXXI ROT=ZROT"))
            b(i) = (row(">ZXXR ROT=ZROT"))
            c(i) = 1 / row(">PERIODE")
            RhoXX(i) = CalcRHO(c(i), a(i), b(i))
            f = CalcPHA(a(i), b(i))
            If f > 0 Then
                PhaXX(i) = CalcPHA(a(i), b(i)) - 180
            Else
                PhaXX(i) = CalcPHA(a(i), b(i)) + 180
            End If

            tableRhoPhaXX.Rows.Add(i, 1 / c(i), RhoXX(i), PhaXX(i))

        Next row
        DataWindow.DataGridViewRhoPhaXX.DataSource = tableRhoPhaXX

        Return 0
    End Function

    Function reCalcXY()

        tableRhoPhaXY.Clear()

        Dim a(intFreq) As Double
        Dim b(intFreq) As Double
        Dim c(intFreq) As Double
        Dim d(intFreq) As Double
        Dim e(intFreq) As Double

        Dim i As Integer

        For Each row As DataRow In tableZXY.Rows
            i += 1
            a(i) = 10 ^ row("log(>ZXYI ROT=ZROT)")
            b(i) = 10 ^ row("log(>ZXYR ROT=ZROT)")
            c(i) = 1 / row(">PERIODE")
            d(i) = row(">RHOXY.FIT ROT=RHOROT")
            e(i) = row(">PHSXY.FIT ROT=RHOROT")

            RhoYX(i) = CalcRHO(c(i), a(i), b(i))
            PhaYX(i) = CalcPHA(a(i), b(i))

            tableRhoPhaXY.Rows.Add(i, 1 / c(i), RhoYX(i), PhaYX(i), d(i), e(i))

        Next row
        DataWindow.DataGridViewRhoPhaXY.DataSource = tableRhoPhaXY

        Return 0
    End Function

    Function reCalcYX()

        tableRhoPhaYX.Clear()

        Dim a(intFreq) As Double
        Dim b(intFreq) As Double
        Dim c(intFreq) As Double
        Dim d(intFreq) As Double
        Dim e(intFreq) As Double

        Dim i As Integer

        For Each row As DataRow In tableZYX.Rows
            i += 1
            a(i) = 10 ^ row("log(>ZYXI ROT=ZROT)")
            b(i) = 10 ^ row("log(>ZYXR ROT=ZROT)")
            c(i) = 1 / row(">PERIODE")
            d(i) = row(">RHOYX.FIT ROT=RHOROT")
            E(i) = row(">PHSYX.FIT ROT=RHOROT")

            RhoYX(i) = CalcRHO(c(i), a(i), b(i))
            PhaYX(i) = CalcPHA(a(i), b(i)) - 180

            tableRhoPhaYX.Rows.Add(i, 1 / c(i), RhoYX(i), PhaYX(i), d(i), e(i))

        Next row
        DataWindow.DataGridViewRhoPhaYX.DataSource = tableRhoPhaYX

        Return 0
    End Function

    Function reCalcYY()

        tableRhoPhaYY.Clear()

        Dim a(intFreq) As Double
        Dim b(intFreq) As Double
        Dim c(intFreq) As Double
        Dim f As Double
        Dim i As Integer

        For Each row As DataRow In tableZYY.Rows
            i += 1
            a(i) = row(">ZYYI ROT=ZROT")
            b(i) = row(">ZYYR ROT=ZROT")
            c(i) = 1 / row(">PERIODE")

            RhoYY(i) = CalcRHO(c(i), a(i), b(i))
            f = CalcPHA(a(i), b(i))
            If f > 0 Then
                PhaYY(i) = CalcPHA(a(i), b(i)) - 180
            Else
                PhaYY(i) = CalcPHA(a(i), b(i)) + 180
            End If

            tableRhoPhaYY.Rows.Add(i, 1 / c(i), RhoYY(i), PhaYY(i))

        Next row
        DataWindow.DataGridViewRhoPhaYY.DataSource = tableRhoPhaYY

        Return 0

    End Function

    Function CalStaticZxy(ByVal SSVal As Double)

        Dim i As Integer = 0
        Dim a As Double

        a = Sqrt(SSVal)
        For Each row As DataRow In tableORI.Rows
            i += 1

            tableALL.Rows(i - 1)(">ZXYI ROT=ZROT") = Abs(row(">ZXYI ROT=ZROT") * a)
            tableALL.Rows(i - 1)(">ZXYR ROT=ZROT") = Abs(row(">ZXYR ROT=ZROT") * a)

            tableZXY.Rows(i - 1)("log(>ZXYI ROT=ZROT)") = Log10(Abs(row(">ZXYI ROT=ZROT") * a))
            tableZXY.Rows(i - 1)("log(>ZXYR ROT=ZROT)") = Log10(Abs(row(">ZXYR ROT=ZROT") * a))

            Dim fr As Double = 1 / Abs(row(">PERIODE"))
            Dim im As Double = Abs(row(">ZXYI ROT=ZROT") * a)
            Dim re As Double = Abs(row(">ZXYR ROT=ZROT") * a)

            tableALL.Rows(i - 1)(">RHOXY ROT=RHOROT") = CalcRHO(fr, im, re)
            tableALL.Rows(i - 1)(">PHSXY ROT=RHOROT") = CalcPHA(im, re) - 180

            tableRhoPhaXY.Rows(i - 1)("RhoXY") = CalcRHO(fr, im, re)
            tableRhoPhaXY.Rows(i - 1)("PhaXY") = CalcPHA(im, re)
        Next row

        DataWindow.DataGridViewRhoPhaXY.DataSource = tableRhoPhaXY
        DataWindow.DataGridViewAllData.DataSource = tableALL
        DataWindow.DataGridViewZxy.DataSource = tableZXY

        StaticShiftWindow.TextBox4.Text = tableRhoPhaXY.Rows(0)("Rhoxy")

        Call dBindZXY()
        Call dBindDash()
        Return 0
    End Function

    Function CalStaticZyx(ByVal SSVal As Double)

        Dim i As Integer = 0
        Dim a As Double

        a = Sqrt(SSVal)
        For Each row As DataRow In tableORI.Rows
            i += 1

            tableALL.Rows(i - 1)(">ZyxI ROT=ZROT") = -Abs(row(">ZyxI ROT=ZROT") * a)
            tableALL.Rows(i - 1)(">ZyxR ROT=ZROT") = -Abs(row(">ZyxR ROT=ZROT") * a)

            tableZYX.Rows(i - 1)("log(>ZyxI ROT=ZROT)") = Log10(Abs(row(">ZyxI ROT=ZROT") * a))
            tableZYX.Rows(i - 1)("log(>ZyxR ROT=ZROT)") = Log10(Abs(row(">ZyxR ROT=ZROT") * a))

            Dim fr As Double = 1 / Abs(row(">PERIODE"))
            Dim im As Double = Abs(row(">ZyxI ROT=ZROT") * a)
            Dim re As Double = Abs(row(">ZyxR ROT=ZROT") * a)

            tableALL.Rows(i - 1)(">RHOYX ROT=RHOROT") = CalcRHO(fr, im, re)
            tableALL.Rows(i - 1)(">PHSYX ROT=RHOROT") = CalcPHA(im, re) - 180

            tableRhoPhaYX.Rows(i - 1)("Rhoyx") = CalcRHO(fr, im, re)
            tableRhoPhaYX.Rows(i - 1)("Phayx") = CalcPHA(im, re) - 180
        Next row

        DataWindow.DataGridViewRhoPhaYX.DataSource = tableRhoPhaYX
        DataWindow.DataGridViewAllData.DataSource = tableALL
        DataWindow.DataGridViewZyx.DataSource = tableZYX

        StaticShiftWindow.TextBox3.Text = tableRhoPhaYX.Rows(0)("Rhoyx")

        Call dBindZYX()
        Call dBindDash()

        Return 0
    End Function

End Module
