// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BusinessLocator.iOS
{
    [Register ("LocationViewController")]
    partial class LocationViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView headerViewContainer { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (headerViewContainer != null) {
                headerViewContainer.Dispose ();
                headerViewContainer = null;
            }
        }
    }
}