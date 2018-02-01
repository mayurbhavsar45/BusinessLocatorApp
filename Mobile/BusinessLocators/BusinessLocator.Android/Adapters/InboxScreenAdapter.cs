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
using Refractored.Controls;

namespace BusinessLocator.Android.Adapters
{
    class InboxScreenAdapter : BaseAdapter<Chat>
    {
        Activity context;
        List<Chat> list;

        public InboxScreenAdapter(Activity _context, List<Chat> _list) :base()

        {
            this.context = _context;
            this.list = _list;

        }
        public override Chat this[int position]
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
                view = context.LayoutInflater.Inflate(Resource.Layout.InboxItem, parent, false);

            Chat item = this[position];

            view.FindViewById<TextView>(Resource.Id.name).Text = item.name;
            view.FindViewById<TextView>(Resource.Id.txtmsg).Text = item.msg;
            view.FindViewById<TextView>(Resource.Id.count).Text = item.count.ToString();
            view.FindViewById<TextView>(Resource.Id.lbltime).Text = item.time;
            view.FindViewById<ImageView>(Resource.Id.profile).SetImageResource(item.image);

            return view;
        }
    }
}