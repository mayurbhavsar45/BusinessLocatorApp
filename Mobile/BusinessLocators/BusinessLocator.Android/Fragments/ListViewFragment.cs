using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using BusinessLocator.Android.Models;
using BusinessLocator.Android.Adapters;
using Fragment = Android.Support.V4.App.Fragment;

namespace BusinessLocator.Android.Fragments
{
    public class ListViewFragment : Fragment
    {
        ListView lstview;
        List<Person> lstSource;
        ListviewScreenAdapter adp;
        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v= inflater.Inflate(Resource.Layout.ListViewFragment, container, false);
            lstSource = new List<Person>();
            lstview = v.FindViewById<ListView>(Resource.Id.list);
            lstSource.Add(new Person() { sid = 1, name = "Bruce wills", address = "303-304,Airen Heights,wore House road", image = Resource.Drawable.user2, phone = "9362-265-214" });
            lstSource.Add(new Person() { sid = 2, name = "Bruce wills", address = "303-304,Airen Heights,wore House road", image = Resource.Drawable.user3, phone = "9362-265-214" });
            lstSource.Add(new Person() { sid = 3, name = "Bruce wills", address = "303-304,Airen Heights,wore House road", image = Resource.Drawable.user1, phone = "9362-265-214" });
            adp = new ListviewScreenAdapter(this.Activity, lstSource);
            lstview.Adapter = adp;
            return v;

          
        }
    }
}