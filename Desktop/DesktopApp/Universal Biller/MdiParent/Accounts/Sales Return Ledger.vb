Imports System.Data.OleDb
Public Class Sales_Return_Ledger

    Private Sub Sales_Return_Ledger_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        ListBox5.Items.Clear()
        ListBox6.Items.Clear()
        ds.Clear()
        Button2.PerformClick()
    End Sub
    Public Sub Up1()
        con.Close()
        con.Open()
        str = "select * From SaleJournalDr "
        cmd = New OleDbCommand(str, con)
        da.SelectCommand = cmd
        da.Fill(ds, "SaleJournalDr")
        Dim a As Integer = ds.Tables("SaleJournalDr").Rows.Count - 1
        For i As Integer = 0 To a
            ListBox1.Items.Add(ds.Tables("SaleJournalDr").Rows(i)(1).ToString())
            ListBox2.Items.Add("To " & ds.Tables("SaleJournalDr").Rows(i)(2).ToString())
            ListBox3.Items.Add(ds.Tables("SaleJournalDr").Rows(i)(3).ToString())
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MDIParent1.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Up1()
    End Sub
End Class