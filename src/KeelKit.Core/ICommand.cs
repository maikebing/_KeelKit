using System;
using EnvDTE;
using EnvDTE80;

namespace KeelKit
{
    public interface ICommand
    {
        string Title { get; }
        Exception DoCommand(DTE2 dte);
        vsCommandStatus GetCommandStatus();
        int Positon { get; }
        int IcoID { get; }

    }
}
