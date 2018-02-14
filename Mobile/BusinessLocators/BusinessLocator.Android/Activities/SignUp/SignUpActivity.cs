using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using BusinessLocator.Shared.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Android.Provider;
using Plugin.Connectivity;
using AlertDialog = Android.App.AlertDialog;
using System.Threading.Tasks;

namespace BusinessLocator.Android
{
    [Activity(Label = "SignUpActivity", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize, WindowSoftInputMode = SoftInput.StateHidden)]
    public class SignUpActivity : AppCompatActivity, ILocationListener
    {
        ImageButton btnback;
        EditText uname, email, pwd, phone;
        Button btnsignup;
        LocationManager service;
        Spinner role;
        Location _currentLocation, location;
        string provider;
        double latitude;
        double longitude;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SignUp);
            btnback = FindViewById<ImageButton>(Resource.Id.btnback);
            email = FindViewById<EditText>(Resource.Id.eemail);
            pwd = FindViewById<EditText>(Resource.Id.password);
            uname = FindViewById<EditText>(Resource.Id.euname);
            phone = FindViewById<EditText>(Resource.Id.ephone);
            role = FindViewById<Spinner>(Resource.Id.erole);

            btnsignup = FindViewById<Button>(Resource.Id.btnsignup);
            btnsignup.Click += Btnsignup_Click;
            btnback.Click += Btnback_Click;
            service = (LocationManager)GetSystemService(Context.LocationService);
            provider = service.GetBestProvider(new Criteria(), false);
            enableGPS();
            //Location location = service.GetLastKnownLocation(provider);
            // location.Accuracy = (float)Accuracy.High;

