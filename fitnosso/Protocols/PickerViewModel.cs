using System;
using Foundation;
using UIKit;
using System.Collections.Generic;
namespace fitnosso
{
    public enum UnitsMode { Metric, Imperial}
    public abstract class ListPickerViewModel<TItem> : UIPickerViewModel
    {
        
        public TItem SelectedItem { get; private set; }
        private IList<TItem> _Metric_items;
        private IList<TItem> _Alt;
        public UnitsMode MeasurementUnits;
        public IList<TItem> MetricItems
        {
            get 
            {
                return _Metric_items;
            }
            set
            {
                _Metric_items = value;
               // Selected(null, 0, 0);
            }
        }
        public IList<TItem> AlternateItems
        {
            get
            {
                return _Alt;
            }
            set
            {
                _Alt = value;
            }
        }
        private bool NoItem(int row = 0)
        {
            if (MeasurementUnits == UnitsMode.Metric)
            {
                return MetricItems == null || row >= MetricItems.Count;
            }
            else
            {
                return AlternateItems == null || row >= AlternateItems.Count;
            }
        }

        public ListPickerViewModel(List<TItem> p_Items)
        {
            MetricItems = p_Items;
            MeasurementUnits = UnitsMode.Metric;

        }

        
        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }
        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            if (NoItem())
            {
                return 1;
            }
            if (MeasurementUnits == UnitsMode.Metric)
            {
                return MetricItems.Count;
            }
            else
            {
                return AlternateItems.Count;
            }
        }
        
        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            if (NoItem((int)row))
            {
                return string.Empty;
            }
            if (MeasurementUnits == UnitsMode.Metric)
            {
                var item = MetricItems[(int)row];
                return item.ToString();
            }
            else
            {
                var item = AlternateItems[(int)row];
                return item.ToString();
            }
        }

    }
}
