using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.Annotation;
using Android.Support.V4.App;
using Android.Support.V4.Graphics.Drawable;
using Android.Util;
using Android.Views;
using Android.Widget;
using static Android.Gms.Maps.GoogleMap;
using Fragment = Android.Support.V4.App.Fragment;


namespace BusinessLocator.Android.Fragments
{
    public class MapViewFragment : Fragment ,IOnMapReadyCallback,IInfoWindowAdapter,IOnInfoWindowClickListener
    {
        private GoogleMap gmap;
        SupportMapFragment mFragment;
        View mCustomMarkerView;


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.MapViewFragment, container, false);
            //mCustomMarkerView= inflater.Inflate(Resource.Layout.view_custom_marker, container);
            var s = Application.Context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
            mCustomMarkerView = s.Inflate(Resource.Layout.view_custom_marker, null);
            var inflater1 = Application.Context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
         
            SetUpMap();
            return v;


        }
      
        private Bitmap CreateDrawableFromView(Context context, View view)
        {


            DisplayMetrics displayMetrics = new DisplayMetrics();
            ((Activity)context).WindowManager.DefaultDisplay.GetMetrics(displayMetrics);
            // view.setLayoutParams(new LayoutParams(LayoutParams.WRAP_CONTENT, LayoutParams.WRAP_CONTENT));
            view.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);

            view.Measure(displayMetrics.WidthPixels, displayMetrics.HeightPixels);

            view.Layout(0, 0, 240, 240);
           
            view.BuildDrawingCache();
            Bitmap bitmap = Bitmap.CreateBitmap(displayMetrics.WidthPixels, displayMetrics.HeightPixels, Bitmap.Config.Argb8888);
            Bitmap bhalfsize = Bitmap.CreateScaledBitmap(bitmap, bitmap.Width/ 2, bitmap.Height/ 2, false);
            Canvas canvas = new Canvas(bhalfsize);
            view.Draw(canvas);

            return bhalfsize;

        }

        public void OnMapReady(GoogleMap googleMap)
        {
            this.gmap = googleMap;
            var s = this.Activity.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
            View  viewMarker = s.Inflate(Resource.Layout.view_custom_marker, null);
            Bitmap bmp = CreateDrawableFromView(this.Activity, viewMarker);

            gmap.UiSettings.ZoomControlsEnabled = true;
            gmap.UiSettings.ScrollGesturesEnabled = true;
            gmap.UiSettings.ZoomGesturesEnabled = true;
            LatLng latlng = new LatLng(21.183549, 72.783175);
            LatLng latlng2 = new LatLng(21.186312, 72.783175);
            LatLng latlng3 = new LatLng(21.190160, 72.778953);
            LatLng latlng4 = new LatLng(21.182070, 72.782674);
            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng, 15);
           
            //var color = BitmapDescriptorFactory.HueBlue;
            gmap.MoveCamera(camera);
            Marker m1 = gmap.AddMarker(new MarkerOptions()
             .SetPosition(latlng)
             .SetIcon(BitmapDescriptorFactory.FromBitmap(bmp)));

              gmap.SetInfoWindowAdapter(this);
              gmap.SetOnInfoWindowClickListener(this);

       
            //Marker m1 = gmap.AddMarker(new MarkerOptions()
            //    .SetPosition(latlng)
            //    .SetTitle("Title1")
            //    .SetSnippet("Snippet1")
            //    .SetIcon(BitmapDescriptorFactory.DefaultMarker(color)));

            Marker m2 = gmap.AddMarker(new MarkerOptions()
              .SetPosition(latlng2)
              .SetTitle("Title2")
              .SetSnippet("Snippet2")
              .SetIcon(BitmapDescriptorFactory.FromBitmap(bmp)));
           


            Marker m3 = gmap.AddMarker(new MarkerOptions()
              .SetPosition(latlng3)
              .SetTitle("Title3")
              .SetSnippet("Snippet3")
              .SetIcon(BitmapDescriptorFactory.FromBitmap(bmp)));
           

            Marker m4 = gmap.AddMarker(new MarkerOptions()
             .SetPosition(latlng4)
             .SetTitle("Title4")
             .SetSnippet("Snippet4s")
             .SetIcon(BitmapDescriptorFactory.FromBitmap(bmp)));
           



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

        public View GetInfoContents(Marker marker)
        {
            return null;
        }

        public View GetInfoWindow(Marker marker)
        {
            View view=   LayoutInflater.Inflate(Resource.Layout.InfoWindow, null);
            view.FindViewById<TextView>(Resource.Id.name).Text = "sweta";
        
            return view;

        }

        public void OnInfoWindowClick(Marker marker)
        {
            Intent i = new Intent(this.Activity, typeof(ProviderProfileActivity));
            StartActivity(i);
        }
    }

}