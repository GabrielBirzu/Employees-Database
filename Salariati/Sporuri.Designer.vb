<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sporuri
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sporuri))
        Me.btnRevenire = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSalariat = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnStergereS = New System.Windows.Forms.Button()
        Me.dgvSporuri = New System.Windows.Forms.DataGridView()
        Me.btnAdaugareS = New System.Windows.Forms.Button()
        Me.cmbSporuri = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvSporuri, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnRevenire
        '
        Me.btnRevenire.BackColor = System.Drawing.Color.FloralWhite
        Me.btnRevenire.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRevenire.Location = New System.Drawing.Point(606, 33)
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
        Me.Label2.Location = New System.Drawing.Point(9, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 18)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "SALARIATUL:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSalariat
        '
        Me.txtSalariat.Enabled = False
        Me.txtSalariat.Location = New System.Drawing.Point(125, 44)
        Me.txtSalariat.Name = "txtSalariat"
        Me.txtSalariat.Size = New System.Drawing.Size(165, 20)
        Me.txtSalariat.TabIndex = 11
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btnStergereS)
        Me.Panel1.Controls.Add(Me.dgvSporuri)
        Me.Panel1.Controls.Add(Me.btnAdaugareS)
        Me.Panel1.Controls.Add(Me.cmbSporuri)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(12, 100)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(776, 568)
        Me.Panel1.TabIndex = 10
        '
        'btnStergereS
        '
        Me.btnStergereS.BackColor = System.Drawing.Color.Red
        Me.btnStergereS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStergereS.ForeColor = System.Drawing.Color.Black
        Me.btnStergereS.Location = New System.Drawing.Point(157, 458)
        Me.btnStergereS.Name = "btnStergereS"
        Me.btnStergereS.Size = New System.Drawing.Size(276, 51)
        Me.btnStergereS.TabIndex = 52
        Me.btnStergereS.Text = "ȘTERGERE SPOR"
        Me.btnStergereS.UseVisualStyleBackColor = False
        '
        'dgvSporuri
        '
        Me.dgvSporuri.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSporuri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSporuri.Location = New System.Drawing.Point(26, 108)
        Me.dgvSporuri.MultiSelect = False
        Me.dgvSporuri.Name = "dgvSporuri"
        Me.dgvSporuri.ReadOnly = True
        Me.dgvSporuri.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSporuri.Size = New System.Drawing.Size(548, 282)
        Me.dgvSporuri.TabIndex = 51
        '
        'btnAdaugareS
        '
        Me.btnAdaugareS.Location = New System.Drawing.Point(437, 39)
        Me.btnAdaugareS.Name = "btnAdaugareS"
        Me.btnAdaugareS.Size = New System.Drawing.Size(137, 37)
        Me.btnAdaugareS.TabIndex = 50
        Me.btnAdaugareS.Text = "ADĂUGARE SPOR"
        Me.btnAdaugareS.UseVisualStyleBackColor = True
        '
        'cmbSporuri
        '
        Me.cmbSporuri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSporuri.FormattingEnabled = True
        Me.cmbSporuri.Location = New System.Drawing.Point(247, 48)
        Me.cmbSporuri.Name = "cmbSporuri"
        Me.cmbSporuri.Size = New System.Drawing.Size(156, 21)
        Me.cmbSporuri.TabIndex = 49
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(218, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "ALEGEȚI UN SPOR PENTRU ADĂUGARE:"
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
        'Sporuri
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkKhaki
        Me.ClientSize = New System.Drawing.Size(800, 679)
        Me.Controls.Add(Me.btnRevenire)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSalariat)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Sporuri"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SPORURI"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvSporuri, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnRevenire As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSalariat As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnStergereS As Button
    Friend WithEvents dgvSporuri As DataGridView
    Friend WithEvents btnAdaugareS As Button
    Friend WithEvents cmbSporuri As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
