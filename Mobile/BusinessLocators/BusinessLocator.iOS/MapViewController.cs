using Foundation;
using System;
using UIKit;
using Google.Maps;
using CoreGraphics;
using CoreLocation;

namespace BusinessLocator.iOS
{
    public partial class MapViewController : UIViewController
    {
        MapView mapView;

        public MapViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void LoadView()
        {
            base.LoadView();

            var camera = CameraPosition.FromCamera(latitude: 21.183549,
                                                   longitude: 72.783175,
                                            zoom: 5);
            mapView = MapView.FromCamera(CGRect.Empty, camera);
            mapView.MyLocationEnabled = true;

            //Marker
            var xamMarker = new Marker() 
            {
                Title = "Natrix",
                Snippet = "Surat, Gujarat",
                Position = new CLLocationCoordinate2D(21.183549, 72.783175),
                Map = mapView
            };

            var xamMarker2 = new Marker()
            {
                Title = "Divyesh",
                Snippet = "Surat, Gujarat",
                Position = new CLLocationCoordinate2D(21.186312, 72.783175),
                Map = mapView
            };

            var marker = new Marker()
            {
                Title = "Business Locator",
                Snippet = "Surat, Adajan",
                Position = new CLLocationCoordinate2D(25.182070, 73.782674),
                Map = mapView
            };

            var marker4 = new Marker()
            {
                Title = "Xamarin ios",
                Snippet = "Surat, Adajan",
                Position = new CLLocationCoordinate2D(24.182070, 75.782674),
                Map = mapView
            };

            //Customize Marker
            xamMarker.Icon = UIImage.FromFile("marker");

            marker.Icon = UIImage.FromFile("marker");
            View = mapView;
        }

    }
}