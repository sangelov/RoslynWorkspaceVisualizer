using System;

namespace RoslynWorkspaceVisualizer
{
	internal abstract class ProjectChildViewModel : ViewModelBase
	{
		public abstract string Name { get; }
	}
}