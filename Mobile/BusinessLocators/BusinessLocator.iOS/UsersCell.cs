using Foundation;
using System;
using UIKit;
using BusinessLocator.iOS.Model;
using CoreAnimation;

namespace BusinessLocator.iOS
{
    public partial class UsersCell : UITableViewCell
    {
        private NSString cellID;

        public UsersCell(IntPtr handle) : base (handle)
        {
        }

        public UsersCell(NSString cellID) : base(UITableViewCellStyle.Default, cellID)
        {
            this.cellID = cellID;
        }

        public void UpdateCell(LocationsListViewItemModel data)
        {
            ProfileImage.Image = UIImage.FromFile(data.Image);
            lblName.Text = data.Name;
            lblMobileNumber.Text = data.MobileNumber;
            lblAddress.Text = data.Location;
        }

        public override void LayoutSubviews()
        {
            CALayer profileImageCircle = ProfileImage.Layer;
            profileImageCircle.CornerRadius = 35;
            profileImageCircle.MasksToBounds = true;

        }
    }
}