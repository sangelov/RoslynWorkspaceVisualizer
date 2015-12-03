using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

namespace RoslynWorkspaceVisualizer
{
	[Guid(ToolWindowGuidStrung)]
	public class RoslynWorkspaceVisualizerToolWindow : ToolWindowPane
	{
		private const string ToolWindowGuidStrung = "0f7a91a6-12b5-40c9-9b13-75e1fa2e0761";
		private const string ToolWindowCaptionString = "Roslyn Workspace Visualizer";

		public RoslynWorkspaceVisualizerToolWindow() : base(provider: null)
		{
			Caption = ToolWindowCaptionString;
			Content = new RoslynWorkspaceVisualizerControl();
		}
	}
}
