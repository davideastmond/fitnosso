using System;
using UIKit;
using System.Collections.Generic;
using Foundation;

namespace fitnosso
{
    public class TableViewSourceModel : UITableViewSource
    {
        public List<LogEntry> CollectionSource;
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            LogEntryViewCell cell = (LogEntryViewCell)tableView.DequeueReusableCell("idlogentry");
            string itemID = CollectionSource[indexPath.Row].EntryID;
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, "idlogentry") as LogEntryViewCell ;

            }
            cell.SetTextString(itemID);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return CollectionSource.Count;
        }
        public TableViewSourceModel(List<LogEntry> p_Items)
        {
            CollectionSource = p_Items;
        }
    }
}
