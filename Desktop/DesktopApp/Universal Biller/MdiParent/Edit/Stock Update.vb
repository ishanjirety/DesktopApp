Imports System.Data.OleDb
Public Class Stock_Update

    Private Sub Stock_Update_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            con.Close()
            con.Open()
            cmd = New OleDbCommand("Insert Into Products(ProductName,ProductType,SerialNo,MFG,Expiry,RateD,Tax,Company,Stock,DiscountD,CostPrice) values('" + TextBox1.Text + "','" + ComboBox1.Text + "','" + TextBox3.Text + "','" + DateTimePicker1.Text + "','" + DateTimePicker2.Text + "','" + TextBox5.Text + "','" + Label12.Text + "','" + TextBox2.Text + "','" + TextBox7.Text + "','" + TextBox6.Text + "','" + TextBox4.Text + "')", con)
            Dim i As Integer = cmd.ExecuteNonQuery
            If (i > 0) Then
                con.Close()
                MsgBox("Details Saved", MsgBoxStyle.Information)
                clear()
            Else
                MsgBox("Bill Cannot Be Generated", MsgBoxStyle.Exclamation)

            End If
        Catch ex As Exception
            MsgBox("Error", ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MDIParent1.Show()
        Me.Close()
    End Sub
    Public Sub clear()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        ComboBox1.Text = Nothing
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click, Label12.Click

    End Sub
End Class