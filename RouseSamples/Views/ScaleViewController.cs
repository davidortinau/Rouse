
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;
using RouseLib;
using Controls;

namespace RouseSamples
{
	public partial class ScaleViewController : BaseDetailViewController
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
			
			initUI();
			initButtons();
		}

		void initUI ()
		{			
			logo = new LogoLayer();
			logo.Frame = new RectangleF( View.Center.X - logo.Frame.Width * 0.5f, View.Center.Y - 150, logo.Frame.Width, logo.Frame.Height);
			View.Layer.AddSublayer( logo );

			logoView = new LogoView();
			logoView.Frame = new RectangleF( View.Center.X - logoView.Frame.Width * 0.5f, View.Center.Y + 150, logoView.Frame.Width, logoView.Frame.Height);
			View.AddSubview( logoView );
			
		}
		
		void initButtons()
		{
			var moveBtn = new UIButton( UIButtonType.RoundedRect );
			moveBtn.Frame = new RectangleF(View.Bounds.Width * 0.5f - 100, 60, 200, 40);
			moveBtn.SetTitle("Scale", UIControlState.Normal);
			moveBtn.TouchUpInside += (object sender, EventArgs e) => {
				if(logoView.Layer.PresentationLayer.Frame.Width < 200){
					Rouse.To (logoView, 1, new KeyPaths{ Scale = 2}, Easing.EaseInExpo);
					Rouse.To (logo, 1, new KeyPaths{ Scale = 2}, Easing.EaseInExpo);
				}else{
					Rouse.To (logoView, 1, new KeyPaths{ Scale = 1}, Easing.EaseOutExpo);
					Rouse.To (logo, 1, new KeyPaths{ Scale = 1}, Easing.EaseOutExpo);
				}
			};
			View.AddSubview( moveBtn );
		}
	}
}

