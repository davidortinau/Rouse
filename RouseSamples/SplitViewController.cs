
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SplitView.NavigationTable;
using System.Reflection;

namespace RouseSamples
{
	public partial class SplitViewController : UISplitViewController
	{
		MasterViewController masterView;
		UIViewController detailView;
		UIPopoverController popoverController;
		UIBarButtonItem rootPopoverButtonItem;

		public SplitViewController () : base ()
		{
			masterView = new MasterViewController();
			detailView = new PositionXViewController();

			ViewControllers = new UIViewController[]{masterView, detailView};

			masterView.RowClicked += (object sender, RowClickedEventArgs e) => {
				this.HandleRowClicked (e);
			};

			this.WillHideViewController += (object sender, UISplitViewHideEventArgs e) => {
				popoverController = e.Pc;
				rootPopoverButtonItem = e.BarButtonItem;
				(detailView as BaseDetailViewController).Popover = popoverController;
				(detailView as BaseDetailViewController).AddContentsButton (rootPopoverButtonItem);
			};
			
			this.WillShowViewController += (object sender, UISplitViewShowEventArgs e) => {
				(detailView as BaseDetailViewController).Popover = null;
				(detailView as BaseDetailViewController).RemoveContentsButton ();
				popoverController = null;
				rootPopoverButtonItem = null;
			};
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
		}

		protected void HandleRowClicked(RowClickedEventArgs e)
		{
			Console.WriteLine("Changing Screens");

			if (popoverController != null)
				popoverController.Dismiss (true);

			if (e.Item.Controller != null)
			{
				UIView.BeginAnimations("DetailViewPush");
				detailView = e.Item.Controller;
				this.ViewControllers = new UIViewController[] { masterView,  detailView };
				UIView.SetAnimationTransition(UIViewAnimationTransition.FlipFromRight, this.ViewControllers[1].View, false);
				UIView.CommitAnimations();
			}
			else
			{
				if (e.Item.ControllerType != null)
				{
					//
					ConstructorInfo ctor = null;
					
					// if the nav item has constructor aguments
					if (e.Item.ControllerConstructorArgs.Length > 0) {
						// look for the constructor
						ctor = e.Item.ControllerType.GetConstructor (e.Item.ControllerConstructorTypes);
					} else {
						// search for the default constructor
						ctor = e.Item.ControllerType.GetConstructor (System.Type.EmptyTypes);
					}
					
					// if we found the constructor
					if (ctor != null) {
						//
						UIViewController instance = null;
						
						if (e.Item.ControllerConstructorArgs.Length > 0) {
							// instance the view controller
							instance = ctor.Invoke (e.Item.ControllerConstructorArgs) as UIViewController;
						} else {
							// instance the view controller
							instance = ctor.Invoke (null) as UIViewController;
						}
						
						if (instance != null) {
							// save the object
							e.Item.Controller = instance;
							
							// push the view controller onto the stack
							UIView.BeginAnimations("DetailViewPush");
							detailView = e.Item.Controller;
							this.ViewControllers = new UIViewController[] { masterView,  detailView};
							UIView.SetAnimationTransition(UIViewAnimationTransition.FlipFromRight, this.ViewControllers[1].View, false);
							UIView.CommitAnimations();
						}
						else
							Console.WriteLine ("instance of view controller not created");
					}
					else
						Console.WriteLine ("constructor not found");
				}
			}

			if (rootPopoverButtonItem != null)
				(detailView as BaseDetailViewController).AddContentsButton (rootPopoverButtonItem);
		}

	}
}

