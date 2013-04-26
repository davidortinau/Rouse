
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

			Delegate = new SplitViewDelegate();
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			masterView.RowClicked += (object sender, RowClickedEventArgs e) => {
				this.HandleRowClicked (e);
			};
		}

		protected void HandleRowClicked(RowClickedEventArgs e)
		{
			Console.WriteLine("Changing Screens");
			
			if (popoverController != null)
				popoverController.Dismiss (true);

//			(detailView as BaseDetailViewController).Update (e.Item);
			
			// if the nav item has a proper controller, push it on to the NavigationController
			// NOTE: we could also raise an event here, to loosely couple this, but isn't neccessary,
			// because we'll only ever use this this way
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
							UIView.SetAnimationTransition(UIViewAnimationTransition.CurlUp, this.ViewControllers[1].View, false);
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

		public override bool ShouldAutorotateToInterfaceOrientation
			(UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}
	}

	public class SplitViewDelegate : UISplitViewControllerDelegate {
		public override bool ShouldHideViewController (UISplitViewController svc, UIViewController viewController, UIInterfaceOrientation inOrientation)
		{
			return inOrientation == UIInterfaceOrientation.Portrait
				|| inOrientation == UIInterfaceOrientation.PortraitUpsideDown;
		}
		
		public override void WillHideViewController (UISplitViewController svc, UIViewController aViewController, UIBarButtonItem barButtonItem, UIPopoverController pc)
		{
			BaseDetailViewController detailView = svc.ViewControllers[1] as BaseDetailViewController;
			detailView.AddContentsButton (barButtonItem);
		}
		
		public override void WillShowViewController (UISplitViewController svc, UIViewController aViewController, UIBarButtonItem button)
		{
			BaseDetailViewController detailView = svc.ViewControllers[1] as BaseDetailViewController;
			detailView.RemoveContentsButton ();
		}
	}
}

