<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctl_tb_user_Keel
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
        Me.lblusername = New System.Windows.Forms.Label
        Me.txtusername = New System.Windows.Forms.TextBox
        Me.lblpassword = New System.Windows.Forms.Label
        Me.txtpassword = New System.Windows.Forms.TextBox
        Me.lblphonetype = New System.Windows.Forms.Label
        Me.txtphonetype = New System.Windows.Forms.TextBox
        Me.lblemail = New System.Windows.Forms.Label
        Me.txtemail = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'lblusername
        '
        Me.lblusername.Location = New System.Drawing.Point(20, 30)
        Me.lblusername.Name = "lblusername"
        Me.lblusername.Size = New System.Drawing.Size(100, 23)
        Me.lblusername.TabIndex = 0
        Me.lblusername.Text = "这是用户表"
        '
        'txtusername
        '
        Me.txtusername.Location = New System.Drawing.Point(150, 30)
        Me.txtusername.Name = "txtusername"
        Me.txtusername.Size = New System.Drawing.Size(100, 21)
        Me.txtusername.TabIndex = 1
        '
        'lblpassword
        '
        Me.lblpassword.Location = New System.Drawing.Point(320, 30)
        Me.lblpassword.Name = "lblpassword"
        Me.lblpassword.Size = New System.Drawing.Size(100, 23)
        Me.lblpassword.TabIndex = 2
        Me.lblpassword.Text = "password"
        '
        'txtpassword
        '
        Me.txtpassword.Location = New System.Drawing.Point(450, 30)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.Size = New System.Drawing.Size(100, 21)
        Me.txtpassword.TabIndex = 2
        '
        'lblphonetype
        '
        Me.lblphonetype.Location = New System.Drawing.Point(20, 60)
        Me.lblphonetype.Name = "lblphonetype"
        Me.lblphonetype.Size = New System.Drawing.Size(100, 23)
        Me.lblphonetype.TabIndex = 3
        Me.lblphonetype.Text = "phonetype"
        '
        'txtphonetype
        '
        Me.txtphonetype.Location = New System.Drawing.Point(150, 60)
        Me.txtphonetype.Name = "txtphonetype"
        Me.txtphonetype.Size = New System.Drawing.Size(100, 21)
        Me.txtphonetype.TabIndex = 3
        '
        'lblemail
        '
        Me.lblemail.Location = New System.Drawing.Point(320, 60)
        Me.lblemail.Name = "lblemail"
        Me.lblemail.Size = New System.Drawing.Size(100, 23)
        Me.lblemail.TabIndex = 4
        Me.lblemail.Text = "email"
        '
        'txtemail
        '
        Me.txtemail.Location = New System.Drawing.Point(450, 60)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(100, 21)
        Me.txtemail.TabIndex = 4
        '
        'ctl_tb_user_Keel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblusername)
        Me.Controls.Add(Me.txtusername)
        Me.Controls.Add(Me.lblpassword)
        Me.Controls.Add(Me.txtpassword)
        Me.Controls.Add(Me.lblphonetype)
        Me.Controls.Add(Me.txtphonetype)
        Me.Controls.Add(Me.lblemail)
        Me.Controls.Add(Me.txtemail)
        Me.Name = "ctl_tb_user_Keel"
        Me.Size = New System.Drawing.Size(600, 131)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents lblusername As System.Windows.Forms.Label
    Public WithEvents txtusername As System.Windows.Forms.TextBox
    Public WithEvents lblpassword As System.Windows.Forms.Label
    Public WithEvents txtpassword As System.Windows.Forms.TextBox
    Public WithEvents lblphonetype As System.Windows.Forms.Label
    Public WithEvents txtphonetype As System.Windows.Forms.TextBox
    Public WithEvents lblemail As System.Windows.Forms.Label
    Public WithEvents txtemail As System.Windows.Forms.TextBox

End Class
