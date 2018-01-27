using Foundation;
using System;
using UIKit;
using CoreGraphics;
using CoreAnimation;

namespace BusinessLocator.iOS
{
    public partial class ForgotPasswordViewController : UIViewController
    {
        public ForgotPasswordViewController (IntPtr handle) : base (handle)
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

            btnBack.SetImage(UIImage.FromFile("back_icon.png"),UIControlState.Normal);

            borderPhoneNumber.Layer.BorderWidth = 2;
            borderPhoneNumber.Layer.BorderColor = UIColor.White.CGColor;

            txtPhoneNumber.AttributedPlaceholder = new NSAttributedString("Phone number", null, UIColor.White);
            txtPhoneNumber.ClearButtonMode = UITextFieldViewMode.WhileEditing;

            btnBack.TouchUpInside += (sender, e) => 
            {
                this.NavigationController.PopViewController(true);
            };

            btnSubmit.TouchUpInside += (sender, e) => 
            {
                MainViewController mainViewController = this.Storyboard.InstantiateViewController("MainViewController") as MainViewController;
                if(mainViewController!=null)
                {
                    this.NavigationController.PushViewController(mainViewController, true);
                }
            };

        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            this.NavigationController.NavigationBarHidden = true;
        }

    }
}