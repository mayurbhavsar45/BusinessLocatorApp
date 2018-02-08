using Foundation;
using System;
using UIKit;
using BusinessLocator.iOS.Model;
using System.Collections.Generic;

namespace BusinessLocator.iOS
{
    public partial class ProductsCell : UICollectionViewCell
    {
        public static string CellID = new NSString("ProductsCell");

        public ProductsCell (IntPtr handle) : base (handle)
        {
        }

        public void UpdateRow(List<ProductsItemModel> items, NSIndexPath indexPath)
        {
            ProductImage.Image = UIImage.FromFile(items[indexPath.Row].Image);
            ProductDescriptionLable.Text = items[indexPath.Row].Information;
            ProductPriceLable.Text = items[indexPath.Row].Price;
        }
    }
}