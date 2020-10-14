Imports System.Data
Imports System.Data.OleDb

Public Class LoginForm1

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If UsernameTextBox.Text = "" Then
            MessageBox.Show("Username Field Cannot Be Empty", "Billing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            UsernameTextBox.Focus()
        ElseIf PasswordTextBox.Text = "" Then
            MessageBox.Show("Password Field Cannot Be Empty", "Billing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PasswordTextBox.Focus()
        Else
            con.Open()
            cmd = New OleDbCommand("Select * From login where Username='" + UsernameTextBox.Text + "'and Password='" + PasswordTextBox.Text + "'", con)
            da = New OleDbDataAdapter(cmd)
            ds = New Data.DataSet
            da.Fill(ds)
            Dim i As Integer
            i = ds.Tables(0).Rows.Count
            If i = 0 Then
                MsgBox("Login Failed Check Your Username/Password", MsgBoxStyle.Critical)
                con.Close()
            Else
                login = UsernameTextBox.Text
                con.Close()
                MDIParent1.Show()
                Me.Close()

            End If
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Beep()
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub LoginForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
