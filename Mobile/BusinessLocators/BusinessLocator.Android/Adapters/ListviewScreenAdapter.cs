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
    class ListviewScreenAdapter : BaseAdapter<Person>
    {
        Activity context;
        List<Person> list;

        public ListviewScreenAdapter(Activity _context, List<Person> _list) : base()
        {
            this.context = _context;
            this.list = _list;

        }
        public override Person this[int position]
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

            Person item = this[position];

            view.FindViewById<TextView>(Resource.Id.name).Text = item.name;
            view.FindViewById<TextView>(Resource.Id.phonelabel).Text = item.phone;
            view.FindViewById<TextView>(Resource.Id.locationtext).Text = item.address;
            view.FindViewById<ImageView>(Resource.Id.profile).SetImageResource(item.image);


            return view;
        }
    }
}