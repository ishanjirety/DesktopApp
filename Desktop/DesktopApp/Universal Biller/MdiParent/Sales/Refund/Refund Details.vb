Imports System.Data
Imports System.Data.OleDb
Public Class Refund_Details

    Private Sub Refund_Details_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getdata()
    End Sub
    Public Sub getdata()
        con.Close()
        con.Open()
        Using cmd As New OleDbCommand
            cmd.CommandText = "Select * From RefundNew "
            cmd.Connection = con
            Dim dt As New DataTable
            Using da As New OleDbDataAdapter(cmd)
                da.Fill(dt)
                DataGridView1.DataSource = dt
                con.Close()
            End Using
        End Using
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        getdata()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        con.Close()
        con.Open()
        Using cmd As New OleDbCommand
            cmd.CommandText = "Select * From RefundNew Where CustomerNameR LIKE @nme + '%'"
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
        TextBox1.Text = Nothing
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        MDIParent1.Show()
        Me.Close()
    End Sub
End Class