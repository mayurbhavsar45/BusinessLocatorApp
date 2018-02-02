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
    class RecyclerViewHolder : RecyclerView.ViewHolder
    {
        public ImageView imgview { get; set; }
        public TextView title { get; set; }
        public TextView price { get; set; }


        public RecyclerViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            imgview = itemview.FindViewById<ImageView>(Resource.Id.image);
            title = itemview.FindViewById<TextView>(Resource.Id.title);
            price = itemview.FindViewById<TextView>(Resource.Id.price);
            itemview.Click += (sender, e) => listener(base.LayoutPosition);

        }
    }
    class ProductAdapter : RecyclerView.Adapter
    {
        public List<Product> lstdata = new List<Product>();
        public event EventHandler<int> ItemClick;
        public ProductAdapter(List<Product> lstdata)
        {
            this.lstdata = lstdata;
        }
        public override int ItemCount
        {
            get
            {
                return lstdata.Count;
            }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerViewHolder viewHolder = holder as RecyclerViewHolder;
            viewHolder.title.Text = lstdata[position].title;
            viewHolder.imgview.SetImageResource(lstdata[position].imgid);
            viewHolder.price.Text = lstdata[position].price.ToString();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemview = inflater.Inflate(Resource.Layout.ProductItem, parent, false);
            return new RecyclerViewHolder(itemview, OnClick);
        }
        void OnClick(int position)
        {
            ItemClick?.Invoke(this, position);
        }
    }
}