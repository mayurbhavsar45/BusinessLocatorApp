using Foundation;
using System;
using UIKit;
using CoreGraphics;
using CoreAnimation;
using BusinessLocator.Shared.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BusinessLocator.iOS
{
    public partial class LoginViewController : UIViewController
    {
        UILabel lblBusinessLocator, lblBusinessRequirement, lblWelcome, lblInformation;
        UITextField txtUserName, txtPassword;
        UIButton btnLogin, btnForgotPassword, btnSignUp;
        UIView borderUserName, borderPassword;

        public LoginViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            CGColor[] colors = new CGColor[] { UIColor.FromRGB(98,107,186).CGColor,
                UIColor.FromRGB(57,122,193).CGColor};
            CAGradientLayer gradientLayer = new CAGradientLayer();
            gradientLayer.Frame = this.View.Bounds;
            gradientLayer.Colors = colors;
            this.View.Layer.InsertSublayer(gradientLayer, 0);

            lblBusinessLocator = new UILabel()
            {
                Frame = new CGRect(20, 80, UIScreen.MainScreen.Bounds.Width - 40, 20),
                Text = "BUSINESS LOCATOR",
                TextColor = UIColor.White,
                Font = UIFont.BoldSystemFontOfSize(28),
                TextAlignment = UITextAlignment.Center
            };
            View.Add(lblBusinessLocator);

            lblBusinessRequirement = new UILabel()
            {
                Frame = new CGRect(20, lblBusinessLocator.Frame.Top + lblBusinessLocator.Frame.Height + 10, UIScreen.MainScreen.Bounds.Width - 40, 20),
                Text = "Business Requirements",
                TextColor = UIColor.White,
                TextAlignment = UITextAlignment.Center
            };
            View.Add(lblBusinessRequirement);

            lblWelcome = new UILabel()
            {
                Frame = new CGRect(20, lblBusinessRequirement.Frame.Top + lblBusinessLocator.Frame.Height + 60, UIScreen.MainScreen.Bounds.Width - 40, 20),
                Text = "Welcome",
                TextColor = UIColor.White,
                Font = UIFont.BoldSystemFontOfSize(28),
                TextAlignment = UITextAlignment.Center
            };
            View.Add(lblWelcome);

            lblInformation = new UILabel()
            {
                Frame = new CGRect(20, lblWelcome.Frame.Top + lblWelcome.Frame.Height + 15, UIScreen.MainScreen.Bounds.Width - 40, 50),
                Text = "You just need, it seems, to add a sublayer with the gradient to the button's Layer object",
                TextColor = UIColor.White,
                Font = UIFont.FromName("Helvetica", 15f),
                TextAlignment = UITextAlignment.Center,
                LineBreakMode = UILineBreakMode.WordWrap,
                Lines = 0
            };
            View.Add(lblInformation);

            borderUserName = new UIView
            {
                Frame = new CGRect(20, lblInformation.Frame.Top + lblInformation.Frame.Height + 50, UIScreen.MainScreen.Bounds.Width - 40, 55)
            };
            borderUserName.Layer.BorderWidth = 2;
            borderUserName.Layer.BorderColor = UIColor.White.CGColor;
            borderUserName.Layer.CornerRadius = 25;
            View.AddSubview(borderUserName);

            txtUserName = new UITextField()
            {
                Frame = new CGRect(15, 8, borderUserName.Bounds.Width - 20, 40),
                AttributedPlaceholder = new NSAttributedString("User name", null, UIColor.White),
                TextAlignment = UITextAlignment.Left,
                TextColor = UIColor.White,
            };
            txtUserName.TintColor = UIColor.Black;
            txtUserName.ClearButtonMode = UITextFieldViewMode.WhileEditing;
            txtUserName.AutocapitalizationType = UITextAutocapitalizationType.None;
            borderUserName.Add(txtUserName);

            borderPassword = new UIView()
            {
                Frame = new CGRect(20, borderUserName.Frame.Top + borderUserName.Frame.Height + 15, UIScreen.MainScreen.Bounds.Width - 40, 55),
            };
            borderPassword.Layer.BorderWidth = 2;
            borderPassword.Layer.BorderColor = UIColor.White.CGColor;
            borderPassword.Layer.CornerRadius = 25;
            View.AddSubview(borderPassword);

            txtPassword = new UITextField()
            {
                Frame = new CGRect(15, 8, borderPassword.Bounds.Width - 20, 40),
                AttributedPlaceholder = new NSAttributedString("Password", null, UIColor.White),
                TextAlignment = UITextAlignment.Left,
                TextColor = UIColor.White,
                SecureTextEntry = true
            };
            txtPassword.TintColor = UIColor.Black;
            txtPassword.ClearButtonMode = UITextFieldViewMode.WhileEditing;
            borderPassword.Add(txtPassword);

            btnForgotPassword = new UIButton()
            {
                Frame = new CGRect(20, borderPassword.Frame.Top + borderPassword.Frame.Height + 15, UIScreen.MainScreen.Bounds.Width - 40, 40),
            };
            btnForgotPassword.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
            btnForgotPassword.SetTitle("Forgot Password ?", UIControlState.Normal);
            btnForgotPassword.SetTitleColor(UIColor.White, UIControlState.Normal);
            View.Add(btnForgotPassword);

            btnLogin = new UIButton()
            {
                Frame = new CGRect(20, btnForgotPassword.Frame.Top + btnForgotPassword.Frame.Height + 15, UIScreen.MainScreen.Bounds.Width - 40, 50),
                BackgroundColor = UIColor.White,
                Font = UIFont.FromName("Helvetica", 22)
            };
            btnLogin.SetTitle("Login", UIControlState.Normal);
            btnLogin.SetTitleColor(UIColor.FromRGB(53, 110, 184), UIControlState.Normal);
            btnLogin.Layer.CornerRadius = 20;
            View.Add(btnLogin);

            btnSignUp = new UIButton()
            {
                Frame = new CGRect(20, btnLogin.Frame.Top + btnLogin.Frame.Height + 40, UIScreen.MainScreen.Bounds.Width - 40, 40)
            };
            btnSignUp.SetTitle("Don't have an account yet ? Sign Up", UIControlState.Normal);
            btnSignUp.SetTitleColor(UIColor.White, UIControlState.Normal);
            View.Add(btnSignUp);


            //Buttons Click Evetns
            btnForgotPassword.TouchUpInside += (sender, e) => 
            {
                ForgotPasswordViewController forgotPasswordViewController = this.Storyboard.InstantiateViewController("ForgotPasswordViewController") as ForgotPasswordViewController;
                if(forgotPasswordViewController != null)
                {
                    this.NavigationController.PushViewController(forgotPasswordViewController, true);    
                }
            };
    
            btnSignUp.TouchUpInside += (sender, e) => 
            {
                SignUpViewController signUpViewController = this.Storyboard.InstantiateViewController("SignUpViewController") as SignUpViewController;
                if(signUpViewController!=null)
                {
                    this.NavigationController.PushViewController(signUpViewController, true);
                }
            };

            btnLogin.TouchUpInside += (sender, e) => 
            {
                var apiResponse = new ServiceApi().Login(txtUserName.Text, txtPassword.Text);

                try
                {
                    if(apiResponse.IsSuccessStatusCode)
                    {
                        var data = apiResponse.Content.ReadAsStringAsync();
                        var response = JsonConvert.DeserializeObject<JObject>(data.Result);

                        MainViewController mainViewController = this.Storyboard.InstantiateViewController("MainViewController") as MainViewController;
                        if (mainViewController != null)
                        {
                            this.NavigationController.PushViewController(mainViewController, true);
                        }    
                    }
                    else
                    {
                        var data = apiResponse.Content.ReadAsStringAsync();
                        var response = JsonConvert.DeserializeObject<JObject>(data.Result);

                        var error = response["error_description"].ToString();

                        var errorAlertController = UIAlertController.Create("Error", error, UIAlertControllerStyle.Alert);
                        errorAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Destructive, null));
                        PresentViewController(errorAlertController, true, null);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            };

        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            this.NavigationController.NavigationBarHidden = true;
            this.NavigationController.NavigationBar.Translucent = false;
        }
    }
}