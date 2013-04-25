using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;
using RouseLib.Utils;
using RouseLib;

namespace RouseSamples
{
	public partial class RouseSamplesViewController : UIViewController
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
			logo.Frame = new RectangleF(20, 20, logo.Contents.Width, logo.Contents.Height);
			View.Layer.AddSublayer( logo );

			logoView = new UIImageView( new RectangleF(20, 200, 100, 100));
			logoView.Image = UIImage.FromBundle("icon-100.png");
			View.AddSubview( logoView );

		}

		void initButtons()
		{
			var moveBtn = new UIButton( UIButtonType.RoundedRect );
			moveBtn.Frame = new RectangleF(550, 20, 200, 40);
			moveBtn.SetTitle("Move X", UIControlState.Normal);
			moveBtn.TouchUpInside += (object sender, EventArgs e) => {
				Console.WriteLine("Frame.X {0} or Position.X {1}", logoView.Layer.PresentationLayer.Frame.X, logoView.Layer.PresentationLayer.Position.X);
				if(logoView.Layer.PresentationLayer.Position.X < 400){
					Console.WriteLine("go right");
					Rouse.To (logoView, 1, new RouseLib.KeyPaths{ PositionX = 400, Opacity = 0.2}, Easing.EaseInExpo);
//					logoView.Layer.Frame = new RectangleF(400, 200, 100, 100);
				}else{
					Console.WriteLine("go left");
					Rouse.To (logoView, 1, new RouseLib.KeyPaths{ PositionX = 70, Opacity = 1}, Easing.EaseOutExpo);
//					logoView.Layer.Frame = new RectangleF(20, 200, 100, 100);
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

