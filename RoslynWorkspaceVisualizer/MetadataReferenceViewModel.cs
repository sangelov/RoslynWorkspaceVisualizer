using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace RoslynWorkspaceVisualizer
{
	internal class MetadataReferenceViewModel : ViewModelBase
	{
		private readonly MetadataReference reference;

		public MetadataReferenceViewModel(MetadataReference reference)
		{
			this.reference = reference;
		}

		public string Name
		{
			get
			{
				return reference.Display;
			}
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