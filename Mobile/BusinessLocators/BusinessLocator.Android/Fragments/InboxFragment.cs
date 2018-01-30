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
using BusinessLocator.Android.Adapters;
using BusinessLocator.Android.Models;
using Fragment = Android.Support.V4.App.Fragment;

namespace BusinessLocator.Android.Fragments
{
    public class InboxFragment : Fragment
    {
        ListView lstview;
        List<InboxClass> lstSource;
        InboxAdapter adp;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.ListViewFragment, container, false);
            lstSource = new List<InboxClass>();
            lstview = v.FindViewById<ListView>(Resource.Id.list);
            lstSource.Add(new InboxClass() { sid = 1, name = "Bruce wills", msg = "303-304,Airen Heights,wore House road", image = Resource.Drawable.user2, time = "4:00 AM" ,count=10});
            lstSource.Add(new InboxClass() { sid = 2, name = "Bruce wills", msg = "303-304,Airen Heights,wore House road", image = Resource.Drawable.user1, time = "5:00 AM", count = 11 });
            lstSource.Add(new InboxClass() { sid = 3, name = "Bruce wills", msg = "303-304,Airen Heights,wore House road", image = Resource.Drawable.user3, time = "6:00 AM", count = 12 });
            adp = new InboxAdapter(this.Activity, lstSource);
            lstview.Adapter = adp;
            return v;
          
        }
    }
}