<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ModificareDate
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModificareDate))
        Me.txtSalariat = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gbPersoane = New System.Windows.Forms.GroupBox()
        Me.btnStergereP = New System.Windows.Forms.Button()
        Me.btnAdaugareP = New System.Windows.Forms.Button()
        Me.dgvIntretinere = New System.Windows.Forms.DataGridView()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.dtpDataNastereP = New System.Windows.Forms.DateTimePicker()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtCNPPersoana = New System.Windows.Forms.TextBox()
        Me.txtPrenumePersoana = New System.Windows.Forms.TextBox()
        Me.txtNumePersoana = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpEmitere = New System.Windows.Forms.DateTimePicker()
        Me.txtTelefon = New System.Windows.Forms.TextBox()
        Me.txtLocalitate = New System.Windows.Forms.TextBox()
        Me.txtJudet = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtAdresa = New System.Windows.Forms.TextBox()
        Me.txtEmitent = New System.Windows.Forms.TextBox()
        Me.txtSerieCI = New System.Windows.Forms.TextBox()
        Me.txtNumarCI = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cmbFunctie = New System.Windows.Forms.ComboBox()
        Me.btnCalculeaza = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cbOra = New System.Windows.Forms.CheckBox()
        Me.cmbDepartament = New System.Windows.Forms.ComboBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtNormaLucru = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtSalariuIncadrare = New System.Windows.Forms.TextBox()
        Me.txtTarifOra = New System.Windows.Forms.TextBox()
        Me.btnModificare = New System.Windows.Forms.Button()
        Me.btnAnulare = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.gbPersoane.SuspendLayout()
        CType(Me.dgvIntretinere, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSalariat
        '
        Me.txtSalariat.Enabled = False
        Me.txtSalariat.Location = New System.Drawing.Point(315, 18)
        Me.txtSalariat.Name = "txtSalariat"
        Me.txtSalariat.Size = New System.Drawing.Size(141, 20)
        Me.txtSalariat.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Sienna
        Me.Label2.Location = New System.Drawing.Point(17, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(292, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "MODIFICAȚI DATELE SALARIATULUI:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.gbPersoane)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Location = New System.Drawing.Point(12, 68)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(776, 693)
        Me.Panel1.TabIndex = 3
        '
        'gbPersoane
        '
        Me.gbPersoane.Controls.Add(Me.btnStergereP)
        Me.gbPersoane.Controls.Add(Me.btnAdaugareP)
        Me.gbPersoane.Controls.Add(Me.dgvIntretinere)
        Me.gbPersoane.Controls.Add(Me.Label45)
        Me.gbPersoane.Controls.Add(Me.dtpDataNastereP)
        Me.gbPersoane.Controls.Add(Me.Label41)
        Me.gbPersoane.Controls.Add(Me.txtCNPPersoana)
        Me.gbPersoane.Controls.Add(Me.txtPrenumePersoana)
        Me.gbPersoane.Controls.Add(Me.txtNumePersoana)
        Me.gbPersoane.Controls.Add(Me.Label42)
        Me.gbPersoane.Controls.Add(Me.Label43)
        Me.gbPersoane.Location = New System.Drawing.Point(3, 421)
        Me.gbPersoane.Name = "gbPersoane"
        Me.gbPersoane.Size = New System.Drawing.Size(590, 256)
        Me.gbPersoane.TabIndex = 48
        Me.gbPersoane.TabStop = False
        Me.gbPersoane.Text = "ADĂUGARE PERSOANE ÎN ÎNTREȚINERE"
        '
        'btnStergereP
        '
        Me.btnStergereP.Location = New System.Drawing.Point(446, 95)
        Me.btnStergereP.Name = "btnStergereP"
        Me.btnStergereP.Size = New System.Drawing.Size(133, 23)
        Me.btnStergereP.TabIndex = 28
        Me.btnStergereP.Text = "ȘTERGERE"
        Me.btnStergereP.UseVisualStyleBackColor = True
        '
        'btnAdaugareP
        '
        Me.btnAdaugareP.Location = New System.Drawing.Point(226, 95)
        Me.btnAdaugareP.Name = "btnAdaugareP"
        Me.btnAdaugareP.Size = New System.Drawing.Size(121, 23)
        Me.btnAdaugareP.TabIndex = 29
        Me.btnAdaugareP.Text = "ADĂUGARE"
        Me.btnAdaugareP.UseVisualStyleBackColor = True
        '
        'dgvIntretinere
        '
        Me.dgvIntretinere.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvIntretinere.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIntretinere.Location = New System.Drawing.Point(6, 124)
        Me.dgvIntretinere.MultiSelect = False
        Me.dgvIntretinere.Name = "dgvIntretinere"
        Me.dgvIntretinere.ReadOnly = True
        Me.dgvIntretinere.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIntretinere.Size = New System.Drawing.Size(578, 126)
        Me.dgvIntretinere.TabIndex = 28
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(14, 78)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(89, 13)
        Me.Label45.TabIndex = 27
        Me.Label45.Text = "DATA NAȘTERII"
        '
        'dtpDataNastereP
        '
        Me.dtpDataNastereP.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDataNastereP.Location = New System.Drawing.Point(17, 94)
        Me.dtpDataNastereP.Name = "dtpDataNastereP"
        Me.dtpDataNastereP.Size = New System.Drawing.Size(123, 20)
        Me.dtpDataNastereP.TabIndex = 26
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(443, 27)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(29, 13)
        Me.Label41.TabIndex = 19
        Me.Label41.Text = "CNP"
        '
        'txtCNPPersoana
        '
        Me.txtCNPPersoana.Location = New System.Drawing.Point(446, 43)
        Me.txtCNPPersoana.Name = "txtCNPPersoana"
        Me.txtCNPPersoana.Size = New System.Drawing.Size(133, 20)
        Me.txtCNPPersoana.TabIndex = 23
        '
        'txtPrenumePersoana
        '
        Me.txtPrenumePersoana.Location = New System.Drawing.Point(226, 43)
        Me.txtPrenumePersoana.Name = "txtPrenumePersoana"
        Me.txtPrenumePersoana.Size = New System.Drawing.Size(121, 20)
        Me.txtPrenumePersoana.TabIndex = 25
        '
        'txtNumePersoana
        '
        Me.txtNumePersoana.Location = New System.Drawing.Point(15, 43)
        Me.txtNumePersoana.Name = "txtNumePersoana"
        Me.txtNumePersoana.Size = New System.Drawing.Size(125, 20)
        Me.txtNumePersoana.TabIndex = 24
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(12, 27)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(39, 13)
        Me.Label42.TabIndex = 20
        Me.Label42.Text = "NUME"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(223, 27)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(61, 13)
        Me.Label43.TabIndex = 21
        Me.Label43.Text = "PRENUME"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(599, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(170, 683)
        Me.PictureBox1.TabIndex = 47
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpEmitere)
        Me.GroupBox1.Controls.Add(Me.txtTelefon)
        Me.GroupBox1.Controls.Add(Me.txtLocalitate)
        Me.GroupBox1.Controls.Add(Me.txtJudet)
        Me.GroupBox1.Controls.Add(Me.txtEmail)
        Me.GroupBox1.Controls.Add(Me.txtAdresa)
        Me.GroupBox1.Controls.Add(Me.txtEmitent)
        Me.GroupBox1.Controls.Add(Me.txtSerieCI)
        Me.GroupBox1.Controls.Add(Me.txtNumarCI)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 196)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(590, 219)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "MODIFICARE DATE PERSONALE"
        '
        'dtpEmitere
        '
        Me.dtpEmitere.CustomFormat = ""
        Me.dtpEmitere.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEmitere.Location = New System.Drawing.Point(477, 46)
        Me.dtpEmitere.Name = "dtpEmitere"
        Me.dtpEmitere.Size = New System.Drawing.Size(102, 20)
        Me.dtpEmitere.TabIndex = 90
        '
        'txtTelefon
        '
        Me.txtTelefon.Location = New System.Drawing.Point(477, 180)
        Me.txtTelefon.Name = "txtTelefon"
        Me.txtTelefon.Size = New System.Drawing.Size(102, 20)
        Me.txtTelefon.TabIndex = 88
        '
        'txtLocalitate
        '
        Me.txtLocalitate.Location = New System.Drawing.Point(369, 180)
        Me.txtLocalitate.Name = "txtLocalitate"
        Me.txtLocalitate.Size = New System.Drawing.Size(102, 20)
        Me.txtLocalitate.TabIndex = 87
        '
        'txtJudet
        '
        Me.txtJudet.Location = New System.Drawing.Point(255, 180)
        Me.txtJudet.Name = "txtJudet"
        Me.txtJudet.Size = New System.Drawing.Size(108, 20)
        Me.txtJudet.TabIndex = 86
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(15, 180)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(234, 20)
        Me.txtEmail.TabIndex = 85
        '
        'txtAdresa
        '
        Me.txtAdresa.Location = New System.Drawing.Point(17, 113)
        Me.txtAdresa.Name = "txtAdresa"
        Me.txtAdresa.Size = New System.Drawing.Size(562, 20)
        Me.txtAdresa.TabIndex = 80
        '
        'txtEmitent
        '
        Me.txtEmitent.Location = New System.Drawing.Point(273, 47)
        Me.txtEmitent.Name = "txtEmitent"
        Me.txtEmitent.Size = New System.Drawing.Size(171, 20)
        Me.txtEmitent.TabIndex = 77
        '
        'txtSerieCI
        '
        Me.txtSerieCI.Location = New System.Drawing.Point(15, 47)
        Me.txtSerieCI.Name = "txtSerieCI"
        Me.txtSerieCI.Size = New System.Drawing.Size(102, 20)
        Me.txtSerieCI.TabIndex = 75
        '
        'txtNumarCI
        '
        Me.txtNumarCI.Location = New System.Drawing.Point(146, 47)
        Me.txtNumarCI.Name = "txtNumarCI"
        Me.txtNumarCI.Size = New System.Drawing.Size(92, 20)
        Me.txtNumarCI.TabIndex = 76
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(475, 164)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(56, 13)
        Me.Label22.TabIndex = 89
        Me.Label22.Text = "TELEFON"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(252, 164)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(56, 13)
        Me.Label21.TabIndex = 84
        Me.Label21.Text = "JUDEȚUL"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(366, 164)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(79, 13)
        Me.Label20.TabIndex = 83
        Me.Label20.Text = "LOCALITATEA"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 164)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(104, 13)
        Me.Label19.TabIndex = 82
        Me.Label19.Text = "ADRESA DE EMAIL"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 31)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 13)
        Me.Label14.TabIndex = 71
        Me.Label14.Text = "SERIA CI"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(12, 97)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(51, 13)
        Me.Label18.TabIndex = 79
        Me.Label18.Text = "ADRESĂ"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(143, 31)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 13)
        Me.Label15.TabIndex = 72
        Me.Label15.Text = "NUMĂR CI"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(270, 31)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(77, 13)
        Me.Label16.TabIndex = 73
        Me.Label16.Text = "ELIBERAT DE"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(474, 31)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(52, 13)
        Me.Label17.TabIndex = 74
        Me.Label17.Text = "LA DATA"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cmbFunctie)
        Me.GroupBox5.Controls.Add(Me.btnCalculeaza)
        Me.GroupBox5.Controls.Add(Me.Label26)
        Me.GroupBox5.Controls.Add(Me.Label32)
        Me.GroupBox5.Controls.Add(Me.cbOra)
        Me.GroupBox5.Controls.Add(Me.cmbDepartament)
        Me.GroupBox5.Controls.Add(Me.Label34)
        Me.GroupBox5.Controls.Add(Me.Label35)
        Me.GroupBox5.Controls.Add(Me.txtNormaLucru)
        Me.GroupBox5.Controls.Add(Me.Label40)
        Me.GroupBox5.Controls.Add(Me.txtSalariuIncadrare)
        Me.GroupBox5.Controls.Add(Me.txtTarifOra)
        Me.GroupBox5.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(590, 187)
        Me.GroupBox5.TabIndex = 46
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "MODIFICARE DATE SALARIZARE"
        '
        'cmbFunctie
        '
        Me.cmbFunctie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFunctie.FormattingEnabled = True
        Me.cmbFunctie.Location = New System.Drawing.Point(216, 43)
        Me.cmbFunctie.Name = "cmbFunctie"
        Me.cmbFunctie.Size = New System.Drawing.Size(148, 21)
        Me.cmbFunctie.TabIndex = 21
        '
        'btnCalculeaza
        '
        Me.btnCalculeaza.Location = New System.Drawing.Point(423, 40)
        Me.btnCalculeaza.Name = "btnCalculeaza"
        Me.btnCalculeaza.Size = New System.Drawing.Size(156, 24)
        Me.btnCalculeaza.TabIndex = 19
        Me.btnCalculeaza.Text = "CALCULEAZĂ"
        Me.btnCalculeaza.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(13, 27)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(89, 13)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "DEPARTAMENT"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(213, 27)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(53, 13)
        Me.Label32.TabIndex = 4
        Me.Label32.Text = "FUNCȚIA"
        '
        'cbOra
        '
        Me.cbOra.AutoSize = True
        Me.cbOra.Location = New System.Drawing.Point(17, 95)
        Me.cbOra.Name = "cbOra"
        Me.cbOra.Size = New System.Drawing.Size(209, 17)
        Me.cbOra.TabIndex = 18
        Me.cbOra.Text = "CALCUL SALARIU LA TARIF PE ORĂ"
        Me.cbOra.UseVisualStyleBackColor = True
        '
        'cmbDepartament
        '
        Me.cmbDepartament.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartament.FormattingEnabled = True
        Me.cmbDepartament.Location = New System.Drawing.Point(17, 43)
        Me.cmbDepartament.Name = "cmbDepartament"
        Me.cmbDepartament.Size = New System.Drawing.Size(145, 21)
        Me.cmbDepartament.TabIndex = 10
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(14, 128)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(105, 13)
        Me.Label34.TabIndex = 11
        Me.Label34.Text = "NORMA DE LUCRU"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(213, 128)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(106, 13)
        Me.Label35.TabIndex = 12
        Me.Label35.Text = "TARIF PE ORĂ (LEI)"
        '
        'txtNormaLucru
        '
        Me.txtNormaLucru.Location = New System.Drawing.Point(17, 144)
        Me.txtNormaLucru.Name = "txtNormaLucru"
        Me.txtNormaLucru.Size = New System.Drawing.Size(145, 20)
        Me.txtNormaLucru.TabIndex = 14
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(420, 128)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(162, 13)
        Me.Label40.TabIndex = 13
        Me.Label40.Text = "SALARIU DE ÎNCADRARE (LEI)"
        '
        'txtSalariuIncadrare
        '
        Me.txtSalariuIncadrare.Location = New System.Drawing.Point(423, 144)
        Me.txtSalariuIncadrare.Name = "txtSalariuIncadrare"
        Me.txtSalariuIncadrare.Size = New System.Drawing.Size(156, 20)
        Me.txtSalariuIncadrare.TabIndex = 8
        '
        'txtTarifOra
        '
        Me.txtTarifOra.Location = New System.Drawing.Point(216, 144)
        Me.txtTarifOra.Name = "txtTarifOra"
        Me.txtTarifOra.Size = New System.Drawing.Size(148, 20)
        Me.txtTarifOra.TabIndex = 7
        '
        'btnModificare
        '
        Me.btnModificare.BackColor = System.Drawing.Color.FloralWhite
        Me.btnModificare.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModificare.Location = New System.Drawing.Point(622, 12)
        Me.btnModificare.Name = "btnModificare"
        Me.btnModificare.Size = New System.Drawing.Size(152, 24)
        Me.btnModificare.TabIndex = 4
        Me.btnModificare.Text = "MODIFICĂ"
        Me.btnModificare.UseVisualStyleBackColor = False
        '
        'btnAnulare
        '
        Me.btnAnulare.BackColor = System.Drawing.Color.Red
        Me.btnAnulare.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnulare.Location = New System.Drawing.Point(622, 42)
        Me.btnAnulare.Name = "btnAnulare"
        Me.btnAnulare.Size = New System.Drawing.Size(152, 25)
        Me.btnAnulare.TabIndex = 5
        Me.btnAnulare.Text = "ANULARE"
        Me.btnAnulare.UseVisualStyleBackColor = False
        '
        'ModificareDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkKhaki
        Me.ClientSize = New System.Drawing.Size(800, 766)
        Me.Controls.Add(Me.btnAnulare)
        Me.Controls.Add(Me.btnModificare)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSalariat)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ModificareDate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MODIFICARE DATE SALARIAT"
        Me.Panel1.ResumeLayout(False)
        Me.gbPersoane.ResumeLayout(False)
        Me.gbPersoane.PerformLayout()
        CType(Me.dgvIntretinere, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSalariat As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents cmbFunctie As ComboBox
    Friend WithEvents btnCalculeaza As Button
    Friend WithEvents Label26 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents cmbDepartament As ComboBox
    Friend WithEvents Label34 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents txtNormaLucru As TextBox
    Friend WithEvents Label40 As Label
    Friend WithEvents txtSalariuIncadrare As TextBox
    Friend WithEvents txtTarifOra As TextBox
    Friend WithEvents cbOra As CheckBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtpEmitere As DateTimePicker
    Friend WithEvents txtTelefon As TextBox
    Friend WithEvents txtLocalitate As TextBox
    Friend WithEvents txtJudet As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtAdresa As TextBox
    Friend WithEvents txtEmitent As TextBox
    Friend WithEvents txtSerieCI As TextBox
    Friend WithEvents txtNumarCI As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents gbPersoane As GroupBox
    Friend WithEvents btnStergereP As Button
    Friend WithEvents btnAdaugareP As Button
    Friend WithEvents dgvIntretinere As DataGridView
    Friend WithEvents Label45 As Label
    Friend WithEvents dtpDataNastereP As DateTimePicker
    Friend WithEvents Label41 As Label
    Friend WithEvents txtCNPPersoana As TextBox
    Friend WithEvents txtPrenumePersoana As TextBox
    Friend WithEvents txtNumePersoana As TextBox
    Friend WithEvents Label42 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents btnModificare As Button
    Friend WithEvents btnAnulare As Button
End Class
