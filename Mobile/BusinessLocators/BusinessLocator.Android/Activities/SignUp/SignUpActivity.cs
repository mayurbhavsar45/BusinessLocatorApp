using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace BusinessLocator.Android
{
    [Activity(Label = "SignUp", Theme = "@style/MyTheme", WindowSoftInputMode = SoftInput.StateHidden)]
    public class SignUpActivity : AppCompatActivity
    {
        ImageButton btnback;
        EditText uname, email, pwd, phone;
        Button btnsignup;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SignUp);
            btnback = FindViewById<ImageButton>(Resource.Id.btnback);
            email = FindViewById<EditText>(Resource.Id.eemail);
            pwd = FindViewById<EditText>(Resource.Id.password);
            uname = FindViewById<EditText>(Resource.Id.euname);
            phone = FindViewById<EditText>(Resource.Id.ephone);
            btnsignup = FindViewById<Button>(Resource.Id.btnsignup);
            btnsignup.Click += Btnsignup_Click;
            btnback.Click += Btnback_Click;
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

            Checkvaliduserinput();
            if (uname.Text != "" && pwd.Text != "" && email.Text != "" && phone.Text != "" && IsValidPassword(pwd.Text) && IsValidUser(uname.Text) && IsValidEmail(email.Text) && IsValidPhone(phone.Text))
            {
                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
            }


        }
    }
}