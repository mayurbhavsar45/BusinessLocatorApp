    using System;
using System.Collections.Generic;
using BusinessLocator.iOS.Model;
using Foundation;
using UIKit;
namespace BusinessLocator.iOS
{
    public class ChatViewTableSource : UITableViewSource
    {
        public static NSString CellID = new NSString("ChatCell");
        private List<ChatViewTableItemModel> _items;
        ChatViewController _VC;

        public ChatViewTableSource()
        {
        }

        //public ChatViewTableSource(List<ChatViewTableItemModel> items)
        //{
        //    this._items = items;
        //}

        public ChatViewTableSource(ChatViewController vc, List<ChatViewTableItemModel> items)
        {
            this._VC = vc;
            this._items = items;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _items.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellID, indexPath) as ChatViewCell;

            if(cell == null)
            {
                cell = new ChatViewCell(CellID);
            }

            var data = _items[indexPath.Row];
            cell.UpdateCell(data);
            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var selected_raw = _items[indexPath.Row];

            //new UIAlertView("Action", "You've Selected: " + selected_raw, null, "OK", null).Show();

            MessageViewController msgController = _VC.Storyboard.InstantiateViewController("MessageViewController") as MessageViewController;

            msgController.Name = selected_raw.Name;
            msgController.Image = selected_raw.Image;
            msgController.Status = selected_raw.Status;

            if(msgController!=null)
            {
                _VC.NavigationController.PushViewController(msgController, true);     
            }

            tableView.DeselectRow(indexPath, true);
        }
    }
}
