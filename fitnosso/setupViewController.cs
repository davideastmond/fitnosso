﻿// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using UIKit;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using GlobalToast; using GlobalToast.Animation; using GlobalToast.ToastViews;

namespace fitnosso
{ 
    public partial class setupViewController : UIViewController
    {
        public UserRegistrationResultProtocol delegate_data = new UserRegistrationResultProtocol();

        public setupViewController (IntPtr handle) : base (handle)
        {


        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // We need to populate the PickerViews with heights and weights in metric and imperial measurements

            // Let's do the heights
            ListPopulator pop = new ListPopulator();
            List<double> Metric_Heights = pop.ReturnIntegersInRange(150, 220); // Heights in centimeters
            List<double> Imperial_Heights = pop.ReturnIntegersInRange(60, 86);
            // Get a model for the heights
            RegistrationStatusPickerViewModel<double> modelHeights = new RegistrationStatusPickerViewModel<double>(Metric_Heights);
            modelHeights.FontFromName = "HelveticaNeue";
            modelHeights.MeasurementUnits = UnitsMode.Metric; // Set default
            modelHeights.AlternateItems = Imperial_Heights;
            pickerView_Height.Model = modelHeights;


            // Get a model for the Genders
            List<Sex> pickerGendersForList = GetSexes();
            RegistrationStatusPickerViewModel<Sex> modelGenders = new RegistrationStatusPickerViewModel<Sex>(pickerGendersForList);
            modelGenders.FontFromName = "HelveticaNeue";
            pickerViewGender.Model = modelGenders;

            // Get a model for the weights
            List<double> Metric_Weights = pop.ReturnIntegersInRange(22, 200);
            List<double> Imperial_Weights = pop.ReturnIntegersInRange(60, 450);
            RegistrationStatusPickerViewModel<double> modelweights = new RegistrationStatusPickerViewModel<double>(Metric_Weights);
            modelweights.AlternateItems = Imperial_Weights;
            modelweights.FontFromName = "HelveticaNeue";
            pickerViewWeight.Model = modelweights;
        }
        private List<Sex> GetSexes()
        {
            List<Sex> sexes = new List<Sex>();
            sexes.Add(Sex.Male);
            sexes.Add(Sex.Female);
            sexes.Add(Sex.Other);
            return sexes;
        }


        partial void sw_height_change(UISwitch sender)
        {
            if (sender.On)
            {
                Console.WriteLine("Switched to selected");
                // This is when the height switch is toggled.
                var heightsModel = pickerView_Height.Model as RegistrationStatusPickerViewModel<double>;
                heightsModel.MeasurementUnits = UnitsMode.Imperial;
                pickerView_Height.Model = heightsModel;
                pickerView_Height.ReloadComponent(0);
               
            }
            
            else
            {
                Console.WriteLine("Not Selected");
                // This is when the height switch is toggled.
                var heightsModel = pickerView_Height.Model as RegistrationStatusPickerViewModel<double>;
                heightsModel.MeasurementUnits = UnitsMode.Metric;
                pickerView_Height.Model = heightsModel;
                pickerView_Height.ReloadComponent(0);
               
            }
            

        }

        partial void sw_weights_change(UISwitch sender)
        {
            // toggle the switch
            if (sender.On)
            {
                // Switched to selected
                var weightsModel = pickerViewWeight.Model as RegistrationStatusPickerViewModel<double>;
                weightsModel.MeasurementUnits = UnitsMode.Imperial;
                pickerViewWeight.Model = weightsModel;
                pickerViewWeight.ReloadComponent(0);

            }
            else
            {
                // Switch is de-selected
                var weightsModel = pickerViewWeight.Model as RegistrationStatusPickerViewModel<double>;
                weightsModel.MeasurementUnits = UnitsMode.Metric;
                pickerViewWeight.Model = weightsModel;
                pickerViewWeight.ReloadComponent(0);
               

            }
        }

        partial void bb_create_touch(UIBarButtonItem sender)
        {
            // Valid and process the information
            // Create a new user

            var selectedGender = (int)pickerViewGender.SelectedRowInComponent(0);


            // Validate the journal name. If the box is empty, supply a default
            if (txtFieldJournalOwnerName.Text == String.Empty)
            {

                // Prompt the user that they have not entered a name and that a default will be created.

                UIAlertController regAlert = UIAlertController.Create("Attention", "Journal Owner Name has not been supplied. Click OK to use the default. Click Go Back to enter a name.", UIAlertControllerStyle.Alert);
                regAlert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, action => populateDefaultTextBox()));
                regAlert.AddAction(UIAlertAction.Create("Go Back", UIAlertActionStyle.Cancel, null));
                PresentViewController(regAlert, true, null);
            }
            if (txtFieldJournalOwnerName.Text == string.Empty)
            {

                return;
            }

            User NewJournalUser = new User(txtFieldJournalOwnerName.Text, (Sex)selectedGender, (DateTime)dobPicker.Date);

            if (sw_height.On)
            {
                // Imperial units will be captured and metric units will automatically be computed
                double selectedHeight_Imperial = pickerView_Height.SelectedRowInComponent(0); // Capture the measurement
                NewJournalUser.Pref_HeightMeasurementUnit = UnitsMode.Imperial; // Set the preference
                NewJournalUser.ImperialHeight = (double)selectedHeight_Imperial;
                NewJournalUser.MetricHeight = MetricConverter.ToCentimeters(NewJournalUser.ImperialHeight); // Set the metric conversion
            }
            else
            {
                // If it's off, metric units will be captured
                double selected_height_Metric = pickerView_Height.SelectedRowInComponent(0); // Capture the metric units
                NewJournalUser.Pref_HeightMeasurementUnit = UnitsMode.Metric; // Set preference
                NewJournalUser.MetricHeight = (double)selected_height_Metric;
                NewJournalUser.ImperialHeight = MetricConverter.ToInches(NewJournalUser.MetricHeight);
            }

            // Create a journal object
            FitnessJournal journalObject = new FitnessJournal(NewJournalUser);
            JournalController.Save(journalObject);
            // Serialize and write to file

            // Send a message via the delegate
            RegistrationReturnData returndata;
            returndata.Successful = true;
            this.delegate_data.RaiseEvent(this, returndata);
        }

        private void populateDefaultTextBox()
        {
            txtFieldJournalOwnerName.Text = "Untitled Journal Owner";
        }
    }
    public class RegistrationStatusPickerViewModel<TItem> : ListPickerViewModel<TItem>
    {
        public string FontFromName = "Avenir";
        public float FontSize = 18f;
        public RegistrationStatusPickerViewModel(List<TItem> p_Items) : base(p_Items)
        {

        }
        public override UIView GetView(UIPickerView pickerView, nint row, nint component, UIView view)
        {
            UILabel pickerLabel = (UILabel)view; // Cast as a UILabel
            if (pickerLabel == null)
            {
                pickerLabel = new UILabel();
                pickerLabel.Font = UIFont.FromName(FontFromName, FontSize);
                pickerLabel.TextAlignment = UITextAlignment.Center;
            }
            if (MeasurementUnits == UnitsMode.Metric)
            {
                var item = MetricItems[(int)row];
                pickerLabel.Text = item.ToString();
                return pickerLabel;
            }
            else
            {
                var item = AlternateItems[(int)row];
                pickerLabel.Text = item.ToString();
                return pickerLabel;
            }

        }
    }

}
