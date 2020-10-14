Imports System.Data
Imports System.Data.OleDb

Public Class Sales
    Public see As Integer = 0
    Private Sub Sales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getdata()
    End Sub
    Public Sub getdata()
        con.Close()
        con.Open()
        Using cmd As New OleDbCommand
            cmd.CommandText = "Select * From Sales "
            cmd.Connection = con
            Dim dt As New DataTable
            Using da As New OleDbDataAdapter(cmd)
                da.Fill(dt)
                DataGridView1.DataSource = dt
                con.Close()
            End Using
        End Using
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        con.Close()
        con.Open()
        Using cmd As New OleDbCommand
            cmd.CommandText = "Select * From Sales Where CustomerName LIKE @nme + '%'"
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@nme", TextBox1.Text.Trim())
            Dim dt As New DataTable
            Using da As New OleDbDataAdapter(cmd)
                da.Fill(dt)
                DataGridView1.DataSource = dt
            End Using
        End Using
    End Sub


    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        getdata()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text = Nothing Then
            MsgBox("Please Enter Name Of Customer Or Ctrl+c To Copy Name From Search", MsgBoxStyle.Exclamation)
        Else
            Dim msg As Integer = MsgBox("Are You Sure To Delete " & "'" & TextBox1.Text & "'" & " From Records?", MsgBoxStyle.YesNo)
            If msg = DialogResult.Yes Then
                Try
                    con.Open()
                    str = "Delete From Sales Where CustomerName=@Nme"
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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox1.Text = Nothing
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        MDIParent1.Show()
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If TextBox1.Text = Nothing Then
            MsgBox("Please Enter Name Of Customer Or Ctrl+c To Copy Name From Search", MsgBoxStyle.Exclamation)
        Else
            rnamecpy = TextBox1.Text
            Refund.Show()
            Me.Close()
        End If
    End Sub
    Public Sub up()
        con.Close()
        con.Open()
        cmd = New OleDbCommand(str, con)
        cmd.CommandText = "select * from Products Where Sales=@name"
        cmd.Prepare()
        cmd.Parameters.AddWithValue("@name", TextBox1.Text)
        Dim dr As OleDbDataReader = cmd.ExecuteReader()
        Try
            If dr.Read() Then
                rname = dr.GetValue(1)
                rmob = dr.GetValue(2)
                raddr = dr.GetValue(3)
                rdt = dr.GetValue(4)
                rinv = dr.GetValue(6)
                dr.Close()
            End If
        Catch ex As Exception
            MsgBox("Error", ex.Message)
        Finally
            con.Close()
        End Try
        con.Close()


        Refund.Show()
        Me.Hide()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class