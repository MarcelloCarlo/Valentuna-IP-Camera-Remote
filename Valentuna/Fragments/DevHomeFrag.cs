using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Android.App;

using System;
using Android.Content;

namespace Valentuna.Fragments
{
    public class DevHome : Android.Support.V4.App.Fragment
    {
        

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


        }

        public static DevHome NewInstance()
        {
            var devHome = new DevHome { Arguments = new Bundle() };

            return devHome;
        }
        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var DevHomeView = inflater.Inflate(Resource.Layout.DevHomeFrag, container, false);

            var listDialogButton = DevHomeView.FindViewById<Button>(Resource.Id.btnAutoDiscoverDevice);
            listDialogButton.Click += ListdialogButton_Click;

            var addDeviceManualButton = DevHomeView.FindViewById<Button>(Resource.Id.btnAddDeviceManual);
            addDeviceManualButton.Click += AddDeviceManualButton;

            return DevHomeView;
        }
        void ListdialogButton_Click(object sender, EventArgs e)
        {
            var activity2 = new Intent(Activity, typeof(AdddeviceActivity));
            activity2.PutExtra("buttonClicked", 1);
            StartActivity(activity2);
        }
        void AddDeviceManualButton(object sender, EventArgs e)
        {
            var activity2 = new Intent(Activity, typeof(AdddeviceActivity));
            activity2.PutExtra("buttonClicked", 2);
            StartActivity(activity2);
        }
    }
}