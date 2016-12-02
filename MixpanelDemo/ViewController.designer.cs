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

namespace MixpanelDemo
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel floatLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel helloLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel intLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (floatLabel != null) {
                floatLabel.Dispose ();
                floatLabel = null;
            }

            if (helloLabel != null) {
                helloLabel.Dispose ();
                helloLabel = null;
            }

            if (intLabel != null) {
                intLabel.Dispose ();
                intLabel = null;
            }
        }
    }
}