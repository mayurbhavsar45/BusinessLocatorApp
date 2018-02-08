using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using BusinessLocator.Android.Models;

namespace BusinessLocator.Android.Adapters
{
    class SubscriptionAdapter : BaseAdapter<MSubscription>
    {
        Activity context;
        List<MSubscription> list;

        public SubscriptionAdapter(Activity _context, List<MSubscription> _list) : base()

        {
            this.context = _context;
            this.list = _list;

        }

        public override MSubscription this[int position]
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
                view = context.LayoutInflater.Inflate(Resource.Layout.SubscriptionItem, parent, false);

            MSubscription item = this[position];

            if (position % 2 == 1)
            {
                view.FindViewById<RelativeLayout>(Resource.Id.backgroundlayout).SetBackgroundResource(Resource.Drawable.back2);

            }
            else
            {
                view.FindViewById<RelativeLayout>(Resource.Id.backgroundlayout).SetBackgroundResource(Resource.Drawable.back);

            }

            view.FindViewById<TextView>(Resource.Id.name).Text = item.name;
            view.FindViewById<TextView>(Resource.Id.price).Text = item.price.ToString();

            return view;
        }


    }


}