<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctl_tb_codfiles_Keel
    Inherits System.Windows.Forms.UserControl

    'UserControl 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblfilemd5 = New System.Windows.Forms.Label
        Me.txtfilemd5 = New System.Windows.Forms.TextBox
        Me.lblfilepath = New System.Windows.Forms.Label
        Me.txtfilepath = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'lblfilemd5
        '
        Me.lblfilemd5.Location = New System.Drawing.Point(20, 30)
        Me.lblfilemd5.Name = "lblfilemd5"
        Me.lblfilemd5.Size = New System.Drawing.Size(100, 23)
        Me.lblfilemd5.TabIndex = 0
        Me.lblfilemd5.Text = "Cod文件"
        '
        'txtfilemd5
        '
        Me.txtfilemd5.Location = New System.Drawing.Point(150, 30)
        Me.txtfilemd5.Name = "txtfilemd5"
        Me.txtfilemd5.Size = New System.Drawing.Size(100, 21)
        Me.txtfilemd5.TabIndex = 1
        '
        'lblfilepath
        '
        Me.lblfilepath.Location = New System.Drawing.Point(320, 30)
        Me.lblfilepath.Name = "lblfilepath"
        Me.lblfilepath.Size = New System.Drawing.Size(100, 23)
        Me.lblfilepath.TabIndex = 2
        Me.lblfilepath.Text = "filepath"
        '
        'txtfilepath
        '
        Me.txtfilepath.Location = New System.Drawing.Point(450, 30)
        Me.txtfilepath.Name = "txtfilepath"
        Me.txtfilepath.Size = New System.Drawing.Size(100, 21)
        Me.txtfilepath.TabIndex = 4
        '
        'ctl_tb_codfiles_Keel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblfilemd5)
        Me.Controls.Add(Me.txtfilemd5)
        Me.Controls.Add(Me.lblfilepath)
        Me.Controls.Add(Me.txtfilepath)
        Me.Name = "ctl_tb_codfiles_Keel"
        Me.Size = New System.Drawing.Size(600, 101)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents lblfilemd5 As System.Windows.Forms.Label
    Public WithEvents txtfilemd5 As System.Windows.Forms.TextBox
    Public WithEvents lblfilepath As System.Windows.Forms.Label
    Public WithEvents txtfilepath As System.Windows.Forms.TextBox

End Class
