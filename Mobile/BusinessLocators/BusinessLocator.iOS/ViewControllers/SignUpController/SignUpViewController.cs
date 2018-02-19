using Foundation;
using System;
using UIKit;
using CoreGraphics;
using CoreAnimation;
using System.Collections.Generic;
using System.Drawing;
using BusinessLocator.Shared.Service;
using Plugin.Connectivity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Mobile.Extensions.iOS.Extensions;

namespace BusinessLocator.iOS
{
    public partial class SignUpViewController : UIViewController
    {
        CAGradientLayer gradientLayer;
        double lat = 0; 
        double lng = 0;

        public SignUpViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //CGColor[] colors = new CGColor[] { UIColor.FromRGB(98,107,186).CGColor,
            //    UIColor.FromRGB(57,122,193).CGColor};
            //gradientLayer = new CAGradientLayer();
            //gradientLayer.Frame = this.View.Bounds;
            //gradientLayer.Colors = colors;
            //this.View.Layer.InsertSublayer(gradientLayer, 0);

            gradientLayer = new CAGradientLayer();
            gradientLayer.Colors = new[] { UIColor.FromRGB(98, 107, 186).CGColor, UIColor.FromRGB(57, 122, 193).CGColor };
            gradientLayer.Frame = this.View.Bounds;
            View.Layer.InsertSublayer(gradientLayer, 0);


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

            var picker = new UserTypeViewModel(list);
            rolePicker.Model = picker;
            rolePicker.ShowSelectionIndicator = true;
            //picker.ValueChanged+=(sender, e) => 
            //{
            //    var val = picker.SelectedValue;
            //};

            //Pickerview Custom Appearance
            var layer = new CALayer();
            layer.Frame = new CGRect(15, 15, rolePicker.Frame.Width - 30, rolePicker.Frame.Height - 30);
            layer.CornerRadius = 10;
            layer.BackgroundColor = UIColor.White.CGColor;
            rolePicker.Layer.Mask = layer;

            btnBack.TouchUpInside += (sender, e) => 
            {
                this.NavigationController.PopViewController(true);
            };

            btnSignUp.TouchUpInside +=(sender, e) => 
            {
                
                var apiCall = new ServiceApi().Register(txtUserName.Text,txtEmail.Text,txtMobileNumber.Text,txtPassword.Text, picker.SelectedValue, lat, lng);
                apiCall.HandleError(null, true);

                apiCall.OnSucess((result)=>
                {
                    var okAlertController = UIAlertController.Create("Alert", "Registration successfull", UIAlertControllerStyle.Alert);
                    okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Destructive, null));
                    PresentViewController(okAlertController, true, null);
                });

            };
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            this.NavigationController.NavigationBarHidden = true;
        }

        public override void WillRotate(UIInterfaceOrientation toInterfaceOrientation, double duration)
        {
            gradientLayer.Frame = this.View.Bounds;
        }

        public override void DidRotate(UIInterfaceOrientation fromInterfaceOrientation)
        {
            gradientLayer.Frame = this.View.Bounds;
        }

       
    }
}