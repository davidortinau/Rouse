using System;
namespace SplitView.NavigationTable
{
	public class RowClickedEventArgs : EventArgs
	{
		public NavItem Item { get; set; }
		
		public RowClickedEventArgs(NavItem item) : base()
		{ this.Item = item; }
	}
}

