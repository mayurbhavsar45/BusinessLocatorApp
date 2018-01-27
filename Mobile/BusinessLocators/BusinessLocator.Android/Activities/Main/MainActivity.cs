using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Views;
using BusinessLocator.Android.Adapters;

namespace BusinessLocator.Android
{
    [Activity(Label = "",Theme ="@style/MyTheme",MainLauncher =true)]

    public class MainActivity : AppCompatActivity
    {
        TextView titletoolbar;
        BottomNavigationView bottomNavigation;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
           // Toast.MakeText(this, "hello", ToastLength.Short).Show();

            bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            bottomNavigation.SetShiftMode(false, false);
       

        }
        

    }
}

