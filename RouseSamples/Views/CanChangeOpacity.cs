
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;
using RouseLib;

namespace RouseSamples
{
	public partial class CanChangeOpacity : BaseDetailViewController
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
			
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			initUI();
			initButtons();
		}

		void initUI ()
		{
			logo = new CALayer();
			logo.Contents = UIImage.FromBundle("icon-100.png").CGImage;
			logo.Frame = new RectangleF(20, 60, logo.Contents.Width, logo.Contents.Height);
			View.Layer.AddSublayer( logo );

			logoView = new UIImageView( new RectangleF(20, 200, 100, 100));
			logoView.Image = UIImage.FromBundle("icon-100.png");
			View.AddSubview( logoView );
		}

		void initButtons()
		{
			var btn = new UIButton( UIButtonType.RoundedRect );
			btn.Frame = new RectangleF(View.Bounds.Width - 340, 60, 200, 40);
			btn.SetTitle("Toggle Opacity", UIControlState.Normal);
			btn.TouchUpInside += (object sender, EventArgs e) => {
				if(logo.PresentationLayer.Opacity > 0){
					Rouse.To (logo, 1, new KeyPaths{ Opacity = 0}, Easing.EaseInExpo);
					Rouse.To (logoView, 1, new KeyPaths{ Opacity = 0}, Easing.EaseInExpo); // TODO pass multiple targets to animation
				}else{
					Rouse.To (logo, 1, new KeyPaths{ Opacity = 1}, Easing.EaseOutExpo);
					Rouse.To (logoView, 1, new KeyPaths{ Opacity = 1}, Easing.EaseInExpo);
				}
			};
			View.AddSubview( btn );
		}
	}
}

