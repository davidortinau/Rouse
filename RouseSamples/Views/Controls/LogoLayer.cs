using System;
using MonoTouch.CoreAnimation;
using MonoTouch.Foundation;
using MonoTouch.CoreGraphics;
using MonoTouch.UIKit;
using System.Drawing;

namespace Controls
{
	public class LogoLayer : CALayer
	{
		public LogoLayer ()
		{
			this.Contents = UIImage.FromBundle("icon-100.png").CGImage;
			this.Frame = new RectangleF(0, 0, this.Contents.Width, this.Contents.Height);
		}

		[Export ("initWithLayer:")]
		public LogoLayer (CALayer other)
			: base (other)
		{
		}
		
		public override void Clone (CALayer other)
		{
			LogoLayer o = (LogoLayer) other;
			base.Clone (other);
		}
		
		public override void DrawInContext (CGContext context)
		{
			base.DrawInContext (context);


		}
	}
}

