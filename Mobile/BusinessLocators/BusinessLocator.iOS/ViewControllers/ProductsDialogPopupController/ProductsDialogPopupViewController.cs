using Foundation;
using System;
using UIKit;

namespace BusinessLocator.iOS
{
    public partial class ProductsDialogPopupViewController : UIViewController
    {
        public string Image { get; set; }
        public string Information { get; set; }
        public string Price { get; set; }

        public ProductsDialogPopupViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.Clear;

            btnContentProvider.BackgroundColor = UIColor.FromRGB(66, 118, 190);

            ProductImage.Image = UIImage.FromFile(Image);
            lblPrice.Text = Price;
            lblDescription.Text = Information;


            btnContentProvider.TouchUpInside += (sender, e) => 
            {
                DismissViewController(true, null);
            };
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);

            UITouch touch = touches.AnyObject as UITouch;
            if(touch.View == PopUpOuterView)
            {
                DismissViewController(true,null);
            }

        }
    }
}