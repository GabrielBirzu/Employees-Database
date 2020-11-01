<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Retineri
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Retineri))
        Me.btnRevenire = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSalariat = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtSuma = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnStergereR = New System.Windows.Forms.Button()
        Me.dgvRetineri = New System.Windows.Forms.DataGridView()
        Me.btnAdaugareR = New System.Windows.Forms.Button()
        Me.cmbRetineri = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvRetineri, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnRevenire
        '
        Me.btnRevenire.BackColor = System.Drawing.Color.FloralWhite
        Me.btnRevenire.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRevenire.Location = New System.Drawing.Point(608, 12)
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
        Me.Label2.Location = New System.Drawing.Point(11, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 18)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "SALARIATUL:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSalariat
        '
        Me.txtSalariat.Enabled = False
        Me.txtSalariat.Location = New System.Drawing.Point(127, 23)
        Me.txtSalariat.Name = "txtSalariat"
        Me.txtSalariat.Size = New System.Drawing.Size(165, 20)
        Me.txtSalariat.TabIndex = 11
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.txtSuma)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btnStergereR)
        Me.Panel1.Controls.Add(Me.dgvRetineri)
        Me.Panel1.Controls.Add(Me.btnAdaugareR)
        Me.Panel1.Controls.Add(Me.cmbRetineri)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(14, 79)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(776, 568)
        Me.Panel1.TabIndex = 10
        '
        'txtSuma
        '
        Me.txtSuma.Location = New System.Drawing.Point(305, 82)
        Me.txtSuma.Name = "txtSuma"
        Me.txtSuma.Size = New System.Drawing.Size(126, 20)
        Me.txtSuma.TabIndex = 53
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(255, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "SUMĂ :"
        '
        'btnStergereR
        '
        Me.btnStergereR.BackColor = System.Drawing.Color.Red
        Me.btnStergereR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStergereR.ForeColor = System.Drawing.Color.Black
        Me.btnStergereR.Location = New System.Drawing.Point(157, 458)
        Me.btnStergereR.Name = "btnStergereR"
        Me.btnStergereR.Size = New System.Drawing.Size(276, 51)
        Me.btnStergereR.TabIndex = 52
        Me.btnStergereR.Text = "ȘTERGERE REȚINERE"
        Me.btnStergereR.UseVisualStyleBackColor = False
        '
        'dgvRetineri
        '
        Me.dgvRetineri.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRetineri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRetineri.Location = New System.Drawing.Point(26, 141)
        Me.dgvRetineri.MultiSelect = False
        Me.dgvRetineri.Name = "dgvRetineri"
        Me.dgvRetineri.ReadOnly = True
        Me.dgvRetineri.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRetineri.Size = New System.Drawing.Size(548, 275)
        Me.dgvRetineri.TabIndex = 51
        '
        'btnAdaugareR
        '
        Me.btnAdaugareR.Location = New System.Drawing.Point(458, 51)
        Me.btnAdaugareR.Name = "btnAdaugareR"
        Me.btnAdaugareR.Size = New System.Drawing.Size(116, 47)
        Me.btnAdaugareR.TabIndex = 50
        Me.btnAdaugareR.Text = "ADĂUGARE REȚINERE"
        Me.btnAdaugareR.UseVisualStyleBackColor = True
        '
        'cmbRetineri
        '
        Me.cmbRetineri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRetineri.FormattingEnabled = True
        Me.cmbRetineri.Location = New System.Drawing.Point(305, 48)
        Me.cmbRetineri.Name = "cmbRetineri"
        Me.cmbRetineri.Size = New System.Drawing.Size(126, 21)
        Me.cmbRetineri.TabIndex = 49
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(281, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "ALEGEȚI UN TIP DE REȚINERE PENTRU ADĂUGARE:"
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
        'Retineri
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkKhaki
        Me.ClientSize = New System.Drawing.Size(805, 658)
        Me.Controls.Add(Me.btnRevenire)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSalariat)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Retineri"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REȚINERI"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvRetineri, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnRevenire As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSalariat As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtSuma As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnStergereR As Button
    Friend WithEvents dgvRetineri As DataGridView
    Friend WithEvents btnAdaugareR As Button
    Friend WithEvents cmbRetineri As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
