
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;
using RouseLib;
using Controls;

namespace RouseSamples
{
	public partial class PositionYViewController : BaseDetailViewController
	{
		UIImageView logoView;

		LogoLayer logoLayer;

		public PositionYViewController () : base ()
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
			
			initUI();
			initButtons();
		}

		void initUI ()
		{			
			logoLayer = new LogoLayer();
			logoLayer.Frame = new RectangleF(140, 60, 100, 100);
			logoLayer.AnchorPoint = new PointF(0,0);
			View.Layer.AddSublayer( logoLayer )
;
			logoView = new LogoView();
			logoView.Frame = new RectangleF(20, 60, 100, 100);
			logoView.Layer.AnchorPoint = new PointF(0,0);
			View.AddSubview( logoView );
			
		}
		
		void initButtons()
		{
			var moveBtn = new UIButton( UIButtonType.RoundedRect );
			moveBtn.Frame = new RectangleF(View.Bounds.Width - 240, 60, 200, 40);
			moveBtn.SetTitle("Move Y", UIControlState.Normal);
			moveBtn.TouchUpInside += (object sender, EventArgs e) => {
				if(logoView.Layer.PresentationLayer.Position.Y < 400){
					Rouse.To (logoView, 1, new RouseLib.KeyPaths{ PositionY = 400}, Easing.EaseInExpo);
					Rouse.To (logoLayer, 1, new RouseLib.KeyPaths{ PositionY = 400}, Easing.EaseInExpo);
				}else{
					Rouse.To (logoView, 1, new RouseLib.KeyPaths{ PositionY = 60}, Easing.EaseOutExpo);
					Rouse.To (logoLayer, 1, new RouseLib.KeyPaths{ PositionY = 60}, Easing.EaseOutExpo);
				}
			};
			View.AddSubview( moveBtn );
		}
	}
}

