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
            decimal averageRating = 2.50m;
            decimal halfRoundedRating = Math.Round(averageRating * 2m, MidpointRounding.AwayFromZero) / 2m;
            decimal wholeRoundedRating = Math.Round(averageRating, MidpointRounding.AwayFromZero);
            ratingView = new PDRatingView(new CoreGraphics.CGRect(130, lblProviderMobileNo.Frame.Top + lblProviderMobileNo.Frame.Height-30, lblProviderMobileNo.Bounds.Width+10, 100), ratingConfig, averageRating);

            ratingView.AverageRating = wholeRoundedRating;
            View.Add(ratingView);

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