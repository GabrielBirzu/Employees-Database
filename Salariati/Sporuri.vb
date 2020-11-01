Imports System.Data.OleDb

Public Class Sporuri

    Private con As New OleDbConnection("Provider= Microsoft.ACE.OLEDB.12.0;Data Source=Salariati.accdb")

    Public NumeSalariat As String

    Public PrenumeSalariat As String

    Public Marca As Integer

    Private Sub Sporuri_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        txtSalariat.Text = NumeSalariat & " " & PrenumeSalariat

        con.Open()

        Dim cmdSporuri As OleDbDataAdapter = New OleDbDataAdapter("SELECT [DenumireSpor] " &
                                                                  "FROM Sporuri ", con)

        Dim dtSporuri As New DataTable

        cmdSporuri.Fill(dtSporuri)

        cmbSporuri.DataSource = dtSporuri

        cmbSporuri.DisplayMember = "DenumireSpor"



        Dim cmdContract As OleDbDataAdapter = New OleDbDataAdapter("SELECT NrContract " &
                                                                   "FROM Contracte " &
                                                                   "WHERE Marca Like '" & Marca & "'", con)

        Dim dtContract As New DataTable

        Dim x As Integer

        cmdContract.Fill(dtContract)

        x = dtContract.Rows(0).Item(0)


        Dim cmdVechime As OleDbDataAdapter = New OleDbDataAdapter("SELECT Vechime " &
                                                                  "FROM Salariati " &
                                                                  "WHERE Marca Like '" & Marca & "'", con)

        Dim dtVechime As New DataTable

        cmdVechime.Fill(dtVechime)

        Dim NrAni As Integer

        NrAni = Microsoft.VisualBasic.Left(dtVechime.Rows(0).Item(0), 2)

        Dim cmdStergere As OleDbCommand = New OleDbCommand("DELETE FROM SporuriContract " &
                                                           "WHERE DenumireSpor Like 'SPOR DE VECHIME%'", con)


        cmdStergere.ExecuteNonQuery()
        cmdStergere.Dispose()

        If NrAni >= 3 And NrAni < 5 Then

            Dim cmdAdaugareSpor As OleDbCommand = New OleDbCommand("INSERT INTO SporuriContract([DenumireSpor],[NrContract])" &
                                                                   "VALUES (?,?)", con)



            Try

                cmdAdaugareSpor.Parameters.Add(New OleDbParameter("DenumireSpor", CType("SPOR DE VECHIME 3-5 ANI", String)))
                cmdAdaugareSpor.Parameters.Add(New OleDbParameter("NrContract", CType(x, Integer)))

                cmdAdaugareSpor.ExecuteNonQuery()
                cmdAdaugareSpor.Dispose()

            Catch ex As Exception


            End Try


        ElseIf NrAni > 4 And NrAni < 10 Then

            Dim cmdAdaugareSpor As OleDbCommand = New OleDbCommand("INSERT INTO SporuriContract([DenumireSpor], [NrContract])" &
                                                                   "VALUES (?,?)", con)



            Try

                cmdAdaugareSpor.Parameters.Add(New OleDbParameter("DenumireSpor", CType("SPOR DE VECHIME 5-10 ANI", String)))
                cmdAdaugareSpor.Parameters.Add(New OleDbParameter("NrContract", CType(x, Integer)))

                cmdAdaugareSpor.ExecuteNonQuery()
                cmdAdaugareSpor.Dispose()

            Catch ex As Exception



            End Try



        ElseIf NrAni > 9 And NrAni < 15 Then

            Dim cmdAdaugareSpor As OleDbCommand = New OleDbCommand("INSERT INTO SporuriContract([DenumireSpor],[NrContract])" &
                                                                   "VALUES (?,?)", con)



            Try

                cmdAdaugareSpor.Parameters.Add(New OleDbParameter("DenumireSpor", CType("SPOR DE VECHIME 10-15 ANI", String)))
                cmdAdaugareSpor.Parameters.Add(New OleDbParameter("NrContract", CType(x, Integer)))

                cmdAdaugareSpor.ExecuteNonQuery()
                cmdAdaugareSpor.Dispose()

            Catch ex As Exception


            End Try



        ElseIf NrAni > 14 And NrAni < 20 Then

            Dim cmdAdaugareSpor As OleDbCommand = New OleDbCommand("INSERT INTO SporuriContract([DenumireSpor],[NrContract])" &
                                                                   "VALUES (?,?)", con)



            Try

                cmdAdaugareSpor.Parameters.Add(New OleDbParameter("DenumireSpor", CType("SPOR DE VECHIME 15-20 ANI", String)))
                cmdAdaugareSpor.Parameters.Add(New OleDbParameter("NrContract", CType(x, Integer)))

                cmdAdaugareSpor.ExecuteNonQuery()
                cmdAdaugareSpor.Dispose()

            Catch ex As Exception


            End Try


        ElseIf NrAni > 19 Then

            Dim cmdAdaugareSpor As OleDbCommand = New OleDbCommand("INSERT INTO SporuriContract([DenumireSpor],[NrContract])" &
                                                                   "VALUES (?,?)", con)



            Try

                cmdAdaugareSpor.Parameters.Add(New OleDbParameter("DenumireSpor", CType("SPOR DE VECHIME PESTE 20 ANI", String)))
                cmdAdaugareSpor.Parameters.Add(New OleDbParameter("NrContract", CType(x, Integer)))

                cmdAdaugareSpor.ExecuteNonQuery()
                cmdAdaugareSpor.Dispose()

            Catch ex As Exception


            End Try


        End If




        Dim cmdAfisareSporuri As OleDbDataAdapter = New OleDbDataAdapter("Select [DenumireSpor] " &
                                                                         "FROM SporuriContract " &
                                                                         "WHERE NrContract Like '" & x & "'", con)

        Dim dtAfisareSporuri As New DataTable

        cmdAfisareSporuri.Fill(dtAfisareSporuri)

        dgvSporuri.DataSource = dtAfisareSporuri

        con.Close()

    End Sub

    Private Sub btnAdaugareS_Click(sender As Object, e As EventArgs) Handles btnAdaugareS.Click

        con.Open()

        Dim cmdAdaugareSpor As OleDbCommand = New OleDbCommand("INSERT INTO SporuriContract([DenumireSpor],[NrContract])" &
                                                               "VALUES (?,?)", con)



        Dim cmdContract As OleDbDataAdapter = New OleDbDataAdapter("SELECT NrContract " &
                                                                   "FROM Contracte " &
                                                                   "WHERE Marca Like '" & Marca & "'", con)

        Dim dtContract As New DataTable

        Dim x As Integer

        cmdContract.Fill(dtContract)

        x = dtContract.Rows(0).Item(0)


        Try

            cmdAdaugareSpor.Parameters.Add(New OleDbParameter("DenumireSpor", CType(cmbSporuri.Text, String)))
            cmdAdaugareSpor.Parameters.Add(New OleDbParameter("NrContract", CType(x, Integer)))

            cmdAdaugareSpor.ExecuteNonQuery()
            cmdAdaugareSpor.Dispose()

        Catch ex As Exception

            MsgBox("DATE INCORECTE!", vbExclamation, "ATENȚIE")
            con.Close() : Exit Sub

        End Try


        Dim cmdAfisareSporuri As OleDbDataAdapter = New OleDbDataAdapter("SELECT [DenumireSpor] " &
                                                                         "FROM SporuriContract " &
                                                                         "WHERE NrContract Like '" & x & "'", con)

        Dim dtAfisareSporuri As New DataTable

        cmdAfisareSporuri.Fill(dtAfisareSporuri)

        dgvSporuri.DataSource = dtAfisareSporuri


        MsgBox("SPORUL DENUMIT " & cmbSporuri.Text & " A FOST ADĂUGATĂ CU SUCCES!", vbInformation, "SUCCES")

        con.Close()


    End Sub

    Private Sub btnStergereS_Click(sender As Object, e As EventArgs) Handles btnStergereS.Click

        Dim index As Integer

        Dim y As String

        Try

            index = dgvSporuri.CurrentRow.Index

        Catch ex As NullReferenceException

            MsgBox("NU EXISTĂ ÎNREGISTRĂRI ÎN BAZA DE DATE!", vbExclamation, "EROARE") : Exit Sub

        End Try

        y = dgvSporuri.Rows(index).Cells(0).Value


        dgvSporuri.Rows.RemoveAt(index)


        con.Open()

        Dim cmdStergereS As OleDbCommand = New OleDbCommand("DELETE FROM [SporuriContract] " &
                                                            "WHERE [DenumireSpor] Like '" & y & "'", con)


        Try

            cmdStergereS.ExecuteNonQuery()
            cmdStergereS.Dispose()

        Catch ex As Exception

            MsgBox(ex.Message)
            con.Close()

        End Try

        MsgBox("SPORUL DENUMIT " & y & " A FOST ȘTERS!", vbInformation, "SUCCES")



        Dim cmdContract As OleDbDataAdapter = New OleDbDataAdapter("SELECT NrContract " &
                                                                   "FROM Contracte " &
                                                                   "WHERE Marca Like '" & Marca & "'", con)

        Dim dtContract As New DataTable

        Dim x As Integer

        cmdContract.Fill(dtContract)

        x = dtContract.Rows(0).Item(0)

        Dim cmdAfisareSporuri As OleDbDataAdapter = New OleDbDataAdapter("SELECT [DenumireSpor] " &
                                                                         "FROM SporuriContract " &
                                                                         "WHERE NrContract Like '" & x & "'", con)

        Dim dtAfisareSporuri As New DataTable

        cmdAfisareSporuri.Fill(dtAfisareSporuri)

        dgvSporuri.DataSource = dtAfisareSporuri

        con.Close()

    End Sub

    Private Sub btnRevenire_Click(sender As Object, e As EventArgs) Handles btnRevenire.Click

        Me.Close()
        Meniu.Show()

    End Sub

End Class