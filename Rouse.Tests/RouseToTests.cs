
using System;
using NUnit.Framework;
using MonoTouch.CoreAnimation;
using System.Drawing;

namespace RouseTests
{
	[TestFixture]
	public class RouseToTests
	{
		[Test]
		public void RouseCanTakeTargetDurationAndProperties ()
		{
			var layer = new CALayer{
				Frame = new RectangleF(20, 20, 100, 100)
			};
			Rouse.To(layer, 1, new {positionx = 120});

			Assert.AreEqual(1, layer.AnimationKeys.Length);
		}

	}
}
