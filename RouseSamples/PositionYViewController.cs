
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;
using RouseLib;

namespace RouseSamples
{
	public partial class PositionYViewController : BaseDetailViewController
	{
		CALayer logo;

		UIImageView logoView;

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
			logoView = new UIImageView( new RectangleF(20, 60, 100, 100));
			logoView.Layer.AnchorPoint = new PointF(0,0);
			logoView.Image = UIImage.FromBundle("icon-100.png");
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
				}else{
					Rouse.To (logoView, 1, new RouseLib.KeyPaths{ PositionY = 60}, Easing.EaseOutExpo);
				}
			};
			View.AddSubview( moveBtn );
		}
	}
}

