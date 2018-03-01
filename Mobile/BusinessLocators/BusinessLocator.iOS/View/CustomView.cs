using Foundation;
using System;
using UIKit;
using ObjCRuntime;
using System.ComponentModel;

namespace BusinessLocator.iOS
{
    public partial class CustomView : UIView
    {
        public CustomView (IntPtr handle) : base (handle)
        {
        }

        public CustomView()
        {
        }

        public CustomView Create()
        {
            //var arr = NSBundle.MainBundle.LoadNib("CustomView", this, null);
            //var v = Runtime.GetNSObject<CustomView>(arr.ValueAt(0));
            var v = Runtime.GetNSObject(NSBundle.MainBundle.LoadNib("CustomView", this, null).ValueAt(0)) as CustomView;
            v.BackgroundColor = UIColor.Clear;
            return v;
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            this.lblName.Text = CommonClass.Name;
            this.lblMobileNumber.Text = CommonClass.MobileNumber;
        }

    }
}