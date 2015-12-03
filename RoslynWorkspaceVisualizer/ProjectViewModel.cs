using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace RoslynWorkspaceVisualizer
{
	internal class ProjectViewModel : ViewModelBase
	{
		private readonly Project project;

		public ProjectViewModel(Project project)
		{
			this.project = project;
		}

		public string Name
		{
			get
			{
				return project.Name;
			}
		}

		public IEnumerable<ProjectChildViewModel> Children
		{
			get
			{
				return new ProjectChildViewModel[] { new ProjectReferencesViewModel(project), new MetadataReferencesViewModel(project) }.Concat(
					project.Documents.OrderBy(d => d.Name).Select(d => new DocumentViewModel(d)));
			}
		}

		public override IEnumerable<KeyValuePair<string, string>> Properties
		{
			get
			{
				foreach (var p in project.GetType().GetProperties().Where(p => p.GetGetMethod().GetParameters().Count() == 0))
				{
					yield return new KeyValuePair<string, string>(p.Name, p.GetValue(project, null).ToString());
				}
			}
		}
	}
}