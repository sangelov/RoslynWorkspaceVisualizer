using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace RoslynWorkspaceVisualizer
{
	internal class SolutionViewModel : ViewModelBase
	{
		private readonly Solution solution;

		public SolutionViewModel(Solution solution)
		{
			this.solution = solution;
		}

		public ObservableCollection<ProjectViewModel> Projects
		{
			get
			{
				return new ObservableCollection<ProjectViewModel>(solution.Projects.Select(p => new ProjectViewModel(p)));
			}
		}

		public string FilePath
		{
			get
			{

				return solution.FilePath;
			}
		}

		public override IEnumerable<KeyValuePair<string, string>> Properties
		{
			get
			{
				foreach (var p in solution.GetType().GetProperties().Where(p => p.GetGetMethod().GetParameters().Count() == 0))
				{
					yield return new KeyValuePair<string, string>(p.Name, p.GetValue(solution, null).ToString());
				}
			}
		}
	}
}