<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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
        Me.Ctl_tb_user_Keel1 = New Controls.ctl_tb_user_Keel
        Me.SuspendLayout()
        '
        'Ctl_tb_user_Keel1
        '
        Me.Ctl_tb_user_Keel1.Location = New System.Drawing.Point(93, 59)
        Me.Ctl_tb_user_Keel1.Name = "Ctl_tb_user_Keel1"
        Me.Ctl_tb_user_Keel1.Size = New System.Drawing.Size(600, 131)
        Me.Ctl_tb_user_Keel1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(796, 268)
        Me.Controls.Add(Me.Ctl_tb_user_Keel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Ctl_tb_user_Keel1 As Controls.ctl_tb_user_Keel

End Class
