<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Payment_Cfg
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.PaymentCfgDG = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbPaymentType = New System.Windows.Forms.ComboBox()
        Me.PaymenttypeinfoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PaymentDataSet = New Payment.paymentDataSet()
        Me.cmbStudentType = New System.Windows.Forms.ComboBox()
        Me.Payment_type_infoTableAdapter = New Payment.paymentDataSetTableAdapters.payment_type_infoTableAdapter()
        Me.PaymenttypeinfoBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Paymentcfgibfk2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Payment_cfgTableAdapter = New Payment.paymentDataSetTableAdapters.payment_cfgTableAdapter()
        Me.dtpDateEffect = New System.Windows.Forms.DateTimePicker()
        CType(Me.PaymentCfgDG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PaymenttypeinfoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PaymentDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PaymenttypeinfoBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Paymentcfgibfk2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Amount"
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(113, 88)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(362, 20)
        Me.txtAmount.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Student Type"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Payment Type"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(643, 60)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(115, 27)
        Me.btnClear.TabIndex = 27
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(500, 60)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(116, 27)
        Me.btnDelete.TabIndex = 26
        Me.btnDelete.Text = "DELETE"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(643, 15)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(115, 27)
        Me.btnUpdate.TabIndex = 25
        Me.btnUpdate.Text = "UPDATE"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(500, 15)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(116, 27)
        Me.btnAdd.TabIndex = 24
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'PaymentCfgDG
        '
        Me.PaymentCfgDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PaymentCfgDG.Location = New System.Drawing.Point(35, 173)
        Me.PaymentCfgDG.Name = "PaymentCfgDG"
        Me.PaymentCfgDG.Size = New System.Drawing.Size(729, 165)
        Me.PaymentCfgDG.TabIndex = 28
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(37, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Date Effect"
        '
        'cmbPaymentType
        '
        Me.cmbPaymentType.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.PaymenttypeinfoBindingSource, "id", True))
        Me.cmbPaymentType.FormattingEnabled = True
        Me.cmbPaymentType.Location = New System.Drawing.Point(113, 19)
        Me.cmbPaymentType.Name = "cmbPaymentType"
        Me.cmbPaymentType.Size = New System.Drawing.Size(362, 21)
        Me.cmbPaymentType.TabIndex = 31
        '
        'PaymenttypeinfoBindingSource
        '
        Me.PaymenttypeinfoBindingSource.DataMember = "payment_type_info"
        Me.PaymenttypeinfoBindingSource.DataSource = Me.PaymentDataSet
        '
        'PaymentDataSet
        '
        Me.PaymentDataSet.DataSetName = "paymentDataSet"
        Me.PaymentDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cmbStudentType
        '
        Me.cmbStudentType.FormattingEnabled = True
        Me.cmbStudentType.Location = New System.Drawing.Point(113, 50)
        Me.cmbStudentType.Name = "cmbStudentType"
        Me.cmbStudentType.Size = New System.Drawing.Size(362, 21)
        Me.cmbStudentType.TabIndex = 32
        '
        'Payment_type_infoTableAdapter
        '
        Me.Payment_type_infoTableAdapter.ClearBeforeFill = True
        '
        'PaymenttypeinfoBindingSource1
        '
        Me.PaymenttypeinfoBindingSource1.DataMember = "payment_type_info"
        Me.PaymenttypeinfoBindingSource1.DataSource = Me.PaymentDataSet
        '
        'Paymentcfgibfk2BindingSource
        '
        Me.Paymentcfgibfk2BindingSource.DataMember = "payment_cfg_ibfk_2"
        Me.Paymentcfgibfk2BindingSource.DataSource = Me.PaymenttypeinfoBindingSource
        '
        'Payment_cfgTableAdapter
        '
        Me.Payment_cfgTableAdapter.ClearBeforeFill = True
        '
        'dtpDateEffect
        '
        Me.dtpDateEffect.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateEffect.Location = New System.Drawing.Point(113, 122)
        Me.dtpDateEffect.Name = "dtpDateEffect"
        Me.dtpDateEffect.Size = New System.Drawing.Size(362, 20)
        Me.dtpDateEffect.TabIndex = 33
        Me.dtpDateEffect.Value = New Date(2017, 2, 23, 14, 49, 23, 0)
        '
        'Payment_Cfg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(796, 360)
        Me.Controls.Add(Me.dtpDateEffect)
        Me.Controls.Add(Me.cmbStudentType)
        Me.Controls.Add(Me.cmbPaymentType)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PaymentCfgDG)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAmount)
        Me.Name = "Payment_Cfg"
        Me.Text = "Payment_Cfg"
        CType(Me.PaymentCfgDG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PaymenttypeinfoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PaymentDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PaymenttypeinfoBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Paymentcfgibfk2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents PaymentCfgDG As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbPaymentType As System.Windows.Forms.ComboBox
    Friend WithEvents cmbStudentType As System.Windows.Forms.ComboBox
    Friend WithEvents PaymentDataSet As Payment.paymentDataSet
    Friend WithEvents PaymenttypeinfoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Payment_type_infoTableAdapter As Payment.paymentDataSetTableAdapters.payment_type_infoTableAdapter
    Friend WithEvents PaymenttypeinfoBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents Paymentcfgibfk2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Payment_cfgTableAdapter As Payment.paymentDataSetTableAdapters.payment_cfgTableAdapter
    Friend WithEvents dtpDateEffect As System.Windows.Forms.DateTimePicker
End Class
