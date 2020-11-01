Imports System.Data.OleDb

Public Class ControlBD

    'CREARE CONEXIUNE BD
    Public DBCon As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" &
                                         "Data Source=Salariati.accdb;")

    'Pregatire comanda BD
    Private DBCmd As OleDbCommand

    'DATE BD

    Public DBDA As OleDbDataAdapter
    Public DBDT As DataTable


    'PARAMETRII DE TIP QUERY
    Public Parametrii As New List(Of OleDbParameter)

    'STATISTICI QUERY
    Public RecordCount As Integer
    Public Exception As String

    Public Sub ExecQuery(Query As String)

        'RESETARE STATISTICI QUERY
        RecordCount = 0
        Exception = ""

        Try

            'DESCHIDERE CONEXIUNE

            DBCon.Open()

            'CREARE COMANDA BD

            DBCmd = New OleDbCommand(Query, DBCon)

            'INCARCARE PARAMETRII IN COMANDA BD

            Parametrii.ForEach(Sub(p) DBCmd.Parameters.Add(p))

            'CURATARE LISTA PARAMETRII

            Parametrii.Clear()

            'EXECUTARE COMANDA SI INREGISTRARE IN TABEL BD

            DBDT = New DataTable
            DBDA = New OleDbDataAdapter(DBCmd)
            RecordCount = DBDA.Fill(DBDT)


        Catch ex As Exception

            Exception = ex.Message

        End Try

        'INCHIDERE CONEXIUNE BD

        If DBCon.State = ConnectionState.Open Then DBCon.Close()

    End Sub

    'INCLUDERE QUERY SI PARAMETRII DE COMANDA

    Public Sub AdaugareParametru(Nume As String, Value As Object)

        Dim ParametruNou As New OleDbParameter(Nume, Value)
        Parametrii.Add(ParametruNou)

    End Sub

End Class



