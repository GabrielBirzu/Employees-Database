Imports System.Data.OleDb

Public Class Penalizari

    Private con As New OleDbConnection("Provider= Microsoft.ACE.OLEDB.12.0;Data Source=Salariati.accdb")

    Public NumeSalariat As String

    Public PrenumeSalariat As String

    Public Marca As Integer

    Private Sub Penalizari_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        txtSalariat.Text = NumeSalariat & " " & PrenumeSalariat

        con.Open()

        Dim cmdAfisarePenalizari As OleDbDataAdapter = New OleDbDataAdapter("SELECT [NrPenalizare],[DataPenalizare],[MotivPenalizare],[SumaPenalizare] " &
                                                                            "FROM Penalizari " &
                                                                            "WHERE Marca Like '" & Marca & "'", con)





        Dim cmdSalariuIncadrare As OleDbDataAdapter = New OleDbDataAdapter("SELECT [SalariuIncadrare] " &
                                                                           "FROM Contracte " &
                                                                           "WHERE Marca Like '" & Marca & "'", con)


        Dim dtSalariu As New DataTable

        cmdSalariuIncadrare.Fill(dtSalariu)

        Dim Suma As Double = dtSalariu.Rows(0).Item(0) * 0.15

        txtSuma.Text = Suma

        If Suma - Math.Truncate(Suma) > 0.49 Then

            txtSuma.Text = Math.Ceiling(Suma)

        Else

            txtSuma.Text = Math.Floor(Suma)

        End If



        Dim dtAfisarePenalizari As New DataTable

        cmdAfisarePenalizari.Fill(dtAfisarePenalizari)

        dgvPenalizari.DataSource = dtAfisarePenalizari

        con.Close()



        Dim cmdNumar As OleDbDataAdapter = New OleDbDataAdapter("SELECT MAX([NrPenalizare]) " &
                                                                "FROM Penalizari ", con)

        Dim dtNumar As New DataTable

        Try

            cmdNumar.Fill(dtNumar)

            txtNr.Text = dtNumar.Rows(0).Item(0) + 1

        Catch ex As Exception

            txtNr.Text = 101

        End Try


    End Sub

    Private Sub btnAdaugareP_Click(sender As Object, e As EventArgs) Handles btnAdaugareP.Click

        If rbReducereSalariu.Checked = True Then

            If txtMotiv.Text = "" Or txtSuma.Text = "" Then

                MsgBox("NU AU FOST INTRODUSE TOATE DATELE!", vbExclamation, "ATENȚIE!") : Exit Sub

            End If


            con.Open()


            Dim cmdAdaugarePenalizare As OleDbCommand = New OleDbCommand("INSERT INTO Penalizari([NrPenalizare],[DataPenalizare],[MotivPenalizare],[SumaPenalizare],[Marca])" &
                                                                         "VALUES (?,?,?,?,?)", con)

            Try

                cmdAdaugarePenalizare.Parameters.Add(New OleDbParameter("NrPenalizare", CType(txtNr.Text, Integer)))
                cmdAdaugarePenalizare.Parameters.Add(New OleDbParameter("DataPenalizare", CType(dtpPenalizare.Value.Date, Date)))
                cmdAdaugarePenalizare.Parameters.Add(New OleDbParameter("MotivPenalizare", CType(txtMotiv.Text, String)))
                cmdAdaugarePenalizare.Parameters.Add(New OleDbParameter("SumaPenalizare", CType(txtSuma.Text, String)))
                cmdAdaugarePenalizare.Parameters.Add(New OleDbParameter("Marca", CType(Marca, Integer)))


                cmdAdaugarePenalizare.ExecuteNonQuery()
                cmdAdaugarePenalizare.Dispose()

            Catch ex As Exception

                MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
                con.Close() : Exit Sub

            End Try


            Dim cmdAfisarePenalizari As OleDbDataAdapter = New OleDbDataAdapter("SELECT [NrPenalizare],[DataPenalizare],[MotivPenalizare],[SumaPenalizare] " &
                                                                                "FROM Penalizari " &
                                                                                "WHERE Marca Like '" & Marca & "'", con)

            Dim dtAfisarePenalizari As New DataTable

            cmdAfisarePenalizari.Fill(dtAfisarePenalizari)

            dgvPenalizari.DataSource = dtAfisarePenalizari


            MsgBox("PENALIZAREA CU NUMĂRUL " & txtNr.Text & " A FOST ADĂUGATĂ CU SUCCES!", vbInformation, "SUCCES")

            Dim cmdNumar As OleDbDataAdapter = New OleDbDataAdapter("SELECT MAX([NrPenalizare]) " &
                                                                    "FROM Penalizari ", con)

            Dim dtNumar As New DataTable

            cmdNumar.Fill(dtNumar)

            txtNr.Text = dtNumar.Rows(0).Item(0) + 1

            con.Close()


        ElseIf rbDesfacere.Checked = True Then


            If txtMotiv.Text = "" Then

                MsgBox("NU AU FOST INTRODUSE TOATE DATELE!", vbExclamation, "ATENȚIE!") : Exit Sub

            End If

            con.Open()


            Dim cmdActiv As OleDbCommand = New OleDbCommand("UPDATE Salariati " &
                                                            "SET Activ = False " &
                                                            "WHERE Marca Like '" & Marca & "'", con)



            Try

                cmdActiv.ExecuteNonQuery()
                cmdActiv.Dispose()

            Catch ex As Exception

                MsgBox(ex.Message)
                con.Close()

            End Try

            MsgBox("SALARIATUL ESTE ACUM INACTIV!", vbInformation, "SUCCES")



            Dim cmdSalariati As OleDbDataAdapter = New OleDbDataAdapter("SELECT Marca, CNP, Nume, Prenume, DataNastere, Varsta, Sex, Adresa, Telefon, Casatorit, Vechime, Handicap, Profesie, DenumireFunctie, DenumireDepartament  " &
                                                                        "FROM Departamente INNER JOIN (Salariati INNER JOIN Functii ON Salariati.Functie=Functii.CodFunctie) ON Salariati.Departament=Departamente.CodDepartament " &
                                                                        "WHERE Activ Like True " &
                                                                        "ORDER BY Marca ASC ", con)


            Dim dtSalariati As New DataTable

            cmdSalariati.Fill(dtSalariati)

            Meniu.dgvSalariati.DataSource = dtSalariati




            Dim cmdFostiSalariati As OleDbDataAdapter = New OleDbDataAdapter("SELECT * " &
                                                                             "FROM Salariati " &
                                                                             "WHERE Activ Like False " &
                                                                             "ORDER BY Marca ASC ", con)

            Dim dtFostiSalariati As New DataTable

            cmdFostiSalariati.Fill(dtFostiSalariati)

            Meniu.dgvFosti.DataSource = dtFostiSalariati.DefaultView



            Me.Close()
            Meniu.Show()

        End If

        txtMotiv.Clear()

    End Sub

    Private Sub btnStergereP_Click(sender As Object, e As EventArgs) Handles btnStergereP.Click

        Dim index As Integer

        Dim x As String

        Try

            index = dgvPenalizari.CurrentRow.Index

        Catch ex As NullReferenceException

            MsgBox("NU EXISTĂ ÎNREGISTRĂRI ÎN BAZA DE DATE!", vbExclamation, "EROARE") : Exit Sub

        End Try

        x = dgvPenalizari.Rows(index).Cells(0).Value


        dgvPenalizari.Rows.RemoveAt(index)


        con.Open()

        Dim cmdStergereP As OleDbCommand = New OleDbCommand("DELETE FROM [Penalizari] " &
                                                            "WHERE [NrPenalizare] Like '" & x & "'", con)


        Try

            cmdStergereP.ExecuteNonQuery()
            cmdStergereP.Dispose()

        Catch ex As Exception

            MsgBox(ex.Message)
            con.Close()

        End Try

        MsgBox("PENALIZAREA CU NUMĂRUL " & x & " A FOST ȘTEARSĂ!", vbInformation, "SUCCES")

        Dim cmdAfisarePenalizari As OleDbDataAdapter = New OleDbDataAdapter("SELECT [NrPenalizare],[DataPenalizare],[MotivPenalizare],[SumaPenalizare] " &
                                                                            "FROM Penalizari " &
                                                                            "WHERE Marca Like '" & Marca & "'", con)

        Dim dtAfisarePenalizari As New DataTable

        cmdAfisarePenalizari.Fill(dtAfisarePenalizari)

        dgvPenalizari.DataSource = dtAfisarePenalizari


        Dim cmdNumar As OleDbDataAdapter = New OleDbDataAdapter("SELECT MAX([NrPenalizare]) " &
                                                                "FROM Penalizari ", con)

        Dim dtNumar As New DataTable

        Try

            cmdNumar.Fill(dtNumar)

            txtNr.Text = dtNumar.Rows(0).Item(0) + 1

        Catch ex As Exception

            txtNr.Text = 101

        End Try


        con.Close()

    End Sub

    Private Sub btnRevenire_Click(sender As Object, e As EventArgs) Handles btnRevenire.Click

        Me.Close()
        Meniu.Show()

    End Sub

    Private Sub rbDesfacere_CheckedChanged(sender As Object, e As EventArgs) Handles rbDesfacere.CheckedChanged

        If rbDesfacere.Checked = True Then

            dtpPenalizare.Enabled = False

            txtMotiv.Clear()
            txtSuma.Clear()
            dtpPenalizare.Value = Now.Date


        ElseIf rbDesfacere.Checked = False Then

            con.Open()

            Dim cmdSalariuIncadrare As OleDbDataAdapter = New OleDbDataAdapter("SELECT [SalariuIncadrare] " &
                                                                               "FROM Contracte " &
                                                                               "WHERE Marca Like '" & Marca & "'", con)


            Dim dtSalariu As New DataTable

            cmdSalariuIncadrare.Fill(dtSalariu)

            Dim Suma As Double = dtSalariu.Rows(0).Item(0) * 0.15

            txtSuma.Text = Suma

            If Suma - Math.Truncate(Suma) > 0.49 Then

                txtSuma.Text = Math.Ceiling(Suma)

            Else

                txtSuma.Text = Math.Floor(Suma)

            End If

            con.Close()


        End If



    End Sub

    Private Sub rbReducereSalariu_CheckedChanged(sender As Object, e As EventArgs) Handles rbReducereSalariu.CheckedChanged

        If rbReducereSalariu.Checked = True Then

            dtpPenalizare.Enabled = True

            txtMotiv.Clear()
            dtpPenalizare.Value = Now.Date


        End If


    End Sub

End Class