// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace fitnosso
{
    [Register ("setupViewController")]
    partial class setupViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem bb_Create { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIDatePicker dobPicker { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView pickerView_Height { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView pickerViewGender { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView pickerViewWeight { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch sw_height { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch sw_weight { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtFieldJournalOwnerName { get; set; }

        [Action ("bb_create_touch:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void bb_create_touch (UIKit.UIBarButtonItem sender);

        [Action ("sw_height_change:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void sw_height_change (UIKit.UISwitch sender);

        [Action ("sw_weights_change:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void sw_weights_change (UIKit.UISwitch sender);

        void ReleaseDesignerOutlets ()
        {
            if (bb_Create != null) {
                bb_Create.Dispose ();
                bb_Create = null;
            }

            if (dobPicker != null) {
                dobPicker.Dispose ();
                dobPicker = null;
            }

            if (pickerView_Height != null) {
                pickerView_Height.Dispose ();
                pickerView_Height = null;
            }

            if (pickerViewGender != null) {
                pickerViewGender.Dispose ();
                pickerViewGender = null;
            }

            if (pickerViewWeight != null) {
                pickerViewWeight.Dispose ();
                pickerViewWeight = null;
            }

            if (sw_height != null) {
                sw_height.Dispose ();
                sw_height = null;
            }

            if (sw_weight != null) {
                sw_weight.Dispose ();
                sw_weight = null;
            }

            if (txtFieldJournalOwnerName != null) {
                txtFieldJournalOwnerName.Dispose ();
                txtFieldJournalOwnerName = null;
            }
        }
    }
}