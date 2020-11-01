Imports System.Data.OleDb
Imports System.Net.Mail

Public Class Autentificare

    Public nr As Integer = 0

    Private con As New OleDbConnection("Provider= Microsoft.ACE.OLEDB.12.0;Data Source=Salariati.accdb")

    Private Sub txtUser_GotFocus(sender As Object, e As EventArgs) Handles txtUser.GotFocus

        txtUser.Text = ""
        txtUser.ForeColor = Color.Black
        txtUser.CharacterCasing = 1

    End Sub

    Private Sub txtParola_GotFocus(sender As Object, e As EventArgs) Handles txtParola.GotFocus

        txtParola.Text = ""
        txtParola.ForeColor = Color.Black
        txtParola.PasswordChar = "*"
        txtParola.CharacterCasing = 1

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnLogare.Click


        con.Open()

        Dim cmdutilizator As OleDbCommand = New OleDbCommand("SELECT * " &
                                                             "FROM Salariati INNER JOIN Functii ON Salariati.Functie = Functii.CodFunctie " &
                                                             "WHERE Nume & ' ' & Prenume = '" & txtUser.Text & "'" &
                                                             "AND RIGHT(CNP,6) & LEFT(Nume,1) = '" & txtParola.Text & "'" &
                                                             "AND DenumireFunctie LIKE '%HR%'", con)

        Dim drutilizator As OleDbDataReader = cmdutilizator.ExecuteReader

        If (drutilizator.Read() = True) Then

            Me.Hide()

            Meniu.Show()

            Meniu.Nume = txtUser.Text

            txtUser.Text = "introduceti numele"
            txtUser.ForeColor = Color.LightGray

            txtParola.Text = "introduceti parola"
            txtParola.ForeColor = Color.LightGray

            txtParola.PasswordChar = ""

            con.Close()

        Else

            nr += 1

            lblAvertizare.Visible = True

            If nr = 3 Then

                Dim raspuns As Integer = MsgBox("DORIȚI SĂ VĂ RECUPERAȚI PAROLA?", vbYesNo, "DATE INCORECTE")

                nr = 0

                If raspuns = vbYes Then

                    Dim mesaj As String = InputBox("Introduceți adresa de email la care se va trimite parola:", "RECUPERARE PAROLĂ")

                    Dim cmdEmail As OleDbCommand = New OleDbCommand("SELECT * " &
                                                                    "FROM Salariati " &
                                                                    "WHERE Email Like '" & mesaj & "'" &
                                                                    "AND Functie LIKE 103 OR Functie LIKE 104", con)

                    Dim drEmail As OleDbDataReader = cmdEmail.ExecuteReader


                    Dim cmdParola As OleDbDataAdapter = New OleDbDataAdapter("SELECT Nume, Prenume, RIGHT(CNP,6), LEFT(Nume,1)" &
                                                                             "FROM Salariati " &
                                                                             "WHERE Email Like '" & mesaj & "'", con)

                    Dim dtParola As New DataTable

                    cmdParola.Fill(dtParola)

                    If mesaj <> "" And drEmail.Read() = True Then

                        Try
                            Dim SmtpServer As New SmtpClient()
                            Dim mail As New MailMessage()
                            SmtpServer.UseDefaultCredentials = False
                            SmtpServer.Credentials = New Net.NetworkCredential("contactdepartament@gmail.com", "jesus1234jesus1234")
                            SmtpServer.Port = 587
                            SmtpServer.EnableSsl = True
                            SmtpServer.Host = "smtp.gmail.com"
                            mail = New MailMessage()
                            mail.From = New MailAddress("contactdepartament@gmail.com")
                            mail.To.Add(mesaj)
                            mail.Subject = "Recuperare parolă"
                            mail.Body = "Bună ziua, " & dtParola.Rows(0).Item(0) & " " & dtParola.Rows(0).Item(1) & "!" & " Parola dumneavoastră este: " _
                            & dtParola.Rows(0).Item(2) & dtParola.Rows(0).Item(3)
                            SmtpServer.Send(mail)
                            MsgBox("Email-ul a fost trimis cu succes!", vbInformation, "SUCCES")

                        Catch ex As Exception

                            MsgBox(ex.ToString)

                        End Try

                    ElseIf mesaj = "" Then

                        MsgBox("Nu a fost introdus email-ul!")

                    Else

                        MsgBox("Email-ul introdus nu există în baza de date!")

                    End If

                End If

            End If

        End If

        con.Close()

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnIeșire.Click

        Me.Close()

    End Sub

End Class
