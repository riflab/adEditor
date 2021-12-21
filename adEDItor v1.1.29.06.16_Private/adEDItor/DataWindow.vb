Imports adEDItor.MainWindow

Public Class DataWindow

    Private Sub DataGridViewAllData_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridViewAllData.RowsAdded
        Call dBindDash()
    End Sub

    Private Sub DataGridViewZxx_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridViewZxx.RowsAdded
        If dataExist = True Then
            Call reCalcXX()
            Call dBindZXX()
        End If
    End Sub

    Private Sub DataGridViewZxy_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridViewZxy.RowsAdded
        If dataExist = True Then
            Call reCalcXY()
            Call dBindZXY()
        End If
    End Sub

    Private Sub DataGridViewZyx_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridViewZyx.RowsAdded
        If dataExist = True Then
            Call reCalcYX()
            Call dBindZYX()
        End If
    End Sub

    Private Sub DataGridViewZyy_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridViewZyy.RowsAdded
        If dataExist = True Then
            Call reCalcYY()
            Call dBindZYY()
        End If
    End Sub

    Private Sub DataGridViewTxZ_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridViewTxZ.RowsAdded
        If dataExist = True Then
            Call dBindTXZ()
        End If
    End Sub

    Private Sub DataGridViewTyZ_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridViewTyZ.RowsAdded
        If dataExist = True Then
            Call dBindTYZ()
        End If
    End Sub

    Private Sub DataWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridViewAllData.DataSource = tableALL
        DataGridViewZxx.DataSource = tableZXX
        DataGridViewZxy.DataSource = tableZXY
        DataGridViewZyx.DataSource = tableZYX
        DataGridViewZyy.DataSource = tableZYY
        DataGridViewTxZ.DataSource = tableTxZ
        DataGridViewTyZ.DataSource = tableTyZ

        Me.TopMost = True

    End Sub
End Class