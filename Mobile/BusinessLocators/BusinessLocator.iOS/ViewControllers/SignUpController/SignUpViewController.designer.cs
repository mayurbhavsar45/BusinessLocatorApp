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
    [Register ("SignUpViewController")]
    partial class SignUpViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView blPickerView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView borderDDL { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView borderEmail { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView borderMobileNumber { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView borderPassword { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView borderUserName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnBack { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSignUp { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtEmail { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtMobileNumber { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtPassword { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtUserName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (blPickerView != null) {
                blPickerView.Dispose ();
                blPickerView = null;
            }

            if (borderDDL != null) {
                borderDDL.Dispose ();
                borderDDL = null;
            }

            if (borderEmail != null) {
                borderEmail.Dispose ();
                borderEmail = null;
            }

            if (borderMobileNumber != null) {
                borderMobileNumber.Dispose ();
                borderMobileNumber = null;
            }

            if (borderPassword != null) {
                borderPassword.Dispose ();
                borderPassword = null;
            }

            if (borderUserName != null) {
                borderUserName.Dispose ();
                borderUserName = null;
            }

            if (btnBack != null) {
                btnBack.Dispose ();
                btnBack = null;
            }

            if (btnSignUp != null) {
                btnSignUp.Dispose ();
                btnSignUp = null;
            }

            if (txtEmail != null) {
                txtEmail.Dispose ();
                txtEmail = null;
            }

            if (txtMobileNumber != null) {
                txtMobileNumber.Dispose ();
                txtMobileNumber = null;
            }

            if (txtPassword != null) {
                txtPassword.Dispose ();
                txtPassword = null;
            }

            if (txtUserName != null) {
                txtUserName.Dispose ();
                txtUserName = null;
            }
        }
    }
}