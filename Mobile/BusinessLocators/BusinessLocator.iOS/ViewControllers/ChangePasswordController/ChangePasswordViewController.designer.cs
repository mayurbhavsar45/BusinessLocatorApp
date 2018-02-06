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
    [Register ("ChangePasswordViewController")]
    partial class ChangePasswordViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView borderConfirmPassword { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView borderNewPassword { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnBack { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSavePassword { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ChangePasswordView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblChangePassword { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblDescript { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtConfirmPassword { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtNewPassword { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (borderConfirmPassword != null) {
                borderConfirmPassword.Dispose ();
                borderConfirmPassword = null;
            }

            if (borderNewPassword != null) {
                borderNewPassword.Dispose ();
                borderNewPassword = null;
            }

            if (btnBack != null) {
                btnBack.Dispose ();
                btnBack = null;
            }

            if (btnSavePassword != null) {
                btnSavePassword.Dispose ();
                btnSavePassword = null;
            }

            if (ChangePasswordView != null) {
                ChangePasswordView.Dispose ();
                ChangePasswordView = null;
            }

            if (lblChangePassword != null) {
                lblChangePassword.Dispose ();
                lblChangePassword = null;
            }

            if (lblDescript != null) {
                lblDescript.Dispose ();
                lblDescript = null;
            }

            if (txtConfirmPassword != null) {
                txtConfirmPassword.Dispose ();
                txtConfirmPassword = null;
            }

            if (txtNewPassword != null) {
                txtNewPassword.Dispose ();
                txtNewPassword = null;
            }
        }
    }
}