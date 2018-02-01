using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace BusinessLocator.Android.Models
{
    class Chat
    {
        public int sid { get; set; }
        public string name { get; set; }
        public string msg { get; set; }
        public string time { get; set; }
        public int count { get; set; }
        public int image { get; set; }
    }
}