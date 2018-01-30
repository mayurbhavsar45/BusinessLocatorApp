using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Views;
using BusinessLocator.Android.Adapters;
using BusinessLocator.Android.Fragments;
using Fragment = Android.Support.V4.App.Fragment;

namespace BusinessLocator.Android
{
    [Activity(Label = "",Theme ="@style/MyTheme", MainLauncher = true)]

    public class MainActivity : AppCompatActivity
    {
    
        BottomNavigationView bottomNavigation;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
           // Toast.MakeText(this, "hello", ToastLength.Short).Show();

            bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            bottomNavigation.SetShiftMode(false, false);
            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;
            LoadFragment(Resource.Id.menu_location);
        }

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }
        void LoadFragment(int id)
        {
            Fragment fragment = null;
            switch (id)
            {
                case Resource.Id.menu_location:
                    fragment = new LocationFragment();
                    break;
                case Resource.Id.menu_inbox:
                    fragment = new InboxFragment();
                    break;
                case Resource.Id.menu_notification:
                    fragment = new NotificationFragment();
                    break;
                case Resource.Id.menu_walls:
                    fragment = new WallsFragment();
                    break;
                case Resource.Id.menu_profile:
                    fragment = new ProfileFragment();
                    break;
            }
            if (fragment == null)
                return;

            SupportFragmentManager.BeginTransaction()
               .Replace(Resource.Id.content_frame, fragment)
               .Commit();
        }
    }
}

