Imports MySql.Data.MySqlClient

Module DBConnection
    Public connString As String = "server=localhost;userid=root;password=root;database=payment"
    Public conn As New MySqlConnection(connString)
    Public cmd As MySqlCommand
    Public adapter As MySqlDataAdapter
    Public dt As New DataTable
    Public reader As MySqlDataReader
    Public ds As New DataSet

    Public Sub conn_str()
        Try
            Console.WriteLine("Connecting...")
            conn.Open()
            Console.WriteLine("Connection Successful")
            conn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub
End Module
