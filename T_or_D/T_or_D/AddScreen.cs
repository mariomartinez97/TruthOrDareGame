using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace T_or_D
{
    [Activity(Label = "AddScreen")]
    public class AddScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddScreen);
            // Create your application here

            Button saveButton = FindViewById<Button>(Resource.Id.saveButton);
            Button cancelButton = FindViewById<Button>(Resource.Id.cancelButton);

            RadioGroup radioButton = FindViewById<RadioGroup>(Resource.Id.radioGroup1);
            RadioButton checkedButton = FindViewById<RadioButton>(radioButton.CheckedRadioButtonId);            


            saveButton.Click += (sender, e) =>
            {
                EditText inputText = FindViewById<EditText>(Resource.Id.textInput);
                string input = inputText.Text;

                var saveString = Application.Context.GetSharedPreferences("MySavedData", FileCreationMode.Private);
                var edit = saveString.Edit();

                if (checkedButton.Id == Resource.Id.radioButtonTruth)
                {
                    edit.PutString("Truths", input);
                    edit.Commit();
                    Android.Widget.Toast.MakeText(this, "Added to the list", ToastLength.Short).Show();
                    inputText.Text = "";
                }
                if (checkedButton.Id == Resource.Id.radioButtonCancel)
                {
                    edit.PutString("Dares", input);
                    edit.Commit();
                    Android.Widget.Toast.MakeText(this, "Added to the list", ToastLength.Short).Show();
                    inputText.Text = "";
                }
            };

            cancelButton.Click += (sender, e) =>
            {                                
                var intent = new Intent(this, typeof(customizedList));
                StartActivity(intent);
            };
        }
    }
}