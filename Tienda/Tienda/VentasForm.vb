Imports BaseDatos

Public Class VentasForm
    Public _CODPRODUCTO As String = "0"
    Dim _DESCRIPCION As String
    Dim _PRECIO As Double
    Dim _CANTIDAD As Integer
    Dim _SUBTOTAL As Double

    Private Sub CrearFactura()
        Dim IdRegistro As Integer = 0

        If Operaciones.Buscar("select coalesce(max(id),0) as id from ventas") = True Then
            IdRegistro = Acceso.ds.Tables(0).Rows(0).Item("id").ToString
        End If

        IdRegistro = IdRegistro + 1
        lbCodigoFactura.Text = IdRegistro.ToString.PadLeft(8, "0")

    End Sub

    Private Sub txtCliente_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCliente.KeyUp
        DataGridView2.Visible = True
        DataGridView2.Height = Panel3.Height

        If Operaciones.Buscar("select CODIGO,NOMBRE,TELEFONO,DIRECCION from clientes where nombre like'%" & txtCliente.Text & "%'") = True Then
            DataGridView2.DataSource = Acceso.ds.Tables(0)
            DataGridView2.Columns(0).Visible = False
        Else
            DataGridView2.DataSource = Nothing
        End If
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        If DataGridView2.RowCount > 0 Then
            txtCliente.Text = DataGridView2.CurrentRow.Cells("Nombre").Value.ToString
            txtDireccion.Text = DataGridView2.CurrentRow.Cells("Direccion").Value.ToString
            txtTelefono.Text = DataGridView2.CurrentRow.Cells("Telefono").Value.ToString
            lbCodigoCliente.Text = DataGridView2.CurrentRow.Cells("codigo").Value.ToString
            DataGridView2.Visible = False
        End If
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            _CODPRODUCTO = txtCodigo.Text

            'Verificamos si existe el producto
            '-------------------------------------------------------------------
            If Operaciones.Buscar("select * from productos where codigo='" & _CODPRODUCTO & "'") = True Then
                Addproducto()
                e.Handled = True
                txtCodigo.Clear()
            End If
        End If
    End Sub

    Public Sub Addproducto()
        Operaciones.FECHA = Configuracion.FECHASERVIDOR

        'Buscamos el codigo del producto para asignarle los valores a las variables
        '--------------------------------------------------------------------------------------------------------
        If Operaciones.Buscar("select * from productos where codigo='" & _CODPRODUCTO & "'") = True Then
            Dim fila As DataRow
            For Each fila In Acceso.ds.Tables(0).Rows
                _DESCRIPCION = fila("descripcion")
                _PRECIO = fila("precio")
            Next
        End If

        'Si ya existe una factura abierta, se ejecuta esta parte del codigo
        '----------------------------------------------------------------------------------------------------
        If Operaciones.Buscar("select * from ventas where estado='ABIERTA'") = True Then
            lbCodigoFactura.Text = Acceso.ds.Tables(0).Rows(0).Item("ID_FACTURA").ToString

            If Operaciones.Buscar("select * from ventas_detalle where codigo='" & _CODPRODUCTO & "' and id_factura='" & lbCodigoFactura.Text & "'") = True Then
                'si ya existe el producto en la tabla, actualizamos la cantidad
                '-----------------------------------------------------------------------------------------------------
                Operaciones.SaveData("update ventas_detalle set cantidad=cantidad+1 where codigo='" & _CODPRODUCTO & "' and id_factura='" & lbCodigoFactura.Text & "'")
            Else
                ' 'si no existe el producto en la tabla lo insertamos
                '------------------------------------------------------------------------------------------------
                Operaciones.SaveData("insert into ventas_detalle(id_factura,codigo,descripcion,precio,cantidad,descuento) " & _
                                 "values('" & lbCodigoFactura.Text & "','" & _CODPRODUCTO & "','" & _DESCRIPCION & "','" & _PRECIO & "',1,0)")
            End If
        Else
            'Creamos la factura si no existe
            '-----------------------------------------------------------------------------------------------
            CrearFactura()
            Operaciones.SaveData("insert into ventas(fecha,id_factura,codigo_cliente,estado,id_usuario) " & _
                                   "values (?FECHA,'" & lbCodigoFactura.Text & "','" & lbCodigoCliente.Text & "','ABIERTA','" & MainForm.lbIDusuario.Text & "')")

            Operaciones.SaveData("insert into ventas_detalle(id_factura,codigo,descripcion,precio,cantidad,descuento) " & _
                             "values('" & lbCodigoFactura.Text & "','" & _CODPRODUCTO & "','" & _DESCRIPCION & "','" & _PRECIO & "',1,0)")

        End If


        'Llenamos el Datagridview con la tabla venta_detalles
        '------------------------------------------------------------------------------
        If Operaciones.Buscar("select CODIGO,DESCRIPCION,PRECIO,CANTIDAD,DESCUENTO,(CANTIDAD*PRECIO-DESCUENTO) as SUBTOTAL from ventas_detalle where id_factura='" & lbCodigoFactura.Text & "'") = True Then
            DataGridView1.AutoGenerateColumns = False
            DataGridView1.DataSource = Acceso.ds.Tables(0)
        Else
            DataGridView1.DataSource = Nothing
        End If

        LlenaFacturaAbierta()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If MessageBox.Show("¿Seguro que desea cancelar esta venta?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            Operaciones.SaveData("update ventas set estado='CANCELADA' where estado='ABIERTA'")
            LimpiarCampos()
            LlenaFacturaAbierta()
        End If
    End Sub

    Private Sub LimpiarCampos()
        For Each c As Control In Me.Controls
            If c.GetType Is GetType(TextBox) Then
                c.Text = ""
            End If
        Next
        For Each c As Control In Me.Panel2.Controls
            If c.GetType Is GetType(TextBox) Then
                c.Text = ""
            End If
        Next

        txtTotal.Text = "0"
        lbCodigoCliente.Text = "0"

        DataGridView1.DataSource = Nothing
    End Sub

    Private Sub VentasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Configuracion.ObtenerFechaServidor()
        LlenaFacturaAbierta()
    End Sub

    Private Sub LlenaFacturaAbierta()

        'Llenamos el Datagridview con la tabla venta_detalles
        '------------------------------------------------------------------------------
        If Operaciones.Buscar("select VENTAS.CODIGO_CLIENTE,VENTAS.ID_FACTURA,CODIGO,DESCRIPCION,PRECIO,CANTIDAD,DESCUENTO,(CANTIDAD*PRECIO-DESCUENTO) as SUBTOTAL from ventas_detalle right join ventas on ventas_detalle.id_factura=ventas.id_factura where ventas.estado='ABIERTA'") = True Then
            DataGridView1.AutoGenerateColumns = False
            DataGridView1.Columns("PrecioP").DefaultCellStyle.Format = "N2"
            DataGridView1.Columns("SubTotalP").DefaultCellStyle.Format = "N2"
            DataGridView1.Columns("DescuentoP").DefaultCellStyle.Format = "N2"

            DataGridView1.DataSource = Acceso.ds.Tables(0)

            Dim fila As DataRow
            For Each fila In Acceso.ds.Tables(0).Rows
                lbCodigoCliente.Text = fila("codigo_cliente")
                lbCodigoFactura.Text = fila("id_factura")
            Next

        Else
            DataGridView1.DataSource = Nothing
        End If

        'Buscamos el cliente con factura abierta
        '------------------------------------------------------------------------------
        If Operaciones.Buscar("select * from clientes where codigo='" & lbCodigoCliente.Text & "'") Then
            Dim fila As DataRow
            For Each fila In Acceso.ds.Tables(0).Rows
                txtCliente.Text = fila("nombre")
                txtDireccion.Text = fila("direccion")
                txtTelefono.Text = fila("telefono")
            Next
        End If

        txtTotal.Text = "0"
        txtDescuento.Text = "0"

        If Operaciones.Buscar("select * from ventas_detalle where id_factura='" & lbCodigoFactura.Text & "'") = True Then
            Dim fila As DataRow
            For Each fila In Acceso.ds.Tables(0).Rows
                txtDescuento.Text = CDbl(txtDescuento.Text) + fila("descuento")
                txtTotal.Text = CDbl(txtTotal.Text) + (fila("precio") * fila("cantidad") - fila("descuento"))
            Next
            txtDescuento.Text = Format(txtDescuento.Text, "standard")
            txtTotal.Text = Format(txtTotal.Text, "standard")
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'Remover productos de la ventas
        '----------------------------------------------------------------------------------------
        If DataGridView1.CurrentCell.ColumnIndex = 0 Then
            Operaciones.SaveData("delete from ventas_detalle where codigo='" & DataGridView1.CurrentRow.Cells("CodigoP").Value & "'")
            LlenaFacturaAbierta()
        End If
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        If DataGridView1.CurrentCell.ColumnIndex = 4 Then
            Operaciones.SaveData("update ventas_detalle set cantidad='" & DataGridView1.CurrentRow.Cells("CantidadP").Value & "' where codigo='" & DataGridView1.CurrentRow.Cells("CodigoP").Value & "'")
        End If

        If DataGridView1.CurrentCell.ColumnIndex = 5 Then
            Operaciones.SaveData("update ventas_detalle set descuento='" & DataGridView1.CurrentRow.Cells("DescuentoP").Value & "' where codigo='" & DataGridView1.CurrentRow.Cells("CodigoP").Value & "'")
        End If

        LlenaFacturaAbierta()
    End Sub

    Private Sub DataGridView1_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellLeave
        DataGridView1.EndEdit()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub btnCompletar_Click(sender As Object, e As EventArgs) Handles btnCompletar.Click
        If MessageBox.Show("Seguro que desea completar esta venta?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            Operaciones.SaveData("insert into pagos(id_factura, subtotal,descuento,total,fecha) " & _
                                 "values('" & lbCodigoFactura.Text & "','" & CDbl(txtTotal.Text) + CDbl(txtDescuento.Text) & "','" & CDbl(txtDescuento.Text) & "','" & CDbl(txtTotal.Text) & "',?FECHA)")

            Operaciones.SaveData("update ventas set estado='COMPLETADA' where id_factura='" & lbCodigoFactura.Text & "'")

            Dim MiForm As New Reporting.ReporteForm
            Reporting.ConsultaReporte.FacturaCliente(lbCodigoFactura.Text)
            MiForm.NombreReporte = "Reporting.FacturaCliente.rdlc"
            'MiForm.MiParametro = "CONDUCE"
            'MiForm.FormaReporte = "Acostado"
            MiForm.Show()



        End If
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        BuscaProductosForm.Show()
    End Sub
End Class