<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ierarhie
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnEliminareSubordonati = New System.Windows.Forms.Button()
        Me.btnEliminareSuperiori = New System.Windows.Forms.Button()
        Me.btnAdaugareSubordonati = New System.Windows.Forms.Button()
        Me.btnAdaugareSuperiori = New System.Windows.Forms.Button()
        Me.dgvSalariati = New System.Windows.Forms.DataGridView()
        Me.dgvSuperiori = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvSubordonati = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSalariat = New System.Windows.Forms.TextBox()
        Me.btnRevenire = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvSalariati, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSuperiori, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSubordonati, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.btnEliminareSubordonati)
        Me.Panel1.Controls.Add(Me.btnEliminareSuperiori)
        Me.Panel1.Controls.Add(Me.btnAdaugareSubordonati)
        Me.Panel1.Controls.Add(Me.btnAdaugareSuperiori)
        Me.Panel1.Controls.Add(Me.dgvSalariati)
        Me.Panel1.Controls.Add(Me.dgvSuperiori)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.dgvSubordonati)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 81)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(776, 590)
        Me.Panel1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 331)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "SALARIAȚI"
        '
        'btnEliminareSubordonati
        '
        Me.btnEliminareSubordonati.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnEliminareSubordonati.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminareSubordonati.Location = New System.Drawing.Point(483, 247)
        Me.btnEliminareSubordonati.Name = "btnEliminareSubordonati"
        Me.btnEliminareSubordonati.Size = New System.Drawing.Size(219, 36)
        Me.btnEliminareSubordonati.TabIndex = 12
        Me.btnEliminareSubordonati.Text = "ELIMINARE SALARIAT DIN TABELUL SUBORDONAȚI"
        Me.btnEliminareSubordonati.UseVisualStyleBackColor = False
        '
        'btnEliminareSuperiori
        '
        Me.btnEliminareSuperiori.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnEliminareSuperiori.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminareSuperiori.Location = New System.Drawing.Point(60, 247)
        Me.btnEliminareSuperiori.Name = "btnEliminareSuperiori"
        Me.btnEliminareSuperiori.Size = New System.Drawing.Size(227, 36)
        Me.btnEliminareSuperiori.TabIndex = 11
        Me.btnEliminareSuperiori.Text = "ELIMINARE SALARIAT DIN TABELUL SUPERIORI"
        Me.btnEliminareSuperiori.UseVisualStyleBackColor = False
        '
        'btnAdaugareSubordonati
        '
        Me.btnAdaugareSubordonati.BackColor = System.Drawing.Color.FloralWhite
        Me.btnAdaugareSubordonati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdaugareSubordonati.Location = New System.Drawing.Point(457, 200)
        Me.btnAdaugareSubordonati.Name = "btnAdaugareSubordonati"
        Me.btnAdaugareSubordonati.Size = New System.Drawing.Size(268, 41)
        Me.btnAdaugareSubordonati.TabIndex = 10
        Me.btnAdaugareSubordonati.Text = "ADĂUGARE SALARIAT SELECTAT ÎN TABELUL SUBORDONAȚI"
        Me.btnAdaugareSubordonati.UseVisualStyleBackColor = False
        '
        'btnAdaugareSuperiori
        '
        Me.btnAdaugareSuperiori.BackColor = System.Drawing.Color.FloralWhite
        Me.btnAdaugareSuperiori.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdaugareSuperiori.Location = New System.Drawing.Point(40, 200)
        Me.btnAdaugareSuperiori.Name = "btnAdaugareSuperiori"
        Me.btnAdaugareSuperiori.Size = New System.Drawing.Size(268, 41)
        Me.btnAdaugareSuperiori.TabIndex = 9
        Me.btnAdaugareSuperiori.Text = "ADĂUGARE SALARIAT SELECTAT ÎN TABELUL SUPERIORI"
        Me.btnAdaugareSuperiori.UseVisualStyleBackColor = False
        '
        'dgvSalariati
        '
        Me.dgvSalariati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSalariati.Location = New System.Drawing.Point(6, 347)
        Me.dgvSalariati.MultiSelect = False
        Me.dgvSalariati.Name = "dgvSalariati"
        Me.dgvSalariati.ReadOnly = True
        Me.dgvSalariati.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSalariati.Size = New System.Drawing.Size(763, 236)
        Me.dgvSalariati.TabIndex = 5
        '
        'dgvSuperiori
        '
        Me.dgvSuperiori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSuperiori.Location = New System.Drawing.Point(6, 27)
        Me.dgvSuperiori.MultiSelect = False
        Me.dgvSuperiori.Name = "dgvSuperiori"
        Me.dgvSuperiori.ReadOnly = True
        Me.dgvSuperiori.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSuperiori.Size = New System.Drawing.Size(360, 150)
        Me.dgvSuperiori.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "SUPERIORI"
        '
        'dgvSubordonati
        '
        Me.dgvSubordonati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSubordonati.Location = New System.Drawing.Point(397, 27)
        Me.dgvSubordonati.MultiSelect = False
        Me.dgvSubordonati.Name = "dgvSubordonati"
        Me.dgvSubordonati.ReadOnly = True
        Me.dgvSubordonati.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSubordonati.Size = New System.Drawing.Size(372, 150)
        Me.dgvSubordonati.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(394, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "SUBORDONAȚI"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Sienna
        Me.Label2.Location = New System.Drawing.Point(12, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 18)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "SALARIATUL:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSalariat
        '
        Me.txtSalariat.Enabled = False
        Me.txtSalariat.Location = New System.Drawing.Point(128, 30)
        Me.txtSalariat.Name = "txtSalariat"
        Me.txtSalariat.Size = New System.Drawing.Size(165, 20)
        Me.txtSalariat.TabIndex = 3
        '
        'btnRevenire
        '
        Me.btnRevenire.BackColor = System.Drawing.Color.FloralWhite
        Me.btnRevenire.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRevenire.Location = New System.Drawing.Point(609, 19)
        Me.btnRevenire.Name = "btnRevenire"
        Me.btnRevenire.Size = New System.Drawing.Size(179, 40)
        Me.btnRevenire.TabIndex = 6
        Me.btnRevenire.Text = "REVENIRE LA PAGINA PRINCIPALA"
        Me.btnRevenire.UseVisualStyleBackColor = False
        '
        'Ierarhie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkKhaki
        Me.ClientSize = New System.Drawing.Size(800, 683)
        Me.Controls.Add(Me.btnRevenire)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSalariat)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Ierarhie"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IERARHIE SALARIAȚI"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvSalariati, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSuperiori, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSubordonati, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSalariat As TextBox
    Friend WithEvents dgvSubordonati As DataGridView
    Friend WithEvents btnAdaugareSuperiori As Button
    Friend WithEvents dgvSalariati As DataGridView
    Friend WithEvents dgvSuperiori As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents btnEliminareSubordonati As Button
    Friend WithEvents btnEliminareSuperiori As Button
    Friend WithEvents btnAdaugareSubordonati As Button
    Friend WithEvents btnRevenire As Button
    Friend WithEvents Label4 As Label
End Class
