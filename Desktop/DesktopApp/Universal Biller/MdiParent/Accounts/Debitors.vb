Imports System.Data.OleDb
Public Class Debitors

    Private Sub Debitors_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ds.Clear()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        dbtinfo()
    End Sub
    Public Sub dbtinfo()
        con.Close()
        con.Open()
        ds.Clear()
        str = "select * From Unpaid"
        cmd = New OleDbCommand(str, con)
        da.SelectCommand = cmd
        da.Fill(ds, "Unpaid")
        Dim a As Integer = ds.Tables("Unpaid").Rows.Count - 1
        For i As Integer = 0 To a
            ListBox1.Items.Add(ds.Tables("Unpaid").Rows(i)(3).ToString())
            ListBox2.Items.Add(ds.Tables("Unpaid").Rows(i)(0).ToString())
            ListBox3.Items.Add(ds.Tables("Unpaid").Rows(i)(5).ToString())
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MDIParent1.Show()
        Me.Close()
    End Sub
End Class