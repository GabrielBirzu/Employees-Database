Imports System.Data.OleDb
Imports System.Data.SqlTypes
Imports System.Security.Principal

Public Class StatPlata

    Private con As New OleDbConnection("Provider= Microsoft.ACE.OLEDB.12.0;Data Source=Salariati.accdb")

    Public NumeSalariat As String

    Public PrenumeSalariat As String

    Public Marca As Integer

    Public Functie As String


    Private Sub StatPlata_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        txtSalariat.Text = NumeSalariat & " " & PrenumeSalariat

        txtTicheteMasa.Text = 0

        txtSumaTichete.Text = 0



        con.Open()

        Dim cmdIndemnizatieBrut As OleDbDataAdapter = New OleDbDataAdapter("SELECT NrZileLucratoare " &
                                                                           "FROM Pontaj " &
                                                                           "WHERE Luna Like '" & Month(Date.Now) & "' AND Anul Like '" & Year(Date.Now) & "'", con)

        Dim dtIndemnizatieBrut As New DataTable

        cmdIndemnizatieBrut.Fill(dtIndemnizatieBrut)


        Dim cmdLunaTrecuta As OleDbDataAdapter = New OleDbDataAdapter("SELECT NrZileLucratoare " &
                                                                      "FROM Pontaj " &
                                                                      "WHERE Luna Like '" & Month(Date.Now) - 1 & "' AND Anul Like '" & Year(Date.Now) & "'", con)

        Dim dtLunaTrecuta As New DataTable

        cmdLunaTrecuta.Fill(dtLunaTrecuta)


        Dim cmdZileConcediuMedical As OleDbDataAdapter = New OleDbDataAdapter("SELECT NrZileConcediuMedical " &
                                                                              "FROM PontajSalariat INNER JOIN Pontaj ON PontajSalariat.NrFisa = Pontaj.NrFisa " &
                                                                              "WHERE Marca LIKE '" & Marca & "' AND Luna Like '" & Month(Date.Now) & "' AND Anul Like '" & Year(Date.Now) & "'", con)


        Dim dtNrZileConcediuMedical As New DataTable

        cmdZileConcediuMedical.Fill(dtNrZileConcediuMedical)



        Dim cmdOreSuplimentare As OleDbDataAdapter = New OleDbDataAdapter("SELECT OreSuplimentare " &
                                                                          "FROM PontajSalariat INNER JOIN Pontaj ON PontajSalariat.NrFisa = Pontaj.NrFisa " &
                                                                          "WHERE Marca LIKE '" & Marca & "' AND Luna Like '" & Month(Date.Now) & "' AND Anul Like '" & Year(Date.Now) & "'", con)

        Dim dtOreSuplimentare As New DataTable

        cmdOreSuplimentare.Fill(dtOreSuplimentare)


        Dim cmdSalariuBrut As OleDbDataAdapter = New OleDbDataAdapter("SELECT SalariuBrut " &
                                                                      "FROM StateSalariati INNER JOIN State ON StateSalariati.NrCurent = State.NrCurent " &
                                                                      "WHERE Marca Like '" & Marca & "' AND Luna Like '" & Month(Date.Now) & "' AND Anul Like '" & Year(Date.Now) & "'", con)

        Dim dtSalariuBrut As New DataTable

        cmdSalariuBrut.Fill(dtSalariuBrut)



        Dim cmdSalariuIncadrare As OleDbDataAdapter = New OleDbDataAdapter("SELECT SalariuIncadrare " &
                                                                           "FROM Contracte " &
                                                                           "WHERE Marca Like '" & Marca & "'", con)

        Dim NrConcendiuMedical As Integer


        Try

            NrConcendiuMedical = ((dtSalariuBrut.Rows(0).Item(0) / (dtLunaTrecuta.Rows(0).Item(0)) * 0.75)) * dtNrZileConcediuMedical.Rows(0).Item(0)

        Catch ex As Exception

            NrConcendiuMedical = 0

        End Try




        Dim dtSalariuIncadrare As New DataTable

        cmdSalariuIncadrare.Fill(dtSalariuIncadrare)


        txtSalariuIncadrare.Text = dtSalariuIncadrare.Rows(0).Item(0)




            Dim cmdPenalizare As OleDbDataAdapter = New OleDbDataAdapter("SELECT SUM(SumaPenalizare) " &
                                                                     "FROM Penalizari " &
                                                                     "WHERE Marca Like '" & Marca & "'", con)

        Try

            Dim dtPenalizare As New DataTable

            cmdPenalizare.Fill(dtPenalizare)

            txtPenalizare.Text = dtPenalizare.Rows(0).Item(0)

        Catch ex As Exception

            txtPenalizare.Text = 0

        End Try



        Dim cmdNormaLucru As OleDbDataAdapter = New OleDbDataAdapter("SELECT NrZileLucratoare " &
                                                                     "FROM Pontaj " &
                                                                     "WHERE Anul Like '" & Year(Now.Date) & "' AND Luna Like '" & Month(Now.Date) & "' AND Anul Like '" & Year(Date.Now) & "'", con)

        Dim dtNormaLucru As New DataTable

        cmdNormaLucru.Fill(dtNormaLucru)

        txtNorma.Text = dtNormaLucru.Rows(0).Item(0) * 8


        txtSalariuIncadrareOra.Text = Math.Round((txtSalariuIncadrare.Text - txtPenalizare.Text) / txtNorma.Text, 4)



        Dim cmdPrezenta As OleDbDataAdapter = New OleDbDataAdapter("SELECT OreLucrate, OreSuplimentare " &
                                                                   "FROM PontajSalariat INNER JOIN Pontaj ON PontajSalariat.NrFisa = Pontaj.NrFisa " &
                                                                   "WHERE Marca Like '" & Marca & "' AND Luna Like '" & Month(Date.Now) & "' AND Anul Like '" & Year(Date.Now) & "'", con)

        Dim dtPrezenta As New DataTable

        cmdPrezenta.Fill(dtPrezenta)


        txtPrezenta.Text = dtPrezenta.Rows(0).Item(0) + dtPrezenta.Rows(0).Item(1)

        If Val(txtPrezenta.Text) > Val(txtNorma.Text) Then

            txtSalariuRealizat.Text = Math.Round(txtSalariuIncadrareOra.Text * (Val(txtPrezenta.Text) - (Val(txtPrezenta.Text) - Val(txtNorma.Text))) + NrConcendiuMedical, 0)

        Else

            txtSalariuRealizat.Text = Math.Round((txtSalariuIncadrareOra.Text * txtPrezenta.Text) + NrConcendiuMedical, 0)

        End If



        Dim cmdSporVechime As OleDbDataAdapter = New OleDbDataAdapter("SELECT [ProcentSpor (%)] " &
                                                                      "FROM Sporuri INNER JOIN (SporuriContract INNER JOIN Contracte ON SporuriContract.NrContract = Contracte.NrContract) ON Sporuri.DenumireSpor = SporuriContract.DenumireSpor " &
                                                                      "WHERE Sporuri.DenumireSpor Like '" & "SPOR DE VECHIME 3-5 ANI" & "' OR Sporuri.DenumireSpor Like '" & "SPOR DE VECHIME 5-10 ANI" & "' OR  Sporuri.DenumireSpor Like '" & "SPOR DE VECHIME 10-15 ANI" & "'" &
                                                                      "OR  Sporuri.DenumireSpor Like '" & "SPOR DE VECHIME 15-20 ANI" & "' OR  Sporuri.DenumireSpor Like '" & "SPOR DE VECHIME PESTE 20 ANI" & "' And Marca Like  '" & Marca & "'", con)

        Dim dtSporVechime As New DataTable

        cmdSporVechime.Fill(dtSporVechime)

        Dim Vechime As Double

        Try

            Vechime = Val(txtSalariuRealizat.Text) * (dtSporVechime.Rows(0).Item(0) / 100)

        Catch ex As Exception

            Vechime = 0

        End Try


        Try

            txtSporVechime.Text = Vechime

        Catch ex As Exception

            txtSporVechime.Text = 0

        End Try

        If Vechime - Math.Truncate(Vechime) > 0.49 Then

            txtSporVechime.Text = Math.Ceiling(Vechime)

        Else

            txtSporVechime.Text = Math.Floor(Vechime)

        End If


        Dim cmdSporConditiiGrele As OleDbDataAdapter = New OleDbDataAdapter("SELECT [ProcentSpor (%)] " &
                                                                            "FROM Sporuri INNER JOIN (SporuriContract INNER JOIN Contracte ON SporuriContract.NrContract = Contracte.NrContract) ON Sporuri.DenumireSpor = SporuriContract.DenumireSpor " &
                                                                            "WHERE Sporuri.DenumireSpor Like '" & "SPOR PENTRU CONDIȚII GRELE DE MUNCĂ" & "' AND Marca Like '" & Marca & "'", con)

        Dim dtSporConditiiGrele As New DataTable

        cmdSporConditiiGrele.Fill(dtSporConditiiGrele)


        Dim SporConditii As Double

        Try

            SporConditii = Val(txtSalariuRealizat.Text) * (dtSporConditiiGrele.Rows(0).Item(0) / 100)

        Catch ex As Exception

            SporConditii = 0

        End Try


        Try

            txtSporConditii.Text = SporConditii

        Catch ex As Exception

            txtSporConditii.Text = 0

        End Try

        If SporConditii - Math.Truncate(SporConditii) > 0.49 Then

            txtSporConditii.Text = Math.Ceiling(SporConditii)

        Else

            txtSporConditii.Text = Math.Floor(SporConditii)

        End If


        Dim cmdIndemnizatie As OleDbDataAdapter = New OleDbDataAdapter("SELECT TipConducere " &
                                                                       "FROM Functii " &
                                                                       "WHERE DenumireFunctie Like '" & Functie & "'", con)

        Dim dtIndemnizatie As New DataTable

        cmdIndemnizatie.Fill(dtIndemnizatie)


        Dim Indemnizatie As Double

        Try

            Indemnizatie = txtSalariuIncadrare.Text * 0.3

        Catch ex As Exception

            Indemnizatie = 0

        End Try

        If dtIndemnizatie.Rows(0).Item(0) = True Then

            txtIndemnizatie.Text = Indemnizatie

        Else

            txtIndemnizatie.Text = 0

        End If


        If Indemnizatie - Math.Truncate(Indemnizatie) > 0.49 Then

            txtIndemnizatie.Text = Math.Ceiling(Indemnizatie)

        Else

            txtIndemnizatie.Text = Math.Floor(Indemnizatie)

        End If


        Dim cmdPrimaMerit As OleDbDataAdapter = New OleDbDataAdapter("SELECT SumaPrima " &
                                                                     "FROM PrimeSalariat " &
                                                                     "WHERE Marca Like '" & Marca & "' AND DenumirePrima Like '" & "PRIMĂ DE MERIT" & "'", con)

        Dim dtPrimaMerit As New DataTable

        cmdPrimaMerit.Fill(dtPrimaMerit)

        Try

            txtPrimaMerit.Text = dtPrimaMerit.Rows(0).Item(0)

        Catch ex As Exception

            txtPrimaMerit.Text = 0

        End Try





        Dim cmdPrimaDeVacanta As OleDbDataAdapter = New OleDbDataAdapter("SELECT SumaPrima " &
                                                                         "FROM PrimeSalariat " &
                                                                         "WHERE Marca Like '" & Marca & "' AND DenumirePrima Like '" & "PRIMĂ DE VACANȚĂ" & "'", con)

        Dim dtPrimaDeVacanta As New DataTable

        cmdPrimaDeVacanta.Fill(dtPrimaDeVacanta)

        Try

            txtPrimaVacanta.Text = dtPrimaDeVacanta.Rows(0).Item(0)

        Catch ex As Exception

            txtPrimaVacanta.Text = 0

        End Try




        Dim cmdPrimaDeSarbatori As OleDbDataAdapter = New OleDbDataAdapter("SELECT SumaPrima " &
                                                                           "FROM PrimeSalariat " &
                                                                           "WHERE Marca Like '" & Marca & "' AND DenumirePrima Like '" & "PRIMĂ DE SĂRBĂTORI" & "'", con)

        Dim dtPrimaDeSarbatori As New DataTable

        cmdPrimaDeSarbatori.Fill(dtPrimaDeSarbatori)

        Try

            txtPrimaSarbatori.Text = dtPrimaDeSarbatori.Rows(0).Item(0)

        Catch ex As Exception

            txtPrimaSarbatori.Text = 0

        End Try

        txtTicheteMasa.Text = Math.Ceiling(Val(txtPrezenta.Text) / 8)

        txtSumaTichete.Text = txtTicheteMasa.Text * 15



        Dim OreSuplimentare As Integer

        Try

            OreSuplimentare = (Val(txtSalariuIncadrareOra.Text) * 0.75) * dtOreSuplimentare.Rows(0).Item(0)


        Catch ex As Exception

            OreSuplimentare = 0

        End Try

        txtOreSuplimentare.Text = OreSuplimentare


        If Val(txtPrimaSarbatori.Text) > 150 And Val(txtPrimaVacanta.Text) > 150 Then

            txtSalariuBrut.Text = Val(txtSalariuRealizat.Text) + Val(txtSporVechime.Text) + Val(txtSporConditii.Text) + Val(txtOreSuplimentare.Text) + Val(txtPrimaMerit.Text) + Val(txtPrimaSarbatori.Text) + Val(txtPrimaVacanta.Text) + Val(txtIndemnizatie.Text) + Val(txtSumaTichete.Text)

        ElseIf Val(txtPrimaSarbatori.Text) > 150 And Val(txtPrimaVacanta.Text) < 151 Then

            txtSalariuBrut.Text = Val(txtSalariuRealizat.Text) + Val(txtSporVechime.Text) + Val(txtSporConditii.Text) + Val(txtOreSuplimentare.Text) + Val(txtPrimaMerit.Text) + Val(txtPrimaSarbatori.Text) + Val(txtIndemnizatie.Text) + Val(txtSumaTichete.Text)

        ElseIf Val(txtPrimaSarbatori.Text) < 151 And Val(txtPrimaVacanta.Text) > 150 Then

            txtSalariuBrut.Text = Val(txtSalariuRealizat.Text) + Val(txtSporVechime.Text) + Val(txtSporConditii.Text) + Val(txtOreSuplimentare.Text) + Val(txtPrimaMerit.Text) + Val(txtPrimaVacanta.Text) + Val(txtIndemnizatie.Text) + Val(txtSumaTichete.Text)

        ElseIf Val(txtPrimaVacanta.Text) < 151 And Val(txtPrimaSarbatori.Text) < 151 Then

            txtSalariuBrut.Text = Val(txtSalariuRealizat.Text) + Val(txtSporVechime.Text) + Val(txtSporConditii.Text) + Val(txtOreSuplimentare.Text) + Val(txtPrimaMerit.Text) + Val(txtIndemnizatie.Text) + Val(txtSumaTichete.Text)

        End If


        txtBazaCA.Text = txtSalariuBrut.Text


        Dim cmdCAS As OleDbDataAdapter = New OleDbDataAdapter("SELECT [ProcentContributie (%)] " &
                                                              "FROM Contributii INNER JOIN ContributiiSalariat ON Contributii.DenumireContributie=ContributiiSalariat.Contributie " &
                                                              "WHERE Marca Like '" & Marca & "' AND Contributie Like '" & "CAS" & "'", con)

        Dim dtCAS As New DataTable

        cmdCAS.Fill(dtCAS)

        Dim ZecimaleCAS As Double = (dtCAS.Rows(0).Item(0) / 100) * Val(txtBazaCA.Text)


        Try

            txtCAS.Text = ZecimaleCAS

        Catch ex As Exception

            txtCAS.Text = 0

        End Try


        If ZecimaleCAS - Math.Truncate(ZecimaleCAS) > 0.49 Then

            txtCAS.Text = Math.Ceiling(ZecimaleCAS)

        Else

            txtCAS.Text = Math.Floor(ZecimaleCAS)

        End If




        Dim cmdCASS As OleDbDataAdapter = New OleDbDataAdapter("SELECT [ProcentContributie (%)] " &
                                                              "FROM Contributii INNER JOIN ContributiiSalariat ON Contributii.DenumireContributie=ContributiiSalariat.Contributie " &
                                                              "WHERE Marca Like '" & Marca & "' AND Contributie Like '" & "CASS" & "'", con)

        Dim dtCASS As New DataTable

        cmdCASS.Fill(dtCASS)


        Dim ZecimaleCASS As Double = (dtCASS.Rows(0).Item(0) / 100) * Val(txtBazaCA.Text)


        Try

            txtCASS.Text = ZecimaleCASS

        Catch ex As Exception

            txtCASS.Text = 0

        End Try

        If ZecimaleCASS - Math.Truncate(ZecimaleCASS) > 0.49 Then

            txtCASS.Text = Math.Ceiling(ZecimaleCASS)

        Else

            txtCASS.Text = Math.Floor(ZecimaleCASS)

        End If



        Dim cmdCAM As OleDbDataAdapter = New OleDbDataAdapter("SELECT [ProcentContributie (%)] " &
                                                              "FROM Contributii " &
                                                              "WHERE DenumireContributie Like '" & "CAM" & "'", con)

        Dim dtCAM As New DataTable

        cmdCAM.Fill(dtCAM)

        Try

            txtCAM.Text = Math.Round(dtCAM.Rows(0).Item(0) / 100 * txtBazaCA.Text)

        Catch ex As Exception

            txtCAM.Text = 0

        End Try


        txtContributii.Text = Val(txtCAS.Text) + Val(txtCASS.Text)




        Dim cmdDeducere As OleDbDataAdapter = New OleDbDataAdapter("SELECT COUNT(CNPPersoana) " &
                                                                   "FROM PersoaneIntretinere " &
                                                                   "WHERE Marca Like '" & Marca & "'", con)

        Dim dtDeducere As New DataTable

        cmdDeducere.Fill(dtDeducere)


        Dim NrPersoane As Integer

        If dtDeducere.Rows(0).Item(0) >= 4 Then

            NrPersoane = 5

        Else

            NrPersoane = dtDeducere.Rows(0).Item(0)

        End If


        If txtSalariuBrut.Text > 3600 Then

            txtDeduceri.Text = 0

        ElseIf txtSalariuBrut.Text < 1901 Then

            txtDeduceri.Text = 1095 - (0.3 * 1950) + (160 * NrPersoane)

        Else

            txtDeduceri.Text = 1095 - 0.3 * (Math.Ceiling((Val(txtSalariuBrut.Text) + Val(txtSumaTichete.Text)) / 50) * 50) + 160 * NrPersoane

        End If

        txtVenitImpozabil.Text = Val(txtSalariuBrut.Text) - Val(txtDeduceri.Text) - Val(txtContributii.Text) + Val(txtSumaTichete.Text)


        If Val(txtVenitImpozabil.Text * 0.1) - Math.Truncate(0.1 * Val(txtVenitImpozabil.Text)) > 0.49 Then

            txtImpozit.Text = Math.Ceiling(0.1 * Val(txtVenitImpozabil.Text))

        Else

            txtImpozit.Text = Math.Floor(0.1 * Val(txtVenitImpozabil.Text))

        End If



        Dim cmdHandicap As OleDbDataAdapter = New OleDbDataAdapter("SELECT Handicap " &
                                                                   "FROM Salariati " &
                                                                   "WHERE Marca Like '" & Marca & "'", con)


        Dim dtHandicap As New DataTable

        cmdHandicap.Fill(dtHandicap)


        If dtHandicap.Rows(0).Item(0) = True Then

            If Val(txtPrimaVacanta.Text) > 150 And Val(txtPrimaSarbatori.Text) > 150 Then

                txtSalariuNet.Text = Val(txtBazaCA.Text) - Val(txtContributii.Text)

            ElseIf Val(txtPrimaVacanta.Text) < 151 And Val(txtPrimaSarbatori.Text) > 150 Then

                txtSalariuNet.Text = Val(txtBazaCA.Text) - Val(txtContributii.Text) + Val(txtPrimaVacanta.Text)

            ElseIf Val(txtPrimaVacanta.Text) > 150 And Val(txtPrimaSarbatori.Text) < 151 Then

                txtSalariuNet.Text = Val(txtBazaCA.Text) - Val(txtContributii.Text) + Val(txtPrimaSarbatori.Text)

            ElseIf Val(txtPrimaVacanta.Text) < 151 And Val(txtPrimaSarbatori.Text) < 151 Then

                txtSalariuNet.Text = Val(txtBazaCA.Text) - Val(txtContributii.Text) + Val(txtPrimaSarbatori.Text) + Val(txtPrimaVacanta.Text)

            End If

        ElseIf Val(txtPrimaVacanta.Text) > 150 And Val(txtPrimaSarbatori.Text) > 150 Then

            txtSalariuNet.Text = Val(txtBazaCA.Text) - Val(txtContributii.Text) - Val(txtImpozit.Text)

        ElseIf Val(txtPrimaVacanta.Text) < 151 And Val(txtPrimaSarbatori.Text) > 150 Then

            txtSalariuNet.Text = Val(txtBazaCA.Text) - Val(txtContributii.Text) - Val(txtImpozit.Text) + Val(txtPrimaVacanta.Text)

        ElseIf Val(txtPrimaVacanta.Text) > 150 And Val(txtPrimaSarbatori.Text) < 151 Then

            txtSalariuNet.Text = Val(txtBazaCA.Text) - Val(txtContributii.Text) - Val(txtImpozit.Text) + Val(txtPrimaSarbatori.Text)

        ElseIf Val(txtPrimaVacanta.Text) < 151 And Val(txtPrimaSarbatori.Text) < 151 Then

            txtSalariuNet.Text = Val(txtBazaCA.Text) - Val(txtContributii.Text) - Val(txtImpozit.Text) + Val(txtPrimaSarbatori.Text) + Val(txtPrimaVacanta.Text)

        End If





        Dim cmdSindicat As OleDbDataAdapter = New OleDbDataAdapter("SELECT Suma " &
                                                                   "FROM RetineriSalariat " &
                                                                   "WHERE TipRetinere Like '" & "SINDICAT" & "' AND Marca Like '" & Marca & "'", con)


        Dim dtSindicat As New DataTable

        cmdSindicat.Fill(dtSindicat)

        Try

            txtSindicat.Text = dtSindicat.Rows(0).Item(0)

        Catch ex As Exception

            txtSindicat.Text = 0

        End Try



        Dim cmdCAR As OleDbDataAdapter = New OleDbDataAdapter("SELECT Suma " &
                                                              "FROM RetineriSalariat " &
                                                              "WHERE TipRetinere Like '" & "CAR" & "' AND Marca Like '" & Marca & "'", con)


        Dim dtCAR As New DataTable

        cmdCAR.Fill(dtCAR)


        Try

            txtCAR.Text = dtCAR.Rows(0).Item(0)

        Catch ex As Exception

            txtCAR.Text = 0

        End Try



        Dim cmdRata As OleDbDataAdapter = New OleDbDataAdapter("SELECT Suma " &
                                                               "FROM RetineriSalariat " &
                                                               "WHERE TipRetinere Like '" & "RATĂ BANCARĂ" & "' AND Marca Like '" & Marca & "'", con)


        Dim dtRata As New DataTable

        cmdRata.Fill(dtRata)


        Try

            txtRata.Text = dtRata.Rows(0).Item(0)

        Catch ex As Exception

            txtRata.Text = 0

        End Try



        txtRestPlata.Text = txtSalariuNet.Text - txtSindicat.Text - txtCAR.Text - txtRata.Text


        con.Close()


    End Sub

    Private Sub btnRevenire_Click(sender As Object, e As EventArgs) Handles btnRevenire.Click

        Me.Close()
        Meniu.Show()

    End Sub




    Private Sub btnAcordare_Click(sender As Object, e As EventArgs) Handles btnAcordare.Click

        con.Open()

        Dim cmdNrStat As OleDbDataAdapter = New OleDbDataAdapter("SELECT MAX([NrCurent]) " &
                                                                 "FROM SalariatiStat ", con)

        Dim dtNrStat As New DataTable


        Dim Nr As Integer

        Try

            cmdNrStat.Fill(dtNrStat)

            Nr = dtNrStat.Rows(0).Item(0)

        Catch ex As Exception

            Nr = 1

        End Try



        Dim cmdAdaugare As OleDbCommand = New OleDbCommand("INSERT INTO StateSalariati([NrCurent],[Marca],[SalariuIncadrareOra],[SalariuRealizat],[TotalSporuri]," &
                                                           "[TotalPrime],[IndemnizatieConducere],[SalariuBrut],[BazaImpozabilaCAS],[CAS],[CASS],[BazaImpozabila]," &
                                                           "[Deducere],[Impozit (10%)],[SalariuNet],[Retineri],[RestDePlata])" &
                                                           "VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)", con)
        Try

            cmdAdaugare.Parameters.Add(New OleDbParameter("NrCurent", CType(Nr, Integer)))
            cmdAdaugare.Parameters.Add(New OleDbParameter("Marca", CType(Marca, Integer)))
            cmdAdaugare.Parameters.Add(New OleDbParameter("SalariuIncadrareOra", CType(txtSalariuIncadrareOra.Text, Integer)))
            cmdAdaugare.Parameters.Add(New OleDbParameter("SalariuRealizat", CType(txtSalariuRealizat.Text, Integer)))
            cmdAdaugare.Parameters.Add(New OleDbParameter("TotalSporuri", CType(txtSporConditii.Text + txtSporVechime.Text + txtOreSuplimentare.Text, Integer)))
            cmdAdaugare.Parameters.Add(New OleDbParameter("TotalPrime", CType(txtPrimaMerit.Text + txtPrimaSarbatori.Text + txtPrimaVacanta.Text, Integer)))
            cmdAdaugare.Parameters.Add(New OleDbParameter("IndemnizatieConducere", CType(txtIndemnizatie.Text, Integer)))
            cmdAdaugare.Parameters.Add(New OleDbParameter("SalariuBrut", CType(txtSalariuBrut.Text, Integer)))
            cmdAdaugare.Parameters.Add(New OleDbParameter("BazaImpozabilaCAS", CType(txtBazaCA.Text, Integer)))
            cmdAdaugare.Parameters.Add(New OleDbParameter("CAS", CType(txtCAS.Text, Integer)))
            cmdAdaugare.Parameters.Add(New OleDbParameter("CASS", CType(txtCASS.Text, Integer)))
            cmdAdaugare.Parameters.Add(New OleDbParameter("BazaImpozabila", CType(txtVenitImpozabil.Text, Integer)))
            cmdAdaugare.Parameters.Add(New OleDbParameter("Deducere", CType(txtDeduceri.Text, Integer)))
            cmdAdaugare.Parameters.Add(New OleDbParameter("Impozit (10%)", CType(txtImpozit.Text, Integer)))
            cmdAdaugare.Parameters.Add(New OleDbParameter("SalariuNet", CType(txtSalariuNet.Text, Integer)))
            cmdAdaugare.Parameters.Add(New OleDbParameter("Retineri", CType(Val(txtCAR.Text) + Val(txtSindicat.Text) + Val(txtRata.Text), Integer)))
            cmdAdaugare.Parameters.Add(New OleDbParameter("RestDePlata", CType(txtRestPlata.Text, Integer)))


            cmdAdaugare.ExecuteNonQuery()
            cmdAdaugare.Dispose()

        Catch ex As Exception

            MsgBox("ANGAJATUL " & txtSalariat.Text & " ARE SALARIUL CALCULAT PE ACEASTĂ LUNĂ!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End Try


        MsgBox("DATELE PRIVIND SALARIUL ANGAJATULUI " & txtSalariat.Text & " AU FOST SALVATE ÎN BAZA DE DATE!", vbInformation, "SUCCES")


        con.Close()

        Me.Close()

        Meniu.Show()


    End Sub

End Class