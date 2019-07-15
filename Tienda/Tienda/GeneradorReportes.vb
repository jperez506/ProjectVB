Imports BaseDatos

Public Class GeneradorReportes

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If RdoEtiquetas.Checked = True Then
            If txtCodigo.Text.Length = 0 Then
                Dim MiForm As New Reporting.ReporteForm
                Reporting.ConsultaReporte.ReporteEtiquetas(txtCodigo.Text, txtCopias.Text)
                MiForm.NombreReporte = "Reporting.ReporteEtiquetas.rdlc"
                MiForm.Show()
            Else
                Dim MiForm As New Reporting.ReporteForm
                Reporting.ConsultaReporte.ReporteEtiquetas(txtCodigo.Text, txtCopias.Text)
                MiForm.NombreReporte = "Reporting.ReporteEtiquetas.rdlc"
                MiForm.Show()
            End If

        End If

        If RdoFactura.Checked = True Then
            Dim MiForm As New Reporting.ReporteForm
            Reporting.ConsultaReporte.FacturaCliente(txtCodigo.Text)
            MiForm.NombreReporte = "Reporting.FacturaCliente.rdlc"
            'MiForm.MiParametro = "CONDUCE"
            'MiForm.FormaReporte = "Acostado"
            MiForm.Show()
        End If

        If RdoNumeros.Checked = True Then
            'Para generar los numeros en la tabla impresion, que se 
            'va a utilizar en la cantidad de impresiones de los codigos de barra
            '===============================================================================================
            If Operaciones.Buscar("select coalesce(max(id),0) as id from impresion") = True Then
                Dim NumeroMaximo As Integer = 0

                Dim fila As DataRow
                For Each fila In Acceso.ds.Tables(0).Rows
                    NumeroMaximo = fila("id")
                Next
                NumeroMaximo += 1

                For i As Integer = NumeroMaximo To 1000
                    Operaciones.SaveData("insert into impresion(numero) values('" & i & "')")
                Next

            End If
        End If

    End Sub

    Private Sub GeneradorReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class