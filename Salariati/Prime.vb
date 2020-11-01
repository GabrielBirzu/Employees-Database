Imports System.Data.OleDb

Public Class Prime

    Private con As New OleDbConnection("Provider= Microsoft.ACE.OLEDB.12.0;Data Source=Salariati.accdb")

    Public NumeSalariat As String

    Public PrenumeSalariat As String

    Public Marca As Integer

    Private Sub Prime_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        txtSalariat.Text = NumeSalariat & " " & PrenumeSalariat

        con.Open()

        Dim cmdPrime As OleDbDataAdapter = New OleDbDataAdapter("SELECT [DenumirePrima] " &
                                                                "FROM Prime ", con)

        Dim dtPrime As New DataTable

        cmdPrime.Fill(dtPrime)

        cmbPrime.DataSource = dtPrime

        cmbPrime.DisplayMember = "DenumirePrima"




        Dim cmdAfisarePrime As OleDbDataAdapter = New OleDbDataAdapter("SELECT [DenumirePrima], [SumaPrima] " &
                                                                       "FROM PrimeSalariat " &
                                                                       "WHERE Marca Like '" & Marca & "'", con)

        Dim dtAfisarePrime As New DataTable

        cmdAfisarePrime.Fill(dtAfisarePrime)

        dgvPrime.DataSource = dtAfisarePrime

        con.Close()

    End Sub

    Private Sub brnAdaugareP_Click(sender As Object, e As EventArgs) Handles brnAdaugareP.Click

        If txtSuma.Text = "" Then

            MsgBox("NU AU FOST INTRODUSE TOATE DATELE!", vbExclamation, "ATENȚIE!") : Exit Sub

        End If

        con.Open()

        Dim cmdAdaugarePrima As OleDbCommand = New OleDbCommand("INSERT INTO PrimeSalariat([Marca],[DenumirePrima],[SumaPrima])" &
                                                                "VALUES (?,?,?)", con)

        Try

            cmdAdaugarePrima.Parameters.Add(New OleDbParameter("Marca", CType(Marca, Integer)))
            cmdAdaugarePrima.Parameters.Add(New OleDbParameter("DenumirePrima", CType(cmbPrime.Text, String)))
            cmdAdaugarePrima.Parameters.Add(New OleDbParameter("SumaPrima", CType(txtSuma.Text, Integer)))

            cmdAdaugarePrima.ExecuteNonQuery()
            cmdAdaugarePrima.Dispose()

        Catch ex As Exception

            MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End Try


        Dim cmdAfisarePrime As OleDbDataAdapter = New OleDbDataAdapter("SELECT [DenumirePrima], [SumaPrima] " &
                                                                       "FROM PrimeSalariat " &
                                                                       "WHERE Marca Like '" & Marca & "'", con)

        Dim dtAfisarePrime As New DataTable

        cmdAfisarePrime.Fill(dtAfisarePrime)

        dgvPrime.DataSource = dtAfisarePrime


        MsgBox("PRIMA DENUMITĂ " & cmbPrime.Text & " A FOST ADĂUGATĂ CU SUCCES!", vbInformation, "SUCCES")

        con.Close()

    End Sub

    Private Sub btnStergereDepartament_Click(sender As Object, e As EventArgs) Handles btnStergereP.Click

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

        Dim cmdStergereP As OleDbCommand = New OleDbCommand("DELETE FROM [PrimeSalariat] " &
                                                            "WHERE [DenumirePrima] Like '" & x & "'", con)


        Try

            cmdStergereP.ExecuteNonQuery()
            cmdStergereP.Dispose()

        Catch ex As Exception

            MsgBox(ex.Message)
            con.Close()

        End Try

        MsgBox("PRIMA DENUMITĂ " & x & " A FOST ȘTEARSĂ!", vbInformation, "SUCCES")

        Dim cmdAfisarePrime As OleDbDataAdapter = New OleDbDataAdapter("SELECT [DenumirePrima], [SumaPrima] " &
                                                                       "FROM PrimeSalariat " &
                                                                       "WHERE Marca Like '" & Marca & "'", con)

        Dim dtAfisarePrime As New DataTable

        cmdAfisarePrime.Fill(dtAfisarePrime)

        dgvPrime.DataSource = dtAfisarePrime

        con.Close()

    End Sub

    Private Sub btnRevenire_Click(sender As Object, e As EventArgs) Handles btnRevenire.Click

        Me.Close()
        Meniu.Show()

    End Sub

End Class