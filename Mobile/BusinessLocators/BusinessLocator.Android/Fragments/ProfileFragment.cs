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
        LinearLayout layoutpwd, layoutconsumer;
        ImageButton btnfilter;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
           View v=inflater.Inflate(Resource.Layout.ProfileFragment, container, false);

            layoutpwd = v.FindViewById<LinearLayout>(Resource.Id.pwdlayout);
            btnfilter = v.FindViewById<ImageButton>(Resource.Id.btnFilter);
            btnfilter.Click += Btnfilter_Click;
            layoutpwd.Click += Layoutpwd_Click;
             return v ;

           
        }

        private void Btnfilter_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this.Activity, typeof(SettingActivity));
            StartActivity(i);
        }

        private void Layoutpwd_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this.Activity, typeof(ChangePasswordActivity));
            StartActivity(i);
        }
    }
}