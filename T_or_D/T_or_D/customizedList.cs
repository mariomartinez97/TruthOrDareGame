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
    public class customizedList : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.customizedList);
            // Create your application here

            //create list
            List<string> listS = new List<string>();
            //retrive old list if exists
            
            //add the new item to the list

            //display list

            //save list

        }
    }
}