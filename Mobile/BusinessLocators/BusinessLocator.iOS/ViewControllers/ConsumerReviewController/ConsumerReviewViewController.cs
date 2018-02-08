using Foundation;
using System;
using UIKit;
using CoreAnimation;
using CoreGraphics;
using System.Collections.Generic;
using BusinessLocator.iOS.Model;

namespace BusinessLocator.iOS
{
    public partial class ConsumerReviewViewController : UIViewController
    {
        public ConsumerReviewViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var gradientLayer = new CAGradientLayer();
            gradientLayer.Colors = new[] { UIColor.FromRGB(98, 107, 186).CGColor, UIColor.FromRGB(57, 122, 193).CGColor };
            gradientLayer.Frame = new CGRect(0, 0, HeaderView.Frame.Width + 50, HeaderView.Frame.Height);
            HeaderView.Layer.InsertSublayer(gradientLayer, 0);

            var data = new List<ConsumerViewTableItemModel> 
            {
                new ConsumerViewTableItemModel
                {
                    Image = "user1.jpg",
                    Review = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                    Duration = "24/01/2017"
                },
                new ConsumerViewTableItemModel
                {
                    Image = "user2.jpg",
                    Review = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                    Duration = "05/06/2017"
                },
                new ConsumerViewTableItemModel
                {
                    Image = "user3.png",
                    Review = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                    Duration = "Yesterday"
                },
                new ConsumerViewTableItemModel
                {
                    Image = "user4.jpg",
                    Review = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                    Duration = "22/10/2017"
                },
            };

            ConsumerTableView.Source = new ConsumerTableSource(this, data);

            ConsumerTableView.RowHeight = UITableView.AutomaticDimension;
            ConsumerTableView.EstimatedRowHeight = 40f;
            ConsumerTableView.SeparatorColor = UIColor.Clear;
            ConsumerTableView.ReloadData();

            btnBack.TouchUpInside += (sender, e) => 
            {
                this.NavigationController.PopViewController(true);
            };
        }
    }
}