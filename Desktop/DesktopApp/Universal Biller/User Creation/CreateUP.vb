Imports System.Data.OleDb
Public Class CreateUP
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Enter Details", MsgBoxStyle.Critical)
        Else
            Try
                If TextBox2.Text = TextBox3.Text Then
                    con.Close()
                    con.Open()
                    cmd = New OleDbCommand("Insert Into Login values('" + TextBox1.Text + "','" + TextBox2.Text + "')", con)
                    Dim i As Integer = cmd.ExecuteNonQuery
                    If (i > 0) Then
                        con.Close()
                        Label4.Text = "User Created Successfully"
                    End If
                Else
                    MsgBox("Password Does Not Match", MsgBoxStyle.Critical)
                    TextBox2.Text = Nothing
                    TextBox3.Text = Nothing
                    TextBox2.Focus()

                End If
            Catch ex As Exception
                MsgBox("Username Already Exist", MsgBoxStyle.Critical)
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
            Finally
                con.Close()
            End Try
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        LoginForm1.Show()
        Me.Hide()
    End Sub
End Class