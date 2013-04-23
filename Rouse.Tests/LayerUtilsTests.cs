
using System;
using NUnit.Framework;
using RouseLib;
using MonoTouch.CoreAnimation;

namespace RouseTests
{
	[TestFixture]
	public class LayerUtilsTests
	{
		[Test]
		public void CanGetPropertyValueForName ()
		{
			CALayer layer = new CALayer();
			layer.Frame = new System.Drawing.RectangleF(new System.Drawing.PointF(20, 20), new System.Drawing.SizeF(200,400));

			float value = LayerUtils.GetCurrentValue(layer, "positionx");
			Assert.AreEqual(value, layer.Position.X);
		}

		[Test]
		public void CanGetPropertyValueForNameWithAnchorTopLeft ()
		{
			CALayer layer = new CALayer();
			layer.AnchorPoint = new System.Drawing.PointF(0,0);
			layer.Frame = new System.Drawing.RectangleF(new System.Drawing.PointF(20, 20), new System.Drawing.SizeF(200,400));

			
			float value = LayerUtils.GetCurrentValue(layer, "positionx");
			Assert.AreEqual(value, layer.Position.X);
		}


	}
}
