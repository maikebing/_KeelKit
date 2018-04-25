from System import *
from System.Windows.Forms import *
from Form1 import *

class IronPythonDemo0: # namespace
    
    @staticmethod
    def RealEntryPoint():
        Application.EnableVisualStyles()
        Application.Run(IronPythonDemo.Form1())

if __name__ == "Program":
    IronPythonDemo0.RealEntryPoint();