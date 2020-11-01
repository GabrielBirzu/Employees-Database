<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contributii
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contributii))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnStergereContributie = New System.Windows.Forms.Button()
        Me.dgvContributii = New System.Windows.Forms.DataGridView()
        Me.btnAdaugareC = New System.Windows.Forms.Button()
        Me.cmbContributie = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnRevenire = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSalariat = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvContributii, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btnStergereContributie)
        Me.Panel1.Controls.Add(Me.dgvContributii)
        Me.Panel1.Controls.Add(Me.btnAdaugareC)
        Me.Panel1.Controls.Add(Me.cmbContributie)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(12, 97)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(776, 568)
        Me.Panel1.TabIndex = 0
        '
        'btnStergereContributie
        '
        Me.btnStergereContributie.BackColor = System.Drawing.Color.Red
        Me.btnStergereContributie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStergereContributie.ForeColor = System.Drawing.Color.Black
        Me.btnStergereContributie.Location = New System.Drawing.Point(157, 458)
        Me.btnStergereContributie.Name = "btnStergereContributie"
        Me.btnStergereContributie.Size = New System.Drawing.Size(276, 51)
        Me.btnStergereContributie.TabIndex = 52
        Me.btnStergereContributie.Text = "ȘTERGERE CONTRIBUȚIE"
        Me.btnStergereContributie.UseVisualStyleBackColor = False
        '
        'dgvContributii
        '
        Me.dgvContributii.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvContributii.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvContributii.Location = New System.Drawing.Point(26, 108)
        Me.dgvContributii.MultiSelect = False
        Me.dgvContributii.Name = "dgvContributii"
        Me.dgvContributii.ReadOnly = True
        Me.dgvContributii.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvContributii.Size = New System.Drawing.Size(548, 282)
        Me.dgvContributii.TabIndex = 51
        '
        'btnAdaugareC
        '
        Me.btnAdaugareC.Location = New System.Drawing.Point(437, 39)
        Me.btnAdaugareC.Name = "btnAdaugareC"
        Me.btnAdaugareC.Size = New System.Drawing.Size(137, 37)
        Me.btnAdaugareC.TabIndex = 50
        Me.btnAdaugareC.Text = "ADĂUGARE CONTRIBUȚIE"
        Me.btnAdaugareC.UseVisualStyleBackColor = True
        '
        'cmbContributie
        '
        Me.cmbContributie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbContributie.FormattingEnabled = True
        Me.cmbContributie.Location = New System.Drawing.Point(282, 48)
        Me.cmbContributie.Name = "cmbContributie"
        Me.cmbContributie.Size = New System.Drawing.Size(126, 21)
        Me.cmbContributie.TabIndex = 49
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(253, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "ALEGEȚI O CONTRIBUȚIE PENTRU ADĂUGARE:"
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
        'btnRevenire
        '
        Me.btnRevenire.BackColor = System.Drawing.Color.FloralWhite
        Me.btnRevenire.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRevenire.Location = New System.Drawing.Point(606, 30)
        Me.btnRevenire.Name = "btnRevenire"
        Me.btnRevenire.Size = New System.Drawing.Size(179, 40)
        Me.btnRevenire.TabIndex = 9
        Me.btnRevenire.Text = "REVENIRE LA PAGINA PRINCIPALA"
        Me.btnRevenire.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Sienna
        Me.Label2.Location = New System.Drawing.Point(9, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 18)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "SALARIATUL:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSalariat
        '
        Me.txtSalariat.Enabled = False
        Me.txtSalariat.Location = New System.Drawing.Point(125, 41)
        Me.txtSalariat.Name = "txtSalariat"
        Me.txtSalariat.Size = New System.Drawing.Size(165, 20)
        Me.txtSalariat.TabIndex = 7
        '
        'Contributii
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkKhaki
        Me.ClientSize = New System.Drawing.Size(800, 676)
        Me.Controls.Add(Me.btnRevenire)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSalariat)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Contributii"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONTRIBUȚII"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvContributii, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnRevenire As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSalariat As TextBox
    Friend WithEvents btnAdaugareC As Button
    Friend WithEvents cmbContributie As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvContributii As DataGridView
    Friend WithEvents btnStergereContributie As Button
End Class
