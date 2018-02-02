using Foundation;
using System;
using UIKit;
using CoreAnimation;
using CoreGraphics;
using System.Collections.Generic;
using BusinessLocator.iOS.Model;

namespace BusinessLocator.iOS
{
    public partial class NotificationViewController : UIViewController
    {
        public NotificationViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var gradientLayer = new CAGradientLayer();
            gradientLayer.Colors = new[] { UIColor.FromRGB(98, 107, 186).CGColor, UIColor.FromRGB(57, 122, 193).CGColor };
            gradientLayer.Locations = new NSNumber[] { 0, 1 };
            gradientLayer.Frame = new CGRect(0, 0, HeaderView.Frame.Width + 50, HeaderView.Frame.Height);
            HeaderView.Layer.InsertSublayer(gradientLayer, 0);

            var data = new List<NotificationTableItemModel>
            {
                new NotificationTableItemModel
                {
                    Image = "user1.jpg",
                    Name = "George",
                    Duration = "2:00 PM",
                    Description = "What is your name?",
                    MesaageCount = "2"
                },

                new NotificationTableItemModel
                {
                    Image = "user2.jpg",
                    Name = "Hank",
                    Duration = "1:00 AM",
                    Description = "What is your name?",
                    MesaageCount = "3"
                },

                new NotificationTableItemModel
                {
                    Image = "user3.png",
                    Name = "Harry",
                    Duration = "2:30 AM",
                    Description = "What is your name?",
                    MesaageCount = "7"
                },

                new NotificationTableItemModel
                {
                    Image = "user4.jpg",
                    Name = "Henry",
                    Duration = "2:00 PM",
                    Description = "What is your name?",
                    MesaageCount = "4"
                },

                new NotificationTableItemModel
                {
                    Image = "user1.jpg",
                    Name = "Benjamin",
                    Duration = "12:00 AM",
                    Description = "What is your name?",
                    MesaageCount = "2"
                },

                new NotificationTableItemModel
                {
                    Image = "user2.jpg",
                    Name = "Obama",
                    Duration = "2:00 PM",
                    Description = "What is your name?",
                    MesaageCount = "1"
                }

            };

            NotificationsTableView.Source = new NotificationsViewTableSource(data);

            NotificationsTableView.RowHeight = UITableView.AutomaticDimension;
            NotificationsTableView.EstimatedRowHeight = 40f;
            NotificationsTableView.SeparatorColor = UIColor.Clear;
            NotificationsTableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            NotificationsTableView.ReloadData();

        }
    }
}