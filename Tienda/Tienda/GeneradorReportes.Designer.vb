<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GeneradorReportes
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.RdoEtiquetas = New System.Windows.Forms.RadioButton()
        Me.txtCopias = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RdoNumeros = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RdoFactura = New System.Windows.Forms.RadioButton()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(439, 61)
        Me.Panel1.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label5.Location = New System.Drawing.Point(11, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(258, 25)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Generador de Reportes"
        '
        'RdoEtiquetas
        '
        Me.RdoEtiquetas.AutoSize = True
        Me.RdoEtiquetas.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdoEtiquetas.Location = New System.Drawing.Point(12, 90)
        Me.RdoEtiquetas.Name = "RdoEtiquetas"
        Me.RdoEtiquetas.Size = New System.Drawing.Size(140, 19)
        Me.RdoEtiquetas.TabIndex = 9
        Me.RdoEtiquetas.TabStop = True
        Me.RdoEtiquetas.Text = "Reporte de etiquetas"
        Me.RdoEtiquetas.UseVisualStyleBackColor = True
        '
        'txtCopias
        '
        Me.txtCopias.Location = New System.Drawing.Point(158, 202)
        Me.txtCopias.MaxLength = 3
        Me.txtCopias.Name = "txtCopias"
        Me.txtCopias.Size = New System.Drawing.Size(48, 20)
        Me.txtCopias.TabIndex = 17
        Me.txtCopias.Text = "1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(160, 183)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Copias"
        '
        'RdoNumeros
        '
        Me.RdoNumeros.AutoSize = True
        Me.RdoNumeros.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdoNumeros.Location = New System.Drawing.Point(278, 90)
        Me.RdoNumeros.Name = "RdoNumeros"
        Me.RdoNumeros.Size = New System.Drawing.Size(123, 19)
        Me.RdoNumeros.TabIndex = 15
        Me.RdoNumeros.TabStop = True
        Me.RdoNumeros.Text = "Generar numeros"
        Me.RdoNumeros.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 183)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Escriba el Código debajo:"
        '
        'RdoFactura
        '
        Me.RdoFactura.AutoSize = True
        Me.RdoFactura.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdoFactura.Location = New System.Drawing.Point(12, 127)
        Me.RdoFactura.Name = "RdoFactura"
        Me.RdoFactura.Size = New System.Drawing.Size(126, 19)
        Me.RdoFactura.TabIndex = 13
        Me.RdoFactura.TabStop = True
        Me.RdoFactura.Text = "Reporte de factura"
        Me.RdoFactura.UseVisualStyleBackColor = True
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(17, 202)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(135, 20)
        Me.txtCodigo.TabIndex = 12
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(332, 202)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(92, 23)
        Me.btnImprimir.TabIndex = 11
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'GeneradorReportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(439, 233)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.RdoEtiquetas)
        Me.Controls.Add(Me.txtCopias)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.RdoNumeros)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RdoFactura)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.btnImprimir)
        Me.Name = "GeneradorReportes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents RdoEtiquetas As System.Windows.Forms.RadioButton
    Friend WithEvents txtCopias As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RdoNumeros As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RdoFactura As System.Windows.Forms.RadioButton
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
End Class
