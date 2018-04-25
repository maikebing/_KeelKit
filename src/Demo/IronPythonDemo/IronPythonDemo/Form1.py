import System
from System.Windows.Forms import *
from System.ComponentModel import *
from System.Drawing import *
from clr import *
import CSharpControls
class IronPythonDemo: # namespace
    
    class Form1(System.Windows.Forms.Form):
        """type(_ctl_tb_codsoftitem_Keel1) == CSharpControls.ctl_tb_codsoftitem_Keel"""
        __slots__ = ['_ctl_tb_codsoftitem_Keel1']
        def __init__(self):
            self.InitializeComponent()
        
        @accepts(Self(), bool)
        @returns(None)
        def Dispose(self, disposing):
            
            
            
            super(type(self), self).Dispose(disposing)
        
        @returns(None)
        def InitializeComponent(self):
            self._ctl_tb_codsoftitem_Keel1 = CSharpControls.ctl_tb_codsoftitem_Keel()
            self.SuspendLayout()
            # 
            # ctl_tb_codsoftitem_Keel1
            # 
            self._ctl_tb_codsoftitem_Keel1.Location = System.Drawing.Point(30, 12)
            self._ctl_tb_codsoftitem_Keel1.Name = 'ctl_tb_codsoftitem_Keel1'
            self._ctl_tb_codsoftitem_Keel1.Size = System.Drawing.Size(700, 251)
            self._ctl_tb_codsoftitem_Keel1.TabIndex = 0
            # 
            # Form1
            # 
            self.ClientSize = System.Drawing.Size(782, 319)
            self.Controls.Add(self._ctl_tb_codsoftitem_Keel1)
            self.Name = 'Form1'
            self.Text = 'Form1'
            self.ResumeLayout(False)
        
    

