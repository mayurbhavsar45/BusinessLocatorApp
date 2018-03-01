using Foundation;
using System;
using UIKit;
using Google.Maps;
using CoreGraphics;
using CoreLocation;
using BusinessLocator.Shared.Service;
using Plugin.Settings;
using Mobile.Extensions.iOS.Extensions;
using System.Collections.Generic;
using BusinessLocator.Shared.Models;
using Newtonsoft.Json;

namespace BusinessLocator.iOS
{
    public partial class MapViewController : BaseViewController
    {
        MapView mapView;
        CustomView v = new CustomView();
        string number, name, address, image, email;
        int rating;
        //public static string role = CrossSettings.Current.GetValueOrDefault("RoleName", "");

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

            LoadingScreen.Show();

            string role = "";
            string searchText = "";
            double lattitude = 21.17024;
            double longitude = 72.831062;

            var apiCall = new ServiceApi().GetUserLocation(lattitude, longitude, searchText, role);

            apiCall.HandleError(null, true);

            apiCall.OnSucess(response =>
            {
                LoadingScreen.Hide();

                var data = response.Result.RecordList.Count;
                var records = response.Result.RecordList;

                //List<object> abc = new List<object>();

                for (var i = 0; i < data; i++)
                {
                    var result = records[i];

                    var mapcamera = CameraPosition.FromCamera(latitude: result.Lattitude,
                                                              longitude: result.Longitude,
                                                              zoom: 5);
                    mapView = MapView.FromCamera(CGRect.Empty, mapcamera);
                    mapView.MyLocationEnabled = true;
                    mapView.Settings.MyLocationButton = true;
                    mapView.MyLocationEnabled = true;
                    mapView.Settings.SetAllGesturesEnabled(true);

                    //abc.Add(new { Title = result.DisplayName, Snippet = result.Address1, Position = new CLLocationCoordinate2D(result.Lattitude, result.Longitude), Map = mapView });

                }

                foreach (var mark in records)
                {
                    var marker = new Marker()
                    {
                        Title = mark.DisplayName + " - " + mark.PhoneNumber,
                        Snippet = mark.PhoneNumber + " - " + mark.DisplayName + " - " + mark.Image + " - " + mark.Address1 + " - " + mark.eMailAddress + " - " + mark.Rating,
                        Position = new CLLocationCoordinate2D(mark.Lattitude, mark.Longitude),
                        Map = mapView,
                    };
                }

                mapView.TappedMarker = (mapView, marker) =>
                {
                    mapView.MarkerInfoWindow = new GMSInfoFor(markerInfoWindow);
                    string[] marker_data = marker.Title.Split('-');
                    if (marker_data.Length > 0)
                    {
                        CommonClass.Name = marker_data[0].Trim();

                        if (marker_data.Length > 1)
                        {
                            CommonClass.MobileNumber = marker_data[1].Trim();
                        }

                    }
                    return false;
                };

                UIView markerInfoWindow(UIView view, Marker m)
                {
                    UIView iWindow = v.Create();
                    return iWindow;
                }

                //Use tp detect tap on the Marker Info Window
                mapView.InfoTapped += (sender, e) =>
                {
                    string[] info_data = e.Marker.Snippet.Split('-');
                    if (info_data.Length > 0)
                    {
                        number = info_data[0].Trim();
                        name = info_data[1].Trim();
                        image = info_data[2].Trim();
                        address = info_data[3].Trim();
                        email = info_data[4].Trim();
                        rating = Convert.ToInt32(info_data[5].Trim());
                    }

                    var controller = Storyboard.InstantiateViewController<ProviderProfileViewController>();

                    controller.Name = name;
                    controller.MobileNumber = number;
                    controller.Addres = address;
                    controller.Image = image;
                    controller.EmailID = email;
                    controller.Rating = rating;

                    NavigationController.PushViewController(controller, true);

                    //UIAlertView alert = new UIAlertView()
                    //{
                    //    Title = "Alert",
                    //    Message = "Clicked" + e.Marker.Title
                    //};
                    //alert.AddButton("OK");
                    //alert.Show();

                };

                //for (var j = 0; j < abc.Count; j++)
                //{
                //    var d = abc[j];
                //}

                //for (var j = 0; j < data; j++)
                //{
                //    foreach(var i in values)
                //    {
                //        var marker = new Marker()
                //        {
                //            Title = i.DisplayName,
                //            Snippet = i.Address1,
                //            Position = new CLLocationCoordinate2D(i.Lattitude, i.Longitude),
                //            Map = mapView,
                //        };
                //    }
                //}

                View = mapView;
            });


            //var camera = CameraPosition.FromCamera(latitude: 21.183549,
            //                                       longitude: 72.783175,
            //                                zoom: 5);
            //mapView = MapView.FromCamera(CGRect.Empty, camera);
            //mapView.MyLocationEnabled = true;
            //mapView.Settings.MyLocationButton = true;
            //mapView.MyLocationEnabled = true;
            //mapView.Settings.SetAllGesturesEnabled(true);
            //mapView.MapType = MapViewType.Satellite;


            //Marker
            //var first_marker = new Marker() 
            //{
            //    Title = "Jim",
            //    //Snippet = "Surat, Gujarat",
            //    Position = new CLLocationCoordinate2D(21.183549, 72.783175),
            //    Map = mapView,
            //};

            //var second_marker = new Marker()
            //{
            //    Title = "Thomas",
            //    //Snippet = "Surat, Gujarat",
            //    Position = new CLLocationCoordinate2D(21.186312, 73.783175),
            //    Map = mapView
            //};
           
             //Customize Marker
            //second_marker.Icon = UIImage.FromFile("icon-marker-30");

            //View = mapView;

        }

    }

    public class MapItems
    {
        public string Title { get; set; }
        public string Snippet { get; set; }
        public Position pos { get; set; }
        public string MapView { get; set; }
    }

    public class Position
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

}