using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;
using RouseLib.Utils;
using RouseLib;

namespace RouseSamples
{
	public partial class PositionXViewController : BaseDetailViewController
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
			logo = new CALayer();
			logo.Contents = UIImage.FromBundle("icon-100.png").CGImage;
			logo.Frame = new RectangleF(20, 60, logo.Contents.Width, logo.Contents.Height);
			View.Layer.AddSublayer( logo );

			logoView = new UIImageView( new RectangleF(20, 240, 100, 100));
			logoView.Image = UIImage.FromBundle("icon-100.png");
			View.AddSubview( logoView );

		}

		void initButtons()
		{
			var moveBtn = new UIButton( UIButtonType.RoundedRect );
			moveBtn.Frame = new RectangleF(View.Bounds.Width - 240, 60, 200, 40);
			moveBtn.SetTitle("Move X", UIControlState.Normal);
			moveBtn.TouchUpInside += (object sender, EventArgs e) => {
				if(logoView.Layer.PresentationLayer.Position.X < 400){
					Rouse.To (logoView, 1, new RouseLib.KeyPaths{ PositionX = 400}, Easing.EaseInExpo);
					Rouse.To (logo, 1, new RouseLib.KeyPaths{ PositionX = 400}, Easing.EaseInExpo);
				}else{
					Rouse.To (logoView, 1, new RouseLib.KeyPaths{ PositionX = 70}, Easing.EaseOutExpo);
					Rouse.To (logo, 1, new RouseLib.KeyPaths{ PositionX = 70}, Easing.EaseOutExpo);
				}
			};
			View.AddSubview( moveBtn );
		}

	}
}

