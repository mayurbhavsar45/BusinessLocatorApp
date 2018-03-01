// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BusinessLocator.iOS
{
    [Register ("CustomView")]
    partial class CustomView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblMobileNumber { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        BusinessLocator.iOS.CustomView rootView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblMobileNumber != null) {
                lblMobileNumber.Dispose ();
                lblMobileNumber = null;
            }

            if (lblName != null) {
                lblName.Dispose ();
                lblName = null;
            }

            if (rootView != null) {
                rootView.Dispose ();
                rootView = null;
            }
        }
    }
}