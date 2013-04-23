using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;
using MonoTouch.CoreGraphics;
using System;

/// <summary>
/// Rouse generates animation blocks and applies them to a target object
/// </summary>
using MonoTouch.Foundation;
using Easing;

//namespace {
using RouseLib.Utils;
using System.Reflection;
using RouseLib;
using System.Collections.Generic;


public class Rouse
{

	public static void To(object target, 
	                      float duration, 
	                      object properties)
	{
		To (target, duration, properties, null, null, null);
	}

	public static void To(object target, 
	                      float duration, 
	                      object properties, 
	                      EasingFormula easing = null, 
	                      Action onComplete = null)
	{
		To (target, duration, properties, null, easing, onComplete);
	}

	public static void To(object target, 
	                      float duration, 
	                      object properties, 
	                      object options = null, 
	                      EasingFormula easing = null, 
	                      Action onComplete = null)
	{
		CALayer layer;
		if(TypeUtils.IsUIView(target)){
			layer = (target as UIView).Layer;
		}else{
			layer = target as CALayer;
		}

		if (easing == null){
			easing = Easing.Easing.EaseInSine;
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
		foreach(PropertyInfo propertyInfo in properties.GetType().GetProperties())
		{
			if (propertyInfo.CanRead)
			{
				var ka = new CAKeyFrameAnimation();
				ka.KeyPath = LayerUtils.GetKeyPath(propertyInfo.Name);
				ka.Duration = duration;
//				ka.BeginTime = localTime;

				var fromValue = LayerUtils.GetCurrentValue(layer, propertyInfo.Name);
				var toValue = Convert.ToSingle( propertyInfo.GetValue(properties, null) );
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