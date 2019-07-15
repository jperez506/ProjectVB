Imports System.Windows.Forms
Imports Microsoft.Reporting.WinForms
Imports BaseDatos

Public Class ReporteForm
    Public NombreReporte As String = "Reporting.FacturaCliente.rdlc"
    Public FormaReporte As String = "Normal"
    Public MiParametro As String = "FACTURA"
    Public ParametroFactura As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Populate()
    End Sub

    Public Sub Populate()
        Dim dt As New DataTable

        Try
            BaseDatos.Acceso.adaptador.Fill(dt)

            Dim rds As ReportDataSource = New ReportDataSource
            rds.Name = "dsDatos"
            rds.Value = dt

            ReportViewer1.Reset()
            ReportViewer1.LocalReport.ReportEmbeddedResource = NombreReporte
            ReportViewer1.LocalReport.EnableExternalImages = True

            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(rds)  'Fixed!'

            'Activar solo si está creado el parametro, de lo contrario no sale el reporte
            If ParametroFactura = True Then
                Dim myParam As New ReportParameter("ReportParameter1", MiParametro)
                ReportViewer1.LocalReport.SetParameters(myParam)
            End If

            Dim newPageSettings As New System.Drawing.Printing.PageSettings
            newPageSettings.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
            If FormaReporte = "Acostado" Then
                newPageSettings.Landscape = True
            End If
            ReportViewer1.SetPageSettings(newPageSettings)

            Me.ReportViewer1.RefreshReport()





        Catch ex As Exception
            Err.Description.ToString()
        End Try

    End Sub
End Class
