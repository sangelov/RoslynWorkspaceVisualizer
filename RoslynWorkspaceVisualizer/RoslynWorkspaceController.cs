using System;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.LanguageServices;

namespace RoslynWorkspaceVisualizer
{
	internal class RoslynWorkspaceController
	{
		public event EventHandler<WorkspaceChangeEventArgs> WorkspaceChanged;

		private readonly Workspace workspace;

		public RoslynWorkspaceController(Workspace workspace)
		{
			this.workspace = workspace;
			this.workspace.WorkspaceChanged += OnWorkspaceChanged;
		}

		public Solution CurrentSolution
		{
			get
			{
				return this.workspace.CurrentSolution;
			}
		}

		private void OnWorkspaceChanged(object sender, WorkspaceChangeEventArgs e)
		{
			RaiseWorkspaceChanged(e);
		}

		private void RaiseWorkspaceChanged(WorkspaceChangeEventArgs e)
		{
			var workspaceChanged = WorkspaceChanged;
			if (workspaceChanged != null)
			{
				workspaceChanged(this, e);
			}
		}
	}
}