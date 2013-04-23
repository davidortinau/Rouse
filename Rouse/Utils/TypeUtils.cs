using System;
using MonoTouch.UIKit;

namespace RouseLib.Utils
{
	public class TypeUtils
	{
		/// <summary>
		/// Attempts to cast the target as UIView and checks to see if it succeeds
		/// </summary>
		public static bool IsUIView(object target)
		{
//			var instance = target as UIView;
//			return instance != null;
			return target is UIView;
		}
	}
}

