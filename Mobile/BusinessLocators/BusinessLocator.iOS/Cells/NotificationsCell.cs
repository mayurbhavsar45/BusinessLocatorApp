using Foundation;
using System;
using UIKit;
using BusinessLocator.iOS.Model;
using CoreAnimation;

namespace BusinessLocator.iOS
{
    public partial class NotificationsCell : UITableViewCell
    {
        private NSString cellID;

        public NotificationsCell (IntPtr handle) : base (handle)
        {
        }

        public NotificationsCell(NSString cellID)
        {
            this.cellID = cellID;
        }

        public void UpdateCell(NotificationTableItemModel data)
        {
            ProfileImage.Image = UIImage.FromFile(data.Image);
            lblName.Text = data.Name;
            lblDescription.Text = data.Description;
            lblDuration.Text = data.Duration;
            btnCount.SetTitle(data.MesaageCount, UIControlState.Normal);
        }

        public override void LayoutSubviews()
        {
            CALayer profileImageCircle = ProfileImage.Layer;
            profileImageCircle.CornerRadius = 34;
            profileImageCircle.BorderColor = UIColor.FromRGB(98, 107, 186).CGColor;
            profileImageCircle.BorderWidth = 3;
            profileImageCircle.MasksToBounds = true;

        }
    }
}