using FloatLabeledEntry;
using MonoTouch.Dialog;
using UIKit;

namespace FLEDemo.iOS
{
	public class DialogDemoViewController : DialogViewController
	{
		public DialogDemoViewController() 
			: base(UITableViewStyle.Grouped, null, true)
		{
			Root = new RootElement("Dialog")
			{
				new Section
				{
					new FloatLabeledEntryElement("First Name"),
					new FloatLabeledEntryElement("Password", isPassword: true),
					new FloatLabeledEntryElement("Prefilled value", value: "Foo bar baz")
				}
			};
		}
	}
}