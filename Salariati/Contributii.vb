Imports System.Data.OleDb

Public Class Contributii

    Private con As New OleDbConnection("Provider= Microsoft.ACE.OLEDB.12.0;Data Source=Salariati.accdb")

    Public NumeSalariat As String

    Public PrenumeSalariat As String

    Public Marca As Integer

    Private Sub Contributii_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        txtSalariat.Text = NumeSalariat & " " & PrenumeSalariat

        con.Open()

        Dim cmdContributii As OleDbDataAdapter = New OleDbDataAdapter("SELECT [DenumireContributie] " &
                                                                      "FROM Contributii ", con)

        Dim dtContributii As New DataTable

        cmdContributii.Fill(dtContributii)

        cmbContributie.DataSource = dtContributii

        cmbContributie.DisplayMember = "DenumireContributie"




        Dim cmdAfisareContributii As OleDbDataAdapter = New OleDbDataAdapter("SELECT [Contributie] " &
                                                                             "FROM ContributiiSalariat " &
                                                                             "WHERE Marca Like '" & Marca & "'", con)

        Dim dtAfisareContributii As New DataTable

        cmdAfisareContributii.Fill(dtAfisareContributii)

        dgvContributii.DataSource = dtAfisareContributii

        con.Close()

    End Sub

    Private Sub btnAdaugareC_Click(sender As Object, e As EventArgs) Handles btnAdaugareC.Click

        con.Open()

        Dim cmdAdaugareContributie As OleDbCommand = New OleDbCommand("INSERT INTO ContributiiSalariat([Marca],[Contributie])" &
                                                                      "VALUES (?,?)", con)

        Try

            cmdAdaugareContributie.Parameters.Add(New OleDbParameter("Marca", CType(Marca, Integer)))
            cmdAdaugareContributie.Parameters.Add(New OleDbParameter("Contributie", CType(cmbContributie.Text, String)))

            cmdAdaugareContributie.ExecuteNonQuery()
            cmdAdaugareContributie.Dispose()

        Catch ex As Exception

            MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End Try


        Dim cmdAfisareContributii As OleDbDataAdapter = New OleDbDataAdapter("SELECT [Contributie] " &
                                                                             "FROM ContributiiSalariat " &
                                                                             "WHERE Marca Like '" & Marca & "'", con)

        Dim dtAfisareContributii As New DataTable

        cmdAfisareContributii.Fill(dtAfisareContributii)

        dgvContributii.DataSource = dtAfisareContributii


        MsgBox("CONTRIBUȚIA DENUMITĂ " & cmbContributie.Text & " A FOST ADĂUGATĂ CU SUCCES!", vbInformation, "SUCCES")

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

        Dim cmdStergereC As OleDbCommand = New OleDbCommand("DELETE FROM [ContributiiSalariat] " &
                                                            "WHERE [Contributie] Like '" & x & "'", con)


        Try

            cmdStergereC.ExecuteNonQuery()
            cmdStergereC.Dispose()

        Catch ex As Exception

            MsgBox(ex.Message)
            con.Close()

        End Try

        MsgBox("CONTRIBUȚIA DENUMITĂ " & x & " A FOST ȘTEARSĂ!", vbInformation, "SUCCES")

        Dim cmdAfisareContributii As OleDbDataAdapter = New OleDbDataAdapter("SELECT [Contributie] " &
                                                                             "FROM ContributiiSalariat " &
                                                                             "WHERE Marca Like '" & Marca & "'", con)

        Dim dtAfisareContributii As New DataTable

        cmdAfisareContributii.Fill(dtAfisareContributii)

        dgvContributii.DataSource = dtAfisareContributii

        con.Close()

    End Sub

    Private Sub btnRevenire_Click(sender As Object, e As EventArgs) Handles btnRevenire.Click

        Me.Close()
        Meniu.Show()

    End Sub

End Class