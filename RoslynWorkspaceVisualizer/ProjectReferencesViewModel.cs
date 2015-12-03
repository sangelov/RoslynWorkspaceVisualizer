using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace RoslynWorkspaceVisualizer
{
	internal class ProjectReferencesViewModel : ProjectChildViewModel
	{
		private readonly Project project;

		public ProjectReferencesViewModel(Project project)
		{
			this.project = project;
		}

		public override string Name
		{
			get
			{
				return "References";
			}
		}

		public IEnumerable<ProjectReferenceViewModel> Children
		{
			get
			{
				return project.ProjectReferences.Select(r => new ProjectReferenceViewModel(r, project.Solution.GetProject(r.ProjectId).Name));
			}
		}
	}
}