using System;
using Mobile.Extensions.iOS.ViewControllers;
using Mobile.Extensions.iOS.Extensions;

namespace BusinessLocator.iOS
{
    public partial class BaseViewController : ExtensionsBaseViewController
    {
        public LoadingScreenViewController LoadingScreen;

        public BaseViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            LoadingScreen = Storyboard.InstantiateViewController<LoadingScreenViewController>();
            LoadingScreen.Parent = this;
        }

        public override void LoadView()
        {
            base.LoadView();

            LoadingScreen = Storyboard.InstantiateViewController<LoadingScreenViewController>();
            LoadingScreen.Parent = this;
        }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}
