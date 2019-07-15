Imports BaseDatos

Public Class ProductosForm

    Private Sub RecibirFoco(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscar.GotFocus
        Dim obj As TextBox = sender
        If obj.Text = "" Or obj.Text = "<Introduzca un producto para buscar...>" Then
            obj.Text = ""
            obj.ForeColor = Color.Black
            obj.Font = New Font("Arial", 12.0, FontStyle.Regular)
        End If
    End Sub

    Private Sub CrearCodigo()
        Dim IdRegistro As Integer = 0

        If Operaciones.Buscar("select coalesce(max(id),0) as id from productos") = True Then
            IdRegistro = Acceso.ds.Tables(0).Rows(0).Item("id").ToString
        End If

        IdRegistro = IdRegistro + 1
        txtCodigo.Text = IdRegistro.ToString.PadLeft(5, "0")

        If Operaciones.Buscar("select * from productos where codigo='" & txtCodigo.Text & "'") = True Then
            MessageBox.Show("Error al crear el código del producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCodigo.Text = ""
            txtCodigo.Focus()
        End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If txtID.Text = "0" Then
                If MessageBox.Show("¿Seguro que desea insertar este registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    Operaciones.SaveData("insert into productos(codigo,descripcion,precio) values('" & txtCodigo.Text & "','" & txtDescripcion.Text & "','" & txtPrecio.Text & "')")

                    MessageBox.Show("Registro exitoso", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ConsultaDatos()
                    LimpiaDatos()
                    CrearCodigo()
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
                    Operaciones.SaveData("update productos set codigo='" & txtCodigo.Text & "',descripcion='" & txtDescripcion.Text & "',precio='" & txtPrecio.Text & "' where id='" & txtID.Text & "'")

                    MessageBox.Show("Actualizacion exitosa", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ConsultaDatos()
                    LimpiaDatos()
                    CrearCodigo()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If MessageBox.Show("¿Seguro que deseas eliminar este registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            Operaciones.SaveData("delete from productos where id='" & txtID.Text & "'")

            MessageBox.Show("Operacion realizada exitosamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ConsultaDatos()
            LimpiaDatos()
            CrearCodigo()
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiaDatos()
        CrearCodigo()
    End Sub

    Private Sub LimpiaDatos()
        txtID.Text = "0"
        txtCodigo.Clear()
        txtDescripcion.Clear()
        txtPrecio.Clear()
        txtCodigo.Focus()

    End Sub

    Private Sub ConsultaDatos()
        If Operaciones.Buscar("select * from productos where descripcion like'%" & txtBuscar.Text & "%'") = True Then
            DataGridView1.DataSource = Acceso.ds.Tables(0)
        Else
            DataGridView1.DataSource = Nothing
        End If
    End Sub

    Private Sub DataGridView1_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        If DataGridView1.RowCount > 0 Then
            txtID.Text = DataGridView1.CurrentRow.Cells("id").Value.ToString
            txtCodigo.Text = DataGridView1.CurrentRow.Cells("codigo").Value.ToString
            txtDescripcion.Text = DataGridView1.CurrentRow.Cells("descripcion").Value.ToString
            txtPrecio.Text = DataGridView1.CurrentRow.Cells("precio").Value
        Else
            LimpiaDatos()
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        ConsultaDatos()
    End Sub

    Private Sub ProductosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearCodigo()
    End Sub
End Class