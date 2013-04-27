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
	public partial class TempViewController : BaseDetailViewController
	{
		CALayer logoLayer;
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
			initButtons ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return true;
		}

		void initUI ()
		{
			logoLayer = new LogoLayer ();
			logoLayer.Frame = new RectangleF (20, 60, logoLayer.Contents.Width, logoLayer.Contents.Height);
			View.Layer.AddSublayer (logoLayer);

			logoView = new LogoView ();
			logoView.Frame = new RectangleF (20, 240, 100, 100);
			View.AddSubview (logoView);

		}

		void initButtons ()
		{
			var moveBtn = UIButton.FromType (UIButtonType.RoundedRect);
			moveBtn.Frame = new RectangleF (View.Bounds.Width - 240, 60, 200, 40);
			moveBtn.SetTitle ("Move X", UIControlState.Normal);
			moveBtn.TouchUpInside += (object sender, EventArgs e) => {
				if (logoView.Layer.PresentationLayer.Position.X < 400) {
					Rouse.To (logoView, 1, new RouseLib.KeyPaths{ PositionX = 400}, Easing.EaseInExpo);

//					Rouse.To (logoLayer, 1, new RouseLib.KeyPaths{ PositionX = 400}, Easing.EaseInExpo);
					var localTime = CAAnimation.CurrentMediaTime ();
					
					var ka = new CAKeyFrameAnimation ();
					ka.KeyPath = "position.x";
					ka.BeginTime = 0;
					ka.Duration = 1;
					ka.TimingFunction = CAMediaTimingFunction.FromName (CAMediaTimingFunction.Linear);
					ka.Values = KeyFrameUtils.CreateKeyValues (logoLayer.Position.X, 400f, RouseLib.Easing.EaseInExpo);
					
//					var ka2 = new CAKeyFrameAnimation ();
//					ka2.KeyPath = "opacity";
//					ka2.BeginTime = 0;
//					ka2.Duration = 1;
//					ka2.TimingFunction = CAMediaTimingFunction.FromName (CAMediaTimingFunction.Linear);
//					ka2.Values = KeyFrameUtils.CreateKeyValues (1, 0.2f, RouseLib.Easing.EaseInExpo);
//					
					var group = CAAnimationGroup.CreateAnimation ();
					group.BeginTime = localTime;
					group.Duration = 1;
					group.FillMode = CAFillMode.Forwards;
					group.RemovedOnCompletion = false;
					group.Animations = new CAAnimation[]{ ka };
					logoLayer.AddAnimation (group, null);

				} else {
					Rouse.To (logoView, 1, new RouseLib.KeyPaths{ PositionX = 70}, Easing.EaseOutExpo);

//					Rouse.To (logoLayer, 1, new RouseLib.KeyPaths{ PositionX = 70}, Easing.EaseOutExpo);
					var localTime = CAAnimation.CurrentMediaTime ();
					
					var ka = new CAKeyFrameAnimation ();
					ka.KeyPath = "position.x";
					ka.BeginTime = 0;
					ka.Duration = 1;
					ka.TimingFunction = CAMediaTimingFunction.FromName (CAMediaTimingFunction.Linear);
					ka.Values = KeyFrameUtils.CreateKeyValues (logoLayer.PresentationLayer.Position.X, 70f, RouseLib.Easing.EaseOutExpo);
					
					//					var ka2 = new CAKeyFrameAnimation ();
					//					ka2.KeyPath = "opacity";
					//					ka2.BeginTime = 0;
					//					ka2.Duration = 1;
					//					ka2.TimingFunction = CAMediaTimingFunction.FromName (CAMediaTimingFunction.Linear);
					//					ka2.Values = KeyFrameUtils.CreateKeyValues (1, 0.2f, RouseLib.Easing.EaseInExpo);
					//					
					var group = CAAnimationGroup.CreateAnimation ();
					group.BeginTime = localTime;
					group.Duration = 1;
					group.FillMode = CAFillMode.Forwards;
					group.RemovedOnCompletion = false;
					group.Animations = new CAAnimation[]{ ka };
					logoLayer.AddAnimation (group, null);
				}

			};
			View.AddSubview (moveBtn);
		}

	}
}

