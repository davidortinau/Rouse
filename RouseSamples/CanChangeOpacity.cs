
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;
using RouseLib;

namespace RouseSamples
{
	public partial class CanChangeOpacity : UIViewController
	{
		CALayer logo;

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			initUI();
			initAnimation();
		}

		void initUI ()
		{
			logo = new CALayer();
			logo.Contents = UIImage.FromBundle("icon-100.png").CGImage;
			logo.Frame = new RectangleF(20, 20, logo.Contents.Width, logo.Contents.Height);
			View.Layer.AddSublayer( logo );
		}

		void initAnimation ()
		{
			Rouse.To( logo, 2, new KeyPaths{ Opacity = 0}, Easing.EaseInExpo);
		}
	}
}

