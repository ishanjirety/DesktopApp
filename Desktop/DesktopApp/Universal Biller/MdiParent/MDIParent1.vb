Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class MDIParent1
    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub MDIParent1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        datecompare()
        Chart1.Hide()
        Chart2.Hide()
        Chart3.Hide()
        ToolStripStatusLabel1.Text = login & " Logged In"
        Me.RefundNewTableAdapter.Fill(Me.BillingDataSet4.RefundNew)
        Me.UnpaidTableAdapter.Fill(Me.BillingDataSet3.Unpaid)
        Me.SalesTableAdapter1.Fill(Me.BillingDataSet2.Sales)
    End Sub
    Public d1 As String
    Public d2 As String
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Dim res As Integer = MessageBox.Show("Do You Want To Exit ?", "Universal Biller", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If res = DialogResult.No Then
        ElseIf res = DialogResult.Yes Then
            LoginForm1.Show()
            Me.Close()
        End If
    End Sub
    Private Sub SalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesToolStripMenuItem.Click
        Sales.Show()
        Me.Close()
    End Sub

    Private Sub UnpaidToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnpaidToolStripMenuItem.Click
        Unpaid.Show()
        Me.Close()
    End Sub

    Private Sub RetailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetailToolStripMenuItem.Click
        Retail2.Show()
        Me.Close()
    End Sub
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Chart2.Show()
        Chart1.Hide()
        Chart3.Hide()
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        Chart3.Show()
        Chart1.Hide()
        Chart2.Hide()
    End Sub

    Private Sub RadioButton2_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Chart1.Show()
        Chart2.Hide()
        Chart3.Hide()
    End Sub

    Private Sub RefundToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefundToolStripMenuItem.Click
        Refund_Details.Show()
        Me.Close()

    End Sub

    Private Sub ChallanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChallanToolStripMenuItem.Click
        Challan_History.Show()
        Me.Close()
    End Sub

    Private Sub StoreDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StoreDetailsToolStripMenuItem.Click
        Add_Details.Show()
        Me.Close()
    End Sub

    Private Sub SalesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesToolStripMenuItem1.Click
        Sale_Ledger.Show()
        Me.Close()
    End Sub

    Private Sub DebitorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DebitorToolStripMenuItem.Click
        Sales_Return_Ledger.Show()
        Me.Close()
    End Sub

    Private Sub UpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateToolStripMenuItem.Click
        Stock_Update.Show()
        Me.Close()
    End Sub

    Private Sub DetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetailsToolStripMenuItem.Click
        Inventory.Show()
        Me.Close()
    End Sub
    Public Sub datecompare()
        d1 = DateTimePicker1.Text
        con.Close()
        con.Open()
        str = "select * From Products"
        cmd = New OleDbCommand(str, con)
        da.SelectCommand = cmd
        da.Fill(ds, "Products")
        Dim name As String
        Dim a As Integer = ds.Tables("Products").Rows.Count - 1
        For i As Integer = 0 To a
            d2 = ds.Tables("Products").Rows(i)(5).ToString
            name = ds.Tables("Products").Rows(i)(1).ToString
            If d1 = d2 Then
                Dim res As Integer = MsgBox("Product ''" & name & "'' in inventory has expired Today Do You Want To Remove That Item From Your Inventory?", MsgBoxStyle.YesNo)
                If res = DialogResult.No Then
                ElseIf res = DialogResult.Yes Then
                    Inventory.TextBox1.Text = name
                    Inventory.Button1.PerformClick()
                    Inventory.Show()
                    Me.Close()
                End If
            End If
        Next
        Me.Refresh()
        con.Close()
        ds.Clear()

    End Sub

    Private Sub PurchaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseToolStripMenuItem.Click

    End Sub

    Private Sub UpdateStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateStockToolStripMenuItem.Click
        Quantity_Update.Show()

    End Sub

    Private Sub DebitorsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DebitorsToolStripMenuItem.Click
        Debitors.Show()
        Me.Close()
    End Sub
End Class
