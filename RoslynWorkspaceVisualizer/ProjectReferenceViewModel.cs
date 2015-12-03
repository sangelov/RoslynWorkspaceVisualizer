using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace RoslynWorkspaceVisualizer
{
	internal class ProjectReferenceViewModel : ViewModelBase
	{
		private readonly ProjectReference reference;

		public string Name { get; private set; }

		public ProjectReferenceViewModel(ProjectReference reference, string name)
		{
			this.reference = reference;
			Name = name;
		}

		public override IEnumerable<KeyValuePair<string, string>> Properties
		{
			get
			{
				foreach (var property in reference.GetType().GetProperties().Where(p => p.GetGetMethod().GetParameters().Count() == 0))
				{
					yield return new KeyValuePair<string, string>(property.Name, property.GetValue(reference, null).ToString());
				}
			}
		}
	}
}