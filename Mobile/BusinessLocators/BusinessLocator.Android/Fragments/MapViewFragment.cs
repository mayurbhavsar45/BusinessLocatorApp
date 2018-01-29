using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;


namespace BusinessLocator.Android.Fragments
{
    public class MapViewFragment : Fragment ,IOnMapReadyCallback
    {
        private GoogleMap gmap;
       SupportMapFragment mFragment;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.MapViewFragment, container, false);
            SetUpMap();
            return v;


        }


        public void OnMapReady(GoogleMap googleMap)
        {
            this.gmap = googleMap;
            // var iconGen = new IconGenerator(activity);
            gmap.UiSettings.ZoomControlsEnabled = true;
            gmap.UiSettings.ScrollGesturesEnabled = true;
            gmap.UiSettings.ZoomGesturesEnabled = true;
            LatLng latlng = new LatLng(21.183549, 72.783175);
            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng, 15);
            gmap.MoveCamera(camera);
            MarkerOptions markerOption = new MarkerOptions();
            markerOption.SetPosition(latlng);
            markerOption.SetTitle("Natrix Software Private Limited");

            gmap.AddMarker(markerOption);
        }

        private void SetUpMap()
        {

            if (gmap == null)
            {

                //   Activity. FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
                mFragment = (SupportMapFragment)   ChildFragmentManager.FindFragmentById(Resource.Id.map);
                mFragment.GetMapAsync(this);
            }

        }
    }

}