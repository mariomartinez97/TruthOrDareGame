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
    public class OnAddUserEventsArgs : EventArgs
    {
        private string mName;

        public string Name
        {
            get{return mName;}

            set{ mName = value;}
        }
        public OnAddUserEventsArgs(string _name) : base()
        {
            Name = _name;
        }
    }
    public class screenFragmentClass : DialogFragment
    {
        EditText mNameInput;
        Button mNextButton;
        Button mCancelButton;

        public event EventHandler<OnAddUserEventsArgs> mOnAddUser;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.screen_fragment, container, false);

            mNameInput = view.FindViewById<EditText>(Resource.Id.userNameinput);
            mNextButton = view.FindViewById<Button>(Resource.Id.addUserButton);
            mCancelButton = view.FindViewById<Button>(Resource.Id.cancelAddUserButton);


            mNextButton.Click += (sender, e) =>
            {
                mOnAddUser.Invoke(this, new OnAddUserEventsArgs(mNameInput.Text));
                this.Dismiss();
            };
            mCancelButton.Click += (sender, e) =>
            {
                this.Dismiss();
            };
            
            return view;
        }
    }
}