using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace RoslynWorkspaceVisualizer
{
	internal class DocumentViewModel : ProjectChildViewModel
	{
		private readonly Document document;

		public DocumentViewModel(Document document)
		{
			this.document = document;
		}

		public override string Name
		{
			get
			{
				return document.Name;
			}
		}

		public override IEnumerable<KeyValuePair<string, string>> Properties
		{
			get
			{
				foreach (var property in document.GetType().GetProperties().Where(p => p.GetGetMethod().GetParameters().Count() == 0))
				{
					yield return new KeyValuePair<string, string>(property.Name, property.GetValue(document, null).ToString());
				}
			}
		}
	}
}