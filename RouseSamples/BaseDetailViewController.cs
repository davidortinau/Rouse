
using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using System.Drawing;

namespace RouseSamples
{
	public partial class BaseDetailViewController : UIViewController
	{
		UIToolbar toolbar;
		public UIPopoverController Popover {get;set;}

		public BaseDetailViewController () : base ()
		{
			View.BackgroundColor = UIColor.White;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			toolbar = new UIToolbar(new RectangleF(0, 0, View.Frame.Width, 30));
			toolbar.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
			View.AddSubview(toolbar);
		}

		/// <summary>
		/// Shows the button that allows access to the master view popover
		/// </summary>
		public void AddContentsButton (UIBarButtonItem button)
		{
			button.Title = "Contents";
			toolbar.SetItems (new UIBarButtonItem[] { button }, false );
		}
		
		/// <summary>
		/// Hides the button that allows access to the master view popover
		/// </summary>
		public void RemoveContentsButton ()
		{
			toolbar.SetItems (new UIBarButtonItem[0], false);
		}

//		public void Update (string text) {
////			label.Text = String.Format (content, text);
//			// dismiss the popover if currently visible
//			if (Popover != null)
//				Popover.Dismiss (true);
//		}
	}
}
