using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using BusinessLocator.iOS.Model;
using CoreAnimation;

namespace BusinessLocator.iOS
{
    public partial class MapListViewController : UIViewController
    {
        public MapListViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var listItems = new List<LocationsListViewItemModel> 
            {
                new LocationsListViewItemModel
                {
                    Image = "user1.jpg",
                    Name = "Bruce Willis",
                    Location = "303-304, Airen Heights",
                    MobileNumber = "9362-265-214"
                },

                new LocationsListViewItemModel
                {
                    Image = "user2.jpg",
                    Name = "Jim Carry",
                    Location = "303-304, Airen Heights",
                    MobileNumber = "9362-265-214"
                },

                new LocationsListViewItemModel
                {
                    Image = "user3.png",
                    Name = "Dwayn Smith",
                    Location = "303-304, Airen Heights",
                    MobileNumber = "9362-265-214"
                }

            };

            UsersTableView.Source = new UsersTableViewSource(listItems);

            UsersTableView.RowHeight = 120f; //UITableView.AutomaticDimension;
            UsersTableView.EstimatedRowHeight = 150f;
            UsersTableView.ReloadData();

        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }


    }
}