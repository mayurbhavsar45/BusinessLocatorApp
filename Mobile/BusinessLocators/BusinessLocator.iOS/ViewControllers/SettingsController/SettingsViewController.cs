using Foundation;
using System;
using UIKit;
using CoreAnimation;
using CoreGraphics;
using Plugin.Settings;

namespace BusinessLocator.iOS
{
    public partial class SettingsViewController : UIViewController
    {
        public SettingsViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var gradientLayer = new CAGradientLayer();
            gradientLayer.Colors = new[] { UIColor.FromRGB(98, 107, 186).CGColor, UIColor.FromRGB(57, 122, 193).CGColor };
            gradientLayer.Frame = new CGRect(0, 0, SettingsHeaderView.Frame.Width + 50, SettingsHeaderView.Frame.Height);
            SettingsHeaderView.Layer.InsertSublayer(gradientLayer, 0);

            //Color for switch off state
            notificationSwitch.Layer.CornerRadius = 16;

            btnBack.TouchUpInside += (sender, e) => 
            {
                this.NavigationController.PopViewController(true);
            };

            btnLogout.TouchUpInside += (sender, e) => 
            {
                var controller = UIAlertController.Create("Confirm", "Are you sure you want to logout?", UIAlertControllerStyle.Alert);
                controller.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Default, (obj) => { }));
                controller.AddAction(UIAlertAction.Create("Logout", UIAlertActionStyle.Default, (obj) =>
                {
                    CrossSettings.Current.Clear();
                    NavigationController.PopToRootViewController(true);
                }));

                PresentViewController(controller, true, null);
                //ProviderProfileViewController providerController = this.Storyboard.InstantiateViewController("ProviderProfileViewController") as ProviderProfileViewController;
                //if (providerController != null)
                //{
                //    this.NavigationController.PushViewController(providerController, true);
                //}
             };
        }
    }
}