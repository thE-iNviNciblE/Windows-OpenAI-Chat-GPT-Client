Public Class frmAPIKEY
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ' My.Settings.openai_api_key = TextBox1.Text
        'My.Settings.Save()
    End Sub

    Private Sub frmAPIKEY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '   TextBox1.Text = My.Settings.openai_api_key

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim proc As New Process
        proc.Start("https://platform.openai.com/account/api-keys")
    End Sub
End Class