using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using BusinessLocator.Android.Adapters;
using BusinessLocator.Android.Models;

namespace BusinessLocator.Android
{
    [Activity(Label = "ProductActivity", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize, WindowSoftInputMode = SoftInput.StateHidden)]
    public class ProductActivity : AppCompatActivity
    {
        RecyclerView rv;
        ProductAdapter adp;
        RecyclerView.LayoutManager layoutmanager;
        List<Product> lstdata = new List<Product>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Product);
            lstdata.Add(new Product() { imgid = Resource.Drawable.product4, title = "Duos Shampoo og Basim 2x750ml",price=40 });
            lstdata.Add(new Product() { imgid = Resource.Drawable.product3, title = "Vitamino color mask 200ml",price = 60 });
            lstdata.Add(new Product() { imgid = Resource.Drawable.product4, title = "Duos Shampoo og Basim 2x750ml",price = 60 });
            lstdata.Add(new Product() { imgid = Resource.Drawable.product3, title = "Vitamino color mask 200ml",price=40 });
            lstdata.Add(new Product() { imgid = Resource.Drawable.product4, title = "Duos Shampoo og Basim 2x750ml", price = 60 });
            lstdata.Add(new Product() { imgid = Resource.Drawable.product3, title = "Vitamino color mask 200ml", price = 40 });
            lstdata.Add(new Product() { imgid = Resource.Drawable.product4, title = "Duos Shampoo og Basim 2x750ml", price = 60 });
            lstdata.Add(new Product() { imgid = Resource.Drawable.product3, title = "Vitamino color mask 200ml", price = 40 });
            lstdata.Add(new Product() { imgid = Resource.Drawable.product4, title = "Duos Shampoo og Basim 2x750ml", price = 60 });
            lstdata.Add(new Product() { imgid = Resource.Drawable.product3, title = "Vitamino color mask 200ml", price = 40 });

            rv = FindViewById<RecyclerView>(Resource.Id.recycle);
            //layoutmanager  = new LinearLayoutManager(this.Activity);
            layoutmanager = new GridLayoutManager(this, 2);

            adp = new ProductAdapter(lstdata);
            adp.ItemClick += Adp_ItemClick;  
            rv.SetAdapter(adp);
            rv.SetLayoutManager(layoutmanager);

            // Create your application here
        }

        private void Adp_ItemClick(object sender, int position)
        {
            Dialog dialog = new Dialog(this);
            dialog.SetContentView(Resource.Layout.ProductDialog);
            TextView ptitle = dialog.FindViewById<TextView>(Resource.Id.ptitle);
            TextView price = dialog.FindViewById<TextView>(Resource.Id.price);
            TextView quantity= dialog.FindViewById<TextView>(Resource.Id.quantity);
            ImageView pimage= dialog.FindViewById<ImageView>(Resource.Id.pimage);
            pimage.SetImageResource(lstdata[position].imgid);
            quantity.Text = "2";
            price.Text = lstdata[position].price.ToString();
            ptitle.Text= lstdata[position].title;
            dialog.Show();
          
            //Toast.MakeText(this, id.ToString() + " " + title.ToString(), ToastLength.Short).Show();
        }
    }
}