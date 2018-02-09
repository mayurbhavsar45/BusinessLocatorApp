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
    [Activity(Label = "SubscriptionActivity", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize, WindowSoftInputMode = SoftInput.StateHidden)]
    public class SubscriptionActivity : AppCompatActivity
    {
        ListView lstview;
        List<MSubscription> lstSource;
        SubscriptionAdapter adp;
        ImageButton btnback;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SubscriptionLayout);
            lstSource = new List<MSubscription>();
            lstview = FindViewById<ListView>(Resource.Id.list);
            btnback = FindViewById<ImageButton>(Resource.Id.btnback);

            lstSource.Add(new MSubscription() {  name = "Lorem lpsum is simply dummy text of the printing and typesetting industry.", price="$4.99" });
            lstSource.Add(new MSubscription() { name = "Lorem lpsum is simply dummy text of the printing and typesetting industry.", price = "$4.99" });
            lstSource.Add(new MSubscription() { name = "Lorem lpsum is simply dummy text of the printing and typesetting industry.", price = "$4.99" });
            lstSource.Add(new MSubscription() { name = "Lorem lpsum is simply dummy text of the printing and typesetting industry.", price = "$4.99" });

            adp = new SubscriptionAdapter(this, lstSource);
            lstview.Adapter = adp;
            btnback.Click += Btnback_Click;

        }

        private void Btnback_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}