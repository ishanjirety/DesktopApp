Public Class Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not TextBox1.Text = "" Then
            If TextBox1.Text = "16bd32-99-4f7c-8ebd" Then
                CreateUP.Show()
                Me.Close()
            ElseIf TextBox1.Text = "Admin" Then
                CreateUP.Show()
                Me.Hide()
            Else
                MsgBox("Authentication Failed", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("Enter Key", MsgBoxStyle.Critical)
            TextBox1.Focus()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        LoginForm1.Show()
        Me.Hide()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class