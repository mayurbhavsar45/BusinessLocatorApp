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
    [Register ("SettingsViewController")]
    partial class SettingsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView AboutUsView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnAboutUs { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnBack { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnHelp { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnLogout { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView HelpView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblAboutUs { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblHelp { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblNotification { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTitle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView LogoutView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch notificationSwitch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView SettingsHeaderView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView SettingView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView SwitchHolderView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AboutUsView != null) {
                AboutUsView.Dispose ();
                AboutUsView = null;
            }

            if (btnAboutUs != null) {
                btnAboutUs.Dispose ();
                btnAboutUs = null;
            }

            if (btnBack != null) {
                btnBack.Dispose ();
                btnBack = null;
            }

            if (btnHelp != null) {
                btnHelp.Dispose ();
                btnHelp = null;
            }

            if (btnLogout != null) {
                btnLogout.Dispose ();
                btnLogout = null;
            }

            if (HelpView != null) {
                HelpView.Dispose ();
                HelpView = null;
            }

            if (lblAboutUs != null) {
                lblAboutUs.Dispose ();
                lblAboutUs = null;
            }

            if (lblHelp != null) {
                lblHelp.Dispose ();
                lblHelp = null;
            }

            if (lblNotification != null) {
                lblNotification.Dispose ();
                lblNotification = null;
            }

            if (lblTitle != null) {
                lblTitle.Dispose ();
                lblTitle = null;
            }

            if (LogoutView != null) {
                LogoutView.Dispose ();
                LogoutView = null;
            }

            if (notificationSwitch != null) {
                notificationSwitch.Dispose ();
                notificationSwitch = null;
            }

            if (SettingsHeaderView != null) {
                SettingsHeaderView.Dispose ();
                SettingsHeaderView = null;
            }

            if (SettingView != null) {
                SettingView.Dispose ();
                SettingView = null;
            }

            if (SwitchHolderView != null) {
                SwitchHolderView.Dispose ();
                SwitchHolderView = null;
            }
        }
    }
}