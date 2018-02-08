using System;
using System.Collections.Generic;
using BusinessLocator.iOS.Model;
using Foundation;
using UIKit;

namespace BusinessLocator.iOS
{
    public class ConsumerTableSource : UITableViewSource
    {
        public static string CellID = new NSString("ConsumerCell");
        ConsumerReviewViewController _VC;
        private List<ConsumerViewTableItemModel> _listItem;

        public ConsumerTableSource(ConsumerReviewViewController vc, List<ConsumerViewTableItemModel> items)
        {
            this._VC = vc;
            this._listItem = items;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellID, indexPath) as ConsumerCell;

            if(cell==null)
            {
                cell = new ConsumerCell(CellID);
            }

            var data = _listItem[indexPath.Row];
            cell.UpdateCell(data);
            return cell;                                
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _listItem.Count;
        }
    }
}
