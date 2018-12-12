<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Manuell
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Bt_FS1 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Bt_FS2 = New System.Windows.Forms.Button()
        Me.Bt_FS3 = New System.Windows.Forms.Button()
        Me.Bt_FS4 = New System.Windows.Forms.Button()
        Me.PB_FS1 = New System.Windows.Forms.PictureBox()
        Me.PB_FS2 = New System.Windows.Forms.PictureBox()
        Me.PB_FS3 = New System.Windows.Forms.PictureBox()
        Me.PB_FS4 = New System.Windows.Forms.PictureBox()
        Me.Bt_Kartonhoch = New System.Windows.Forms.Button()
        Me.Bt_Greifer1 = New System.Windows.Forms.Button()
        Me.Bt_Greifer2 = New System.Windows.Forms.Button()
        Me.Bt_MagHoch = New System.Windows.Forms.Button()
        Me.Bt_MagRunter = New System.Windows.Forms.Button()
        Me.Bt_MagGreif = New System.Windows.Forms.Button()
        Me.Bt_MagPush = New System.Windows.Forms.Button()
        Me.Tb_IP_KartongreiferAuf = New System.Windows.Forms.TextBox()
        Me.Tb_IP_Push = New System.Windows.Forms.TextBox()
        Me.Tb_IP_MagHoch = New System.Windows.Forms.TextBox()
        Me.Tb_IP_MagRunter = New System.Windows.Forms.TextBox()
        Me.Tb_IP_MagGreifen = New System.Windows.Forms.TextBox()
        Me.Tb_IP_KartonHoch = New System.Windows.Forms.TextBox()
        Me.Tb_IP_KartongreiferZu = New System.Windows.Forms.TextBox()
        Me.Tb_IP_KartonDa = New System.Windows.Forms.TextBox()
        CType(Me.PB_FS1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_FS2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_FS3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_FS4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bt_FS1
        '
        Me.Bt_FS1.Location = New System.Drawing.Point(271, 308)
        Me.Bt_FS1.Name = "Bt_FS1"
        Me.Bt_FS1.Size = New System.Drawing.Size(93, 53)
        Me.Bt_FS1.TabIndex = 0
        Me.Bt_FS1.Text = "Förderstrecke 1"
        Me.Bt_FS1.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'Bt_FS2
        '
        Me.Bt_FS2.Location = New System.Drawing.Point(370, 308)
        Me.Bt_FS2.Name = "Bt_FS2"
        Me.Bt_FS2.Size = New System.Drawing.Size(93, 53)
        Me.Bt_FS2.TabIndex = 1
        Me.Bt_FS2.Text = "Förderstrecke 2"
        Me.Bt_FS2.UseVisualStyleBackColor = True
        '
        'Bt_FS3
        '
        Me.Bt_FS3.Location = New System.Drawing.Point(469, 308)
        Me.Bt_FS3.Name = "Bt_FS3"
        Me.Bt_FS3.Size = New System.Drawing.Size(93, 53)
        Me.Bt_FS3.TabIndex = 2
        Me.Bt_FS3.Text = "Förderstrecke 3"
        Me.Bt_FS3.UseVisualStyleBackColor = True
        '
        'Bt_FS4
        '
        Me.Bt_FS4.Location = New System.Drawing.Point(568, 308)
        Me.Bt_FS4.Name = "Bt_FS4"
        Me.Bt_FS4.Size = New System.Drawing.Size(93, 53)
        Me.Bt_FS4.TabIndex = 3
        Me.Bt_FS4.Text = "Förderstrecke 4"
        Me.Bt_FS4.UseVisualStyleBackColor = True
        '
        'PB_FS1
        '
        Me.PB_FS1.Image = Global.WindowsApplication1.My.Resources.Resources.Palette_klein
        Me.PB_FS1.InitialImage = Nothing
        Me.PB_FS1.Location = New System.Drawing.Point(275, 252)
        Me.PB_FS1.Name = "PB_FS1"
        Me.PB_FS1.Size = New System.Drawing.Size(89, 50)
        Me.PB_FS1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PB_FS1.TabIndex = 4
        Me.PB_FS1.TabStop = False
        Me.PB_FS1.Visible = False
        '
        'PB_FS2
        '
        Me.PB_FS2.Image = Global.WindowsApplication1.My.Resources.Resources.Palette_klein
        Me.PB_FS2.Location = New System.Drawing.Point(374, 252)
        Me.PB_FS2.Name = "PB_FS2"
        Me.PB_FS2.Size = New System.Drawing.Size(89, 50)
        Me.PB_FS2.TabIndex = 5
        Me.PB_FS2.TabStop = False
        Me.PB_FS2.Visible = False
        '
        'PB_FS3
        '
        Me.PB_FS3.Image = Global.WindowsApplication1.My.Resources.Resources.Palette_klein
        Me.PB_FS3.Location = New System.Drawing.Point(473, 252)
        Me.PB_FS3.Name = "PB_FS3"
        Me.PB_FS3.Size = New System.Drawing.Size(89, 50)
        Me.PB_FS3.TabIndex = 6
        Me.PB_FS3.TabStop = False
        Me.PB_FS3.Visible = False
        '
        'PB_FS4
        '
        Me.PB_FS4.Image = Global.WindowsApplication1.My.Resources.Resources.Palette_klein
        Me.PB_FS4.Location = New System.Drawing.Point(572, 252)
        Me.PB_FS4.Name = "PB_FS4"
        Me.PB_FS4.Size = New System.Drawing.Size(89, 50)
        Me.PB_FS4.TabIndex = 7
        Me.PB_FS4.TabStop = False
        Me.PB_FS4.Visible = False
        '
        'Bt_Kartonhoch
        '
        Me.Bt_Kartonhoch.Location = New System.Drawing.Point(73, 373)
        Me.Bt_Kartonhoch.Name = "Bt_Kartonhoch"
        Me.Bt_Kartonhoch.Size = New System.Drawing.Size(93, 53)
        Me.Bt_Kartonhoch.TabIndex = 8
        Me.Bt_Kartonhoch.Text = "Karton hoch"
        Me.Bt_Kartonhoch.UseVisualStyleBackColor = True
        '
        'Bt_Greifer1
        '
        Me.Bt_Greifer1.Location = New System.Drawing.Point(36, 249)
        Me.Bt_Greifer1.Name = "Bt_Greifer1"
        Me.Bt_Greifer1.Size = New System.Drawing.Size(93, 53)
        Me.Bt_Greifer1.TabIndex = 9
        Me.Bt_Greifer1.Text = "Greifer 1"
        Me.Bt_Greifer1.UseVisualStyleBackColor = True
        '
        'Bt_Greifer2
        '
        Me.Bt_Greifer2.Location = New System.Drawing.Point(154, 249)
        Me.Bt_Greifer2.Name = "Bt_Greifer2"
        Me.Bt_Greifer2.Size = New System.Drawing.Size(93, 53)
        Me.Bt_Greifer2.TabIndex = 10
        Me.Bt_Greifer2.Text = "Greifer 2"
        Me.Bt_Greifer2.UseVisualStyleBackColor = True
        '
        'Bt_MagHoch
        '
        Me.Bt_MagHoch.Location = New System.Drawing.Point(36, 28)
        Me.Bt_MagHoch.Name = "Bt_MagHoch"
        Me.Bt_MagHoch.Size = New System.Drawing.Size(93, 53)
        Me.Bt_MagHoch.TabIndex = 11
        Me.Bt_MagHoch.Text = "Magazin hoch"
        Me.Bt_MagHoch.UseVisualStyleBackColor = True
        '
        'Bt_MagRunter
        '
        Me.Bt_MagRunter.Location = New System.Drawing.Point(36, 112)
        Me.Bt_MagRunter.Name = "Bt_MagRunter"
        Me.Bt_MagRunter.Size = New System.Drawing.Size(93, 53)
        Me.Bt_MagRunter.TabIndex = 12
        Me.Bt_MagRunter.Text = "Magazin runter"
        Me.Bt_MagRunter.UseVisualStyleBackColor = True
        '
        'Bt_MagGreif
        '
        Me.Bt_MagGreif.Location = New System.Drawing.Point(206, 65)
        Me.Bt_MagGreif.Name = "Bt_MagGreif"
        Me.Bt_MagGreif.Size = New System.Drawing.Size(93, 53)
        Me.Bt_MagGreif.TabIndex = 13
        Me.Bt_MagGreif.Text = "Magazin Greifer"
        Me.Bt_MagGreif.UseVisualStyleBackColor = True
        '
        'Bt_MagPush
        '
        Me.Bt_MagPush.Location = New System.Drawing.Point(271, 151)
        Me.Bt_MagPush.Name = "Bt_MagPush"
        Me.Bt_MagPush.Size = New System.Drawing.Size(93, 53)
        Me.Bt_MagPush.TabIndex = 14
        Me.Bt_MagPush.Text = "Paletten Schieber"
        Me.Bt_MagPush.UseVisualStyleBackColor = True
        '
        'Tb_IP_KartongreiferAuf
        '
        Me.Tb_IP_KartongreiferAuf.Location = New System.Drawing.Point(55, 223)
        Me.Tb_IP_KartongreiferAuf.Name = "Tb_IP_KartongreiferAuf"
        Me.Tb_IP_KartongreiferAuf.Size = New System.Drawing.Size(93, 20)
        Me.Tb_IP_KartongreiferAuf.TabIndex = 15
        Me.Tb_IP_KartongreiferAuf.Text = "Auf"
        Me.Tb_IP_KartongreiferAuf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Tb_IP_Push
        '
        Me.Tb_IP_Push.Location = New System.Drawing.Point(271, 124)
        Me.Tb_IP_Push.Name = "Tb_IP_Push"
        Me.Tb_IP_Push.Size = New System.Drawing.Size(93, 20)
        Me.Tb_IP_Push.TabIndex = 16
        Me.Tb_IP_Push.Text = "zurück"
        Me.Tb_IP_Push.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Tb_IP_MagHoch
        '
        Me.Tb_IP_MagHoch.Location = New System.Drawing.Point(36, 2)
        Me.Tb_IP_MagHoch.Name = "Tb_IP_MagHoch"
        Me.Tb_IP_MagHoch.Size = New System.Drawing.Size(93, 20)
        Me.Tb_IP_MagHoch.TabIndex = 17
        Me.Tb_IP_MagHoch.Text = "hoch"
        Me.Tb_IP_MagHoch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Tb_IP_MagRunter
        '
        Me.Tb_IP_MagRunter.Location = New System.Drawing.Point(36, 86)
        Me.Tb_IP_MagRunter.Name = "Tb_IP_MagRunter"
        Me.Tb_IP_MagRunter.Size = New System.Drawing.Size(93, 20)
        Me.Tb_IP_MagRunter.TabIndex = 18
        Me.Tb_IP_MagRunter.Text = "runter"
        Me.Tb_IP_MagRunter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Tb_IP_MagGreifen
        '
        Me.Tb_IP_MagGreifen.Location = New System.Drawing.Point(206, 39)
        Me.Tb_IP_MagGreifen.Name = "Tb_IP_MagGreifen"
        Me.Tb_IP_MagGreifen.Size = New System.Drawing.Size(93, 20)
        Me.Tb_IP_MagGreifen.TabIndex = 19
        Me.Tb_IP_MagGreifen.Text = "offen"
        Me.Tb_IP_MagGreifen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Tb_IP_KartonHoch
        '
        Me.Tb_IP_KartonHoch.Location = New System.Drawing.Point(73, 432)
        Me.Tb_IP_KartonHoch.Name = "Tb_IP_KartonHoch"
        Me.Tb_IP_KartonHoch.Size = New System.Drawing.Size(93, 20)
        Me.Tb_IP_KartonHoch.TabIndex = 20
        Me.Tb_IP_KartonHoch.Text = "hoch"
        Me.Tb_IP_KartonHoch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Tb_IP_KartongreiferZu
        '
        Me.Tb_IP_KartongreiferZu.Location = New System.Drawing.Point(154, 223)
        Me.Tb_IP_KartongreiferZu.Name = "Tb_IP_KartongreiferZu"
        Me.Tb_IP_KartongreiferZu.Size = New System.Drawing.Size(93, 20)
        Me.Tb_IP_KartongreiferZu.TabIndex = 21
        Me.Tb_IP_KartongreiferZu.Text = "Zu"
        Me.Tb_IP_KartongreiferZu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Tb_IP_KartonDa
        '
        Me.Tb_IP_KartonDa.Location = New System.Drawing.Point(73, 325)
        Me.Tb_IP_KartonDa.Multiline = True
        Me.Tb_IP_KartonDa.Name = "Tb_IP_KartonDa"
        Me.Tb_IP_KartonDa.Size = New System.Drawing.Size(93, 42)
        Me.Tb_IP_KartonDa.TabIndex = 22
        Me.Tb_IP_KartonDa.Text = "da"
        Me.Tb_IP_KartonDa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Manuell
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 459)
        Me.Controls.Add(Me.Tb_IP_KartonDa)
        Me.Controls.Add(Me.Tb_IP_KartongreiferZu)
        Me.Controls.Add(Me.Tb_IP_KartonHoch)
        Me.Controls.Add(Me.Tb_IP_MagGreifen)
        Me.Controls.Add(Me.Tb_IP_MagRunter)
        Me.Controls.Add(Me.Tb_IP_MagHoch)
        Me.Controls.Add(Me.Tb_IP_Push)
        Me.Controls.Add(Me.Tb_IP_KartongreiferAuf)
        Me.Controls.Add(Me.Bt_MagPush)
        Me.Controls.Add(Me.Bt_MagGreif)
        Me.Controls.Add(Me.Bt_MagRunter)
        Me.Controls.Add(Me.Bt_MagHoch)
        Me.Controls.Add(Me.Bt_Greifer2)
        Me.Controls.Add(Me.Bt_Greifer1)
        Me.Controls.Add(Me.Bt_Kartonhoch)
        Me.Controls.Add(Me.PB_FS4)
        Me.Controls.Add(Me.PB_FS3)
        Me.Controls.Add(Me.PB_FS2)
        Me.Controls.Add(Me.PB_FS1)
        Me.Controls.Add(Me.Bt_FS4)
        Me.Controls.Add(Me.Bt_FS3)
        Me.Controls.Add(Me.Bt_FS2)
        Me.Controls.Add(Me.Bt_FS1)
        Me.Name = "Manuell"
        Me.Text = "Manuell"
        CType(Me.PB_FS1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_FS2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_FS3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_FS4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Bt_FS1 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Bt_FS2 As Button
    Friend WithEvents Bt_FS3 As Button
    Friend WithEvents Bt_FS4 As Button
    Friend WithEvents PB_FS1 As PictureBox
    Friend WithEvents PB_FS2 As PictureBox
    Friend WithEvents PB_FS3 As PictureBox
    Friend WithEvents PB_FS4 As PictureBox
    Friend WithEvents Bt_Kartonhoch As Button
    Friend WithEvents Bt_Greifer1 As Button
    Friend WithEvents Bt_Greifer2 As Button
    Friend WithEvents Bt_MagHoch As Button
    Friend WithEvents Bt_MagRunter As Button
    Friend WithEvents Bt_MagGreif As Button
    Friend WithEvents Bt_MagPush As Button
    Friend WithEvents Tb_IP_KartongreiferAuf As TextBox
    Friend WithEvents Tb_IP_Push As TextBox
    Friend WithEvents Tb_IP_MagHoch As TextBox
    Friend WithEvents Tb_IP_MagRunter As TextBox
    Friend WithEvents Tb_IP_MagGreifen As TextBox
    Friend WithEvents Tb_IP_KartonHoch As TextBox
    Friend WithEvents Tb_IP_KartongreiferZu As TextBox
    Friend WithEvents Tb_IP_KartonDa As TextBox
End Class
