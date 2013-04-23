
using System;
using NUnit.Framework;

namespace RouseTests
{
	[TestFixture]
	public class PropertiesTests
	{
		[Test]
		public void CanCreatePropertiesObject ()
		{
			var properties = new {positionx = 20f,alpha = 1};

			Assert.AreEqual(20f, properties.positionx);
			Assert.AreEqual(1, properties.alpha);
		}
	}
}
