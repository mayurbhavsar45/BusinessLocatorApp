using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Views;

namespace BusinessLocator.Android
{
    [Activity(Label = "",Theme ="@style/MyTheme",MainLauncher =true)]

    public class MainActivity : AppCompatActivity
    {
        TextView titletoolbar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
          // // var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
          //  titletoolbar = FindViewById<TextView>(Resource.Id.toolbar_title);
          //  titletoolbar = FindViewById<TextView>(Resource.Id.toolbar_title);
           // titletoolbar.Text = "BUSINESS LOCATOR";
          //  SetSupportActionBar(toolbar);
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            //MenuInflater.Inflate(Resource.Menu.mainactivitymenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }


    }
}

