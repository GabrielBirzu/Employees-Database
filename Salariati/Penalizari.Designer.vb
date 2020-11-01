<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Penalizari
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Penalizari))
        Me.btnRevenire = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSalariat = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbDesfacere = New System.Windows.Forms.RadioButton()
        Me.rbReducereSalariu = New System.Windows.Forms.RadioButton()
        Me.txtNr = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnAdaugareP = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSuma = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMotiv = New System.Windows.Forms.TextBox()
        Me.dtpPenalizare = New System.Windows.Forms.DateTimePicker()
        Me.btnStergereP = New System.Windows.Forms.Button()
        Me.dgvPenalizari = New System.Windows.Forms.DataGridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvPenalizari, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnRevenire
        '
        Me.btnRevenire.BackColor = System.Drawing.Color.FloralWhite
        Me.btnRevenire.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRevenire.Location = New System.Drawing.Point(608, 17)
        Me.btnRevenire.Name = "btnRevenire"
        Me.btnRevenire.Size = New System.Drawing.Size(179, 40)
        Me.btnRevenire.TabIndex = 13
        Me.btnRevenire.Text = "REVENIRE LA PAGINA PRINCIPALA"
        Me.btnRevenire.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Sienna
        Me.Label2.Location = New System.Drawing.Point(11, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 18)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "SALARIATUL:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSalariat
        '
        Me.txtSalariat.Enabled = False
        Me.txtSalariat.Location = New System.Drawing.Point(127, 28)
        Me.txtSalariat.Name = "txtSalariat"
        Me.txtSalariat.Size = New System.Drawing.Size(165, 20)
        Me.txtSalariat.TabIndex = 11
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.rbDesfacere)
        Me.Panel1.Controls.Add(Me.rbReducereSalariu)
        Me.Panel1.Controls.Add(Me.txtNr)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.btnAdaugareP)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtSuma)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtMotiv)
        Me.Panel1.Controls.Add(Me.dtpPenalizare)
        Me.Panel1.Controls.Add(Me.btnStergereP)
        Me.Panel1.Controls.Add(Me.dgvPenalizari)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(14, 84)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(776, 568)
        Me.Panel1.TabIndex = 10
        '
        'rbDesfacere
        '
        Me.rbDesfacere.AutoSize = True
        Me.rbDesfacere.Location = New System.Drawing.Point(351, 42)
        Me.rbDesfacere.Name = "rbDesfacere"
        Me.rbDesfacere.Size = New System.Drawing.Size(211, 17)
        Me.rbDesfacere.TabIndex = 63
        Me.rbDesfacere.TabStop = True
        Me.rbDesfacere.Text = "DESFACERE CONTRACT DE MUNCĂ"
        Me.rbDesfacere.UseVisualStyleBackColor = True
        '
        'rbReducereSalariu
        '
        Me.rbReducereSalariu.AutoSize = True
        Me.rbReducereSalariu.Checked = True
        Me.rbReducereSalariu.Location = New System.Drawing.Point(29, 42)
        Me.rbReducereSalariu.Name = "rbReducereSalariu"
        Me.rbReducereSalariu.Size = New System.Drawing.Size(224, 17)
        Me.rbReducereSalariu.TabIndex = 62
        Me.rbReducereSalariu.TabStop = True
        Me.rbReducereSalariu.Text = "REDUCERE SALARIU DE BAZĂ CU 15%"
        Me.rbReducereSalariu.UseVisualStyleBackColor = True
        '
        'txtNr
        '
        Me.txtNr.Enabled = False
        Me.txtNr.Location = New System.Drawing.Point(166, 91)
        Me.txtNr.Name = "txtNr"
        Me.txtNr.Size = New System.Drawing.Size(100, 20)
        Me.txtNr.TabIndex = 61
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 13)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "NUMĂR ÎNREGISTRARE:"
        '
        'btnAdaugareP
        '
        Me.btnAdaugareP.Location = New System.Drawing.Point(467, 137)
        Me.btnAdaugareP.Name = "btnAdaugareP"
        Me.btnAdaugareP.Size = New System.Drawing.Size(107, 36)
        Me.btnAdaugareP.TabIndex = 59
        Me.btnAdaugareP.Text = "APLICARE PENALIZARE"
        Me.btnAdaugareP.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 149)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "SUMĂ:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(200, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 13)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "DATĂ PENALIZARE:"
        '
        'txtSuma
        '
        Me.txtSuma.Enabled = False
        Me.txtSuma.Location = New System.Drawing.Point(73, 146)
        Me.txtSuma.Name = "txtSuma"
        Me.txtSuma.Size = New System.Drawing.Size(100, 20)
        Me.txtSuma.TabIndex = 56
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(301, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "MOTIV:"
        '
        'txtMotiv
        '
        Me.txtMotiv.Location = New System.Drawing.Point(351, 91)
        Me.txtMotiv.Name = "txtMotiv"
        Me.txtMotiv.Size = New System.Drawing.Size(223, 20)
        Me.txtMotiv.TabIndex = 54
        '
        'dtpPenalizare
        '
        Me.dtpPenalizare.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPenalizare.Location = New System.Drawing.Point(315, 146)
        Me.dtpPenalizare.Name = "dtpPenalizare"
        Me.dtpPenalizare.Size = New System.Drawing.Size(118, 20)
        Me.dtpPenalizare.TabIndex = 53
        '
        'btnStergereP
        '
        Me.btnStergereP.BackColor = System.Drawing.Color.Red
        Me.btnStergereP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStergereP.ForeColor = System.Drawing.Color.Black
        Me.btnStergereP.Location = New System.Drawing.Point(157, 470)
        Me.btnStergereP.Name = "btnStergereP"
        Me.btnStergereP.Size = New System.Drawing.Size(276, 51)
        Me.btnStergereP.TabIndex = 52
        Me.btnStergereP.Text = "ȘTERGERE PENALIZARE"
        Me.btnStergereP.UseVisualStyleBackColor = False
        '
        'dgvPenalizari
        '
        Me.dgvPenalizari.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPenalizari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPenalizari.Location = New System.Drawing.Point(26, 196)
        Me.dgvPenalizari.MultiSelect = False
        Me.dgvPenalizari.Name = "dgvPenalizari"
        Me.dgvPenalizari.ReadOnly = True
        Me.dgvPenalizari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPenalizari.Size = New System.Drawing.Size(548, 248)
        Me.dgvPenalizari.TabIndex = 51
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(599, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(170, 558)
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'Penalizari
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkKhaki
        Me.ClientSize = New System.Drawing.Size(805, 662)
        Me.Controls.Add(Me.btnRevenire)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSalariat)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Penalizari"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PENALIZĂRI"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvPenalizari, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnRevenire As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSalariat As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSuma As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtMotiv As TextBox
    Friend WithEvents dtpPenalizare As DateTimePicker
    Friend WithEvents btnStergereP As Button
    Friend WithEvents dgvPenalizari As DataGridView
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnAdaugareP As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNr As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents rbDesfacere As RadioButton
    Friend WithEvents rbReducereSalariu As RadioButton
End Class
