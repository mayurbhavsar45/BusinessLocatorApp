using System;
using System.Collections.Generic;
using System.Drawing;
using UIKit;
using CoreGraphics;
namespace BusinessLocator.iOS
{
    internal class UserTypeViewModel : UIPickerViewModel
    {
        private List<string> _usersList;

        public UserTypeViewModel(List<string> userslist)
        {
            this._usersList = userslist;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return _usersList.Count;
        }

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            return _usersList[(int)row];
        }

        public override UIView GetView(UIPickerView pickerView, nint row, nint component, UIView view)
        {
            //UILabel lbl = new UILabel(new RectangleF(0, 0, 200f, 50f));
            UILabel lbl = new UILabel() 
            {
                Frame = new CGRect(0, 0, 280, 18)
            };
            lbl.TextColor = UIColor.White;              
            lbl.Font = UIFont.SystemFontOfSize(20f);                
            lbl.TextAlignment = UITextAlignment.Center;              
            lbl.Text = _usersList[(int)row];              
            return lbl;      
        }

    }

   
}