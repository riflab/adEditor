Imports adEDItor.MainWindow

Public Class StaticShiftWindow

    Dim status As Boolean = False

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        SSxy = NumericUpDown1.Value
        SSyx = NumericUpDown2.Value

        Call CalStaticZxy(SSxy)
        Call CalStaticZyx(SSyx)

        Me.Close()
    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    Private Sub StaticShiftWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
        TextBox8.Enabled = False

        NumericUpDown1.Enabled = True
        NumericUpDown1.Enabled = True
        NumericUpDown3.Enabled = False
        NumericUpDown4.Enabled = False

        NumericUpDown1.Value = SSxy
        NumericUpDown2.Value = SSyx

        TextBox1.Text = tableRhoPhaXY.Rows(0)("Rhoxy")
        TextBox2.Text = tableRhoPhaYX.Rows(0)("Rhoyx")
        TextBox3.Text = tableRhoPhaYX.Rows(0)("Rhoyx")
        TextBox4.Text = tableRhoPhaXY.Rows(0)("Rhoxy")

        Me.TopMost = True
        status = True
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If status = True Then
            SSxy = NumericUpDown1.Value
            Call CalStaticZxy(SSxy)
        End If
    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        If status = True Then
            SSyx = NumericUpDown2.Value
            Call CalStaticZyx(SSyx)
        End If
    End Sub

    Private Sub ButtonApply_Click(sender As Object, e As EventArgs) Handles ButtonApply.Click
        SSxy = NumericUpDown1.Value
        SSyx = NumericUpDown2.Value

        Call CalStaticZxy(SSxy)
        Call CalStaticZyx(SSyx)
    End Sub
End Class