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


            CALayer profileImageCircle = ProfilePicture.Layer;
            profileImageCircle.CornerRadius = 25;
            profileImageCircle.BorderColor = UIColor.White.CGColor;
            profileImageCircle.BorderWidth = 2;
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