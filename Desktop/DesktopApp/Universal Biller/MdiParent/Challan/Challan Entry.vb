Imports System.Data.OleDb
Public Class Challan_Entry

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click, Label7.Click, Label6.Click

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click, Label9.Click, Label8.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        challandetailFIll()
        tableEntry()
        Sale_Challan.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        clr()
        Dim res As Integer = MessageBox.Show("Do You Want To Exit This Page ?", "Universal Biller", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If res = DialogResult.No Then
        ElseIf res = DialogResult.Yes Then
            MDIParent1.Show()
            Me.Close()
        End If
    End Sub
    Public Sub clr()
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        TextBox3.Text = Nothing
        TextBox4.Text = Nothing
        TextBox5.Text = Nothing
        TextBox6.Text = Nothing
        TextBox7.Text = Nothing
    End Sub

    Private Sub Challan_Entry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        IDs()
        Sale_Challan.Label4.Text = Label15.Text
        Label19.Text = DateTimePicker1.Text
        DateTimePicker1.Hide()
    End Sub
    Public Sub IDs()
        con.Close()
        con.Open()
        cmd = New OleDbCommand("Select MAX(PKGID) from Challan", con)
        Dim dr As OleDbDataReader
        Try
            dr = cmd.ExecuteReader
            While dr.Read
                Dim cus As String = dr.GetValue(0)
                Label15.Text = cus
                Label14.Text = "00" & cus
            End While
        Catch ex As Exception
            MsgBox("Error", ex.Message)
        Finally
            con.Close()

        End Try
    End Sub
    Public Sub challandetailFIll()
        Sale_Challan.ListBox4.Items.Add(TextBox1.Text)
        Sale_Challan.ListBox4.Items.Add("GSTIN " & TextBox3.Text)
        Sale_Challan.ListBox4.Items.Add(TextBox4.Text)
        Sale_Challan.ListBox4.Items.Add(TextBox5.Text)
        Sale_Challan.ListBox7.Items.Add(TextBox6.Text)
        Sale_Challan.ListBox7.Items.Add("GSTIN " & TextBox7.Text)
        Sale_Challan.ListBox6.Items.Add("No. Of Carton " & TextBox8.Text)
        Sale_Challan.ListBox6.Items.Add("No. Of Packets" & TextBox9.Text)
        Sale_Challan.Label17.Text = TextBox1.Text
        Sale_Challan.Label16.Text = TextBox8.Text
        Sale_Challan.Label6.Text = TextBox9.Text
        Sale_Challan.Label19.Text = Label19.Text
    End Sub
    Public Sub tableEntry()
        Try
            con.Close()
            con.Open()
            cmd = New OleDbCommand("Insert Into Challan(ORDID,NameCus,AddressCus,GSTINCus,EmailIDCus,PhoneCus,AddressWar,GSTINWar,Amount,NoPackets,NoCarton) values('" + Label14.Text + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + Label20.Text + "','" + TextBox8.Text + "','" + TextBox9.Text + "')", con)
            Dim i As Integer = cmd.ExecuteNonQuery
            If (i > 0) Then
                con.Close()
            Else
                MsgBox("Challan Cannot Be Generated", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox("Error", ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
End Class