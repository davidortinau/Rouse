using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;

namespace RouseSamples
{
	public partial class RouseSamplesViewController : UIViewController
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
			logo.Frame = new RectangleF(20, 20, logo.Contents.Width, logo.Contents.Height);
			View.Layer.AddSublayer( logo );
		}

		void initButtons()
		{
			var moveBtn = new UIButton( UIButtonType.RoundedRect );
			moveBtn.Frame = new RectangleF(550, 20, 200, 40);
			moveBtn.SetTitle("Move X", UIControlState.Normal);
			moveBtn.TouchUpInside += (object sender, EventArgs e) => {
				if(logo.PresentationLayer.Position.X < 400){
					Rouse.To (logo, 1, new RouseLib.KeyPaths{ PositionX = 400});
				}else{
					Rouse.To (logo, 1, new RouseLib.KeyPaths{ PositionX = 20});
				}
			};
			View.AddSubview( moveBtn );

			var alphaBtn = new UIButton( UIButtonType.RoundedRect );
			alphaBtn.Frame = new RectangleF(550, 80, 200, 40);
			alphaBtn.SetTitle("Alpha", UIControlState.Normal);
			alphaBtn.TouchUpInside += (object sender, EventArgs e) => {
				if(logo.PresentationLayer.Opacity > 0){
					Rouse.To (logo, 1, new RouseLib.KeyPaths{ Opacity = 0});
				}else{
					Rouse.To (logo, 1, new RouseLib.KeyPaths{ Opacity = 1});
				}
			};
			View.AddSubview( alphaBtn );
		}

	}
}

