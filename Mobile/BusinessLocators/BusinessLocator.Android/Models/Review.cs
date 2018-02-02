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
    class Review
    {
        
        public string review { get; set; }
        public string time { get; set; }
        public int image { get; set; }
    }
}