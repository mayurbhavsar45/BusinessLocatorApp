using Foundation;
using System;
using UIKit;

namespace BusinessLocator.iOS
{
    public partial class ProductsDialogPopupViewController : UIViewController
    {
        //public string Name { get; set; }
        //public string Image { get; set; }
        //public string Price { get; set; }
        ////public string Quantity { get; set; }
        //public string ProductDescription { get; set; }
        
        public ProductsDialogPopupViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //ProductTitleLable.Text = Name;
            //ProductImage.Image = UIImage.FromFile(Image);
            //lblPrice.Text = Price;
            //lblQuantity.Text = Quantity;
            //lblDescription.Text = ProductDescription;

            btnContentProvider.BackgroundColor = UIColor.FromRGB(66, 118, 190);
            btnContentProvider.TouchUpInside += (sender, e) => 
            {
                DismissViewController(true, null);
            };
        }
    }
}