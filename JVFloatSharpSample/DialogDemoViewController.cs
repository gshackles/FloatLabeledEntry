using System;
using MonoTouch.Dialog;
using MonoTouch.UIKit;
using JVFloatSharp;

namespace JVFloatSharpSample
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
					new JVFloatLabeledEntryElement("First Name"),
					new JVFloatLabeledEntryElement("Password", isPassword: true),
					new JVFloatLabeledEntryElement("Prefilled value", value: "Foo bar baz")
				}
			};
        }
    }
}