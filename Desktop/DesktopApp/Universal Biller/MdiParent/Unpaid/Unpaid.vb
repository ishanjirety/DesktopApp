Imports System.Data
Imports System.Data.OleDb
Public Class Unpaid
    

    Private Sub Unpaid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getdata1()
    End Sub
    Public Sub getdata1()
        con.Close()
        con.Open()
        Using cmd As New OleDbCommand
            cmd.CommandText = "Select * From Unpaid "
            cmd.Connection = con
            Dim dt As New DataTable
            Using da As New OleDbDataAdapter(cmd)
                da.Fill(dt)
                DataGridView1.DataSource = dt
                con.Close()
            End Using
        End Using
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        MDIParent1.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MsgBox(" Press Ctrl + C To Copy Name In Textbox ", MsgBoxStyle.Information)
        Else
            Dim res As Integer = MsgBox("Do You Want To Generate Bill In favour Of " & TextBox1.Text, MsgBoxStyle.YesNo)
            If res = DialogResult.No Then
            ElseIf res = DialogResult.Yes Then
                con.Close()
                con.Open()
                cmd = New OleDbCommand(str, con)
                cmd.CommandText = "select * from Unpaid Where CustomerName1=@name"
                cmd.Prepare()
                cmd.Parameters.AddWithValue("@name", TextBox1.Text)
                Dim dr As OleDbDataReader = cmd.ExecuteReader()
                Try
                    If dr.Read() Then
                        namecpy = dr.GetValue(0)
                        numcpy = dr.GetValue(1)
                        addcpy = dr.GetValue(2)
                        dtecpy = dr.GetValue(3)
                        remarkcpy = dr.GetValue(4)
                        invcpy = Conversion.Val(dr.GetValue(5))
                        textcpy = TextBox1.Text
                        dr.Close()
                    End If
                Catch ex As Exception
                    MsgBox("Error", ex.Message)
                Finally
                    con.Close()
                End Try
                'Try
                '    con.Open()
                '    str = "Delete From Unpaid Where CustomerName1=@Nme"
                '    cmd = New OleDbCommand(str, con)
                '    cmd.Parameters.AddWithValue("@Nme", TextBox1.Text)
                '    cmd.ExecuteNonQuery()
                Form3.Show()
                Me.Close()
                '    TextBox1.Text = Nothing
                'Catch ex As Exception
                '    MsgBox("An Error Was Generated Please Try Again", MsgBoxStyle.Critical)
                'Finally
                '    con.Close()
                'End Try

            End If
        End If
        'Try
        '    con.Open()
        '    str = "Delete From Unpaid Where CustomerName1=@Nme"
        '    cmd = New OleDbCommand(str, con)
        '    cmd.Parameters.AddWithValue("@Nme", TextBox1.Text)
        '    cmd.ExecuteNonQuery()
        '    Form3.Show()
        '    Me.Close()
        '    TextBox1.Text = Nothing
        'Catch ex As Exception
        '    MsgBox("An Error Was Generated Please Try Again", MsgBoxStyle.Critical)
        'Finally
        '    con.Close()
        'End Try


        
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        con.Close()
        con.Open()
        Using cmd As New OleDbCommand
            cmd.CommandText = "Select * From Unpaid Where CustomerName1 LIKE @nme2 + '%'"
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@nme2", TextBox1.Text.Trim())
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

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        getdata1()
    End Sub
End Class
