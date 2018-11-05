Public Class Verbindung
    Public ip(4) As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ip(0) = Val(TextBox1.Text)
        ip(1) = Val(TextBox2.Text)
        ip(2) = Val(TextBox3.Text)
        ip(3) = Val(TextBox4.Text)
        Palettierer.g_handle = 0                                   'To link controller
        ZAux_OpenEth(ip(0) & "." & ip(1) & "." & ip(2) & "." & ip(3), Palettierer.g_handle)

        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        BackColor = Color.Snow
        Palettierer.g_handle = 0                                   'To link controller
        ZAux_OpenEth("127.0.0.1", Palettierer.g_handle)

        Me.Close()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class