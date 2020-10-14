Imports System.Data.OleDb
Imports System.Data
Imports System.Security.Cryptography
Imports System.Text
Public Class Retail2
    Dim lastno As Integer
    Private Sub Retail2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'BillingDataSet1.Products' table. You can move, or remove it, as needed.
        Me.ProductsTableAdapter.Fill(Me.BillingDataSet1.Products)
        BillB.Show()
        BillB.Hide()
        Label53.Hide()
        ComboBox1.Items.Clear()
        ds.Clear()
        Label31.Hide()
        Label32.Hide()
        Label33.Hide()
        TextBox10.Hide()
        TextBox11.Hide()
        TextBox12.Hide()
        TextBox9.Hide()
        Label34.Hide()
        Label35.Hide()
        ComboBox1.Focus()
        Searchid()
        Label28.Text = c
        clear()
        Prdctname()
        clr()
    End Sub
    Public Sub bill()
        con.Close()
        con.Open()
        str = "Select * From Sales"
        cmd = New OleDbCommand(str, con)
        da.SelectCommand = cmd
        da.Fill(ds, "Sales")
        lastno = ds.Tables("Sales").Rows.Count + 1
        If lastno >= 0 Then
        Else
            Label28.Text = 0
        End If
        con.Close()
    End Sub
    Public Sub Prdctname()
        con.Close()
        con.Open()
        ds.Clear()
        str = "select ProductName From Products "
        cmd = New OleDbCommand(str, con)
        da.SelectCommand = cmd
        da.Fill(ds, "Products")
        Dim a As Integer = ds.Tables("Products").Rows.Count - 1
        For i As Integer = 0 To a
            ComboBox1.Items.Add(ds.Tables("Products").Rows(i)(1).ToString())
        Next
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        con.Close()
        con.Open()
        cmd = New OleDbCommand(str, con)
        cmd.CommandText = "select * from Products Where ProductName=@name"
        cmd.Prepare()
        cmd.Parameters.AddWithValue("@name", ComboBox1.Text)
        Dim dr As OleDbDataReader = cmd.ExecuteReader()
        Try
            If dr.Read() Then
                pdt = dr.GetValue(1)
                amt = dr.GetValue(6)
                amt = dr.GetValue(6)
                Label39.Text = dr.GetValue(6)
                Label37.Text = dr.GetValue(3)
                Label38.Text = dr.GetValue(8)
                Label40.Text = dr.GetValue(9)
                tempo = dr.GetValue(10)
                dis = (dr.GetValue(10))
                cpy = dr.GetValue(9)
                dr.Close()
            End If
        Catch ex As Exception
            MsgBox("Error", ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub up()
        con.Close()
        con.Open()
        cmd = New OleDbCommand(str, con)
        cmd.CommandText = "select * from Products Where ProductName=@name"
        cmd.Prepare()
        cmd.Parameters.AddWithValue("@name", ComboBox1.Text)
        Dim dr As OleDbDataReader = cmd.ExecuteReader()
        Try
            If dr.Read() Then
                cpy1 = dr.GetValue(9)
                dr.Close()
            End If
        Catch ex As Exception
            MsgBox("Error", ex.Message)
        Finally
            con.Close()
        End Try
        con.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        clear()
    End Sub
    Public Sub clear()
        TextBox4.Text = Nothing
        TextBox5.Text = Nothing
        TextBox6.Text = Nothing
        TextBox7.Text = Nothing
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        ListBox5.Items.Clear()
        Label36.Text = Nothing
        Label37.Text = Nothing
        Label38.Text = Nothing
        Label39.Text = Nothing
        Label40.Text = Nothing
        Label41.Text = Nothing
        Label431.Text = Nothing
        Label44.Text = Nothing
        Label45.Text = Nothing
        ComboBox1.Text = Nothing
        TextBox2.Text = Nothing
        Label47.Text = Nothing
        ComboBox2.Text = Nothing

    End Sub

    Private Sub Label32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        If Conversion.Val(TextBox2.Text) > cpy Then
            MsgBox("Not Enough Stock", MsgBoxStyle.Critical)
            TextBox2.Text = Nothing
        End If
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Label47.Text = ComboBox2.Text
        If ComboBox2.Text = "Cash" Then
            Label31.Hide()
            Label32.Hide()
            Label33.Hide()
            TextBox10.Hide()
            TextBox11.Hide()
            TextBox12.Hide()
            TextBox9.Show()
            Label34.Show()
            Label35.Show()
            TextBox10.Text = "NULL"
            TextBox12.Text = "NULL"
            TextBox11.Text = "NULL"
        ElseIf ComboBox2.Text = "Paytm" Then
            Label31.Hide()
            Label32.Hide()
            Label33.Hide()
            TextBox10.Hide()
            TextBox11.Hide()
            TextBox12.Hide()
            TextBox10.Text = "NULL"
            TextBox12.Text = "NULL"
            TextBox11.Text = "NULL"
        ElseIf ComboBox2.Text = "Cheque" Then
            TextBox9.Hide()
            Label34.Hide()
            Label35.Hide()
            Label31.Show()
            Label32.Show()
            Label33.Show()
            TextBox10.Show()
            TextBox11.Show()
            TextBox12.Show()
        ElseIf ComboBox2.Text = "Bank Transfer" Then
            TextBox9.Hide()
            Label34.Hide()
            Label35.Hide()
            Label31.Show()
            Label32.Show()
            Label33.Show()
            TextBox10.Show()
            TextBox11.Show()
            TextBox12.Show()
        Else
            TextBox9.Hide()
            Label34.Hide()
            Label35.Hide()
            Label31.Hide()
            Label32.Hide()
            Label33.Hide()
            TextBox10.Hide()
            TextBox11.Hide()
            TextBox12.Hide()
        End If
    End Sub
    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        Label29.Text = TextBox4.Text
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged
        Label30.Text = TextBox5.Text
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        Label50.Text = TextBox6.Text
    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged
        Label51.Text = TextBox7.Text
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MDIParent1.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        newadder = 0
        If count = -1 Then
            count = 0
        End If
        If ComboBox1.Text = Nothing Or TextBox2.Text = Nothing Then
            MsgBox("Cannot Proceed Without Item", MsgBoxStyle.Exclamation)
        Else
            count = count + 1
            pcs = Conversion.Int(TextBox2.Text)
            Dim temp As Integer = Conversion.Val(Label41.Text)
            Dim sum As Integer
            Dim lsum As Integer
            Dim lsum1 As Integer
            Dim temp1 As Integer = Conversion.Val(Label431.Text)
            sum1 = (pcs * (amt * ((100 - dis) / 100)))
            sum = sum1
            sum = sum + temp
            lsum1 = pcs * amt
            lsum = lsum1
            lsum = lsum + temp1
            ListBox1.Items.Add(pdt)
            ListBox2.Items.Add("        " & pcs)
            ListBox3.Items.Add("        " & amt)
            ListBox4.Items.Add("        " & tempo & "%")
            ListBox5.Items.Add("            " & sum1)
            BillB.ListBox2.Items.Add(pdt)
            BillB.ListBox3.Items.Add(amt)
            BillB.ListBox4.Items.Add(Label37.Text)
            BillB.ListBox5.Items.Add(pcs)
            BillB.ListBox6.Items.Add(tempo)
            BillB.ListBox7.Items.Add(sum1)
            BillB.ListBox8.Items.Add(sum1)
            '''''''''''''''''''''''''''''''''
            Sale_Challan.ListBox2.Items.Add(pdt)
            Sale_Challan.ListBox3.Items.Add(amt)
            Sale_Challan.ListBox1.Items.Add(count)
            Sale_Challan.ListBox5.Items.Add(pcs)
            Sale_Challan.ListBox8.Items.Add(sum1)
            '''''''''''''''''''''''''''''''''
            Label36.Text = count
            d = sum1
            Label41.Text = sum
            Label431.Text = lsum
            e1 = lsum1
            f1 = lsum
            a = sum
            new1 = Conversion.Val(Label41.Text)
            Label52.Text = emp
            Try
                con.Open()
                Dim l1 As Integer
                l1 = Conversion.Val(Label40.Text) - Conversion.Val(TextBox2.Text)
                Dim cb As String = "update [Products] set [Stock]='" & l1 & "'Where [ProductName]='" & ComboBox1.Text & "'" 'MYsql
                cmd = New OleDbCommand(cb)
                cmd.Connection = con
                cmd.ExecuteReader()
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Close()
            Catch ex As Exception
                MsgBox("Error", ex.Message)
            End Try
            up()
            Label40.Text = cpy1
            cpy2 = Label40.Text
            TextBox2.Text = Nothing
            ComboBox1.Text = Nothing
            Label44.Text = Conversion.Val(Label431.Text) - Conversion.Val(Label41.Text)
        End If
    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If ListBox1.SelectedItem = Nothing Or ListBox2.SelectedItem = Nothing Or ListBox3.SelectedItem = Nothing Or ListBox4.SelectedItem = Nothing Or ListBox5.SelectedItem = Nothing Then
            MsgBox("Select Item To Remove", MsgBoxStyle.Information)
        Else
            Try
                con.Close()
                con.Open()
                Dim l2 As String
                l2 = Conversion.Val(cpy2) + Conversion.Val(ListBox2.SelectedItem)
                Conversion.Val(l2)
                Dim cb As String = "update [Products] set [Stock]='" & l2 & "'Where ProductName='" & ListBox1.SelectedItem & "' "
                cmd = New OleDbCommand(cb)
                cmd.Connection = con
                cmd.ExecuteNonQuery()
                con.Close()
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            Catch ex As Exception
                MsgBox("Error", ex.Message)
            Finally
                con.Close()
            End Try
            con.Close()
            count1 = 0
            count1 = count1 + 1
            a = 0
            f1 = 0
            TextBox9.Text = Nothing
            Dim l1 As String = ListBox1.SelectedItem
            Dim l21 As Integer = Conversion.Val(ListBox2.SelectedItem)
            Dim l3 As Integer = Conversion.Val(ListBox3.SelectedItem)
            Dim l4 As Integer = Conversion.Val(ListBox4.SelectedItem)
            Dim l5 As Integer = Conversion.Val(ListBox5.SelectedItem)
            BillB.ListBox2.Items.Remove(l1)
            BillB.ListBox3.Items.Remove(l3)
            BillB.ListBox4.Items.Remove(Label37.Text)
            BillB.ListBox5.Items.Remove(l21)
            BillB.ListBox6.Items.Remove(l4)
            BillB.ListBox7.Items.Remove(l5)
            BillB.ListBox8.Items.Remove(l5)
            ''''''''''''''''''''''''''''''''
            Sale_Challan.ListBox2.Items.Remove(pdt)
            Sale_Challan.ListBox3.Items.Remove(amt)
            Sale_Challan.ListBox1.Items.Remove(count)
            Sale_Challan.ListBox5.Items.Remove(pcs)
            Sale_Challan.ListBox8.Items.Remove(sum1)
            ''''''''''''''''''''''''''''''''
            ListBox1.Items.Remove(ListBox1.SelectedItem)
            ListBox2.Items.Remove(ListBox2.SelectedItem)
            d2 = ListBox3.SelectedItem
            ListBox3.Items.Remove(ListBox3.SelectedItem)
            ListBox4.Items.Remove(ListBox4.SelectedItem)
            d1 = ListBox5.SelectedItem
            ListBox5.Items.Remove(ListBox5.SelectedItem)

            Label41.Text = Conversion.Val(Label41.Text) - Conversion.Val(d1)
            Label431.Text = Conversion.Val(Label431.Text) - (pcs * (Conversion.Val(d2)))
            dash = count - count1
            If dash = 0 Then
                clear()
            End If
            Label36.Text = dash
            a = Conversion.Val(Label41.Text)
            f1 = Conversion.Val(Label431.Text)
            Label44.Text = Conversion.Val(Label431.Text) - Conversion.Val(Label41.Text)
            count = dash
        End If
    End Sub
    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged
        Label35.Text = "Change " & Conversion.Val(TextBox9.Text) - Conversion.Val(TextBox8.Text)
    End Sub

    Private Sub ListBox5_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox5.KeyPress
    End Sub
    Private Sub Label41_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label41.TextChanged
        Sale_Challan.Label23.Text = "GST Charged: " & Conversion.Val(Label41.Text) * 0.025 'Sending Gst Amount To challan'
        Sale_Challan.Label24.Text = "Amount: " & Label41.Text
        TextBox8.Text = Conversion.Val(Label41.Text) * 1.025
        gstnew = Conversion.Val(Label41.Text) * 0.025
        Sale_Challan.Label22.Text = "Rs." & TextBox8.Text
        Challan_Entry.Label20.Text = TextBox8.Text
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If ComboBox2.Text = "Challan" Then
            Challan_Entry.Show()
            Me.Close()
        Else
            Label26.Show()
            Label43.Show()
            Label48.Show()
            Label49.Show()
            TextBox4.Show()
            TextBox5.Show()
            TextBox6.Show()
            TextBox7.Show()
            clr()
            Data_Send_Bill()
            If ListBox1.Items.Count = 0 Then
                MsgBox("Add Items To Your Cart To Proceed", MsgBoxStyle.Critical)
            Else
                If ComboBox2.Text = "Credit/Unpaid" Then
                    Try
                        con.Close()
                        con.Open()
                        cmd = New OleDbCommand("Insert Into Unpaid(CustomerName1,MobileNo1,Address1,date2,Remark1,InvoiceValue1) values('" + Label29.Text + "','" + Label50.Text + "','" + Label30.Text + "','" + DateTimePicker1.Text + "','" + Label51.Text + "','" + TextBox8.Text + "')", con)
                        Dim i As Integer = cmd.ExecuteNonQuery
                        If (i > 0) Then
                            con.Close()
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
                Else
                    Try
                        Sledger_insert()
                        con.Open()
                        Sales_Return_Ledger.Up1()
                        cmd = New OleDbCommand("Insert Into Sales(CustomerName,MobileNo,Address,date1,Remark,InvoiceValue,Mode,BankName,BranchCode,ChequeNo,Description,Discount) values('" + Label29.Text + "','" + Label50.Text + "','" + Label30.Text + "','" + DateTimePicker1.Text + "','" + Label51.Text + "','" + TextBox8.Text + "','" + ComboBox2.Text + "','" + TextBox12.Text + "','" + TextBox10.Text + "','" + TextBox11.Text + "','" + Label53.Text + "','" + Label52.Text + "')", con)
                        Dim i As Integer = cmd.ExecuteNonQuery
                        If (i > 0) Then
                            con.Close()
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
                End If
                'Data_Send_Bill()
                BillB.Show()
                Me.Hide()
            End If
        End If
    End Sub
    Public Sub clr()
        Sale_Challan.ListBox1.Items.Clear()
        Sale_Challan.ListBox2.Items.Clear()
        Sale_Challan.ListBox3.Items.Clear()
        Sale_Challan.ListBox5.Items.Clear()
    End Sub
    Public Sub Searchid()
        con.Close()
        con.Open()
        cmd = New OleDbCommand("Select MAX(Bill) from Sales", con)
        Dim dr As OleDbDataReader
        Try
            dr = cmd.ExecuteReader
            While dr.Read
                Dim cus As String = dr.GetValue(0)
                c = cus
            End While
        Catch ex As Exception
            MsgBox("Error", ex.Message)
        Finally
            con.Close()

        End Try
    End Sub
    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True

            End If
        End If
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True

            End If
        End If
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 65 Or Asc(e.KeyChar) > 122 Then
                If Asc(e.KeyChar) = 32 Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            End If
        End If
    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True

            End If
        End If
    End Sub

    Private Sub TextBox7_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 65 Or Asc(e.KeyChar) > 122 Then
                If Asc(e.KeyChar) = 32 Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            End If
        End If
    End Sub

    Private Sub TextBox9_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True

            End If
        End If
    End Sub
    Public Sub Data_Send_Bill()
        NameB = Label29.Text
        addB = Label30.Text
        mobB = Label50.Text
        tItemB = Label36.Text
        VOGB = Label431.Text
        AdisB = Label41.Text
        BillB.Label20.Text = gstnew
        MdeB = Label47.Text
        Ysave = Label44.Text
        invB = TextBox8.Text
        dateB = DateTimePicker1.Text
        BillB.Label37.Text = "000" & Label28.Text
        BillB.Label40.Text = NameB
        BillB.Label42.Text = addB
        BillB.Label44.Text = mobB
        BillB.Label46.Text = tItemB
        'Bill1.Label21.Text = AdisB
        BillB.Label38.Text = VOGB
        BillB.Label48.Text = MdeB
        BillB.Label50.Text = Ysave
        BillB.Label21.Text = invB
        BillB.Label39.Text = invB
        BillB.Label27.Text = invB
        BillB.Label36.Text = dateB
    End Sub
    Public Sub Sledger_insert()
        'Sale_Ledger.ListBox4.Items.Add(DateTimePicker1.Text)
        'Sale_Ledger.ListBox5.Items.Add("BY " & Label29.Text)
        'Sale_Ledger.ListBox6.Items.Add(TextBox8.Text)
        Try
            con.Close()
            con.Open()
            cmd = New OleDbCommand("Insert Into SaleJournalCr(CrDate,CrName,CrAmount) values('" + DateTimePicker1.Text + "','" + Label29.Text + "','" + TextBox8.Text + "')", con)
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

    Private Sub ComboBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.TextChanged
        If ComboBox2.Text = "Challan" Then
            Label26.Hide()
            Label43.Hide()
            Label48.Hide()
            Label49.Hide()
            TextBox4.Hide()
            TextBox5.Hide()
            TextBox6.Hide()
            TextBox7.Hide()
        Else
            Label26.Show()
            Label43.Show()
            Label48.Show()
            Label49.Show()
            TextBox4.Show()
            TextBox5.Show()
            TextBox6.Show()
            TextBox7.Show()
        End If
    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged

    End Sub
End Class