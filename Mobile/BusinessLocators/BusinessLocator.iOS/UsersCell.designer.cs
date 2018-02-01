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
    [Register ("UsersCell")]
    partial class UsersCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblAddress { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblMobileNumber { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ProfileImage { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblAddress != null) {
                lblAddress.Dispose ();
                lblAddress = null;
            }

            if (lblMobileNumber != null) {
                lblMobileNumber.Dispose ();
                lblMobileNumber = null;
            }

            if (lblName != null) {
                lblName.Dispose ();
                lblName = null;
            }

            if (ProfileImage != null) {
                ProfileImage.Dispose ();
                ProfileImage = null;
            }
        }
    }
}