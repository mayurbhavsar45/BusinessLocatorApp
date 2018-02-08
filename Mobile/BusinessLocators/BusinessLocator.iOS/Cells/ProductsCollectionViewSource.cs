using System.Collections.Generic;
using BusinessLocator.iOS.Model;
using UIKit;

namespace BusinessLocator.iOS
{
    internal class ProductsCollectionViewSource : UICollectionViewSource
    {
        AvailableProductsViewController _VC;
        List<ProductsItemModel> _Items;

        public ProductsCollectionViewSource(AvailableProductsViewController VC, List<ProductsItemModel> items)
        {
            this._VC = VC;
            this._Items = items;
        }


        public override System.nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }

        public override System.nint GetItemsCount(UICollectionView collectionView, System.nint section)
        {
            return _Items.Count;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, Foundation.NSIndexPath indexPath)
        {
            var cell = (ProductsCell)collectionView.DequeueReusableCell(ProductsCell.CellID, indexPath);
            cell.UpdateRow(_Items, indexPath);
            return cell;
        }

        public override void ItemSelected(UICollectionView collectionView, Foundation.NSIndexPath indexPath)
        {
            var selected_raw = _Items[indexPath.Row];
            //new UIAlertView("Action","Clicked",null,"OK",null).Show();
            ProductsDialogPopupViewController controller = _VC.Storyboard.InstantiateViewController("ProductsDialogPopupViewController") as ProductsDialogPopupViewController;

            //controller.Image = selected_raw.Image;
            //controller.ProductDescription = selected_raw.Information;
            //controller.Price = selected_raw.Price;

            if(controller != null)
            {
                controller.ModalPresentationStyle = UIModalPresentationStyle.Popover;
                controller.ModalTransitionStyle = UIModalTransitionStyle.FlipHorizontal;
                //_VC.NavigationController.PushViewController(controller, true);
                 _VC.PresentViewController(controller, true, null);
            }
        }
    }
}