Imports MySql.Data.MySqlClient

Public Class Acceso
    Public Shared Conexion As MySql.Data.MySqlClient.MySqlConnection
    Public Shared comando As MySql.Data.MySqlClient.MySqlCommand
    Public Shared adaptador As MySql.Data.MySqlClient.MySqlDataAdapter

    Public Shared ds As DataSet

    Public Shared Sub AbrirConexion()
        Try
            Conexion = New MySqlConnection("Data Source=localhost;Database=tienda;User Id=root;Password=Temp2019")
        Catch ex As Exception
            Err.Description.ToString()
        End Try
    End Sub
End Class
