using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using BusinessLocator.iOS.Model;
using CoreAnimation;
using CoreGraphics;

namespace BusinessLocator.iOS
{
    public partial class AvailableProductsViewController : UIViewController
    {
        public AvailableProductsViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var gradientLayer = new CAGradientLayer();
            gradientLayer.Colors = new[] { UIColor.FromRGB(98, 107, 186).CGColor, UIColor.FromRGB(57, 122, 193).CGColor };
            gradientLayer.Frame = new CGRect(0, 0, HeaderView.Frame.Width + 50, HeaderView.Frame.Height);
            HeaderView.Layer.InsertSublayer(gradientLayer, 0);


            var data = new List<ProductsItemModel> 
            {
                new ProductsItemModel
                {
                    Image = "product1.jpg",
                    Information = "Calvin Klein One Deodorant Body Spray...",
                    Price = "$40"    
                },

                new ProductsItemModel
                {
                    Image = "product2.jpg",
                    Information = "Narciso Rodriguez L'Eau Eau De Toilette for Her, 100ml",
                    Price = "$85"
                },

                new ProductsItemModel
                {
                    Image = "product3.png",
                    Information = "Shiseido Bio performance Lift dynamic Serum, 30ml",
                    Price = "$70"
                },

                new ProductsItemModel
                {
                    Image = "product6.jpg",
                    Information = "Lakme Invisible Finish SPF 8 Foundation, Shade 01, 25 ml",
                    Price = "$50"
                },

                new ProductsItemModel
                {
                    Image = "product7.jpg",
                    Information = "Lakme Face Magic Souffle, Marble, 30 ml",
                    Price = "$80"
                },
            };

            ProductsCollectionView.Source = new ProductsCollectionViewSource(this, data);
            ProductsCollectionView.ReloadData();

            btnBack.TouchUpInside += (sender, e) => 
            {
                this.NavigationController.PopViewController(true);
            };

        }

    }
}