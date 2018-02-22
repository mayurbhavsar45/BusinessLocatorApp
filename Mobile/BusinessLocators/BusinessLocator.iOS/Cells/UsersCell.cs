using Foundation;
using System;
using UIKit;
using BusinessLocator.iOS.Model;
using CoreAnimation;
using BusinessLocator.Shared.Models;
using System.IO;

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

        public void UpdateCell(UserProfileModel data)
        {
            ProfileImage.Image = UIImage.FromFile(data.Image);
            //ProfileImage.Image = UIImage.FromFile("user1.jpg");
            lblName.Text = data.DisplayName;
            lblMobileNumber.Text = data.PhoneNumber;
            lblAddress.Text = data.Address1;
        }

        public override void LayoutSubviews()
        {
            CALayer profileImageCircle = ProfileImage.Layer;
            profileImageCircle.CornerRadius = 35;
            profileImageCircle.MasksToBounds = true;
            //profileImageCircle.BorderColor = UIColor.FromRGB(98, 107, 186).CGColor;
            //profileImageCircle.BorderWidth = 3;
        }
    }
}