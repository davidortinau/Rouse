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
			{"opacity", "opacity"},
			{"rotationx", "rotation.x"},
			{"rotationy", "rotation.y"},
			{"rotationz", "rotation.z"},
			{"rotation", "rotation"},
			{"scale", "transform.scale"},
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
			switch (propertyName.ToLower()) {
			case "positionx":
				return layer.PresentationLayer.Position.X;
			case "positiony":
				return layer.PresentationLayer.Position.Y;
			case "opacity":
				return layer.PresentationLayer.Opacity;
			case "scale":
				return layer.PresentationLayer.Transform.m11;
//			case "rotation":
//				return layer.Transform.Rotate;
//			case "translation":
//				return layer.Transform.Translate;
			default:
				return 0;
			}
		}

		public static string GetKeyPath (string name)
		{
			if (!KeyPaths.ContainsKey (name.ToLower())) {
				throw new NotImplementedException ();
			} else {
				return KeyPaths [name.ToLower()] as string;
			}
		}
	}
}

