using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;


namespace BusinessLocator.Android
{
    [Activity(Label = "BusinessLocator", Theme = "@style/MyTheme", WindowSoftInputMode = SoftInput.StateHidden)]
    public class LoginActivity : AppCompatActivity
    {
        TextView signuplink,forgotpwdlink;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Login);
            signuplink = FindViewById<TextView>(Resource.Id.signuplink);
            forgotpwdlink = FindViewById<TextView>(Resource.Id.forgotpwdlink);
            signuplink.Click += Signuplink_Click;
            forgotpwdlink.Click += Forgotpwdlink_Click;
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