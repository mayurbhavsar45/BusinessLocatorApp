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
using Android.Views;
using Android.Widget;

namespace BusinessLocator.Android
{
    [Activity(Label = "ForgotPasswordActivity", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize, WindowSoftInputMode = SoftInput.StateHidden)]
    public class ForgotPasswordActivity : AppCompatActivity
    {
        ImageButton btnback;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ForgotPassword);
            btnback = FindViewById<ImageButton>(Resource.Id.btnback);
            btnback.Click += Btnback_Click;
        }
        private void Btnback_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}