using Foundation;
using System;
using UIKit;
using CoreAnimation;
using CoreGraphics;
using System.Collections.Generic;
using BusinessLocator.iOS.Model;

namespace BusinessLocator.iOS
{
    public partial class ChatViewController : UIViewController
    {
        public ChatViewController (IntPtr handle) : base (handle)
        {
        }

        public ChatViewController(){}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var gradientLayer = new CAGradientLayer();
            gradientLayer.Colors = new[] { UIColor.FromRGB(98, 107, 186).CGColor, UIColor.FromRGB(57, 122, 193).CGColor };
            gradientLayer.Locations = new NSNumber[] { 0, 1 };
            gradientLayer.Frame = new CGRect(0, 0, headerView.Frame.Width + 50, headerView.Frame.Height);
            headerView.Layer.InsertSublayer(gradientLayer, 0);

            var data = new List<ChatViewTableItemModel>
            {
                new ChatViewTableItemModel
                {
                    Image = "user1.jpg",
                    Name = "George",
                    Duration = "2:00 PM",
                    Description = "What is your name?",
                    MesaageCount = "2",
                    Status = true
                },

                new ChatViewTableItemModel
                {
                    Image = "user2.jpg",
                    Name = "Mr.Bin",
                    Duration = "1:00 AM",
                    Description = "What is your name?",
                    MesaageCount = "3",
                    Status = true
                },

                new ChatViewTableItemModel
                {
                    Image = "user3.png",
                    Name = "Harry",
                    Duration = "2:30 AM",
                    Description = "What is your name?",
                    MesaageCount = "7",
                    Status = false
                },

                new ChatViewTableItemModel
                {
                    Image = "user4.jpg",
                    Name = "Henry",
                    Duration = "2:00 PM",
                    Description = "What is your name?",
                    MesaageCount = "4",
                    Status = false
                },

                new ChatViewTableItemModel
                {
                    Image = "user1.jpg",
                    Name = "Benjamin",
                    Duration = "12:00 AM",
                    Description = "What is your name?",
                    MesaageCount = "2"
                },

                new ChatViewTableItemModel
                {
                    Image = "user2.jpg",
                    Name = "Obama",
                    Duration = "2:00 PM",
                    Description = "What is your name?",
                    MesaageCount = "1",
                    Status = false
                }

            };

            //ChatViewTable.Source = new ChatViewTableSource(data);
            ChatViewTable.Source = new ChatViewTableSource(this, data);

            ChatViewTable.RowHeight = UITableView.AutomaticDimension;
            ChatViewTable.EstimatedRowHeight = 40f;
            ChatViewTable.SeparatorColor = UIColor.Clear;
            ChatViewTable.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            ChatViewTable.ReloadData();

        }

    }
}