    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace BusinessLocator.Android.Activities.Provider_Profile
{
    [Activity(Label = "ProviderProfileActivity", MainLauncher = true, Theme = "@style/MyTheme", WindowSoftInputMode = SoftInput.StateHidden)]
    public class ProviderProfileActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ProviderProfile);
            RatingBar ratingBar =FindViewById<RatingBar>(Resource.Id.ratingBar);
            LayerDrawable stars = (LayerDrawable)ratingBar.ProgressDrawable;
            stars.GetDrawable(2).SetColorFilter(Color.Yellow, PorterDuff.Mode.SrcAtop);
            // Create your application here
        }
    }
}