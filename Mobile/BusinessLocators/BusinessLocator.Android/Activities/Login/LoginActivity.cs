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
using BusinessLocator.Shared;
using BusinessLocator.Shared.Models;
using BusinessLocator.Shared.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;
using Plugin.Settings;
using AlertDialog = Android.App.AlertDialog;
using ProgressDialog = Android.App.ProgressDialog;

namespace BusinessLocator.Android
{
    [Activity(Label = "BusinessLocator", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize, WindowSoftInputMode = SoftInput.StateHidden)]
    public class LoginActivity : AppCompatActivity
    {
        TextView signuplink,forgotpwdlink;
        Button btnlogin;
        EditText euname,epwd;
        ProgressDialog progress = null;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Login);
            signuplink = FindViewById<TextView>(Resource.Id.signuplink);
            forgotpwdlink = FindViewById<TextView>(Resource.Id.forgotpwdlink);
            btnlogin = FindViewById<Button>(Resource.Id.btnlogin);
            euname = FindViewById<EditText>(Resource.Id.euname);
            epwd = FindViewById<EditText>(Resource.Id.epwd);
            euname.Text = "swetavanjara2017@gmail.com";
            epwd.Text = "Sweta@123";
            signuplink.Click += Signuplink_Click;
            forgotpwdlink.Click += Forgotpwdlink_Click;
            btnlogin.Click += Btnlogin_Click;
        }

        private void Btnlogin_Click(object sender, EventArgs e)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                //ShowDialog();

                var response = new ServiceApi().Login(euname.Text,epwd.Text);
               
                if (response.IsSuccessStatusCode)
                {
                    var success = response.Content.ReadAsStringAsync();
                    var s = JsonConvert.DeserializeObject<TokenResponse>(success.Result);
                    LocalStorage.SaveLogin(s);

                    var role = CrossSettings.Current.GetValueOrDefault("RoleName","");
                    if (role.Equals("Provider"))
                    {
                        StartActivity(new Intent(this, typeof(ProviderMainActivity)));
                    }
                    else
                    {
                        StartActivity(new Intent(this, typeof(MainActivity)));
                    }

                }
                else
                {
                    var error = response.Content.ReadAsStringAsync();
                    var s = JsonConvert.DeserializeObject<JObject>(error.Result);
                    var errors = "";
                    errors = s["error_description"].ToString();
                    new AlertDialog.Builder(this).SetTitle("Error").SetMessage(errors.ToString()).SetNeutralButton("Ok", (se, ev) => { }).Show();
                }
            }


        }

        private void Forgotpwdlink_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ForgotPasswordActivity));
            StartActivity(i);
        }

        private void Signuplink_Click(object sender, System.EventArgs e)
        {
           Intent i = new Intent(this, typeof(SignUpActivity));
           StartActivity(i);
        }
        void ShowDialog()
        {
            progress = new ProgressDialog(this);
            progress.Indeterminate = true;
            progress.SetProgressStyle(ProgressDialogStyle.Spinner);
            progress.SetMessage("Please wait...");
            progress.SetCancelable(false);
            progress.Show();
        }
        void HideDialog()
        {
            progress.Dismiss();
        }

    }
}