using Foundation;
using System;
using UIKit;
using CoreAnimation;
using CoreGraphics;

namespace BusinessLocator.iOS
{
    public partial class UserProfileViewController : UIViewController
    {
        public UserProfileViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var gradientLayer = new CAGradientLayer();
            gradientLayer.Colors = new[] { UIColor.FromRGB(98,107,186).CGColor, UIColor.FromRGB(57,122,193).CGColor };
            gradientLayer.Frame = new CGRect(0, 0, ProfileHeaderView.Frame.Width+40, ProfileHeaderView.Frame.Height);
            ProfileHeaderView.Layer.InsertSublayer(gradientLayer, 0);

            btnBack.Hidden = true;


            //UIImageView view = new UIImageView()
            //{
            //    Frame = new CGRect(0, 250, ProfileWall.Frame.Width, ProfileWall.Frame.Height),
            //    //BackgroundColor=UIColor.Blue,
            //    Image = UIImage.FromFile("user1.jpg")
            //};
            //View.Add(view);

            UIImageView imageView = new UIImageView();
            imageView.Frame = new CGRect(0, 0, ProfileWall.Frame.Width + 50,ProfileWall.Frame.Height);
            imageView.Image = UIImage.FromFile("Polygon_one");
            imageView.ContentMode = UIViewContentMode.ScaleToFill;
            ProfileWall.MaskView = imageView;

            ProfileImage.Layer.CornerRadius = ProfileImage.Frame.Width / 2;
            ProfileImage.Layer.MasksToBounds = true;
            ProfileImage.Layer.BorderColor = UIColor.White.CGColor;
            ProfileImage.Layer.BorderWidth = 2;

        }

    }
}