using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Util;
using Android.Views;
using Android.Widget;
using BusinessLocator.Android.Adapters;
using Fragment = Android.Support.V4.App.Fragment;
using Color = Android.Graphics.Color;

namespace BusinessLocator.Android.Fragments
{
    public class LocationFragment : Fragment
    {
        TabLayout tabLayout;
        ViewPager viewPager;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.LocationFragment, container, false);
            tabLayout = v.FindViewById<TabLayout>(Resource.Id.sliding_tabs);
            viewPager = v.FindViewById<ViewPager>(Resource.Id.viewpager);
            FnInitTabLayout();
            return v;
        }
        void FnInitTabLayout()
        {

            var fragments = new Fragment[]
            {
                new MapViewFragment(),
                new ListViewFragment()
               
            };

            var titles = CharSequence.ArrayFromStringArray(new[] {
                "Map View",
                "List View"
               
            });



            viewPager.Adapter = new ViewPagerAdapter(ChildFragmentManager, fragments, titles);
            tabLayout.SetTabTextColors(Color.Rgb(192, 192, 192), Color.Rgb(62, 133, 199));

            tabLayout.SetupWithViewPager(viewPager);
            //  tabLayout.GetTabAt(0).SetIcon(Resource.Drawable.home2);
           

        }
    }
}