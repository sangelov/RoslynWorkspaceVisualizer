using System;
using System.Collections.Generic;
using System.Linq;

namespace RoslynWorkspaceVisualizer
{
	internal abstract class ViewModelBase
	{
		public virtual IEnumerable<KeyValuePair<string, string>> Properties
		{
			get
			{
				return Enumerable.Empty<KeyValuePair<string, string>>();
			}
		}
	}
}