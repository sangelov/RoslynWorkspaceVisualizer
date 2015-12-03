using System;
using System.Runtime.InteropServices;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.LanguageServices;
using Microsoft.VisualStudio.Shell;

namespace RoslynWorkspaceVisualizer
{
	[PackageRegistration(UseManagedResourcesOnly = true)]
	[InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
	[ProvideMenuResource("Menus.ctmenu", 1)]
	[ProvideToolWindow(typeof(RoslynWorkspaceVisualizerToolWindow))]
	[Guid(PackageGuidString)]
	public sealed class RoslynWorkspaceVisualizerPackage : Package
	{
		public const string PackageGuidString = "74ffab6e-a030-4b3f-8b60-503aeb146b86";

		public static RoslynWorkspaceVisualizerPackage Instance { get; private set; }
		public Workspace Workspace { get; internal set; }

		public RoslynWorkspaceVisualizerPackage()
		{
			
		}

		protected override void Initialize()
		{
			var componentModel = (IComponentModel)GetService(typeof(SComponentModel));
			Workspace = componentModel.GetService<VisualStudioWorkspace>();
			Instance = this;
			ShowToolWindowCommand.Initialize(this);
			base.Initialize();
		}
	}
}
