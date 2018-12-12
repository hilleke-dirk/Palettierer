Public Class Manuell

    Dim fs_status() = {0, 0, 0, 0}
    Public paljpg As Bitmap


    Private Sub Bt_FS1_Click(sender As Object, e As EventArgs) Handles Bt_FS1.Click
        Switch_OP(Palettierer.OP_FS(0), Bt_FS1)
    End Sub
    Private Sub Bt_FS2_Click(sender As Object, e As EventArgs) Handles Bt_FS2.Click
        Switch_OP(Palettierer.OP_FS(1), Bt_FS2)
    End Sub
    Private Sub Bt_FS3_Click(sender As Object, e As EventArgs) Handles Bt_FS3.Click
        Switch_OP(Palettierer.OP_FS(2), Bt_FS3)
    End Sub
    Private Sub Bt_FS4_Click(sender As Object, e As EventArgs) Handles Bt_FS4.Click
        Switch_OP(Palettierer.OP_FS(3), Bt_FS4)
    End Sub

    Private Sub Palanzeige(IO As Integer, ByRef status As Integer, PB As PictureBox)
        Dim wert
        wert = Palettierer.ZMotion_IP(IO)
        If (wert = 0) And status = 1 Then
            status = 0
            PB.Visible = False
        ElseIf (wert <> 0) And status = 0 Then
            status = 1
            PB.Visible = True
        End If

    End Sub

    Private Sub IP_Anzeige(IO As Integer, twert As String, TB As TextBox)
        Dim wert
        Dim anzeige As String
        wert = Palettierer.ZMotion_IP(IO)
        If wert = 1 Then
            anzeige = twert
            TB.BackColor = Color.Lime
        Else
            anzeige = "nicht " + twert
            TB.BackColor = SystemColors.Control
        End If
        TB.Text = anzeige
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        '        Dim myGraphics As Graphics = Me.CreateGraphics
        Palanzeige(Palettierer.IP_FS(0), fs_status(0), PB_FS1)
        Palanzeige(Palettierer.IP_FS(1), fs_status(1), PB_FS2)
        Palanzeige(Palettierer.IP_FS(2), fs_status(2), PB_FS3)
        Palanzeige(Palettierer.IP_FS(3), fs_status(3), PB_FS4)

        IP_Anzeige(Palettierer.IP_KartonGreiferAuf, "auf", Tb_IP_KartongreiferAuf)
        IP_Anzeige(Palettierer.IP_KartonGreiferZu, "zu", Tb_IP_KartongreiferZu)
        IP_Anzeige(Palettierer.IP_MagOben, "oben", Tb_IP_MagHoch)
        IP_Anzeige(Palettierer.IP_MagUnten, "unten", Tb_IP_MagRunter)
        IP_Anzeige(Palettierer.IP_MagOffen, "offen", Tb_IP_MagGreifen)
        IP_Anzeige(Palettierer.IP_MagNopush, "zurück", Tb_IP_Push)
        IP_Anzeige(Palettierer.IP_KartonAnheben, "hoch", Tb_IP_KartonHoch)
        IP_Anzeige(Palettierer.IP_KartonDa, "da", Tb_IP_KartonDa)

    End Sub

    Private Sub Setze_Farbe_Op(IO As Integer, Bt As Button)
        Dim wert = 0
        ZAux_Direct_GetOp(Palettierer.g_handle, IO, wert)
        If (wert = 0) Then
            Bt.BackColor = SystemColors.Control
        Else
            Bt.BackColor = Color.Lime
        End If
    End Sub

    Private Sub Switch_OP(IO As Integer, bt As Button)
        Dim wert = 0
        ZAux_Direct_GetOp(Palettierer.g_handle, IO, wert)
        ZAux_Direct_SetOp(Palettierer.g_handle, IO, 1 - wert)
        Setze_Farbe_Op(IO, bt)
    End Sub


    Private Sub Manuell_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        paljpg = Bitmap.FromFile("Palette-klein.jpg")
        Timer1.Interval = 1000
        Timer1.Start()
        Setze_Farbe_Op(Palettierer.OP_KartonGreifen1, Bt_Greifer1)
        Setze_Farbe_Op(Palettierer.OP_FS(0), Bt_FS1)
        Setze_Farbe_Op(Palettierer.OP_FS(1), Bt_FS2)
        Setze_Farbe_Op(Palettierer.OP_FS(2), Bt_FS3)
        Setze_Farbe_Op(Palettierer.OP_FS(3), Bt_FS4)
        Setze_Farbe_Op(Palettierer.OP_KartonGreifen2, Bt_Greifer2)
        Setze_Farbe_Op(Palettierer.OP_MagGreifen, Bt_MagGreif)
        Setze_Farbe_Op(Palettierer.OP_MagPush, Bt_MagPush)
        Setze_Farbe_Op(Palettierer.OP_MagSenken, Bt_MagRunter)
        Setze_Farbe_Op(Palettierer.OP_MagSenken, Bt_MagRunter)
        Setze_Farbe_Op(Palettierer.OP_KartonAnheben, Bt_Kartonhoch)
    End Sub

    Private Sub Manuell_FormClosing(ByVal sender As Object,
                               ByVal e As System.Windows.Forms.FormClosingEventArgs
                                     ) Handles Me.FormClosing
        Timer1.Stop()

    End Sub

    Private Sub Bt_Greifer1_Click(sender As Object, e As EventArgs) Handles Bt_Greifer1.Click
        Switch_OP(Palettierer.OP_KartonGreifen1, Bt_Greifer1)
    End Sub

    Private Sub Bt_Greifer2_Click(sender As Object, e As EventArgs) Handles Bt_Greifer2.Click
        Switch_OP(Palettierer.OP_KartonGreifen2, Bt_Greifer2)
    End Sub

    Private Sub Bt_MagGreif_Click(sender As Object, e As EventArgs) Handles Bt_MagGreif.Click
        Switch_OP(Palettierer.OP_MagGreifen, Bt_MagGreif)
    End Sub

    Private Sub Bt_MagPush_Click(sender As Object, e As EventArgs) Handles Bt_MagPush.Click
        Switch_OP(Palettierer.OP_MagPush, Bt_MagPush)
    End Sub

    Private Sub Bt_MagHoch_Click(sender As Object, e As EventArgs) Handles Bt_MagHoch.Click
        If Bt_MagHoch.BackColor = SystemColors.Control And Bt_MagRunter.BackColor = Color.Lime Then 'Runter ist an und hoch ist aus
            Switch_OP(Palettierer.OP_MagSenken, Bt_MagRunter) 'dann muss Runter aus sein !!!
        End If
        Switch_OP(Palettierer.OP_MagHeben, Bt_MagHoch)
    End Sub

    Private Sub Bt_MagRunter_Click(sender As Object, e As EventArgs) Handles Bt_MagRunter.Click
        If Bt_MagRunter.BackColor = SystemColors.Control And Bt_MagHoch.BackColor = Color.Lime Then 'Hoch ist an und runter ist aus
            Switch_OP(Palettierer.OP_MagHeben, Bt_MagHoch) 'dann muss Hoch aus sein !!!
        End If
        Switch_OP(Palettierer.OP_MagSenken, Bt_MagRunter)
    End Sub

    Private Sub Bt_Kartonhoch_Click(sender As Object, e As EventArgs) Handles Bt_Kartonhoch.Click
        Switch_OP(Palettierer.OP_KartonAnheben, Bt_Kartonhoch)
    End Sub
End Class