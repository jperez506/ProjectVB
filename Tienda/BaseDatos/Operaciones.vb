Imports MySql.Data.MySqlClient

Public Class Operaciones

    Private Shared _FECHA As Date

    Public Shared Property FECHA As Date
        Get
            Return _FECHA
        End Get
        Set(value As Date)
            _FECHA = value
        End Set
    End Property

    Public Shared Function Buscar(ByVal cadena As String) As Boolean
        Try
            Acceso.AbrirConexion()
            Configuracion.ObtenerFechaServidor()

            Acceso.comando = New MySqlCommand(cadena, Acceso.Conexion)
            Acceso.comando.Parameters.AddWithValue("?FECHA", MySqlDbType.Date).Value = FECHA
            Acceso.adaptador = New MySqlDataAdapter(Acceso.comando)

            Acceso.ds = New DataSet
            Acceso.adaptador.Fill(Acceso.ds)

            If Acceso.ds.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

            Acceso.Conexion.Close()
        Catch ex As Exception
            Console.WriteLine(Err.Description)
            Return False
        End Try

    End Function

    Public Shared Sub SaveData(ByVal Cadena As String)
        Try

            Configuracion.ObtenerFechaServidor()

            Acceso.AbrirConexion()
            Acceso.Conexion.Open()
            Acceso.comando = New MySql.Data.MySqlClient.MySqlCommand(Cadena, Acceso.Conexion)
            Acceso.comando.Parameters.Add("?FECHA", MySqlDbType.Date).Value = FECHA
            Acceso.comando.ExecuteNonQuery()

            Acceso.Conexion.Close()
        Catch ex As Exception
            Console.WriteLine(Err.Description)
        End Try
    End Sub
End Class
