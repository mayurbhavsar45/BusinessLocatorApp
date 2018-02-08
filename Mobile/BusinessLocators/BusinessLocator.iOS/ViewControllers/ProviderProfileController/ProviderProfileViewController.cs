using Foundation;
using System;
using UIKit;
using CoreAnimation;
using CoreGraphics;

namespace BusinessLocator.iOS
{
    public partial class ProviderProfileViewController : UIViewController
    {
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

            btnBack.TouchUpInside += (sender, e) => 
            {
                this.NavigationController.PopViewController(true);
            };

            btnReportProvider.TouchUpInside += (sender, e) => 
            {
                
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