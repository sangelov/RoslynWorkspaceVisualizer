using System;
using System.Collections.ObjectModel;
using Microsoft.CodeAnalysis;

namespace RoslynWorkspaceVisualizer
{
	internal class WorkspaceViewModel
	{
		private readonly ObservableCollection<SolutionViewModel> solutions = new ObservableCollection<SolutionViewModel>();
		private readonly RoslynWorkspaceController controller;

		public WorkspaceViewModel(RoslynWorkspaceController controller)
		{
			this.controller = controller;
			Solutions.Add(new SolutionViewModel(controller.CurrentSolution));
			this.controller.WorkspaceChanged += OnWorkspaceChanged;
		}

		public ObservableCollection<SolutionViewModel> Solutions
		{
			get
			{
				return solutions;
			}
		}

		private void OnWorkspaceChanged(object sender, WorkspaceChangeEventArgs e)
		{
			Solutions.Clear();
			Solutions.Add(new SolutionViewModel(e.NewSolution));
		}
	}
}