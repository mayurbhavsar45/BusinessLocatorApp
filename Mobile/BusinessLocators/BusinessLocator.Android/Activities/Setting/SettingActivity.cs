using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace BusinessLocator.Android
{
    [Activity(Label = "SettingActivity", Theme = "@style/MyTheme", WindowSoftInputMode = SoftInput.StateHidden)]
    public class SettingActivity : AppCompatActivity
    {
        ImageButton btnback;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Setting);
            btnback = FindViewById<ImageButton>(Resource.Id.btnback);
            btnback.Click += Btnback_Click;
        }
        private void Btnback_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}