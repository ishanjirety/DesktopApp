Imports System.Data.OleDb
Public Class Inventory

    Private Sub Inventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getdata()
        Button1.PerformClick()
    End Sub
    Public Sub getdata()
        con.Close()
        con.Open()
        Using cmd As New OleDbCommand
            cmd.CommandText = "Select * From Products "
            cmd.Connection = con
            Dim dt As New DataTable
            Using da As New OleDbDataAdapter(cmd)
                da.Fill(dt)
                DataGridView1.DataSource = dt
                con.Close()
            End Using
        End Using
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MDIParent1.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        con.Close()
        con.Open()
        Using cmd As New OleDbCommand
            cmd.CommandText = "Select * From Products Where ProductName LIKE @nme + '%'"
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@nme", TextBox1.Text.Trim())
            Dim dt As New DataTable
            Using da As New OleDbDataAdapter(cmd)
                da.Fill(dt)
                DataGridView1.DataSource = dt
            End Using
        End Using
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If TextBox1.Text = Nothing Then
            MsgBox("Please Enter Name Of Customer Or Ctrl+c To Copy Name From Search", MsgBoxStyle.Exclamation)
        Else
            Dim msg As Integer = MsgBox("Are You Sure To Delete " & "'" & TextBox1.Text & "'" & " From Records?", MsgBoxStyle.YesNo)
            If msg = DialogResult.Yes Then
                Try
                    con.Open()
                    str = "Delete From Products Where ProductName=@Nme"
                    cmd = New OleDbCommand(str, con)
                    cmd.Parameters.AddWithValue("@Nme", TextBox1.Text)
                    cmd.ExecuteNonQuery()
                    MsgBox("Record Deleted", MsgBoxStyle.Information, MsgBoxStyle.OkOnly)
                    TextBox1.Text = Nothing
                Catch ex As Exception
                    MsgBox("An Error Was Generated Please Try Again", MsgBoxStyle.Critical)
                Finally
                    con.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Button1.PerformClick()
    End Sub
End Class