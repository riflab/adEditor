Imports adEDItor.MainWindow

Public Class ScaleSettingWindow

    Dim staScaleSetting As Boolean = False

    Private Sub ScaleSettingWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True

        TextBoxMinPerXX.Text = minPerZxx
        TextBoxMaxPerXX.Text = maxPerZxx
        TextBoxMinRhoXX.Text = minRhoZxx
        TextBoxMaxRhoXX.Text = maxRhoZxx
        TextBoxMinPhaXX.Text = minPhaZxx
        TextBoxMaxPhaXX.Text = maxPhaZxx
        TextBoxMinZxx.Text = minZZxx
        TextBoxMaxZxx.Text = maxZZxx

        TextBoxMinPerXY.Text = minPerZxy
        TextBoxMaxPerXY.Text = maxPerZxy
        TextBoxMinRhoXY.Text = minRhoZxy
        TextBoxMaxRhoXY.Text = maxRhoZxy
        TextBoxMinPhaXY.Text = minPhaZxy
        TextBoxMaxPhaXY.Text = maxPhaZxy
        TextBoxMinZxy.Text = minZZxy
        TextBoxMaxZxy.Text = maxZZxy

        TextBoxMinPerYX.Text = minPerZyx
        TextBoxMaxPerYX.Text = maxPerZyx
        TextBoxMinRhoYX.Text = minRhoZyx
        TextBoxMaxRhoYX.Text = maxRhoZyx
        TextBoxMinPhaYX.Text = minPhaZyx
        TextBoxMaxPhaYX.Text = maxPhaZyx
        TextBoxMinZyx.Text = minZZyx
        TextBoxMaxZyx.Text = maxZZyx

        TextBoxMinPerYY.Text = minPerZyy
        TextBoxMaxPerYY.Text = maxPerZyy
        TextBoxMinRhoYY.Text = minRhoZyy
        TextBoxMaxRhoYY.Text = maxRhoZyy
        TextBoxMinPhaYY.Text = minPhaZyy
        TextBoxMaxPhaYY.Text = maxPhaZyy
        TextBoxMinZyy.Text = minZZyy
        TextBoxMaxZyy.Text = maxZZyy

        TextBoxMinPerXZ.Text = minPerTxz
        TextBoxMaxPerXZ.Text = maxPerTxz
        TextBoxMinTxz.Text = minTxz
        TextBoxMaxTxz.Text = maxTxz

        TextBoxMinPerYZ.Text = minPerTyz
        TextBoxMaxPerYZ.Text = maxPerTyz
        TextBoxMinTyz.Text = minTyz
        TextBoxMaxTyz.Text = maxTyz

        staScaleSetting = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call plot()
        staScaleSetting = False
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        staScaleSetting = False
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call plot()
    End Sub

    Function plot()
        minPerZxx = TextBoxMinPerXX.Text
        maxPerZxx = TextBoxMaxPerXX.Text
        minRhoZxx = TextBoxMinRhoXX.Text
        maxRhoZxx = TextBoxMaxRhoXX.Text
        minPhaZxx = TextBoxMinPhaXX.Text
        maxPhaZxx = TextBoxMaxPhaXX.Text
        minZZxx = TextBoxMinZxx.Text
        maxZZxx = TextBoxMaxZxx.Text

        minPerZxy = TextBoxMinPerXY.Text
        maxPerZxy = TextBoxMaxPerXY.Text
        minRhoZxy = TextBoxMinRhoXY.Text
        maxRhoZxy = TextBoxMaxRhoXY.Text
        minPhaZxy = TextBoxMinPhaXY.Text
        maxPhaZxy = TextBoxMaxPhaXY.Text
        minZZxy = TextBoxMinZxy.Text
        maxZZxy = TextBoxMaxZxy.Text

        minPerZyx = TextBoxMinPerYX.Text
        maxPerZyx = TextBoxMaxPerYX.Text
        minRhoZyx = TextBoxMinRhoYX.Text
        maxRhoZyx = TextBoxMaxRhoYX.Text
        minPhaZyx = TextBoxMinPhaYX.Text
        maxPhaZyx = TextBoxMaxPhaYX.Text
        minZZyx = TextBoxMinZyx.Text
        maxZZyx = TextBoxMaxZyx.Text

        minPerZyy = TextBoxMinPerYY.Text
        maxPerZyy = TextBoxMaxPerYY.Text
        minRhoZyy = TextBoxMinRhoYY.Text
        maxRhoZyy = TextBoxMaxRhoYY.Text
        minPhaZyy = TextBoxMinPhaYY.Text
        maxPhaZyy = TextBoxMaxPhaYY.Text
        minZZyy = TextBoxMinZyy.Text
        maxZZyy = TextBoxMaxZyy.Text

        minPerTxz = TextBoxMinPerXZ.Text
        maxPerTxz = TextBoxMaxPerXZ.Text
        minTxz = TextBoxMinTxz.Text
        maxTxz = TextBoxMaxTxz.Text

        minPerTyz = TextBoxMinPerYZ.Text
        maxPerTyz = TextBoxMaxPerYZ.Text
        minTyz = TextBoxMinTyz.Text
        maxTyz = TextBoxMaxTyz.Text

        Call loadZxx(minPerZxx, maxPerZxx, minRhoZxx, maxRhoZxx, minPhaZxx, maxPhaZxx, minZZxx, maxZZxx)
        Call loadZxy(minPerZxy, maxPerZxy, minRhoZxy, maxRhoZxy, minPhaZxy, maxPhaZxy, minZZxy, maxZZxy)
        Call loadZyx(minPerZyx, maxPerZyx, minRhoZyx, maxRhoZyx, minPhaZyx, maxPhaZyx, minZZyx, maxZZyx)
        Call loadZyy(minPerZyy, maxPerZyy, minRhoZyy, maxRhoZyy, minPhaZyy, maxPhaZyy, minZZyy, maxZZyy)
        Call loadTxZ(minPerTxz, maxPerTxz, minTxz, maxTxz)
        Call loadTyZ(minPerTyz, maxPerTyz, minTyz, maxTyz)


        Return 0
    End Function

    'Private Sub TextBoxMinPerXX_TextChanged(sender As Object, e As EventArgs) Handles TextBoxMinPerXX.TextChanged
    '    If staScaleSetting = True Then
    '        If IsNumeric(TextBoxMinPerXX.Text) And (TextBoxMinPerXX.Text < TextBoxMaxPerXX.Text) And (TextBoxMinPerXX.Text > 0) And (TextBoxMaxPerXX.Text > 0) Then
    '            TextBoxMinPerXX.BackColor = SystemColors.Window
    '            TextBoxMaxPerXX.BackColor = SystemColors.Window
    '            Button1.Enabled = True
    '            Button3.Enabled = True
    '        Else
    '            TextBoxMinPerXX.BackColor = Color.LightPink
    '            Button1.Enabled = False
    '            Button3.Enabled = False
    '        End If
    '    End If
    'End Sub

    'Private Sub TextBoxMaxPerXX_TextChanged(sender As Object, e As EventArgs) Handles TextBoxMaxPerXX.TextChanged
    '    If staScaleSetting = True Then
    '        If IsNumeric(TextBoxMaxPerXX.Text) And (TextBoxMinPerXX.Text < TextBoxMaxPerXX.Text) And (TextBoxMinPerXX.Text > 0) And (TextBoxMaxPerXX.Text > 0) Then
    '            TextBoxMinPerXX.BackColor = SystemColors.Window
    '            TextBoxMaxPerXX.BackColor = SystemColors.Window
    '            Button1.Enabled = True
    '            Button3.Enabled = True
    '        Else
    '            TextBoxMaxPerXX.BackColor = Color.LightPink
    '            Button1.Enabled = False
    '            Button3.Enabled = False
    '        End If
    '    End If
    'End Sub

    'Private Sub TextBoxMinRhoXX_TextChanged(sender As Object, e As EventArgs) Handles TextBoxMinRhoXX.TextChanged
    '    If staScaleSetting = True Then
    '        If IsNumeric(TextBoxMinRhoXX.Text) And (TextBoxMinRhoXX.Text < TextBoxMaxRhoXX.Text) And (TextBoxMinRhoXX.Text > 0) And (TextBoxMaxRhoXX.Text > 0) Then
    '            TextBoxMinRhoXX.BackColor = SystemColors.Window
    '            TextBoxMaxRhoXX.BackColor = SystemColors.Window
    '            Button1.Enabled = True
    '            Button3.Enabled = True
    '        Else
    '            TextBoxMinRhoXX.BackColor = Color.LightPink
    '            Button1.Enabled = False
    '            Button3.Enabled = False
    '        End If
    '    End If
    'End Sub

    'Private Sub TextBoxMaxRhoXX_TextChanged(sender As Object, e As EventArgs) Handles TextBoxMaxRhoXX.TextChanged
    '    If staScaleSetting = True Then
    '        If IsNumeric(TextBoxMaxRhoXX.Text) And (TextBoxMinRhoXX.Text < TextBoxMaxRhoXX.Text) And (TextBoxMinRhoXX.Text > 0) And (TextBoxMaxRhoXX.Text > 0) Then
    '            TextBoxMinRhoXX.BackColor = SystemColors.Window
    '            TextBoxMaxRhoXX.BackColor = SystemColors.Window
    '            Button1.Enabled = True
    '            Button3.Enabled = True
    '        Else
    '            TextBoxMaxRhoXX.BackColor = Color.LightPink
    '            Button1.Enabled = False
    '            Button3.Enabled = False
    '        End If
    '    End If
    'End Sub

    'Private Sub TextBoxMinPhaXX_TextChanged(sender As Object, e As EventArgs) Handles TextBoxMinPhaXX.TextChanged
    '    If staScaleSetting = True Then
    '        If IsNumeric(TextBoxMinPhaXX.Text) And (TextBoxMinPhaXX.Text < TextBoxMaxPhaXX.Text) And (TextBoxMinPhaXX.Text < 0) And (TextBoxMaxPhaXX.Text >= 0) Then
    '            MessageBox.Show(TextBoxMinPhaXX.Text & vbTab & TextBoxMaxPhaXX.Text)
    '            TextBoxMinPhaXX.BackColor = SystemColors.Window
    '            TextBoxMaxPhaXX.BackColor = SystemColors.Window
    '            Button1.Enabled = True
    '            Button3.Enabled = True
    '        Else
    '            TextBoxMinPhaXX.BackColor = Color.LightPink
    '            Button1.Enabled = False
    '            Button3.Enabled = False
    '        End If
    '    End If
    'End Sub

    'Private Sub TextBoxMaxPhaXX_TextChanged(sender As Object, e As EventArgs) Handles TextBoxMaxPhaXX.TextChanged
    '    If staScaleSetting = True Then
    '        If IsNumeric(TextBoxMaxPhaXX.Text) And (TextBoxMinPhaXX.Text < TextBoxMaxPhaXX.Text) And (TextBoxMinPhaXX.Text < 0) And (TextBoxMaxPhaXX.Text >= 0) Then
    '            MessageBox.Show(TextBoxMinPhaXX.Text & vbTab & TextBoxMaxPhaXX.Text)
    '            TextBoxMinPhaXX.BackColor = SystemColors.Window
    '            TextBoxMaxPhaXX.BackColor = SystemColors.Window
    '            Button1.Enabled = True
    '            Button3.Enabled = True
    '        Else
    '            TextBoxMaxPhaXX.BackColor = Color.LightPink
    '            Button1.Enabled = False
    '            Button3.Enabled = False
    '        End If
    '    End If
    'End Sub

End Class