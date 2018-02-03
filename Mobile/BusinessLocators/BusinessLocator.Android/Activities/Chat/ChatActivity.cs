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
    [Activity(Label = "ChatActivity", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize, WindowSoftInputMode = SoftInput.StateHidden)]
    public class ChatActivity : AppCompatActivity
    {
        ImageView profile;
        TextView name;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Chat);
            int imgid, sid;
            string title;
            imgid = Intent.GetIntExtra("imgid", 0);
            sid = Intent.GetIntExtra("sid", 0);
            title = Intent.GetStringExtra("name");
            profile = FindViewById<ImageView>(Resource.Id.profile);
            name = FindViewById<TextView>(Resource.Id.lblTitle);
            profile.SetImageResource(imgid);
            name.Text = title.ToString();
            // Create your application here
        }
    }
}