Imports System.Data
Imports System.Data.OleDb
Public Class Refund
    Private Sub Refund_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Show()
        TextBox2.Show()
        Label23.Show()
        Label24.Show()
        Button3.Show()
        ComboBox1.Items.Clear()
        ds.Clear()
        Label19.Hide()
        Prdctname()
        refundDetails()
    End Sub
    Public Sub Prdctname()
        con.Close()
        con.Open()
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
        data()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Label6.Text = rinv
        If ComboBox1.Text = Nothing Or TextBox2.Text = Nothing Then
            MsgBox("Cannot Proceed Without Item", MsgBoxStyle.Exclamation)
        Else
            count = count + 1
            pcs = Conversion.Int(TextBox2.Text)
            Dim temp As Integer = Conversion.Val(Label41.Text)
            Dim sum As Integer
            Dim sum1 As Integer
            Dim lsum As Integer
            Dim lsum1 As Integer
            Dim temp1 As Integer = Conversion.Val(Label431.Text)
            sum1 = (pcs * (amt * ((100 - dis) / 100)))
            sum = sum1
            If rinv < sum Then
                MsgBox("Refund Value Exceeded Invoice Value", MsgBoxStyle.Critical)
                ComboBox1.Text = Nothing
                TextBox2.Text = Nothing
                sum1 = 0
            ElseIf Conversion.Val(TextBox8.Text) + sum1 = rinv Then
                ComboBox1.Hide()
                TextBox2.Hide()
                Label23.Hide()
                Label24.Hide()
                Button3.Hide()
            ElseIf Conversion.Val(TextBox8.Text) + sum1 > rinv Then
                MsgBox("Refund Value Exceeded Invoice Value", MsgBoxStyle.Critical)
                ComboBox1.Text = Nothing
                TextBox2.Text = Nothing
                sum1 = 0
            Else
                sum = sum + temp
                lsum1 = pcs * amt
                lsum = lsum1
                lsum = lsum + temp1
                ListBox1.Items.Add(pdt)
                ListBox2.Items.Add("        " & pcs)
                ListBox3.Items.Add("        " & amt)
                ListBox4.Items.Add("        " & tempo & "%")
                ListBox5.Items.Add("            " & sum1)
                Label36.Text = count
                d = sum1
                Label41.Text = sum
                'TextBox8.Text = sum
                Label431.Text = lsum
                e1 = lsum1
                f1 = lsum
                a = sum
                'TextBox8.Text = sum
                new1 = Conversion.Val(Label41.Text)
                check()
                Try
                    con.Open()
                    Dim l1 As Integer
                    l1 = Conversion.Val(Label40.Text) + Conversion.Val(TextBox2.Text)
                    Dim cb As String = "update [Products] set [Stock]='" & l1 & "'Where [ProductName]='" & ComboBox1.Text & "'"
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
            End If
        End If
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
    Public Sub data()
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
    Public Sub refundDetails()
        con.Close()
        con.Open()
        cmd = New OleDbCommand(str, con)
        cmd.CommandText = "select * from Sales Where CustomerName=@name"
        cmd.Prepare()
        cmd.Parameters.AddWithValue("@name", rnamecpy)
        Dim dr As OleDbDataReader = cmd.ExecuteReader()
        Try
            If dr.Read() Then
                Label29.Text = dr.GetValue(1)
                Label50.Text = dr.GetValue(2)
                Label30.Text = dr.GetValue(3)
                rinv = dr.GetValue(6)
                dr.Close()
            End If
        Catch ex As Exception
            MsgBox("Error", ex.Message)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        remo()
        check()
    End Sub
    Public Sub remo()
        If ListBox1.SelectedItem = Nothing Or ListBox2.SelectedItem = Nothing Or ListBox3.SelectedItem = Nothing Or ListBox4.SelectedItem = Nothing Or ListBox5.SelectedItem = Nothing Then
            MsgBox("Select Item To Remove", MsgBoxStyle.Information)
        Else
            Try
                con.Close()
                con.Open()
                Dim l2 As String
                l2 = Conversion.Val(cpy2) - Conversion.Val(ListBox2.SelectedItem)
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
            'TextBox9.Text = Nothing
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
            'Label44.Text = Conversion.Val(Label431.Text) - Conversion.Val(Label41.Text)
            count = dash
        End If
    End Sub

    Public Sub clear()
        'TextBox4.Text = Nothing
        'TextBox5.Text = Nothing
        'TextBox6.Text = Nothing
        'TextBox7.Text = Nothing
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
        'Label44.Text = Nothing
        'Label45.Text = Nothing
        ComboBox1.Text = Nothing
        TextBox2.Text = Nothing
        'Label47.Text = Nothing
        'ComboBox2.Text = Nothing

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If ListBox1.Items.Count = 0 Then
            MsgBox("Add Items To Your Cart To Proceed", MsgBoxStyle.Critical)
        Else
            Sledger_insert()
            If Conversion.Val(rinv) - Math.Round(Conversion.Val(TextBox8.Text)) = 0 Then
                delete1()
                delete()
                refunfentrey()
            Else
                updatesale()
                updatesale1()
                refunfentrey()
            End If
        End If
    End Sub
    Public Sub delete()
        Try
            con.Open()
            str = "Delete From Sales Where CustomerName=@Nme"
            cmd = New OleDbCommand(str, con)
            cmd.Parameters.AddWithValue("@Nme", rnamecpy)
            cmd.ExecuteNonQuery()
            TextBox1.Text = Nothing
        Catch ex As Exception
            MsgBox("An Error Was Generated Please Try Again", MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub delete1()
        Try
            con.Open()
            str = "Delete From SaleJournalCr Where CrName=@Nme"
            cmd = New OleDbCommand(str, con)
            cmd.Parameters.AddWithValue("@Nme", rnamecpy)
            cmd.ExecuteNonQuery()
            TextBox1.Text = Nothing
        Catch ex As Exception
            MsgBox("An Error Was Generated Please Try Again", MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub updatesale()
        Try
            con.Open()
            Dim l1 As Integer
            l1 = Conversion.Val(rinv) - Math.Round(Conversion.Val(TextBox8.Text))
            Dim cb As String = "update [Sales] set [InvoiceValue]='" & l1 & "'Where [CustomerName]='" & Label29.Text & "'"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            MsgBox("Sales Updated")
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Close()
        Catch ex As Exception
            MsgBox("Error", ex.Message)
        End Try
    End Sub
    Public Sub updatesale1()
        Try
            con.Open()
            Dim l1 As Integer
            l1 = Conversion.Val(rinv) - Math.Round(Conversion.Val(TextBox8.Text))
            Dim cb As String = "update [SaleJournalCr] set [CrAmount]='" & l1 & "'Where [CrName]='" & Label29.Text & "'"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            MsgBox("Sales Updated")
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Close()
        Catch ex As Exception
            MsgBox("Error", ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MDIParent1.Show()
        Me.Close()
    End Sub

    Private Sub Label41_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label41.TextChanged
        TextBox8.Text = Conversion.Val(Label41.Text) * 1.025
    End Sub
    Public Sub refunfentrey()
        Try
            con.Open()
            cmd = New OleDbCommand("Insert Into RefundNew(CustomerNameR,MobileNoR,AddressR,dateR,RemarkR,InvoiceValueR,DescriptionR) values('" + Label29.Text + "','" + Label50.Text + "','" + Label30.Text + "','" + DateTimePicker1.Text + "','" + Label19.Text + "','" + TextBox8.Text + "','" + TextBox3.Text + "')", con)
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
    End Sub

    Public Sub Sledger_insert()
        'Sale_Ledger.ListBox4.Items.Add(DateTimePicker1.Text)
        'Sale_Ledger.ListBox5.Items.Add("BY " & Label29.Text)
        'Sale_Ledger.ListBox6.Items.Add(TextBox8.Text)
        Try
            con.Close()
            con.Open()
            cmd = New OleDbCommand("Insert Into SaleJournalDr(DrDate,DrName,DrAmount) values('" + DateTimePicker1.Text + "','" + Label29.Text + "','" + TextBox8.Text + "')", con)
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
    Public Sub check()
        If rinv - Conversion.Val(TextBox8.Text) < 1 Then
            ComboBox1.Hide()
            TextBox2.Hide()
            Label23.Hide()
            Label24.Hide()
            Button3.Hide()
        Else
            ComboBox1.Show()
            TextBox2.Show()
            Label23.Show()
            Label24.Show()
            Button3.Show()
        End If
    End Sub
    'Public Sub check2()
    '    If Conversion.Val(TextBox8.Text) + sum1 > rinv Then
    '        MsgBox("Refund Value Exceeded Invoice Value", MsgBoxStyle.Critical)
    '        ComboBox1.Text = Nothing
    '        TextBox2.Text = Nothing
    '        sum1 = 0
    '    Else
    '        ComboBox1.Show()
    '        TextBox2.Show()
    '        Label23.Show()
    '        Label24.Show()
    '        Button3.Show()
    '    End If
    'End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        up()
    End Sub
End Class