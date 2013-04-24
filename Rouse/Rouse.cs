using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;
using MonoTouch.CoreGraphics;
using System;

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

		if (easing == null){
			easing = Easing.EaseInSine;
		}

		// if more than one property, need a group...maybe just make a group anyway
		var localTime = CAAnimation.CurrentMediaTime();

		var group = new CAAnimationGroup();
		group.BeginTime = localTime; // TODO + delay from options...
		group.Duration = duration;
		group.FillMode = CAFillMode.Forwards;
		group.RemovedOnCompletion = false;
		if(onComplete != null){
			group.AnimationStopped += (object sender, CAAnimationStateEventArgs e) => {
				onComplete.Invoke();
			};
		}

		var animations = new List<CAKeyFrameAnimation>();
		var propType = properties.GetType();
		foreach(var field in propType.GetFields(BindingFlags.Instance | 
		                                                        BindingFlags.NonPublic |
		                                                        BindingFlags.Public))
		{
			// TODO if property value null, bypass it
			if (field.GetValue(properties) != null)
			{
				var ka = new CAKeyFrameAnimation();
				ka.KeyPath = LayerUtils.GetKeyPath(field.Name);
				ka.Duration = duration;
//				ka.BeginTime = localTime;

				var fromValue = LayerUtils.GetCurrentValue(layer, field.Name);
				var toValue = Convert.ToSingle( field.GetValue(properties) );
				ka.Values = KeyFrameUtils.CreateKeyValues((float)fromValue, (float)toValue, easing);

				ka.FillMode = CAFillMode.Forwards;
				ka.RemovedOnCompletion = false;
				ka.TimingFunction = CAMediaTimingFunction.FromName( CAMediaTimingFunction.Linear );

				animations.Add( ka );
			}
		}

		group.Animations = animations.ToArray();
		layer.AddAnimation( group, "rouseAnimations" );

		// now set the final properties on the layer?
	}
}
//}