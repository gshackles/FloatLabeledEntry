using UIKit;
using FloatLabeledEntry;
using CoreGraphics;

namespace FLEDemo.iOS
{
	public class MainViewController : UIViewController
	{
		private const float FieldHeight = 44.0f;
		private const float FieldHMargin = 10.0f;
		private const float FieldFontSize = 16.0f;
		private const float FieldFloatingLabelFontSize = 11.0f;

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			Title = "Floating Label Demo";

			View.BackgroundColor = UIColor.White;

			float topOffset = (float)(UIApplication.SharedApplication.StatusBarFrame.Size.Height + NavigationController.NavigationBar.Frame.Size.Height);
			UIColor floatingLabelColor = UIColor.Gray, floatingLabelActiveColor = UIColor.Blue;

			var titleField = new FloatLabeledTextField(new CGRect(FieldHMargin, topOffset, 
				View.Frame.Size.Width - 2 * FieldHMargin, 
				FieldHeight))
			{
				Placeholder = "Title",
				Font = UIFont.SystemFontOfSize(FieldFontSize),
				ClearButtonMode = UITextFieldViewMode.WhileEditing,
				FloatingLabelFont = UIFont.BoldSystemFontOfSize(FieldFloatingLabelFontSize),
				FloatingLabelTextColor = floatingLabelColor,
				FloatingLabelActiveTextColor = floatingLabelActiveColor
			};
			View.AddSubview(titleField);

			var div1 = new UIView(new CGRect(FieldHMargin, 
				titleField.Frame.Y + titleField.Frame.Size.Height, 
				View.Frame.Size.Width - 2 * FieldHMargin, 1))
			{
				BackgroundColor = UIColor.LightGray.ColorWithAlpha(0.3f)
			};
			View.AddSubview(div1);

			var priceField = new FloatLabeledTextField(new CGRect(FieldHMargin, 
				div1.Frame.Y + div1.Frame.Size.Height, 
				80, FieldHeight))
			{
				Placeholder = "Price",
				Font = UIFont.SystemFontOfSize(FieldFontSize),
				FloatingLabelFont = UIFont.BoldSystemFontOfSize(FieldFloatingLabelFontSize),
				FloatingLabelTextColor = floatingLabelColor,
				FloatingLabelActiveTextColor = floatingLabelActiveColor,
				Text = "3.14"
			};
			View.AddSubview(priceField);

			var div2 = new UIView(new CGRect(FieldHMargin + priceField.Frame.Size.Width, 
				titleField.Frame.Y + titleField.Frame.Size.Height, 
				1, FieldHeight))
			{
				BackgroundColor = UIColor.LightGray.ColorWithAlpha(0.3f)
			};
			View.AddSubview(div2);

			var locationField = new FloatLabeledTextField(new CGRect(FieldHMargin + FieldHMargin + priceField.Frame.Size.Width + 1.0f, 
				div1.Frame.Y + div1.Frame.Size.Height,
				View.Frame.Size.Width - 3 * FieldHMargin - priceField.Frame.Size.Width - 1.0f, 
				FieldHeight))
			{
				Placeholder = "Specific Location (optional)",
				Font = UIFont.SystemFontOfSize(FieldFontSize),
				FloatingLabelFont = UIFont.BoldSystemFontOfSize(FieldFloatingLabelFontSize),
				FloatingLabelTextColor = floatingLabelColor,
				FloatingLabelActiveTextColor = floatingLabelActiveColor
			};
			View.AddSubview(locationField);

			var div3 = new UIView(new CGRect(FieldHMargin, 
				priceField.Frame.Y + priceField.Frame.Size.Height,
				View.Frame.Size.Width - 2 * FieldHMargin, 1))
			{
				BackgroundColor = UIColor.LightGray.ColorWithAlpha(0.3f)
			};
			View.AddSubview(div3);

			var descriptionField = new FloatLabeledTextField(new CGRect(FieldHMargin, 
				div3.Frame.Y + div3.Frame.Size.Height,
				View.Frame.Size.Width - 2 * FieldHMargin, 
				FieldHeight))
			{
				Placeholder = "Description",
				Font = UIFont.SystemFontOfSize(FieldFontSize),
				FloatingLabelFont = UIFont.BoldSystemFontOfSize(FieldFloatingLabelFontSize),
				FloatingLabelTextColor = floatingLabelColor,
				FloatingLabelActiveTextColor = floatingLabelActiveColor
			};
			View.AddSubview(descriptionField);

			titleField.BecomeFirstResponder();

			NavigationItem.RightBarButtonItem = new UIBarButtonItem("Dialog Demo", UIBarButtonItemStyle.Plain, 
				(s, a) => NavigationController.PushViewController(new DialogDemoViewController(), true));
		}
	}
}