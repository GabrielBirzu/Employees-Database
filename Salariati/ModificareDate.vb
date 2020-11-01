Imports System.Data.OleDb

Public Class ModificareDate

    Private con As New OleDbConnection("Provider= Microsoft.ACE.OLEDB.12.0;Data Source=Salariati.accdb")

    Public NumeSalariat As String

    Public PrenumeSalariat As String

    Public Marca As Integer

    Public Sub Majuscule(ByVal root As Control)

        For Each ctrl As Control In root.Controls
            Majuscule(ctrl)

            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).CharacterCasing = 1

            End If

        Next ctrl

    End Sub


    Private Sub Form3_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Majuscule(Me)

        txtSalariat.Text = NumeSalariat & " " & PrenumeSalariat

        txtSalariuIncadrare.Enabled = True
        btnCalculeaza.Visible = False
        txtTarifOra.Enabled = False
        txtNormaLucru.Enabled = False

        dtpDataNastereP.Enabled = False

        con.Open()

        Dim dt3 As New DataTable

        Dim cmdDate As OleDbDataAdapter = New OleDbDataAdapter("SELECT CNPPersoana, NumePersoana, PrenumePersoana, DataNasterePersoana " &
                                                               "FROM PersoaneIntretinere " &
                                                               "WHERE Marca Like '" & Marca & "'", con)

        cmdDate.Fill(dt3)

        dgvIntretinere.DataSource = dt3.DefaultView


        Dim cmdDateS As OleDbDataAdapter = New OleDbDataAdapter("SELECT SeriaCI, NumarCI, Emitent, Adresa, Email, Judetul, Localitatea, Telefon, DataEmitere, SalariuIncadrare " &
                                                                "FROM Salariati INNER JOIN Contracte ON Salariati.Marca = Contracte.Marca " &
                                                                "WHERE Nume & '" & " " & "' & Prenume = '" & txtSalariat.Text & "'", con)

        Dim dt As New DataTable

        cmdDateS.Fill(dt)

        If dt.Rows.Count < 1 Then

            Exit Sub

        End If


        txtSerieCI.Text = dt.Rows(0).Item(0)
        txtNumarCI.Text = dt.Rows(0).Item(1)
        txtEmitent.Text = dt.Rows(0).Item(2)
        txtAdresa.Text = dt.Rows(0).Item(3)
        txtEmail.Text = dt.Rows(0).Item(4)
        txtJudet.Text = dt.Rows(0).Item(5)
        txtLocalitate.Text = dt.Rows(0).Item(6)
        txtTelefon.Text = dt.Rows(0).Item(7)
        dtpEmitere.Value = dt.Rows(0).Item(8)
        txtSalariuIncadrare.Text = dt.Rows(0).Item(9)


        Dim cmdDepartament As OleDbDataAdapter = New OleDbDataAdapter("SELECT [DenumireDepartament] " &
                                                                      "FROM Departamente", con)

        Dim cmdSelectareD As OleDbDataAdapter = New OleDbDataAdapter("SELECT DenumireDepartament " &
                                                                     "FROM Departamente INNER JOIN Salariati ON Departamente.CodDepartament = Salariati.Departament " &
                                                                     "WHERE CodDepartament = Departament  AND Nume & '" & " " & "' & Prenume = '" & txtSalariat.Text & "'", con)


        Dim dt1 As New DataTable

        cmdDepartament.Fill(dt1)

        cmbDepartament.DataSource = dt1

        cmbDepartament.DisplayMember = "DenumireDepartament"


        Dim dtIndexD As New DataTable

        cmdSelectareD.Fill(dtIndexD)

        cmbDepartament.Text = dtIndexD.Rows(0).Item(0)


        Dim dt2 As New DataTable

        Dim cmdFunctie As OleDbDataAdapter = New OleDbDataAdapter("Select [DenumireFunctie]" &
                                                                   "FROM Functii", con)


        Dim cmdSelectareF As OleDbDataAdapter = New OleDbDataAdapter("SELECT DenumireFunctie " &
                                                                    "FROM Functii INNER JOIN Salariati ON Functii.CodFunctie = Salariati.Functie " &
                                                                    "WHERE CodFunctie = Functie AND Nume & '" & " " & "' & Prenume = '" & txtSalariat.Text & "'", con)

        cmdFunctie.Fill(dt2)

        cmbFunctie.DataSource = dt2


        cmbFunctie.DisplayMember = "CodFunctie"
        cmbFunctie.DisplayMember = "DenumireFunctie"


        Dim dtIndexF As New DataTable

        cmdSelectareF.Fill(dtIndexF)

        cmbFunctie.Text = dtIndexF.Rows(0).Item(0)


        con.Close()

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnModificare.Click

        If txtAdresa.Text = "" Or txtEmail.Text = "" Or txtEmitent.Text = "" Or txtJudet.Text = "" Or txtLocalitate.Text = "" Or txtNumarCI.Text = "" Or txtSalariuIncadrare.Text = "" Or txtSerieCI.Text = "" Or txtTelefon.Text = "" Then

            MsgBox("DATE LIPSĂ!", vbExclamation, "ATENȚIE!") : Exit Sub

        End If

        If cbOra.Checked = True And (txtTarifOra.Text = "" Or txtNormaLucru.Text = "") Then

            MsgBox("NU AU FOST INTRODUSE TOATE DATELE!", vbExclamation, "ATENȚIE!") : Exit Sub

        End If

        con.Open()


        Dim cmdCodFunctie As OleDbDataAdapter = New OleDbDataAdapter("SELECT CodFunctie " &
                                                                     "FROM Functii " &
                                                                     "WHERE DenumireFunctie Like '" & cmbFunctie.Text & "'", con)

        Dim dtCodFunctie As New DataTable

        cmdCodFunctie.Fill(dtCodFunctie)




        Dim cmdCodDepartament As OleDbDataAdapter = New OleDbDataAdapter("SELECT CodDepartament " &
                                                                         "FROM Departamente " &
                                                                         "WHERE DenumireDepartament Like '" & cmbDepartament.Text & "'", con)

        Dim dtCodDepartament As New DataTable

        cmdCodDepartament.Fill(dtCodDepartament)



        Dim cmdSchimbareF As OleDbCommand = New OleDbCommand("UPDATE Salariati " &
                                                             "SET Functie = '" & dtCodFunctie.Rows(0).Item(0) & "', Departament = '" & dtCodDepartament.Rows(0).Item(0) & "'," &
                                                             "SeriaCI = '" & txtSerieCI.Text & "', NumarCI = '" & txtNumarCI.Text & "', Emitent = '" & txtEmitent.Text & "'," &
                                                             "Adresa = '" & txtAdresa.Text & "', Email = '" & txtEmail.Text & "', Judetul = '" & txtJudet.Text & "'," &
                                                             "Localitatea = '" & txtLocalitate.Text & "', Telefon = '" & txtTelefon.Text & "', DataEmitere = '" & dtpEmitere.Value.Date & "'" &
                                                             "WHERE Nume & '" & " " & "' & Prenume = '" & txtSalariat.Text & "'", con)



        Dim cmdSchimbareC As OleDbCommand = New OleDbCommand("UPDATE Contracte INNER JOIN Salariati ON Contracte.Marca = Salariati.Marca " &
                                                             "SET SalariuIncadrare = '" & txtSalariuIncadrare.Text & "'" &
                                                             "WHERE Nume & '" & " " & "' & Prenume = '" & txtSalariat.Text & "'", con)


        Dim raspuns As Integer = MsgBox("SUNTEȚI SIGUR CĂ DORIȚI SĂ MODIFICAȚI DATELE SALARIATULUI " & txtSalariat.Text & " ?", vbYesNo, "ATENȚIE")

        If raspuns = vbYes Then

            Try

                cmdSchimbareC.ExecuteNonQuery()
                cmdSchimbareC.Dispose()

                cmdSchimbareF.ExecuteNonQuery()
                cmdSchimbareF.Dispose()


            Catch ex As Exception

                MsgBox(ex.Message)
                con.Close() : Exit Sub

            End Try


            MsgBox("DATELE ANGAJATULULUI AU FOST MODIFICATE CU SUCCES!", vbInformation, "ADĂUGARE SALARIAT")

            Me.Close()
            Meniu.Show()

        Else

            con.Close() : Exit Sub

        End If

    End Sub

    Private Sub btnAdaugareP_Click(sender As Object, e As EventArgs) Handles btnAdaugareP.Click

        If txtNumePersoana.Text = "" Or txtPrenumePersoana.Text = "" Or txtCNPPersoana.Text = "" Then

            MsgBox("NU AU FOST INTRODUSE TOATE DATELE!", vbExclamation, "ATENȚIE!") : Exit Sub

        End If


        con.Open()

        Dim cmdAdaugare As OleDbCommand = New OleDbCommand("INSERT INTO PersoaneIntretinere ([CNPPersoana],[NumePersoana],[PrenumePersoana],[DataNasterePersoana],[Marca])" &
                                                           "VALUES (?,?,?,?,?)", con)

        Try

            cmdAdaugare.Parameters.Add(New OleDbParameter("CNPPersoana", CType(txtCNPPersoana.Text, String)))
            cmdAdaugare.Parameters.Add(New OleDbParameter("NumePersoana", CType(txtNumePersoana.Text, String)))
            cmdAdaugare.Parameters.Add(New OleDbParameter("PrenumePersoana", CType(txtPrenumePersoana.Text, String)))
            cmdAdaugare.Parameters.Add(New OleDbParameter("DataNasterePersoana", CType(dtpDataNastereP.Value.Date, Date)))
            cmdAdaugare.Parameters.Add(New OleDbParameter("Marca", CType(Marca, Integer)))

        Catch ex As Exception

            MsgBox("INTRODUCEȚI TOATE DATELE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End Try

        Try

            cmdAdaugare.ExecuteNonQuery()
            cmdAdaugare.Dispose()

            dtpDataNastereP.Value = Today

        Catch ex As Exception

            MsgBox("PERSOANA CU CNP-ul " & txtCNPPersoana.Text & " EXISTĂ ÎN BAZA DE DATE!", vbInformation, "EROARE")
            con.Close() : Exit Sub

        End Try


        Dim ds As New DataSet
        Dim dt As New DataTable
        ds.Tables.Add(dt)

        Dim cmdDate As OleDbDataAdapter = New OleDbDataAdapter("SELECT CNPPersoana,NumePersoana,PrenumePersoana,DataNasterePersoana " &
                                                               "FROM PersoaneIntretinere " &
                                                               "WHERE Marca Like '" & Marca & "'", con)

        cmdDate.Fill(dt)

        dgvIntretinere.DataSource = dt

        MsgBox("PERSOANA CU CNP-ul " & txtCNPPersoana.Text & " A FOST ADĂUGATĂ CU CU SUCCES!", vbInformation, "SUCCES")



        txtNumePersoana.Clear()
        txtPrenumePersoana.Clear()
        txtCNPPersoana.Clear()

        con.Close()

    End Sub


    Private Sub btnStergereP_Click(sender As Object, e As EventArgs) Handles btnStergereP.Click

        Dim ds As New DataSet
        Dim dt As New DataTable
        ds.Tables.Add(dt)

        Dim cmdDate As OleDbDataAdapter = New OleDbDataAdapter("SELECT CNPPersoana, NumePersoana, PrenumePersoana, DataNasterePersoana " &
                                                               "FROM PersoaneIntretinere " &
                                                               "WHERE Marca Like '" & Marca & "'", con)

        cmdDate.Fill(dt)

        dgvIntretinere.DataSource = dt.DefaultView


        Dim index As Integer

        Dim x As String

        Try

            index = dgvIntretinere.CurrentCell.RowIndex

        Catch ex As NullReferenceException

            MsgBox("NU EXISTĂ ÎNREGISTRĂRI ÎN BAZA DE DATE!", vbExclamation, "EROARE") : Exit Sub

        End Try


        x = dgvIntretinere.Rows(index).Cells(index).Value

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

        con.Close()

    End Sub

    Private Sub btnAnulare_Click(sender As Object, e As EventArgs) Handles btnAnulare.Click

        Me.Close()
        Meniu.Show()

        dtpDataNastereP.Value = Today
        dtpEmitere.Value = Today

    End Sub

    Private Sub txtCNPPersoana_Leave(sender As Object, e As EventArgs) Handles txtCNPPersoana.Leave

        If Len(txtCNPPersoana.Text) = 13 Then

            Dim DataNastere As String

            DataNastere = Mid(txtCNPPersoana.Text, 4, 2) & "/" & Mid(txtCNPPersoana.Text, 6, 2) & "/" & Mid(txtCNPPersoana.Text, 2, 2)

            Dim Data As Date = Convert.ToDateTime(DataNastere)

            dtpDataNastereP.Value = Data

        ElseIf txtCNPPersoana.Text = "" Then



        Else

            txtCNPPersoana.Select()
            MsgBox("CNP ERONAT!", vbExclamation, "EROARE") : Exit Sub

        End If

    End Sub

End Class