using Foundation;
using System;
using UIKit;
using CoreGraphics;
using CoreAnimation;
using System.Collections.Generic;

namespace BusinessLocator.iOS
{
    public partial class LocationViewController : UIViewController
    {

        public LocationViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var gradientLayer = new CAGradientLayer();
            gradientLayer.Colors = new[] { UIColor.FromRGB(98, 107, 186).CGColor, UIColor.FromRGB(57, 122, 193).CGColor };
            gradientLayer.Locations = new NSNumber[] { 0, 1 };
            gradientLayer.Frame = new CGRect(0, 0, locationtabHeaderView.Frame.Width+50, locationtabHeaderView.Frame.Height);
            //gradientLayer.Frame = locationtabHeaderView.Frame;
            locationtabHeaderView.Layer.InsertSublayer(gradientLayer,0);

            var layout = collectionViewPager.CollectionViewLayout as UICollectionViewFlowLayout;
            layout.ItemSize = new CGSize(UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height - 120);

            var controllers = new List<UIViewController>();
            var mapController = this.Storyboard.InstantiateViewController("MapViewController") as MapViewController;
            AddChildViewController(mapController);
            controllers.Add(mapController);

            var listViewController = this.Storyboard.InstantiateViewController("MapListViewController") as MapListViewController;
            AddChildViewController(listViewController);
            controllers.Add(listViewController);

            btnMapView.TouchUpInside +=(sender, e) => 
            {
                ScrollToPosition(0);
            };

            btnListView.TouchUpInside+=(sender, e) => 
            {
                ScrollToPosition(1);
            };

            var source = new CustomCollectionSource<UIViewController>(controllers, GetCell);
            collectionViewPager.Source = source;
            collectionViewPager.ReloadData();

            collectionViewPager.Delegate = null;

            collectionViewPager.Scrolled += (sender, e) =>
            {
                int position = (int)(collectionViewPager.ContentOffset.X / UIScreen.MainScreen.Bounds.Width);
                if (collectionViewPager.ContentOffset.X % UIScreen.MainScreen.Bounds.Width > (UIScreen.MainScreen.Bounds.Width / 2f))
                {
                    position++;
                }

                //if (position == 1)
                //{
                //    //ShowHelpIfNecessary(TutorialHelper.SchedulesScores);
                //}

                SetButtonColor(position);

                //_lcIndicatorLeading.Constant = collectionViewPager.ContentOffset.X / 2f;
            };
        }

        void SetButtonColor(int position)
        {
            btnMapView.SetTitleColor(UIColor.Gray, UIControlState.Normal);
            btnListView.SetTitleColor(UIColor.Gray, UIControlState.Normal);
            if (position == 0)
            {
                btnMapView.SetTitleColor(UIColor.FromRGB(66, 120, 189), UIControlState.Normal);
            }
            else if (position == 1)
            {
                btnListView.SetTitleColor(UIColor.FromRGB(66, 120, 189), UIControlState.Normal);
            }
        }

        private void ScrollToPosition(int position)
        {
            collectionViewPager.ScrollToItem(NSIndexPath.FromRowSection(position,0), UICollectionViewScrollPosition.None, true);
        }

        public UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath, UIViewController item)
        {
            var cell = collectionView.DequeueReusableCell("HomeCell", indexPath) as UICollectionViewCell;
            if (item.View.Superview == null)
            {
                cell.Add(item.View);
                var frame = item.View.Frame;
                frame.Width = cell.Frame.Width;
                frame.Height = cell.Frame.Height;
                item.View.Frame = frame;
            }
            return cell;
        }


        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

        }
    }

}