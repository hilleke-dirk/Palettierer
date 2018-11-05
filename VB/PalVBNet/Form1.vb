Public Class Form1
    Dim piAxislist As Integer
    'Public g_handle As Integer         '当前使用的卡号
    Public g_axisnum As Long        '当前运动的轴号


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'BackColor = Color.Snow
        'g_handle = 0                                   '链接控制器
        'ZAux_OpenEth("192.168.0.11", g_handle)

        'If g_handle <> 0 Then
        '    MsgBox("Connected Successfully！", vbOKOnly, "Connection Status")
        '    Timer1.Enabled = True
        '    Timer1.Interval = 1000
        'Else
        '    MsgBox("Fail To Connect！", vbOKOnly, "Connection Status")
        'End If
        'TextBox4.Text = 1000
        'TextBox5.Text = 0
        'TextBox6.Text = 100
        'TextBox7.Text = 10000
        'TextBox8.Text = 10000
        'TextBox9.Text = 20
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim m_units As Single
        Dim m_lspeed As Single
        Dim m_speed As Single
        Dim m_acc As Single
        Dim m_dec As Single
        Dim m_sramp As Single
        Dim m_step As Single

        'm_units = Val(TextBox4.Text)     'units
        'm_lspeed = Val(TextBox5.Text)    'lspeed
        'm_speed = Val(TextBox6.Text)     'speed
        'm_acc = Val(TextBox7.Text)       'accel
        'm_dec = Val(TextBox8.Text)       'decel
        'm_sramp = Val(TextBox9.Text)     'sramp
        'm_step = Val(TextBox10.Text)     '寸动距离
        ''Zaux_Direct_Base(g_handle, g_axisnum, piAxislist)
        'ZAux_Direct_SetAtype(g_handle, g_axisnum, 1)
        'ZAux_Direct_SetUnits(g_handle, g_axisnum, m_units)
        'ZAux_Direct_SetLspeed(g_handle, g_axisnum, m_lspeed)
        'ZAux_Direct_SetSpeed(g_handle, g_axisnum, m_speed)
        'ZAux_Direct_SetAccel(g_handle, g_axisnum, m_acc)
        'ZAux_Direct_SetDecel(g_handle, g_axisnum, m_dec)
        'ZAux_Direct_SetSramp(g_handle, g_axisnum, m_sramp)
        'If RadioButton5.Checked Then  '点动
        '    If CheckBox1.Checked Then    '正向运动
        '        ZAux_Direct_Singl_Vmove(g_handle, g_axisnum, 1)
        '    Else    '负向运动
        '        ZAux_Direct_Singl_Vmove(g_handle, g_axisnum, -1)
        '    End If

        'Else    '寸动
        '    If CheckBox1.Checked Then    '正向运动
        '        ZAux_Direct_Singl_Move(g_handle, g_axisnum, m_step)
        '    Else    '负向运动
        '        ZAux_Direct_Singl_Move(g_handle, g_axisnum, -1 * m_step)
        '    End If
        'End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'ZAux_Direct_Singl_Cancel(g_handle, g_axisnum, 0)  'cancel  减速停止

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'ZAux_Direct_SetDpos(g_handle, g_axisnum, 0)   '位置清零
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim m_idle As Long
        Dim m_pos As Single
        Dim m_vsp As Single


        'ZAux_Direct_GetIfIdle(g_handle, g_axisnum, m_idle)
        'ZAux_Direct_GetDpos(g_handle, g_axisnum, m_pos)
        'ZAux_Direct_GetVpSpeed(g_handle, g_axisnum, m_vsp)

        If m_idle = 0 Then
            TextBox1.Text = "Operate"
        Else
            TextBox1.Text = "Stop"
        End If

        TextBox2.Text = Str(m_pos)
        TextBox3.Text = Str(m_vsp)


    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        g_axisnum = 0
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        g_axisnum = 1
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        g_axisnum = 2
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        g_axisnum = 3
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim frm2 As New Verbindung
        frm2.Text = "To Link Controller"
        Verbindung.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim frmPal As New Palettierer
        frmPal.Text = "Palettierer"
        Palettierer.Show()
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class
