/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.Xml;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Designer.Interfaces;
using Microsoft.VisualStudio.Shell;
using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
using IServiceProvider = System.IServiceProvider;
using ShellConstants = Microsoft.VisualStudio.Shell.Interop.Constants;
using OleConstants = Microsoft.VisualStudio.OLE.Interop.Constants;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.VisualStudio.Package
{
	#region structures
	[StructLayoutAttribute(LayoutKind.Sequential)]
	internal struct _DROPFILES
	{
		public Int32 pFiles;
		public Int32 X;
		public Int32 Y;
		public Int32 fNC;
		public Int32 fWide;
	}
	#endregion

	#region enums
	/// <summary>
	/// Defines possible types of output that can produced by a language project
	/// </summary>
	[PropertyPageTypeConverterAttribute(typeof(OutputTypeConverter))]
	public enum OutputType
	{
		/// <summary>
		/// The output type is a class library.
		/// </summary>
		Library,

		/// <summary>
		/// The output type is a windows executable.
		/// </summary>
		WinExe,

		/// <summary>
		/// The output type is an executable.
		/// </summary>
		Exe
	}

	/// <summary>
	/// Debug values used by DebugModeConverter.
	/// </summary>
	[PropertyPageTypeConverterAttribute(typeof(DebugModeConverter))]
	public enum DebugMode
	{
		Project,
		Program,
		[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "URL")]
		URL
	}

	/// <summary>
	/// An enumeration that describes the type of action to be taken by the build.
	/// </summary>
	[PropertyPageTypeConverterAttribute(typeof(BuildActionConverter))]
	public enum BuildAction
	{
		None,
		Compile,
		Content,
		EmbeddedResource
	}

	/// <summary>
	/// Defines the version of the CLR that is appropriate to the project.
	/// </summary>
	[PropertyPageTypeConverterAttribute(typeof(PlatformTypeConverter))]
	public enum PlatformType
	{
		[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "not")]
		notSpecified,
		[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "v")]
		v1,
		[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "v")]
		v11,
		[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "v")]
		v2,
		[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "cli")]
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "cli")]
		cli1
	}

	/// <summary>
	/// Defines the currect state of a property page.
	/// </summary>
	[Flags]
	public enum PropPageStatus
	{

		Dirty = 0x1,

		Validate = 0x2,

		Clean = 0x4
	}

	[Flags]
	[SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
	public enum ModuleKindFlags
	{

		ConsoleApplication,

		WindowsApplication,

		DynamicallyLinkedLibrary,

		ManifestResourceFile,

		UnmanagedDynamicallyLinkedLibrary
	}

	/// <summary>
	/// Defines the status of the command being queried
	/// </summary>
	[Flags]
	[SuppressMessage("Microsoft.Naming", "CA1714:FlagsEnumsShouldHavePluralNames")]
	[SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
	public enum QueryStatusResult
	{
		/// <summary>
		/// The command is not supported.
		/// </summary>
		[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "NOTSUPPORTED")]
		NOTSUPPORTED = 0,

		/// <summary>
		/// The command is supported
		/// </summary>
		[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "SUPPORTED")]
		SUPPORTED = 1,

		/// <summary>
		/// The command is enabled
		/// </summary>
		[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "ENABLED")]
		ENABLED = 2,

		/// <summary>
		/// The command is toggled on
		/// </summary>
		[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "LATCHED")]
		LATCHED = 4,

		/// <summary>
		/// The command is toggled off (the opposite of LATCHED).
		/// </summary>
		[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "NINCHED")]
		NINCHED = 8,

		/// <summary>
		/// The command is invisible.
		/// </summary>
		[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "INVISIBLE")]
		INVISIBLE = 16
	}

	/// <summary>
	/// Defines the type of item to be added to the hierarchy.
	/// </summary>
	public enum HierarchyAddType
	{
		AddNewItem,
		AddExistingItem
	}

	/// <summary>
	/// Defines the component from which a command was issued.
	/// </summary>
	public enum CommandOrigin
	{
		[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Ui")]
		UiHierarchy,
		OleCommandTarget
	}

	/// <summary>
	/// Defines the current status of the build process.
	/// </summary>
	public enum MSBuildResult
	{
		/// <summary>
		/// The build is currently suspended.
		/// </summary>
		Suspended,

		/// <summary>
		/// The build has been restarted.
		/// </summary>
		Resumed,

		/// <summary>
		/// The build failed.
		/// </summary>
		Failed,

		/// <summary>
		/// The build was successful.
		/// </summary>
		Successful,
	}

	/// <summary>
	/// Defines the type of action to be taken in showing the window frame.
	/// </summary>
	public enum WindowFrameShowAction
	{
		DontShow,
		Show,
		ShowNoActivate,
		Hide,
	}

	/// <summary>
	/// Defines drop types
	/// </summary>
	internal enum DropDataType
	{
		None,
		Shell,
		VsStg,
		VsRef
	}

	/// <summary>
	/// Used by the hierarchy node to decide which element to redraw.
	/// </summary>
	[Flags]
	[SuppressMessage("Microsoft.Naming", "CA1714:FlagsEnumsShouldHavePluralNames")]
	public enum UIHierarchyElement
	{
		None = 0,

		/// <summary>
		/// This will be translated to VSHPROPID_IconIndex
		/// </summary>
		Icon = 1,

		/// <summary>
		/// This will be translated to VSHPROPID_StateIconIndex
		/// </summary>
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Scc")]
		SccState = 2,

		/// <summary>
		/// This will be translated to VSHPROPID_Caption
		/// </summary>
		Caption = 4
	}

	/// <summary>
	/// Defines the global propeties used by the msbuild project.
	/// </summary>
	public enum GlobalProperty
	{
		/// <summary>
		/// Property specifying that we are building inside VS.
		/// </summary>
		BuildingInsideVisualStudio,

		/// <summary>
		/// The VS installation directory. This is the same as the $(DevEnvDir) macro.
		/// </summary>
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Env")]
		DevEnvDir,

		/// <summary>
		/// The name of the solution the project is created. This is the same as the $(SolutionName) macro.
		/// </summary>
		SolutionName,

		/// <summary>
		/// The file name of the solution. This is the same as $(SolutionFileName) macro.
		/// </summary>
		SolutionFileName,

		/// <summary>
		/// The full path of the solution. This is the same as the $(SolutionPath) macro.
		/// </summary>
		SolutionPath,

		/// <summary>
		/// The directory of the solution. This is the same as the $(SolutionDir) macro.
		/// </summary>               
		SolutionDir,

		/// <summary>
		/// The extension of teh directory. This is the same as the $(SolutionExt) macro.
		/// </summary>
		SolutionExt,

		/// <summary>
		/// The fxcop installation directory.
		/// </summary>
		FxCopDir,

		/// <summary>
		/// The ResolvedNonMSBuildProjectOutputs msbuild property
		/// </summary>
		[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "VSIDE")]
		VSIDEResolvedNonMSBuildProjectOutputs,

		/// <summary>
		/// The Configuartion property.
		/// </summary>
		Configuration,

		/// <summary>
		/// The platform property.
		/// </summary>
		Platform,

		/// <summary>
		/// The RunCodeAnalysisOnce property
		/// </summary>
		RunCodeAnalysisOnce,
	}

	/// <summary>
	/// Defines the project trust levels.
	/// </summary>
	public enum ProjectTrustLevel
	{
		/// <summary>
		/// Unknown project.
		/// </summary>
		Unknown = 0,

		/// <summary>
		/// Trusted project.
		/// </summary>
		Trusted = 1
	};

	/// <summary>
	/// Defines the project load options from the ProjectSecurity dialog box
	/// </summary>
	public enum ProjectLoadOption
	{
		/// <summary>
		/// Load the project normally
		/// </summary>
		LoadNormally = 0,

		/// <summary>
		/// Load the project only for browsing
		/// </summary>
		LoadOnlyForBrowsing = 1,

		/// <summary>
		/// Do not load the project.
		/// </summary>
		DonNotLoad = 2
	};

	/// <summary>
	/// Defines the components in the msbuild project file that will be checked.
	/// </summary>
	/// <devremark>The order actually specifies the order in which security checks are made. Thus this is important.</devremark>
	public enum ProjectFileSecurityCheck
	{
		/// <summary>
		/// Not checked
		/// </summary>
		NotChecked = 0,

		/// <summary>
		/// The imports.
		/// </summary>
		Import,

		/// <summary>
		/// The imports in the user file.
		/// </summary>
		ImportInUserFile,

		/// <summary>
		/// The properties.
		/// </summary>
		Property,

		/// <summary>
		/// The targets.
		/// </summary>
		Target,

		/// <summary>
		/// The items.
		/// </summary>
		Item,

		/// <summary>
		/// The using tasks in the project file.
		/// </summary>
		UsingTask,

		/// <summary>
		/// The using task in the user file.
		/// </summary>
		UsingTaskInUserFile,

		/// <summary>
		/// The item location.
		/// </summary>
		ItemLocation,

		/// <summary>
		/// Unknowm
		/// </summary>
		External
	};

	#endregion

	public class AfterProjectFileOpenedEventArgs : EventArgs
	{
		#region fields
		private bool added;
		#endregion

		#region properties
		/// <summary>
		/// True if the project is added to the solution after the solution is opened. false if the project is added to the solution while the solution is being opened.
		/// </summary>
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal bool Added
		{
			get { return this.added; }
		}
		#endregion

		#region ctor
		internal AfterProjectFileOpenedEventArgs(bool added)
		{
			this.added = added;
		}
		#endregion
	}

	public class BeforeProjectFileClosedEventArgs : EventArgs
	{
		#region fields
		private bool removed;
		#endregion

		#region properties
		/// <summary>
		/// true if the project was removed from the solution before the solution was closed. false if the project was removed from the solution while the solution was being closed.
		/// </summary>
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal bool Removed
		{
			get { return this.removed; }
		}
		#endregion

		#region ctor
		internal BeforeProjectFileClosedEventArgs(bool removed)
		{
			this.removed = removed;
		}
		#endregion
	}

	/// <summary>
	/// This class is used for the events raised by a HierarchyNode object.
	/// </summary>
	public class HierarchyNodeEventArgs : EventArgs
	{
		private HierarchyNode child;

		internal HierarchyNodeEventArgs(HierarchyNode child)
		{
			this.child = child;
		}

		public HierarchyNode Child
		{
			get { return this.child; }
		}
	}

	/// <summary>
	/// Event args class for triggering file change event arguments.
	/// </summary>
	internal class FileChangedOnDiskEventArgs : EventArgs
	{
		#region Private fields
		/// <summary>
		/// File name that was changed on disk.
		/// </summary>
		private string fileName;

		/// <summary>
		/// The item ide of the file that has changed.
		/// </summary>
		private uint itemID;

		/// <summary>
		/// The reason the file has changed on disk.
		/// </summary>
		private _VSFILECHANGEFLAGS fileChangeFlag;
		#endregion

		/// <summary>
		/// Constructs a new event args.
		/// </summary>
		/// <param name="fileName">File name that was changed on disk.</param>
		/// <param name="id">The item id of the file that was changed on disk.</param>
		internal FileChangedOnDiskEventArgs(string fileName, uint id, _VSFILECHANGEFLAGS flag)
		{
			this.fileName = fileName;
			this.itemID = id;
			this.fileChangeFlag = flag;
		}

		/// <summary>
		/// Gets the file name that was changed on disk.
		/// </summary>
		/// <value>The file that was changed on disk.</value>
		internal string FileName
		{
			get
			{
				return this.fileName;
			}
		}

		/// <summary>
		/// Gets item id of the file that has changed
		/// </summary>
		/// <value>The file that was changed on disk.</value>
		internal uint ItemID
		{
			get
			{
				return this.itemID;
			}
		}

		/// <summary>
		/// The reason while the file has chnaged on disk.
		/// </summary>
		/// <value>The reason while the file has chnaged on disk.</value>
		internal _VSFILECHANGEFLAGS FileChangeFlag
		{
			get
			{
				return this.fileChangeFlag;
			}
		}
	}

	/// <summary>
	/// Defines the event args for the active configuration chnage event.
	/// </summary>
	public class ActiveConfigurationChangedEventArgs : EventArgs
	{
		#region Private fields
		/// <summary>
		/// The hierarchy whose configuration has changed 
		/// </summary>
		private IVsHierarchy hierarchy;
		#endregion

		/// <summary>
		/// Constructs a new event args.
		/// </summary>
		/// <param name="fileName">The hierarchy that has changed its configuration.</param>
		internal ActiveConfigurationChangedEventArgs(IVsHierarchy hierarchy)
		{
			this.hierarchy = hierarchy;
		}

		/// <summary>
		/// The hierarchy whose configuration has changed 
		/// </summary>
		internal IVsHierarchy Hierarchy
		{
			get
			{
				return this.hierarchy;
			}
		}
	}

	/// <summary>
	/// Argument of the event raised when a project property is changed.
	/// </summary>
	[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
	public class ProjectPropertyChangedArgs : EventArgs
	{
		private string propertyName;
		private string oldValue;
		private string newValue;

		internal ProjectPropertyChangedArgs(string propertyName, string oldValue, string newValue)
		{
			this.propertyName = propertyName;
			this.oldValue = oldValue;
			this.newValue = newValue;
		}

		public string NewValue
		{
			get { return newValue; }
		}

		public string OldValue
		{
			get { return oldValue; }
		}

		public string PropertyName
		{
			get { return propertyName; }
		}
	}
}
