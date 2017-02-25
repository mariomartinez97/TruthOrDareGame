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
using Java.Interop;

namespace T_or_D
{
    [Activity(Label = "AddScreen")]
    public class AddScreen : Activity
    {
        bool t = true;
        [Export("radioButton_OnClick")]
        public void radioButton_OnClick(View v)
        {
            switch (v.Id)
            {
                case Resource.Id.radioButtonTruth:
                    t = true;
                    break;
                case Resource.Id.radioButtonDare:
                    t = false;
                     break;
            }
        }
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
                inputText.Text = null;

                var saveTruths = Application.Context.GetSharedPreferences("MySavedTruths", FileCreationMode.Private);
                var editT = saveTruths.Edit();
                var saveDares = Application.Context.GetSharedPreferences("MySavedDares", FileCreationMode.Private);
                var editD = saveTruths.Edit();

                if (inputText.Text != null)
                {
                    if (t)
                    {
                        editT.PutString("Truths", input);
                        editT.Commit();
                        Android.Widget.Toast.MakeText(this, "Added to the list", ToastLength.Short).Show();
                        inputText.Text = "";
                    }
                    else if (t == false)
                    {
                        editD.PutString("Dares", input);
                        editD.Commit();
                        Android.Widget.Toast.MakeText(this, "Added to the list", ToastLength.Short).Show();
                        inputText.Text = "";
                    }
                    inputText.Text = null;

                    var intent = new Intent(this, typeof(customizedList));
                    StartActivity(intent);
                }
                else
                {
                    Android.Widget.Toast.MakeText(this, "You cant have an empty truth or dare", ToastLength.Short).Show();
                }
                
            };

            cancelButton.Click += (sender, e) =>
            {             
                EditText inputText = FindViewById<EditText>(Resource.Id.textInput);
                inputText.Text = null;

                var saveStringA = Application.Context.GetSharedPreferences("MySavedDares", FileCreationMode.Private);
                var editA = saveStringA.Edit();

                var saveString = Application.Context.GetSharedPreferences("MySavedTruths", FileCreationMode.Private);
                var edit = saveString.Edit();
                edit.Clear();
                edit.Commit();
                editA.Clear();
                editA.Commit();

                var intent = new Intent(this, typeof(customizedList));
                StartActivity(intent);
            };
        }
    }
}