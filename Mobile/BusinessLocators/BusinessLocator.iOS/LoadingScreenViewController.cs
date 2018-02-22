using Foundation;
using System;
using UIKit;
using Mobile.Extensions.iOS.Interfaces; 

namespace BusinessLocator.iOS
{
    public partial class LoadingScreenViewController : UIViewController, ILoadingScreen
    {
        public UIViewController Parent;
        public LoadingScreenViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var b = UIScreen.MainScreen.Bounds;
            View.Frame = b;
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            var b = UIScreen.MainScreen.Bounds;
            View.Frame = b;

        }

        public void Show()
        {
            Parent.View.AddSubview(this.View);

            Parent.View.BringSubviewToFront(this.View);
            this.View.Layer.Opacity = 0;
            LoaderImageView.Alpha = 1;
            UIView.Animate(0.7, 0, UIViewAnimationOptions.Repeat | UIViewAnimationOptions.Autoreverse, () =>
            {
                LoaderImageView.Alpha = 0;
            }, () => { });

            UIView.Animate(0.15, 0, UIViewAnimationOptions.CurveEaseInOut, () =>
            {
                this.View.Layer.Opacity = 1;
            }, () => { });
        }

        public void Hide()
        {
            View.Layer.RemoveAllAnimations();
            UIView.Animate(0.15, 0, UIViewAnimationOptions.CurveEaseInOut, () =>
            {
                this.View.Layer.Opacity = 0;
            }, () => { });
        }

       

    }
}