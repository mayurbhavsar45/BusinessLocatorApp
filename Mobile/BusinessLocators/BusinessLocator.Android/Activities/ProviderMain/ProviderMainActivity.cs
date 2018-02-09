using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Views;
using BusinessLocator.Android.Adapters;
using BusinessLocator.Android.Fragments;
using Fragment = Android.Support.V4.App.Fragment;
using Android.Content.PM;
using System;

namespace BusinessLocator.Android
{
    [Activity(Label = "", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize, WindowSoftInputMode = SoftInput.StateHidden)]
    public class ProviderMainActivity : AppCompatActivity
    {
        BottomNavigationView bottomNavigation;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ProviderMainlayout);

            bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            bottomNavigation.SetShiftMode(false, false);
            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;
            LoadFragment(Resource.Id.menu_location);

            // Create your application here
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
                    fragment = new ProviderInboxFragment();
                    break;
                case Resource.Id.menu_product:
                    fragment = new ProviderProductFragment();
                    break;
                case Resource.Id.menu_profile:
                    fragment = new ProviderProfileFragment();
                    break;
            }
            if (fragment == null)
                return;

            SupportFragmentManager.BeginTransaction()
               .Replace(Resource.Id.content_frame, fragment)
               .Commit();
        }

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }
    }
}