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

namespace BusinessLocator.Android
{
    public class NotificationFragment : Fragment
    {
        ListView lstview;
        List<NotificationModel> lstSource;
        NotificationAdapter adp;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.NotificationFragment, container, false);
            lstSource = new List<NotificationModel>();
            lstview = v.FindViewById<ListView>(Resource.Id.list);

            lstSource.Add(new NotificationModel() { sid = 1, name = "George", msg = "Hiiii,How are u???", time = "4:00 AM", count = 10, image = Resource.Drawable.user2 });
            lstSource.Add(new NotificationModel() { sid = 2, name = "Hank", msg = "Hellooo", time = "5:00 AM", count = 11, image = Resource.Drawable.user1 });
            lstSource.Add(new NotificationModel() { sid = 3, name = "Harry", msg = "303-304,Airen Heights,wore House roadrrrrrrrrrrrrrrrrrrrrrrrrrr", time = "6:00 AM", count = 1, image = Resource.Drawable.user3 });
            lstSource.Add(new NotificationModel() { sid = 4, name = "Henryy", msg = "303-304,Airen Heights,wore House roadrrrrrrrrrrrrrrrrrrrrrrrrrr", time = "6:00 AM"});
            lstSource.Add(new NotificationModel() { sid = 5, name = "Benjamin", msg = "303-304,Airen Heights,wore House roadrrrrrrrrrrrrrrrrrrrrrrrrrr", time = "6:00 AM", count = 10, image = Resource.Drawable.user1 });
            lstSource.Add(new NotificationModel() { sid = 5, name = "Harryyyy", msg = "303-304,Airen Heights,wore House roadrrrrrrrrrrrrrrrrrrrrrrrrrr", time = "6:00 AM"});
            adp = new NotificationAdapter(this.Activity, lstSource);
            lstview.Adapter = adp;
            return v;
        }
    }
}