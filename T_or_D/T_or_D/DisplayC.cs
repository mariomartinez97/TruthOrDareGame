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
    [Activity(Label = "DisplayC")]
    public class DisplayC : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.DisplayScreen);

            EditText inputText = FindViewById<EditText>(Resource.Id.textInput3);
            Button nextButton = FindViewById<Button>(Resource.Id.nextbutton);

            List<string> listTruths = new List<string>();
            //retrive old list if exists
            var sharedPref = Application.Context.GetSharedPreferences("MySavedData", FileCreationMode.Private);
            if (sharedPref.Contains("TruthsList"))
            {
                listTruths.AddRange(sharedPref.GetStringSet("TruthsList", null).ToArray());
            }

            Functions f = new Functions();
            string text;

            nextButton.Click += (sender, e) =>
            {
                text = f.RandomUser(listTruths);
                inputText.Text = text;
            };
            
        }
    }
}