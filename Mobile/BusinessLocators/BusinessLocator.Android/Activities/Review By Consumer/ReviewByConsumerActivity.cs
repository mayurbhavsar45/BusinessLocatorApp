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
using BusinessLocator.Android.Adapters;
using BusinessLocator.Android.Models;

namespace BusinessLocator.Android
{
    [Activity(Label = "ReviewByConsumerActivity", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize, WindowSoftInputMode = SoftInput.StateHidden)]
    public class ReviewByConsumerActivity : AppCompatActivity
    {
        ListView lstview;
        List<Review> lstSource;
        ReviewConsumerAdapter adp;
        ImageButton btnback;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ReviewByConsumer);
            lstSource = new List<Review>();
            lstview =FindViewById<ListView>(Resource.Id.list);
            btnback = FindViewById<ImageButton>(Resource.Id.btnback);
            btnback.Click += Btnback_Click;
            lstSource.Add(new Review() { review = "Hiiii,How are u???", time = "03/1/2018", image = Resource.Drawable.user2 });
            lstSource.Add(new Review() { review = "Hellooo", time = "02/1/2018", image = Resource.Drawable.user2 });
            lstSource.Add(new Review() { review = "303-304,Airen Heights,wore House roadrrrrrrrrrrrrrrrrrrrrrrrrrr", time = "6:00 AM", image = Resource.Drawable.user2 });
            lstSource.Add(new Review() { review = "303-304,Airen Heights,wore House roadrrrrrrrrrrrrrrrrrrrrrrrrrr", time = "6:00 AM", image = Resource.Drawable.user5 });
            lstSource.Add(new Review() { review = "303-304,Airen Heights,wore House roadrrrrrrrrrrrrrrrrrrrrrrrrrr", time = "6:00 AM",  image = Resource.Drawable.user5 });
            lstSource.Add(new Review() { review = "303-304,Airen Heights,wore House roadrrrrrrrrrrrrrrrrrrrrrrrrrr", time = "6:00 AM", image = Resource.Drawable.user5 });
            lstSource.Add(new Review() { review = "303-304,Airen Heights,wore House roadrrrrrrrrrrrrrrrrrrrrrrrrrr", time = "6:00 AM", image = Resource.Drawable.user5 });
            lstSource.Add(new Review() { review = "303-304,Airen Heights,wore House roadrrrrrrrrrrrrrrrrrrrrrrrrrr", time = "6:00 AM", image = Resource.Drawable.user5 });

            adp = new ReviewConsumerAdapter(this, lstSource);
            lstview.Adapter = adp;
        }

        private void Btnback_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}