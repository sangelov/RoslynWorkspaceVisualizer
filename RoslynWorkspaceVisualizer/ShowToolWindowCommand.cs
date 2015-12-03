using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace RoslynWorkspaceVisualizer
{
	internal sealed class ShowToolWindowCommand
	{
		public static readonly Guid CommandSet = new Guid("a32b1d3e-73dc-4e51-adac-1593c7c28e26");

		public const int CommandId = 0x0100;

		private readonly Package package;

		public static ShowToolWindowCommand Instance { get; private set; }

		private ShowToolWindowCommand(Package package)
		{
			if (package == null)
			{
				throw new ArgumentNullException("package");
			}

			this.package = package;

			var commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
			if (commandService != null)
			{
				var menuCommandID = new CommandID(CommandSet, CommandId);
				var menuItem = new MenuCommand(this.ShowToolWindow, menuCommandID);
				commandService.AddCommand(menuItem);
			}
		}

		private IServiceProvider ServiceProvider
		{
			get
			{
				return this.package;
			}
		}

		public static void Initialize(Package package)
		{
			Instance = new ShowToolWindowCommand(package);
		}

		public void ShowToolWindow(object sender, EventArgs e)
		{
			ToolWindowPane window = this.package.FindToolWindow(typeof(RoslynWorkspaceVisualizerToolWindow), id: 0, create: true);
			if ((null == window) || (null == window.Frame))
			{
				throw new NotSupportedException("Cannot create tool window");
			}

			IVsWindowFrame windowFrame = (IVsWindowFrame)window.Frame;
			ErrorHandler.ThrowOnFailure(windowFrame.Show());
		}
	}
}
