Imports BaseDatos

Public Class ConsultaReporte
    Public Shared Sub FacturaCliente(ByVal IDFACTURA As String)
        If Operaciones.Buscar("SELECT clientes.nombre, clientes.telefono, clientes.direccion, ventas.fecha, ventas.id_factura, ventas.codigo_cliente, ventas.id_usuario, ventas_detalle.codigo, ventas_detalle.descripcion, ventas_detalle.precio, " & _
            " ventas_detalle.cantidad, ventas_detalle.descuento FROM ventas inner join ventas_detalle on ventas.id_factura=ventas_detalle.id_factura inner join clientes on ventas.codigo_cliente=clientes.codigo where ventas.id_factura='" & IDFACTURA & "'") Then

        End If
    End Sub

    Public Shared Sub ReporteEtiquetas(ByVal IDPRODUCTO As String, ByVal Copias As Integer)
        Dim Limite As String = "Select codigo,descripcion,precio from productos, impresion where codigo='" & IDPRODUCTO & "' limit " & Copias
        If IDPRODUCTO.Length > 1 Then
            If Operaciones.Buscar(Limite) Then
            End If
        Else
            If Operaciones.Buscar("select * from productos") Then
            End If
        End If

    End Sub


End Class