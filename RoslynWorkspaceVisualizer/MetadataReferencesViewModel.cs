using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace RoslynWorkspaceVisualizer
{
	internal class MetadataReferencesViewModel : ProjectChildViewModel
	{
		private readonly Project project;

		public MetadataReferencesViewModel(Project project)
		{
			this.project = project;
		}

		public override string Name
		{
			get
			{
				return "Metadata References";
			}
		}

		public IEnumerable<MetadataReferenceViewModel> Children
		{
			get
			{
				return project.MetadataReferences.Select(m => new MetadataReferenceViewModel(m));
			}
		}
	}
}