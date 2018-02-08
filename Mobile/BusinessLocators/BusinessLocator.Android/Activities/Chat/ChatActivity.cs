using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Animation;
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
    [Activity(Label = "ChatActivity", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize, WindowSoftInputMode = SoftInput.StateHidden)]
    public class ChatActivity : AppCompatActivity,Animator.IAnimatorListener
    {
        ImageView profile;
        TextView name;
        ImageButton btnback,btnattach;
        Button subscriptionbutton;
        RelativeLayout lrevel;
        bool hidden = true;
        Animator animator, animate;

        public void OnAnimationCancel(Animator animation)
        {
            //throw new NotImplementedException();
        }

        public void OnAnimationEnd(Animator animation)
        {
            lrevel.Visibility = ViewStates.Invisible;
            hidden = true;
        }

        public void OnAnimationRepeat(Animator animation)
        {
            
        }

        public void OnAnimationStart(Animator animation)
        {
            lrevel.Visibility = ViewStates.Visible;
            hidden = false;
            animator.Start();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Chat);
            int imgid, sid;
            string title;

            imgid = Intent.GetIntExtra("imgid", 0);
            sid = Intent.GetIntExtra("sid", 0);
            title = Intent.GetStringExtra("name");

            profile = FindViewById<ImageView>(Resource.Id.profile);
            btnback = FindViewById<ImageButton>(Resource.Id.btnback);
            name = FindViewById<TextView>(Resource.Id.lblTitle);
            lrevel = FindViewById<RelativeLayout>(Resource.Id.RevealCollection);
            btnattach= FindViewById<ImageButton>(Resource.Id.btnattach);
            subscriptionbutton= FindViewById<Button>(Resource.Id.subbtn);
            subscriptionbutton.Click += Subscriptionbutton_Click;

            lrevel.Visibility = ViewStates.Invisible;

            btnattach.Click += Btnattach_Click;
            btnback.Click += Btnback_Click;
          
            profile.SetImageResource(imgid);
            name.Text = title.ToString();
         
        }

        private void Subscriptionbutton_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(SubscriptionActivity));
            StartActivity(i);
        }

        private void Btnattach_Click(object sender, EventArgs e)
        {

            int cx = (lrevel.Left + lrevel.Right);
            int cy = (lrevel.Top);
            int startradius = 0;
            int endradius = Math.Max(lrevel.Width, lrevel.Height);
            animator= ViewAnimationUtils.CreateCircularReveal(lrevel, cx, cy, startradius, endradius);
            animator.SetDuration(400);

            int reverse_startradius= Math.Max(lrevel.Width, lrevel.Height);
            int reverse_endradius = 0;
            animate = ViewAnimationUtils.CreateCircularReveal(lrevel, cx, cy, reverse_startradius, reverse_endradius);

            if(hidden)
            {
                lrevel.Visibility = ViewStates.Visible;
                hidden = false;
                animator.Start();
            }
            else
            {
                animate.AddListener(this);
                animate.Start();
                hidden = true;
            }
        }

        private void Btnback_Click(object sender, EventArgs e)
        {
            Finish();
        }

     
    }
}