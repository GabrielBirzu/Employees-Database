Imports System.Data.OleDb
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Data.Odbc
Imports System.Windows.Forms.VisualStyles

Public Class Meniu

    Private con As New OleDbConnection("Provider= Microsoft.ACE.OLEDB.12.0;Data Source=Salariati.accdb")

    Public Nume As String

    Public Sub Majuscule(ByVal root As Control)

        For Each ctrl As Control In root.Controls
            Majuscule(ctrl)

            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).CharacterCasing = 1

            End If

        Next ctrl

    End Sub

    Public Sub Golire(ByVal root As Control)

        For Each ctrl As Control In root.Controls
            Golire(ctrl)

            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Text = String.Empty

            End If

        Next ctrl

    End Sub

    Private Sub Form2_Shown(sender As Object, e As EventArgs) Handles Me.Shown


        SaveFileDialog1.FileName = ""

        SaveFileDialog1.Filter = "PDF (*.pdf)|*.pdf"

        TextBox1.Text = ""

        TextBox2.Text = ""


        con.Open()

        Majuscule(Me)

        lblNume.Text = Nume & "!"




        txtFiltru.Enabled = False
        txtNumar.Enabled = False
        txtMarca.Enabled = False
        dtpDataNastereP.Enabled = False
        dtpSfarsit.Visible = False
        lblSfarsit.Visible = False
        btnCalculeaza.Visible = False
        txtTarifOra.Enabled = False
        txtNormaLucru.Enabled = False
        dgvAnterioare.MultiSelect = False
        dgvIntretinere.MultiSelect = False

        Dim cmdDepartament As OleDbDataAdapter = New OleDbDataAdapter("SELECT [DenumireDepartament]" &
                                                                      "FROM Departamente", con)

        Dim dt As New DataTable

        cmdDepartament.Fill(dt)

        cmbDepartament.DataSource = dt

        cmbDepartament.DisplayMember = "DenumireDepartament"


        Dim dt2 As New DataTable

        Dim cmdFunctie As OleDbDataAdapter = New OleDbDataAdapter("SELECT [DenumireFunctie]" &
                                                                  "FROM Functii ", con)

        cmdFunctie.Fill(dt2)

        cmbFunctie.DataSource = dt2

        cmbFunctie.DisplayMember = "DenumireFunctie"



        Dim cmdMax As OleDbDataAdapter = New OleDbDataAdapter("SELECT MAX([Marca]) " &
                                                              "FROM Salariati ", con)

        Dim dtMarca As New DataTable

        cmdMax.Fill(dtMarca)

        txtMarca.Text = dtMarca.Rows(0).Item(0) + 1


        con.Close()

        dtpNastere.Value = Today
        dtpEmitere.Value = Today
        dtpInceput.Value = Today
        dtpSfarsit.Value = Today



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAdaugareSalariat.Click


        Dim cmdContract As OleDbDataAdapter = New OleDbDataAdapter("SELECT MAX([NrContract]) " &
                                                                   "FROM Contracte ", con)

        Dim dtContract As New DataTable

        cmdContract.Fill(dtContract)

        Try

            txtNumar.Text = dtContract.Rows(0).Item(0) + 1

        Catch ex As Exception

            txtNumar.Text = 10000

        End Try

        pnlStatistici.Hide()
        pnlDosare.Hide()
        pnlDate.Show()
        pnlPontaj.Hide()
        pnlState.Hide()

        tabControl.SelectedIndex = 0
        tpSalariat.Show()

        con.Close()

    End Sub


    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles btnAnulare.Click

        con.Open()

        Dim index As Integer

        Dim x As String

        index = dgvAnterioare.Rows.Count - 1

        Do Until index < 0

            x = dgvAnterioare.Rows(index).Cells(0).Value

            Dim cmdStergereLoc As OleDbCommand = New OleDbCommand("DELETE FROM [LocuriMuncaAnterioare] " &
                                                                  "WHERE [NrInregistrare] Like '" & x & "'", con)

            cmdStergereLoc.ExecuteNonQuery()
            cmdStergereLoc.Dispose()

            index = index - 1

        Loop

        Dim index1 As Integer

        Dim y As String

        index1 = dgvIntretinere.Rows.Count - 1

        Do Until index1 < 0

            y = dgvIntretinere.Rows(index1).Cells(0).Value

            Dim cmdStergerePers As OleDbCommand = New OleDbCommand("DELETE FROM [PersoaneIntretinere] " &
                                                                   "WHERE [CNPPersoana] Like '" & y & "'", con)

            cmdStergerePers.ExecuteNonQuery()
            cmdStergerePers.Dispose()

            index1 = index1 - 1

        Loop

        Dim ds As New DataSet
        Dim dt As New DataTable
        ds.Tables.Add(dt)

        Dim cmdDate As OleDbDataAdapter = New OleDbDataAdapter("SELECT [NrInregistrare],[DataInceput],[DataSfarsit],[Functia],[Firma],[VechimeFirma] " &
                                                               "FROM [LocuriMuncaAnterioare] " &
                                                               "WHERE [Marca] Is Null", con)

        cmdDate.Fill(dt)

        dgvAnterioare.DataSource = dt.DefaultView


        Dim ds2 As New DataSet
        Dim dt2 As New DataTable
        ds2.Tables.Add(dt2)

        Dim cmdDatePersoana As OleDbDataAdapter = New OleDbDataAdapter("SELECT [CNPPersoana],[NumePersoana],[PrenumePersoana],[DataNasterePersoana] " &
                                                                       "FROM PersoaneIntretinere " &
                                                                       "WHERE [Marca] Is Null", con)

        cmdDate.Fill(dt2)

        dgvIntretinere.DataSource = dt2.DefaultView

        con.Close()

        pnlDate.Visible = False

        Golire(pnlDate)

        dtpNastere.Value = Today
        dtpEmitere.Value = Today
        dtpInceput.Value = Today
        dtpSfarsit.Value = Today
        rbNecasatorit.Checked = True
        rbtNedeterminata.Checked = True
        cbOra.Checked = False

        dtpDataNastereP.Value = Today
        dtpDeLa.Value = Today
        dtpPanaLa.Value = Today

        tabControl.SelectedIndex() = 0

    End Sub



    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btnSalvare.Click


        If txtMarca.Text = "" Or txtNume.Text = "" Or txtPrenume.Text = "" Or txtNumar.Text = "" Or txtCNP.Text = "" Or txtLoc.Text = "" Or txtSerieCI.Text = "" Or txtNumarCI.Text = "" Or txtEmitent.Text = "" Or txtAdresa.Text = "" Or txtEmail.Text = "" Or txtJudet.Text = "" Or txtLocalitate.Text = "" Or txtTelefon.Text = "" Or cmbDepartament.Text = "" Or txtProfesie.Text = "" Or cmbFunctie.Text = "" Or cmbTip.Text = "" Or txtSalariuIncadrare.Text = "" Then

            MsgBox("NU AU FOST INTRODUSE TOATE DATELE!", vbExclamation, "ATENȚIE!") : Exit Sub

        End If

        con.Open()

        Dim cmdDepartament As OleDbCommand = New OleDbCommand("SELECT CodDepartament " &
                                                              "FROM Departamente " &
                                                              "WHERE DenumireDepartament Like '" & cmbDepartament.Text & "'", con)

        Dim CitireD As OleDbDataReader

        CitireD = cmdDepartament.ExecuteReader

        CitireD.Read()

        Dim D As Integer = CitireD("CodDepartament")


        Dim cmdFunctie As OleDbCommand = New OleDbCommand("SELECT CodFunctie " &
                                                          "FROM Functii " &
                                                          "WHERE DenumireFunctie Like '" & cmbFunctie.Text & "'", con)

        Dim CitireF As OleDbDataReader

        CitireF = cmdFunctie.ExecuteReader

        CitireF.Read()

        Dim F As Integer = CitireF("CodFunctie")

        Dim cmdMarca As OleDbCommand = New OleDbCommand("SELECT CNP " &
                                                        "FROM Salariati " &
                                                        "WHERE CNP Like '" & txtCNP.Text & "'", con)

        Dim CitireM As OleDbDataReader

        CitireM = cmdMarca.ExecuteReader

        If (CitireM.Read() = True) Then

            MsgBox("ANGAJATUL CU CNP-ul " & txtCNP.Text & " EXISTĂ DEJA ÎN BAZA DE DATE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End If



        Dim cmdAdaugare As OleDbCommand


        If cbHandicap.Checked = True Then

            cmdAdaugare = New OleDbCommand("INSERT INTO Salariati([Marca],[CNP],[SeriaCI],[NumarCI],[Emitent]," &
                                           "[DataEmitere],[Nume],[Prenume],[DataNastere],[LocNastere],[Adresa],[Email]," &
                                           "[Judetul],[Localitatea],[Telefon],[Vechime],[Casatorit],[Profesie],[Handicap],[Departament],[Functie])" &
                                           "VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)", con)
            Try

                cmdAdaugare.Parameters.Add(New OleDbParameter("Marca", CType(txtMarca.Text, Integer)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("CNP", CType(txtCNP.Text, String)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("SeriaCI", CType(txtSerieCI.Text, String)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("NumarCI", CType(txtNumarCI.Text, Integer)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Emitent", CType(txtEmitent.Text, String)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("DataEmitere", CType(dtpEmitere.Value.Date, Date)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Nume", CType(txtNume.Text, String)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Prenume", CType(txtPrenume.Text, String)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("DataNastere", CType(dtpNastere.Value.Date, Date)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("LocNastere", CType(txtLoc.Text, String)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Adresa", CType(txtAdresa.Text, String)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Email", CType(txtEmail.Text, String)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Judetul", CType(txtJudet.Text, String)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Localitatea", CType(txtLocalitate.Text, String)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Telefon", CType(txtTelefon.Text, String)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Vechime", CType(txtAniSocietate.Text & " ani " & txtLuniSocietate.Text & " luni " & txtZileSocietate.Text & " zile", String)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Casatorit", CType(rbCasatorit.Checked = True, Boolean)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Profesie", CType(txtProfesie.Text, String)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Handicap", CType(cbHandicap.Checked = True, Boolean)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Departament", CType(D, Integer)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Functie", CType(F, Integer)))

            Catch ex As Exception

                MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
                con.Close() : Exit Sub

            End Try

        Else

            cbHandicap.Checked = False

            cmdAdaugare = New OleDbCommand("INSERT INTO Salariati([Marca],[CNP],[SeriaCI],[NumarCI],[Emitent]," &
                                           "[DataEmitere],[Nume],[Prenume],[DataNastere],[LocNastere],[Adresa],[Email]," &
                                           "[Judetul],[Localitatea],[Telefon],[Vechime],[Casatorit],[Profesie],[Departament],[Functie])" &
                                           "VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)", con)
            Try

                cmdAdaugare.Parameters.Add(New OleDbParameter("Marca", CType(txtMarca.Text, Integer)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("CNP", CType(txtCNP.Text, String)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("SeriaCI", CType(txtSerieCI.Text, String)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("NumarCI", CType(txtNumarCI.Text, Integer)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Emitent", CType(txtEmitent.Text, String)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("DataEmitere", CType(dtpEmitere.Value.Date, Date)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Nume", CType(txtNume.Text, String)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Prenume", CType(txtPrenume.Text, String)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("DataNastere", CType(dtpNastere.Value.Date, Date)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("LocNastere", CType(txtLoc.Text, String)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Adresa", CType(txtAdresa.Text, String)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Email", CType(txtEmail.Text, String)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Judetul", CType(txtJudet.Text, String)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Localitatea", CType(txtLocalitate.Text, String)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Telefon", CType(txtTelefon.Text, String)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Vechime", CType(txtAniSocietate.Text & " ani " & txtLuniSocietate.Text & " luni " & txtZileSocietate.Text & " zile", String)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Casatorit", CType(rbCasatorit.Checked = True, Boolean)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Profesie", CType(txtProfesie.Text, String)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Departament", CType(D, Integer)))
                cmdAdaugare.Parameters.Add(New OleDbParameter("Functie", CType(F, Integer)))

            Catch ex As Exception

                MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
                con.Close() : Exit Sub

            End Try

        End If


        Dim cmdAdaugareContract As OleDbCommand

        If rbtDeterminata.Checked = True Then

            Try

                cmdAdaugareContract = New OleDbCommand("INSERT INTO Contracte([NrContract],[DataInceputContract],[DataSfarsitContract],[SalariuIncadrare],[Marca])" &
                                                       "VALUES (?,?,?,?,?)", con)

                cmdAdaugareContract.Parameters.Add(New OleDbParameter("NrContract", CType(txtNumar.Text, Integer)))
                cmdAdaugareContract.Parameters.Add(New OleDbParameter("DataInceput", CType(dtpInceput.Value.Date, Date)))
                cmdAdaugareContract.Parameters.Add(New OleDbParameter("DataSfarsit", CType(dtpSfarsit.Value.Date, Date)))
                cmdAdaugareContract.Parameters.Add(New OleDbParameter("SalariuIncadrare", CType(txtSalariuIncadrare.Text, Integer)))
                cmdAdaugareContract.Parameters.Add(New OleDbParameter("Marca", CType(txtMarca.Text, Integer)))

            Catch ex As Exception

                MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
                con.Close() : Exit Sub

            End Try


        Else

            Try

                cmdAdaugareContract = New OleDbCommand("INSERT INTO Contracte([NrContract],[DataInceputContract],[SalariuIncadrare],[Marca])" &
                                                       "VALUES (?,?,?,?)", con)

                cmdAdaugareContract.Parameters.Add(New OleDbParameter("NrContract", CType(txtNumar.Text, Integer)))
                cmdAdaugareContract.Parameters.Add(New OleDbParameter("DataInceput", CType(dtpInceput.Value.Date, Date)))
                cmdAdaugareContract.Parameters.Add(New OleDbParameter("SalariuIncadrare", CType(txtSalariuIncadrare.Text, Integer)))
                cmdAdaugareContract.Parameters.Add(New OleDbParameter("Marca", CType(txtMarca.Text, Integer)))

            Catch ex As Exception

                MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
                con.Close() : Exit Sub

            End Try

        End If



        Dim cmdAdaugareSpor As OleDbCommand

        If chbSporConditii.Checked = True Then

            Try

                cmdAdaugareSpor = New OleDbCommand("INSERT INTO SporuriContract([DenumireSpor],[NrContract])" &
                                                   "VALUES (?,?)", con)

                cmdAdaugareSpor.Parameters.Add(New OleDbParameter("DenumireSpor", CType("SPOR PENTRU CONDIȚII GRELE", String)))
                cmdAdaugareSpor.Parameters.Add(New OleDbParameter("NrContract", CType(txtNumar.Text, Integer)))

            Catch ex As Exception

                MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
                con.Close() : Exit Sub

            End Try

        End If



        Dim cmdAdaugareCAS As OleDbCommand

        If chbCAS.Checked = True Then

            Try

                cmdAdaugareCAS = New OleDbCommand("INSERT INTO ContributiiSalariat([Marca],[Contributie])" &
                                                  "VALUES (?,?)", con)

                cmdAdaugareCAS.Parameters.Add(New OleDbParameter("Marca", CType(txtMarca.Text, Integer)))
                cmdAdaugareCAS.Parameters.Add(New OleDbParameter("Contributie", CType("CAS", String)))

            Catch ex As Exception

                MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
                con.Close() : Exit Sub

            End Try

        End If



        Dim cmdAdaugareCASS As OleDbCommand

        If chbCASS.Checked = True Then

            Try

                cmdAdaugareCASS = New OleDbCommand("INSERT INTO ContributiiSalariat([Marca],[Contributie])" &
                                                   "VALUES (?,?)", con)

                cmdAdaugareCASS.Parameters.Add(New OleDbParameter("Marca", CType(txtMarca.Text, Integer)))
                cmdAdaugareCASS.Parameters.Add(New OleDbParameter("Contributie", CType("CASS", String)))

            Catch ex As Exception

                MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
                con.Close() : Exit Sub

            End Try

        End If



        Dim raspuns As Integer = MsgBox("SUNTEȚI SIGUR CĂ VREȚI SĂ SALVAȚI SALARIATUL ÎN BAZA DE DATE?", vbYesNo, "ATENȚIE")


        If raspuns = vbYes Then

            Try

                cmdAdaugare.ExecuteNonQuery()
                cmdAdaugare.Dispose()

                cmdAdaugareContract.ExecuteNonQuery()
                cmdAdaugareContract.Dispose()

                Dim index As Integer

                Dim x As String

                index = dgvAnterioare.Rows.Count - 1


                Do Until index < 0

                    x = dgvAnterioare.Rows(index).Cells(0).Value

                    Dim cmdActualizareLocMunca As OleDbCommand = New OleDbCommand("UPDATE LocuriMuncaAnterioare SET [Marca] = '" & txtMarca.Text & "' WHERE [NrInregistrare] Like '" & x & "'", con)

                    cmdActualizareLocMunca.ExecuteNonQuery()
                    cmdActualizareLocMunca.Dispose()

                    index = index - 1

                Loop

                Dim index1 As Integer

                Dim y As String

                index1 = dgvIntretinere.Rows.Count - 1


                Do Until index1 < 0

                    y = dgvIntretinere.Rows(index1).Cells(0).Value

                    Dim cmdPersoaneIntretinere As OleDbCommand = New OleDbCommand("UPDATE PersoaneIntretinere SET [Marca] = '" & txtMarca.Text & "' WHERE [CNPPersoana] Like '" & y & "'", con)

                    cmdPersoaneIntretinere.ExecuteNonQuery()
                    cmdPersoaneIntretinere.Dispose()

                    index1 = index1 - 1

                Loop

                tabControl.Refresh()

            Catch ex As Exception

                MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
                con.Close() : Exit Sub

            End Try

            MsgBox("ANGAJATUL A FOST INTRODUS CU SUCCES ÎN BAZA DE DATE!", vbInformation, "ADĂUGARE SALARIAT")

            Golire(pnlDate)




            Dim cmdMax As OleDbDataAdapter = New OleDbDataAdapter("SELECT MAX([Marca]) " &
                                                                  "FROM Salariati ", con)

            Dim dtMarca As New DataTable

            cmdMax.Fill(dtMarca)

            txtMarca.Text = dtMarca.Rows(0).Item(0) + 1




            Dim cmdContract As OleDbDataAdapter = New OleDbDataAdapter("SELECT MAX([NrContract]) " &
                                                                       "FROM Contracte ", con)

            Dim dtContract As New DataTable

            cmdContract.Fill(dtContract)

            txtNumar.Text = dtContract.Rows(0).Item(0) + 1

            dtpNastere.Value = Today
            dtpEmitere.Value = Today
            dtpInceput.Value = Today
            dtpSfarsit.Value = Today
            rbNecasatorit.Checked = True
            rbtNedeterminata.Checked = True
            cbOra.Checked = False

            dtpDataNastereP.Value = Today
            dtpDeLa.Value = Today
            dtpPanaLa.Value = Today

            tabControl.SelectedIndex() = 0


            Dim ds As New DataSet
            Dim dt As New DataTable
            ds.Tables.Add(dt)

            Dim cmdDate As OleDbDataAdapter = New OleDbDataAdapter("SELECT [NrInregistrare],[DataInceput],[DataSfarsit],[Functia],[Firma],[VechimeFirma] " &
                                                                   "FROM [LocuriMuncaAnterioare] " &
                                                                   "WHERE [Marca] Is Null", con)

            cmdDate.Fill(dt)

            dgvAnterioare.DataSource = dt.DefaultView


            Dim ds2 As New DataSet
            Dim dt2 As New DataTable
            ds2.Tables.Add(dt2)

            Dim cmdDatePersoana As OleDbDataAdapter = New OleDbDataAdapter("SELECT [CNPPersoana],[NumePersoana],[PrenumePersoana],[DataNasterePersoana] " &
                                                                           "FROM PersoaneIntretinere " &
                                                                           "WHERE [Marca] Is Null", con)

            cmdDate.Fill(dt2)

            dgvIntretinere.DataSource = dt2.DefaultView

            con.Close()

        Else

            con.Close() : Exit Sub

        End If

    End Sub



    Private Sub txtCNP_Leave(sender As Object, e As EventArgs) Handles txtCNP.Leave

        If Len(txtCNP.Text) = 13 Then

            Dim DataNastere As String

            DataNastere = Mid(txtCNP.Text, 6, 2) & "/" & Mid(txtCNP.Text, 4, 2) & "/" & Mid(txtCNP.Text, 2, 2)

            Try

                Dim Data As Date = Convert.ToDateTime(DataNastere)

                dtpNastere.Value = Data

            Catch ex As Exception

                MsgBox("CNP ERONAT!", vbExclamation, "EROARE") : Exit Sub

            End Try


        ElseIf txtCNP.Text = "" Then



        Else

            txtCNP.Select()
            MsgBox("CNP ERONAT!", vbExclamation, "EROARE") : Exit Sub

        End If

        Dim Varsta As Integer

        If dtpNastere.Value.Day < Date.Now.Day And dtpNastere.Value.Month > Date.Now.Month Then

            Varsta = (Today.Year - dtpNastere.Value.Year) - 1

            txtVarsta.Text = Varsta

        Else

            Varsta = Today.Year - dtpNastere.Value.Year

            txtVarsta.Text = Varsta

        End If

        If txtCNP.Text = "" Then

            txtVarsta.Text = ""

        ElseIf Microsoft.VisualBasic.Left(txtCNP.Text, 1) = 1 Then

            txtSex.Text = "MASCULIN"

        Else

            txtSex.Text = "FEMININ"

        End If

    End Sub

    Private Sub btnAdaugare_Click(sender As Object, e As EventArgs) Handles btnAdaugare.Click

        If txtAniMunca.Text = "" Or txtLuniMunca.Text = "" Or txtZileMunca.Text = "" Or txtFunctie.Text = "" Or txtFirma.Text = "" Then

            MsgBox("NU AU FOST INTRODUSE TOATE DATELE!", vbExclamation, "ATENȚIE!") : Exit Sub

        End If

        con.Open()

        Dim cmdAdaugareLocMunca As OleDbCommand

        cmdAdaugareLocMunca = New OleDbCommand("INSERT INTO LocuriMuncaAnterioare([DataInceput],[DataSfarsit],[Functia],[Firma],[VechimeFirma])" &
                                               "VALUES (?,?,?,?,?)", con)

        Try

            cmdAdaugareLocMunca.Parameters.Add(New OleDbParameter("DataInceput", CType(dtpDeLa.Value.Date, Date)))
            cmdAdaugareLocMunca.Parameters.Add(New OleDbParameter("DataSfarsit", CType(dtpPanaLa.Value.Date, Date)))
            cmdAdaugareLocMunca.Parameters.Add(New OleDbParameter("Functia", CType(txtFunctie.Text, String)))
            cmdAdaugareLocMunca.Parameters.Add(New OleDbParameter("Firma", CType(txtFirma.Text, String)))
            cmdAdaugareLocMunca.Parameters.Add(New OleDbParameter("VechimeFirma", CType(txtAniMunca.Text & " ani " & txtLuniMunca.Text & " luni " & txtZileMunca.Text & " zile", String)))

        Catch ex As Exception

            MsgBox("INTRODUCEȚI TOATE DATELE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End Try


        Try

            cmdAdaugareLocMunca.ExecuteNonQuery()
            cmdAdaugareLocMunca.Dispose()
            tabControl.Refresh()

            Golire(gbLocuri)


        Catch ex As Exception

            MsgBox(ex.Message)
            con.Close() : Exit Sub

        End Try

        Dim ds As New DataSet
        Dim dt As New DataTable
        ds.Tables.Add(dt)

        Dim cmdDate As OleDbDataAdapter = New OleDbDataAdapter("SELECT [NrInregistrare],[DataInceput],[DataSfarsit],[Functia],[Firma],[VechimeFirma] " &
                                                               "FROM [LocuriMuncaAnterioare] " &
                                                               "WHERE [Marca] Is Null", con)

        cmdDate.Fill(dt)

        dgvAnterioare.DataSource = dt.DefaultView


        con.Close()

    End Sub



    Private Sub rbtDeterminata_CheckedChanged(sender As Object, e As EventArgs) Handles rbtDeterminata.CheckedChanged


        dtpSfarsit.Visible = True
        lblSfarsit.Visible = True

    End Sub

    Private Sub rbtNedeterminata_CheckedChanged(sender As Object, e As EventArgs) Handles rbtNedeterminata.CheckedChanged

        dtpSfarsit.Visible = False
        lblSfarsit.Visible = False

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnIesire.Click


        Me.Close()
        Autentificare.Show()

    End Sub

    Private Sub dtpSfarsit_Leave(sender As Object, e As EventArgs) Handles dtpSfarsit.Leave


        If dtpSfarsit.Value < dtpInceput.Value Then

            MsgBox("DATA INCORECTĂ!", vbExclamation, "EROARE")
            dtpSfarsit.Select()
            dtpInceput.Enabled = False

        Else

            dtpInceput.Enabled = True

        End If

    End Sub



    Private Sub dtpInceput_Leave(sender As Object, e As EventArgs) Handles dtpInceput.Leave



        If dtpSfarsit.Visible = False Then



        ElseIf dtpInceput.Value > dtpSfarsit.Value Then

            MsgBox("DATA INCORECTĂ!", vbExclamation, "EROARE")
            dtpInceput.Select()
            dtpSfarsit.Enabled = False

        Else

            dtpSfarsit.Enabled = True

        End If


    End Sub



    Private Sub btnCalculeaza_Click(sender As Object, e As EventArgs) Handles btnCalculeaza.Click

        If cbOra.Checked = True And (txtNormaLucru.Text = "" Or txtTarifOra.Text = "") Then

            MsgBox("NU AU FOST INTRODUSE TOATE DATELE!", vbExclamation, "ATENȚIE!") : Exit Sub

        ElseIf cbOra.Checked = True Then

            Dim Tarif As Integer
            Dim Norma As Integer

            Tarif = txtTarifOra.Text
            Norma = txtNormaLucru.Text

            txtSalariuIncadrare.Enabled = False
            txtSalariuIncadrare.Text = Tarif * Norma

        End If


    End Sub

    Private Sub cbOra_CheckedChanged(sender As Object, e As EventArgs) Handles cbOra.CheckedChanged

        If cbOra.Checked = True Then

            txtSalariuIncadrare.Enabled = False
            btnCalculeaza.Visible = True
            txtTarifOra.Enabled = True
            txtNormaLucru.Enabled = True

            txtSalariuIncadrare.Clear()

        Else

            txtSalariuIncadrare.Enabled = True
            btnCalculeaza.Visible = False
            txtTarifOra.Enabled = False
            txtNormaLucru.Enabled = False

            txtTarifOra.Clear()
            txtNormaLucru.Clear()
            txtSalariuIncadrare.Clear()

        End If

    End Sub

    Private Sub cmbTip_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTip.SelectedIndexChanged

        If cmbTip.SelectedIndex = 1 Then

            cbHandicap.Checked = True

        Else

            cbHandicap.Checked = False

        End If

    End Sub

    Private Sub btnAdaugareP_Click(sender As Object, e As EventArgs) Handles btnAdaugareP.Click

        If txtNumePersoana.Text = "" Or txtPrenumePersoana.Text = "" Or txtCNPPersoana.Text = "" Then

            MsgBox("NU AU FOST INTRODUSE TOATE DATELE!", vbExclamation, "ATENȚIE!") : Exit Sub

        End If


        con.Open()

        Dim cmdAdaugare As OleDbCommand = New OleDbCommand("INSERT INTO PersoaneIntretinere ([CNPPersoana],[NumePersoana],[PrenumePersoana],[DataNasterePersoana])" &
                                                           "VALUES (?,?,?,?)", con)

        Try

            cmdAdaugare.Parameters.Add(New OleDbParameter("CNPPersoana", CType(txtCNPPersoana.Text, String)))
            cmdAdaugare.Parameters.Add(New OleDbParameter("NumePersoana", CType(txtNumePersoana.Text, String)))
            cmdAdaugare.Parameters.Add(New OleDbParameter("PrenumePersoana", CType(txtPrenumePersoana.Text, String)))
            cmdAdaugare.Parameters.Add(New OleDbParameter("DataNasterePersoana", CType(dtpDataNastereP.Value.Date, Date)))


        Catch ex As Exception

            MsgBox("INTRODUCEȚI TOATE DATELE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End Try

        Try

            cmdAdaugare.ExecuteNonQuery()
            cmdAdaugare.Dispose()
            tabControl.Refresh()

            Golire(gbPersoane)

            dtpDataNastereP.Value = Today

        Catch ex As Exception

            MsgBox("PERSOANA CU CNP-ul " & txtCNPPersoana.Text & " EXISTĂ ÎN BAZA DE DATE!", vbInformation, "EROARE")
            con.Close() : Exit Sub

        End Try


        Dim dt As New DataTable

        Dim cmdDate As OleDbDataAdapter = New OleDbDataAdapter("SELECT [CNPPersoana],[NumePersoana],[PrenumePersoana],[DataNasterePersoana] " &
                                                               "FROM PersoaneIntretinere " &
                                                               "WHERE [Marca] Is Null", con)

        cmdDate.Fill(dt)

        dgvIntretinere.DataSource = dt.DefaultView

        con.Close()

    End Sub

    Private Sub btnStergere_Click(sender As Object, e As EventArgs) Handles btnStergere.Click

        Dim index As Integer

        Dim x As String

        Try

            index = dgvAnterioare.CurrentRow.Index

        Catch ex As NullReferenceException

            MsgBox("NU EXISTĂ ÎNREGISTRĂRI ÎN BAZA DE DATE!", vbExclamation, "EROARE") : Exit Sub

        End Try

        x = dgvAnterioare.Rows(index).Cells(0).Value


        dgvAnterioare.Rows.RemoveAt(index)


        con.Open()

        Dim cmdStergereLoc As OleDbCommand = New OleDbCommand("DELETE FROM [LocuriMuncaAnterioare] " &
                                                              "WHERE [NrInregistrare] Like '" & x & "'", con)


        Try

            cmdStergereLoc.ExecuteNonQuery()
            cmdStergereLoc.Dispose()
            dgvAnterioare.Refresh()

        Catch ex As Exception

            MsgBox("PERSOANA CU CNP-ul " & x & " EXISTĂ ÎN BAZA DE DATE!", vbInformation, "EROARE")
            con.Close()

        End Try

        MsgBox("ÎNREGISTRAREA CU NUMĂRUL " & x & " A FOST ȘTEARSĂ DIN BAZA DE DATE!", vbInformation, "SUCCES")


        Dim dt As New DataTable

        Dim cmdCautare As OleDbDataAdapter = New OleDbDataAdapter("SELECT Marca, Nume, Prenume, CNP, DataNastere, Adresa, Telefon, Casatorit, Vechime, Handicap, Profesie, DenumireFunctie, DenumireDepartament " &
                                                                          "FROM Departamente INNER JOIN (Salariati INNER JOIN Functii ON Salariati.Functie=Functii.CodFunctie) ON Salariati.Departament=Departamente.CodDepartament " &
                                                                          "WHERE Nume & '" & " " & "' & Prenume LIKE '" & txtFiltru.Text & "'", con)
        cmdCautare.Fill(dt)

        dgvSalariati.DataSource = dt

        con.Close()

    End Sub

    Private Sub btnStergereP_Click(sender As Object, e As EventArgs) Handles btnStergereP.Click


        Dim index As Integer

        Dim x As String

        Try

            index = dgvIntretinere.CurrentRow.Index

        Catch ex As NullReferenceException

            MsgBox("NU EXISTĂ ÎNREGISTRĂRI ÎN BAZA DE DATE!", vbExclamation, "EROARE") : Exit Sub

        End Try


        x = dgvIntretinere.Rows(index).Cells(0).Value

        dgvIntretinere.Rows.RemoveAt(index)



        con.Open()

        Dim cmdStergerePer As OleDbCommand = New OleDbCommand("DELETE FROM [PersoaneIntretinere] " &
                                                              "WHERE [CNPPersoana] Like '" & x & "'", con)


        Try

            cmdStergerePer.ExecuteNonQuery()
            cmdStergerePer.Dispose()
            dgvIntretinere.Refresh()

        Catch ex As Exception

            MsgBox(ex.Message)
            con.Close()

        End Try

        MsgBox("PERSOANA CU CNP-ul " & x & " A FOST ȘTEARSĂ DIN BAZA DE DATE!", vbInformation, "SUCCES")


        Dim dt As New DataTable

        Dim cmdDate As OleDbDataAdapter = New OleDbDataAdapter("SELECT CNPPersoana, NumePersoana, PrenumePersoana, DataNasterePersoana " &
                                                               "FROM PersoaneIntretinere " &
                                                               "WHERE Marca Is Null", con)

        cmdDate.Fill(dt)

        dgvIntretinere.DataSource = dt.DefaultView

        con.Close()

    End Sub

    Private Sub txtCNPPersoana_Leave(sender As Object, e As EventArgs) Handles txtCNPPersoana.Leave


        If Len(txtCNPPersoana.Text) = 13 Then

            Dim DataNastere As String

            DataNastere = Mid(txtCNPPersoana.Text, 6, 2) & "/" & Mid(txtCNPPersoana.Text, 4, 2) & "/" & Mid(txtCNPPersoana.Text, 2, 2)

            Dim Data As Date = Convert.ToDateTime(DataNastere)

            dtpDataNastereP.Value = Data

        ElseIf txtCNPPersoana.Text = "" Then



        Else

            txtCNPPersoana.Select()
            MsgBox("CNP ERONAT!", vbExclamation, "EROARE") : Exit Sub

        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnDosare.Click

        Golire(pnlDosare)

        pnlStatistici.Hide()
        pnlPontaj.Hide()
        pnlDate.Hide()
        pnlDosare.Show()
        pnlState.Hide()

        tbDosare.SelectedIndex = 0

        con.Open()

        Dim cmdSalariati As OleDbDataAdapter = New OleDbDataAdapter("SELECT Marca, CNP, Nume, Prenume, DataNastere, Telefon, Vechime, Profesie, DenumireFunctie As [Denumire Functie], DenumireDepartament As [Denumire Departament]  " &
                                                                    "FROM Departamente INNER JOIN (Salariati INNER JOIN Functii ON Salariati.Functie=Functii.CodFunctie) ON Salariati.Departament=Departamente.CodDepartament " &
                                                                    "WHERE Activ = True " &
                                                                    "ORDER BY Marca ASC ", con)


        Dim dtSalariati As New DataTable

        cmdSalariati.Fill(dtSalariati)

        dgvSalariati.DataSource = dtSalariati




        Dim cmdDepartamente As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                       "FROM Departamente " &
                                                                       "ORDER BY CodDepartament ", con)

        Dim dtDepartamente As New DataTable

        cmdDepartamente.Fill(dtDepartamente)

        dgvDepartamente.DataSource = dtDepartamente.DefaultView




        Dim cmdFunctii As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                  "FROM Functii " &
                                                                  "ORDER BY CodFunctie ", con)

        Dim dtFunctii As New DataTable

        cmdFunctii.Fill(dtFunctii)

        dgvFunctii.DataSource = dtFunctii.DefaultView




        Dim cmdContributii As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                      "FROM Contributii " &
                                                                      "ORDER BY DenumireContributie ", con)

        Dim dtContributii As New DataTable

        cmdContributii.Fill(dtContributii)

        dgvContributii.DataSource = dtContributii.DefaultView




        Dim cmdSporuri As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                  "FROM Sporuri " &
                                                                  "ORDER BY TipSpor ", con)

        Dim dtSporuri As New DataTable

        cmdSporuri.Fill(dtSporuri)

        dgvSporuri.DataSource = dtSporuri.DefaultView




        Dim cmdPrime As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                "FROM Prime " &
                                                                "ORDER BY TipPrima ", con)

        Dim dtPrime As New DataTable

        cmdPrime.Fill(dtPrime)

        dgvPrime.DataSource = dtPrime.DefaultView




        Dim cmdRetineri As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                   "FROM Retineri " &
                                                                   "ORDER BY TipRetinere ", con)

        Dim dtRetineri As New DataTable

        cmdRetineri.Fill(dtRetineri)

        dgvRetineri.DataSource = dtRetineri.DefaultView




        Dim cmdFostiSalariati As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                         "FROM Salariati " &
                                                                         "WHERE Activ = False " &
                                                                         "ORDER BY Marca ASC ", con)

        Dim dtFostiSalariati As New DataTable

        cmdFostiSalariati.Fill(dtFostiSalariati)

        dgvFosti.DataSource = dtFostiSalariati.DefaultView

        con.Close()

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles btnStergereAngajat.Click

        con.Open()

        Dim index As Integer

        Dim x As String

        Try

            index = dgvSalariati.CurrentRow.Index

        Catch ex As NullReferenceException

            MsgBox("NU EXISTĂ ÎNREGISTRĂRI ÎN BAZA DE DATE!", vbExclamation, "EROARE") : Exit Sub

        End Try

        x = dgvSalariati.Rows(index).Cells(0).Value

        dgvSalariati.Rows.RemoveAt(index)



        Dim cmdStergereAng As OleDbCommand = New OleDbCommand("UPDATE Salariati " &
                                                              "SET Activ = False " &
                                                              "WHERE [Marca] Like '" & x & "'", con)

        Try

            cmdStergereAng.ExecuteNonQuery()
            cmdStergereAng.Dispose()
            dgvSalariati.Refresh()

        Catch ex As Exception

            MsgBox(ex.Message)
            con.Close()

        End Try



        Dim cmdFostiSalariati As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                         "FROM Salariati " &
                                                                         "WHERE Activ = False " &
                                                                         "ORDER BY Marca ASC ", con)

        Dim dtFostiSalariati As New DataTable

        cmdFostiSalariati.Fill(dtFostiSalariati)

        dgvFosti.DataSource = dtFostiSalariati.DefaultView



        MsgBox("ANGAJATUL CU MARCA " & x & " A FOST SALVAT ÎN BAZA DE DATE INACTIV!", vbInformation, "SUCCES")


        Dim cmdSalariati As OleDbDataAdapter = New OleDbDataAdapter("SELECT Marca, CNP, Nume, Prenume, DataNastere, Adresa, Telefon, Casatorit, Vechime, Handicap, Profesie, DenumireFunctie, DenumireDepartament  " &
                                                                    "FROM Departamente INNER JOIN (Salariati INNER JOIN Functii ON Salariati.Functie=Functii.CodFunctie) ON Salariati.Departament=Departamente.CodDepartament " &
                                                                    "WHERE Activ = True " &
                                                                    "ORDER BY Marca ASC ", con)


        Dim dtSalariati As New DataTable

        cmdSalariati.Fill(dtSalariati)

        dgvSalariati.DataSource = dtSalariati

        con.Close()

    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles btnCautare.Click

        con.Open()

        If cmbFiltru.SelectedItem = "" Then

            pgIncarcare.Visible = False

            Dim cmdCautare As OleDbDataAdapter = New OleDbDataAdapter("SELECT Marca, CNP, Nume, Prenume, DataNastere, Adresa, Telefon, Casatorit, Vechime, Handicap, Profesie, DenumireFunctie, DenumireDepartament " &
                                                                      "FROM Departamente INNER JOIN (Salariati INNER JOIN Functii ON Salariati.Functie=Functii.CodFunctie) ON Salariati.Departament=Departamente.CodDepartament " &
                                                                      "WHERE Activ = True " &
                                                                      "ORDER BY Marca ", con)

            Dim dt As New DataTable

            cmdCautare.Fill(dt)

            dgvSalariati.DataSource = dt

            MsgBox("Selectați o opțiune de filtru!", vbExclamation, "ATENȚIE")


        Else

            Timer.Start()


            pgIncarcare.Value = 0

            pgIncarcare.Visible = True

        End If

        con.Close()

    End Sub


    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick

        con.Open()


        pgIncarcare.Increment(1)

        If pgIncarcare.Value = 100 Then

            Timer.Stop()


            Dim dt As New DataTable

            If cmbFiltru.SelectedIndex = 1 Then


                Dim cmdCautare As OleDbDataAdapter = New OleDbDataAdapter("SELECT Marca, CNP, Nume, Prenume, DataNastere, Adresa, Telefon, Casatorit, Vechime, Handicap, Profesie, DenumireFunctie, DenumireDepartament " &
                                                                          "FROM Departamente INNER JOIN (Salariati INNER JOIN Functii ON Salariati.Functie=Functii.CodFunctie) ON Salariati.Departament=Departamente.CodDepartament " &
                                                                          "WHERE Nume & '" & " " & "' & Prenume LIKE '" & txtFiltru.Text & "' AND Activ = True " &
                                                                          "ORDER BY Marca ASC ", con)
                cmdCautare.Fill(dt)

                dgvSalariati.DataSource = dt

                dgvSalariati.Refresh()

                pgIncarcare.Visible = False


            ElseIf cmbFiltru.SelectedIndex = 2 Then

                Dim cmdCautare As OleDbDataAdapter = New OleDbDataAdapter("SELECT Marca, CNP, Nume, Prenume, DataNastere, Adresa, Telefon, Casatorit, Vechime, Handicap, Profesie, DenumireFunctie, DenumireDepartament " &
                                                                          "FROM Departamente INNER JOIN (Salariati INNER JOIN Functii ON Salariati.Functie=Functii.CodFunctie) ON Salariati.Departament=Departamente.CodDepartament " &
                                                                          "WHERE DenumireDepartament LIKE '" & txtFiltru.Text & "' AND Activ = True " &
                                                                          "ORDER BY Marca ASC ", con)

                cmdCautare.Fill(dt)

                dgvSalariati.DataSource = dt

                dgvSalariati.Refresh()

                pgIncarcare.Visible = False

            ElseIf cmbFiltru.SelectedIndex = 3 Then

                Dim cmdCautare As OleDbDataAdapter = New OleDbDataAdapter("SELECT Marca, CNP, Nume, Prenume, DataNastere, Adresa, Telefon, Casatorit, Vechime, Handicap, Profesie, DenumireFunctie, DenumireDepartament " &
                                                                          "FROM Departamente INNER JOIN (Salariati INNER JOIN Functii ON Salariati.Functie=Functii.CodFunctie) ON Salariati.Departament=Departamente.CodDepartament " &
                                                                          "WHERE DenumireFunctie LIKE '" & txtFiltru.Text & "' AND Activ = True " &
                                                                          "ORDER BY Marca ASC ", con)

                cmdCautare.Fill(dt)

                dgvSalariati.DataSource = dt

                dgvSalariati.Refresh()

                pgIncarcare.Visible = False

            End If

        End If

        con.Close()

    End Sub

    Private Sub cmbFiltru_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFiltru.SelectedIndexChanged

        If cmbFiltru.SelectedIndex = 0 Then

            txtFiltru.Enabled = False

            pgIncarcare.Visible = False

            Dim cmdCautare As OleDbDataAdapter = New OleDbDataAdapter("SELECT Marca, CNP, Nume, Prenume, DataNastere, Adresa, Telefon, Casatorit, Vechime, Handicap, Profesie, DenumireFunctie, DenumireDepartament " &
                                                                      "FROM Departamente INNER JOIN (Salariati INNER JOIN Functii ON Salariati.Functie=Functii.CodFunctie) ON Salariati.Departament=Departamente.CodDepartament " &
                                                                      "WHERE Activ = True " &
                                                                      "ORDER BY Marca ", con)

            Dim dt As New DataTable

            cmdCautare.Fill(dt)

            dgvSalariati.DataSource = dt

            txtFiltru.Clear()

        Else

            txtFiltru.Enabled = True

        End If


    End Sub


    Private Sub btnModificare_Click(sender As Object, e As EventArgs) Handles btnModificare.Click


        Dim Index As Integer
        Dim x As String

        Index = dgvSalariati.CurrentRow.Index

        x = dgvSalariati.Rows(Index).Cells(2).Value

        Dim y As String

        y = dgvSalariati.Rows(Index).Cells(3).Value

        Dim z As String

        z = dgvSalariati.Rows(Index).Cells(0).Value

        ModificareDate.NumeSalariat = x
        ModificareDate.PrenumeSalariat = y
        ModificareDate.Marca = z


        Me.Hide()

        ModificareDate.Show()

    End Sub

    Private Sub btnIerarhie_Click(sender As Object, e As EventArgs) Handles btnIerarhie.Click

        Dim Index As Integer
        Dim x As String

        Index = dgvSalariati.CurrentRow.Index

        x = dgvSalariati.Rows(Index).Cells(2).Value

        Dim y As String

        y = dgvSalariati.Rows(Index).Cells(3).Value

        Dim z As String

        z = dgvSalariati.Rows(Index).Cells(0).Value

        Ierarhie.NumeSalariat = x
        Ierarhie.PrenumeSalariat = y
        Ierarhie.Marca = z

        Me.Hide()
        Ierarhie.Show()

    End Sub

    Private Sub btnSalvareDep_Click(sender As Object, e As EventArgs) Handles btnSalvareDep.Click

        con.Open()

        If txtCodDepartament.Text = "" Or txtDenumireDepartament.Text = "" Then


            MsgBox("INTRODUCEȚI TOATE DATELE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End If

        Dim cmdAdaugareDepartament As OleDbCommand = New OleDbCommand("INSERT INTO Departamente([CodDepartament],[DenumireDepartament])" &
                                                                      "VALUES (?,?)", con)

        Try

            cmdAdaugareDepartament.Parameters.Add(New OleDbParameter("CodDepartament", CType(txtCodDepartament.Text, Integer)))
            cmdAdaugareDepartament.Parameters.Add(New OleDbParameter("DenumireDepartament", CType(txtDenumireDepartament.Text, String)))

            cmdAdaugareDepartament.ExecuteNonQuery()
            cmdAdaugareDepartament.Dispose()

        Catch ex As Exception

            MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End Try


        Dim cmdDepartamente As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                       "FROM Departamente " &
                                                                       "ORDER BY CodDepartament ", con)

        Dim dtDepartamente As New DataTable

        cmdDepartamente.Fill(dtDepartamente)

        dgvDepartamente.DataSource = dtDepartamente.DefaultView



        MsgBox("DEPARTAMENTUL DENUMIT" & txtDenumireDepartament.Text & " A FOST INTRODUS CU SUCCES ÎN BAZA DE DATE!", vbInformation, "SUCCES")

        txtCodDepartament.Clear()
        txtDenumireDepartament.Clear()

        con.Close()

    End Sub

    Private Sub btnModificareDep_Click(sender As Object, e As EventArgs) Handles btnModificareDep.Click

        con.Open()

        If txtCodDepartament.Text = "" Or txtDenumireDepartament.Text = "" Then


            MsgBox("INTRODUCEȚI TOATE DATELE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End If

        Dim mesaj As String = MsgBox("SUNTEȚI SIGUR CĂ DORIȚI SĂ MODIFICAȚI DATELE DEPARTAMENTULUI?", vbYesNo, "ATENȚIE")

        If mesaj = vbYes Then

            Dim Index As Integer

            Dim x As String

            Index = dgvDepartamente.CurrentCell.RowIndex

            x = dgvDepartamente.Rows(Index).Cells(0).Value

            Dim cmdModificareD As OleDbCommand = New OleDbCommand("UPDATE Departamente SET [CodDepartament] = '" & txtCodDepartament.Text & "', [DenumireDepartament] = '" & txtDenumireDepartament.Text & "' WHERE [CodDepartament] Like '" & x & "'", con)

            Try

                cmdModificareD.ExecuteNonQuery()
                cmdModificareD.Dispose()



            Catch ex As Exception

                MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
                con.Close() : Exit Sub

            End Try


            Dim cmdDepartamente As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                           "FROM Departamente " &
                                                                           "ORDER BY CodDepartament ", con)

            Dim dtDepartamente As New DataTable

            cmdDepartamente.Fill(dtDepartamente)

            dgvDepartamente.DataSource = dtDepartamente.DefaultView

            MsgBox("DATELE DEPARTAMENTULUI AU FOST MODIFICATE CU SUCCES!", vbInformation, "SUCCES")

        Else

            con.Close() : Exit Sub

        End If

        txtCodDepartament.Clear()
        txtDenumireDepartament.Clear()

        con.Close()

    End Sub

    Private Sub btnStergereDepartament_Click(sender As Object, e As EventArgs) Handles btnStergereDepartament.Click

        Dim index As Integer

        Dim x As String

        Try

            index = dgvDepartamente.CurrentRow.Index

        Catch ex As NullReferenceException

            MsgBox("NU EXISTĂ ÎNREGISTRĂRI ÎN BAZA DE DATE!", vbExclamation, "EROARE") : Exit Sub

        End Try

        x = dgvDepartamente.Rows(index).Cells(1).Value



        con.Open()

        Dim cmdStergereD As OleDbCommand = New OleDbCommand("DELETE FROM [Departamente] " &
                                                            "WHERE [DenumireDepartament] Like '" & x & "'", con)


        Try

            cmdStergereD.ExecuteNonQuery()
            cmdStergereD.Dispose()

        Catch ex As Exception

            MsgBox("DEPARTAMENTUL SELECTAT NU SE POATE ȘTERGE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End Try

        dgvDepartamente.Rows.RemoveAt(index)

        MsgBox("DEPARTAMENTUL DENUMIT " & x & " A FOST ȘTERS DIN BAZA DE DATE!", vbInformation, "SUCCES")


        Dim cmdDepartamente As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                       "FROM Departamente " &
                                                                       "ORDER BY CodDepartament ", con)

        Dim dtDepartamente As New DataTable

        cmdDepartamente.Fill(dtDepartamente)

        dgvDepartamente.DataSource = dtDepartamente.DefaultView

        txtCodDepartament.Clear()
        txtDenumireDepartament.Clear()

        con.Close()

    End Sub

    Private Sub btnSalvareFun_Click(sender As Object, e As EventArgs) Handles btnSalvareFun.Click

        con.Open()

        If txtCodFunctie.Text = "" Or txtDenumireFunctie.Text = "" Then


            MsgBox("INTRODUCEȚI TOATE DATELE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End If

        If cbFunctie.Checked = True Then

            Dim cmdAdaugareFunctie As OleDbCommand = New OleDbCommand("INSERT INTO Functii([CodFunctie],[DenumireFunctie],[TipConducere])" &
                                                                      "VALUES (?,?,?)", con)

            Try

                cmdAdaugareFunctie.Parameters.Add(New OleDbParameter("CodFunctie", CType(txtCodFunctie.Text, Integer)))
                cmdAdaugareFunctie.Parameters.Add(New OleDbParameter("DenumireFunctie", CType(txtDenumireFunctie.Text, String)))
                cmdAdaugareFunctie.Parameters.Add(New OleDbParameter("TipConducere", CType(cbFunctie.Checked = True, Boolean)))

                cmdAdaugareFunctie.ExecuteNonQuery()
                cmdAdaugareFunctie.Dispose()

            Catch ex As Exception

                MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
                con.Close() : Exit Sub

            End Try

        ElseIf cbFunctie.Checked = False Then

            Dim cmdAdaugareFunctie As OleDbCommand = New OleDbCommand("INSERT INTO Functii([CodFunctie],[DenumireFunctie])" &
                                                                      "VALUES (?,?)", con)

            Try

                cmdAdaugareFunctie.Parameters.Add(New OleDbParameter("CodFunctie", CType(txtCodFunctie.Text, Integer)))
                cmdAdaugareFunctie.Parameters.Add(New OleDbParameter("DenumireFunctie", CType(txtDenumireFunctie.Text, String)))

                cmdAdaugareFunctie.ExecuteNonQuery()
                cmdAdaugareFunctie.Dispose()

            Catch ex As Exception

                MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
                con.Close() : Exit Sub

            End Try

        End If



        Dim cmdFunctii As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                  "FROM Functii " &
                                                                  "ORDER BY CodFunctie ", con)

        Dim dtFunctii As New DataTable

        cmdFunctii.Fill(dtFunctii)

        dgvFunctii.DataSource = dtFunctii.DefaultView



        MsgBox("FUNCȚIA DENUMITĂ " & txtDenumireFunctie.Text & " A FOST INTRODUSĂ CU SUCCES ÎN BAZA DE DATE!", vbInformation, "SUCCES")

        txtCodFunctie.Clear()
        txtDenumireFunctie.Clear()

        con.Close()

    End Sub

    Private Sub btnModificareFun_Click(sender As Object, e As EventArgs) Handles btnModificareFun.Click

        con.Open()

        If txtCodFunctie.Text = "" Or txtDenumireFunctie.Text = "" Then


            MsgBox("INTRODUCEȚI TOATE DATELE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End If

        Dim mesaj As String = MsgBox("SUNTEȚI SIGUR CĂ DORIȚI SĂ MODIFICAȚI DATELE FUNCȚIEI?", vbYesNo, "ATENȚIE")

        If mesaj = vbYes Then

            Dim Index As Integer

            Dim x As String

            Index = dgvFunctii.CurrentCell.RowIndex

            x = dgvFunctii.Rows(Index).Cells(0).Value

            Dim cmdModificareF As OleDbCommand = New OleDbCommand("UPDATE Functii SET [CodFunctie] = '" & txtCodFunctie.Text & "', [DenumireFunctie] = '" & txtDenumireFunctie.Text & "' WHERE [CodFunctie] Like '" & x & "'", con)

            Try

                cmdModificareF.ExecuteNonQuery()
                cmdModificareF.Dispose()



            Catch ex As Exception

                MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
                con.Close() : Exit Sub

            End Try


            Dim cmdFunctii As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                      "FROM Functii " &
                                                                      "ORDER BY CodFunctie ", con)

            Dim dtFunctii As New DataTable

            cmdFunctii.Fill(dtFunctii)

            dgvFunctii.DataSource = dtFunctii.DefaultView

        Else

            con.Close() : Exit Sub

        End If

        txtCodFunctie.Clear()
        txtCodFunctie.Clear()

        con.Close()

    End Sub

    Private Sub btnStergereFunctie_Click(sender As Object, e As EventArgs) Handles btnStergereFunctie.Click

        Dim index As Integer

        Dim x As String

        Try

            index = dgvFunctii.CurrentRow.Index

        Catch ex As NullReferenceException

            MsgBox("NU EXISTĂ ÎNREGISTRĂRI ÎN BAZA DE DATE!", vbExclamation, "EROARE") : Exit Sub

        End Try

        x = dgvFunctii.Rows(index).Cells(1).Value


        dgvFunctii.Rows.RemoveAt(index)


        con.Open()

        Dim cmdStergereF As OleDbCommand = New OleDbCommand("DELETE FROM [Functii] " &
                                                            "WHERE [DenumireFunctie] Like '" & x & "'", con)


        Try

            cmdStergereF.ExecuteNonQuery()
            cmdStergereF.Dispose()

        Catch ex As Exception

            MsgBox(ex.Message)
            con.Close()

        End Try

        MsgBox("FUNCȚIA DENUMITĂ " & x & " A FOST ȘTEARSĂ DIN BAZA DE DATE!", vbInformation, "SUCCES")


        Dim cmdFunctii As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                  "FROM Functii " &
                                                                  "ORDER BY CodFunctie ", con)

        Dim dtFunctii As New DataTable

        cmdFunctii.Fill(dtFunctii)

        dgvFunctii.DataSource = dtFunctii.DefaultView

        txtCodFunctie.Clear()
        txtDenumireFunctie.Clear()

        con.Close()

    End Sub

    Private Sub btnSalvareC_Click(sender As Object, e As EventArgs) Handles btnSalvareC.Click

        con.Open()

        If txtDenumireContributie.Text = "" Or txtProcentContributie.Text = "" Then


            MsgBox("INTRODUCEȚI TOATE DATELE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End If

        Dim cmdAdaugareContributie As OleDbCommand = New OleDbCommand("INSERT INTO Contributii([DenumireContributie],[ProcentContributie (%)])" &
                                                                      "VALUES (?,?)", con)

        Try

            cmdAdaugareContributie.Parameters.Add(New OleDbParameter("DenumireContributie", CType(txtDenumireContributie.Text, String)))
            cmdAdaugareContributie.Parameters.Add(New OleDbParameter("ProcentContributie", CType(txtProcentContributie.Text, Integer)))

            cmdAdaugareContributie.ExecuteNonQuery()
            cmdAdaugareContributie.Dispose()

        Catch ex As Exception

            MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End Try


        Dim cmdContributii As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                      "FROM Contributii " &
                                                                      "ORDER BY DenumireContributie ", con)

        Dim dtContributii As New DataTable

        cmdContributii.Fill(dtContributii)

        dgvContributii.DataSource = dtContributii.DefaultView



        MsgBox("CONTRIBUȚIA DENUMITĂ " & txtDenumireContributie.Text & " A FOST INTRODUSĂ CU SUCCES ÎN BAZA DE DATE!", vbInformation, "SUCCES")

        txtDenumireContributie.Clear()
        txtProcentContributie.Clear()

        con.Close()

    End Sub

    Private Sub btnModificareC_Click(sender As Object, e As EventArgs) Handles btnModificareC.Click

        con.Open()

        If txtDenumireContributie.Text = "" Or txtProcentContributie.Text = "" Then


            MsgBox("INTRODUCEȚI TOATE DATELE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End If

        Dim mesaj As String = MsgBox("SUNTEȚI SIGUR CĂ DORIȚI SĂ MODIFICAȚI DATELE CONTRIBUȚIEI?", vbYesNo, "ATENȚIE")

        If mesaj = vbYes Then

            Dim Index As Integer

            Dim x As String

            Index = dgvContributii.CurrentCell.RowIndex

            x = dgvContributii.Rows(Index).Cells(0).Value

            Dim cmdModificareC As OleDbCommand = New OleDbCommand("UPDATE Contributii SET [DenumireContributie] = '" & txtDenumireContributie.Text & "', [ProcentContributie (%)] = '" & txtProcentContributie.Text & "' WHERE [DenumireContributie] Like '" & x & "'", con)

            Try

                cmdModificareC.ExecuteNonQuery()
                cmdModificareC.Dispose()



            Catch ex As Exception

                MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
                con.Close() : Exit Sub

            End Try


            Dim cmdContributii As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                          "FROM Contributii " &
                                                                          "ORDER BY DenumireContributie ", con)

            Dim dtContributii As New DataTable

            cmdContributii.Fill(dtContributii)

            dgvContributii.DataSource = dtContributii.DefaultView

        Else

            con.Close() : Exit Sub

        End If

        txtDenumireContributie.Clear()
        txtProcentContributie.Clear()

        con.Close()


    End Sub

    Private Sub btnStergereContributie_Click(sender As Object, e As EventArgs) Handles btnStergereContributie.Click

        Dim index As Integer

        Dim x As String

        Try

            index = dgvContributii.CurrentRow.Index

        Catch ex As NullReferenceException

            MsgBox("NU EXISTĂ ÎNREGISTRĂRI ÎN BAZA DE DATE!", vbExclamation, "EROARE") : Exit Sub

        End Try

        x = dgvContributii.Rows(index).Cells(0).Value


        dgvContributii.Rows.RemoveAt(index)


        con.Open()

        Dim cmdStergereC As OleDbCommand = New OleDbCommand("DELETE FROM [Contributii] " &
                                                            "WHERE [DenumireContributie] Like '" & x & "'", con)


        Try

            cmdStergereC.ExecuteNonQuery()
            cmdStergereC.Dispose()

        Catch ex As Exception

            MsgBox(ex.Message)
            con.Close()

        End Try

        MsgBox("CONTRIBUȚIA DENUMITĂ " & x & " A FOST ȘTEARSĂ DIN BAZA DE DATE!", vbInformation, "SUCCES")


        Dim cmdContributii As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                      "FROM Contributii " &
                                                                      "ORDER BY DenumireContributie ", con)

        Dim dtContributii As New DataTable

        cmdContributii.Fill(dtContributii)

        dgvContributii.DataSource = dtContributii.DefaultView


        txtDenumireContributie.Clear()
        txtProcentContributie.Clear()

        con.Close()

    End Sub

    Private Sub btnSalvareS_Click(sender As Object, e As EventArgs) Handles btnSalvareS.Click

        con.Open()

        If txtDenumireSpor.Text = "" Or txtTipSpor.Text = "" Or txtProcentSpor.Text = "" Then


            MsgBox("INTRODUCEȚI TOATE DATELE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End If

        Dim cmdAdaugareSpor As OleDbCommand = New OleDbCommand("INSERT INTO Sporuri([DenumireSpor],[TipSpor],[ProcentSpor (%)])" &
                                                               "VALUES (?,?,?)", con)

        Try

            cmdAdaugareSpor.Parameters.Add(New OleDbParameter("DenumireSpor", CType(txtDenumireSpor.Text, String)))
            cmdAdaugareSpor.Parameters.Add(New OleDbParameter("TipSpor", CType(txtTipSpor.Text, String)))
            cmdAdaugareSpor.Parameters.Add(New OleDbParameter("ProcentSpor (%)", CType(txtProcentSpor.Text, Integer)))

            cmdAdaugareSpor.ExecuteNonQuery()
            cmdAdaugareSpor.Dispose()

        Catch ex As Exception

            MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End Try


        Dim cmdSporuri As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                  "FROM Sporuri " &
                                                                  "ORDER BY TipSpor ", con)

        Dim dtSporuri As New DataTable

        cmdSporuri.Fill(dtSporuri)

        dgvSporuri.DataSource = dtSporuri.DefaultView



        MsgBox("SPORUL DENUMIT " & txtDenumireSpor.Text & " A FOST INTRODUS CU SUCCES ÎN BAZA DE DATE!", vbInformation, "SUCCES")

        txtDenumireSpor.Clear()
        txtProcentSpor.Clear()

        con.Close()

    End Sub

    Private Sub btnModificareS_Click(sender As Object, e As EventArgs) Handles btnModificareS.Click

        con.Open()

        If txtDenumireSpor.Text = "" Or txtTipSpor.Text = "" Or txtProcentSpor.Text = "" Then


            MsgBox("INTRODUCEȚI TOATE DATELE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End If

        Dim mesaj As String = MsgBox("SUNTEȚI SIGUR CĂ DORIȚI SĂ MODIFICAȚI DATELE SPORULUI?", vbYesNo, "ATENȚIE")

        If mesaj = vbYes Then

            Dim Index As Integer

            Dim x As String

            Index = dgvSporuri.CurrentCell.RowIndex

            x = dgvSporuri.Rows(Index).Cells(0).Value

            Dim cmdModificareS As OleDbCommand = New OleDbCommand("UPDATE Sporuri SET [DenumireSpor] = '" & txtDenumireSpor.Text & "', [TipSpor] = '" & txtTipSpor.Text & "', [ProcentSpor (%)] = '" & txtProcentSpor.Text & "' WHERE [DenumireSpor] Like '" & x & "'", con)

            Try

                cmdModificareS.ExecuteNonQuery()
                cmdModificareS.Dispose()



            Catch ex As Exception

                MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
                con.Close() : Exit Sub

            End Try


            Dim cmdSporuri As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                  "FROM Sporuri " &
                                                                  "ORDER BY TipSpor ", con)

            Dim dtSporuri As New DataTable

            cmdSporuri.Fill(dtSporuri)

            dgvSporuri.DataSource = dtSporuri.DefaultView

        Else

            con.Close() : Exit Sub

        End If

        txtDenumireSpor.Clear()
        txtProcentSpor.Clear()

        con.Close()

    End Sub

    Private Sub btnStergereS_Click(sender As Object, e As EventArgs) Handles btnStergereS.Click

        Dim index As Integer

        Dim x As String

        Try

            index = dgvSporuri.CurrentRow.Index

        Catch ex As NullReferenceException

            MsgBox("NU EXISTĂ ÎNREGISTRĂRI ÎN BAZA DE DATE!", vbExclamation, "EROARE") : Exit Sub

        End Try

        x = dgvSporuri.Rows(index).Cells(0).Value


        dgvSporuri.Rows.RemoveAt(index)


        con.Open()

        Dim cmdStergereS As OleDbCommand = New OleDbCommand("DELETE FROM [Sporuri] " &
                                                            "WHERE [DenumireSpor] Like '" & x & "'", con)


        Try

            cmdStergereS.ExecuteNonQuery()
            cmdStergereS.Dispose()

        Catch ex As Exception

            MsgBox(ex.Message)
            con.Close()

        End Try

        MsgBox("SPORUL DENUMIT " & x & " A FOST ȘTERS DIN BAZA DE DATE!", vbInformation, "SUCCES")


        Dim cmdSporuri As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                  "FROM Sporuri " &
                                                                  "ORDER BY TipSpor ", con)

        Dim dtSporuri As New DataTable

        cmdSporuri.Fill(dtSporuri)

        dgvSporuri.DataSource = dtSporuri.DefaultView


        txtDenumireSpor.Clear()
        txtProcentSpor.Clear()

        con.Close()

    End Sub

    Private Sub btnSalvareP_Click(sender As Object, e As EventArgs) Handles btnSalvareP.Click

        con.Open()


        If txtDenumirePrima.Text = "" Or txtTipPrima.Text = "" Then


            MsgBox("INTRODUCEȚI TOATE DATELE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End If

        Dim cmdAdaugarePrima As OleDbCommand = New OleDbCommand("INSERT INTO Prime([DenumirePrima],[TipPrima])" &
                                                                "VALUES (?,?)", con)

        Try

            cmdAdaugarePrima.Parameters.Add(New OleDbParameter("DenumirePrima", CType(txtDenumirePrima.Text, String)))
            cmdAdaugarePrima.Parameters.Add(New OleDbParameter("TipPrima", CType(txtTipPrima.Text, String)))

            cmdAdaugarePrima.ExecuteNonQuery()
            cmdAdaugarePrima.Dispose()

        Catch ex As Exception

            MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End Try


        Dim cmdPrime As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                "FROM Prime " &
                                                                "ORDER BY TipPrima ", con)

        Dim dtPrime As New DataTable

        cmdPrime.Fill(dtPrime)

        dgvPrime.DataSource = dtPrime.DefaultView



        MsgBox("PRIMA DENUMITĂ " & txtDenumirePrima.Text & " A FOST INTRODUSĂ CU SUCCES ÎN BAZA DE DATE!", vbInformation, "SUCCES")

        txtDenumirePrima.Clear()

        con.Close()

    End Sub

    Private Sub btnModificareP_Click(sender As Object, e As EventArgs) Handles btnModificareP.Click

        con.Open()

        If txtDenumirePrima.Text = "" Or txtTipPrima.Text = "" Then


            MsgBox("INTRODUCEȚI TOATE DATELE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End If

        Dim mesaj As String = MsgBox("SUNTEȚI SIGUR CĂ DORIȚI SĂ MODIFICAȚI DATELE PRIMEI?", vbYesNo, "ATENȚIE")

        If mesaj = vbYes Then

            Dim Index As Integer

            Dim x As String

            Index = dgvPrime.CurrentCell.RowIndex

            x = dgvPrime.Rows(Index).Cells(0).Value

            Dim cmdModificareP As OleDbCommand = New OleDbCommand("UPDATE Prime SET [DenumirePrima] = '" & txtDenumirePrima.Text & "', [TipPrima] = '" & txtTipPrima.Text & "' WHERE [DenumirePrima] Like '" & x & "'", con)

            Try

                cmdModificareP.ExecuteNonQuery()
                cmdModificareP.Dispose()



            Catch ex As Exception

                MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
                con.Close() : Exit Sub

            End Try


            Dim cmdPrime As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                    "FROM Prime " &
                                                                    "ORDER BY TipPrima ", con)

            Dim dtPrime As New DataTable

            cmdPrime.Fill(dtPrime)

            dgvPrime.DataSource = dtPrime.DefaultView

        Else

            con.Close() : Exit Sub

        End If

        txtDenumirePrima.Clear()

        con.Close()

    End Sub

    Private Sub btnStergerePrima_Click(sender As Object, e As EventArgs) Handles btnStergerePrima.Click

        Dim index As Integer

        Dim x As String

        Try

            index = dgvPrime.CurrentRow.Index

        Catch ex As NullReferenceException

            MsgBox("NU EXISTĂ ÎNREGISTRĂRI ÎN BAZA DE DATE!", vbExclamation, "EROARE") : Exit Sub

        End Try

        x = dgvPrime.Rows(index).Cells(0).Value


        dgvPrime.Rows.RemoveAt(index)


        con.Open()

        Dim cmdStergereP As OleDbCommand = New OleDbCommand("DELETE FROM [Prime] " &
                                                            "WHERE [DenumirePrima] Like '" & x & "'", con)


        Try

            cmdStergereP.ExecuteNonQuery()
            cmdStergereP.Dispose()

        Catch ex As Exception

            MsgBox(ex.Message)
            con.Close()

        End Try

        MsgBox("PRIMA DENUMITĂ " & x & " A FOST ȘTEARSĂ DIN BAZA DE DATE!", vbInformation, "SUCCES")


        Dim cmdPrime As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                "FROM Prime " &
                                                                "ORDER BY TipPrima ", con)

        Dim dtPrime As New DataTable

        cmdPrime.Fill(dtPrime)



        txtDenumirePrima.Clear()

        con.Close()


    End Sub

    Private Sub btnSalvareR_Click(sender As Object, e As EventArgs) Handles btnSalvareR.Click

        con.Open()

        If txtTipRetinere.Text = "" Then


            MsgBox("INTRODUCEȚI TOATE DATELE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End If

        Dim cmdAdaugareRetinere As OleDbCommand = New OleDbCommand("INSERT INTO Retineri([TipRetinere])" &
                                                                   "VALUES (?)", con)

        Try

            cmdAdaugareRetinere.Parameters.Add(New OleDbParameter("TipRetinere", CType(txtTipRetinere.Text, String)))

            cmdAdaugareRetinere.ExecuteNonQuery()
            cmdAdaugareRetinere.Dispose()

        Catch ex As Exception

            MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End Try


        Dim cmdRetineri As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                   "FROM Retineri " &
                                                                   "ORDER BY TipRetinere ", con)

        Dim dtRetineri As New DataTable

        cmdRetineri.Fill(dtRetineri)

        dgvRetineri.DataSource = dtRetineri.DefaultView



        MsgBox("REȚINEREA DENUMITĂ " & txtTipRetinere.Text & " A FOST INTRODUSĂ CU SUCCES ÎN BAZA DE DATE!", vbInformation, "SUCCES")

        txtTipRetinere.Clear()

        con.Close()

    End Sub

    Private Sub btnModificareR_Click(sender As Object, e As EventArgs) Handles btnModificareR.Click

        con.Open()

        If txtTipRetinere.Text = "" Then


            MsgBox("INTRODUCEȚI TOATE DATELE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End If

        Dim mesaj As String = MsgBox("SUNTEȚI SIGUR CĂ DORIȚI SĂ MODIFICAȚI DATELE REȚINERII?", vbYesNo, "ATENȚIE")

        If mesaj = vbYes Then

            Dim Index As Integer

            Dim x As String

            Index = dgvRetineri.CurrentCell.RowIndex

            x = dgvRetineri.Rows(Index).Cells(0).Value

            Dim cmdModificareR As OleDbCommand = New OleDbCommand("UPDATE Retineri SET [TipRetinere] = '" & txtTipRetinere.Text & "' WHERE [TipRetinere] Like '" & x & "'", con)

            Try

                cmdModificareR.ExecuteNonQuery()
                cmdModificareR.Dispose()



            Catch ex As Exception

                MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
                con.Close() : Exit Sub

            End Try


            Dim cmdRetineri As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                       "FROM Retineri " &
                                                                       "ORDER BY TipRetinere ", con)

            Dim dtRetineri As New DataTable

            cmdRetineri.Fill(dtRetineri)

            dgvRetineri.DataSource = dtRetineri.DefaultView


        Else

            con.Close() : Exit Sub

        End If

        txtTipRetinere.Clear()

        con.Close()

    End Sub

    Private Sub btnStergereR_Click(sender As Object, e As EventArgs) Handles btnStergereR.Click

        Dim index As Integer

        Dim x As String

        Try

            index = dgvRetineri.CurrentRow.Index

        Catch ex As NullReferenceException

            MsgBox("NU EXISTĂ ÎNREGISTRĂRI ÎN BAZA DE DATE!", vbExclamation, "EROARE") : Exit Sub

        End Try

        x = dgvRetineri.Rows(index).Cells(0).Value


        dgvRetineri.Rows.RemoveAt(index)


        con.Open()

        Dim cmdStergereR As OleDbCommand = New OleDbCommand("DELETE FROM [Retineri] " &
                                                            "WHERE [TipRetinere] Like '" & x & "'", con)


        Try

            cmdStergereR.ExecuteNonQuery()
            cmdStergereR.Dispose()

        Catch ex As Exception

            MsgBox(ex.Message)
            con.Close()

        End Try

        MsgBox("REȚINEREA DENUMITĂ " & x & " A FOST ȘTEARSĂ DIN BAZA DE DATE!", vbInformation, "SUCCES")

        Dim cmdRetineri As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                   "FROM Retineri " &
                                                                   "ORDER BY TipRetinere ", con)

        Dim dtRetineri As New DataTable

        cmdRetineri.Fill(dtRetineri)

        dgvRetineri.DataSource = dtRetineri.DefaultView


        txtTipRetinere.Clear()

        con.Close()

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles btnContributii.Click

        Dim Index As Integer
        Dim x As String

        Index = dgvSalariati.CurrentRow.Index

        x = dgvSalariati.Rows(Index).Cells(2).Value

        Dim y As String

        y = dgvSalariati.Rows(Index).Cells(3).Value

        Dim z As String

        z = dgvSalariati.Rows(Index).Cells(0).Value

        Contributii.NumeSalariat = x
        Contributii.PrenumeSalariat = y
        Contributii.Marca = z

        Me.Hide()

        Contributii.Show()

    End Sub

    Private Sub Button6_Click_2(sender As Object, e As EventArgs) Handles btnSporuri.Click

        Dim Index As Integer
        Dim x As String

        Index = dgvSalariati.CurrentRow.Index

        x = dgvSalariati.Rows(Index).Cells(2).Value

        Dim y As String

        y = dgvSalariati.Rows(Index).Cells(3).Value

        Dim z As String

        z = dgvSalariati.Rows(Index).Cells(0).Value

        Sporuri.NumeSalariat = x
        Sporuri.PrenumeSalariat = y
        Sporuri.Marca = z

        Me.Hide()
        Sporuri.Show()

    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles btnPrime.Click

        Dim Index As Integer
        Dim x As String

        Index = dgvSalariati.CurrentRow.Index

        x = dgvSalariati.Rows(Index).Cells(2).Value

        Dim y As String

        y = dgvSalariati.Rows(Index).Cells(3).Value

        Dim z As String

        z = dgvSalariati.Rows(Index).Cells(0).Value

        Prime.NumeSalariat = x
        Prime.PrenumeSalariat = y
        Prime.Marca = z

        Me.Hide()
        Prime.Show()

    End Sub


    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles btnRetineri.Click

        Dim Index As Integer
        Dim x As String

        Index = dgvSalariati.CurrentRow.Index

        x = dgvSalariati.Rows(Index).Cells(2).Value

        Dim y As String

        y = dgvSalariati.Rows(Index).Cells(3).Value

        Dim z As String

        z = dgvSalariati.Rows(Index).Cells(0).Value

        Retineri.NumeSalariat = x
        Retineri.PrenumeSalariat = y
        Retineri.Marca = z

        Me.Hide()
        Retineri.Show()

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles btnPenalizari.Click

        Dim Index As Integer
        Dim x As String

        Index = dgvSalariati.CurrentRow.Index

        x = dgvSalariati.Rows(Index).Cells(2).Value

        Dim y As String

        y = dgvSalariati.Rows(Index).Cells(3).Value

        Dim z As String

        z = dgvSalariati.Rows(Index).Cells(0).Value



        Penalizari.NumeSalariat = x
        Penalizari.PrenumeSalariat = y
        Penalizari.Marca = z


        Me.Hide()
        Penalizari.Show()

    End Sub

    Private Sub btnFisePontaj_Click(sender As Object, e As EventArgs) Handles btnFisePontaj.Click

        Golire(pnlPontaj)

        pnlStatistici.Hide()
        pnlPontaj.Show()
        pnlDosare.Hide()
        pnlDate.Hide()
        pnlState.Hide()

        tbPontaj.SelectedIndex = 0

        con.Open()

        Dim cmdIndemnizatieBrut As OleDbDataAdapter = New OleDbDataAdapter("SELECT NrZileLucratoare " &
                                                                           "FROM Pontaj " &
                                                                           "WHERE Luna Like '" & Month(Date.Now) & "'", con)

        Dim dtIndemnizatieBrut As New DataTable

        cmdIndemnizatieBrut.Fill(dtIndemnizatieBrut)


        txtOreLucrate.Text = dtIndemnizatieBrut.Rows(0).Item(0) * 8

        txtOreSuplimentare.Text = 0

        txtZileConcediuMedical.Text = 0

        txtZileConcediuOdihna.Text = 0

        txtOreAbsentate.Text = 0

        Dim dtMarca As New DataTable

        Dim cmdMarca As OleDbDataAdapter = New OleDbDataAdapter("SELECT Marca  " &
                                                                "FROM Salariati " &
                                                                "WHERE Activ = True " &
                                                                "ORDER BY Marca ASC", con)

        cmdMarca.Fill(dtMarca)

        cmbMarca.DataSource = dtMarca

        cmbMarca.DisplayMember = "Marca"


        Dim cmdAfisareFise As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                      "FROM Pontaj ", con)

        Dim dtFise As New DataTable

        cmdAfisareFise.Fill(dtFise)

        dgvFisePontaj.DataSource = dtFise



        Dim cmdAfisarePontaj As OleDbDataAdapter = New OleDbDataAdapter("SELECT MAX([NrFisa]), MAX([Luna]) " &
                                                                        "FROM Pontaj ", con)

        Dim dtAfisarePontaj As New DataTable

        cmdAfisarePontaj.Fill(dtAfisarePontaj)


        Try

            If dtAfisarePontaj.Rows(0).Item(1) < Month(Now) Then

                txtNrFisa.Text = dtAfisarePontaj.Rows(0).Item(0) + 1

            Else

                txtNrFisa.Text = dtAfisarePontaj.Rows(0).Item(0)

            End If

        Catch ex As Exception

            txtNrFisa.Text = 1

        End Try




        Dim cmdAfisareInregistrari As OleDbDataAdapter = New OleDbDataAdapter("SELECT NrFisa, Marca, OreLucrate, OreSuplimentare, NrZileConcediuOdihna, NrZileConcediuMedical " &
                                                                              "FROM PontajSalariat " &
                                                                              "WHERE Marca Like '" & "1001" & "'", con)

        Dim dtAfisareInregistrari As New DataTable

        cmdAfisareInregistrari.Fill(dtAfisareInregistrari)

        dgvSalariatiPontaj.DataSource = dtAfisareInregistrari

        con.Close()

        txtAnul.Text = Year(Now)
        txtLuna.Text = Month(Now)

    End Sub


    Private Sub btnAdaugaFisa_Click(sender As Object, e As EventArgs) Handles btnAdaugaFisa.Click

        If txtZileLucratoare.Text = "" Then

            MsgBox("INTRODUCEȚI TOATE DATELE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End If

        con.Open()

        Dim cmdAdaugareDatePontaj As OleDbCommand

        cmdAdaugareDatePontaj = New OleDbCommand("INSERT INTO Pontaj([NrFisa],[Anul],[Luna],[NrZileLucratoare])" &
                                                 "VALUES (?,?,?,?)", con)

        Try

            cmdAdaugareDatePontaj.Parameters.Add(New OleDbParameter("NrFisa", CType(txtNrFisa.Text, Integer)))
            cmdAdaugareDatePontaj.Parameters.Add(New OleDbParameter("Anul", CType(txtAnul.Text, Integer)))
            cmdAdaugareDatePontaj.Parameters.Add(New OleDbParameter("Luna", CType(txtLuna.Text, Integer)))
            cmdAdaugareDatePontaj.Parameters.Add(New OleDbParameter("NrZileLucratoare", CType(txtZileLucratoare.Text, Integer)))

            cmdAdaugareDatePontaj.ExecuteNonQuery()
            cmdAdaugareDatePontaj.Dispose()

        Catch ex As Exception

            MsgBox("FIȘA EXISTĂ ÎN BAZA DE DATE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End Try



        Dim cmdAfisareFise As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                      "FROM Pontaj ", con)

        Dim dtFise As New DataTable

        cmdAfisareFise.Fill(dtFise)

        dgvFisePontaj.DataSource = dtFise


        MsgBox("FIȘA CU NUMĂRUL " & txtNrFisa.Text & " A FOST INTRODUSĂ CU SUCCES ÎN BAZA DE DATE!", vbInformation, "SUCCES")

        txtZileLucratoare.Clear()




        Dim cmdAfisarePontaj As OleDbDataAdapter = New OleDbDataAdapter("SELECT MAX([NrFisa]), MAX([Luna]) " &
                                                                        "FROM Pontaj ", con)

        Dim dtAfisarePontaj As New DataTable

        cmdAfisarePontaj.Fill(dtAfisarePontaj)


        Try

            If dtAfisarePontaj.Rows(0).Item(1) < Month(Now) Then

                txtNrFisa.Text = dtAfisarePontaj.Rows(0).Item(0) + 1

            Else

                txtNrFisa.Text = 1

            End If

        Catch ex As Exception

            txtNrFisa.Text = 1

        End Try


        con.Close()

    End Sub

    Private Sub btnModificareFisa_Click(sender As Object, e As EventArgs) Handles btnModificareFisa.Click

        con.Open()

        If txtZileLucratoare.Text = "" Then

            MsgBox("INTRODUCEȚI TOATE DATELE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End If



        Dim mesaj As String = MsgBox("SUNTEȚI SIGUR CĂ DORIȚI SĂ MODIFICAȚI DATELE?", vbYesNo, "ATENȚIE")

        If mesaj = vbYes Then

            Dim Index As Integer

            Dim x As String

            Index = dgvFisePontaj.CurrentCell.RowIndex

            x = dgvFisePontaj.Rows(Index).Cells(0).Value

            Dim cmdModificareP As OleDbCommand = New OleDbCommand("UPDATE Pontaj SET [NrZileLucratoare] = '" & txtZileLucratoare.Text & "' WHERE [NrFisa] Like '" & x & "'", con)

            Try

                cmdModificareP.ExecuteNonQuery()
                cmdModificareP.Dispose()



            Catch ex As Exception

                MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
                con.Close() : Exit Sub

            End Try


            Dim cmdAfisareFise As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                      "FROM Pontaj ", con)

            Dim dtFise As New DataTable

            cmdAfisareFise.Fill(dtFise)

            dgvFisePontaj.DataSource = dtFise


        Else

            con.Close() : Exit Sub

        End If

        txtZileLucratoare.Clear()

        con.Close()

    End Sub

    Private Sub btnStergereFisa_Click(sender As Object, e As EventArgs) Handles btnStergereFisa.Click

        Dim index As Integer

        Dim x As String

        Try

            index = dgvFisePontaj.CurrentRow.Index

        Catch ex As NullReferenceException

            MsgBox("NU EXISTĂ ÎNREGISTRĂRI ÎN BAZA DE DATE!", vbExclamation, "EROARE") : Exit Sub

        End Try

        x = dgvFisePontaj.Rows(index).Cells(0).Value


        dgvFisePontaj.Rows.RemoveAt(index)


        con.Open()

        Dim cmdStergereF As OleDbCommand = New OleDbCommand("DELETE FROM [Pontaj] " &
                                                            "WHERE [NrFisa] Like '" & x & "'", con)


        Try

            cmdStergereF.ExecuteNonQuery()
            cmdStergereF.Dispose()

        Catch ex As Exception

            MsgBox(ex.Message)
            con.Close()

        End Try

        MsgBox("FIȘA CU NUMĂRUL " & x & " A FOST ȘTEARSĂ DIN BAZA DE DATE!", vbInformation, "SUCCES")

        Dim cmdAfisareFise As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                      "FROM Pontaj ", con)

        Dim dtFise As New DataTable

        cmdAfisareFise.Fill(dtFise)

        dgvFisePontaj.DataSource = dtFise


        txtZileLucratoare.Clear()

        con.Close()

    End Sub


    Private Sub btnAdaugareEvidenta_Click(sender As Object, e As EventArgs) Handles btnAdaugareEvidenta.Click


        If txtNrFisa.Text = "" Or cmbMarca.Text = "" Or txtOreLucrate.Text = "" Or txtOreSuplimentare.Text = "" Or txtZileConcediuMedical.Text = "" Or txtZileConcediuOdihna.Text = "" Then

            MsgBox("INTRODUCEȚI TOATE DATELE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End If

        con.Open()



        Dim cmdAdaugarePontajSalariat As OleDbCommand

        cmdAdaugarePontajSalariat = New OleDbCommand("INSERT INTO PontajSalariat([NrFisa],[Marca],[OreLucrate],[OreSuplimentare],[NrZileConcediuOdihna],[NrZileConcediuMedical])" &
                                                     "VALUES (?,?,?,?,?,?)", con)

        Try

            cmdAdaugarePontajSalariat.Parameters.Add(New OleDbParameter("NrFisa", CType(txtNrFisa.Text, Integer)))
            cmdAdaugarePontajSalariat.Parameters.Add(New OleDbParameter("Marca", CType(cmbMarca.Text, Integer)))
            cmdAdaugarePontajSalariat.Parameters.Add(New OleDbParameter("OreLucrate", CType(txtOreLucrate.Text, Integer)))
            cmdAdaugarePontajSalariat.Parameters.Add(New OleDbParameter("OreSuplimentare", CType(txtOreSuplimentare.Text, Integer)))
            cmdAdaugarePontajSalariat.Parameters.Add(New OleDbParameter("NrZileConcediuOdihna", CType(txtZileConcediuOdihna.Text, Integer)))
            cmdAdaugarePontajSalariat.Parameters.Add(New OleDbParameter("NrZileConcediuMedical", CType(txtZileConcediuMedical.Text, Integer)))

            cmdAdaugarePontajSalariat.ExecuteNonQuery()
            cmdAdaugarePontajSalariat.Dispose()

        Catch ex As Exception

            MsgBox("SALARIATUL ESTE DEJA PONTAT!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End Try



        Dim cmdAfisareInregistrari As OleDbDataAdapter = New OleDbDataAdapter("SELECT NrFisa, Marca, OreLucrate, OreSuplimentare, NrZileConcediuOdihna, NrZileConcediuMedical " &
                                                                              "FROM PontajSalariat " &
                                                                              "WHERE Marca Like '" & cmbMarca.Text & "'", con)

        Dim dtAfisareInregistrari As New DataTable

        cmdAfisareInregistrari.Fill(dtAfisareInregistrari)

        dgvSalariatiPontaj.DataSource = dtAfisareInregistrari

        con.Close()

        Golire(tbPontajSalariati)


        txtOreAbsentate.Text = 0
        txtOreSuplimentare.Text = 0
        txtZileConcediuMedical.Text = 0
        txtZileConcediuOdihna.Text = 0

        MsgBox("DATELE AU FOST INTRODUSE CU SUCCES!", vbInformation, "SUCCES")

    End Sub


    Private Sub btnModificarePontaj_Click(sender As Object, e As EventArgs) Handles btnModificarePontaj.Click

        con.Open()


        If txtNrFisa.Text = "" Or cmbMarca.Text = "" Or txtOreLucrate.Text = "" Or txtOreSuplimentare.Text = "" Or txtZileConcediuMedical.Text = "" Or txtZileConcediuOdihna.Text = "" Then

            MsgBox("INTRODUCEȚI TOATE DATELE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End If



        Dim mesaj As String = MsgBox("SUNTEȚI SIGUR CĂ DORIȚI SĂ MODIFICAȚI DATELE?", vbYesNo, "ATENȚIE")

        If mesaj = vbYes Then

            Dim Index As Integer

            Dim x As String

            Index = dgvSalariatiPontaj.CurrentCell.RowIndex

            x = dgvSalariatiPontaj.Rows(Index).Cells(0).Value

            Dim cmdModificareP As OleDbCommand = New OleDbCommand("UPDATE PontajSalariat SET [OreLucrate] = '" & txtOreLucrate.Text & "', [OreSuplimentare] = '" & txtOreSuplimentare.Text & "', [NrZileConcediuOdihna] = '" & txtZileConcediuOdihna.Text & "', [NrZileConcediuMedical] = '" & txtZileConcediuMedical.Text & "' WHERE [NrFisa] Like '" & x & "' AND [Marca] Like '" & cmbMarca.Text & "'", con)

            Try

                cmdModificareP.ExecuteNonQuery()
                cmdModificareP.Dispose()



            Catch ex As Exception

                MsgBox(ex.Message)
                con.Close() : Exit Sub

            End Try


            Dim cmdAfisareInregistrari As OleDbDataAdapter = New OleDbDataAdapter("SELECT NrFisa, Marca, OreLucrate, OreSuplimentare, NrZileConcediuOdihna, NrZileConcediuMedical " &
                                                                                  "FROM PontajSalariat " &
                                                                                  "WHERE Marca Like '" & cmbMarca.Text & "'", con)

            Dim dtAfisareInregistrari As New DataTable

            cmdAfisareInregistrari.Fill(dtAfisareInregistrari)

            dgvSalariatiPontaj.DataSource = dtAfisareInregistrari


        Else

            con.Close() : Exit Sub

        End If

        Golire(tbPontajSalariati)

        txtOreAbsentate.Text = 0
        txtOreSuplimentare.Text = 0
        txtZileConcediuMedical.Text = 0
        txtZileConcediuOdihna.Text = 0

        con.Close()

    End Sub

    Private Sub btnStergereInregistrare_Click(sender As Object, e As EventArgs) Handles btnStergereInregistrare.Click

        Dim index As Integer

        Dim x As String

        Dim y As String

        Try

            index = dgvSalariatiPontaj.CurrentRow.Index

        Catch ex As NullReferenceException

            MsgBox("NU EXISTĂ ÎNREGISTRĂRI ÎN BAZA DE DATE!", vbExclamation, "EROARE") : Exit Sub

        End Try

        x = dgvSalariatiPontaj.Rows(index).Cells(0).Value

        y = dgvSalariatiPontaj.Rows(index).Cells(1).Value


        dgvSalariatiPontaj.Rows.RemoveAt(index)


        con.Open()


        Dim cmdStergereP As OleDbCommand = New OleDbCommand("DELETE FROM [PontajSalariat] " &
                                                            "WHERE [NrFisa] Like '" & x & "' AND [Marca] Like '" & y & "'", con)


        Try

            cmdStergereP.ExecuteNonQuery()
            cmdStergereP.Dispose()

        Catch ex As Exception

            MsgBox(ex.Message)
            con.Close()

        End Try


        MsgBox("ÎNREGISTRAREA A FOST ȘTEARSĂ DIN BAZA DE DATE!", vbInformation, "SUCCES")

        Dim cmdAfisareInregistrari As OleDbDataAdapter = New OleDbDataAdapter("SELECT NrFisa, Marca, OreLucrate, OreSuplimentare, NrZileConcediuOdihna, NrZileConcediuMedical " &
                                                                              "FROM PontajSalariat " &
                                                                              "WHERE Marca Like '" & cmbMarca.Text & "'", con)

        Dim dtAfisareInregistrari As New DataTable

        cmdAfisareInregistrari.Fill(dtAfisareInregistrari)

        dgvSalariatiPontaj.DataSource = dtAfisareInregistrari

        Golire(tbPontajSalariati)

        con.Close()

    End Sub

    Private Sub btnAnularePontaj_Click(sender As Object, e As EventArgs) Handles btnAnularePontaj.Click

        pnlPontaj.Hide()
        Golire(pnlPontaj)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        pnlDosare.Hide()
        Golire(pnlDosare)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSalarii.Click

        Golire(pnlState)

        pnlStatistici.Hide()
        pnlState.Show()
        pnlDate.Hide()
        pnlDosare.Hide()
        pnlPontaj.Hide()

        tbState.SelectedIndex = 0

        con.Open()

        Dim cmdSalariati As OleDbDataAdapter = New OleDbDataAdapter("SELECT Marca, CNP, Nume, Prenume, DataNastere, Adresa, Telefon, Casatorit, Vechime, Handicap, Profesie, DenumireFunctie, DenumireDepartament  " &
                                                                    "FROM Departamente INNER JOIN (Salariati INNER JOIN Functii ON Salariati.Functie=Functii.CodFunctie) ON Salariati.Departament=Departamente.CodDepartament " &
                                                                    "WHERE Activ = True " &
                                                                    "ORDER BY Marca ASC ", con)


        Dim dtSalariati As New DataTable

        cmdSalariati.Fill(dtSalariati)

        dgvStatSalariati.DataSource = dtSalariati



        Dim cmdAfisareFise As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                      "FROM State ", con)

        Dim dtFise As New DataTable

        cmdAfisareFise.Fill(dtFise)

        dgvFise.DataSource = dtFise




        Dim cmdAfisarePontaj As OleDbDataAdapter = New OleDbDataAdapter("SELECT MAX([NrCurent]), MAX([Luna]) " &
                                                                        "FROM State ", con)

        Dim dtAfisarePontaj As New DataTable

        cmdAfisarePontaj.Fill(dtAfisarePontaj)


        Try

            If dtAfisarePontaj.Rows(0).Item(1) < Month(Now) Then

                txtNrPontaj.Text = dtAfisarePontaj.Rows(0).Item(0) + 1

            Else

                txtNrPontaj.Text = dtAfisarePontaj.Rows(0).Item(0)

            End If

        Catch ex As Exception

            txtNrPontaj.Text = 1

        End Try




        Dim cmdAnul As OleDbDataAdapter = New OleDbDataAdapter("SELECT Anul " &
                                                               "FROM State " &
                                                               "GROUP BY Anul " &
                                                               "ORDER BY Anul", con)

        Dim dtAnul As New DataTable

        cmdAnul.Fill(dtAnul)

        cmbAnul.DataSource = dtAnul

        cmbAnul.DisplayMember = "Anul"




        Dim cmdLuna As OleDbDataAdapter = New OleDbDataAdapter("SELECT Luna " &
                                                               "FROM State " &
                                                               "GROUP BY Luna " &
                                                               "ORDER BY LEN(Luna), Luna", con)


        Dim dtLuna As New DataTable

        cmdLuna.Fill(dtLuna)

        cmbLuna.DataSource = dtLuna

        cmbLuna.DisplayMember = "Luna"




        txtAnPontaj.Text = Year(Now)

        txtLunaPontaj.Text = Month(Now)

        con.Close()

    End Sub

    Private Sub btnAfisareFluturas_Click(sender As Object, e As EventArgs) Handles btnAfisareFluturas.Click

        Dim Index As Integer
        Dim x As String

        Index = dgvStatSalariati.CurrentRow.Index

        x = dgvStatSalariati.Rows(Index).Cells(2).Value

        Dim y As String

        y = dgvStatSalariati.Rows(Index).Cells(3).Value

        Dim z As String

        z = dgvStatSalariati.Rows(Index).Cells(0).Value

        Dim h As String

        h = dgvStatSalariati.Rows(Index).Cells(11).Value


        StatPlata.Functie = h
        StatPlata.NumeSalariat = x
        StatPlata.PrenumeSalariat = y
        StatPlata.Marca = z

        Me.Hide()
        StatPlata.Show()

    End Sub

    Private Sub cmbMarca_TextChanged(sender As Object, e As EventArgs) Handles cmbMarca.TextChanged

        Dim cmdAfisareInregistrari As OleDbDataAdapter = New OleDbDataAdapter("SELECT NrFisa, Marca, OreLucrate, OreSuplimentare, NrZileConcediuOdihna, NrZileConcediuMedical " &
                                                                              "FROM PontajSalariat " &
                                                                              "WHERE Marca Like '" & cmbMarca.Text & "'", con)

        Dim dtAfisareInregistrari As New DataTable

        cmdAfisareInregistrari.Fill(dtAfisareInregistrari)

        dgvSalariatiPontaj.DataSource = dtAfisareInregistrari

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click

        pnlState.Hide()

    End Sub

    Private Sub btnAdaugareFisa_Click(sender As Object, e As EventArgs) Handles btnAdaugareFisa.Click

        con.Open()

        Dim cmdAdaugareFisa As OleDbCommand

        cmdAdaugareFisa = New OleDbCommand("INSERT INTO State([NrCurent],[Anul],[Luna])" &
                                           "VALUES (?,?,?)", con)

        Try

            cmdAdaugareFisa.Parameters.Add(New OleDbParameter("NrCurent", CType(txtNrPontaj.Text, Integer)))
            cmdAdaugareFisa.Parameters.Add(New OleDbParameter("Anul", CType(txtAnPontaj.Text, Integer)))
            cmdAdaugareFisa.Parameters.Add(New OleDbParameter("Luna", CType(txtLunaPontaj.Text, Integer)))

            cmdAdaugareFisa.ExecuteNonQuery()
            cmdAdaugareFisa.Dispose()

        Catch ex As Exception

            MsgBox("FIȘA EXISTĂ ÎN BAZA DE DATE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End Try



        Dim cmdAfisareFise As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                      "FROM State ", con)

        Dim dtFise As New DataTable

        cmdAfisareFise.Fill(dtFise)

        dgvFise.DataSource = dtFise


        MsgBox("FIȘA CU NUMĂRUL " & txtNrFisa.Text & " A FOST INTRODUSĂ CU SUCCES ÎN BAZA DE DATE!", vbInformation, "SUCCES")

        txtZileLucratoare.Clear()



        Dim cmdAfisarePontaj As OleDbDataAdapter = New OleDbDataAdapter("SELECT MAX([NrCurent]), MAX([Luna]) " &
                                                                        "FROM State ", con)

        Dim dtAfisarePontaj As New DataTable

        cmdAfisarePontaj.Fill(dtAfisarePontaj)


        Try

            If dtAfisarePontaj.Rows(0).Item(1) < Month(Now) Then

                txtNrPontaj.Text = dtAfisarePontaj.Rows(0).Item(0) + 1

            Else

                txtNrPontaj.Text = 1

            End If

        Catch ex As Exception

            txtNrPontaj.Text = 1

        End Try


        con.Close()

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        Dim cmdAfisareStat As OleDbDataAdapter = New OleDbDataAdapter("SELECT StateSalariati.[NrCurent] AS [Numar Curent],Nume & '" & " " & "' & Prenume As [Nume Prenume],[SalariuIncadrareOra] As [Salariu Incadrare Ora],[SalariuRealizat] As [Salariu Realizat],[TotalSporuri] As [Total Sporuri]," &
                                                                      "[TotalPrime] As [Total Prime],[IndemnizatieConducere] As [Indemnizatie Conducere],[SalariuBrut] As [Salariu Brut],[BazaImpozabilaCAS] As [Baza Impozabila CAS],[CAS],[CASS],[BazaImpozabila] As [Baza Impozabila]," &
                                                                      "[Deducere],[Impozit (10%)],[SalariuNet] As [Salariu Net], [Retineri],[RestDePlata] As [Rest De Plata] " &
                                                                      "FROM Salariati INNER JOIN (StateSalariati INNER JOIN State ON StateSalariati.NrCurent = State.NrCurent) ON Salariati.Marca = StateSalariati.Marca " &
                                                                      "WHERE Anul Like '" & cmbAnul.Text & "' AND Luna Like '" & cmbLuna.Text & "'", con)

        Dim dtStat As New DataTable

        cmdAfisareStat.Fill(dtStat)

        dgvState.DataSource = dtStat

    End Sub

    Private Sub btnStatistici_Click(sender As Object, e As EventArgs) Handles btnStatistici.Click

        rbNrAngajati.Checked = True

        chrtCheltuieli.Hide()
        chrtPrezenta.Hide()
        chrtStatistica.Hide()

        pnlStatistici.Show()
        pnlDosare.Hide()
        pnlDate.Hide()
        pnlPontaj.Hide()
        pnlState.Hide()



        con.Open()

        Dim cmdAnul As OleDbDataAdapter = New OleDbDataAdapter("SELECT DISTINCT([Anul])" &
                                                               "FROM Pontaj", con)

        Dim dtAnul As New DataTable

        cmdAnul.Fill(dtAnul)

        cmbAnStatistica.DataSource = dtAnul

        cmbAnStatistica.DisplayMember = "Anul"




        Dim cmdLuna As OleDbDataAdapter = New OleDbDataAdapter("SELECT DISTINCT([Luna])" &
                                                               "FROM Pontaj " &
                                                               "WHERE Anul Like '" & cmbAnStatistica.Text & "'", con)

        Dim dtLuna As New DataTable

        cmdLuna.Fill(dtLuna)

        cmbLunaStatistica.DataSource = dtLuna

        cmbLunaStatistica.DisplayMember = "Luna"



        con.Close()

    End Sub

    Private Sub Button8_Click_2(sender As Object, e As EventArgs) Handles txtIesireStatistici.Click


        pnlStatistici.Hide()

        rbNrAngajati.Checked = True

        chrtCheltuieli.Hide()
        chrtPrezenta.Hide()
        chrtStatistica.Hide()


    End Sub



    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles txtAfisareGrafic.Click

        con.Open()


        If rbNrAngajati.Checked = True Then

            chrtStatistica.Series("Nr. angajați/Departament").Points.Clear()

            chrtCheltuieli.Visible = False

            chrtPrezenta.Visible = False

            chrtStatistica.Visible = True

            Dim cmdDepartamente As OleDbCommand = New OleDbCommand("SELECT * " &
                                                                   "FROM Departamente", con)

            Dim citireDepartamente As OleDbDataReader = cmdDepartamente.ExecuteReader


            Dim cmdNrAngajati As OleDbCommand = New OleDbCommand("SELECT COUNT(Marca) AS Nr " &
                                                                 "FROM Salariati INNER JOIN Departamente ON Salariati.Departament=Departamente.CodDepartament " &
                                                                 "GROUP BY DenumireDepartament", con)

            Dim citireAngajati As OleDbDataReader = cmdNrAngajati.ExecuteReader


            While citireDepartamente.Read And citireAngajati.Read


                chrtStatistica.Series("Nr. angajați/Departament").IsValueShownAsLabel = True

                chrtStatistica.Series("Nr. angajați/Departament").Points.AddXY(citireDepartamente("DenumireDepartament"), citireAngajati("Nr"))

            End While

        ElseIf rbPrezentaLunara.Checked = True Then

            chrtPrezenta.Series("Prezenta").Points.Clear()

            chrtCheltuieli.Visible = False

            chrtStatistica.Visible = False

            chrtPrezenta.Visible = True


            Dim cmdNumeLuna As OleDbCommand = New OleDbCommand("SELECT COUNT(Marca) As NrAbsenti " &
                                                               "FROM PontajSalariat INNER JOIN Pontaj ON PontajSalariat.NrFisa=Pontaj.NrFisa " &
                                                               "WHERE OreLucrate < (NrZileLucratoare * 8) And Anul Like '" & cmbAnStatistica.Text & "' AND Luna Like '" & cmbLunaStatistica.Text & "'", con)

            Dim citireLuna As OleDbDataReader = cmdNumeLuna.ExecuteReader



            Dim cmdOre As OleDbCommand = New OleDbCommand("SELECT COUNT(Marca) As NrPrezenti " &
                                                          "FROM PontajSalariat INNER JOIN Pontaj ON PontajSalariat.NrFisa=Pontaj.NrFisa " &
                                                          "WHERE OreLucrate = (NrZileLucratoare * 8) And Anul Like '" & cmbAnStatistica.Text & "' AND Luna Like '" & cmbLunaStatistica.Text & "'", con)

            Dim citireOre As OleDbDataReader = cmdOre.ExecuteReader


            Dim cmdNrTotalSalariati As OleDbCommand = New OleDbCommand("SELECT COUNT(*) AS Total " &
                                                                       "FROM PontajSalariat INNER JOIN Pontaj ON PontajSalariat.NrFisa=Pontaj.NrFisa " &
                                                                       "WHERE Anul Like '" & cmbAnStatistica.Text & "' AND Luna Like '" & cmbLunaStatistica.Text & "'", con)

            Dim citireTotal As OleDbDataReader = cmdNrTotalSalariati.ExecuteReader


            While citireLuna.Read And citireOre.Read And citireTotal.Read

                chrtPrezenta.Series("Prezenta").IsValueShownAsLabel = True

                chrtPrezenta.Series("Prezenta").Points.AddXY("Prezenti", citireOre("NrPrezenti") / citireTotal("Total"))

                chrtPrezenta.Series("Prezenta").Points.AddXY("Absenti", citireLuna("NrAbsenti") / citireTotal("Total"))

            End While


        ElseIf rbSituatieCheltuieli.Checked = True Then

            chrtCheltuieli.Series("Cheltuieli").Points.Clear()

            chrtStatistica.Visible = False

            chrtPrezenta.Visible = False

            chrtCheltuieli.Visible = True


            Dim cmdSalarii As OleDbCommand = New OleDbCommand("SELECT SUM(RestDePlata) As Cheltuieli, Luna " &
                                                              "FROM StateSalariati INNER JOIN State ON StateSalariati.NrCurent=State.NrCurent " &
                                                              "WHERE Anul Like '" & cmbAnStatistica.Text & "'" &
                                                              "GROUP BY Luna ", con)


            Dim citireSalarii As OleDbDataReader = cmdSalarii.ExecuteReader

            Dim i As Integer = 1

            Do While citireSalarii.Read And i < 13

                chrtCheltuieli.Series("Cheltuieli").IsValueShownAsLabel = True

                chrtCheltuieli.Series("Cheltuieli").Points.AddXY(MonthName(i), citireSalarii("Cheltuieli"))

                i += 1

            Loop


        End If


        con.Close()

    End Sub

    Private Sub cmbAnStatistica_TextChanged(sender As Object, e As EventArgs) Handles cmbAnStatistica.TextChanged

        Dim cmdLuna As OleDbDataAdapter = New OleDbDataAdapter("SELECT Luna " &
                                                               "FROM State " &
                                                               "GROUP BY Luna " &
                                                               "ORDER BY LEN(Luna), Luna", con)

        Dim dtLuna As New DataTable

        cmdLuna.Fill(dtLuna)

        cmbLunaStatistica.DataSource = dtLuna

        cmbLunaStatistica.DisplayMember = "Luna"

    End Sub

    Private Sub rbSituatieCheltuieli_CheckedChanged(sender As Object, e As EventArgs) Handles rbSituatieCheltuieli.CheckedChanged

        If rbSituatieCheltuieli.Checked = True Then

            cmbLunaStatistica.Visible = False

            lblLuna.Visible = False

        Else

            cmbLunaStatistica.Visible = True

            lblLuna.Visible = True

            chrtCheltuieli.Visible = False

        End If

    End Sub

    Private Sub rbNrAngajati_CheckedChanged(sender As Object, e As EventArgs) Handles rbNrAngajati.CheckedChanged

        If rbNrAngajati.Checked = True Then

            lblLuna.Visible = False

            lblAn.Visible = False

            lblSelectie.Visible = False

            cmbLunaStatistica.Visible = False

            cmbAnStatistica.Visible = False

        Else

            lblLuna.Visible = True

            lblAn.Visible = True

            lblSelectie.Visible = True

            cmbLunaStatistica.Visible = True

            cmbAnStatistica.Visible = True

            chrtStatistica.Visible = False

        End If

    End Sub



    Private Sub rbPrezentaLunara_CheckedChanged(sender As Object, e As EventArgs) Handles rbPrezentaLunara.CheckedChanged

        If rbPrezentaLunara.Checked = False Then

            chrtPrezenta.Visible = False

        End If

    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

        SaveFileDialog1.FileName = ""

        If SaveFileDialog1.ShowDialog = DialogResult.OK Then

            TextBox2.Text = SaveFileDialog1.FileName

        End If


        Dim Paragraf1 As New Paragraph

        Dim Paragraf2 As New Paragraph

        Dim PdfFile As New Document(PageSize.LETTER.Rotate(), 60, 60, 60, 40)

        PdfFile.AddTitle(Date.Now)

        Try

            Dim Scriere As PdfWriter = PdfWriter.GetInstance(PdfFile, New FileStream(TextBox2.Text, FileMode.Create))

            PdfFile.Open()

            Dim pTitlu As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD, BaseColor.BLACK)

            Dim pTabel As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)

            Paragraf1 = New Paragraph(New Chunk("STAT DE PLATA", pTitlu))

            Paragraf1.Alignment = Element.ALIGN_CENTER

            Paragraf1.SpacingAfter = 5.0F


            Paragraf2 = New Paragraph(New Chunk("luna 7, anul 2020", pTitlu))

            Paragraf2.Alignment = Element.ALIGN_CENTER

            Paragraf2.SpacingAfter = 5.0F


            PdfFile.Add(Paragraf1)

            PdfFile.Add(Paragraf2)

            Dim PdfTabel As New PdfPTable(dgvState.Columns.Count)

            PdfTabel.TotalWidth = 790.0F



            PdfTabel.LockedWidth = True


            Dim widths(0 To dgvState.Columns.Count - 1) As Single

            For i As Integer = 0 To dgvState.Columns.Count - 1

                widths(i) = 1.0F

            Next

            PdfTabel.SetWidths(widths)
            PdfTabel.HorizontalAlignment = 1
            PdfTabel.SpacingBefore = 5.0F

            Dim pdfcell As PdfPCell = New PdfPCell

            For i As Integer = 0 To dgvState.Columns.Count - 1

                pdfcell = New PdfPCell(New Phrase(New Chunk(dgvState.Columns(i).HeaderText, pTabel)))

                pdfcell.HorizontalAlignment = PdfPCell.ALIGN_LEFT

                PdfTabel.AddCell(pdfcell)

            Next

            For i As Integer = 0 To dgvState.Rows.Count - 2

                For j As Integer = 0 To dgvState.Columns.Count - 1

                    pdfcell = New PdfPCell(New Phrase(dgvState(j, i).Value.ToString(), pTabel))

                    pdfcell.HorizontalAlignment = PdfPCell.ALIGN_LEFT

                    PdfTabel.AddCell(pdfcell)

                Next

            Next


            For Each row As DataGridViewRow In dgvState.Rows

                For Each cell As DataGridViewCell In row.Cells

                    pdfcell = New PdfPCell(New Phrase(cell.Value.ToString(), pTabel))

                    pdfcell.HorizontalAlignment = PdfPCell.ALIGN_LEFT

                    PdfTabel.AddCell(pdfcell)

                Next

            Next

            PdfFile.Add(PdfTabel)

            PdfFile.Close()


        Catch ex As Exception

        End Try

    End Sub

    Private Sub btn_Click(sender As Object, e As EventArgs) Handles btn.Click

        SaveFileDialog1.FileName = ""

        If SaveFileDialog1.ShowDialog = DialogResult.OK Then

            TextBox2.Text = SaveFileDialog1.FileName

        End If


        Dim Paragraf1 As New Paragraph

        Dim Paragraf2 As New Paragraph

        Dim Paragraf3 As New Paragraph

        Dim PdfFile As New Document(PageSize.LETTER.Rotate(), 60, 60, 60, 40)

        PdfFile.AddTitle(Date.Now)

        Try

            Dim Scriere As PdfWriter = PdfWriter.GetInstance(PdfFile, New FileStream(TextBox2.Text, FileMode.Create))

            PdfFile.Open()

            Dim pTitlu As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 15, iTextSharp.text.Font.BOLD, BaseColor.BLACK)

            Dim pTabel As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK)

            Paragraf1 = New Paragraph(New Chunk("LISTA CU SALARIATII FIRMEI", pTitlu))

            Paragraf1.Alignment = Element.ALIGN_CENTER

            Paragraf1.SpacingAfter = 5.0F


            Paragraf2 = New Paragraph(New Chunk("luna " & Month(Date.Now) & ", anul " & Year(Date.Now), pTitlu))

            Paragraf2.Alignment = Element.ALIGN_CENTER

            Paragraf2.SpacingAfter = 5.0F



            PdfFile.Add(Paragraf1)

            PdfFile.Add(Paragraf2)


            Dim PdfTabel As New PdfPTable(dgvSalariati.Columns.Count)

            PdfTabel.TotalWidth = 780.0F



            PdfTabel.LockedWidth = True


            Dim widths(0 To dgvSalariati.Columns.Count - 1) As Single

            For i As Integer = 0 To dgvSalariati.Columns.Count - 1

                widths(i) = 1.0F

            Next

            PdfTabel.SetWidths(widths)
            PdfTabel.HorizontalAlignment = 1
            PdfTabel.SpacingBefore = 6.0F

            Dim pdfcell As PdfPCell = New PdfPCell

            For i As Integer = 0 To dgvSalariati.Columns.Count - 1

                pdfcell = New PdfPCell(New Phrase(New Chunk(dgvSalariati.Columns(i).HeaderText, pTabel)))

                pdfcell.HorizontalAlignment = PdfPCell.ALIGN_LEFT

                PdfTabel.AddCell(pdfcell)

            Next

            For i As Integer = 0 To dgvSalariati.Rows.Count - 2

                For j As Integer = 0 To dgvSalariati.Columns.Count - 1

                    pdfcell = New PdfPCell(New Phrase(dgvSalariati(j, i).Value.ToString(), pTabel))

                    pdfcell.HorizontalAlignment = PdfPCell.ALIGN_LEFT

                    PdfTabel.AddCell(pdfcell)

                Next

            Next



            Paragraf3 = New Paragraph(New Chunk("INTOCMIT DE " & lblNume.Text, pTitlu))

            Paragraf3.Alignment = Element.ALIGN_CENTER

            Paragraf3.SpacingAfter = 5.0F



            PdfFile.Add(Paragraf3)



            PdfFile.Add(PdfTabel)

            PdfFile.Close()


        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtOreLucrate_Leave(sender As Object, e As EventArgs) Handles txtOreLucrate.Leave

        Dim cmdIndemnizatieBrut As OleDbDataAdapter = New OleDbDataAdapter("SELECT NrZileLucratoare " &
                                                                           "FROM Pontaj " &
                                                                           "WHERE Luna Like '" & Month(Date.Now) & "'", con)

        Dim dtIndemnizatieBrut As New DataTable

        cmdIndemnizatieBrut.Fill(dtIndemnizatieBrut)

        If Val(txtOreLucrate.Text) > dtIndemnizatieBrut.Rows(0).Item(0) * 8 Then

            txtOreLucrate.Select()
            MsgBox("NUMAR DE ORE INCORECT!", vbExclamation, "EROARE") : Exit Sub

        End If

    End Sub

    Private Sub txtOreSuplimentare_Leave(sender As Object, e As EventArgs) Handles txtOreSuplimentare.Leave

        If Val(txtOreSuplimentare.Text) > 32 Then

            txtOreSuplimentare.Select()
            MsgBox("NUMARUL DE ORE NU POATE FI MAI MARE DE 32!", vbExclamation, "EROARE") : Exit Sub

        End If

    End Sub

    Private Sub txtZileConcediuMedical_TextChanged(sender As Object, e As EventArgs) Handles txtZileConcediuMedical.TextChanged

        Dim cmdIndemnizatieBrut As OleDbDataAdapter = New OleDbDataAdapter("SELECT NrZileLucratoare " &
                                                                           "FROM Pontaj " &
                                                                           "WHERE Luna Like '" & Month(Date.Now) & "'", con)

        Dim dtIndemnizatieBrut As New DataTable

        cmdIndemnizatieBrut.Fill(dtIndemnizatieBrut)

        txtOreLucrate.Text = (dtIndemnizatieBrut.Rows(0).Item(0) * 8) - (Val(txtZileConcediuMedical.Text) * 8) - (Val(txtZileConcediuOdihna.Text) * 8) - Val(txtOreAbsentate.Text)

    End Sub

    Private Sub txtZileConcediuOdihna_TextChanged(sender As Object, e As EventArgs) Handles txtZileConcediuOdihna.TextChanged

        Dim cmdIndemnizatieBrut As OleDbDataAdapter = New OleDbDataAdapter("SELECT NrZileLucratoare " &
                                                                          "FROM Pontaj " &
                                                                          "WHERE Luna Like '" & Month(Date.Now) & "'", con)

        Dim dtIndemnizatieBrut As New DataTable

        cmdIndemnizatieBrut.Fill(dtIndemnizatieBrut)

        txtOreLucrate.Text = (dtIndemnizatieBrut.Rows(0).Item(0) * 8) - (Val(txtZileConcediuMedical.Text) * 8) - (Val(txtZileConcediuOdihna.Text) * 8) - Val(txtOreAbsentate.Text)

    End Sub

    Private Sub txtOreAbsentate_TextChanged(sender As Object, e As EventArgs) Handles txtOreAbsentate.TextChanged

        Dim cmdIndemnizatieBrut As OleDbDataAdapter = New OleDbDataAdapter("SELECT NrZileLucratoare " &
                                                                          "FROM Pontaj " &
                                                                          "WHERE Luna Like '" & Month(Date.Now) & "'", con)

        Dim dtIndemnizatieBrut As New DataTable

        cmdIndemnizatieBrut.Fill(dtIndemnizatieBrut)

        txtOreLucrate.Text = (dtIndemnizatieBrut.Rows(0).Item(0) * 8) - (Val(txtZileConcediuMedical.Text) * 8) - (Val(txtZileConcediuOdihna.Text) * 8) - Val(txtOreAbsentate.Text)

    End Sub


End Class
