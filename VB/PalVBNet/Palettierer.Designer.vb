<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Palettierer
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Bt_1 = New System.Windows.Forms.Button()
        Me.Bt_2 = New System.Windows.Forms.Button()
        Me.Bt_3 = New System.Windows.Forms.Button()
        Me.Nud_P1_Lagen = New System.Windows.Forms.NumericUpDown()
        Me.La_Lagen = New System.Windows.Forms.Label()
        Me.Lab_Status = New System.Windows.Forms.Label()
        Me.LB_P1 = New System.Windows.Forms.ListBox()
        Me.La_P1_max_Lagen = New System.Windows.Forms.Label()
        Me.La_P1_max_Karton = New System.Windows.Forms.Label()
        Me.La_Karton = New System.Windows.Forms.Label()
        Me.Nud_P1_Karton = New System.Windows.Forms.NumericUpDown()
        Me.La_Pal_Soll = New System.Windows.Forms.Label()
        Me.Nud_P1_Pal_Soll = New System.Windows.Forms.NumericUpDown()
        Me.La_Pal_Ist = New System.Windows.Forms.Label()
        Me.La_P1_Pal_Ist = New System.Windows.Forms.Label()
        Me.CB_P1_aktiv = New System.Windows.Forms.CheckBox()
        Me.La_aktiv = New System.Windows.Forms.Label()
        Me.CB_P2_aktiv = New System.Windows.Forms.CheckBox()
        Me.La_P2_Pal_Ist = New System.Windows.Forms.Label()
        Me.Nud_P2_Pal_Soll = New System.Windows.Forms.NumericUpDown()
        Me.La_P2_max_Karton = New System.Windows.Forms.Label()
        Me.Nud_P2_Karton = New System.Windows.Forms.NumericUpDown()
        Me.La_P2_max_Lagen = New System.Windows.Forms.Label()
        Me.LB_P2 = New System.Windows.Forms.ListBox()
        Me.Nud_P2_Lagen = New System.Windows.Forms.NumericUpDown()
        Me.CB_P3_aktiv = New System.Windows.Forms.CheckBox()
        Me.La_P3_Pal_Ist = New System.Windows.Forms.Label()
        Me.Nud_P3_Pal_Soll = New System.Windows.Forms.NumericUpDown()
        Me.La_P3_max_Karton = New System.Windows.Forms.Label()
        Me.Nud_P3_Karton = New System.Windows.Forms.NumericUpDown()
        Me.La_P3_max_Lagen = New System.Windows.Forms.Label()
        Me.LB_P3 = New System.Windows.Forms.ListBox()
        Me.Nud_P3_Lagen = New System.Windows.Forms.NumericUpDown()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TimerAchsenstatus = New System.Windows.Forms.Timer(Me.components)
        Me.Tb_X_dpos = New System.Windows.Forms.TextBox()
        Me.Tb_X_speed = New System.Windows.Forms.TextBox()
        Me.Lb_Name_Achse = New System.Windows.Forms.Label()
        Me.Lb_Achse_Position = New System.Windows.Forms.Label()
        Me.Lb_Achse_Speed = New System.Windows.Forms.Label()
        Me.Tb_Y_speed = New System.Windows.Forms.TextBox()
        Me.Tb_Y_dpos = New System.Windows.Forms.TextBox()
        Me.Tb_Z_speed = New System.Windows.Forms.TextBox()
        Me.Tb_Z_dpos = New System.Windows.Forms.TextBox()
        Me.Tb_R_speed = New System.Windows.Forms.TextBox()
        Me.Tb_R_dpos = New System.Windows.Forms.TextBox()
        Me.La_akt_Lage = New System.Windows.Forms.Label()
        Me.La_akt_Karton = New System.Windows.Forms.Label()
        Me.CB_AX = New System.Windows.Forms.CheckBox()
        Me.CB_AY = New System.Windows.Forms.CheckBox()
        Me.CB_AZ = New System.Windows.Forms.CheckBox()
        Me.CB_AR = New System.Windows.Forms.CheckBox()
        CType(Me.Nud_P1_Lagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Nud_P1_Karton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Nud_P1_Pal_Soll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Nud_P2_Pal_Soll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Nud_P2_Karton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Nud_P2_Lagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Nud_P3_Pal_Soll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Nud_P3_Karton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Nud_P3_Lagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bt_1
        '
        Me.Bt_1.Location = New System.Drawing.Point(22, 86)
        Me.Bt_1.Name = "Bt_1"
        Me.Bt_1.Size = New System.Drawing.Size(104, 58)
        Me.Bt_1.TabIndex = 0
        Me.Bt_1.Text = "START"
        Me.Bt_1.UseVisualStyleBackColor = True
        '
        'Bt_2
        '
        Me.Bt_2.Location = New System.Drawing.Point(22, 150)
        Me.Bt_2.Name = "Bt_2"
        Me.Bt_2.Size = New System.Drawing.Size(104, 58)
        Me.Bt_2.TabIndex = 1
        Me.Bt_2.Text = "PAUSE"
        Me.Bt_2.UseVisualStyleBackColor = True
        '
        'Bt_3
        '
        Me.Bt_3.Location = New System.Drawing.Point(22, 214)
        Me.Bt_3.Name = "Bt_3"
        Me.Bt_3.Size = New System.Drawing.Size(104, 58)
        Me.Bt_3.TabIndex = 2
        Me.Bt_3.Text = "STOPP"
        Me.Bt_3.UseVisualStyleBackColor = True
        '
        'Nud_P1_Lagen
        '
        Me.Nud_P1_Lagen.Enabled = False
        Me.Nud_P1_Lagen.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nud_P1_Lagen.Location = New System.Drawing.Point(345, 86)
        Me.Nud_P1_Lagen.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.Nud_P1_Lagen.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Nud_P1_Lagen.Name = "Nud_P1_Lagen"
        Me.Nud_P1_Lagen.Size = New System.Drawing.Size(40, 44)
        Me.Nud_P1_Lagen.TabIndex = 3
        Me.Nud_P1_Lagen.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'La_Lagen
        '
        Me.La_Lagen.AutoSize = True
        Me.La_Lagen.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.La_Lagen.Location = New System.Drawing.Point(313, 54)
        Me.La_Lagen.Name = "La_Lagen"
        Me.La_Lagen.Size = New System.Drawing.Size(72, 26)
        Me.La_Lagen.TabIndex = 4
        Me.La_Lagen.Text = "Lagen"
        '
        'Lab_Status
        '
        Me.Lab_Status.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Lab_Status.CausesValidation = False
        Me.Lab_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lab_Status.Location = New System.Drawing.Point(18, 9)
        Me.Lab_Status.Name = "Lab_Status"
        Me.Lab_Status.Size = New System.Drawing.Size(270, 34)
        Me.Lab_Status.TabIndex = 11
        Me.Lab_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LB_P1
        '
        Me.LB_P1.Enabled = False
        Me.LB_P1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_P1.FormattingEnabled = True
        Me.LB_P1.ItemHeight = 24
        Me.LB_P1.Location = New System.Drawing.Point(202, 86)
        Me.LB_P1.Name = "LB_P1"
        Me.LB_P1.Size = New System.Drawing.Size(86, 28)
        Me.LB_P1.TabIndex = 12
        '
        'La_P1_max_Lagen
        '
        Me.La_P1_max_Lagen.AutoSize = True
        Me.La_P1_max_Lagen.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.La_P1_max_Lagen.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.La_P1_max_Lagen.Location = New System.Drawing.Point(321, 93)
        Me.La_P1_max_Lagen.Name = "La_P1_max_Lagen"
        Me.La_P1_max_Lagen.Size = New System.Drawing.Size(18, 20)
        Me.La_P1_max_Lagen.TabIndex = 13
        Me.La_P1_max_Lagen.Text = "3"
        '
        'La_P1_max_Karton
        '
        Me.La_P1_max_Karton.AutoSize = True
        Me.La_P1_max_Karton.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.La_P1_max_Karton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.La_P1_max_Karton.Location = New System.Drawing.Point(399, 93)
        Me.La_P1_max_Karton.Name = "La_P1_max_Karton"
        Me.La_P1_max_Karton.Size = New System.Drawing.Size(27, 20)
        Me.La_P1_max_Karton.TabIndex = 16
        Me.La_P1_max_Karton.Text = "30"
        '
        'La_Karton
        '
        Me.La_Karton.AutoSize = True
        Me.La_Karton.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.La_Karton.Location = New System.Drawing.Point(406, 54)
        Me.La_Karton.Name = "La_Karton"
        Me.La_Karton.Size = New System.Drawing.Size(87, 26)
        Me.La_Karton.TabIndex = 15
        Me.La_Karton.Text = "Kartons"
        '
        'Nud_P1_Karton
        '
        Me.Nud_P1_Karton.Enabled = False
        Me.Nud_P1_Karton.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nud_P1_Karton.Location = New System.Drawing.Point(432, 86)
        Me.Nud_P1_Karton.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.Nud_P1_Karton.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Nud_P1_Karton.Name = "Nud_P1_Karton"
        Me.Nud_P1_Karton.Size = New System.Drawing.Size(61, 44)
        Me.Nud_P1_Karton.TabIndex = 14
        Me.Nud_P1_Karton.Value = New Decimal(New Integer() {45, 0, 0, 0})
        '
        'La_Pal_Soll
        '
        Me.La_Pal_Soll.AutoSize = True
        Me.La_Pal_Soll.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.La_Pal_Soll.Location = New System.Drawing.Point(510, 54)
        Me.La_Pal_Soll.Name = "La_Pal_Soll"
        Me.La_Pal_Soll.Size = New System.Drawing.Size(92, 26)
        Me.La_Pal_Soll.TabIndex = 18
        Me.La_Pal_Soll.Text = "Paletten"
        '
        'Nud_P1_Pal_Soll
        '
        Me.Nud_P1_Pal_Soll.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nud_P1_Pal_Soll.Location = New System.Drawing.Point(536, 86)
        Me.Nud_P1_Pal_Soll.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.Nud_P1_Pal_Soll.Name = "Nud_P1_Pal_Soll"
        Me.Nud_P1_Pal_Soll.Size = New System.Drawing.Size(61, 44)
        Me.Nud_P1_Pal_Soll.TabIndex = 17
        Me.Nud_P1_Pal_Soll.Value = New Decimal(New Integer() {99, 0, 0, 0})
        '
        'La_Pal_Ist
        '
        Me.La_Pal_Ist.AutoSize = True
        Me.La_Pal_Ist.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.La_Pal_Ist.Location = New System.Drawing.Point(618, 54)
        Me.La_Pal_Ist.Name = "La_Pal_Ist"
        Me.La_Pal_Ist.Size = New System.Drawing.Size(88, 26)
        Me.La_Pal_Ist.TabIndex = 19
        Me.La_Pal_Ist.Text = "gepackt"
        '
        'La_P1_Pal_Ist
        '
        Me.La_P1_Pal_Ist.AutoSize = True
        Me.La_P1_Pal_Ist.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.La_P1_Pal_Ist.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.La_P1_Pal_Ist.Location = New System.Drawing.Point(639, 86)
        Me.La_P1_Pal_Ist.Name = "La_P1_Pal_Ist"
        Me.La_P1_Pal_Ist.Size = New System.Drawing.Size(35, 37)
        Me.La_P1_Pal_Ist.TabIndex = 20
        Me.La_P1_Pal_Ist.Text = "0"
        '
        'CB_P1_aktiv
        '
        Me.CB_P1_aktiv.AutoSize = True
        Me.CB_P1_aktiv.Enabled = False
        Me.CB_P1_aktiv.Location = New System.Drawing.Point(176, 95)
        Me.CB_P1_aktiv.Name = "CB_P1_aktiv"
        Me.CB_P1_aktiv.Size = New System.Drawing.Size(15, 14)
        Me.CB_P1_aktiv.TabIndex = 21
        Me.CB_P1_aktiv.UseVisualStyleBackColor = True
        '
        'La_aktiv
        '
        Me.La_aktiv.AutoSize = True
        Me.La_aktiv.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.La_aktiv.Location = New System.Drawing.Point(171, 54)
        Me.La_aktiv.Name = "La_aktiv"
        Me.La_aktiv.Size = New System.Drawing.Size(57, 26)
        Me.La_aktiv.TabIndex = 22
        Me.La_aktiv.Text = "aktiv"
        '
        'CB_P2_aktiv
        '
        Me.CB_P2_aktiv.AutoSize = True
        Me.CB_P2_aktiv.Enabled = False
        Me.CB_P2_aktiv.Location = New System.Drawing.Point(176, 159)
        Me.CB_P2_aktiv.Name = "CB_P2_aktiv"
        Me.CB_P2_aktiv.Size = New System.Drawing.Size(15, 14)
        Me.CB_P2_aktiv.TabIndex = 30
        Me.CB_P2_aktiv.UseVisualStyleBackColor = True
        '
        'La_P2_Pal_Ist
        '
        Me.La_P2_Pal_Ist.AutoSize = True
        Me.La_P2_Pal_Ist.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.La_P2_Pal_Ist.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.La_P2_Pal_Ist.Location = New System.Drawing.Point(639, 150)
        Me.La_P2_Pal_Ist.Name = "La_P2_Pal_Ist"
        Me.La_P2_Pal_Ist.Size = New System.Drawing.Size(35, 37)
        Me.La_P2_Pal_Ist.TabIndex = 29
        Me.La_P2_Pal_Ist.Text = "0"
        '
        'Nud_P2_Pal_Soll
        '
        Me.Nud_P2_Pal_Soll.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nud_P2_Pal_Soll.Location = New System.Drawing.Point(536, 150)
        Me.Nud_P2_Pal_Soll.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.Nud_P2_Pal_Soll.Name = "Nud_P2_Pal_Soll"
        Me.Nud_P2_Pal_Soll.Size = New System.Drawing.Size(61, 44)
        Me.Nud_P2_Pal_Soll.TabIndex = 28
        Me.Nud_P2_Pal_Soll.Value = New Decimal(New Integer() {99, 0, 0, 0})
        '
        'La_P2_max_Karton
        '
        Me.La_P2_max_Karton.AutoSize = True
        Me.La_P2_max_Karton.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.La_P2_max_Karton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.La_P2_max_Karton.Location = New System.Drawing.Point(399, 157)
        Me.La_P2_max_Karton.Name = "La_P2_max_Karton"
        Me.La_P2_max_Karton.Size = New System.Drawing.Size(27, 20)
        Me.La_P2_max_Karton.TabIndex = 27
        Me.La_P2_max_Karton.Text = "30"
        '
        'Nud_P2_Karton
        '
        Me.Nud_P2_Karton.Enabled = False
        Me.Nud_P2_Karton.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nud_P2_Karton.Location = New System.Drawing.Point(432, 150)
        Me.Nud_P2_Karton.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.Nud_P2_Karton.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Nud_P2_Karton.Name = "Nud_P2_Karton"
        Me.Nud_P2_Karton.Size = New System.Drawing.Size(61, 44)
        Me.Nud_P2_Karton.TabIndex = 26
        Me.Nud_P2_Karton.Value = New Decimal(New Integer() {45, 0, 0, 0})
        '
        'La_P2_max_Lagen
        '
        Me.La_P2_max_Lagen.AutoSize = True
        Me.La_P2_max_Lagen.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.La_P2_max_Lagen.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.La_P2_max_Lagen.Location = New System.Drawing.Point(321, 157)
        Me.La_P2_max_Lagen.Name = "La_P2_max_Lagen"
        Me.La_P2_max_Lagen.Size = New System.Drawing.Size(18, 20)
        Me.La_P2_max_Lagen.TabIndex = 25
        Me.La_P2_max_Lagen.Text = "3"
        '
        'LB_P2
        '
        Me.LB_P2.Enabled = False
        Me.LB_P2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_P2.FormattingEnabled = True
        Me.LB_P2.ItemHeight = 24
        Me.LB_P2.Location = New System.Drawing.Point(202, 150)
        Me.LB_P2.Name = "LB_P2"
        Me.LB_P2.Size = New System.Drawing.Size(86, 28)
        Me.LB_P2.TabIndex = 24
        '
        'Nud_P2_Lagen
        '
        Me.Nud_P2_Lagen.Enabled = False
        Me.Nud_P2_Lagen.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nud_P2_Lagen.Location = New System.Drawing.Point(345, 150)
        Me.Nud_P2_Lagen.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.Nud_P2_Lagen.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Nud_P2_Lagen.Name = "Nud_P2_Lagen"
        Me.Nud_P2_Lagen.Size = New System.Drawing.Size(40, 44)
        Me.Nud_P2_Lagen.TabIndex = 23
        Me.Nud_P2_Lagen.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'CB_P3_aktiv
        '
        Me.CB_P3_aktiv.AutoSize = True
        Me.CB_P3_aktiv.Enabled = False
        Me.CB_P3_aktiv.Location = New System.Drawing.Point(176, 223)
        Me.CB_P3_aktiv.Name = "CB_P3_aktiv"
        Me.CB_P3_aktiv.Size = New System.Drawing.Size(15, 14)
        Me.CB_P3_aktiv.TabIndex = 38
        Me.CB_P3_aktiv.UseVisualStyleBackColor = True
        '
        'La_P3_Pal_Ist
        '
        Me.La_P3_Pal_Ist.AutoSize = True
        Me.La_P3_Pal_Ist.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.La_P3_Pal_Ist.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.La_P3_Pal_Ist.Location = New System.Drawing.Point(639, 214)
        Me.La_P3_Pal_Ist.Name = "La_P3_Pal_Ist"
        Me.La_P3_Pal_Ist.Size = New System.Drawing.Size(35, 37)
        Me.La_P3_Pal_Ist.TabIndex = 37
        Me.La_P3_Pal_Ist.Text = "0"
        '
        'Nud_P3_Pal_Soll
        '
        Me.Nud_P3_Pal_Soll.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nud_P3_Pal_Soll.Location = New System.Drawing.Point(536, 214)
        Me.Nud_P3_Pal_Soll.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.Nud_P3_Pal_Soll.Name = "Nud_P3_Pal_Soll"
        Me.Nud_P3_Pal_Soll.Size = New System.Drawing.Size(61, 44)
        Me.Nud_P3_Pal_Soll.TabIndex = 36
        Me.Nud_P3_Pal_Soll.Value = New Decimal(New Integer() {99, 0, 0, 0})
        '
        'La_P3_max_Karton
        '
        Me.La_P3_max_Karton.AutoSize = True
        Me.La_P3_max_Karton.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.La_P3_max_Karton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.La_P3_max_Karton.Location = New System.Drawing.Point(399, 221)
        Me.La_P3_max_Karton.Name = "La_P3_max_Karton"
        Me.La_P3_max_Karton.Size = New System.Drawing.Size(27, 20)
        Me.La_P3_max_Karton.TabIndex = 35
        Me.La_P3_max_Karton.Text = "30"
        '
        'Nud_P3_Karton
        '
        Me.Nud_P3_Karton.Enabled = False
        Me.Nud_P3_Karton.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nud_P3_Karton.Location = New System.Drawing.Point(432, 214)
        Me.Nud_P3_Karton.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.Nud_P3_Karton.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Nud_P3_Karton.Name = "Nud_P3_Karton"
        Me.Nud_P3_Karton.Size = New System.Drawing.Size(61, 44)
        Me.Nud_P3_Karton.TabIndex = 34
        Me.Nud_P3_Karton.Value = New Decimal(New Integer() {45, 0, 0, 0})
        '
        'La_P3_max_Lagen
        '
        Me.La_P3_max_Lagen.AutoSize = True
        Me.La_P3_max_Lagen.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.La_P3_max_Lagen.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.La_P3_max_Lagen.Location = New System.Drawing.Point(321, 221)
        Me.La_P3_max_Lagen.Name = "La_P3_max_Lagen"
        Me.La_P3_max_Lagen.Size = New System.Drawing.Size(18, 20)
        Me.La_P3_max_Lagen.TabIndex = 33
        Me.La_P3_max_Lagen.Text = "3"
        '
        'LB_P3
        '
        Me.LB_P3.Enabled = False
        Me.LB_P3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_P3.FormattingEnabled = True
        Me.LB_P3.ItemHeight = 24
        Me.LB_P3.Location = New System.Drawing.Point(202, 214)
        Me.LB_P3.Name = "LB_P3"
        Me.LB_P3.Size = New System.Drawing.Size(86, 28)
        Me.LB_P3.TabIndex = 32
        '
        'Nud_P3_Lagen
        '
        Me.Nud_P3_Lagen.Enabled = False
        Me.Nud_P3_Lagen.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nud_P3_Lagen.Location = New System.Drawing.Point(345, 214)
        Me.Nud_P3_Lagen.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.Nud_P3_Lagen.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Nud_P3_Lagen.Name = "Nud_P3_Lagen"
        Me.Nud_P3_Lagen.Size = New System.Drawing.Size(40, 44)
        Me.Nud_P3_Lagen.TabIndex = 31
        Me.Nud_P3_Lagen.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Timer1
        '
        '
        'TimerAchsenstatus
        '
        '
        'Tb_X_dpos
        '
        Me.Tb_X_dpos.Enabled = False
        Me.Tb_X_dpos.Location = New System.Drawing.Point(487, 288)
        Me.Tb_X_dpos.Name = "Tb_X_dpos"
        Me.Tb_X_dpos.Size = New System.Drawing.Size(63, 20)
        Me.Tb_X_dpos.TabIndex = 40
        '
        'Tb_X_speed
        '
        Me.Tb_X_speed.Enabled = False
        Me.Tb_X_speed.Location = New System.Drawing.Point(556, 288)
        Me.Tb_X_speed.Name = "Tb_X_speed"
        Me.Tb_X_speed.Size = New System.Drawing.Size(63, 20)
        Me.Tb_X_speed.TabIndex = 41
        '
        'Lb_Name_Achse
        '
        Me.Lb_Name_Achse.AutoSize = True
        Me.Lb_Name_Achse.Location = New System.Drawing.Point(444, 272)
        Me.Lb_Name_Achse.Name = "Lb_Name_Achse"
        Me.Lb_Name_Achse.Size = New System.Drawing.Size(37, 13)
        Me.Lb_Name_Achse.TabIndex = 42
        Me.Lb_Name_Achse.Text = "Achse"
        '
        'Lb_Achse_Position
        '
        Me.Lb_Achse_Position.AutoSize = True
        Me.Lb_Achse_Position.Location = New System.Drawing.Point(484, 272)
        Me.Lb_Achse_Position.Name = "Lb_Achse_Position"
        Me.Lb_Achse_Position.Size = New System.Drawing.Size(44, 13)
        Me.Lb_Achse_Position.TabIndex = 43
        Me.Lb_Achse_Position.Text = "Position"
        '
        'Lb_Achse_Speed
        '
        Me.Lb_Achse_Speed.AutoSize = True
        Me.Lb_Achse_Speed.Location = New System.Drawing.Point(553, 272)
        Me.Lb_Achse_Speed.Name = "Lb_Achse_Speed"
        Me.Lb_Achse_Speed.Size = New System.Drawing.Size(85, 13)
        Me.Lb_Achse_Speed.TabIndex = 44
        Me.Lb_Achse_Speed.Text = "Geschwindigkeit"
        '
        'Tb_Y_speed
        '
        Me.Tb_Y_speed.Enabled = False
        Me.Tb_Y_speed.Location = New System.Drawing.Point(556, 314)
        Me.Tb_Y_speed.Name = "Tb_Y_speed"
        Me.Tb_Y_speed.Size = New System.Drawing.Size(63, 20)
        Me.Tb_Y_speed.TabIndex = 47
        '
        'Tb_Y_dpos
        '
        Me.Tb_Y_dpos.Enabled = False
        Me.Tb_Y_dpos.Location = New System.Drawing.Point(487, 314)
        Me.Tb_Y_dpos.Name = "Tb_Y_dpos"
        Me.Tb_Y_dpos.Size = New System.Drawing.Size(63, 20)
        Me.Tb_Y_dpos.TabIndex = 46
        '
        'Tb_Z_speed
        '
        Me.Tb_Z_speed.Enabled = False
        Me.Tb_Z_speed.Location = New System.Drawing.Point(556, 340)
        Me.Tb_Z_speed.Name = "Tb_Z_speed"
        Me.Tb_Z_speed.Size = New System.Drawing.Size(63, 20)
        Me.Tb_Z_speed.TabIndex = 50
        '
        'Tb_Z_dpos
        '
        Me.Tb_Z_dpos.Enabled = False
        Me.Tb_Z_dpos.Location = New System.Drawing.Point(487, 340)
        Me.Tb_Z_dpos.Name = "Tb_Z_dpos"
        Me.Tb_Z_dpos.Size = New System.Drawing.Size(63, 20)
        Me.Tb_Z_dpos.TabIndex = 49
        '
        'Tb_R_speed
        '
        Me.Tb_R_speed.Enabled = False
        Me.Tb_R_speed.Location = New System.Drawing.Point(556, 366)
        Me.Tb_R_speed.Name = "Tb_R_speed"
        Me.Tb_R_speed.Size = New System.Drawing.Size(63, 20)
        Me.Tb_R_speed.TabIndex = 53
        '
        'Tb_R_dpos
        '
        Me.Tb_R_dpos.Enabled = False
        Me.Tb_R_dpos.Location = New System.Drawing.Point(487, 366)
        Me.Tb_R_dpos.Name = "Tb_R_dpos"
        Me.Tb_R_dpos.Size = New System.Drawing.Size(63, 20)
        Me.Tb_R_dpos.TabIndex = 52
        '
        'La_akt_Lage
        '
        Me.La_akt_Lage.AutoSize = True
        Me.La_akt_Lage.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.La_akt_Lage.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.La_akt_Lage.Location = New System.Drawing.Point(338, 9)
        Me.La_akt_Lage.Name = "La_akt_Lage"
        Me.La_akt_Lage.Size = New System.Drawing.Size(35, 37)
        Me.La_akt_Lage.TabIndex = 54
        Me.La_akt_Lage.Text = "0"
        '
        'La_akt_Karton
        '
        Me.La_akt_Karton.AutoSize = True
        Me.La_akt_Karton.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.La_akt_Karton.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.La_akt_Karton.Location = New System.Drawing.Point(425, 9)
        Me.La_akt_Karton.Name = "La_akt_Karton"
        Me.La_akt_Karton.Size = New System.Drawing.Size(35, 37)
        Me.La_akt_Karton.TabIndex = 55
        Me.La_akt_Karton.Text = "0"
        '
        'CB_AX
        '
        Me.CB_AX.AutoSize = True
        Me.CB_AX.Enabled = False
        Me.CB_AX.Location = New System.Drawing.Point(449, 290)
        Me.CB_AX.Name = "CB_AX"
        Me.CB_AX.Size = New System.Drawing.Size(33, 17)
        Me.CB_AX.TabIndex = 56
        Me.CB_AX.Text = "X"
        Me.CB_AX.UseVisualStyleBackColor = True
        '
        'CB_AY
        '
        Me.CB_AY.AutoSize = True
        Me.CB_AY.Enabled = False
        Me.CB_AY.Location = New System.Drawing.Point(449, 316)
        Me.CB_AY.Name = "CB_AY"
        Me.CB_AY.Size = New System.Drawing.Size(33, 17)
        Me.CB_AY.TabIndex = 57
        Me.CB_AY.Text = "Y"
        Me.CB_AY.UseVisualStyleBackColor = True
        '
        'CB_AZ
        '
        Me.CB_AZ.AutoSize = True
        Me.CB_AZ.Enabled = False
        Me.CB_AZ.Location = New System.Drawing.Point(449, 342)
        Me.CB_AZ.Name = "CB_AZ"
        Me.CB_AZ.Size = New System.Drawing.Size(33, 17)
        Me.CB_AZ.TabIndex = 58
        Me.CB_AZ.Text = "Z"
        Me.CB_AZ.UseVisualStyleBackColor = True
        '
        'CB_AR
        '
        Me.CB_AR.AutoSize = True
        Me.CB_AR.Enabled = False
        Me.CB_AR.Location = New System.Drawing.Point(449, 368)
        Me.CB_AR.Name = "CB_AR"
        Me.CB_AR.Size = New System.Drawing.Size(34, 17)
        Me.CB_AR.TabIndex = 59
        Me.CB_AR.Text = "R"
        Me.CB_AR.UseVisualStyleBackColor = True
        '
        'Palettierer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 403)
        Me.Controls.Add(Me.CB_AR)
        Me.Controls.Add(Me.CB_AZ)
        Me.Controls.Add(Me.CB_AY)
        Me.Controls.Add(Me.CB_AX)
        Me.Controls.Add(Me.La_akt_Karton)
        Me.Controls.Add(Me.La_akt_Lage)
        Me.Controls.Add(Me.Tb_R_speed)
        Me.Controls.Add(Me.Tb_R_dpos)
        Me.Controls.Add(Me.Tb_Z_speed)
        Me.Controls.Add(Me.Tb_Z_dpos)
        Me.Controls.Add(Me.Tb_Y_speed)
        Me.Controls.Add(Me.Tb_Y_dpos)
        Me.Controls.Add(Me.Lb_Achse_Speed)
        Me.Controls.Add(Me.Lb_Achse_Position)
        Me.Controls.Add(Me.Lb_Name_Achse)
        Me.Controls.Add(Me.Tb_X_speed)
        Me.Controls.Add(Me.Tb_X_dpos)
        Me.Controls.Add(Me.CB_P3_aktiv)
        Me.Controls.Add(Me.La_P3_Pal_Ist)
        Me.Controls.Add(Me.Nud_P3_Pal_Soll)
        Me.Controls.Add(Me.La_P3_max_Karton)
        Me.Controls.Add(Me.Nud_P3_Karton)
        Me.Controls.Add(Me.La_P3_max_Lagen)
        Me.Controls.Add(Me.LB_P3)
        Me.Controls.Add(Me.Nud_P3_Lagen)
        Me.Controls.Add(Me.CB_P2_aktiv)
        Me.Controls.Add(Me.La_P2_Pal_Ist)
        Me.Controls.Add(Me.Nud_P2_Pal_Soll)
        Me.Controls.Add(Me.La_P2_max_Karton)
        Me.Controls.Add(Me.Nud_P2_Karton)
        Me.Controls.Add(Me.La_P2_max_Lagen)
        Me.Controls.Add(Me.LB_P2)
        Me.Controls.Add(Me.Nud_P2_Lagen)
        Me.Controls.Add(Me.La_aktiv)
        Me.Controls.Add(Me.CB_P1_aktiv)
        Me.Controls.Add(Me.La_P1_Pal_Ist)
        Me.Controls.Add(Me.La_Pal_Ist)
        Me.Controls.Add(Me.La_Pal_Soll)
        Me.Controls.Add(Me.Nud_P1_Pal_Soll)
        Me.Controls.Add(Me.La_P1_max_Karton)
        Me.Controls.Add(Me.La_Karton)
        Me.Controls.Add(Me.Nud_P1_Karton)
        Me.Controls.Add(Me.La_P1_max_Lagen)
        Me.Controls.Add(Me.LB_P1)
        Me.Controls.Add(Me.Lab_Status)
        Me.Controls.Add(Me.La_Lagen)
        Me.Controls.Add(Me.Nud_P1_Lagen)
        Me.Controls.Add(Me.Bt_3)
        Me.Controls.Add(Me.Bt_2)
        Me.Controls.Add(Me.Bt_1)
        Me.Name = "Palettierer"
        Me.Text = "Palettierer"
        CType(Me.Nud_P1_Lagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Nud_P1_Karton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Nud_P1_Pal_Soll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Nud_P2_Pal_Soll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Nud_P2_Karton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Nud_P2_Lagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Nud_P3_Pal_Soll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Nud_P3_Karton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Nud_P3_Lagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Bt_1 As Button
    Friend WithEvents Bt_2 As Button
    Friend WithEvents Bt_3 As Button
    Friend WithEvents Nud_P1_Lagen As NumericUpDown
    Friend WithEvents La_Lagen As Label
    Friend WithEvents Lab_Status As Label
    Friend WithEvents LB_P1 As ListBox
    Friend WithEvents La_P1_max_Lagen As Label
    Friend WithEvents La_P1_max_Karton As Label
    Friend WithEvents La_Karton As Label
    Friend WithEvents Nud_P1_Karton As NumericUpDown
    Friend WithEvents La_Pal_Soll As Label
    Friend WithEvents Nud_P1_Pal_Soll As NumericUpDown
    Friend WithEvents La_Pal_Ist As Label
    Friend WithEvents La_P1_Pal_Ist As Label
    Friend WithEvents CB_P1_aktiv As CheckBox
    Friend WithEvents La_aktiv As Label
    Friend WithEvents CB_P2_aktiv As CheckBox
    Friend WithEvents La_P2_Pal_Ist As Label
    Friend WithEvents Nud_P2_Pal_Soll As NumericUpDown
    Friend WithEvents La_P2_max_Karton As Label
    Friend WithEvents Nud_P2_Karton As NumericUpDown
    Friend WithEvents La_P2_max_Lagen As Label
    Friend WithEvents LB_P2 As ListBox
    Friend WithEvents Nud_P2_Lagen As NumericUpDown
    Friend WithEvents CB_P3_aktiv As CheckBox
    Friend WithEvents La_P3_Pal_Ist As Label
    Friend WithEvents Nud_P3_Pal_Soll As NumericUpDown
    Friend WithEvents La_P3_max_Karton As Label
    Friend WithEvents Nud_P3_Karton As NumericUpDown
    Friend WithEvents La_P3_max_Lagen As Label
    Friend WithEvents LB_P3 As ListBox
    Friend WithEvents Nud_P3_Lagen As NumericUpDown
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TimerAchsenstatus As Timer
    Friend WithEvents Tb_X_dpos As TextBox
    Friend WithEvents Tb_X_speed As TextBox
    Friend WithEvents Lb_Name_Achse As Label
    Friend WithEvents Lb_Achse_Position As Label
    Friend WithEvents Lb_Achse_Speed As Label
    Friend WithEvents Tb_Y_speed As TextBox
    Friend WithEvents Tb_Y_dpos As TextBox
    Friend WithEvents Tb_Z_speed As TextBox
    Friend WithEvents Tb_Z_dpos As TextBox
    Friend WithEvents Tb_R_speed As TextBox
    Friend WithEvents Tb_R_dpos As TextBox
    Friend WithEvents La_akt_Lage As Label
    Friend WithEvents La_akt_Karton As Label
    Friend WithEvents CB_AX As CheckBox
    Friend WithEvents CB_AY As CheckBox
    Friend WithEvents CB_AZ As CheckBox
    Friend WithEvents CB_AR As CheckBox
End Class
