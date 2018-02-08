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
    public class InboxAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView name { get; set; }
        public TextView msg { get; set; }
        public TextView time { get; set; }
        public TextView count { get; set; }
        public ImageView image { get; set; }
         

        public InboxAdapterViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            name = itemview.FindViewById<TextView>(Resource.Id.name);
            msg = itemview.FindViewById<TextView>(Resource.Id.txtmsg);
            count = itemview.FindViewById<TextView>(Resource.Id.count);
            time = itemview.FindViewById<TextView>(Resource.Id.lbltime);
            image = itemview.FindViewById<ImageView>(Resource.Id.profile);
            itemview.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }
    class InboxAdapter : RecyclerView.Adapter
    {
        public List<Chat> lstdata = new List<Chat>();
        public event EventHandler<int> ItemClick;

        public InboxAdapter(List<Chat> lstdata)
        {
            this.lstdata = lstdata;
        }
        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemview = inflater.Inflate(Resource.Layout.InboxItem, parent, false);
            return new InboxAdapterViewHolder(itemview, OnClick);
        }

        void OnClick(int position)
        {
            ItemClick?.Invoke(this, position);
        }


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            InboxAdapterViewHolder viewHolder = holder as InboxAdapterViewHolder;
            viewHolder.name.Text = lstdata[position].name.ToString();
            viewHolder.msg.Text = lstdata[position].msg.ToString();
            viewHolder.time.Text = lstdata[position].time.ToString();
            viewHolder.count.Text = lstdata[position].count.ToString();
            viewHolder.image.SetImageResource(lstdata[position].image);

        }

        public override int ItemCount
        {
            get
            {
                return lstdata.Count;
            }
        }


    }

}