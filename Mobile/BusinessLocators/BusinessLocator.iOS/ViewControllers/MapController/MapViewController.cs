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
            mapView.Settings.MyLocationButton = true;
            mapView.MyLocationEnabled = true;
            mapView.Settings.SetAllGesturesEnabled(true);
            //mapView.MapType = MapViewType.Satellite;


            //Marker
            var first_marker = new Marker() 
            {
                Title = "Jim",
                //Snippet = "Surat, Gujarat",
                Position = new CLLocationCoordinate2D(21.183549, 72.783175),
                Map = mapView
            };

            var second_marker = new Marker()
            {
                Title = "Thomas",
                //Snippet = "Surat, Gujarat",
                Position = new CLLocationCoordinate2D(21.186312, 73.783175),
                Map = mapView
            };

            var third_marker = new Marker()
            {
                Title = "Katherin",
                //Snippet = "Surat, Adajan",
                Position = new CLLocationCoordinate2D(25.182070, 73.782674),
                Map = mapView
            };

            var fourth_marker = new Marker()
            {
                Title = "Jonathan",
                //Snippet = "Surat, Adajan",
                Position = new CLLocationCoordinate2D(24.182070, 75.782674),
                Map = mapView
            };

            //Customize Marker
            second_marker.Icon = UIImage.FromFile("icon-marker-30");
            fourth_marker.Icon = UIImage.FromFile("marker-pin");
            third_marker.Icon = UIImage.FromFile("icon-marker-30");

            View = mapView;
        }

    }
}