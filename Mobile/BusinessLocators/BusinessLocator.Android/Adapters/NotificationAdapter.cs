using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BusinessLocator.Android.Models;


namespace BusinessLocator.Android.Adapters
{
    class NotificationAdapter : BaseAdapter<NotificationModel>
    {
        Activity context;
        List<NotificationModel> list;

        public NotificationAdapter(Activity _context, List<NotificationModel> _list) : base()

        {
            this.context = _context;
            this.list = _list;

        }
        public override NotificationModel this[int position]
        {
            get
            {
                return list[position];
            }
        }


        public override int Count
        {
            get
            {
                return list.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;


            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.NotificationItem, parent, false);

            NotificationModel item = this[position];

            view.FindViewById<TextView>(Resource.Id.name).Text = item.name;
            view.FindViewById<TextView>(Resource.Id.txtmsg).Text = item.msg;
         
            view.FindViewById<TextView>(Resource.Id.lbltime).Text = item.time;
            var a=  item.image;
            var count = item.count;
            if(a==0 && count==0)
            {
                view.FindViewById<TextView>(Resource.Id.count).Visibility = ViewStates.Gone;
                view.FindViewById<ImageView>(Resource.Id.profile).Visibility = ViewStates.Gone;
            }
            else
            {
                view.FindViewById<ImageView>(Resource.Id.profile).Visibility = ViewStates.Visible;
                view.FindViewById<TextView>(Resource.Id.count).Visibility = ViewStates.Visible;
                view.FindViewById<ImageView>(Resource.Id.profile).SetImageResource(item.image);
                view.FindViewById<TextView>(Resource.Id.count).Text = item.count.ToString();
            }

            return view;
        }
    }
}