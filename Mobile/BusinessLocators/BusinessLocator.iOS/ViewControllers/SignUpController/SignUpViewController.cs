using Foundation;
using System;
using UIKit;
using CoreGraphics;
using CoreAnimation;
using System.Collections.Generic;
using System.Drawing;

namespace BusinessLocator.iOS
{
    public partial class SignUpViewController : UIViewController
    {
        public SignUpViewController (IntPtr handle) : base (handle)
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

            //Set Placeholder Text Color
            txtUserName.AttributedPlaceholder = new NSAttributedString("Username", null, UIColor.White);
            txtEmail.AttributedPlaceholder = new NSAttributedString("Emial", null, UIColor.White);
            txtMobileNumber.AttributedPlaceholder = new NSAttributedString("Mobile number", null, UIColor.White);
            txtPassword.AttributedPlaceholder = new NSAttributedString("Password", null, UIColor.White);

            //Show Clear Button While Editing Values
            txtUserName.ClearButtonMode = UITextFieldViewMode.WhileEditing;
            txtEmail.ClearButtonMode = UITextFieldViewMode.WhileEditing;
            txtMobileNumber.ClearButtonMode = UITextFieldViewMode.WhileEditing;
            txtPassword.ClearButtonMode = UITextFieldViewMode.WhileEditing;

            txtPassword.SecureTextEntry = true;

            borderUserName.Layer.BorderWidth = 2;
            borderUserName.Layer.BorderColor = UIColor.White.CGColor;

            borderEmail.Layer.BorderWidth = 2;
            borderEmail.Layer.BorderColor = UIColor.White.CGColor;

            borderMobileNumber.Layer.BorderWidth = 2;
            borderMobileNumber.Layer.BorderColor = UIColor.White.CGColor;

            borderPassword.Layer.BorderWidth = 2;
            borderPassword.Layer.BorderColor = UIColor.White.CGColor;

            borderDDL.Layer.BorderWidth = 2;
            borderDDL.Layer.BorderColor = UIColor.White.CGColor;

            //UIPickerView Values

            var list = new List<string> 
            {
                "Are you", "Provider", "Consumer"
            };

            blPickerView.Model = new UserTypeViewModel(list);
            blPickerView.ShowSelectionIndicator = true;
            //UserTypeViewModel picker_model;
            //picker_model = new UserTypeViewModel(list);
            //blPickerView.Model = picker_model;

            //Pickerview Custom Appearance
            var layer = new CALayer();
            layer.Frame = new CGRect(15, 15, blPickerView.Frame.Width - 30, blPickerView.Frame.Height - 30);
            layer.CornerRadius = 10;
            layer.BackgroundColor = UIColor.White.CGColor;
            blPickerView.Layer.Mask = layer;

            btnBack.TouchUpInside += (sender, e) => 
            {
                this.NavigationController.PopViewController(true);
            };

        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

        }
    }
}