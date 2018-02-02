using Foundation;
using System;
using UIKit;
using BusinessLocator.iOS.Model;
using CoreAnimation;

namespace BusinessLocator.iOS
{
    public partial class ChatViewCell : UITableViewCell
    {
        private NSString cellID;

        public ChatViewCell (IntPtr handle) : base (handle)
        {
        }

        public ChatViewCell(NSString cellID)
        {
            this.cellID = cellID;
        }

        public void UpdateCell(ChatViewTableItemModel data)
        {
            ChatProfileImage.Image = UIImage.FromFile(data.Image);
            lblName.Text = data.Name;
            lblDescription.Text = data.Description;
            lblDuration.Text = data.Duration;
            btnCount.SetTitle(data.MesaageCount, UIControlState.Normal);
        }

        public override void LayoutSubviews()
        {
            CALayer profileImageCircle = ChatProfileImage.Layer;
            profileImageCircle.CornerRadius = 34;
            profileImageCircle.BorderColor = UIColor.FromRGB(98, 107, 186).CGColor;
            profileImageCircle.BorderWidth = 3;
            profileImageCircle.MasksToBounds = true;

        }
    }
}