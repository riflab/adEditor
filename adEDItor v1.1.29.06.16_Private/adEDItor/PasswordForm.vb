Public Class PasswordForm


    Private Sub PasswordForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBoxPass.Text = "aaksep" Then
            MessageBox.Show("Password accepted")
            Me.Close()
            MainWindow.Show()

        Else
            MessageBox.Show("Invalid password")
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        AboutForm.Show()
    End Sub
End Class