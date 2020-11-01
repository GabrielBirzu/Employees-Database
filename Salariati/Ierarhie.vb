Imports System.Data.OleDb

Public Class Ierarhie

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

    Public Sub Ascundere()

        Dim Index As Integer

        Dim cm1 As CurrencyManager = CType(BindingContext(dgvSalariati.DataSource), CurrencyManager)

        Index = 0

        Do While Index < dgvSalariati.Rows.Count

            If dgvSalariati.Rows(Index).Cells(0).Value = Marca Then

                cm1.SuspendBinding()

                dgvSalariati.Rows(Index).Visible = False

                cm1.ResumeBinding()

            End If

            Index += 1

        Loop

        Try

            dgvSalariati.CurrentCell = dgvSalariati.Rows(0).Cells(0)

        Catch ex As Exception

            dgvSalariati.CurrentCell = dgvSalariati.Rows(1).Cells(0)

        End Try

    End Sub

    Private Sub Form4_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        con.Open()

        Majuscule(Me)

        txtSalariat.Text = NumeSalariat & " " & PrenumeSalariat

        Dim dt1 As New DataTable

        Dim cmdCautare As OleDbDataAdapter = New OleDbDataAdapter("SELECT Marca, Nume, Prenume, Vechime, Profesie, DenumireFunctie, DenumireDepartament " &
                                                                          "FROM Departamente INNER JOIN (Salariati INNER JOIN Functii ON Salariati.Functie=Functii.CodFunctie) ON Salariati.Departament=Departamente.CodDepartament " &
                                                                          "ORDER BY Marca ASC ", con)

        cmdCautare.Fill(dt1)

        dgvSalariati.DataSource = dt1


        Dim dt2 As New DataTable

        Dim cmdCautareSuperior As OleDbDataAdapter = New OleDbDataAdapter("SELECT s2.Marca, s2.Nume, s2.Prenume, s2.Vechime, s2.Profesie, DenumireFunctie, DenumireDepartament " &
                                                                          "FROM Salariati s2, Departamente INNER JOIN (Salariati INNER JOIN Functii ON Salariati.Functie=Functii.CodFunctie) ON Salariati.Departament=Departamente.CodDepartament " &
                                                                          "WHERE s2.Marca Like Salariati.MarcaSalariatSef AND Salariati.Marca Like '" & Marca & "'" &
                                                                          "ORDER BY s2.Marca ASC ", con)

        cmdCautareSuperior.Fill(dt2)

        dgvSuperiori.DataSource = dt2


        Dim dt3 As New DataTable

        Dim cmdCautareSubordonat As OleDbDataAdapter = New OleDbDataAdapter("SELECT Marca, Nume, Prenume, Vechime, Profesie, DenumireFunctie, DenumireDepartament " &
                                                                            "FROM Departamente INNER JOIN (Salariati INNER JOIN Functii ON Salariati.Functie=Functii.CodFunctie) ON Salariati.Departament=Departamente.CodDepartament " &
                                                                            "WHERE MarcaSalariatSef Like '" & Marca & "'" &
                                                                            "ORDER BY Marca ASC ", con)

        cmdCautareSubordonat.Fill(dt3)

        dgvSubordonati.DataSource = dt3

        Ascundere()

        con.Close()

    End Sub

    Private Sub btnAdaugareSuperiori_Click(sender As Object, e As EventArgs) Handles btnAdaugareSuperiori.Click

        con.Open()


        Dim index As Integer

        Dim index2 As Integer

        Dim x As String

        Try

            index = dgvSalariati.CurrentRow.Index

        Catch ex As Exception

            MsgBox("SELECTAȚI UN SALARIAT!", vbExclamation, "ATENȚIE")

        End Try

        index2 = 0

        Do While index2 < dgvSubordonati.Rows.Count

            If dgvSalariati.Rows(index).Cells(0).Value = dgvSubordonati.Rows(index2).Cells(0).Value Then

                MsgBox("SALARIATUL SE AFLĂ ÎN TABELUL SUBORDONAȚI!", vbExclamation, "EROARE")
                con.Close() : Exit Sub

            End If

            index2 += 1

        Loop


        Try

            index = dgvSalariati.CurrentRow.Index

        Catch ex As NullReferenceException

            con.Close() : Exit Sub

        End Try

        x = dgvSalariati.Rows(index).Cells(0).Value

        Dim cmdAdaugareSuperior As OleDbCommand = New OleDbCommand("UPDATE Salariati SET [MarcaSalariatSef] = '" & x & "' WHERE Marca Like '" & Marca & "'", con)


        cmdAdaugareSuperior.ExecuteNonQuery()
        cmdAdaugareSuperior.Dispose()


        Dim dt2 As New DataTable

        Dim cmdCautareSuperior As OleDbDataAdapter = New OleDbDataAdapter("SELECT s2.Marca, s2.Nume, s2.Prenume, s2.Vechime, s2.Profesie, DenumireFunctie, DenumireDepartament " &
                                                                          "FROM Salariati s2, Departamente INNER JOIN (Salariati INNER JOIN Functii ON Salariati.Functie=Functii.CodFunctie) ON Salariati.Departament=Departamente.CodDepartament " &
                                                                          "WHERE s2.Marca Like Salariati.MarcaSalariatSef AND Salariati.Marca Like '" & Marca & "'" &
                                                                          "ORDER BY s2.Marca ASC ", con)

        cmdCautareSuperior.Fill(dt2)

        dgvSuperiori.DataSource = dt2

        Ascundere()

        con.Close()

    End Sub

    Private Sub btnEliminareSuperiori_Click(sender As Object, e As EventArgs) Handles btnEliminareSuperiori.Click

        con.Open()

        Dim cmdStergereSuperior As OleDbCommand = New OleDbCommand("UPDATE Salariati SET [MarcaSalariatSef] = Null WHERE Marca Like '" & Marca & "'", con)


        cmdStergereSuperior.ExecuteNonQuery()
        cmdStergereSuperior.Dispose()


        Dim dt2 As New DataTable

        Dim cmdCautareSuperior As OleDbDataAdapter = New OleDbDataAdapter("SELECT s2.Marca, s2.Nume, s2.Prenume, s2.Vechime, s2.Profesie, DenumireFunctie, DenumireDepartament " &
                                                                          "FROM Salariati s2, Departamente INNER JOIN (Salariati INNER JOIN Functii ON Salariati.Functie=Functii.CodFunctie) ON Salariati.Departament=Departamente.CodDepartament " &
                                                                          "WHERE s2.Marca Like Salariati.MarcaSalariatSef AND Salariati.Marca Like '" & Marca & "'" &
                                                                          "ORDER BY s2.Marca ASC ", con)

        cmdCautareSuperior.Fill(dt2)

        dgvSuperiori.DataSource = dt2

        Ascundere()

        con.Close()

    End Sub

    Private Sub btnAdaugareSubordonati_Click(sender As Object, e As EventArgs) Handles btnAdaugareSubordonati.Click

        con.Open()

        Dim index As Integer

        Dim x As String

        Try

            index = dgvSalariati.CurrentRow.Index

        Catch ex As Exception

            MsgBox("SELECTAȚI UN SALARIAT!", vbExclamation, "ATENȚIE")

        End Try


        If dgvSalariati.Rows(index).Cells(0).Value = dgvSuperiori.Rows(0).Cells(0).Value Then

            MsgBox("SALARIATUL SE AFLĂ ÎN TABELUL SUPERIORI!", vbExclamation, "EROARE")
            con.Close() : Exit Sub

        End If


        Try

            index = dgvSalariati.CurrentRow.Index

        Catch ex As NullReferenceException

            Exit Sub

        End Try

        x = dgvSalariati.Rows(index).Cells(0).Value

        Dim cmdAdaugareSubordonat As OleDbCommand = New OleDbCommand("UPDATE Salariati SET [MarcaSalariatSef] = '" & Marca & "' WHERE Marca Like '" & x & "'", con)


        cmdAdaugareSubordonat.ExecuteNonQuery()
        cmdAdaugareSubordonat.Dispose()


        Dim dt3 As New DataTable

        Dim cmdCautareSubordonat As OleDbDataAdapter = New OleDbDataAdapter("SELECT Marca, Nume, Prenume, Vechime, Profesie, DenumireFunctie, DenumireDepartament " &
                                                                            "FROM Departamente INNER JOIN (Salariati INNER JOIN Functii ON Salariati.Functie=Functii.CodFunctie) ON Salariati.Departament=Departamente.CodDepartament " &
                                                                            "WHERE MarcaSalariatSef Like '" & Marca & "'" &
                                                                            "ORDER BY Marca ASC ", con)

        cmdCautareSubordonat.Fill(dt3)

        dgvSubordonati.DataSource = dt3

        Ascundere()

        con.Close()

    End Sub

    Private Sub btnEliminareSubordonati_Click(sender As Object, e As EventArgs) Handles btnEliminareSubordonati.Click

        Dim index As Integer

        Dim x As String

        Try

            index = dgvSubordonati.CurrentRow.Index

        Catch ex As NullReferenceException

            Exit Sub

        End Try

        x = dgvSubordonati.Rows(index).Cells(0).Value

        con.Open()

        Ascundere()

        Dim cmdStergereSuperior As OleDbCommand = New OleDbCommand("UPDATE Salariati SET [MarcaSalariatSef] = Null WHERE Marca Like '" & x & "'", con)


        cmdStergereSuperior.ExecuteNonQuery()
        cmdStergereSuperior.Dispose()


        Dim dt2 As New DataTable

        Dim cmdCautareSubordonat As OleDbDataAdapter = New OleDbDataAdapter("SELECT Marca, Nume, Prenume, Vechime, Profesie, DenumireFunctie, DenumireDepartament " &
                                                                            "FROM Departamente INNER JOIN (Salariati INNER JOIN Functii ON Salariati.Functie=Functii.CodFunctie) ON Salariati.Departament=Departamente.CodDepartament " &
                                                                            "WHERE MarcaSalariatSef Like '" & Marca & "'" &
                                                                            "ORDER BY Marca ASC ", con)

        cmdCautareSubordonat.Fill(dt2)

        dgvSubordonati.DataSource = dt2

        con.Close()

    End Sub

    Private Sub btnRevenire_Click(sender As Object, e As EventArgs) Handles btnRevenire.Click

        Me.Close()

        Meniu.Show()

    End Sub

End Class