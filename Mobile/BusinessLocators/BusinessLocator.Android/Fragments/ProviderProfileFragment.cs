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
using Fragment = Android.Support.V4.App.Fragment;
using Uri = Android.Net.Uri;

namespace BusinessLocator.Android.Fragments
{
    public class ProviderProfileFragment : Fragment
    {
        TextView changpwd;
        ImageButton btnfilter, edit;
        ImageView profileimage, coverimage;
        Uri imageuri;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View v = inflater.Inflate(Resource.Layout.ProviderProfileFragment, container, false);
            profileimage = v.FindViewById<ImageView>(Resource.Id.profile);
            coverimage = v.FindViewById<ImageView>(Resource.Id.cover);
            edit = v.FindViewById<ImageButton>(Resource.Id.edit);
            changpwd = v.FindViewById<TextView>(Resource.Id.lblchangepwd);
            changpwd.Click += Changpwd_Click;
            edit.Click += Edit_Click;
            return v;
        }

        private void Edit_Click(object sender, EventArgs e)
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
                    profileimage.SetImageURI(data.Data);
                    coverimage.SetImageURI(data.Data);
                  

                }
            }
        }
        private void Changpwd_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this.Activity, typeof(OTPVerificationActivity));
            StartActivity(i);
        }
    }
}