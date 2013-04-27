
using System;
using System.Collections.Generic;

using MonoTouch.UIKit;
using SplitView.NavigationTable;

namespace RouseSamples
{
	public partial class MasterViewController : UITableViewController
	{
		public event EventHandler<RowClickedEventArgs> RowClicked;
		
		// declare vars
		List<NavItemGroup> navItems = new List<NavItemGroup> ();
		NavItemTableSource tableSource;

		public MasterViewController () : base (UITableViewStyle.Grouped)
		{

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// create the navigation items
			NavItemGroup navGroup = new NavItemGroup ("Animations");
			navItems.Add (navGroup);
//			navGroup.Items.Add (new NavItem ("Temp", "", typeof (TempViewController)));
			navGroup.Items.Add (new NavItem ("PositionX", "", typeof (PositionXViewController)));
			navGroup.Items.Add (new NavItem ("PositionY", "", typeof (PositionYViewController)));
			navGroup.Items.Add (new NavItem ("Position", "", typeof (PositionViewController)));
			navGroup.Items.Add (new NavItem ("Opacity", "", typeof (CanChangeOpacity)));
			navGroup.Items.Add (new NavItem ("Scale", "", typeof (ScaleViewController)));


			
//			NavItemGroup caGroup = new NavItemGroup("CA Animations");
//			navItems.Add( caGroup );

			// create a table source from our nav items
			tableSource = new NavItemTableSource (navItems);
			
			// set the source on the table to our data source
			base.TableView.Source =  tableSource;
			
			tableSource.RowClicked += (object sender, RowClickedEventArgs e) => {
				if(this.RowClicked != null)
					this.RowClicked(sender, e);
			};
		}

		public override bool ShouldAutorotateToInterfaceOrientation
			(UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}
	}
}
