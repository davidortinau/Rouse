using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace Controls
{
	public class LogoView : UIImageView
	{
		public LogoView ()
		{
			this.Frame = new RectangleF (0, 0, 100, 100);
//			this.Image = UIImage.FromBundle ("icon-100.png");
			this.BackgroundColor = UIColor.Clear.FromHex(0xFF3300);
		}


	}
}

