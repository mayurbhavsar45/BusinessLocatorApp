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
    [Register ("ReportProviderViewController")]
    partial class ReportProviderViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnClose { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSubmit { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView DialogHeaderView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblDialogTitle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView MainView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView PickerView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ReportProviderDialogView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView ReportProviderPicker { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView reportTextArea { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnClose != null) {
                btnClose.Dispose ();
                btnClose = null;
            }

            if (btnSubmit != null) {
                btnSubmit.Dispose ();
                btnSubmit = null;
            }

            if (DialogHeaderView != null) {
                DialogHeaderView.Dispose ();
                DialogHeaderView = null;
            }

            if (lblDialogTitle != null) {
                lblDialogTitle.Dispose ();
                lblDialogTitle = null;
            }

            if (MainView != null) {
                MainView.Dispose ();
                MainView = null;
            }

            if (PickerView != null) {
                PickerView.Dispose ();
                PickerView = null;
            }

            if (ReportProviderDialogView != null) {
                ReportProviderDialogView.Dispose ();
                ReportProviderDialogView = null;
            }

            if (ReportProviderPicker != null) {
                ReportProviderPicker.Dispose ();
                ReportProviderPicker = null;
            }

            if (reportTextArea != null) {
                reportTextArea.Dispose ();
                reportTextArea = null;
            }
        }
    }
}