
using System;
using NUnit.Framework;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.CoreAnimation;
using RouseLib.Utils;


namespace RouseTests
{
	[TestFixture]
	public class TypeUtilsTests
	{
		[Test]
		public void RouseCanGetTypeOfUIViewForUIView()
		{
			var view = new UIView( new RectangleF(0, 0, 100, 100) );

			Assert.True(TypeUtils.IsUIView(view));

		}

		[Test]
		public void RouseCanGetTypeOfUIViewForUIButton()
		{
			var view = new UIButton( new RectangleF(0, 0, 100, 100) );

			Assert.True(TypeUtils.IsUIView(view));
			
		}

		[Test]
		public void RouseCanTellCALayerIsNotUIView()
		{
			var layer = new CALayer();

			Assert.False(TypeUtils.IsUIView(layer));
			
		}
	}
}
