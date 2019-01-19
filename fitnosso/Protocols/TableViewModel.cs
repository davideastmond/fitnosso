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
            string logtype_string = "";
            string exFoodString = "";
            int cKals = 0;

            if (CollectionSource[indexPath.Row] is FoodLogEntry)
            {
                FoodLogEntry flog = CollectionSource[indexPath.Row] as FoodLogEntry;
                // It's food, so it's an in
                logtype_string = "IN";
                exFoodString = flog.FoodEatenDescription;
                cKals = flog.cKalsEaten;

            }
            else
            {
                ExerciseLogEntry eLog = CollectionSource[indexPath.Row] as ExerciseLogEntry;
                exFoodString = eLog.ActivityCompleted.Description;
                // It's exercise - so it's an OUT
                logtype_string = "OUT";
                cKals = eLog.cKalsBurned;
            }

            //Grab the TableViewCell and cast it as my custom cell

            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, "idlogentry") as LogEntryViewCell ;
                

            }
            if (logtype_string == "IN")
            {
                cell.SetcKalLabelColor(UIColor.Red);
                cell.SetExerciseFoodText(exFoodString);
            }
            else
            {
                cell.SetcKalLabelColor(UIColor.Green);
                cell.SetExerciseFoodText(exFoodString);
            }
            cell.SetItemIDText(itemID);
            cell.SetInOutText(logtype_string);
            cell.SetcKalText(cKals.ToString());

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
