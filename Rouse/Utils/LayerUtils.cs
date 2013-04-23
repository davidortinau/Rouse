using System;
using MonoTouch.CoreAnimation;
using System.Collections.Generic;

namespace RouseLib
{
	public class LayerUtils
	{
		public static Dictionary<string, string> KeyPaths = new Dictionary<string, string> ()
		{
			{"x", "position.x"},
			{"y", "position.y"},
			{"positionx", "position.x"},
			{"positiony", "position.y"},
			{"alpha", "alpha"},
			{"rotationx", "rotation.x"},
			{"rotationy", "rotation.y"},
			{"rotationz", "rotation.z"},
			{"rotation", "rotation"},
			{"scale", "scale"},
			{"scalex", "scale.x"},
			{"scaley", "scale.y"},
			{"scalez", "scale.z"},
			{"translation", "translation"},
			{"translationx", "translation.x"},
			{"translationy", "translation.y"},
			{"translationz", "translation.z"},
			{"width", "width"},
			{"height", "height"},// CGSize
			{"origin", "origin"},// CGRect
			{"originx", "origin.x"},// CGRect
			{"originy", "origin.y"},// CGRect
			{"size", "size"},// CGRect
			{"sizewidth", "size.width"},// CGRect
			{"sizeheight", "size.height"}// CGRect
		};

		public static float GetCurrentValue (CALayer layer, string propertyName)
		{
			switch (propertyName) {
			case "positionx":
				return layer.Position.X;
			case "positiony":
				return layer.Position.Y;
			case "alpha":
				return layer.Opacity;
			default:
				return 0;
			}
		}

		public static string GetKeyPath (string name)
		{
			if (!KeyPaths.ContainsKey (name)) {
				throw new NotImplementedException ();
			} else {
				return KeyPaths [name] as string;
			}
		}
	}
}

