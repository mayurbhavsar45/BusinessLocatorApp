using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Uri = Android.Net.Uri;

using Com.Github.Florent37.Diagonallayout;
using Fragment = Android.Support.V4.App.Fragment;
using Plugin.Settings;

namespace BusinessLocator.Android
{
    public class ProfileFragment : Fragment
    {
        TextView lblpwd, lblconsumer, lblName;
        ImageButton btnfilter, edit;
        ImageView profileimage, coverimage;
        Uri imageuri;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v=inflater.Inflate(Resource.Layout.ProfileFragment, container, false);
            btnfilter= v.FindViewById<ImageButton>(Resource.Id.btnFilter);
            edit = v.FindViewById<ImageButton>(Resource.Id.edit);
            profileimage = v.FindViewById<ImageView>(Resource.Id.profile);
            coverimage = v.FindViewById<ImageView>(Resource.Id.cover);


            lblpwd = v.FindViewById<TextView>(Resource.Id.lblchangepwd);
            lblconsumer = v.FindViewById<TextView>(Resource.Id.lblconsumer);

            lblName = v.FindViewById<TextView>(Resource.Id.name);

            lblName.Text = CrossSettings.Current.GetValueOrDefault("UserName", "");

            lblpwd.Click += Lblpwd_Click;
            btnfilter.Click += Btnfilter_Click;
            edit.Click += Edit_Click;
             return v ;    
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            var imageIntent = new Intent(Intent.ActionPick, MediaStore.Images.Media.ExternalContentUri);

            //imageIntent.SetType("image/*");
            //imageIntent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(
                Intent.CreateChooser(imageIntent, "Select photo"),2);
        }

        public override void OnActivityResult(int requestCode, int resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == 2)
            {
                if (data != null)
                {

                    imageuri = data.Data;
                    profileimage.SetImageURI(data.Data);
                    coverimage.SetImageURI(data.Data);
                    //    imgproductsymbol.Visibility = ViewStates.Gone;
                    //     imgtextlbl.Visibility = ViewStates.Gone;

                   // Toast.MakeText(this.Activity, data.Data.ToString(), ToastLength.Short).Show();

                }
            }
        }

        private void Lblpwd_Click(object sender, EventArgs e)
        {

            Intent i = new Intent(this.Activity, typeof(ChangePasswordActivity));
            StartActivity(i);
        }

        private void Btnfilter_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this.Activity, typeof(SettingActivity));
            StartActivity(i);
        }

        
    }
}