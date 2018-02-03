using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

using Com.Github.Florent37.Diagonallayout;
using Fragment = Android.Support.V4.App.Fragment;

namespace BusinessLocator.Android
{
    public class ProfileFragment : Fragment
    {
        TextView lblpwd, lblconsumer;
        ImageButton btnfilter;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
           View v=inflater.Inflate(Resource.Layout.ProfileFragment, container, false);
            btnfilter= v.FindViewById<ImageButton>(Resource.Id.btnFilter);
            lblpwd = v.FindViewById<TextView>(Resource.Id.lblchangepwd);
            lblconsumer = v.FindViewById<TextView>(Resource.Id.lblconsumer);
            lblpwd.Click += Lblpwd_Click;
            btnfilter.Click += Btnfilter_Click;
             return v ;    
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