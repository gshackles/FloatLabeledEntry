// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace FLEDemo.iOS
{
    [Register ("StoryboardViewController")]
    partial class StoryboardViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        FloatLabeledEntry.FloatLabeledTextField FirstName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        FloatLabeledEntry.FloatLabeledTextField LastName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (FirstName != null) {
                FirstName.Dispose ();
                FirstName = null;
            }

            if (LastName != null) {
                LastName.Dispose ();
                LastName = null;
            }
        }
    }
}