using Foundation;
using System;
using UIKit;
using CoreAnimation;
using CoreGraphics;
using System.Collections.Generic;

namespace BusinessLocator.iOS
{
    public partial class ReportProviderViewController : UIViewController
    {
        public ReportProviderViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.Clear;

            var gradientLayer = new CAGradientLayer();
            gradientLayer.Colors = new[] { UIColor.FromRGB(98, 107, 186).CGColor, UIColor.FromRGB(57, 122, 193).CGColor };
            gradientLayer.Frame = new CGRect(0, 0, DialogHeaderView.Frame.Width + 40, DialogHeaderView.Bounds.Height);
            DialogHeaderView.Layer.InsertSublayer(gradientLayer, 0);

            //UIPickerView Values

            var list = new List<string>
            {
                "What is Loreun Isapum?", "Provider", "Consumer"
            };

            PickerView.Layer.BorderWidth = 2;
            PickerView.Layer.CornerRadius = 5;
            PickerView.Layer.BorderColor = UIColor.White.CGColor;

            ReportProviderPicker.Model = new UserTypeViewModel(list);
            ReportProviderPicker.ShowSelectionIndicator = true;


            //Pickerview Custom Appearance
            var layer = new CALayer();
            layer.Frame = new CGRect(10, 8, ReportProviderPicker.Frame.Width-5, ReportProviderPicker.Frame.Height-5);
            layer.CornerRadius = 10;
            layer.BackgroundColor = UIColor.White.CGColor;
            ReportProviderPicker.Layer.Mask = layer;

            //reportTextArea.Layer.BorderWidth = 1;
            //reportTextArea.Layer.BorderColor = UIColor.Black.CGColor;

            //Placeholder for TextArea
            string Placeholder = "Type here";
            reportTextArea.Text = Placeholder;

            reportTextArea.ShouldBeginEditing = _ =>
            {
                if (reportTextArea.Text == Placeholder)
                {
                    reportTextArea.Text = string.Empty;
                }
                return true;
            };

            reportTextArea.ShouldEndEditing = _ => 
            {
                if(string.IsNullOrEmpty(reportTextArea.Text))
                {
                    reportTextArea.Text = Placeholder;
                }
                reportTextArea.ResignFirstResponder();
                return true;
            };

            btnClose.TouchUpInside+=(sender, e) =>  
            {
                DismissViewController(true, null);
            };

        }
    }
}