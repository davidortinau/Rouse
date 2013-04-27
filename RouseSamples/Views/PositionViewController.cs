using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;
using RouseLib.Utils;
using RouseLib;
using Controls;

namespace RouseSamples
{
	public partial class PositionViewController : BaseDetailViewController
	{
		CALayer logo;

		UIImageView logoView;
				
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
			initButtons();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return true;
		}

		void initUI ()
		{
			logo = new LogoLayer();
			logo.Frame = new RectangleF(20, 60, logo.Contents.Width, logo.Contents.Height);
			View.Layer.AddSublayer( logo );

			logoView = new LogoView();
			logoView.Frame = new RectangleF(20, 240, 100, 100);
			View.AddSubview( logoView );

		}

		void initButtons()
		{
			var moveBtn = UIButton.FromType(UIButtonType.RoundedRect);
			moveBtn.Frame = new RectangleF(View.Bounds.Width - 240, 60, 200, 40);
			moveBtn.SetTitle("Move X", UIControlState.Normal);
			moveBtn.TouchUpInside += (object sender, EventArgs e) => {
				if(logoView.Layer.PresentationLayer.Position.X < 400){
					Rouse.To (logoView, 1, new RouseLib.KeyPaths{ PositionX = 400, PositionY = 200}, Easing.EaseInExpo);
					Rouse.To (logo, 1, new RouseLib.KeyPaths{ PositionX = 400, PositionY = 400}, Easing.EaseInExpo);
				}else{
					Rouse.To (logoView, 1, new RouseLib.KeyPaths{ PositionX = 70, PositionY = 110}, Easing.EaseOutExpo);
					Rouse.To (logo, 1, new RouseLib.KeyPaths{ PositionX = 70, PositionY = 290}, Easing.EaseOutExpo);
				}
			};
			View.AddSubview( moveBtn );
		}

	}
}

