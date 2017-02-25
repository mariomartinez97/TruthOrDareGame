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
    [Activity(Label = "usersClass")]
    public class usersClass : ListActivity
    {
        List<string> namesList = new List<string>();

        
protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.UsersScreen);
            Button AddButton = FindViewById<Button>(Resource.Id.addUsers);
            Button ContinueButton = FindViewById<Button>(Resource.Id.continueOnUser);
            
            checkAdd();
            ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, namesList);

            AddButton.Click += (object sender, EventArgs args) =>
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                screenFragmentClass fragmentScreen = new screenFragmentClass();
                fragmentScreen.mOnAddUser += FragmentScreen_mOnAddUser;
                fragmentScreen.Show(transaction, "fragment");

            };
            ContinueButton.Click += (object sender, EventArgs args) =>
            {
                var intent = new Intent(this, typeof(DisplayC));
                StartActivity(intent);
            };
        }
        private void FragmentScreen_mOnAddUser(object sender, OnAddUserEventsArgs e)
        {
            var sharedPref = Application.Context.GetSharedPreferences("MySavedData", FileCreationMode.Private);

            
            string a;
            a = e.Name;
            namesList.Add(a);
            ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, namesList);

            var edit = sharedPref.Edit();
            edit.PutStringSet("NamesList", namesList);
            edit.Commit();
        }
        public void checkAdd()
        {
            var sharedPref = Application.Context.GetSharedPreferences("MySavedData", FileCreationMode.Private);
            try
            {
                namesList.AddRange(sharedPref.GetStringSet("NamesList", null).ToArray());
            }
            catch (ArgumentNullException)
            {

            }
        }
    }
}