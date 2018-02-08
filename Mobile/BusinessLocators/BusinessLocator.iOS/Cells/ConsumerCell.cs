using Foundation;
using System;
using UIKit;
using BusinessLocator.iOS.Model;
using CoreAnimation;

namespace BusinessLocator.iOS
{
    public partial class ConsumerCell : UITableViewCell
    {
        private string cellID;

        public ConsumerCell (IntPtr handle) : base (handle)
        {
        }

        public ConsumerCell(string cellID)
        {
            this.cellID = cellID;
        }

        public void UpdateCell(ConsumerViewTableItemModel data)
        {
            CALayer profileImageCircle = ProfileImage.Layer;
            profileImageCircle.CornerRadius = 34;
            profileImageCircle.MasksToBounds = true;

            ProfileImage.Image = UIImage.FromFile(data.Image);
            lblInformation.Text = data.Review;
            lblDuration.Text = data.Duration;
        }
    }
}