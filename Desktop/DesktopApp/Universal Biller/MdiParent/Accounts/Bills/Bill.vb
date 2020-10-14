Imports System.Data.OleDb
Public Class BillB

    Private Sub BillB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label40.Text = NameB
        Label42.Text = addB
        Label44.Text = mobB
        Label38.Text = VOGB
        Label46.Text = tItemB
        Label48.Text = MdeB
        Label50.Text = Ysave
        Label21.Text = invB
        Label39.Text = invB
        Label36.Text = dateB
        '-----------------'
        con.Close()
        con.Open()
        cmd = New OleDbCommand(str, con)
        cmd.CommandText = "select * from StoreDetails"
        cmd.Prepare()
        Dim dr As OleDbDataReader = cmd.ExecuteReader()
        Try
            If dr.Read() Then
                Label1.Text = dr.GetValue(0)
                Label2.Text = dr.GetValue(1)
                Label6.Text = "Tel. :-" & dr.GetValue(2)
                Label52.Text = "Mob. :-" & dr.GetValue(4)
                Label51.Text = "Email ID :-" & dr.GetValue(3)
                Label53.Text = "GSTIN :-" & dr.GetValue(5)
            End If
        Catch ex As Exception
            MsgBox("Error", ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
End Class