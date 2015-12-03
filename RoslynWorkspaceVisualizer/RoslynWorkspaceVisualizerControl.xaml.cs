using System.Windows.Controls;

namespace RoslynWorkspaceVisualizer
{
	public partial class RoslynWorkspaceVisualizerControl : UserControl
	{
		public RoslynWorkspaceVisualizerControl()
		{
			this.InitializeComponent();
			DataContext = new WorkspaceViewModel(new RoslynWorkspaceController(RoslynWorkspaceVisualizerPackage.Instance.Workspace));
		}
	}
}