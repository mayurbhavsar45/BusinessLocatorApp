using System;
using System.Collections.Generic;
using BusinessLocator.iOS.Model;
using Foundation;
using UIKit;

namespace BusinessLocator.iOS
{
    public class UsersTableViewSource : UITableViewSource 
    {
        public static NSString CellID = new NSString("UserCell");
        private List<LocationsListViewItemModel> _items;

        public UsersTableViewSource(List<LocationsListViewItemModel> items)
        {
            this._items = items;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellID, indexPath) as UsersCell;

            if(cell == null)
            {
                cell = new UsersCell(CellID);
            }

            var data = _items[indexPath.Row];
            cell.UpdateCell(data);
            tableView.DeselectRow(indexPath, true);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _items.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var selected_row =  _items[indexPath.Row].Name;
            new UIAlertView("Alert","You've Selected: " + selected_row,null,"Ok", null).Show();
            tableView.DeselectRow(indexPath, true);
        }
    }
}
