using Foundation;
using System;
using UIKit;
using CoreAnimation;
using CoreGraphics;

namespace BusinessLocator.iOS
{
    public partial class MessageViewController : UIViewController
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
       
        public MessageViewController (IntPtr handle) : base (handle)
        {
        }

        public MessageViewController(){}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var gradientLayer = new CAGradientLayer();
            gradientLayer.Colors = new[] { UIColor.FromRGB(98, 107, 186).CGColor, UIColor.FromRGB(57, 122, 193).CGColor };
            gradientLayer.Locations = new NSNumber[] { 0, 1 };
            gradientLayer.Frame = new CGRect(0, 0, HeaderView.Frame.Width + 50, HeaderView.Frame.Height);
            HeaderView.Layer.InsertSublayer(gradientLayer, 0);

            //var buttonGradientLayer = new CAGradientLayer();
            //buttonGradientLayer.Colors = new[] { UIColor.FromRGB(98, 107, 186).CGColor, UIColor.FromRGB(57, 122, 193).CGColor };
            //buttonGradientLayer.Frame = btnSendMessage.Layer.Bounds;
            //buttonGradientLayer.CornerRadius = btnSendMessage.Layer.CornerRadius;
            //buttonGradientLayer.Locations = new NSNumber[] { 0, 1 };
            //btnSendMessage.Layer.AddSublayer(buttonGradientLayer);

            btnSendMessage.BackgroundColor = UIColor.FromRGB(98, 107, 186);

            CALayer profileImageCircle = ProfilePicture.Layer;
            profileImageCircle.CornerRadius = 25;
            profileImageCircle.BorderColor = UIColor.White.CGColor;
            profileImageCircle.BorderWidth = 1.5f;
            profileImageCircle.MasksToBounds = true;

            //Circular Revel View
            //RevelView.Layer.BorderColor = UIColor.LightGray.CGColor;
            //RevelView.Layer.BorderWidth = 1;
            RevelView.Layer.CornerRadius = 5;

            var count = 1;
            btnAttachement.TouchUpInside+=(sender, e) => 
            {
                if(count==1)
                {
                    //SlideHorizontaly(RevelView, true, true, 2, null);
                    //SlideVerticaly(RevelView, true, true, 1, null);
                    //FadeAnimation(RevelView, true, 1, null);
                    Zoom(RevelView, true, 0.7, null);
                    //Rotate(RevelView, true, true, 1, null);
                    //FlipVerticaly(RevelView, true, 0.8, null);

                    RevelView.Hidden = false;
                    count++;
                }
                else
                {
                     //SlideHorizontaly(RevelView, false, true, 1, null);
                    //SlideVerticaly(RevelView, false, true, 1, null);
                    //FadeAnimation(RevelView, false, 1, null);
                     Zoom(RevelView, false, 0.8, null);
                     //Scale(RevelView, false, 1, null);
                    //Rotate(RevelView, false, true, 1, null);
                    //FlipVerticaly(RevelView, false, 0.7, null);

                    count = 1;
                }
            };


            lblName.Text = Name;
            ProfilePicture.Image = UIImage.FromFile(Image);

            if(Status == true)
            {
                lblStatus.Text = "Online";    
            }
            else
            {
                lblStatus.RemoveFromSuperview();
            }

            textSender.AttributedPlaceholder = new NSAttributedString("type message here...", null, UIColor.FromRGB(98, 107, 186));

