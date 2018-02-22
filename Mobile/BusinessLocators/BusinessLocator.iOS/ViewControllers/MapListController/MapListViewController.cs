using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using BusinessLocator.iOS.Model;
using CoreAnimation;
using CoreGraphics;
using BusinessLocator.Shared.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Mobile.Extensions.iOS.Extensions;
using BusinessLocator.Shared.Models;

namespace BusinessLocator.iOS
{
    public partial class MapListViewController : BaseViewController
    {
        
        public MapListViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            string role = "";
            string searchText = "";
            LoadingScreen.Show();

            var apiCall = new ServiceApi().GetUserLocation(21.17024, 72.831062, searchText, role);

            apiCall.HandleError(null,true);
            apiCall.OnSucess(response =>
            {
                LoadingScreen.Hide();

                List<UserProfileModel> data = new List<UserProfileModel>();

                for (var i = 0; i < response.Result.RecordList.Count;i++)
                {
                    
                    var result = response.Result.RecordList[i];
                    data.Add(new UserProfileModel
                    {
                        DisplayName = result.DisplayName,
                        PhoneNumber = result.PhoneNumber,
                        Image = result.Image,
                        Address1 = result.Address1
                    });
                }

                //foreach(var item in response.Result.RecordList)
                //{
                //    data.Add(new UserProfileModel
                //    {
                //        DisplayName = item.DisplayName,
                //        PhoneNumber = item.PhoneNumber,
                //        Image = item.Image,
                //        Address1 = item.Address1
                //    });
                //}

                UsersTableView.Source = new UsersTableViewSource(data);
                UsersTableView.RowHeight = UITableView.AutomaticDimension;
                UsersTableView.SeparatorColor = UIColor.Clear;
                UsersTableView.EstimatedRowHeight = 50f;
                UsersTableView.ReloadData();
            });
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }


    }
}