Imports System.Data.OleDb
Public Class Challan_History

    Private Sub Challan_History_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getdata()
    End Sub
    Public Sub getdata()
        con.Close()
        con.Open()
        Using cmd As New OleDbCommand
            cmd.CommandText = "Select * From Challan "
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
        con.Close()
        con.Open()
        Try
            Using cmd As New OleDbCommand
                cmd.CommandText = "Select * From Challan Where ORDID LIKE @nme + '%'"
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@nme", TextBox1.Text.Trim())
                Dim dt As New DataTable
                Using da As New OleDbDataAdapter(cmd)
                    da.Fill(dt)
                    DataGridView1.DataSource = dt
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error Occured", MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MDIParent1.Show()
        Me.Close()
    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True

            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        getdata()
    End Sub
End Class