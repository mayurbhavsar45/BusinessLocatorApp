using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using BusinessLocator.Android.Adapters;
using BusinessLocator.Android.Models;
using Fragment = Android.Support.V4.App.Fragment;
using Uri = Android.Net.Uri;
using Android.Graphics;

namespace BusinessLocator.Android.Fragments
{
    public class ProviderProductFragment : Fragment
    {
        RecyclerView rv;
        ProductAdapter adp;
        RecyclerView.LayoutManager layoutmanager;
        List<Product> lstdata = new List<Product>();
        ImageButton btnadd;
        ImageView productimage,imgproductsymbol;
        TextView imgtextlbl;
        Uri imageuri;
       
      
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.ProviderProductFragment, container, false);
            rv = v.FindViewById<RecyclerView>(Resource.Id.recycle);
            btnadd = v.FindViewById<ImageButton>(Resource.Id.btnAdd);
            btnadd.Click += Btnadd_Click;

            lstdata.Add(new Product() { imgid = Resource.Drawable.product4, title = "Duos Shampoo og Basim 2x750ml", price = 40 });
            lstdata.Add(new Product() { imgid = Resource.Drawable.product3, title = "Vitamino color mask 200ml", price = 60 });
            lstdata.Add(new Product() { imgid = Resource.Drawable.product4, title = "Duos Shampoo og Basim 2x750ml", price = 60 });
            lstdata.Add(new Product() { imgid = Resource.Drawable.product3, title = "Vitamino color mask 200ml", price = 40 });
            lstdata.Add(new Product() { imgid = Resource.Drawable.product4, title = "Duos Shampoo og Basim 2x750ml", price = 60 });
            lstdata.Add(new Product() { imgid = Resource.Drawable.product3, title = "Vitamino color mask 200ml", price = 40 });
            lstdata.Add(new Product() { imgid = Resource.Drawable.product4, title = "Duos Shampoo og Basim 2x750ml", price = 60 });
            lstdata.Add(new Product() { imgid = Resource.Drawable.product3, title = "Vitamino color mask 200ml", price = 40 });
            lstdata.Add(new Product() { imgid = Resource.Drawable.product4, title = "Duos Shampoo og Basim 2x750ml", price = 60 });
            lstdata.Add(new Product() { imgid = Resource.Drawable.product3, title = "Vitamino color mask 200ml", price = 40 });

            //layoutmanager  = new LinearLayoutManager(this.Activity);
            layoutmanager = new GridLayoutManager(this.Activity, 2);

            adp = new ProductAdapter(lstdata);
            adp.ItemClick += Adp_ItemClick;
            rv.SetAdapter(adp);
            rv.SetLayoutManager(layoutmanager);

            return v;
        }

        private void Adp_ItemClick(object sender, int position)
        {
            Dialog dialog = new Dialog(this.Activity);
            dialog.SetContentView(Resource.Layout.ProviderProductShowDialog);
            dialog.FindViewById<ImageView>(Resource.Id.imageproduct).SetImageResource(lstdata[position].imgid);
            dialog.FindViewById<EditText>(Resource.Id.pname).Text = lstdata[position].title;
            dialog.FindViewById<EditText>(Resource.Id.pprice).Text = lstdata[position].price.ToString();
            dialog.FindViewById<EditText>(Resource.Id.pdesc).Text = "dgggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg";
            dialog.Show();

        }

        private void Btnadd_Click(object sender, EventArgs e)
        {
            Dialog dialog = new Dialog(this.Activity);
            dialog.SetContentView(Resource.Layout.ProviderProductAddDialog);
            productimage=  dialog.FindViewById<ImageView>(Resource.Id.imageproduct);
            productimage.Click += Imagebg_Click;
            imgproductsymbol= dialog.FindViewById<ImageView>(Resource.Id.img);
            imgtextlbl = dialog.FindViewById<TextView>(Resource.Id.imagetext);
            dialog.Show();
        }

        private void Imagebg_Click(object sender, EventArgs e)
        {
            var imageIntent = new Intent(Intent.ActionPick, MediaStore.Images.Media.ExternalContentUri);

            //imageIntent.SetType("image/*");
            //imageIntent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(
                Intent.CreateChooser(imageIntent, "Select photo"), 2);
        }
        public override void OnActivityResult(int requestCode, int resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == 2)
            {
                if (data != null)
                {
                   
                    imageuri = data.Data;
                    productimage.SetImageURI(data.Data);
                    imgproductsymbol.Visibility = ViewStates.Gone;
                    imgtextlbl.Visibility = ViewStates.Gone;

                    // Toast.MakeText(this.Activity, data.Data.ToString(), ToastLength.Short).Show();

                }
            }
        }
    }
}