using Foundation;
using System;
using UIKit;
using CoreAnimation;
using CoreGraphics;
using PatridgeDev;

namespace BusinessLocator.iOS
{
    public partial class ProviderProfileViewController : UIViewController
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string MobileNumber { get; set; }
        public string EmailID { get; set; }
        public string Addres { get; set; }
        public int Rating { get; set; }

        PDRatingView ratingView;
        public ProviderProfileViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


            var gradientLayer = new CAGradientLayer();
            gradientLayer.Colors = new[] { UIColor.FromRGB(98, 107, 186).CGColor, UIColor.FromRGB(57, 122, 193).CGColor };
            gradientLayer.Frame = new CGRect(0, 0, HeaderView.Frame.Width + 50, HeaderView.Frame.Height);
            HeaderView.Layer.InsertSublayer(gradientLayer, 0);

            CALayer profileImageCircle = ProviderDisplayPicture.Layer;
            profileImageCircle.CornerRadius = 40;
            profileImageCircle.BorderColor = UIColor.FromRGB(98, 107, 186).CGColor;
            profileImageCircle.BorderWidth = 3;
            profileImageCircle.MasksToBounds = true;

            var ratingConfig = new RatingConfig(emptyImage: UIImage.FromFile("empty"),
                                                filledImage: UIImage.FromFile("chosen"),//filled
                                                chosenImage: UIImage.FromFile("chosen"));
            // Create the view.
            decimal averageRating = Rating;
            decimal halfRoundedRating = Math.Round(averageRating * 2m, MidpointRounding.AwayFromZero) / 2m;
            decimal wholeRoundedRating = Math.Round(averageRating, MidpointRounding.AwayFromZero);
            ratingView = new PDRatingView(new CGRect(155, lblProviderMobileNo.Frame.Top + lblProviderMobileNo.Frame.Height-30, lblProviderMobileNo.Bounds.Width+10, 100), ratingConfig, averageRating);

            ratingView.AverageRating = wholeRoundedRating;
            View.Add(ratingView);

            var imageBytes = Convert.FromBase64String(Image);
            var imageData = NSData.FromArray(imageBytes);
            var UserImage = UIImage.LoadFromData(imageData);

            ProviderDisplayPicture.Image = UserImage;
            ProviderWallPicture.Image = UserImage;
            lblProviderName.Text = Name;
            lblProviderMobileNo.Text = MobileNumber;
            lblEmailId.Text = EmailID;
            lblAddress.Text = Addres;

            btnBack.TouchUpInside += (sender, e) => 
            {
                this.NavigationController.PopViewController(true);
            };

            btnReportProvider.TouchUpInside += (sender, e) => 
            {
                ReportProviderViewController _VC = this.Storyboard.InstantiateViewController("ReportProviderViewController") as ReportProviderViewController;
                if(_VC!=null)
                {
                    _VC.ModalPresentationStyle = UIModalPresentationStyle.OverCurrentContext;
                    _VC.ModalTransitionStyle = UIModalTransitionStyle.CoverVertical;
                    this.PresentViewController(_VC, true, null);
                }
            };

            btnReviewbyOther.TouchUpInside += (sender, e) => 
            {
                ConsumerReviewViewController reviewController = this.Storyboard.InstantiateViewController("ConsumerReviewViewController") as ConsumerReviewViewController;
                if(reviewController != null)
                {
                    this.NavigationController.PushViewController(reviewController, true);
                }
            };

            btnAvailableProducts.TouchUpInside += (sender, e) => 
            {
                AvailableProductsViewController _vc = this.Storyboard.InstantiateViewController("AvailableProductsViewController") as AvailableProductsViewController;
                if(_vc != null)
                {
                    this.NavigationController.PushViewController(_vc, true);
                }
            };
        }


    }
}