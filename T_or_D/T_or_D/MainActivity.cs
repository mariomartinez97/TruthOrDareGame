using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace T_or_D
{
    [Activity(Label = "T_or_D", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            Button customizedOption = FindViewById<Button>(Resource.Id.CustomizeButton);

            customizedOption.Click += (sender, e) =>
            {
                // Present the initial List (should be blank at first)
                var intent = new Intent(this, typeof(customizedList));
                StartActivity(intent);

            };
        }
    }
}

