    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace BusinessLocator.Android
{

    [Activity(Label = "ProviderProfileActivity", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize, WindowSoftInputMode = SoftInput.StateHidden)]
    public class ProviderProfileActivity : AppCompatActivity
    {
        LinearLayout productlayot,reviewconsumerlayout;
        ImageButton btnback;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ProviderProfile);
            RatingBar ratingBar =FindViewById<RatingBar>(Resource.Id.ratingBar);
            ImageButton btnback = FindViewById<ImageButton>(Resource.Id.btnback);
            LayerDrawable stars = (LayerDrawable)ratingBar.ProgressDrawable;
            stars.GetDrawable(2).SetColorFilter(Color.Yellow, PorterDuff.Mode.SrcAtop);

            productlayot = FindViewById<LinearLayout>(Resource.Id.productlayout);
            reviewconsumerlayout= FindViewById<LinearLayout>(Resource.Id.reviewconsumerlayout);
            productlayot.Click += Productlayot_Click;
            reviewconsumerlayout.Click += Reviewconsumerlayout_Click;
            btnback.Click += Btnback_Click;
            // Create your application here
        }

        private void Btnback_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void Reviewconsumerlayout_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ReviewByConsumerActivity));
            StartActivity(i);
        }

        private void Productlayot_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ProductActivity));
            StartActivity(i);
        }
    }
}