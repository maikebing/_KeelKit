using System;
using KeelKit.AutoVersion;

namespace KeelKit
{
    public static class HandEvents
    {
        public static void HandAllEvents()
        {
            try
            {
            Common.chDTE.Events.BuildEvents.OnBuildBegin += new EnvDTE._dispBuildEvents_OnBuildBeginEventHandler(BuildEvents_OnBuildBegin);
            Common.chDTE.Events.DebuggerEvents.OnEnterRunMode += new EnvDTE._dispDebuggerEvents_OnEnterRunModeEventHandler(DebuggerEvents_OnEnterRunMode);
            Common.chDTE.Events.SolutionEvents.Opened += new EnvDTE._dispSolutionEvents_OpenedEventHandler(SolutionEvents_Opened);
            Common.chDTE.Events.SolutionEvents.BeforeClosing += new EnvDTE._dispSolutionEvents_BeforeClosingEventHandler(SolutionEvents_BeforeClosing);
            if (Environment.OSVersion.Version.Major >= 6 && Environment.OSVersion.Version.Minor >= 1)
            {
                Common.Win7Taskbar.Startup();
            }
            }
            catch (Exception)
            {

                Common.ShowInfo("委托解决方案的事件时遇到问题!");
            }
            
        }

        static void SolutionEvents_BeforeClosing()
        {
           
        }
 

        static void SolutionEvents_Opened()
        {
    
        }

    
        public static void RemoveHandAllEvents()
        {

            Common.chDTE.Events.BuildEvents.OnBuildBegin -= new EnvDTE._dispBuildEvents_OnBuildBeginEventHandler(BuildEvents_OnBuildBegin);
            Common.chDTE.Events.DebuggerEvents.OnEnterRunMode -= new EnvDTE._dispDebuggerEvents_OnEnterRunModeEventHandler(DebuggerEvents_OnEnterRunMode);
            Common.chDTE.Events.SolutionEvents.Opened -= new EnvDTE._dispSolutionEvents_OpenedEventHandler(SolutionEvents_Opened);
        }


        static void DebuggerEvents_OnEnterRunMode(EnvDTE.dbgEventReason Reason)
        {
            if (Environment.OSVersion.Version.Major >= 6 && Environment.OSVersion.Version.Minor >= 1)
            {
                Common.Win7Taskbar.OnEnterRunMode(Reason);
            }
        }

        static void BuildEvents_OnBuildBegin(EnvDTE.vsBuildScope Scope, EnvDTE.vsBuildAction Action)
        {
            AsmVerControl.CheckAndChangeAsmVer();
            if (Environment.OSVersion.Version.Major >= 6 && Environment.OSVersion.Version.Minor >= 1)
            {
                Common.Win7Taskbar.OnBuildBegin(Scope, Action);
            }
        }

      
    }

    }
