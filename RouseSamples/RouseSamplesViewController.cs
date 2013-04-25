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
				Console.WriteLine("Frame.X {0}", logo.PresentationLayer.Frame.X);
				if(logoView.Layer.PresentationLayer.Frame.X < 400){
//					var localTime = CAAnimation.CurrentMediaTime();
//
//					var ka = new CAKeyFrameAnimation();
//					ka.KeyPath = "position.x";
//					ka.BeginTime = 0;
//					ka.Duration = 1;
//					ka.TimingFunction = CAMediaTimingFunction.FromName( CAMediaTimingFunction.Linear );
//					ka.Values = KeyFrameUtils.CreateKeyValues(logoView.Layer.Position.X, 400f, RouseLib.Easing.EaseInExpo);
//
//					var ka2 = new CAKeyFrameAnimation();
//					ka2.KeyPath = "opacity";
//					ka2.BeginTime = 0;
//					ka2.Duration = 1;
//					ka2.TimingFunction = CAMediaTimingFunction.FromName( CAMediaTimingFunction.Linear );
//					ka2.Values = KeyFrameUtils.CreateKeyValues(1, 0.2f, RouseLib.Easing.EaseInExpo);
//
//					var group = CAAnimationGroup.CreateAnimation();
//					group.BeginTime = localTime;
//					group.Duration = 1;
//					group.FillMode = CAFillMode.Forwards;
//					group.RemovedOnCompletion = false;
//					group.Animations = new CAAnimation[]{ ka, ka2 };
//					logoView.Layer.AddAnimation( group, null );

					Console.WriteLine("GO");
					Rouse.To (logo, 1, new RouseLib.KeyPaths{ PositionX = 400, Opacity = 0.2}, Easing.EaseInExpo);
//					logoView.Frame = new RectangleF(400, 200, 100, 100);
				}else{
					Rouse.To (logoView, 1, new RouseLib.KeyPaths{ PositionX = 20, Opacity = 1});
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

