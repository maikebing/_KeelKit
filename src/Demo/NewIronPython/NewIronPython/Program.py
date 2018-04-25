from System import *
from System.Windows.Forms import *
from Form1 import *

class NewIronPython0: # namespace
    
    @staticmethod
    def RealEntryPoint():
        Application.EnableVisualStyles()
        Application.Run(NewIronPython.Form1())

if __name__ == "Program":
    NewIronPython0.RealEntryPoint();