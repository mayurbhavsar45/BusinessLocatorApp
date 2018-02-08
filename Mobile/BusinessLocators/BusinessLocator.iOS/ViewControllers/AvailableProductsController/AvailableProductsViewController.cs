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
                    Information = "Collection Views allow content to be displayed using arbitrary layouts",
                    Price = "$40"    
                },

                new ProductsItemModel
                {
                    Image = "product2.jpg",
                    Information = "Collection Views allow content to be displayed using arbitrary layouts",
                    Price = "$40"
                },

                new ProductsItemModel
                {
                    Image = "product3.jpg",
                    Information = "Collection Views allow content to be displayed using arbitrary layouts",
                    Price = "$40"
                },

                new ProductsItemModel
                {
                    Image = "product4.jpg",
                    Information = "Collection Views allow content to be displayed using arbitrary layouts",
                    Price = "$40"
                },

                new ProductsItemModel
                {
                    Image = "product1.jpg",
                    Information = "Collection Views allow content to be displayed using arbitrary layouts",
                    Price = "$40"
                },
            };

            ProductsCollectionView.Source = new ProductsCollectionViewSource(this, data);
            ProductsCollectionView.ReloadData();


        }

    }
}