            btnBack.TouchUpInside += (sender, e) => 
            {
                this.NavigationController.PopViewController(true);
            };
           
        }

        public static void FadeAnimation(UIView view, bool isIn, double duration = 0.3, Action onFinished = null)
        {  
            var minAlpha = (nfloat) 0.0f;  
            var maxAlpha = (nfloat) 1.0f;  
            view.Alpha = isIn ? minAlpha : maxAlpha;  
            view.Transform = CGAffineTransform.MakeIdentity();  
            UIView.Animate(duration, 0, UIViewAnimationOptions.TransitionCrossDissolve, () => 
            {  
                view.Alpha = isIn ? maxAlpha : minAlpha;  
            }, onFinished);  
          
        }  

        public static void SlideHorizontaly(UIView view, bool isIn, bool fromLeft, double duration = 0.3, Action onFinished = null)
        {
            var minAlpha = (nfloat)0.0f;
            var maxAlpha = (nfloat)1.0f;
            var minTransform = CGAffineTransform.MakeTranslation((fromLeft ? -1 : 1) * view.Bounds.Width, 0);
            var maxTransform = CGAffineTransform.MakeIdentity();

            view.Alpha = isIn ? minAlpha : maxAlpha;
            view.Transform = isIn ? minTransform : maxTransform;
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () => {
                    view.Alpha = isIn ? maxAlpha : minAlpha;
                    view.Transform = isIn ? maxTransform : minTransform;
                },
                onFinished
            );
        }

        public static void Zoom(UIView view, bool isIn, double duration = 0.3, Action onFinished = null)
        {
            var minAlpha = (nfloat)0.0f;
            var maxAlpha = (nfloat)1.0f;
            var minTransform = CGAffineTransform.MakeScale((nfloat)2.0, (nfloat)2.0);
            var maxTransform = CGAffineTransform.MakeScale((nfloat)1, (nfloat)1);

            view.Alpha = isIn ? minAlpha : maxAlpha;
            view.Transform = isIn ? minTransform : maxTransform;
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () => {
                    view.Alpha = isIn ? maxAlpha : minAlpha;
                    view.Transform = isIn ? maxTransform : minTransform;
                },
                onFinished
            );
        }

        public static void Scale(UIView view, bool isIn, double duration = 0.3, Action onFinished = null)
        {
            var minAlpha = (nfloat)0.0f;
            var maxAlpha = (nfloat)1.0f;
            var minTransform = CGAffineTransform.MakeScale((nfloat)0.1, (nfloat)0.1);
            var maxTransform = CGAffineTransform.MakeScale((nfloat)1, (nfloat)1);

            view.Alpha = isIn ? minAlpha : maxAlpha;
            view.Transform = isIn ? minTransform : maxTransform;
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () => {
                    view.Alpha = isIn ? maxAlpha : minAlpha;
                    view.Transform = isIn ? maxTransform : minTransform;
                },
                onFinished
            );
        }

        public static void SlideVerticaly(UIView view, bool isIn, bool fromTop, double duration = 0.3, Action onFinished = null)
        {
            var minAlpha = (nfloat)0.0f;
            var maxAlpha = (nfloat)1.0f;
            var minTransform = CGAffineTransform.MakeTranslation(0, (fromTop ? -1 : 1) * view.Bounds.Height);
            var maxTransform = CGAffineTransform.MakeIdentity();

            view.Alpha = isIn ? minAlpha : maxAlpha;
            view.Transform = isIn ? minTransform : maxTransform;
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () => {
                    view.Alpha = isIn ? maxAlpha : minAlpha;
                    view.Transform = isIn ? maxTransform : minTransform;
                },
                onFinished
            );
        }

        public static void Rotate(UIView view, bool isIn, bool fromLeft = true, double duration = 0.3, Action onFinished = null)
        {
            var minAlpha = (nfloat)0.0f;
            var maxAlpha = (nfloat)1.0f;
            var minTransform = CGAffineTransform.MakeRotation((nfloat)((fromLeft ? -1 : 1) * 720));
            var maxTransform = CGAffineTransform.MakeRotation((nfloat)0.0);

            view.Alpha = isIn ? minAlpha : maxAlpha;
            view.Transform = isIn ? minTransform : maxTransform;
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () => {
                    view.Alpha = isIn ? maxAlpha : minAlpha;
                    view.Transform = isIn ? maxTransform : minTransform;
                },
                onFinished
            );
        }

        public static void FlipVerticaly(UIView view, bool isIn, double duration = 0.3, Action onFinished = null)
        {
            var m34 = (nfloat)(-1 * 0.001);

            var minAlpha = (nfloat)0.0f;
            var maxAlpha = (nfloat)1.0f;

            var minTransform = CATransform3D.Identity;
            minTransform.m34 = m34;
            minTransform = minTransform.Rotate((nfloat)((isIn ? 1 : -1) * Math.PI * 0.5), (nfloat)1.0f, (nfloat)0.0f, (nfloat)0.0f);
            var maxTransform = CATransform3D.Identity;
            maxTransform.m34 = m34;

            view.Alpha = isIn ? minAlpha : maxAlpha;
            view.Layer.Transform = isIn ? minTransform : maxTransform;
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () => {
                    view.Layer.AnchorPoint = new CGPoint((nfloat)0.5, (nfloat)0.5f);
                    view.Layer.Transform = isIn ? maxTransform : minTransform;
                    view.Alpha = isIn ? maxAlpha : minAlpha;
                },
                onFinished
            );
        }
    }
}