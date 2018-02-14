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
using Plugin.Settings;
using AlertDialog = Android.Support.V7.App.AlertDialog;


namespace BusinessLocator.Android
{
    [Activity(Label = "SettingActivity", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize, WindowSoftInputMode = SoftInput.StateHidden)]
    public class SettingActivity : AppCompatActivity
    {
        ImageButton btnback;
        Button btnlogout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Setting);
            btnback = FindViewById<ImageButton>(Resource.Id.btnback);
            btnlogout= FindViewById<Button>(Resource.Id.btnlogout);
            btnback.Click += Btnback_Click;
            btnlogout.Click += Btnlogout_Click;
        }

        private void Btnlogout_Click(object sender, EventArgs e)
        {
        
            //Intent i = new Intent(this, typeof(LoginActivity));

            new AlertDialog.Builder(this)
                   .SetTitle("Logout")
                   .SetMessage("Are you sure you want to logout?")
                   .SetPositiveButton("Logout", (sv, e1) => Logout())
                   .SetNegativeButton("Cancel", (sv, e1) => { })
                   .Show();
   
        }

        private void Logout()
        {
            CrossSettings.Current.Clear();
            StartActivity(typeof(LoginActivity));
            Finish();

        }

        private void Btnback_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}