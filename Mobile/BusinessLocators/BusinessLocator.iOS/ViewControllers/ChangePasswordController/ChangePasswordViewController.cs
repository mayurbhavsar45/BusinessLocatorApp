using Foundation;
using System;
using UIKit;
using CoreGraphics;
using CoreAnimation;

namespace BusinessLocator.iOS
{
    public partial class ChangePasswordViewController : UIViewController
    {
        public ChangePasswordViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            CGColor[] colors = new CGColor[] { UIColor.FromRGB(98,107,186).CGColor,
                UIColor.FromRGB(57,122,193).CGColor};
            CAGradientLayer gradientLayer = new CAGradientLayer();
            gradientLayer.Frame = this.View.Bounds;
            gradientLayer.Colors = colors;
            this.View.Layer.InsertSublayer(gradientLayer, 0);

            borderNewPassword.Layer.BorderWidth = 1.5f;
            borderNewPassword.Layer.BorderColor = UIColor.White.CGColor;

            borderConfirmPassword.Layer.BorderWidth = 1.5f;
            borderConfirmPassword.Layer.BorderColor = UIColor.White.CGColor;

            txtNewPassword.AttributedPlaceholder = new NSAttributedString("New password", null, UIColor.White);
            txtNewPassword.ClearButtonMode = UITextFieldViewMode.WhileEditing;

            txtConfirmPassword.AttributedPlaceholder = new NSAttributedString("Confirm password", null, UIColor.White);
            txtConfirmPassword.ClearButtonMode = UITextFieldViewMode.WhileEditing;

            btnBack.TouchUpInside+=(sender, e) => 
            {
                this.NavigationController.PopViewController(true);
            };
        }

    }
}