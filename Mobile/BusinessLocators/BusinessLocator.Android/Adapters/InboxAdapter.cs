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
    class InboxAdapter : BaseAdapter<InboxClass>
    {
        Activity context;
        List<InboxClass> list;

        public InboxAdapter(Activity _context, List<InboxClass> _list) : base()
        {
            this.context = _context;
            this.list = _list;

        }
        public override InboxClass this[int position]
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
                view = context.LayoutInflater.Inflate(Resource.Layout.ListViewScreenItems, parent, false);

            InboxClass item = this[position];

            view.FindViewById<TextView>(Resource.Id.name).Text = item.name;
            view.FindViewById<TextView>(Resource.Id.txtmsg).Text = item.msg;
            view.FindViewById<TextView>(Resource.Id.count).Text = item.count.ToString();
            view.FindViewById<TextView>(Resource.Id.lbltime).Text = item.time;
            view.FindViewById<ImageView>(Resource.Id.profile).SetImageResource(item.image);
            
            return view;
        }
    }
}