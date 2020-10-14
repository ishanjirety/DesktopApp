Imports System.Data.OleDb
Public Class Quantity_Update
    Private Sub ComboBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.TextChanged, ComboBox2.TextChanged
        If ComboBox1.Text = Nothing Then
            Panel1.Hide()
            Panel2.Hide()
            Panel3.Hide()
            Panel4.Hide()
            Panel5.Hide()
            Panel6.Hide()
            Panel7.Hide()
            Panel8.Hide()
            Panel9.Hide()
        End If
        If ComboBox1.Text = "Expiry " Then
            hde()
            Panel1.Show()
        ElseIf ComboBox1.Text = "M.F.G" Then
            hde()
            Panel2.Show()
        ElseIf ComboBox1.Text = "Batch No." Then
            hde()
            Panel3.Show()
        ElseIf ComboBox1.Text = "Price" Then
            hde()
            Panel4.Show()
        ElseIf ComboBox1.Text = "Discount " Then
            hde()
            Panel5.Show()
        ElseIf ComboBox1.Text = "Name" Then
            hde()
            Panel6.Show()
        ElseIf ComboBox1.Text = "Company" Then
            hde()
            Panel7.Show()
        ElseIf ComboBox1.Text = "Cost Price" Then
            hde()
            Panel8.Show()
        ElseIf ComboBox1.Text = "Quantity" Then
            hde()
            Panel9.Show()
        Else
            If ComboBox1.Text = Nothing Then
            Else
                MsgBox("Please Choose From Drop Down", MsgBoxStyle.Information)
                ComboBox1.Text = Nothing
            End If
        End If
    End Sub

    Private Sub Quantity_Update_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Clear()
        hde()
        Prdctname()
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        PrdtNamechng()
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        prdtcostchng()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        prdtexpirychng()
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        prdtdischng()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        prdtMFGchng()
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        prdtCmPnychng()
    End Sub
    Public Sub refrsh()
        Prdctname()
    End Sub
    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        prdtRatechng()
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        prdtBatchchng()
    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        prdtQuanchng()
    End Sub
    Public Sub Clear()
        ComboBox2.Items.Clear()
        ComboBox3.Items.Clear()
        ComboBox4.Items.Clear()
        ComboBox5.Items.Clear()
        ComboBox6.Items.Clear()
        ComboBox7.Items.Clear()
        ComboBox8.Items.Clear()
        ComboBox9.Items.Clear()
        ComboBox10.Items.Clear()
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
            ComboBox2.Items.Add(ds.Tables("Products").Rows(i)(1).ToString())
            ComboBox3.Items.Add(ds.Tables("Products").Rows(i)(1).ToString())
            ComboBox4.Items.Add(ds.Tables("Products").Rows(i)(1).ToString())
            ComboBox5.Items.Add(ds.Tables("Products").Rows(i)(1).ToString())
            ComboBox6.Items.Add(ds.Tables("Products").Rows(i)(1).ToString())
            ComboBox7.Items.Add(ds.Tables("Products").Rows(i)(1).ToString())
            ComboBox8.Items.Add(ds.Tables("Products").Rows(i)(1).ToString())
            ComboBox9.Items.Add(ds.Tables("Products").Rows(i)(1).ToString())
            ComboBox10.Items.Add(ds.Tables("Products").Rows(i)(1).ToString())
        Next
    End Sub
    Public Sub hde()
        Panel1.Hide()
        Panel2.Hide()
        Panel3.Hide()
        Panel4.Hide()
        Panel5.Hide()
        Panel6.Hide()
        Panel7.Hide()
        Panel8.Hide()
        Panel9.Hide()
    End Sub
    Public Sub PrdtNamechng()
        Try
            con.Close()
            con.Open()
            Dim cb As String = "update [Products] set [ProductName]='" & TextBox4.Text & "'Where [ProductName]='" & ComboBox3.Text & "'"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            MsgBox("Name Updated")
            ComboBox3.Text = Nothing
            TextBox4.Text = Nothing
            Clear()
            refrsh()
            hde()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Close()
        Catch ex As Exception
            MsgBox("Error", ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub prdtcostchng()
        Try
            con.Close()
            con.Open()
            Dim cb As String = "update [Products] set [CostPrice]='" & TextBox6.Text & "'Where [ProductName]='" & ComboBox2.Text & "'"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            MsgBox("Cost Updated")
            ComboBox3.Text = Nothing
            TextBox4.Text = Nothing
            Clear()
            refrsh()
            hde()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Close()
        Catch ex As Exception
            MsgBox("Error", ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub prdtexpirychng()
        Try
            con.Close()
            con.Open()
            Dim cb As String = "update [Products] set [Expiry]='" & DateTimePicker1.Text & "'Where [ProductName]='" & ComboBox6.Text & "'"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            MsgBox("Expiry Updated")
            ComboBox3.Text = Nothing
            TextBox4.Text = Nothing
            Clear()
            refrsh()
            hde()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Close()
        Catch ex As Exception
            MsgBox("Error", ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub prdtdischng()
        Try
            con.Close()
            con.Open()
            Dim cb As String = "update [Products] set [DiscountD]='" & TextBox3.Text & "'Where [ProductName]='" & ComboBox4.Text & "'"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            MsgBox("Discount Updated")
            ComboBox3.Text = Nothing
            TextBox4.Text = Nothing
            Clear()
            refrsh()
            hde()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Close()
        Catch ex As Exception
            MsgBox("Error", ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub prdtMFGchng()
        Try
            con.Close()
            con.Open()
            Dim cb As String = "update [Products] set [MFG]='" & DateTimePicker2.Text & "'Where [ProductName]='" & ComboBox5.Text & "'"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            MsgBox("MFG Updated")
            ComboBox3.Text = Nothing
            TextBox4.Text = Nothing
            Clear()
            refrsh()
            hde()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Close()
        Catch ex As Exception
            MsgBox("Error", ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub prdtRatechng()
        Try
            con.Close()
            con.Open()
            Dim cb As String = "update [Products] set [RateD]='" & TextBox2.Text & "'Where [ProductName]='" & ComboBox8.Text & "'"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            MsgBox("MRP Updated")
            ComboBox3.Text = Nothing
            TextBox4.Text = Nothing
            Clear()
            refrsh()
            hde()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Close()
        Catch ex As Exception
            MsgBox("Error", ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub prdtBatchchng()
        Try
            con.Close()
            con.Open()
            Dim cb As String = "update [Products] set [SerialNo]='" & TextBox1.Text & "'Where [ProductName]='" & ComboBox9.Text & "'"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            MsgBox("Batch No. Updated")
            ComboBox3.Text = Nothing
            TextBox4.Text = Nothing
            Clear()
            refrsh()
            hde()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Close()
        Catch ex As Exception
            MsgBox("Error", ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub prdtCmPnychng()
        Try
            con.Close()
            con.Open()
            Dim cb As String = "update [Products] set [Company]='" & TextBox5.Text & "'Where [ProductName]='" & ComboBox7.Text & "'"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            MsgBox("Company Name Updated")
            ComboBox3.Text = Nothing
            TextBox4.Text = Nothing
            Clear()
            refrsh()
            hde()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Close()
        Catch ex As Exception
            MsgBox("Error", ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub prdtQuanchng()
        Try
            con.Close()
            con.Open()
            Dim cb As String = "update [Products] set [Stock]='" & TextBox7.Text & "'Where [ProductName]='" & ComboBox10.Text & "'"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            MsgBox("Stock Updated")
            ComboBox10.Text = Nothing
            TextBox7.Text = Nothing
            Clear()
            refrsh()
            hde()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Close()
        Catch ex As Exception
            MsgBox("Error", ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        MDIParent1.Show()
        Me.Close()
    End Sub
End Class