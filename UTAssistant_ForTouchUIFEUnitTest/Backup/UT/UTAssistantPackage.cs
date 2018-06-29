using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;

using EnvDTE;

using Microsoft.Internal.VisualStudio.PlatformUI;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

using UTAssistant.BE;
using UTAssistant.BE.ViewModel;
using UTAssistant.FE;

namespace VSPackage.UTAssistant
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    ///
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the 
    /// IVsPackage interface and uses the registration attributes defined in the framework to 
    /// register itself and its components with the shell.
    /// </summary>
    // This attribute tells the PkgDef creation utility (CreatePkgDef.exe) that this class is
    // a package.
    [PackageRegistration( UseManagedResourcesOnly = true )]
    // This attribute is used to register the information needed to show this package
    // in the Help/About dialog of Visual Studio.
    [InstalledProductRegistration( "#110", "#112", "1.0", IconResourceID = 400 )]
    // This attribute is needed to let the shell know that this package exposes some menus.
    [ProvideMenuResource( "Menus.ctmenu", 1 )]
    [Guid( GuidList.guidUTPkgString )]
    public sealed class UTAssistantPackage : Package
    {
        /// <summary>
        /// Default constructor of the package.
        /// Inside this method you can place any initialization code that does not require 
        /// any Visual Studio service because at this point the package object is created but 
        /// not sited yet inside Visual Studio environment. The place to do all the other 
        /// initialization is the Initialize method.
        /// </summary>
        public UTAssistantPackage()
        {
            Debug.WriteLine( string.Format( CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString() ) );
        }

        /////////////////////////////////////////////////////////////////////////////
        // Overridden Package Implementation

        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            Debug.WriteLine( string.Format( CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString() ) );
            base.Initialize();

            // Add our command handlers for menu (commands must exist in the .vsct file)
            OleMenuCommandService mcs = GetService( typeof( IMenuCommandService ) ) as OleMenuCommandService;
            if( null != mcs )
            {
                // Create the command for the menu item.
                CommandID menuCommandID = new CommandID( GuidList.guidUTCmdSet, (int) PkgCmdIDList.cmdidOpenTests );
                MenuCommand menuItem = new MenuCommand( MenuItemCallback, menuCommandID );
                mcs.AddCommand( menuItem );
            }
        }

        #endregion

        /// <summary>
        /// This function is the callback used to execute a command when the a menu item is clicked.
        /// See the Initialize method to see how the menu item is associated to this function using
        /// the OleMenuCommandService service and the MenuCommand class.
        /// </summary>
        private void MenuItemCallback( object sender, EventArgs e )
        {
            // Show a Message Box to prove we were here
            IVsUIShell uiShell = (IVsUIShell) GetService( typeof( SVsUIShell ) );
            //Guid clsid = Guid.Empty;
            //int result;
            //Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure( uiShell.ShowMessageBox(
            //                                                                           0,
            //                                                                           ref clsid,
            //                                                                           "UT",
            //                                                                           string.Format( CultureInfo.CurrentCulture,
            //                                                                                          "Inside {0}.MenuItemCallback()",
            //                                                                                          this.ToString() ),
            //                                                                           string.Empty,
            //                                                                           0,
            //                                                                           OLEMSGBUTTON.OLEMSGBUTTON_OK,
            //                                                                           OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST,
            //                                                                           OLEMSGICON.OLEMSGICON_INFO,
            //                                                                           0,
            //                                                                           // false

            //                                                                           out result ) );

            IntPtr hwnd;
            uiShell.GetDialogOwnerHwnd( out hwnd );

            // Get an instance of the currently running Visual Studio IDE
            //DTE dte = (DTE) GetService( typeof( DTE ) );
            //if( !dte.Solution.IsOpen )
            //{
            //    return;
            //}

            //var assemblies = new List<string>();
            //foreach( Project project in dte.Solution.Projects )
            //{
            //    var name = project.Name;

            //    if( name.EndsWith( "Test.Unit" ) )
            //    {
            //        assemblies.Add( GetAssemblyPath( project ) );
            //    }
            //}

            const string solution = "TouchUI";
            var assemblyList = new List<string>
            {
                @"D:\TFS\IRIDIUM1\bin\Debug\CT.Exam.TouchUI.FE.Test.Unit.dll",
            };
            //var root = AssemblyWalker.BuildTree( dte.Solution.FileName, assemblies );
            var root = AssemblyWalker.BuildTree( solution, assemblyList );

            MainWindow mainWindow = new MainWindow();

            var projects = new UtTreeViewModel( root );
            mainWindow.DataContext = projects;
            WindowHelper.ShowModal( mainWindow, hwnd );
        }

        private static string GetAssemblyPath( Project vsProject )
        {
            string fullPath = vsProject.Properties.Item( "FullPath" ).Value.ToString();
            string outputPath = vsProject.ConfigurationManager.ActiveConfiguration.Properties.Item( "OutputPath" ).Value.ToString();
            string outputDir = Path.Combine( fullPath, outputPath );
            string outputFileName = vsProject.Properties.Item( "OutputFileName" ).Value.ToString();
            string assemblyPath = Path.Combine( outputDir, outputFileName );
            return assemblyPath;
        }
    }
}