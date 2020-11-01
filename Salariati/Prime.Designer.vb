<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Prime
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Prime))
        Me.btnRevenire = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSalariat = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtSuma = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnStergereP = New System.Windows.Forms.Button()
        Me.dgvPrime = New System.Windows.Forms.DataGridView()
        Me.brnAdaugareP = New System.Windows.Forms.Button()
        Me.cmbPrime = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvPrime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnRevenire
        '
        Me.btnRevenire.BackColor = System.Drawing.Color.FloralWhite
        Me.btnRevenire.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRevenire.Location = New System.Drawing.Point(608, 19)
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
        Me.Label2.Location = New System.Drawing.Point(11, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 18)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "SALARIATUL:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSalariat
        '
        Me.txtSalariat.Enabled = False
        Me.txtSalariat.Location = New System.Drawing.Point(127, 30)
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
        Me.Panel1.Controls.Add(Me.btnStergereP)
        Me.Panel1.Controls.Add(Me.dgvPrime)
        Me.Panel1.Controls.Add(Me.brnAdaugareP)
        Me.Panel1.Controls.Add(Me.cmbPrime)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(14, 86)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(776, 568)
        Me.Panel1.TabIndex = 10
        '
        'txtSuma
        '
        Me.txtSuma.Location = New System.Drawing.Point(243, 75)
        Me.txtSuma.Name = "txtSuma"
        Me.txtSuma.Size = New System.Drawing.Size(161, 20)
        Me.txtSuma.TabIndex = 53
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(171, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "SUMĂ (LEI):"
        '
        'btnStergereP
        '
        Me.btnStergereP.BackColor = System.Drawing.Color.Red
        Me.btnStergereP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStergereP.ForeColor = System.Drawing.Color.Black
        Me.btnStergereP.Location = New System.Drawing.Point(157, 458)
        Me.btnStergereP.Name = "btnStergereP"
        Me.btnStergereP.Size = New System.Drawing.Size(276, 51)
        Me.btnStergereP.TabIndex = 52
        Me.btnStergereP.Text = "ȘTERGERE PRIMĂ"
        Me.btnStergereP.UseVisualStyleBackColor = False
        '
        'dgvPrime
        '
        Me.dgvPrime.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPrime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPrime.Location = New System.Drawing.Point(26, 108)
        Me.dgvPrime.MultiSelect = False
        Me.dgvPrime.Name = "dgvPrime"
        Me.dgvPrime.ReadOnly = True
        Me.dgvPrime.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPrime.Size = New System.Drawing.Size(548, 282)
        Me.dgvPrime.TabIndex = 51
        '
        'brnAdaugareP
        '
        Me.brnAdaugareP.Location = New System.Drawing.Point(437, 48)
        Me.brnAdaugareP.Name = "brnAdaugareP"
        Me.brnAdaugareP.Size = New System.Drawing.Size(137, 37)
        Me.brnAdaugareP.TabIndex = 50
        Me.brnAdaugareP.Text = "ADĂUGARE PRIMĂ"
        Me.brnAdaugareP.UseVisualStyleBackColor = True
        '
        'cmbPrime
        '
        Me.cmbPrime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrime.FormattingEnabled = True
        Me.cmbPrime.Location = New System.Drawing.Point(243, 48)
        Me.cmbPrime.Name = "cmbPrime"
        Me.cmbPrime.Size = New System.Drawing.Size(161, 21)
        Me.cmbPrime.TabIndex = 49
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(214, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "ALEGEȚI O PRIMĂ PENTRU ADĂUGARE:"
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
        'Prime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkKhaki
        Me.ClientSize = New System.Drawing.Size(800, 667)
        Me.Controls.Add(Me.btnRevenire)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSalariat)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Prime"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PRIME"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvPrime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnRevenire As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSalariat As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnStergereP As Button
    Friend WithEvents dgvPrime As DataGridView
    Friend WithEvents brnAdaugareP As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents cmbPrime As ComboBox
    Friend WithEvents txtSuma As TextBox
    Friend WithEvents Label3 As Label
End Class
