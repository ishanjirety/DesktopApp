Imports System.Data.OleDb
Public Class Sale_Ledger
    Public looprun As Integer
    Private Sub Sale_Ledger_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        ListBox5.Items.Clear()
        ListBox6.Items.Clear()
        ds.Clear()
        Up()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        ListBox5.Items.Clear()
        ListBox6.Items.Clear()
        ds.Clear()
        MDIParent1.Show()
        Me.Close()
    End Sub
    Public Sub Up()
        con.Close()
        con.Open()
        str = "select * From SaleJournalCr "
        cmd = New OleDbCommand(str, con)
        da.SelectCommand = cmd
        da.Fill(ds, "SaleJournalCr")
        Dim a As Integer = ds.Tables("SaleJournalCr").Rows.Count - 1
        For i As Integer = 0 To a
            ListBox4.Items.Add(ds.Tables("SaleJournalCr").Rows(i)(1).ToString())
            ListBox5.Items.Add("By " & ds.Tables("SaleJournalCr").Rows(i)(2).ToString())
            ListBox6.Items.Add(ds.Tables("SaleJournalCr").Rows(i)(3).ToString())
        Next
    End Sub
    'Public Sub Up1()
    '    con.Close()
    '    con.Open()
    '    str = "select * From SaleJournalDr "
    '    cmd = New OleDbCommand(str, con)
    '    da.SelectCommand = cmd
    '    da.Fill(ds, "SaleJournalDr")
    '    Dim a As Integer = ds.Tables("SaleJournalDr").Rows.Count - 1
    '    For i As Integer = 0 To a
    '        ListBox1.Items.Add(ds.Tables("SaleJournalDr").Rows(i)(1).ToString())
    '        ListBox2.Items.Add("To " & ds.Tables("SaleJournalDr").Rows(i)(2).ToString())
    '        ListBox3.Items.Add(ds.Tables("SaleJournalDr").Rows(i)(3).ToString())
    '    Next
    'End Sub
End Class