using System;
using System.Reflection;
using EnvDTE;
using EnvDTE80;
using Extensibility;
using Microsoft.WindowsAPICodePack.Taskbar;
using KeelKit.Properties;
using System.Windows.Forms;

namespace KeelKit
{
    public class Win7Taskbar
    {
        private AddIn _addInInstance;
        private DTE2 _applicationObject;
        private BuildEvents _buildEvents;
        private DebuggerEvents _debuggerEvents;
        private SolutionEvents _solutionEvents;
        private TaskbarManager _taskbarManager = TaskbarManager.Instance;
        private ThumbnailToolBarButton buttonBuildSolution = new ThumbnailToolBarButton(Resources.build, "生成解决方案");
        private ThumbnailToolBarButton buttonDebug = new ThumbnailToolBarButton(Resources.debug, "启动调试");
        private ThumbnailToolBarButton buttonRun = new ThumbnailToolBarButton(Resources.run, "开始执行(不调试)");

        private void buttonBuildSolution_Click(object sender, ThumbnailButtonClickedEventArgs args)
        {

            try
            {
                this._applicationObject.Solution.SolutionBuild.Build(false);
            }
            catch (Exception)
            {

                // throw;
            }

        }

        private void buttonDebug_Click(object sender, ThumbnailButtonClickedEventArgs args)
        {
            try
            {
                this._applicationObject.Solution.SolutionBuild.Debug();
            }
            catch (Exception)
            {


            }
        }

        private void buttonRun_Click(object sender, ThumbnailButtonClickedEventArgs args)
        {
            try
            {
                this._applicationObject.Solution.SolutionBuild.Run();
            }
            catch (Exception)
            {


            }
        }

        private void CheckTasks()
        {
            int num = 0;
            int num2 = 0;
            foreach (TaskItem item in this._applicationObject.ToolWindows.TaskList.TaskItems)
            {
                if (item.Category == "BuildCompile")
                {
                    switch (item.Priority)
                    {
                        case vsTaskPriority.vsTaskPriorityLow:
                            {
                                continue;
                            }
                        case vsTaskPriority.vsTaskPriorityMedium:
                            {
                                num++;
                                continue;
                            }
                        case vsTaskPriority.vsTaskPriorityHigh:
                            {
                                num2++;
                                continue;
                            }
                    }
                }
            }
            if (num2 != 0)
            {
                this._taskbarManager.SetOverlayIcon(Resources.error, "错误!");
            }
            else if (num != 0)
            {
                this._taskbarManager.SetOverlayIcon(Resources.warning, "警告!");
            }
            else
            {
                this._taskbarManager.SetOverlayIcon(null, null);
            }
        }

        private void DisableToolbar()
        {
            this.buttonBuildSolution.Enabled = false;
            this.buttonDebug.Enabled = false;
            this.buttonRun.Enabled = false;
        }

        private void EnableToolbar()
        {
            this.buttonBuildSolution.Enabled = true;
            this.buttonDebug.Enabled = true;
            this.buttonRun.Enabled = true;
        }

        public void OnAddInsUpdate(ref Array custom)
        {
        }

        public void OnBeginShutdown(ref Array custom)
        {
        }

        public void OnBuildBegin(vsBuildScope Scope, vsBuildAction Action)
        {
            this._taskbarManager.SetProgressState(TaskbarProgressBarState.Indeterminate);
            this.DisableToolbar();
            this._taskbarManager.SetOverlayIcon(null, null);
        }

        private void OnBuildDone(vsBuildScope Scope, vsBuildAction Action)
        {
            this._taskbarManager.SetProgressState(TaskbarProgressBarState.NoProgress);
            this.EnableToolbar();
            this.CheckTasks();
        }

