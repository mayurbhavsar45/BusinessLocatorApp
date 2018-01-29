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
    [Register ("LocationViewController")]
    partial class LocationViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnListView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnMapView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView collectionViewPager { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView IndicatorView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView locationtabHeaderView { get; set; }

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

            if (IndicatorView != null) {
                IndicatorView.Dispose ();
                IndicatorView = null;
            }

            if (locationtabHeaderView != null) {
                locationtabHeaderView.Dispose ();
                locationtabHeaderView = null;
            }
        }
    }
}