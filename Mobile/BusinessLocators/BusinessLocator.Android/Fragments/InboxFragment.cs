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
        List<Chat> lstSource;
        InboxScreenAdapter adp;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.InboxFragment, container, false);
            v.SetLayerType(LayerType.Hardware, null);
            lstSource = new List<Chat>();
            lstview = v.FindViewById<ListView>(Resource.Id.list);
      
            lstSource.Add(new Chat() { sid = 1, name = "George", msg = "Hiiii,How are u???", time = "4:00 AM", count = 10, image = Resource.Drawable.user2 });
            lstSource.Add(new Chat() { sid = 2, name = "Hank", msg = "Hellooo", time = "5:00 AM", count = 11, image = Resource.Drawable.user1 });
            lstSource.Add(new Chat() { sid = 3, name = "Harry", msg = "303-304,Airen Heights,wore House roadrrrrrrrrrrrrrrrrrrrrrrrrrr", time = "6:00 AM", count = 1, image = Resource.Drawable.user3 });
            lstSource.Add(new Chat() { sid = 4, name = "Henryy", msg = "303-304,Airen Heights,wore House roadrrrrrrrrrrrrrrrrrrrrrrrrrr", time = "6:00 AM", count = 4, image = Resource.Drawable.user4 });
            lstSource.Add(new Chat() { sid = 5, name = "Benjamin", msg = "303-304,Airen Heights,wore House roadrrrrrrrrrrrrrrrrrrrrrrrrrr", time = "6:00 AM", count = 10, image = Resource.Drawable.user1 });
            lstSource.Add(new Chat() { sid = 6, name = "Benjamin", msg = "303-304,Airen Heights,wore House roadrrrrrrrrrrrrrrrrrrrrrrrrrr", time = "6:00 AM", count = 10, image = Resource.Drawable.user1 });
            lstSource.Add(new Chat() { sid = 7, name = "Benjamin", msg = "303-304,Airen Heights,wore House roadrrrrrrrrrrrrrrrrrrrrrrrrrr", time = "6:00 AM", count = 10, image = Resource.Drawable.user1 });
            lstSource.Add(new Chat() { sid = 8, name = "Benjamin", msg = "303-304,Airen Heights,wore House roadrrrrrrrrrrrrrrrrrrrrrrrrrr", time = "6:00 AM", count = 10, image = Resource.Drawable.user1 });
            adp = new InboxScreenAdapter(this.Activity, lstSource);
            lstview.Adapter = adp;
            lstview.ItemClick += Lstview_ItemClick;
            return v;
          
        }

        private void Lstview_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var item = this.adp.GetItemAtPosition(e.Position);
            int imgid= item.image;
            int sid= item.sid;
            string name= item.name;
            Intent i = new Intent(this.Activity, typeof(ChatActivity));
            i.PutExtra("imgid", imgid);
            i.PutExtra("sid", sid);
            i.PutExtra("name", name);
            StartActivity(i);
        }
    }
}