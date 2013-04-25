using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;
using MonoTouch.CoreGraphics;
using System;
using System.Drawing;

/// <summary>
/// Rouse generates animation blocks and applies them to a target object
/// </summary>
using MonoTouch.Foundation;

//namespace {
using RouseLib.Utils;
using System.Reflection;
using RouseLib;
using System.Collections.Generic;


public class Rouse
{

	public static void To(object target, 
	                      float duration, 
	                      KeyPaths properties)
	{
		To (target, duration, properties, null, Easing.EaseInExpo, null);
	}

	public static void To(object target, 
	                      float duration, 
	                      KeyPaths properties, 
	                      EasingFormula easing)
	{
		To (target, duration, properties, null, easing, null);
	}

	public static void To(object target, 
	                      float duration, 
	                      KeyPaths properties, 
	                      object options, 
	                      EasingFormula easing, 
	                      Action onComplete)
	{
		CALayer layer;
		if(TypeUtils.IsUIView(target)){
			layer = (target as UIView).Layer;
		}else{
			layer = target as CALayer;
		}

//		layer.RemoveAllAnimations(); // kill any previous animations hanging around

		if (easing == null){
			easing = Easing.EaseInSine;
		}

		var animations = new List<CAKeyFrameAnimation>();
		var propType = properties.GetType();
		foreach(var field in propType.GetFields(BindingFlags.Instance | 
		                                                        BindingFlags.NonPublic |
		                                                        BindingFlags.Public))
		{
			if (field.GetValue(properties) != null)
			{
				var ka = new CAKeyFrameAnimation();
				ka.KeyPath = LayerUtils.GetKeyPath(field.Name);
				ka.Duration = duration;
				ka.TimingFunction = CAMediaTimingFunction.FromName( CAMediaTimingFunction.Linear );

				var fromValue = LayerUtils.GetCurrentValue(layer, field.Name);
				var toValue = Convert.ToSingle( field.GetValue(properties) );
				ka.Values = KeyFrameUtils.CreateKeyValues((float)fromValue, (float)toValue, easing);

				animations.Add( ka );
				setLayerProperties(layer, field.Name, toValue);
			}
		}

		var localTime = CAAnimation.CurrentMediaTime();
		var group = CAAnimationGroup.CreateAnimation();
		group.BeginTime = localTime; // TODO + delay from options...
		group.Duration = duration;
		group.FillMode = CAFillMode.Forwards;
		group.RemovedOnCompletion = false;
		//		group.AutoReverses = false;
		//		group.RepeatCount = 0;
		
		if(onComplete != null){
			group.AnimationStopped += (object sender, CAAnimationStateEventArgs e) => {
				onComplete.Invoke();
			};
		}

		group.Animations = animations.ToArray();
		layer.AddAnimation( group, null );
	}

	static void setLayerProperties (CALayer layer, string name, float toValue)
	{
//		layer.SetValueForKeyPath(NSNumber.FromFloat(toValue), (NSString)name);
		switch(name){
		case "PositionX":
			layer.Frame = new RectangleF(new PointF(toValue - (layer.Frame.Width * layer.AnchorPoint.X), layer.Frame.Y), layer.Frame.Size);
			break;
		case "Opacity":
			layer.Opacity = toValue;
			break;
		}
	}
}
//}