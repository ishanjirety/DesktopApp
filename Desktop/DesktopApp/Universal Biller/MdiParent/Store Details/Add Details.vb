Imports System.Data
Imports System.Data.OleDb

Public Class Add_Details


    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click, Label6.Click, Label5.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim res As Integer = MessageBox.Show("Do You Want To Save Details ?", "Universal Biller", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If res = DialogResult.No Then
        ElseIf res = DialogResult.Yes Then
            Try
                con.Open()
                cmd = New OleDbCommand("Insert Into StoreDetails(StoreName,StoreAddress,StoreTelephone,EmailID,PhoneNum,GSTIN) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox5.Text + "','" + TextBox4.Text + "','" + TextBox6.Text + "')", con)
                Dim i As Integer = cmd.ExecuteNonQuery
                If (i > 0) Then
                    con.Close()
                    MsgBox("Details Saved!", MsgBoxStyle.Information)
                    getdata()
                Else
                    MsgBox("An Error Occured", MsgBoxStyle.Exclamation)

                End If
            Catch ex As Exception
                MsgBox("Error", ex.Message)
            Finally
                con.Close()
            End Try
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MDIParent1.Show()
        Me.Close()
    End Sub

    Private Sub Add_Details_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getdata()
    End Sub
    Public Sub getdata()
        con.Close()
        con.Open()
        Using cmd As New OleDbCommand
            cmd.CommandText = "Select * From StoreDetails "
            cmd.Connection = con
            Dim dt As New DataTable
            Using da As New OleDbDataAdapter(cmd)
                da.Fill(dt)
                DataGridView1.DataSource = dt
                con.Close()
            End Using
        End Using
    End Sub

   
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If TextBox7.Text = Nothing Then
            MsgBox("Please Enter Name Of Customer Or Ctrl+c To Copy Name From Search", MsgBoxStyle.Exclamation)
        Else
            Dim msg As Integer = MsgBox("Are You Sure To Delete " & "'" & TextBox7.Text & "'" & " From Records?", MsgBoxStyle.YesNo)
            If msg = DialogResult.Yes Then
                Try
                    con.Open()
                    str = "Delete From StoreDetails Where StoreName=@Nme"
                    cmd = New OleDbCommand(str, con)
                    cmd.Parameters.AddWithValue("@Nme", TextBox7.Text)
                    cmd.ExecuteNonQuery()
                    MsgBox("Record Deleted", MsgBoxStyle.Information, MsgBoxStyle.OkOnly)
                    TextBox7.Text = Nothing
                Catch ex As Exception
                    MsgBox("An Error Was Generated Please Try Again", MsgBoxStyle.Critical)
                Finally
                    con.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged
        getdata()
    End Sub
End Class