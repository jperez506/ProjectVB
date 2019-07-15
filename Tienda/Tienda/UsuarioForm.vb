Imports BaseDatos

Public Class UsuarioForm

    Private Sub RecibirFoco(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscar.GotFocus
        Dim obj As TextBox = sender
        If obj.Text = "" Or obj.Text = "<Introduzca un nombre o usuario a buscar...>" Then
            obj.Text = ""
            obj.ForeColor = Color.Black
            obj.Font = New Font("Arial", 12.0, FontStyle.Regular)
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If txtID.Text = "0" Then
                If MessageBox.Show("¿Seguro que desea insertar este registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    Operaciones.SaveData("insert into usuarios(nombre,username,clave, rol) values('" & txtNombre.Text & "','" & txtUsuario.Text & "','" & txtPassword.Text & "', '" & cbrol.Text & "')")

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
                    Operaciones.SaveData("update usuarios set nombre='" & txtNombre.Text & "',username='" & txtUsuario.Text & "',clave='" & txtPassword.Text & "', rol='" & cbrol.Text & "'  where id='" & txtID.Text & "'")

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
            Operaciones.SaveData("delete from usuarios where id='" & txtID.Text & "'")

            MessageBox.Show("Operacion realizada exitosamente", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ConsultaDatos()
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiaDatos()
    End Sub

    Private Sub LimpiaDatos()
        txtID.Text = "0"
        txtNombre.Clear()
        txtPassword.Clear()
        txtUsuario.Clear()
        txtNombre.Focus()

    End Sub

    Private Sub ConsultaDatos()
        If Operaciones.Buscar("select * from usuarios where nombre like'%" & txtBuscar.Text & "%' or username like '%" & txtBuscar.Text & "%'") = True Then
            DataGridView1.DataSource = Acceso.ds.Tables(0)
        Else
            DataGridView1.DataSource = Nothing
        End If
    End Sub

    Private Sub DataGridView1_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        If DataGridView1.RowCount > 0 Then
            txtID.Text = DataGridView1.CurrentRow.Cells("id").Value.ToString
            txtNombre.Text = DataGridView1.CurrentRow.Cells("nombre").Value.ToString
            txtUsuario.Text = DataGridView1.CurrentRow.Cells("username").Value.ToString
            txtPassword.Text = DataGridView1.CurrentRow.Cells("clave").Value.ToString
        Else
            LimpiaDatos()
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        ConsultaDatos()
    End Sub

    Private Sub UsuarioForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class