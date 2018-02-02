using System;
using System.Collections.Generic;
using BusinessLocator.iOS.Model;
using Foundation;
using UIKit;

namespace BusinessLocator.iOS
{
    public class NotificationsViewTableSource : UITableViewSource
    {
        public static NSString CellID = new NSString("NotificationCell");
        private List<NotificationTableItemModel> _items;

        public NotificationsViewTableSource()
        {
        }

        public NotificationsViewTableSource(List<NotificationTableItemModel> items)
        {
            this._items = items;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _items.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellID, indexPath) as NotificationsCell;

            if (cell == null)
            {
                cell = new NotificationsCell(CellID);
            }

            var data = _items[indexPath.Row];
            cell.UpdateCell(data);
            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var selected_raw = _items[indexPath.Row].Name;

            new UIAlertView("Action", "You've Selected: " + selected_raw, null, "OK", null).Show();

            tableView.DeselectRow(indexPath, true);
        }
       
    }
}