        public void InitThis(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
        {
            this._applicationObject = (DTE2)application;
            this._addInInstance = (AddIn)addInInst;
            if (!TaskbarManager.IsPlatformSupported)
            {
                //  MessageBox.Show("Win7任务栏快捷按钮仅基于Windows7，不支持当前平台！", "插件需要Windows7", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Common.ShowInfo("Win7任务栏快捷按钮仅基于Windows7，不支持当前平台！");

            }

        }

        public void UnloadThis(ext_DisconnectMode disconnectMode, ref Array custom)
        {
            try
            {
                this._taskbarManager.SetProgressState(TaskbarProgressBarState.NoProgress);
                this._taskbarManager.SetOverlayIcon(null, null);
            }
            catch (Exception)
            {


            }

        }

        public void OnEnterDesignMode(dbgEventReason Reason)
        {
            this.buttonDebug.Enabled = true;
        }

        public void OnEnterRunMode(dbgEventReason Reason)
        {
            this.buttonDebug.Enabled = false;
        }

        public void Startup()
        {
            this.buttonBuildSolution.Click += new EventHandler<ThumbnailButtonClickedEventArgs>(this.buttonBuildSolution_Click);
            this.buttonDebug.Click += new EventHandler<ThumbnailButtonClickedEventArgs>(this.buttonDebug_Click);
            this.buttonRun.Click += new EventHandler<ThumbnailButtonClickedEventArgs>(this.buttonRun_Click);
            _taskbarManager.ThumbnailToolBars.AddButtons((IntPtr)this._applicationObject.MainWindow.HWnd, new ThumbnailToolBarButton[] { this.buttonBuildSolution, this.buttonDebug, this.buttonRun });
            this.DisableToolbar();
            this._buildEvents = this._applicationObject.Events.BuildEvents;
            this._buildEvents.OnBuildBegin += new _dispBuildEvents_OnBuildBeginEventHandler(OnBuildBegin);
            this._buildEvents.OnBuildDone += new _dispBuildEvents_OnBuildDoneEventHandler(OnBuildDone);
            this._debuggerEvents = this._applicationObject.Events.DebuggerEvents;
            this._debuggerEvents.OnEnterRunMode += (new _dispDebuggerEvents_OnEnterRunModeEventHandler(this.OnEnterRunMode));
            this._debuggerEvents.OnEnterDesignMode += (new _dispDebuggerEvents_OnEnterDesignModeEventHandler(this.OnEnterDesignMode));
            this._solutionEvents = this._applicationObject.Events.SolutionEvents;
            this._solutionEvents.Opened += (new _dispSolutionEvents_OpenedEventHandler(this.EnableToolbar));
            this._solutionEvents.AfterClosing += (new _dispSolutionEvents_AfterClosingEventHandler(this.DisableToolbar));
        }
        public void EndWork()
        {
            this.buttonBuildSolution.Click -= new EventHandler<ThumbnailButtonClickedEventArgs>(this.buttonBuildSolution_Click);
            this.buttonDebug.Click -= new EventHandler<ThumbnailButtonClickedEventArgs>(this.buttonDebug_Click);
            this.buttonRun.Click -= new EventHandler<ThumbnailButtonClickedEventArgs>(this.buttonRun_Click);
            this.DisableToolbar();
            this._buildEvents = this._applicationObject.Events.BuildEvents;
            this._buildEvents.OnBuildBegin += new _dispBuildEvents_OnBuildBeginEventHandler(OnBuildBegin);
            this._buildEvents.OnBuildDone -= new _dispBuildEvents_OnBuildDoneEventHandler(OnBuildDone);
            this._debuggerEvents = this._applicationObject.Events.DebuggerEvents;
            this._debuggerEvents.OnEnterRunMode += (new _dispDebuggerEvents_OnEnterRunModeEventHandler(this.OnEnterRunMode));
            this._debuggerEvents.OnEnterDesignMode -= (new _dispDebuggerEvents_OnEnterDesignModeEventHandler(this.OnEnterDesignMode));
            this._solutionEvents = this._applicationObject.Events.SolutionEvents;
            this._solutionEvents.Opened -= (new _dispSolutionEvents_OpenedEventHandler(this.EnableToolbar));
            this._solutionEvents.AfterClosing -= (new _dispSolutionEvents_AfterClosingEventHandler(this.DisableToolbar));
        }



    }
}
