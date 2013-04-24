using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace RouseSamples
{
	public partial class RouseSamplesViewController : UIViewController
	{
		UIView moveMe;

		public RouseSamplesViewController () : base ("RouseSamplesViewController", null)
		{
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
			
			initUI ();
			initAnimations ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return true;
		}

		void initUI ()
		{
			moveMe = new UIView{
				Frame = new RectangleF( 20, 20, 100, 100),
				BackgroundColor = UIColor.Black
			};
			View.AddSubview (moveMe);
		}

		void initAnimations ()
		{
			Rouse.To (moveMe, 1, new RouseLib.KeyPaths{ PositionX = 400});
		}
	}
}

