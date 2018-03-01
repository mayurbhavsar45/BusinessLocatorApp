using Foundation;
using System;
using UIKit;
using CoreAnimation;
using CoreGraphics;
using Plugin.Settings;
using BusinessLocator.Shared.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Mobile.Extensions.iOS.Extensions;
using BusinessLocator.Shared.Models;

namespace BusinessLocator.iOS
{
    public partial class UserProfileViewController : BaseViewController
    {
        UIImagePickerController imagePicker;

        public UserProfileViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var gradientLayer = new CAGradientLayer();
            gradientLayer.Colors = new[] { UIColor.FromRGB(98,107,186).CGColor, UIColor.FromRGB(57,122,193).CGColor };
            gradientLayer.Frame = new CGRect(0, 0, ProfileHeaderView.Frame.Width + 50, ProfileHeaderView.Frame.Height);
            ProfileHeaderView.Layer.InsertSublayer(gradientLayer, 0);

            btnBack.Hidden = true;

            //UIImageView view = new UIImageView()
            //{
            //    Frame = new CGRect(0, 250, ProfileWall.Frame.Width, ProfileWall.Frame.Height),
            //    //BackgroundColor=UIColor.Blue,
            //    Image = UIImage.FromFile("user1.jpg")
            //};
            //View.Add(view);

            UIImageView imageView = new UIImageView();
            imageView.Frame = new CGRect(0, 0, ProfileWall.Frame.Width + 50, ProfileWall.Frame.Height + 75);
            imageView.Image = UIImage.FromFile("Polygon_one");
            imageView.ContentMode = UIViewContentMode.ScaleToFill;
            ProfileWall.MaskView = imageView;

            ProfileImage.Layer.CornerRadius = ProfileImage.Frame.Width / 2;
            ProfileImage.Layer.MasksToBounds = true;
            ProfileImage.Layer.BorderColor = UIColor.White.CGColor;
            ProfileImage.Layer.BorderWidth = 2;

            //Set from CrossSettings classs / Session Variable
            //lblName.Text = CrossSettings.Current.GetValueOrDefault("UserName", "");

            btnFilter.TouchUpInside += (sender, e) =>
            {
                SettingsViewController settingsController = this.Storyboard.InstantiateViewController("SettingsViewController") as SettingsViewController;
                if (settingsController != null)
                {
                    this.NavigationController.PushViewController(settingsController, true);
                }
            };

            btnChangePassword.TouchUpInside += (sender, e) =>
            {
                //new UIAlertView("Click", "Clicked", null, "Ok", null).Show();
                ChangePasswordViewController changePasswordController = this.Storyboard.InstantiateViewController("ChangePasswordViewController") as ChangePasswordViewController;
                if (changePasswordController != null)
                {
                    this.NavigationController.PushViewController(changePasswordController, true);
                }
            };

            btnEditProfileImage.TouchUpInside+=(sender, e) => 
            {
                try
                {
                    imagePicker = new UIImagePickerController();
                    imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
                    imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);
                    imagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
                    imagePicker.Canceled += Handle_Canceled;
                    NavigationController.PresentModalViewController(imagePicker, true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            };

            //Make Call to API
            GetProfileData();
        }

        public void GetProfileData()
        {
            var apiResponse = new ServiceApi().GetUserProfile();
            apiResponse.HandleError(null, true);
            apiResponse.OnSucess(response =>
            {
                LoadingScreen.Hide();
                var result = response.Result;
                lblName.Text = result.DisplayName;
                lblMobileNumber.Text = result.PhoneNumber;
                addressLabel.Text = "B/5/128, Willson Tower, LA";
                lblEmail.Text = result.eMailAddress;
            });
        }

        protected void Handle_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
        {
            // determine what was selected, video or image
            bool isImage = false;
            switch (e.Info[UIImagePickerController.MediaType].ToString())
            {
                case "public.image":
                    Console.WriteLine("Image selected");
                    isImage = true;
                    break;
                case "public.video":
                    Console.WriteLine("Video selected");
                    break;
            }

            // get common info (shared between images and video)
            NSUrl referenceURL = e.Info[new NSString("UIImagePickerControllerReferenceURL")] as NSUrl;
            if (referenceURL != null)
                Console.WriteLine("Url:" + referenceURL.ToString());

            // if it was an image, get the other image info
            if (isImage)
            {
                // get the original image
                UIImage originalImage = e.Info[UIImagePickerController.OriginalImage] as UIImage;
                if (originalImage != null)
                {
                    // do something with the image
                    Console.WriteLine("got the original image");
                    ProfileImage.Image = originalImage; // display
                    ProfileWall.Image = originalImage;
                }
            }
            else
            { 
                // if it's a video
                // get video url
                NSUrl mediaURL = e.Info[UIImagePickerController.MediaURL] as NSUrl;
                if (mediaURL != null)
                {
                    Console.WriteLine(mediaURL.ToString());
                }
            }
            // dismiss the picker
            imagePicker.DismissModalViewController(true);
        }

        void Handle_Canceled(object sender, EventArgs e)
        {
            imagePicker.DismissModalViewController(true);
        }
    }
}