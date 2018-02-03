using Foundation;
using System;
using UIKit;
using CoreAnimation;
using CoreGraphics;

namespace BusinessLocator.iOS
{
    public partial class MessageViewController : UIViewController
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
       
        public MessageViewController (IntPtr handle) : base (handle)
        {
        }

        public MessageViewController(){}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var gradientLayer = new CAGradientLayer();
            gradientLayer.Colors = new[] { UIColor.FromRGB(98, 107, 186).CGColor, UIColor.FromRGB(57, 122, 193).CGColor };
            gradientLayer.Locations = new NSNumber[] { 0, 1 };
            gradientLayer.Frame = new CGRect(0, 0, HeaderView.Frame.Width + 50, HeaderView.Frame.Height);
            HeaderView.Layer.InsertSublayer(gradientLayer, 0);

            //var buttonGradientLayer = new CAGradientLayer();
            //buttonGradientLayer.Colors = new[] { UIColor.FromRGB(98, 107, 186).CGColor, UIColor.FromRGB(57, 122, 193).CGColor };
            //buttonGradientLayer.Frame = btnSendMessage.Layer.Bounds;
            //buttonGradientLayer.CornerRadius = btnSendMessage.Layer.CornerRadius;
            //buttonGradientLayer.Locations = new NSNumber[] { 0, 1 };
            //btnSendMessage.Layer.AddSublayer(buttonGradientLayer);

            btnSendMessage.BackgroundColor = UIColor.FromRGB(98, 107, 186);

            CALayer profileImageCircle = ProfilePicture.Layer;
            profileImageCircle.CornerRadius = 25;
            profileImageCircle.BorderColor = UIColor.White.CGColor;
            profileImageCircle.BorderWidth = 1.5f;
            profileImageCircle.MasksToBounds = true;


            lblName.Text = Name;
            ProfilePicture.Image = UIImage.FromFile(Image);

            if(Status == true)
            {
                lblStatus.Text = "Online";    
            }
            else
            {
                lblStatus.RemoveFromSuperview();
            }

            textSender.AttributedPlaceholder = new NSAttributedString("type message here...", null, UIColor.FromRGB(98, 107, 186));

            btnBack.TouchUpInside += (sender, e) => 
            {
                this.NavigationController.PopViewController(true);
            };
           
        }

    }
}