            //InitializeLocationManager();
        }


        void enableGPS()
        {

            Boolean enabled = service.IsProviderEnabled(provider);

            if (!enabled)
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Location Services Not Active");

                alert.SetMessage("Please enable Location Services and GPS");
                alert.SetPositiveButton("Ok", (c, ev) =>
                {
                    StartActivity(new Intent(Settings.ActionLocationSourceSettings));
                });
                alert.Show();
            }

        }
        protected override void OnPause()
        {
            base.OnPause();
            service.RemoveUpdates(this);
        }
        protected override void OnResume()
        {
            base.OnResume();
            service.RequestLocationUpdates(provider, 400, 1, this);
        }

        private void Btnback_Click(object sender, EventArgs e)
        {
            Finish();
        }
        public void Checkvaliduserinput()
        {
            if (uname.Text == "")
            {
                uname.Error = "Please enter username";
            }
            else if (!IsValidUser(uname.Text))
            {
                uname.Error = "Invalid username.\nUsername must be only alphanumeric.\nUsername must be between 6 to 14 characters";
            }

            if (pwd.Text == "")
            {
                pwd.Error = "Please enter password";
            }
            else if (!IsValidPassword(pwd.Text))
            {
                pwd.Error = "Password must be 6 characters long";
            }

            if (email.Text == "")
            {
                email.Error = "Please enter email";

            }
            else if (!IsValidEmail(email.Text))
            {
                email.Error = "Invalid Email";
            }

            if (phone.Text == "")
            {
                phone.Error = "Please enter Phone number";

            }
            else if (!IsValidPhone(phone.Text))
            {
                phone.Error = "Phone number must be 10 digits long";
            }
        }
        private Boolean IsValidEmail(String email)
        {
            Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            return EmailRegex.IsMatch(email);
        }
        private Boolean IsValidUser(String user)
        {
            Regex UserRegex = new Regex(@"^[a-zA-Z0-9_-]{6,14}$");

            return UserRegex.IsMatch(user);
        }
        private Boolean IsValidPhone(String phone)
        {
            Regex PhoneRegex = new Regex(@"^\d{10}$");

            return PhoneRegex.IsMatch(phone);
        }
        private Boolean IsValidPassword(String pass)
        {
            if (pass != null && pass.Length >= 6)
            {
                return true;
            }
            return false;
        }

        private void Btnsignup_Click(object sender, EventArgs e)
        {

            //if (location == null)
            //{
            //    //  new AlertDialog.Builder(this).SetTitle("Error").SetMessage("Please check your connection ,try after some time").SetNeutralButton("Ok", (se, ev) => { }).Show();
            //    latitude = 0;
            //    longitude = 0;
            //}
            //else
            //{
            Checkvaliduserinput();
            if (uname.Text != "" && pwd.Text != "" && email.Text != "" && phone.Text != "" && IsValidPassword(pwd.Text) && IsValidUser(uname.Text) && IsValidEmail(email.Text) && IsValidPhone(phone.Text))
            {
                //Intent i = new Intent(this, typeof(MainActivity));
                //  StartActivity(i);

                latitude = 0;
                longitude = 0;


                if (CrossConnectivity.Current.IsConnected)
                {

                    var response = new ServiceApi().Register(uname.Text, email.Text, phone.Text, pwd.Text, role.SelectedItem.ToString(), latitude, longitude);
                    if (response.IsSuccessStatusCode)
                    {
                        var success = response.Content.ReadAsStringAsync();
                        var s = JsonConvert.DeserializeObject<JObject>(success.Result);
                        new AlertDialog.Builder(this).SetTitle("Success").SetMessage(s["Message"].ToString()).SetNeutralButton("Ok", (se, ev) => { }).Show();
                    }
                    else
                    {
                        var sv = response.Content.ReadAsStringAsync();
                        var error = JsonConvert.DeserializeObject<JObject>(sv.Result);
                        string errors = "";
                        errors = error["Message"].ToString();

                        //if (error["modelstate"] != null)
                        //{
                        //    foreach (var err in error["ModelState"])
                        //    {
                        //        errors += err.Values().FirstOrDefault() + "\n";
                        //    }
                        //}


                        //errors = errors.Trim();
                        new AlertDialog.Builder(this).SetTitle("Error").SetMessage(errors.ToString()).SetNeutralButton("Ok", (se, ev) => { }).Show();

                    }

                }
                else
                {
                    new AlertDialog.Builder(this).SetTitle("Error").SetMessage("No Internet Connection").SetNeutralButton("Ok", (s, ev) => { }).Show();
                }



                //}






            }






        }

        async Task<Address> ReverseGeocodeCurrentLocation()
        {
            Geocoder geocoder = new Geocoder(this);
            IList<Address> addressList =
                await geocoder.GetFromLocationAsync(_currentLocation.Latitude, _currentLocation.Longitude, 10);

            Address address = addressList.FirstOrDefault();
            return address;
        }
        void DisplayAddress(Address address)
        {
            if (address != null)
            {
                StringBuilder deviceAddress = new StringBuilder();
                for (int i = 0; i < address.MaxAddressLineIndex; i++)
                {
                    deviceAddress.AppendLine(address.GetAddressLine(i));
                }
                Toast.MakeText(this, deviceAddress.ToString(), ToastLength.Short).Show();

                // _addressText.Text = deviceAddress.ToString();
            }
            else
            {
                Toast.MakeText(this, "Unable to determine the address. Try again in a few minutes.", ToastLength.Short).Show();
                //  _addressText.Text = "Unable to determine the address. Try again in a few minutes.";
            }
        }


        public async void OnLocationChanged(Location location)
        {
            _currentLocation = location;
            if (_currentLocation == null)
            {
                new AlertDialog.Builder(this).SetTitle("Error").SetMessage("Try Again").SetNeutralButton("Ok", (s, ev) => { }).Show();
            }
            else
            {
                Address address = await ReverseGeocodeCurrentLocation();
                DisplayAddress(address);
                Toast.MakeText(this, "Location Changed   " + _currentLocation.Latitude.ToString() + " " + _currentLocation.Longitude.ToString(), ToastLength.Short).Show();
            }

        }

        public void OnProviderDisabled(string provider)
        {
            //throw new NotImplementedException();
        }

        public void OnProviderEnabled(string provider)
        {
            //throw new NotImplementedException();
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            // throw new NotImplementedException();
        }
    }
}