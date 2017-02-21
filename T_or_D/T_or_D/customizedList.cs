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
    [Activity(Label = "customizedList")]
    public class customizedList : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.customizedList);

            Button add = FindViewById<Button>(Resource.Id.addButton);
            Button continueButton = FindViewById<Button>(Resource.Id.continueButton);
            Button cancelButton = FindViewById<Button>(Resource.Id.cancelButton);


            add.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(AddScreen));
                StartActivity(intent);
            };
            
            //create list
            List<string> listTruths = new List<string>();
            List<string> listDares = new List<string>();
            //retrive old list if exists
            var sharedPref = Application.Context.GetSharedPreferences("MySavedData", FileCreationMode.Private);
            if (sharedPref.Contains("TruthsList"))
            {
                listTruths.AddRange(sharedPref.GetStringSet("TruthsList",null).ToArray());
            }
            if (sharedPref.Contains("DaresList"))
            {
                listDares.AddRange(sharedPref.GetStringSet("DaresList", null).ToArray());
            }

            //add the new item to the list
            if (sharedPref.Contains("Truths"))
            {
                string newInput = sharedPref.GetString("Truths", null);
                listTruths.Add(newInput);
            }
            if (sharedPref.Contains("Dares"))
            {
                string newInput = sharedPref.GetString("Dares", null);
                listDares.Add(newInput);
            }
            //display list
            List<string> completeList = new List<string>();            
            completeList = listTruths.Concat(listDares).ToList();
            ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, completeList);

            //save list
            var saveLists = Application.Context.GetSharedPreferences("MySavedData", FileCreationMode.Private);
            var edit = saveLists.Edit();

            edit.PutStringSet("TruthsList", listTruths);
            edit.PutStringSet("DaresList", listTruths);
            edit.Commit();


            cancelButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };
            continueButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(usersClass));
                StartActivity(intent);
            };

        }
    }
}