Imports BaseDatos

Public Class BuscaProductosForm

    Private Sub RecibirFoco(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscar.GotFocus
        Dim obj As TextBox = sender
        If obj.Text = "" Or obj.Text = "<Escriba aquí para buscar...>" Then
            obj.Text = ""
            obj.ForeColor = Color.Black
            obj.Font = New Font("Arial", 12.0, FontStyle.Regular)

        End If

    End Sub

    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Seleccion()
            e.Handled = True
        End If
    End Sub

    Private Sub LlenarDatos()
        If Operaciones.Buscar("select * from productos where descripcion like'%" & txtBuscar.Text & "%'") = True Then
            DataGridView1.DataSource = Acceso.ds.Tables(0)
        Else
            DataGridView1.DataSource = Nothing
        End If
    End Sub
    Private Sub BuscaProductosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        Seleccion()
    End Sub

    Private Sub Seleccion()
        VentasForm._CODPRODUCTO = DataGridView1.CurrentRow.Cells("Codigo").Value.ToString
        VentasForm.Addproducto()
        Close()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        LlenarDatos()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.RowCount > 0 Then
            txtBuscar.Text = DataGridView1.CurrentRow.Cells("descripcion").Value.ToString
            txtBuscar.Focus()
            txtBuscar.Text = Replace(txtBuscar.Text, "ñ", "n")
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class