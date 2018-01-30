// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace BusinessLocator.iOS
{
    [Register ("LocationViewController")]
    partial class LocationViewController
    {
        [Outlet]
        UIKit.UIButton btnListView { get; set; }


        [Outlet]
        UIKit.UIButton btnMapView { get; set; }


        [Outlet]
        UIKit.UICollectionView collectionViewPager { get; set; }


        [Outlet]
        UIKit.UIView IndicatorView { get; set; }


        [Outlet]
        UIKit.UIView locationtabHeaderView { get; set; }


        [Outlet]
        UIKit.UIView TabContainer { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnListView != null) {
                btnListView.Dispose ();
                btnListView = null;
            }

            if (btnMapView != null) {
                btnMapView.Dispose ();
                btnMapView = null;
            }

            if (collectionViewPager != null) {
                collectionViewPager.Dispose ();
                collectionViewPager = null;
            }

            if (locationtabHeaderView != null) {
                locationtabHeaderView.Dispose ();
                locationtabHeaderView = null;
            }
        }
    }
}