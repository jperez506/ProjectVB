Imports BaseDatos

Public Class MainForm

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        If MessageBox.Show("Seguro que desea abandonar el sistema?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            Me.Hide()
            LoginForm.Show()
        End If
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub RegistroDeClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeClientesToolStripMenuItem.Click
        clienteForm.Show()
    End Sub

    Private Sub RegistroDeUsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeUsuariosToolStripMenuItem.Click
        If (TSrol.Text = "Administrador") Then
            UsuarioForm.Show()
        Else
            MessageBox.Show("Acceso denegado usuario ingresado no es administrdor", "Sistema")
        End If

    End Sub

    Private Sub RegistroDeProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeProductosToolStripMenuItem.Click
        ProductosForm.Show()
    End Sub

    Private Sub RealizarVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RealizarVentaToolStripMenuItem.Click
        VentasForm.Show()
    End Sub

    Private Sub ReportesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportesToolStripMenuItem.Click
        GeneradorReportes.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Configuracion.ObtenerFechaServidor()

        lbFecha.Text = Configuracion.FECHASERVIDOR.Date
        lbHora.Text = Configuracion.FECHASERVIDOR.TimeOfDay.ToString

    End Sub

    Private Sub lbIDusuario_Click(sender As Object, e As EventArgs) Handles lbIDusuario.Click

    End Sub
End Class
