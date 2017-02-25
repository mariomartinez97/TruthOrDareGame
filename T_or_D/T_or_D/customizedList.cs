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
        //create list
        List<string> listTruths = new List<string>();
        List<string> listDares = new List<string>();
        List<string> completeList = new List<string>();

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

            var saveTruths = Application.Context.GetSharedPreferences("MySavedTruths", FileCreationMode.Private);
            var saveDares = Application.Context.GetSharedPreferences("MySavedDares", FileCreationMode.Private);

            //add the new item to the list
            if (saveTruths.Contains("Truths"))
            {
                string newInput = saveTruths.GetString("Truths", null);
                listTruths.Add(newInput);
            }
            if (saveDares.Contains("Dares"))
            {
                string newInput = saveDares.GetString("Dares", null);
                listDares.Add(newInput);
            }

            //retrive old list if exists
            if (saveTruths.Contains("TruthsList"))
            {
                listTruths.AddRange(saveTruths.GetStringSet("TruthsList", null).ToArray());
            }
            if (saveDares.Contains("DaresList"))
            {
                listDares.AddRange(saveDares.GetStringSet("DaresList", null).ToArray());
            }

            
            //display list
            completeList = listTruths.Concat(listDares).ToList();
            ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, completeList);

            //save list

            var editT = saveTruths.Edit();
            var editD = saveTruths.Edit();
            

            editT.PutStringSet("TruthsList", listTruths);
            editT.Commit();
            editD.PutStringSet("DaresList", listDares);
            editD.Commit();

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