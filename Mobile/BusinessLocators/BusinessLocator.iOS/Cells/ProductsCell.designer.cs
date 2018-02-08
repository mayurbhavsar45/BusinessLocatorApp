// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BusinessLocator.iOS
{
    [Register ("ProductsCell")]
    partial class ProductsCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ProductDescriptionLable { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ProductImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ProductPriceLable { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ProductDescriptionLable != null) {
                ProductDescriptionLable.Dispose ();
                ProductDescriptionLable = null;
            }

            if (ProductImage != null) {
                ProductImage.Dispose ();
                ProductImage = null;
            }

            if (ProductPriceLable != null) {
                ProductPriceLable.Dispose ();
                ProductPriceLable = null;
            }
        }
    }
}