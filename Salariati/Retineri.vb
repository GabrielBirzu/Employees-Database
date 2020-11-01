Imports System.Data.OleDb

Public Class Retineri

    Private con As New OleDbConnection("Provider= Microsoft.ACE.OLEDB.12.0;Data Source=Salariati.accdb")

    Public NumeSalariat As String

    Public PrenumeSalariat As String

    Public Marca As Integer

    Private Sub Retineri_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        txtSalariat.Text = NumeSalariat & " " & PrenumeSalariat

        con.Open()

        Dim cmdRetineri As OleDbDataAdapter = New OleDbDataAdapter("SELECT [TipRetinere] " &
                                                                   "FROM Retineri ", con)

        Dim dtRetineri As New DataTable

        cmdRetineri.Fill(dtRetineri)

        cmbRetineri.DataSource = dtRetineri

        cmbRetineri.DisplayMember = "TipRetinere"




        Dim cmdAfisareRetineri As OleDbDataAdapter = New OleDbDataAdapter("SELECT [TipRetinere],[Suma] " &
                                                                          "FROM RetineriSalariat " &
                                                                          "WHERE Marca Like '" & Marca & "'", con)

        Dim dtAfisareRetineri As New DataTable

        cmdAfisareRetineri.Fill(dtAfisareRetineri)

        dgvRetineri.DataSource = dtAfisareRetineri

        con.Close()

    End Sub

    Private Sub btnAdaugareR_Click(sender As Object, e As EventArgs) Handles btnAdaugareR.Click

        If txtSuma.Text = "" Then

            MsgBox("NU AU FOST INTRODUSE TOATE DATELE!", vbExclamation, "ATENȚIE!") : Exit Sub

        End If

        con.Open()

        Dim cmdAdaugareRetinere As OleDbCommand = New OleDbCommand("INSERT INTO RetineriSalariat([Marca],[TipRetinere],[Suma])" &
                                                                   "VALUES (?,?,?)", con)

        Try

            cmdAdaugareRetinere.Parameters.Add(New OleDbParameter("Marca", CType(Marca, Integer)))
            cmdAdaugareRetinere.Parameters.Add(New OleDbParameter("TipRetinere", CType(cmbRetineri.Text, String)))
            cmdAdaugareRetinere.Parameters.Add(New OleDbParameter("Suma", CType(txtSuma.Text, Integer)))

            cmdAdaugareRetinere.ExecuteNonQuery()
            cmdAdaugareRetinere.Dispose()

        Catch ex As Exception

            MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End Try


        Dim cmdAfisareRetineri As OleDbDataAdapter = New OleDbDataAdapter("SELECT [TipRetinere],[Suma] " &
                                                                          "FROM RetineriSalariat " &
                                                                          "WHERE Marca Like '" & Marca & "'", con)

        Dim dtAfisareRetineri As New DataTable

        cmdAfisareRetineri.Fill(dtAfisareRetineri)

        dgvRetineri.DataSource = dtAfisareRetineri


        MsgBox("REȚINEREA DENUMITĂ " & cmbRetineri.Text & " A FOST ADĂUGATĂ CU SUCCES!", vbInformation, "SUCCES")

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

        Dim cmdStergereR As OleDbCommand = New OleDbCommand("DELETE FROM [RetineriSalariat] " &
                                                            "WHERE [TipRetinere] Like '" & x & "'", con)


        Try

            cmdStergereR.ExecuteNonQuery()
            cmdStergereR.Dispose()

        Catch ex As Exception

            MsgBox(ex.Message)
            con.Close()

        End Try

        MsgBox("REȚINEREA DENUMITĂ " & x & " A FOST ȘTEARSĂ!", vbInformation, "SUCCES")

        Dim cmdAfisareRetineri As OleDbDataAdapter = New OleDbDataAdapter("SELECT [TipRetinere],[Suma] " &
                                                                          "FROM RetineriSalariat " &
                                                                          "WHERE Marca Like '" & Marca & "'", con)

        Dim dtAfisareRetineri As New DataTable

        cmdAfisareRetineri.Fill(dtAfisareRetineri)

        dgvRetineri.DataSource = dtAfisareRetineri

        con.Close()

    End Sub

    Private Sub btnRevenire_Click(sender As Object, e As EventArgs) Handles btnRevenire.Click

        Me.Close()
        Meniu.Show()

    End Sub

End Class