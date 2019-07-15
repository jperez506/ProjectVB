Imports BaseDatos

Public Class clienteForm

    Private Sub RecibirFoco(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscar.GotFocus
        Dim obj As TextBox = sender
        If obj.Text = "" Or obj.Text = "<Introduzca un nombre o telefono a buscar...>" Then
            obj.Text = ""
            obj.ForeColor = Color.Black
            obj.Font = New Font("Arial", 12.0, FontStyle.Regular)
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If txtID.Text = "0" Then
                If MessageBox.Show("¿Seguro que desea insertar este registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    Operaciones.SaveData("insert into clientes(codigo,nombre,telefono,direccion) values('" & txtCodigo.Text & "','" & txtNombre.Text & "','" & txtTelefono.Text & "','" & txtDireccion.Text & "')")

                    MessageBox.Show("Registro exitoso", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ConsultaDatos()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            If txtID.Text <> "0" Then
                If MessageBox.Show("¿Seguro que desea actualizar este registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    Operaciones.SaveData("update clientes set codigo='" & txtCodigo.Text & "', nombre='" & txtNombre.Text & "',telefono='" & txtTelefono.Text & "',direccion='" & txtDireccion.Text & "' where id='" & txtID.Text & "'")

                    MessageBox.Show("Actualizacion exitosa", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ConsultaDatos()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If MessageBox.Show("¿Seguro que deseas eliminar este registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            Operaciones.SaveData("delete from clientes where id='" & txtID.Text & "'")

            MessageBox.Show("Operacion realizada exitosamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ConsultaDatos()
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiaDatos()
        CrearID()
    End Sub

    Private Sub CrearID()
        Configuracion.ObtenerFechaServidor()
        Dim Fecha As String = Configuracion.FECHASERVIDOR.Date.Year
        Dim CantidadRegistros As Integer = 0

        Dim IDcliente As Integer = 0

        If Operaciones.Buscar("select coalesce(id,0) as id from clientes where codigo like'%" & Fecha & "'") = True Then
            CantidadRegistros = Acceso.ds.Tables(0).Rows.Count
        End If

        IDcliente = CantidadRegistros + 1
        txtCodigo.Text = "CLIENTE-" & IDcliente.ToString.PadLeft(4, "0") & "-" & Fecha

        If Operaciones.Buscar("select * from clientes where codigo='" & txtCodigo.Text & "'") = True Then
            MessageBox.Show("Error al crear el código del cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCodigo.Text = ""
        End If

    End Sub

    Private Sub LimpiaDatos()
        txtID.Text = "0"
        txtCodigo.Clear()
        txtNombre.Clear()
        txtTelefono.Clear()
        txtDireccion.Clear()
        txtNombre.Focus()

    End Sub

    Private Sub ConsultaDatos()
        If Operaciones.Buscar("select * from clientes where nombre like'%" & txtBuscar.Text & "%' or telefono like '%" & txtBuscar.Text & "%'") = True Then
            DataGridView1.DataSource = Acceso.ds.Tables(0)
        Else
            DataGridView1.DataSource = Nothing
        End If
    End Sub

    Private Sub clienteForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConsultaDatos()
        CrearID()
    End Sub

    Private Sub DataGridView1_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        If DataGridView1.RowCount > 0 Then
            txtCodigo.Text = DataGridView1.CurrentRow.Cells("codigo").Value.ToString
            txtID.Text = DataGridView1.CurrentRow.Cells("id").Value.ToString
            txtNombre.Text = DataGridView1.CurrentRow.Cells("nombre").Value.ToString
            txtTelefono.Text = DataGridView1.CurrentRow.Cells("telefono").Value.ToString
            txtDireccion.Text = DataGridView1.CurrentRow.Cells("direccion").Value.ToString
        Else
            LimpiaDatos()
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        ConsultaDatos()
    End Sub
End Class
