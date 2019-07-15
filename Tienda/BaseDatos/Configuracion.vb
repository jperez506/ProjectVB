Imports MySql.Data.MySqlClient

Public Class Configuracion


    Private Shared _FECHASERVIDOR As Date
    Public Shared Property FECHASERVIDOR As Date
        Get
            Return _FECHASERVIDOR
        End Get
        Set(ByVal value As Date)
            _FECHASERVIDOR = value
        End Set
    End Property

    Public Shared Sub ObtenerFechaServidor()
        Try
            Acceso.AbrirConexion()
            Acceso.adaptador = New MySqlDataAdapter("SELECT NOW() AS CurrentDateTime", Acceso.Conexion)
            Acceso.ds = New DataSet
            Acceso.adaptador.Fill(Acceso.ds)

            If Acceso.ds.Tables(0).Rows.Count > 0 Then
                FECHASERVIDOR = Acceso.ds.Tables(0).Rows(0).Item(0)
            Else
                FECHASERVIDOR = Today.Date
            End If

            Acceso.Conexion.Close()

        Catch ex As Exception
            Console.WriteLine(Err.Description)
        End Try

    End Sub
End Class
