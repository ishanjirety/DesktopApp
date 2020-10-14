Imports System.Data
Imports System.Data.OleDb
Public Class Form3


    Private Sub ComboBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.TextChanged
        Label47.Text = ComboBox2.Text
        If ComboBox2.Text = "Cash" Then
            Label31.Hide()
            Label32.Hide()
            Label33.Hide()
            Label34.Show()
            Label35.Show()
            TextBox9.Show()
            TextBox12.Hide()
            TextBox10.Hide()
            TextBox11.Hide()
            TextBox12.Text = "NULL"
            TextBox10.Text = "NULL"
            TextBox11.Text = "NULL"
        ElseIf ComboBox2.Text = "Bank Transfer" Or ComboBox2.Text = "Cheque" Then
            Label35.Hide()
            Label34.Hide()
            TextBox9.Hide()
            Label31.Show()
            Label32.Show()
            Label33.Show()
            TextBox12.Show()
            TextBox10.Show()
            TextBox11.Show()
        Else
            hde()
        End If
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        Label14.Hide()
        hde()
        ins()
    End Sub
    Public Sub hde()
        Label23.Hide()
        Label12.Hide()
        Label34.Hide()
        Label31.Hide()
        Label32.Hide()
        Label33.Hide()
        Label35.Hide()
        TextBox9.Hide()
        TextBox12.Hide()
        TextBox10.Hide()
        TextBox11.Hide()
    End Sub
    Public Sub ins()
        Label29.Text = namecpy
        Label30.Text = addcpy
        Label50.Text = numcpy
        Label13.Text = dtecpy
        Label51.Text = remarkcpy
        Label41.Text = invcpy
        TextBox8.Text = invcpy
        ListBox1.Items.Add("Empty")
        ListBox2.Items.Add("Empty")
        ListBox3.Items.Add("Empty")
        ListBox4.Items.Add("Empty")
        ListBox5.Items.Add("Empty")
    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged
        Label35.Text = "Change " & Conversion.Val(TextBox9.Text) - Conversion.Val(TextBox8.Text)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        billentry()
        ledgentry()
        If ListBox1.Items.Count = 0 Then
            MsgBox("Add Items To Your Cart To Proceed", MsgBoxStyle.Critical)
        Else
            Try
                con.Open()
                str = "Delete From Unpaid Where CustomerName1=@Nme"
                cmd = New OleDbCommand(str, con)
                cmd.Parameters.AddWithValue("@Nme", textcpy)
                cmd.ExecuteNonQuery()
                TextBox1.Text = Nothing
            Catch ex As Exception
                MsgBox("An Error Was Generated Please Try Again", MsgBoxStyle.Critical)
            Finally
                con.Close()
            End Try
            Label23.Show()
            Label12.Show()
            Try
                con.Close()
                con.Open()
                cmd = New OleDbCommand("Insert Into Sales(CustomerName,MobileNo,Address,date1,Remark,InvoiceValue,Mode,BankName,BranchCode,ChequeNo,Description) values('" + Label29.Text + "','" + Label50.Text + "','" + Label30.Text + "','" + Label13.Text + "','" + Label51.Text + "','" + TextBox8.Text + "','" + ComboBox2.Text + "','" + TextBox12.Text + "','" + TextBox10.Text + "','" + TextBox11.Text + "','" + Label14.Text + "')", con)
                Dim i As Integer = cmd.ExecuteNonQuery
                If (i > 0) Then
                    con.Close()
                    'MsgBox("Generating Bill...", MsgBoxStyle.Information)
                    MDIParent1.Show()
                    Me.Close()

                Else
                    MsgBox("Bill Cannot Be Generated", MsgBoxStyle.Exclamation)

                End If
            Catch ex As Exception
                MsgBox("Error", ex.Message)
            Finally
                con.Close()
            End Try
            MDIParent1.Show()
            BillB.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Unpaid.Show()
        Me.Close()
    End Sub

    Public Sub billentry()
        BillB.Label37.Text = Label28.Text
        BillB.Label40.Text = Label29.Text
        BillB.Label42.Text = Label30.Text
        BillB.Label44.Text = Label50.Text
        BillB.Label38.Text = Label431.Text
        BillB.Label21.Text = Label41.Text
        BillB.Label48.Text = ComboBox2.Text
        BillB.Label50.Text = Label44.Text
        BillB.Label21.Text = TextBox8.Text
        BillB.Label39.Text = TextBox8.TextAlign
        BillB.Label36.Text = Label31.Text

    End Sub
    Public Sub ledgentry()
        Try
            con.Close()
            con.Open()
            cmd = New OleDbCommand("Insert Into SaleJournalCr(CrDate,CrName,CrAmount) values('" + Label13.Text + "','" + Label29.Text + "','" + TextBox8.Text + "')", con)
            Dim i As Integer = cmd.ExecuteNonQuery
            If (i > 0) Then
                con.Close()
            Else
                MsgBox("Ledger Can Not Be Updated", MsgBoxStyle.Exclamation)

            End If
        Catch ex As Exception
            MsgBox("Error", ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
End Class