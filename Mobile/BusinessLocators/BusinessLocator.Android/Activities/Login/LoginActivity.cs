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


namespace BusinessLocator.Android
{
    [Activity(Label = "BusinessLocator", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize, WindowSoftInputMode = SoftInput.StateHidden)]
    public class LoginActivity : AppCompatActivity
    {
        TextView signuplink,forgotpwdlink;
        Button btnlogin;
        EditText euname,epwd;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Login);
            signuplink = FindViewById<TextView>(Resource.Id.signuplink);
            forgotpwdlink = FindViewById<TextView>(Resource.Id.forgotpwdlink);
            btnlogin = FindViewById<Button>(Resource.Id.btnlogin);
            euname = FindViewById<EditText>(Resource.Id.euname);
            epwd = FindViewById<EditText>(Resource.Id.epwd);
            euname.Text = "provider@gmail.com";
            epwd.Text = "provider";

            signuplink.Click += Signuplink_Click;
            forgotpwdlink.Click += Forgotpwdlink_Click;
            btnlogin.Click += Btnlogin_Click;
        }

        private void Btnlogin_Click(object sender, EventArgs e)
        {
            if (euname.Text.ToString().Equals("provider@gmail.com") && epwd.Text.ToString().Equals("provider"))
            {
                Intent i = new Intent(this, typeof(ProviderMainActivity));
                StartActivity(i);
            }
            else
            {
                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
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

    }
}